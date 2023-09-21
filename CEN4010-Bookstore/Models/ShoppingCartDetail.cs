namespace CEN4010_Bookstore.Models
{
    public class ShoppingCartDetail
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int ShoppingCartId { get; set; }
        public int Quantity { get; set; }

    }
}
