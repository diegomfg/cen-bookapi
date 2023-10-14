using System.ComponentModel.DataAnnotations;

namespace CEN4010_Bookstore.Models
{
    public class BookRating
    {
<<<<<<< HEAD
=======
        [Key]
        public int Id { get; set; }
>>>>>>> main
        public int userId { get; set; }
        public Book BookId { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }

    }
}
