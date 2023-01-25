using EBusiness.DAL;
using EBusiness.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EBusiness.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Team> teams = _context.Teams.Include(x => x.Profession).Where(x => x.IsDeleted == false).ToList();

            return View(teams);
        }

        
    }
}