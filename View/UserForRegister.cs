using System.ComponentModel.DataAnnotations;

namespace app.View
{
    public class UserForRegister
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4-8")]
        public string  Password { get; set; }
    }
}