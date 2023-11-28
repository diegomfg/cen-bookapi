using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace CEN4010_Bookstore.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
       
        [ForeignKey("UserId")]
        [ValidateNever]
        public User? User { get; set; }

        public int? BookId { get; set; }
        
        [ForeignKey("BookId")]
        [ValidateNever]
        public Book? Book { get; set; }

        public int Quantity { get; set; }
    }
}
