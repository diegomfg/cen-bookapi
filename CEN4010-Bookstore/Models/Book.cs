using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CEN4010_Bookstore.Models
{
    public class Book
    {
        public int Id { get; set; } 
        public string? Title { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        [ValidateNever]
        public Author? Author { get; set; }

        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        [ValidateNever]
        public Genre? Genre { get; set; }


        public string? ISBN {  get; set; }
        public int MSRP {  get; set; }
        public string? Description {  get; set; }
        public int YearPublished {  get; set; }
        [ValidateNever]
        public string? ImgID { get; set; }
        public int CopiesSold {  get; set; }


    }
}
