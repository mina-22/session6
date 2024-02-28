using crud_system.Data;
using crud_system.Models;
using crud_system.Modelview ;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace crud_system.Controllers
{
    public class DashBoardController : Controller
    {

        private readonly AppDbContext _database;
        public DashBoardController(AppDbContext database)
        {
            _database = database;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewBlog()
        {
            var blogs = _database.blogs.Include(blogs => blogs.type);
            return View(blogs);

        }
        public IActionResult Delete(int id)
        {
            Blog? blog = _database.Set<Blog>().Find(id);
            _database.blogs.Remove(blog);
            _database.SaveChanges();
            return RedirectToAction("ViewBlog");
        }


        public IActionResult AddBlog()
        {
            var TypeList = _database.types.ToList();
            var blogT = new BlogType()
            {
                type = TypeList
            };
            return View(blogT);
        }


        [HttpPost]
      public IActionResult AddBlog(Blog blog)
      {
            
                    if (!ModelState.IsValid)
                    {
                          BlogType b = new BlogType();
                          b.blog = blog;
                          b.type = _database.types.ToList();
                          return View(b);
                    }



            _database.blogs.Add(blog);
            _database.SaveChanges();


            return RedirectToAction("ViewBlog");
      }


       
        
        public IActionResult UpdateBlog(int id)
        {

            var TypeList = _database.types.ToList();
            var b = new BlogType()
            {
                type = TypeList
            };
            b.blog= _database.blogs.SingleOrDefault(i => i.Id == id);
           

            return View(b.blog);


        }


        [HttpPost]
        public IActionResult SaveBlog( Blog b)
        {
            
            Blog NewBlog = new Blog();
            NewBlog = _database.blogs.SingleOrDefault(i => i.Id == b.Id);
            NewBlog.Name = b.Name;
            NewBlog.Discription = b.Discription;
            NewBlog.Enable = b.Enable;
            NewBlog.TypeId = b.TypeId;
            _database.Set<Blog>().Update(NewBlog);
            _database.SaveChanges();
            return RedirectToAction("ViewBlog");
        }



    }
}

