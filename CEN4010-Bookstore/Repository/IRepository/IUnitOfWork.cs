namespace CEN4010_Bookstore.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IGenreRepository Genre { get; }
        IBookRepository Book { get; }
        IAuthorRepository Author { get; }
        IPublisherRepository Publisher { get; }
        IBookRepository BookRepository { get; }
        IBookReviewRepository BookReview { get; }
        IBookRatingRepository BookRating { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IUserRepository User { get; }   

        void Save();
    }
}
