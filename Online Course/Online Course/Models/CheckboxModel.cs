using System.ComponentModel.DataAnnotations;

namespace Online_Course.Models
{
    public class CheckboxModel
    {
        public int? UserId { get; set; }
        public int? CourseId { get; set; }
        public bool IsCheked { get; set; }
        public IEnumerable<CourseDetail> courseDetails { get; set; }
        public List<CheckboxModel> checkboxModels { get; set; }
    }
}
