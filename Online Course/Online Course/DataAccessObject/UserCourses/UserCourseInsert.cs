using Online_Course.Models;

namespace Online_Course.DataAccessObject.UserCourses
{
    public class UserCourseInsert:IUserCourseInsert
    {
        public  bool UserCourseDetails(CheckboxModel checkboxModel)
        {
            try
            {
                UserCoursesDetails userCourseModel = new UserCoursesDetails
                {
                    UserId = checkboxModel.UserId,
                    CourseId = checkboxModel.CourseId
                };
                 DbContect.GetDbContext().UserCourses.AddAsync(userCourseModel);
                return true;
            }
            catch
            {
                return false;
            }

            finally
            {
                DbContect.GetDbContext().SaveChangesAsync();
            }
        }
    }
}
