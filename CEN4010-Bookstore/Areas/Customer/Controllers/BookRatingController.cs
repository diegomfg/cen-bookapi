//Emmanuel Mejia
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using CEN4010_Bookstore.Models;
using CEN4010_Bookstore.Data;
using CEN4010_Bookstore.Repository.IRepository;

namespace CEN4010_Bookstore.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class BookRatingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookRatingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public IActionResult CreateRating(BookRating bookRating)
        {
            // Making sure the rating is between 1 and 5 stars
            if (bookRating.Rating < 1 || bookRating.Rating > 5)
            {
                return BadRequest("Invalid rating. It must be between 1 and 5.");
            }

            /*
            var rating = _unitOfWork.BookRating.Add(bookRating);

            _unitOfWork.SaveChanges();
            */

            return Ok("Rating created successfully");
        }



    }
}