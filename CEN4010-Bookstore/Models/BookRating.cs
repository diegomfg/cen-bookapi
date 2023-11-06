using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CEN4010_Bookstore.Models
{
    public class BookRating
    {
        [Key]
        public int Id { get; set; }
        public int? userId { get; set; }
        public int? BookId { get; set; }
        public int? Rating { get; set; }
        public DateTime? Date { get; set; }

    }
}
