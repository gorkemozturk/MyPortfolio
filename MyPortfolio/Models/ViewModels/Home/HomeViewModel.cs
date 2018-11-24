using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.Models.ViewModels.Home
{
    public class HomeViewModel
    {
        public IEnumerable<Resume> Resumes { get; set; }
        public IEnumerable<Education> Educations { get; set; }
        public IEnumerable<Experience> Experiences { get; set; }
        public IEnumerable<Work> Works { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public Contact Contact { get; set; }
    }
}
