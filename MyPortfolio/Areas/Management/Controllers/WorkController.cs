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
    public class WorkController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var works = await _context.Works.ToListAsync();

            return View(works);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Work work)
        {
            if (!ModelState.IsValid)
                return NotFound();

            work.CreatedAt = DateTime.Now;

            await _context.Works.AddAsync(work);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var work = await _context.Works.FindAsync(id);

            if (work == null)
                return NotFound();

            return View(work);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Work work)
        {
            if (id != work.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(work);

            _context.Entry(work).State = EntityState.Modified;
            _context.Entry(work).Property("CreatedAt").IsModified = false;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var work = await _context.Works.FindAsync(id);

            if (work == null)
                return NotFound();

            return View(work);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var work = await _context.Works.FindAsync(id);

            _context.Works.Remove(work);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}