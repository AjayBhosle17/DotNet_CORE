using System.ComponentModel.DataAnnotations;

namespace Web_UI.Models
{
    public class LoginModel
    {
        [EmailAddress]
        [Required (ErrorMessage ="Plz Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Plz Enter Password")]
        public string Password { get; set; }
    }
}
