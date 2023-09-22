using System.Security.Cryptography;
using CEN4010_Bookstore.Data;
using CEN4010_Bookstore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CEN4010_Bookstore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            // User diego = new User { UserName = "diegomp0x", Password = "12356asd6486!", Address = "1234 NW 43 ST Miami, FL, 33178", LastName = "Matheus", FirstName = "Diego", Id = new Random(0).Next(), UserTypeId = 1, PaymentId = 1 };
            // _db.Users.Add(diego);
            // _db.SaveChanges();
            return View();
        }

        [HttpGet]
        public List<User> GetUsers()
        {

            // Can't find anything for some reason... Migrations?
            return _db.Users.ToList();

        }

    }
}