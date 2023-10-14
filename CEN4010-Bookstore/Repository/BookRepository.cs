using CEN4010_Bookstore.Data;
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
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private ApplicationDbContext _db;
        public BookRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Book obj)
        {
            _db.Books.Update(obj);
        }
    }
}
