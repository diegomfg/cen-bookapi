using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CEN4010_Bookstore.Models
{
    public class UserProfile
    {

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public String? ProfilePicture { get; set; }
        public String? Biography { get; set; }
    }
}