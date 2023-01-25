using EBusiness.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EBusiness.areas.manage.Controllers
{
    [Area("manage")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _rolemanager;

        public DashboardController(UserManager<AppUser> userManager, RoleManager<IdentityRole> rolemanager)
        {
            _userManager = userManager;
            _rolemanager = rolemanager;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser admin = new AppUser
        //    {
        //        UserName = "SuperAdmin",
        //        FullName = "Admin Adminzade"
        //    };
        //   await _userManager.CreateAsync(admin,"Admin123");
        //    return Ok("AdminCReatded");
        //}
        //public IActionResult CreateRole()
        //{
        //    IdentityRole role1 = new IdentityRole("SuperAdmin");
        //    IdentityRole role2 = new IdentityRole("Admin");
        //    IdentityRole role3 = new IdentityRole("Admin");

        //    _rolemanager.CreateAsync(role3);
        //    _rolemanager.CreateAsync(role2);
        //    _rolemanager.CreateAsync(role1);
        //    return Ok("Role Created");
        //}
        //public async Task<IActionResult> AddRole()
        //{
        //    AppUser user =await _userManager.FindByNameAsync("SuperAdmin");
        //    _userManager.AddToRoleAsync(user, "SuperAdmin");
        //    return Ok("RoleAdded");
        //}

    }
}
