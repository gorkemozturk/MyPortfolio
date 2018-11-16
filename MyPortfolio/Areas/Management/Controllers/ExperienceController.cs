using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Models;
using MyPortfolio.Utilities;

namespace MyPortfolio.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = StaticEnvironments.Administrator)]
    public class ExperienceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExperienceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var experiences = await _context.Experiences.ToListAsync();

            return View(experiences);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Experience experience)
        {
            if (!ModelState.IsValid)
                return View(experience);

            experience.CreatedAt = DateTime.Now;

            _context.Add(experience);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var experience = await _context.Experiences.FindAsync(id);

            if (experience == null)
                return NotFound();

            return View(experience);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, Experience experience)
        {
            if (id != experience.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(experience);

            _context.Entry(experience).Property("CreatedAt").IsModified = false;
            _context.Entry(experience).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var experience = await _context.Experiences.FindAsync(id);

            if (experience == null)
                return NotFound();

            return View(experience);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var experience = await _context.Experiences.FindAsync(id);

            _context.Remove(experience);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}