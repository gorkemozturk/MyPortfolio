using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.Models
{
    public class Experience
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Institute Name")]
        public string InstituteName { get; set; }

        [Required]
        public string Caption { get; set; }

        public string Body { get; set; }

        [Required]
        [Display(Name = "Started At")]
        [DataType(DataType.Date)]
        public DateTime StartedAt { get; set; }

        [Display(Name = "Finished At")]
        [DataType(DataType.Date)]
        public DateTime? FinishedAt { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }
    }
}
