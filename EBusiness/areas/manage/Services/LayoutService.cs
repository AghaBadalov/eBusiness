using EBusiness.Models;
using Microsoft.AspNetCore.Identity;

namespace EBusiness.areas.manage.Services
{
    public class LayoutService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AppUser> _userManager;

        public LayoutService(IHttpContextAccessor httpContext,UserManager<AppUser> userManager)
        {
            _httpContext = httpContext;
            _userManager = userManager;
        }
        public async Task<AppUser> GetUser()
        {
            string name = _httpContext.HttpContext.User.Identity.Name;

            AppUser user =await _userManager.FindByNameAsync(name);
            return user;
        }
    }
}
