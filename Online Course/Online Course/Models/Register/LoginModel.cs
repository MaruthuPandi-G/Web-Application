using System.ComponentModel.DataAnnotations;

namespace Online_Course.Models.Register
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter Your Email")]
        [RegularExpression(@"^[a-z0-9_.+-]+@[a-z0-9-]+\.[a-z0-9-.]+$", ErrorMessage = "Incorrect Email")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Enter Your Password")]
        [RegularExpression(@"^[a-zA-z]{1,20}@[0-9]{1,20}$", ErrorMessage = "Incorrect Password")]
        public string UserPassword { get; set; }
    }
}
