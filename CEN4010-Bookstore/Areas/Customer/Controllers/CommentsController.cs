//Emmanuel Mejia
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using CEN4010_Bookstore.Models;
using CEN4010_Bookstore.Data;

namespace CEN4010_Bookstore.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class ReviewsComments : Controller
    {
        private readonly ApplicationDbContext _db;

        public ReviewsComments(ApplicationDbContext db)
        {
            _db = db;
        }


        [HttpPost]
        public IActionResult CreateRating(BookRating bookRating)
        {
            // Making sure the rating is between 1 and 5 stars
            if (bookRating.Rating < 1 || bookRating.Rating > 5)
            {
                return BadRequest("Invalid rating. It must be between 1 and 5.");
            }


            var rating = _db.BookRatings.Add(bookRating);

            _db.SaveChanges();

            return Ok("Rating created successfully");
        }






    }
}