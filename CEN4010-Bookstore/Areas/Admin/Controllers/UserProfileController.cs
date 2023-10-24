using System.Security.Cryptography;
using CEN4010_Bookstore.Data;
using CEN4010_Bookstore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace CEN4010_Bookstore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserProfileController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserProfileController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetProfiles()
        {
            List<UserProfile> UserProfiles = _db.UserProfiles.Include(u => u.User).ToList();
            // List<UserProfile> UserProfiles = _db.UserProfiles.ToList();
            return Json(new {data = UserProfiles});

        }

        [HttpPost]
        public String Create([FromBody] UserProfile userProfile)
        {
            var payload = _db.UserProfiles.Add(userProfile);
            if (_db.SaveChanges() > 0)
                return "Create user profile";
            else
                return "error creating user profile";

        }

    }
}

