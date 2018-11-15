using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
    }
}
