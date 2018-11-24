using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.Models
{
    public class Comment
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "User")]
        public string UserId { get; set; }

        [Display(Name = "Post")]
        public int PostId { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
    }
}
