using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.EntityModels;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public readonly UserManager<User> userManager;
        public readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AccountModel model)
        {
            
            if (!ModelState.IsValid)
            {

            }
            else
            {
                using (CateringContext c = new CateringContext())
                {
                    var user = c.Users.FirstOrDefault(x => x.Username == model.Username);
                    if (user == null)
                    {

                    }
                    var checkpassword = await userManager.CheckPasswordAsync(user,model.Password);
                    if (!checkpassword)
                    {
                        return View("Index", new AccountModel { message = "Password is incorrect" });
                    }

                    var result = await signInManager.PasswordSignInAsync(model.Username,model.Password,true,true);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Cook");
                    }

                }
            }

            return View("Index", new AccountModel {message="Your credentials are incorrect" });
        }
        public async Task<IActionResult> Logout()
        {
            await  signInManager.SignOutAsync();

            return RedirectToAction("Index");
        }
    }
}
