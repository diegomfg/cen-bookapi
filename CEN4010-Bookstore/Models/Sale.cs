namespace CEN4010_Bookstore.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public User UserId { get; set; }
        public Payment PaymentId { get; set; }
        public float Total {  get; set; }

    }
}
