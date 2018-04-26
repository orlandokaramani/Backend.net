using System;
using System.ComponentModel.DataAnnotations;

namespace app.View
{
    public class UserForRegister
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "You must specify password between 4-8")]
        public string  Password { get; set; }
        public string Gjinia { get; set; }
        public DateTime Datelindja { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public UserForRegister(){
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }
}