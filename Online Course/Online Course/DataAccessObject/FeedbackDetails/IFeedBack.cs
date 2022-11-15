using Online_Course.Models;

namespace Online_Course.DataAccessObject.FeedbackDetails
{
    public interface IFeedBack
    {
         Task<bool> UserFeedback(FeedbackDetail feedback);
    }
}
