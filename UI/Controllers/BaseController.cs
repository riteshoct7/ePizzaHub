using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UI.Interfaces;

namespace UI.Controllers
{
    public class BaseController : Controller
    {
        #region Properties

        IUserAccessor _userAccessor;
        //protected UserManager<User> _userManager; 

        //public User CurrentUser
        //{
        //    get 
        //    { 
        //        if (User.Identity.Name !=null)
        //        {
        //            return _userManager.FindByNameAsync(User.Identity.Name).Result;
        //        }
        //        else
        //        {
        //            return null;
        //        }

        //    }
        //}

        public User CurrentUser
        {
            get
            {
                if (User != null)
                    return _userAccessor.GetUser();
                else
                    return null;                   
            }
        }

        #endregion

        #region Constructors
        //public BaseController(UserManager<User> userManager)
        //{
        //    _userManager = userManager;
        //} 

        public BaseController(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }
        #endregion

    }
}
