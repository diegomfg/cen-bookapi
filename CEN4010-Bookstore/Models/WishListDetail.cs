namespace CEN4010_Bookstore.Models
{
    public class WishListDetail
    {
        public int Id { get; set; }
        public int WishlistId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
