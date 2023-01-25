using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EBusiness.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
