using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        [StringLength(10,MinimumLength =2 , ErrorMessage ="plz Enter min 2 charcaters")]
        [Required(ErrorMessage ="Plz Enter First Name")]

        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "plz Enter min 2 charcaters")]
        [Required(ErrorMessage = "Plz Enter Last Name")]

        public string LastName { get; set; }

        [EmailAddress(ErrorMessage ="Invalid Email")]
        [Required(ErrorMessage ="Plz Enter Email")]
        public string Email { get; set; }

        [Required]
        [Compare("Email", ErrorMessage = "Email and confirm Email not match")]
        public string ConfirmEmail { get; set; }



        [Required(ErrorMessage ="please enter password")]
        [DataType(DataType.Password ,ErrorMessage ="Please Enter Strong Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password",ErrorMessage ="password and confirm password not match")]
        public string ConfirmPassword {  get; set; }



        [DisplayName("Date Of Birth ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="dd/MM/yyyy",ApplyFormatInEditMode =true)]
        [Required(ErrorMessage = "please enter date of birth")]

        public DateTime? DateOfBirth { get; set; }
        [Range(1,100,ErrorMessage ="Age should be between 1 to 100")]
        [Required(ErrorMessage = "please enter age")]

        public int? Age { get; set; }

        //[Required(ErrorMessage ="please enter facebook url")]
        [DisplayName("Facebook Page Url")]
        [Url(ErrorMessage ="please enter valid url")]
        public string FacebookUrl { get; set; }
    }
}
