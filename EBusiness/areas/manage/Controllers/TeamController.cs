using EBusiness.DAL;
using EBusiness.Helpers;
using EBusiness.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBusiness.areas.manage.Controllers
{
    [Area("manage")]
    [Authorize]
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TeamController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            var query = _context.Teams.Include(x=>x.Profession).Where(x=>x.IsDeleted==false).AsQueryable();
            var paginatedteams = PaginatedList<Team>.Create(query,2,page);

            //List<Team> teams = _context.Teams.Include(x=>x.Profession).Where(x=>x.IsDeleted==false).ToList();
            return View(paginatedteams);
        }
        public IActionResult DeletedTeams()
        {
            List<Team> teams = _context.Teams.Include(x => x.Profession).Where(x => x.IsDeleted == true).ToList();
            return View(teams);
        }
        public IActionResult Create()
        {
            ViewBag.Professions = _context.Professions.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            ViewBag.Professions = _context.Professions.ToList();
            team.IsDeleted = false;
            if (!ModelState.IsValid) return View(team);
            if(team.ImageFile is null)
            {
                ModelState.AddModelError("ImageFile", "Image Can't be null");
                return View(team);
            }
            if(team.ImageFile.ContentType!="image/png" && team.ImageFile.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("IamgeFile", "Wrong File type");
                return View();
            }
            if (team.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "Wrong length");
                return View(team);
            }
            team.ImageUrl = team.ImageFile.SaveFile(_env.WebRootPath, "uploads/teams");
            team.IsDeleted = false;
            _context.Teams.Add(team);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Update(int id)
        {
            ViewBag.Professions = _context.Professions.ToList();

            Team team =_context.Teams.FirstOrDefault(x=>x.Id==id);
            if (team == null) return NotFound();
            return View(team);
        }
        [HttpPost]
        public IActionResult Update(Team team)
        {
            ViewBag.Professions = _context.Professions.ToList();
            Team exstteam = _context.Teams.FirstOrDefault(x => x.Id == team.Id);
            if(exstteam == null) return NotFound();

            if (!ModelState.IsValid) return View();
            if(team.ImageFile != null)
            {
                string path = Path.Combine(_env.WebRootPath, "uploads/teams", exstteam.ImageUrl);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                if (team.ImageFile.Length> 2097152)
                {
                    ModelState.AddModelError("ImageFile", "Wrong length");
                    return View(team);
                }
                if (team.ImageFile.ContentType != "image/png" && team.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("IamgeFile", "Wrong File type");
                    return View();
                }
                exstteam.ImageUrl = team.ImageFile.SaveFile(_env.WebRootPath, "uploads/teams");
            }
            exstteam.ProfessionId = team.ProfessionId;
            exstteam.Name = team.Name;
            exstteam.FBUrl = team.FBUrl;
            exstteam.IGUrl = team.IGUrl;
            exstteam.TTUrl = team.TTUrl;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Team team = _context.Teams.FirstOrDefault(x => x.Id == id);
            if (team == null) return NotFound();
            string path = Path.Combine(_env.WebRootPath, "uploads/teams", team.ImageUrl);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _context.Teams.Remove(team);
            _context.SaveChanges();
            return RedirectToAction("DeletedTeams");
        }
        public IActionResult Softdelete(int id)
        {
            Team team = _context.Teams.FirstOrDefault(x => x.Id == id);
            if (team == null) return NotFound();
            
            team.IsDeleted=true;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Restore(int id)
        {
            Team team = _context.Teams.FirstOrDefault(x => x.Id == id);
            if (team == null) return NotFound();

            team.IsDeleted = false;
            _context.SaveChanges();
            return RedirectToAction("DeletedTeams");
        }
    }
}
