using System.ComponentModel;

namespace CEN4010_Bookstore.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
