using System.ComponentModel.DataAnnotations;

namespace Online_Course.Models.Register
{
    public class RegisterValidationModel
    {
        [Required(ErrorMessage = "Enter Your Name")]
        [StringLength(30,ErrorMessage ="Name should be =>30 chars")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Select your Gender")]
        public string Gender { get; set; } = null!;

        [Required(ErrorMessage = "Enter Your Email")]
        [RegularExpression(@"^[a-z0-9_.+-]+@[a-z0-9-]+\.[a-z0-9-.]+$", ErrorMessage = "Incorrect Email")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Enter Your Password")]
        [RegularExpression(@"^[a-zA-z]{1,20}@[0-9]{1,20}$", ErrorMessage = "Incorrect Password")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Enter Your Confirm Password")]
        [RegularExpression(@"^[a-zA-z]{1,20}@[0-9]{1,20}$", ErrorMessage = "Incorrect Password")]
        public string ConfirmPassword { get; set; } = null!;

     
    }
}
