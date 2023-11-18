using CEN4010_Bookstore.Data;
using CEN4010_Bookstore.Models;
using CEN4010_Bookstore.Repository;
using CEN4010_Bookstore.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CEN4010_Bookstore.Areas.Admin.Controllers
{
    /*[Route("api/[controller]/[action]")]
    [ApiController]*/
    // Assign a user id to each user
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
        public List<ShoppingCart> GetShoppingCartProfiles()
        {
            List<ShoppingCart> SCProfiles = _db.ShoppingCarts.ToList();
            return SCProfiles;

        }
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBookList(int UserId)
        {
            var cartBooks = GetBookInCart(UserId);

            if (cartBooks == null || !cartBooks.Any())
            {
                return NotFound("No books found in the User's shopping cart.");
            }

            return Ok(cartBooks);
        }

        private IEnumerable<Book> GetBookInCart(int userId)
        {
            var Books = new List<Book>
            {
                new Book {},
                new Book {},
                new Book{}
            };
           

            return Books;
        }
        //TEST
        public IActionResult GetBooks1(int UserId)
        {
            List<ShoppingCart> shoppingCartList = _unitOfWork.ShoppingCart.GetAll(includeProperties: "Book,User").ToList();
            shoppingCartList = shoppingCartList.Where(x => x.UserId == UserId).ToList();
            return Json(new { Data = shoppingCartList });
        }
        



        /*[HttpPost]
        public IActionResult addBook(ShoppingCart book)
        {
            if (ModelState.IsValid)
            {
                _db.ShoppingCarts.Add(book);
                _db.SaveChanges();
                TempData["success"] = "Book added successfully";
            }
            return View();
        }*/


            /*var shoppingCartItems = new List<ShoppingCart>;

            var bookIdsInCart = shoppingCartItems.Select(item => item.BookId).ToList();
            var booksInCart = GetBooksFromDatabase(bookIdsInCart);

            return booksInCart;*/
    }
}
