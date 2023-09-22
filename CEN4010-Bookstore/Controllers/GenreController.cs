using CEN4010_Bookstore.Data;
using CEN4010_Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace CEN4010_Bookstore.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
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

        [HttpPost]
        public IActionResult Create(Genre obj)
        {
            _db.Genres.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

       

    }
}
