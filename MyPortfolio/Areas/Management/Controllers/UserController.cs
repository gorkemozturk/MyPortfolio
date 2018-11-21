using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Models.ViewModels;
using MyPortfolio.Utilities;

namespace MyPortfolio.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = StaticEnvironments.Administrator)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            UserViewModel model = new UserViewModel()
            {
                Users = await _context.Users.ToListAsync()
            };

            return View(model);
        }
    }
}