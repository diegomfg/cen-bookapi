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

    public class AuthorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AuthorController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Author> objAuthorList = _unitOfWork.Author.GetAll(includeProperties: "Publisher").ToList();
            return View(objAuthorList);
        }

        [HttpGet]
        public List<Author> GetAuthor()
        {
            List<Author> Author = _unitOfWork.Author.GetAll().ToList();
            return Author;
        }
        public IActionResult Upsert(int? id)
        {
            AuthorVM authorVM = new()
            {
                PublisherList = _unitOfWork.Publisher.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),
                Author = new Author()
            };

            if (id == null || id == 0)
            {
                //create
                return View(authorVM);

            }
            else
            {
                //update
                authorVM.Author = _unitOfWork.Author.Get(u => u.Id == id);
                return View(authorVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert([FromForm] AuthorVM authorVM)
        {

            if (ModelState.IsValid)
            {

                if (authorVM.Author.Id == 0)
                {
                    _unitOfWork.Author.Add(authorVM.Author);
                }
                else
                {
                    _unitOfWork.Author.Update(authorVM.Author);
                }
                _unitOfWork.Save();
                TempData["success"] = "Author created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Author> objAuthorList = _unitOfWork.Author.GetAll(includeProperties: "Publisher").ToList();
            return Json(new { data = objAuthorList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var authorToBeDeleted = _unitOfWork.Author.Get(u => u.Id == id);

            if (authorToBeDeleted == null)
            {
                return Json(new { success = false, message = "error while deleting" });
            }

            _unitOfWork.Author.Remove(authorToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "delete successful" });
        }
        #endregion 

    }
}
