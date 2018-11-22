using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Utilities;

namespace MyPortfolio.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = StaticEnvironments.Administrator)]
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var contacts = await _context.Contacts.OrderByDescending(c => c.CreatedAt).ToListAsync();

            return View(contacts);
        }

        public async Task<IActionResult> Show(int? id)
        {
            if (id == null)
                return NotFound();

            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
                return NotFound();

            return View(contact);
        }
    }
}