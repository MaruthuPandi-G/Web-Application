using Online_Course.Models.Register;

namespace Online_Course.DataAccessObject.RegisterDetails
{
    public interface IRegister
    {
        Task<bool> UserRegisterDetail(RegisterValidationModel register);
    }
}
