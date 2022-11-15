namespace Online_Course.Models
{
    public class CourseModel
    {
        public IEnumerable<CourseDetail> CourseDetails { get; set; }

        public SubscriberDetail SubscriberDetail { get; set; }
    }
}
