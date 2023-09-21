namespace CEN4010_Bookstore.Models
{
    public class BookReview
    {
        public int Id { get; set; } 
        public Book BookId { get; set; }
        public string Review { get; set; }
        public DateTime Date { get; set; }

    }
}
