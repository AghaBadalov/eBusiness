using EBusiness.areas.manage.ViewModels;
using EBusiness.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EBusiness.areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _usermanager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> usermanager,SignInManager<AppUser> signInManager)
        {
            _usermanager = usermanager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginVM adminLoginVM)
        {
            if(!ModelState.IsValid) return View();
            AppUser user =await _usermanager.FindByNameAsync(adminLoginVM.UserName);
            if(user == null)
            {
                ModelState.AddModelError("", "Username or Password is incorrect");
                return View();
            }
            var result =await _signInManager.PasswordSignInAsync(user, adminLoginVM.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or Password is incorrect");
                return View();
            }




            return RedirectToAction("index","dashboard");
        }
        public async Task<IActionResult> Logout()
        {
           await _signInManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }
    }
}
