using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: Authors
        public ActionResult Index()
        {
            using(Models.LibraryContext ctx = new Models.LibraryContext())
            {
                var items = ctx.Authors.OrderBy(a => a.Surname).ToList();
                return View(items);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            using(Models.LibraryContext ctx = new Models.LibraryContext())
            {
                Models.Author author = new Models.Author()
                {
                    Name = form["Name"],
                    Surname = form["Surname"]
                };
                ctx.Authors.Add(author);
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}