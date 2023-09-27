using System.Security.Cryptography;
using CEN4010_Bookstore.Data;
using CEN4010_Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CEN4010_Bookstore.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public User Create([FromBody] User user)
        {
            Console.WriteLine(user.ToString());
            _db.Users.Add(user);
            _db.SaveChanges();
            return user;
        }

        [HttpGet]
        public List<User>? GetByUserName([FromQuery] string username)
        {
            Console.WriteLine($"Received from query: {username}");

            List<User> users = _db.Users.Where(user => user.UserName.Contains(username)).ToList();

            return users;

        }

        // Finds user by Email (Approximately)
        [HttpGet]
        public List<User>? GetByEmail([FromQuery] string possibleEmail)
        {
            List<User> users = _db.Users.Where(user => user.Email.Contains(possibleEmail)).ToList();
            return users;
        }

        /**
        * @todo Create Edit route
        *       Create Delete route
        *
        */

        [HttpGet]
        public User? Update(int? id)
        {
            // As expected. Doesn't work.
            var user = _db.Users.Find(id);
            return user;
        }

        [HttpDelete]
        public int Delete(int? id){
            // Pending
            var user = _db.Users.Where(user => user.Id.Equals(id)).ExecuteDelete();
            return user;
        }

    }
}