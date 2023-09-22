using System.Security.Cryptography;
using CEN4010_Bookstore.Data;
using CEN4010_Bookstore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace CEN4010_Bookstore.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("/api/[controller]/")]
        public IActionResult Index()
        {
            /*
                Creates a user object AND a user profile object simultaneously.
                Saves associated changes.
            */
            return View();
        }

        [Route("get-users")]
        [HttpGet]
        public List<User> GetUsers()
        {

            // Can't find anything for some reason... Migrations?
            return _db.Users.ToList();

        }

    }
}