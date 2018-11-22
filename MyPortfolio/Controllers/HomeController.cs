using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Models.ViewModels.Home;

namespace MyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel model = new HomeViewModel()
            {
                Resumes = await _context.Resumes.Where(r => r.IsActive == true).ToListAsync(),
                Educations = await _context.Educations.OrderBy(e => e.StartedAt).ToListAsync(),
                Experiences = await _context.Experiences.OrderBy(e => e.StartedAt).ToListAsync(),
                Works = await _context.Works.OrderBy(e => e.StartedAt).ToListAsync(),
                Contact = new Models.Contact()
            };

            return View(model);
        }
    }
}