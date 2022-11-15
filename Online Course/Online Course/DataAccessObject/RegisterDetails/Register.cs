using Microsoft.EntityFrameworkCore.ChangeTracking;
using Online_Course.Models.Register;
using Online_Course.Models;

namespace Online_Course.DataAccessObject.RegisterDetails
{
    public class Register : IRegister
    {
        public async Task<bool> UserRegisterDetail(RegisterValidationModel registerModel)
        {
            try
            {
                RegisterModel reg = new RegisterModel
                {
                    Name = registerModel.Name,
                    Gender = registerModel.Gender,
                    Email = registerModel.Email,
                    Password = registerModel.Password,
                };

                await DbContect.GetDbContext().UserRegisterDetails.AddAsync(reg);
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
