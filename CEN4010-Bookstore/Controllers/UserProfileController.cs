using System.Security.Cryptography;
using CEN4010_Bookstore.Data;
using CEN4010_Bookstore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace CEN4010_Bookstore.Controllers
{
    [ApiController]
    public class UserProfileController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserProfileController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("/api/[controller]/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("get-profiles")]
        [HttpGet]
        public List<UserProfile> GetProfiles()
        {

            
            return _db.UserProfiles.ToList();

        }

    }
}