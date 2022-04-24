using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class MovieController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Movie
        public ActionResult Index()
        {
            var data = db.Movies.ToList();
            return View(data);
        }
    }
}