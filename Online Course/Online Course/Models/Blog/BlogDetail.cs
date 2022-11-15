using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Online_Course.Models.Blog
{
    public partial class BlogDetail
    {

        public int BlogId { get; set; }

        public string BlogName { get; set; } = null!;

     
        public string BlogDetails { get; set; } = null!;

        public string BloggerName { get; set; } = null!;

      
        public string? BloggerImage { get; set; }

        public DateTime BlogDate { get; set; }


    }
}
