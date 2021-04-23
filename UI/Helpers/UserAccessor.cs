using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using UI.Interfaces;

namespace UI.Helpers
{
    public class UserAccessor : IUserAccessor
    {

        #region Properties
        UserManager<User> userManager;
        IHttpContextAccessor httpContextAccessor;
        #endregion

        #region Constructors
        public UserAccessor(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Methods

        public User GetUser()
        {
            if (httpContextAccessor.HttpContext.User != null)
                return userManager.GetUserAsync(httpContextAccessor.HttpContext.User).Result;
            else
                return null;
        } 

        #endregion

    }
}
