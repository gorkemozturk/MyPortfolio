using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.ViewComponents
{
    public class AboutViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public AboutViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var resumes = await _context.Resumes.Where(r => r.IsActive == true).ToListAsync();

            return View(resumes);
        }
    }
}
