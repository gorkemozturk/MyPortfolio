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
    public class ResumeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResumeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var resumes = await _context.Resumes.ToListAsync();

            return View(resumes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Resume resume)
        {
            if (!ModelState.IsValid)
                return View(resume);

            resume.CreatedAt = DateTime.Now;

            _context.Resumes.Add(resume);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var resume = await _context.Resumes.FindAsync(id);

            if (resume == null)
                return NotFound();

            return View(resume);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Resume resume)
        {
            if (id != resume.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(resume);

            _context.Entry(resume).State = EntityState.Modified;
            _context.Entry(resume).Property("CreatedAt").IsModified = false;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var resume = await _context.Resumes.FindAsync(id);

            if (resume == null)
                return NotFound();

            return View(resume);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var resume = await _context.Resumes.FindAsync(id);

            _context.Remove(resume);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}