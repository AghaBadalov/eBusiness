using EBusiness.DAL;
using EBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace EBusiness.areas.manage.Controllers
{
    [Area("manage")]
    public class ProfessionController : Controller
    {
        private readonly AppDbContext _context;

        public ProfessionController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Profession> professions = _context.Professions.ToList();
            return View(professions);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Profession profession)
        {
            if (!ModelState.IsValid) return View(profession);
            _context.Professions.Add(profession);
            _context.SaveChanges();
            
            return RedirectToAction("index");
        }

        public IActionResult Update(int id)
        {
            Profession profession = _context.Professions.FirstOrDefault(x=>x.Id==id);
            if (profession == null) return NotFound();
            return View(profession);
        }
        [HttpPost]
        public IActionResult Update(Profession profession)
        {
            Profession exprofession = _context.Professions.FirstOrDefault(x=>x.Id==profession.Id);
            if(exprofession == null) return NotFound();
            if (!ModelState.IsValid) return View(profession);
            exprofession.Name = profession.Name;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Profession profession = _context.Professions.FirstOrDefault(x => x.Id == id);
            if (profession == null) return NotFound();
            _context.Professions.Remove(profession);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
