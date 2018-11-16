using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.ViewComponents
{
    public class EducationViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public EducationViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var educations = await _context.Educations.OrderByDescending(e => e.StartedAt).ToListAsync();

            return View(educations);
        }
    }
}
