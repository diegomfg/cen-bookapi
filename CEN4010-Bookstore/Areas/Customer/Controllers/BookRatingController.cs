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





//        [HttpPost]
        public IActionResult CreateRating(int bookid, int rating, int userid)
        {
            // Making sure the rating is between 1 and 5 stars
            if (rating < 1 || rating > 5)
            {
                return BadRequest("Invalid rating. It must be between 1 and 5.");
            }
            else
            {
                BookRating temprating = new BookRating();
                temprating.Rating = rating;
                temprating.BookId = bookid;
                temprating.Date = DateTime.Now;
                temprating.userId = userid;

                _unitOfWork.BookRating.Add(temprating);
                _unitOfWork.Save();
                TempData["success"] = "BookRating created successfully";
                return Json(new { success = true, message = " successful" });
            }
        }



    }
}