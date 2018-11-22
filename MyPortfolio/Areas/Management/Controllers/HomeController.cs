using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Models.ViewModels.Dashboard;
using MyPortfolio.Utilities;

namespace MyPortfolio.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = StaticEnvironments.Administrator)]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            DashboardViewModel model = new DashboardViewModel()
            {
                DailyUsers = await _context.ApplicationUsers.Where(u => u.CreatedAt.Date == DateTime.Today).CountAsync(),
                DailyContacts = await _context.Contacts.Where(u => u.CreatedAt.Date == DateTime.Today).CountAsync(),
                Contacts = await _context.Contacts.Where(u => u.CreatedAt.Date == DateTime.Today).ToListAsync(),
            };

            return View(model);
        }
    }
}