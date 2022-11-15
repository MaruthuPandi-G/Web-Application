using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Online_Course.Models
{
    public class UserCoursesDetails
    {
        public int SNo { get; set; }
        public int? UserId { get; set; }
        public int? CourseId { get; set; }
    }
}
