using Microsoft.EntityFrameworkCore.ChangeTracking;
using Online_Course.Models;

namespace Online_Course.DataAccessObject.SubscriberDetails
{
    public class Subscribe:ISubscribe
    {
        public bool UserSubscriberDetail(SubscriberDetail subscriber)
        {
             EntityEntry<SubscriberDetail>  records = DbContect.GetDbContext().SubscriberDetails.Add(subscriber);
             if(records != null)
            {
                DbContect.GetDbContext().SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
