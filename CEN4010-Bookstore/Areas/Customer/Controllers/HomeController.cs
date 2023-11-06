using CEN4010_Bookstore.Models;
using CEN4010_Bookstore.Repository;
using CEN4010_Bookstore.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CEN4010_Bookstore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Book> bookList = _unitOfWork.Book.GetAll(includeProperties: "Genre,Author");
            return View(bookList);
        }
        public IActionResult Details(int bookId)
        {
            Book book = _unitOfWork.Book.Get(u => u.Id == bookId, includeProperties: "Genre,Author");
            return View(book);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}