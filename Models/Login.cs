using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace the_wall.Models
{
    public class Login 
    {
        [Key]
        public int nothing {get; set;}

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address:")]
        public string lemail {get; set;}

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string lpassword {get; set;}

        public Login ()
        {
        
        }
    }
}