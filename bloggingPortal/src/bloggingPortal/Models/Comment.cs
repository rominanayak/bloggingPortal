﻿using System;

namespace bloggingPortal.Models
{
    public class Comment
    {
        public string Id { get; set; }
        //public string BlogId { get; set; }
        public Blog blog { get; set; }
        public DateTime DateTime { get; set; }
        public string UserName { get; set; }
        public string Body { get; set; }
        public Comment()
        {
            DateTime = DateTime.Now;
        }
    }
}