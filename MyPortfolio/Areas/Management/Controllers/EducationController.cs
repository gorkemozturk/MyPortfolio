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
    public class EducationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EducationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var educations = await _context.Educations.ToListAsync();

            return View(educations);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Education education)
        {
            if (!ModelState.IsValid)
                return View(education);

            education.CreatedAt = DateTime.Now;

            _context.Add(education);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var education = await _context.Educations.FindAsync(id);

            if (education == null)
                return NotFound();

            return View(education);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, Education education)
        {
            if (id != education.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(education);

            _context.Entry(education).Property("CreatedAt").IsModified = false;
            _context.Entry(education).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var education = await _context.Educations.FindAsync(id);

            if (education == null)
                return NotFound();

            return View(education);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var education = await _context.Educations.FindAsync(id);

            _context.Remove(education);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}