using System.ComponentModel.DataAnnotations;

namespace CEN4010_Bookstore.Models{

    /**
        It's worth to note, an Address is also an external entity, this UserProfile is 
        also composed of se
    */
    public class UserProfile {

        [Key]
        public int Id {get; set; }
        public string? ProfilePicture {get; set; }
        public string? Address {get; set;}

    }
}