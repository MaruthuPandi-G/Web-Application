using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Online_Course.Models
{
    public class UserCourse
    {
        public int S_no { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
    }
}
