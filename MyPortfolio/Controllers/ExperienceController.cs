using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;

namespace MyPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExperienceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var educations = await _context.Experiences.OrderBy(e => e.StartedAt).ToListAsync();

            return View(educations);
        }
    }
}