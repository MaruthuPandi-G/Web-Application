namespace Online_Course.Models
{
    public class CourseEditModel:CourseInsertModel
    {
        public int Id { get; set; }

        public string ExistingPhotoPath { get; set; } = null!;

    }
}
