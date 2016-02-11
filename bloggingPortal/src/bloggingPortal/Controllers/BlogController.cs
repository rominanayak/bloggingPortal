using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using bloggingPortal.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace bloggingPortal.Controllers
{
    public class BlogController : Controller
    {
        private ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }
        //BlogDataContext _db = new BlogDataContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            var blogs = _context.Blog.ToList();
            return View(blogs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            if(ModelState.IsValid)
            {
                _context.Blog.Add(blog);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        public IActionResult Blog(Guid id)
        {
            var blog = _context.Blog.Single(m => m.Id == id);
            return View(blog);
        }

        [HttpPost]
        public IActionResult Blog(Guid id, Comment newComment )
        {
            if (ModelState.IsValid)
            {
                newComment.blog = _context.Blog.Single(m => m.Id == id);
                _context.Comment.Add(newComment);
                _context.SaveChanges();
                return RedirectToAction("Blog", new { Id = id });
            }
            return Blog(id);
            var blog = _context.Blog.Single(m => m.Id == id);
            return View(blog);
        }
    }
}
