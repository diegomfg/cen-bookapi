namespace CEN4010_Bookstore.Models
{
    public class Author
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string biography { get; set; }
        public Publisher PublisherId { get; set; }

    }
}
