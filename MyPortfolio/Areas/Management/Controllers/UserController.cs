﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Models;
using MyPortfolio.Models.ViewModels;
using MyPortfolio.Utilities;

namespace MyPortfolio.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = StaticEnvironments.Administrator)]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _context.ApplicationUsers.ToListAsync();

            return View(users);
        }

        public async Task<IActionResult> Update(string id)
        {
            if (id == null || id.Trim().Length == 0)
                return NotFound();

            var user = await _context.ApplicationUsers.FindAsync(id);

            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id, ApplicationUser user)
        {
            if (id != user.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(user);

            ApplicationUser existingUser = await _context.ApplicationUsers.Where(u => u.Id == id).FirstOrDefaultAsync();

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.IsAuthorized = user.IsAuthorized;

            if (user.IsAuthorized == true)
                await _userManager.AddToRoleAsync(existingUser, StaticEnvironments.Administrator);
            else
                await _userManager.RemoveFromRoleAsync(existingUser, StaticEnvironments.Administrator);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || id.Trim().Length == 0)
                return NotFound();

            var user = await _context.ApplicationUsers.FindAsync(id);

            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, ApplicationUser user)
        {
            if (id != user.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(user);

            ApplicationUser existingUser = await _context.ApplicationUsers.Where(u => u.Id == id).FirstOrDefaultAsync();

            existingUser.LockoutEnd = DateTime.Now.AddYears(100);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}