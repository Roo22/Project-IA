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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            db.Movies.Add(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var data = db.Movies.SingleOrDefault(c => c.MovieId == id);

            if (data == null) return View("NotFound");
            return View(data);
        }
        public ActionResult Edit(int id)
        {
            var data = db.Movies.SingleOrDefault(c => c.MovieId == id);

            if (data == null) return View("NotFound");
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                return View(movie);
            }
            var MoviesDb = db.Movies.SingleOrDefault(c => c.MovieId == movie.MovieId);
            MoviesDb.MovieName = movie.MovieName;
            MoviesDb.Description = movie.Description;
            MoviesDb.ImageUrl = movie.ImageUrl;
            MoviesDb.MovieCategory = movie.MovieCategory;
            MoviesDb.Author = movie.Author;
            MoviesDb.Director = movie.Director;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var MoviesDb = db.Movies.SingleOrDefault(c => c.MovieId == Id);
            db.Movies.Remove(MoviesDb);
            db.SaveChanges();
            return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
        }
    }
}