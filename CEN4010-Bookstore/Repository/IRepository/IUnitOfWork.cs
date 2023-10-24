namespace CEN4010_Bookstore.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IGenreRepository Genre { get; }
        IBookRepository Book { get; }
        IAuthorRepository Author { get; }
        IPublisherRepository Publisher { get; }

        void Save();
    }
}
