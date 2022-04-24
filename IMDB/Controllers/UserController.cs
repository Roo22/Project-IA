using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: User
        public ActionResult Index()
        {
            var data = db.Users.ToList(); 
            return View(data);
        }
        public ActionResult Edit(int id)
        {
            var data = db.Users.SingleOrDefault(c => c.UserId == id);

            if (data == null) return View("NotFound");
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {

            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var UserDb = db.Users.SingleOrDefault(c => c.UserId == user.UserId);
            UserDb.ProfilePictureUrl = user.ProfilePictureUrl;
            UserDb.FirstName = user.FirstName;
            UserDb.LastName = user.LastName;
            UserDb.FavActor = user.FavActor;
            UserDb.FavDirector = user.FavDirector;
            UserDb.FavMovie = user.FavMovie;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}