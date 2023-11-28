using CEN4010_Bookstore.Data;
using CEN4010_Bookstore.Models;
using CEN4010_Bookstore.Repository;
using CEN4010_Bookstore.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CEN4010_Bookstore.Areas.Admin.Controllers
{
        [Area ("Admin")]
    public class ShoppingCartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;
        public ShoppingCartController(ApplicationDbContext db, IUnitOfWork unitOfWork)
        {
            _db = db;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<ShoppingCart> GetShoppingCarts()            
        {
            List<ShoppingCart> shoppingCarts = _db.ShoppingCarts.ToList();
            return shoppingCarts;

        }
        public List<ShoppingCart> GetBooksInCart(int UserId)
        {
            List<ShoppingCart> shoppingCartList = _unitOfWork.ShoppingCart.GetAll(includeProperties: "Book,User").ToList();
            shoppingCartList = shoppingCartList.Where(x => x.UserId == UserId).ToList();
            return shoppingCartList;
            
        }
        public decimal GetTotal(int userId) {
            var Total = _db.ShoppingCarts.Where(x => x.UserId == userId);

            return ((decimal)Total.Sum(x => x.Book.MSRP));
        
        }

        [HttpPost]
        public ShoppingCart addBook(ShoppingCart shoppingCartItem, int bookId, int UserId)
        {
            _unitOfWork.ShoppingCart.Add(shoppingCartItem);
            _unitOfWork.Save();
            return shoppingCartItem;
        }

        [HttpDelete]
        public IActionResult Delete(int bookId, int userId)
        {
            var ShoppingCartBook = _unitOfWork.ShoppingCart.Get(u => u.BookId == bookId);
            var ShoppingCartUser = _unitOfWork.ShoppingCart.Get(u => u.UserId == userId);

            if (ShoppingCartUser != null && ShoppingCartBook != null)
            {
                _unitOfWork.ShoppingCart.Remove(ShoppingCartBook);
                _unitOfWork.Save();
                return Json(new { success = true, message = "delete successful" });
            } 
            else if (ShoppingCartBook == null)
            {
                return Json(new { success = false, message = "Book not found" });
            } 
            else 
            {
                return Json(new { success = false, message = "User not found" });
            }       
        }

    }
}
