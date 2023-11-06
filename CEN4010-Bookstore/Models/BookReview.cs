using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CEN4010_Bookstore.Models
{
        public class BookReview
        {
                public int Id { get; set; }

                public int BookId { get; set; }
                [ForeignKey("BookId")]
                [ValidateNever]
                public Book? Book { get; set; }

                public string Review { get; set; }
                public DateTime Date { get; set; }
                public int userId { get; set; } 
    }
}
