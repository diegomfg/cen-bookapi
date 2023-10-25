using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace CEN4010_Bookstore.Models
{
    public class Author
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        [ValidateNever]
        public string LastName { get; set; }
        [ValidateNever]
        public string Country { get; set; }
        public string biography { get; set; }
        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        [ValidateNever]
        public Publisher? Publisher { get; set; }

    }
}
