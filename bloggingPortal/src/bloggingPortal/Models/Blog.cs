using System;
using System.ComponentModel.DataAnnotations;

namespace bloggingPortal.Models
{
    public class Blog
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PostedOn { get; set; }
    }
}
