﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using bloggingPortal.Models;
using Microsoft.AspNet.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace bloggingPortal.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
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

        [AllowAnonymous]
        public IActionResult Blog(Guid id)
        {
            var blog = _context.Blog.Single(m => m.Id == id);
            return View(blog);
        }

        [HttpPost]
        public IActionResult Blog(Guid id, Comment newComment)
        {
            if (ModelState.IsValid)
            {
                newComment.blog = _context.Blog.Single(m => m.Id == id);
                _context.Comment.Add(newComment);
                _context.SaveChanges();
                return RedirectToAction("Blog", new { Id = id });
            }
            return Blog(id);
        }

        public IActionResult Edit(Guid id)
        {
            var blog = _context.Blog.Single(m => m.Id == id);
            return View(blog);
        }

        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Blog.Update(blog);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }
    }
}
