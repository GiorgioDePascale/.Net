using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult Index(int id)
        {
            using (Models.LibraryContext ctx = new Models.LibraryContext())
            {
                var error = ctx.Errors.Where(e => e.ID.Equals(id)).FirstOrDefault();
                if (error != null)
                    return View(error);
                else
                    return RedirectToAction("Index", "Users");
            }
        }
    }
}