namespace CEN4010_Bookstore.Models
{
    public class SalesDetail
    {
        public int Id { get; set; }
        public Sale SaleId { get; set; }
        public Book BookId { get; set; }
        public int Quantity { get; set; }
        public float Cost { get; set; }

    }
}
