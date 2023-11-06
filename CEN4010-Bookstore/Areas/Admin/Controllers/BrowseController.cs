// CODE IS SUBJECT TO CHANGE - FILE IS NOT FINAL!

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CEN4010_Bookstore.Models;
using CEN4010_Bookstore.Data;

namespace CEN4010_Bookstore.Controllers
{
    public class BookController : Controller
    {
        private List<Book> GetBooks()
        {

            return new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", AuthorId = 1, GenreId = 1, ISBN = "1234567890", MSRP = 29, Description = "Description of Book 1", YearPublished = 2020, ImgID = "img1" },
                new Book { Id = 2, Title = "Book 2", AuthorId = 2, GenreId = 2, ISBN = "2345678901", MSRP = 19, Description = "Description of Book 2", YearPublished = 2019, ImgID = "img2" },
                // Add more books here
            };
        }

        public IActionResult Index(string sortOrder)
        {
            ViewBag.TitleSortParam = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.AuthorSortParam = sortOrder == "Author" ? "author_desc" : "Author";
            ViewBag.PriceSortParam = sortOrder == "MSRP" ? "msrp_desc" : "MSRP";

            var books = GetBooks();

            switch (sortOrder)
            {
                case "title_desc":
                    books = books.OrderByDescending(b => b.Title).ToList();
                    break;
                case "Author":
                    books = books.OrderBy(b => b.AuthorId).ToList();
                    break;
                case "author_desc":
                    books = books.OrderByDescending(b => b.AuthorId).ToList();
                    break;
                case "MSRP":
                    books = books.OrderBy(b => b.MSRP).ToList();
                    break;
                case "msrp_desc":
                    books = books.OrderByDescending(b => b.MSRP).ToList();
                    break;
                default:
                    books = books.OrderBy(b => b.Title).ToList();
                    break;
            }

            return View(books);
        }
    }
}
