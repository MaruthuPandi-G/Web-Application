using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_Course.Models.Register
{
    public partial class RegisterModel
    {
        public int UserId { get; set; }

        public string Name { get; set; } = null!;

       
        public string Gender { get; set; } = null!;

    
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

      
       
      
    }
}
