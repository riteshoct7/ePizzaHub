using Entities;
using Microsoft.AspNetCore.Identity;
using Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Properties
        UserManager<User> userManager;
        SignInManager<User> signInManager;
        RoleManager<Role> roleManager;
        #endregion

        #region Constructors
        public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        #endregion

        #region Methods

        public User GetUser(string userName)
        {
            return userManager.FindByNameAsync(userName).Result;
        }

        public User Login(string userName, string passowrd)
        {
            var result = signInManager.PasswordSignInAsync(userName, passowrd, false, false).Result;
            if (result.Succeeded)
            {
                var user = userManager.FindByNameAsync(userName).Result;
                var roles = userManager.GetRolesAsync(user).Result;
                user.Roles = roles.ToArray();
                return user;
            }
            return null;
        }

        public bool SignUp(User user, string password)
        {
            var result = userManager.CreateAsync(user, password).Result;
            if (result.Succeeded)
            {
                string role = "User";
                var roleResult = userManager.AddToRoleAsync(user, role).Result;
                if (roleResult.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> SignOut()
        {
            try
            {
                await signInManager.SignOutAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        } 
        #endregion

    }
}
