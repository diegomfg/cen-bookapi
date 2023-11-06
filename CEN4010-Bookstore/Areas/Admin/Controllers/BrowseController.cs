using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CEN4010_Bookstore.Models;
using CEN4010_Bookstore.Data;

namespace CEN4010_Bookstore.Controllers

{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("genre/{genre}")]
        public ActionResult<IEnumerable<Book>> GetBooksByGenre(string genre)
        {
            var books = _bookRepository.GetBooksByGenre(genre);
            if (books == null || !books.Any())
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpGet("topsellers")]
        public ActionResult<IEnumerable<Book>> GetTopSellers()
        {
            var topSellers = _bookRepository.GetTopSellers(10);
            return Ok(topSellers);
        }

        [HttpGet("rating/{rating}")]
        public ActionResult<IEnumerable<Book>> GetBooksByRating(int rating)
        {
            var books = _bookRepository.GetBooksByRating(rating);
            if (books == null || !books.Any())
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpPut("discount")]
        public ActionResult DiscountBooksByPublisher(string publisher, double discountPercent)
        {
            _bookRepository.ApplyDiscountByPublisher(publisher, discountPercent);
            return NoContent();
        }
    }
}
