
using Online_Course.Models.Register;

namespace Online_Course.DataAccessObject.LoginDetails
{
    public interface ILogin
    {
        public RegisterModel UserLogin(string userEmail, string UserPassword);
       
    }
}
