using System.ComponentModel.DataAnnotations;

namespace CEN4010_Bookstore.Models
{
    public class BookRating
    {
        [Key]
        public int Id { get; set; }
        public int userId { get; set; }
        public Book BookId { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }

    }
}
