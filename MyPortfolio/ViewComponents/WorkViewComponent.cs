using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.ViewComponents
{
    public class WorkViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public WorkViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var works = await _context.Works.OrderByDescending(e => e.StartedAt).ToListAsync();

            return View(works);
        }
    }
}
