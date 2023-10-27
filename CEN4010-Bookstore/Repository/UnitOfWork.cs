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
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Genre = new GenreRepository(_db);
            Book = new BookRepository(_db);
            Author = new AuthorRepository(_db);
            Publisher = new PublisherRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
