using CEN4010_Bookstore.Data;
using CEN4010_Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;

namespace CEN4010_Bookstore.Controllers
{


    public class GenreController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GenreController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Genre> objCategoryList = _db.Genres.ToList();
            return View(objCategoryList);
        }

        [HttpGet]
        public List<Genre> GetGenres()
        {
            List<Genre> genres = _db.Genres.ToList();
            return genres;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm] Genre obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString()){
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (obj.Name !=null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an invalid value");
            }
            if (ModelState.IsValid)
            {
                _db.Genres.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Genre created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }

            Genre? genreFromDb = _db.Genres.Find(id);
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
                _db.Genres.Update(obj);
                _db.SaveChanges();
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

            Genre? genreFromDb = _db.Genres.Find(id);
            if (genreFromDb == null)
            {
                return NotFound();
            }
            return View(genreFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Genre obj = _db.Genres.Find(id); if (obj == null)
            {
                return NotFound();
            }
            _db.Genres.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Genre deleted successfully";


            return RedirectToAction("Index");


        }

    }
}
