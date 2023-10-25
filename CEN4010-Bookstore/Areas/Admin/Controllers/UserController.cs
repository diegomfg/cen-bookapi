using System.Security.Cryptography;
using CEN4010_Bookstore.Data;
using CEN4010_Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CEN4010_Bookstore.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        public List<User> GetUsers()
        {

            List<User> users = _db.Users.ToList();

            return users;

        }

        [HttpGet]
        public User? GetById(int? id)
        {
            if (id == null || id == 0)
            {
                return null;
            }

            User foundInDB = _db.Users.Find(id);

            return foundInDB;

        }

        [HttpPut]
        public OkObjectResult Update([FromBody] User user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
            return Ok("Record has been updated");
        }

        [HttpDelete]
        public int Delete(int? id)
        {
            var user = _db.Users.Where(user => user.Id.Equals(id)).ExecuteDelete();
            return user;
        }

    }
}