namespace CEN4010_Bookstore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author AuthorId { get; set; }
        public Genre GenreId { get; set; }
        public string ISBN {  get; set; }
        public float MSRP {  get; set; }
        public string Description {  get; set; }
        public int YearPublished {  get; set; }
        public string ImgID { get; set; }

    }
}
