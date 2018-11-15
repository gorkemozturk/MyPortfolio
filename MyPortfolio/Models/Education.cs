using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.Models
{
    public class Education
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Institute Name")]
        public string InstituteName { get; set; }

        [Required]
        public string Degree { get; set; }

        public string Body { get; set; }

        [Required]
        [Display(Name = "Started At")]
        [DataType(DataType.Date)]
        public DateTime StartedAt { get; set; }

        [Display(Name = "Finished At")]
        [DataType(DataType.Date)]
        public DateTime? FinishedAt { get; set; }

        [Display(Name = "Completed")]
        public bool IsCompleted { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }
    }
}
