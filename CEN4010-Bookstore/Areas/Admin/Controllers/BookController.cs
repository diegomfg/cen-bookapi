using CEN4010_Bookstore.Data;
using CEN4010_Bookstore.Models;
using CEN4010_Bookstore.Models.ViewModels;
using CEN4010_Bookstore.Repository;
using CEN4010_Bookstore.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace CEN4010_Bookstore.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Book> objBookList = _unitOfWork.Book.GetAll(includeProperties:"Genre").ToList();
            return View(objBookList);
        }

        [HttpGet]
        public List<Book> GetBooks()
        {
            List<Book> books = _unitOfWork.Book.GetAll().ToList();
            return books;
        }
        public IActionResult Upsert(int? id) 
        {
            BookVM bookVM = new()
            {
                GenreList = _unitOfWork.Genre.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),
                Book = new Book()
            };

            if(id==null || id ==0)
            {
                //create
                return View(bookVM); 

            }
            else
            {
                //update
                bookVM.Book = _unitOfWork.Book.Get(u => u.Id == id);
                return View(bookVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert([FromForm] BookVM bookVM, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\books");

                    if (!string.IsNullOrEmpty(bookVM.Book.ImgID))
                    {
                        //delete old img
                        var oldImagePath = 
                            Path.Combine(wwwRootPath, bookVM.Book.ImgID.TrimStart('\\'));
                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    bookVM.Book.ImgID = @"\images\books\" + fileName;
                }


                if(bookVM.Book.Id == 0)
                {
                    _unitOfWork.Book.Add(bookVM.Book);
                }
                else
                {
                    _unitOfWork.Book.Update(bookVM.Book);
                }
                _unitOfWork.Save();
                TempData["success"] = "Book created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
       
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book? BookFromDb = _unitOfWork.Book.Get(u => u.Id == id);
            if (BookFromDb == null)
            {
                return NotFound();
            }
            return View(BookFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Book obj = _unitOfWork.Book.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Book.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Book deleted successfully";
            return RedirectToAction("Index");


        }

    }
}
