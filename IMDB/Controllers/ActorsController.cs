
using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class ActorsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Actors
       
        public ActionResult Index()
        {
            var data = db.Actors.ToList();
            return View(data);
        }
       
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Actor actor)
        {
            if (actor == null)
            {
                throw new ArgumentNullException(nameof(actor));
            }

            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            db.Actors.Add(actor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var data = db.Actors.SingleOrDefault(c => c.ActorId == id);

            if (data == null) return View("NotFound");
            return View(data);
        }
        public ActionResult Edit(int id)
        {
            var data = db.Actors.SingleOrDefault(c => c.ActorId == id);

            if (data == null) return View("NotFound");
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Actor actor)
        {

            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            var ActorsDb = db.Actors.SingleOrDefault(c => c.ActorId == actor.ActorId);
            ActorsDb.ProfilePictureUrl = actor.ProfilePictureUrl;
            ActorsDb.FirstName = actor.FirstName;
            ActorsDb.LastName = actor.LastName;
            ActorsDb.Age = actor.Age;
            ActorsDb.Bio = actor.Bio;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var ActorsDb = db.Actors.SingleOrDefault(c => c.ActorId == Id);
            db.Actors.Remove(ActorsDb);
            db.SaveChanges();
            return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
        }

    }
}