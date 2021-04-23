using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        #region Properties
        IAuthenticationService authService;
        #endregion

        #region Constructors

        public AccountController(IAuthenticationService authService)
        {
            this.authService = authService;
        }

        #endregion

        #region Methods

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.Name = model.Name;
                user.UserName = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                bool result  =authService.SignUp(user, model.Password);
                if (result)
                {
                   return  RedirectToAction("Login");
                }
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model ,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = authService.Login(model.UserName, model.Password);
                if (user != null)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    if (user.Roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index","Dashboard", new { area ="Admin"});
                    }
                    else if (user.Roles.Contains("User"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "User" });
                    }
                }
            }
            return View(model);
        }

        public async Task<IActionResult> LogOut ()
        {
            await authService.SignOut();
            return RedirectToAction("LogOutComplete");
        }


        public IActionResult LogOutComplete()
        {
            return View();
        }

        public IActionResult Unauthorize ()
        {
            return View();
        }


        #endregion
    }
}
