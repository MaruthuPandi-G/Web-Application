using System.ComponentModel.DataAnnotations;

namespace Online_Course.Models.Blog
{
    public class BlogInsertModel
    {
        public int BlogId { get; set; }

      //  [Required(ErrorMessage = "Enter BlogName")]
       // [StringLength(30, ErrorMessage = "Name less than 30chars")]
        public string BlogName { get; set; } = null!;

      ///  [Required(ErrorMessage = "Enter BlogDetails")]
        public string BlogDetails { get; set; } = null!;

        //[Required(ErrorMessage = "Enter BloggerName")]
        //[StringLength(30, ErrorMessage = "Name less than 30chars")]
        public string BloggerName { get; set; } = null!;

        //[Required(ErrorMessage = "Select Image")]
        public IFormFile BloggerImage { get; set; }

        public DateTime BlogDate { get; set; }
    }
}
