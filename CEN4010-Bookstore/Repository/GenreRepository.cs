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
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private ApplicationDbContext _db;
        public GenreRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Genre obj)
        {
            _db.Genres.Update(obj);
        }
    }
}
