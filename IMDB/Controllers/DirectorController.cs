using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class DirectorController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Director

        
        public ActionResult Index()
        {
            var data = db.Directors.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Director director)
        {
            if (director == null)
            {
                throw new ArgumentNullException(nameof(director));
            }

            if (!ModelState.IsValid)
            {
                return View(director);
            }
            db.Directors.Add(director);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var data = db.Directors.SingleOrDefault(c => c.DirectorId == id);

            if (data == null) return View("NotFound");
            return View(data);
        }
        public ActionResult Edit(int id)
        {
            var data = db.Directors.SingleOrDefault(c => c.DirectorId == id);

            if (data == null) return View("NotFound");
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Director director)
        {

            if (!ModelState.IsValid)
            {
                return View(director);
            }
            var DirectorsDb = db.Directors.SingleOrDefault(c => c.DirectorId == director.DirectorId);
            DirectorsDb.ProfilePictureUrl = director.ProfilePictureUrl;
            DirectorsDb.FirstName = director.FirstName;
            DirectorsDb.LastName = director.LastName;
            DirectorsDb.Age = director.Age;
            DirectorsDb.Bio = director.Bio;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var DirectorsDb = db.Directors.SingleOrDefault(c => c.DirectorId == Id);
            db.Directors.Remove(DirectorsDb);
            db.SaveChanges();
            return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
        }

    }
}