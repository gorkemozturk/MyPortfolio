using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Models.ViewModels;

namespace MyPortfolio.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Posts()
        {
            var posts = await _context.Posts.Include(p => p.User).ToListAsync();

            return View(posts);
        }

        [Route("Blog/Post/{year:min(2000)}/{month:range(1,12)}/{id}")]
        public async Task<IActionResult> Post(int? year, int? month, int? id)
        {
            if (year == null || month == null || id == null)
                return NotFound();

            PostViewModel model = new PostViewModel()
            {
                Post = await _context.Posts.Include(p => p.User).FirstAsync(p => p.Id == id),
            };

            return View(model);
        }
    }
}