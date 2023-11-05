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
            if (UserProfiles == null)
            {
                return Json(new { message = "Unable to find data" });
            }
            else return Json(new { data = UserProfiles });

        }

        [HttpPost]
        public IActionResult Create([FromBody] UserProfile userProfile)
        {
            var payload = _db.UserProfiles.Add(userProfile);
            if (_db.SaveChanges() > 0)
                return Json(new { message = "Success CREATING User Profile" });
            else
                return Json(new { message = $"Error CREATING new profile for user: {userProfile.User}" });

        }

        [HttpGet]
        public IActionResult GetById(int? id)
        {
            UserProfile? profile = _db.UserProfiles
                .Include(uP => uP.User)
                .FirstOrDefault(uP => uP.Id == id);

            if (profile != null)
            {
                return Json(profile);
            }
            else return Json(new { message = "Unable to FIND User Profile" });
        }

        [HttpPut]
        public IActionResult Update([FromBody] UserProfile profileToEdit)
        {

            _db.UserProfiles.Update(profileToEdit);

            if (_db.SaveChanges() > 0)
            {

                return Json(new { message = "Successfully EDITED profile" });

            }
            else return Json(new { message = "Unable to find profile" });

        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            _db.UserProfiles.Where(uP => uP.Id.Equals(id)).ExecuteDelete();
            _db.SaveChanges();
            return Json(new { message = "Profile Deleted" });

        }
    }
}

