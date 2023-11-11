namespace CEN4010_Bookstore.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PaymentId { get; set; }
        public float Total {  get; set; }

    }
}
