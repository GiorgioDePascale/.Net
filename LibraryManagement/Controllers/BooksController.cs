using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            using (Models.LibraryContext ctx = new Models.LibraryContext())
            {
                var items = ctx.Books.OrderBy(b => b.Title).ToList();
                return View(items);
            }
        }

        public ActionResult Create()
        {
            using(Models.LibraryContext ctx = new Models.LibraryContext())
            {
                ViewModels.CreateBookViewModel item = new ViewModels.CreateBookViewModel();
                item.Book = new Models.Book();
                item.Authors = ctx.Authors.OrderBy(a => a.Surname).ToList();
                item.Users = ctx.Users.OrderBy(u => u.Surname).ToList();
                return View(item);
            }
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            using(Models.LibraryContext ctx = new Models.LibraryContext())
            {
                bool available = false;
                if (form["Book.Available"].Contains("true"))
                    available = true;

                int authorId = int.Parse(form["Author"]);
                var author = ctx.Authors.Where(a => a.Id.Equals(authorId)).FirstOrDefault();

                int userId = int.Parse(form["User"]);
                var user = ctx.Users.Where(u => u.ID.Equals(userId)).FirstOrDefault();

                Models.Book book = new Models.Book()
                {
                    Title = form["Book.Title"],
                    ISBN = form["Book.ISBN"],
                    Available = available,
                    Author = author,
                    User = user
                };

                ctx.Books.Add(book);
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}