using System;
using System.Collections.Generic;

namespace Online_Course.Models
{
    public class UserCourseModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string CourseDescription { get; set; } = null!;
        public string CourseImage { get; set; } = null!;
    }
    public class CourseViewModel
    {
       public IEnumerable<UserCourseModel> Courses { get; set; } 
    }
}
