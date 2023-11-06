using CEN4010_Bookstore.Data;
using CEN4010_Bookstore.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN4010_Bookstore.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IGenreRepository Genre {get;private set;}
        public IBookRepository Book { get; private set; }
        public IAuthorRepository Author { get; private set; }
        public IPublisherRepository Publisher { get; private set; }
        public IBookReviewRepository BookReview { get; private set; }
        public IBookRatingRepository BookRating { get; private set; }

        IBookRepository IUnitOfWork.BookRepository => throw new NotImplementedException();

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Genre = new GenreRepository(_db);
            Book = new BookRepository(_db);
            Author = new AuthorRepository(_db);
            Publisher = new PublisherRepository(_db);
            BookReview = new BookReviewRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
