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
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Genre = new GenreRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
