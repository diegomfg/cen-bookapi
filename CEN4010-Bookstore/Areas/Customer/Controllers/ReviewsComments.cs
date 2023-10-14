//Emmanuel Mejia
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using CEN4010_Bookstore.Models;

namespace CEN4010_Bookstore.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class ReviewsComments : Controller
    {
        private readonly ILogger<ReviewsComments> _logger;

        public ReviewsComments(ILogger<ReviewsComments> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public IActionResult CreateRating(int bookId, int userId, int rating)
        {
            // Making sure the rating is between 1 and 5 stars
            if (rating < 1 || rating > 5)
            {
                return BadRequest("Invalid rating. It must be between 1 and 5.");
            }

            // Create a new rating for a book
            var newRating = new BookRating
            {
                BookId = bookId,
                Rating = rating,
                Date = DateTime.Now
            };

            _logger.BookRatings.Add(newRating);
            _logger.SaveChanges();

            return Ok("Rating created successfully");
        }






    }
}