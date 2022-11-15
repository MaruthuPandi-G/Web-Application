using Online_Course.Models.Register;
using System.Linq;

namespace Online_Course.DataAccessObject.LoginDetails
{
    public class Login : ILogin
    {
        public RegisterModel UserLogin(string userEmail, string UserPassword)
        {
            RegisterModel records;
            lock (DbContect.GetDbContext())
            {
                 records = DbContect.GetDbContext().UserRegisterDetails.Where(user => user.Email == userEmail && user.Password == UserPassword).FirstOrDefault();
            }
            
            if (records != null)
            {
                return records;
            }
            else
            {
                return null;
            }
        }       

    }
}
