using CEN4010_Bookstore.Data;
using CEN4010_Bookstore.Models;
using CEN4010_Bookstore.Repository;
using CEN4010_Bookstore.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;

namespace CEN4010_Bookstore.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class GenreController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Genre> objCategoryList = _unitOfWork.Genre.GetAll().ToList();
            return View(objCategoryList);
        }

        [HttpGet]
        public List<Genre> GetGenres()
        {
            List<Genre> genres = _unitOfWork.Genre.GetAll().ToList();
            return genres;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm] Genre obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (obj.Name != null && obj.Name.ToLower() == "test")
            {
               
 ModelState.AddModelError("", "Test is an invalid value");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Genre.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Genre created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Genre? genreFromDb = _unitOfWork.Genre.Get(u => u.Id == id);
            if (genreFromDb == null)
            {
                return NotFound();
            }
            return View(genreFromDb);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] Genre obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Genre.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Genre updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 100)
            {
                return NotFound();
            }

            Genre? genreFromDb = _unitOfWork.Genre.Get(u => u.Id == id);
            if (genreFromDb == null)
            {
                return NotFound();
            }
            return View(genreFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Genre obj = _unitOfWork.Genre.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Genre.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Genre deleted successfully";
            return RedirectToAction("Index");


        }

    }
}
