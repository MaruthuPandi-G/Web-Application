using Online_Course.Models;

namespace Online_Course.DataAccessObject
{
    public sealed class DbContect
    {
        private static CourseDbContext dbContext=new CourseDbContext();

        private DbContect()
        {

        }

        public static CourseDbContext GetDbContext()
        {
            return dbContext;
        }
    }
}
