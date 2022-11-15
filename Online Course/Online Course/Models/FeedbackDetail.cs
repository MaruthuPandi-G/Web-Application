using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_Course.Models
{
    public  class FeedbackDetail
    {
        public int FeedbackId { get; set; }

        [Required(ErrorMessage = "Enter Your Name")]
        public string Name { get; set; } 

        [Required(ErrorMessage = "Enter Your Email")]
        [RegularExpression(@"^[a-z0-9_.+-]+@[a-z0-9-]+\.[a-z0-9-.]+$", ErrorMessage = "Incorrect Email")]
        public string Email { get; set; } 

        [Required(ErrorMessage = "Enter Your Subject")]
        public string Subject { get; set; } 

        [Required(ErrorMessage = "Enter Your FeedBackMessage")]
        public string FeedbackMessage { get; set; } 

        
    }
}
