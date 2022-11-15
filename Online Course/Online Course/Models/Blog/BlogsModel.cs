namespace Online_Course.Models.Blog
{
    public class BlogsModel
    {
        public IEnumerable<BlogDetail>? BlogsDetails { get; set; }

        public BlogInsertModel? BlogDetail { get; set; }
    }
}
