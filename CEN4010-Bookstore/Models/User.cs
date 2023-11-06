using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CEN4010_Bookstore.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int PaymentId { get; set; }
        public int UserTypeId { get; set; }
        // public int? UserProfile { get; set; }
        // public UserProfile? UserProfile { get; set; }

    }
}
