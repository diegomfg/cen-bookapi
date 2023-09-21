namespace CEN4010_Bookstore.Models
{
    public class BookRating
    {
        public int Id { get; set; }
        public Book BookId { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }

    }
}
