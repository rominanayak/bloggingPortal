using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bloggingPortal.Models
{
    public class Blog
    {
        [Key]
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [ScaffoldColumn(false)]
        public DateTime PostedOn { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public Blog()
        {
            PostedOn = DateTime.Now;
        }
    }
}
