using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CEN4010_Bookstore.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [DisplayName("Category Name")]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage = "Display Order must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
