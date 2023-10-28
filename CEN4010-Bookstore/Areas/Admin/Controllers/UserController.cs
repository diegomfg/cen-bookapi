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
        public IActionResult GetUsers()
        {

            List<User> users = _db.Users.ToList();
            if(users != null){
                return Json(new {data=users});
            } else return Json(new {message="Can't find users"});

        }

        [HttpGet]
        public IActionResult GetById(int? id)
        {
            if (id == null || id == 0)
            {
                return Json(new {message = "Id cannot is invalid"});
            }

            User foundInDB = _db.Users.Find(id);

            return Json(foundInDB);

        }

        [HttpPut]
        public User Update([FromBody] User user)
        {
            _db.Users.Update(user);
            if (_db.SaveChanges() > 0)
                return user;
            return null;
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var deleted = _db.Users.Where(user => user.Id.Equals(id)).ExecuteDelete();
            if(deleted > 0){
                return Json(new {message = "Successfully deleted"});
            } else return Json(new {message = "Can't delete user"});
        }

    }
}