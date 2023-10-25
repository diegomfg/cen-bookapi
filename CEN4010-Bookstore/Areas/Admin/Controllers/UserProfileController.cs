using System.Security.Cryptography;
using CEN4010_Bookstore.Data;
using CEN4010_Bookstore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

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
        public List<UserProfile> GetProfiles()
        {
            List<UserProfile> UserProfiles = _db.UserProfiles.ToList();
            return UserProfiles;

        }

        [HttpPost]
        public String Create([FromBody] UserProfile userProfile)
        {

            return "Create user profile";

        }

    }
}

