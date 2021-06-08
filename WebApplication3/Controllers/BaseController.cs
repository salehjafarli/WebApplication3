using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.EntityModels;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        public readonly UserManager<User> userManager;
        public BaseController(UserManager<User> userManager )
        {
            this.userManager = userManager;
        }

        private UserModel GetCurrentUser()
        {
            User user = userManager.GetUserAsync(User).Result;
            List<string> roles = userManager.GetRolesAsync(user).Result.ToList();

            return new UserModel() { Id = user.Id, Username = user.Username, Roles = roles };
        }

        public UserModel CurrentUser => GetCurrentUser();
    }
}
