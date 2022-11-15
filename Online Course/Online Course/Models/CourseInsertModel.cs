using System.ComponentModel.DataAnnotations;

namespace Online_Course.Models
{
    public class CourseInsertModel
    {      
      
        public string CourseName { get; set; } = null!;
        public string CourseDescription { get; set; } = null!;
        public IFormFile CourseImage { get; set; } = null!;

      //  public CourseDetail courseDetail { get; set; } = null!;
    }
}
