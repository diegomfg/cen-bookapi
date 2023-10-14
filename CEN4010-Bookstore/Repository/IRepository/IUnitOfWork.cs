namespace CEN4010_Bookstore.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IGenreRepository Genre { get; }
        IBookRepository Book { get; }

        void Save();
    }
}
