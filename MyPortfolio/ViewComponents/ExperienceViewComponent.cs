using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.ViewComponents
{
    public class ExperienceViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ExperienceViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var experiences = await _context.Experiences.OrderByDescending(e => e.StartedAt).ToListAsync();

            return View(experiences);
        }
    }
}
