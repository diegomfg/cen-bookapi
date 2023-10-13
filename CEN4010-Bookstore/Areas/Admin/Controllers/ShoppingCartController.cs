using CEN4010_Bookstore.Data;
using CEN4010_Bookstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CEN4010_Bookstore.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ShoppingCartController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public List<ShoppingCart> GetShoppingCartProfiles()
        {
            List<ShoppingCart> SCProfiles = _db.ShoppingCarts.ToList();
            return SCProfiles;

        }
    }
}
