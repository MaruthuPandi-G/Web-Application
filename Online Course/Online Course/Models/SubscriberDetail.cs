using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_Course.Models
{
    public  class SubscriberDetail
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Enter Your Email")]
        [RegularExpression(@"^[a-z0-9_.+-]+@[a-z0-9-]+\.[a-z0-9-.]+$", ErrorMessage = "Incorrect Email")]
        public string Email { get; set; }

        
    }

}
