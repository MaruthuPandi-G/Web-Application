using Online_Course.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Online_Course.DataAccessObject.FeedbackDetails
{
    public class FeedBack:IFeedBack
    {
        public async Task<bool> UserFeedback(FeedbackDetail feedback)
        {
            try
            {
                await DbContect.GetDbContext().FeedbackDetails.AddAsync(feedback);
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
