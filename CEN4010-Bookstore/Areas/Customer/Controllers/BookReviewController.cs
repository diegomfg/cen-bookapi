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

    public class BookReviewController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookReviewController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public IActionResult CreateReview(BookReview obj)
        {


            _unitOfWork.BookReview.Add(obj);
            _unitOfWork.Save();

            return Ok("Review created successfully");
        }



        public IActionResult GetReviews(int id)
        {
            /* var reviews = _dbContext.BookReview
                .Where(c => c.BookId == bookId)
                .ToList();
            */
            List<BookReview> objReviewList = _unitOfWork.BookReview.GetAll().ToList();
            objReviewList = objReviewList.Where(x => x.BookId == id).ToList();
            return Json(new { data = objReviewList });
        }


    }
}