using Entities;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAuthenticationService
    {
        #region Methods

        bool SignUp(User user, string passowrd);

        User Login(string userName, string password);

        User GetUser(string userName);

        Task<bool> SignOut();

        #endregion
    }
}
