﻿using CEN4010_Bookstore.Data;
using CEN4010_Bookstore.Models;
using CEN4010_Bookstore.Repository.IRepository;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CEN4010_Bookstore.Repository
{
    public class BookReviewRepository : Repository<BookReview>, IBookReviewRepository
    {
        private ApplicationDbContext _db;
        public BookReviewRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(BookReview obj)
        {
            _db.BookReviews.Update(obj);
        }
    }
}
