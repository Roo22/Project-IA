using IMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Controllers
{
    public class AuthorController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Author

        public ActionResult Index()
        {
            var data = db.Authors.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            if (!ModelState.IsValid)
            {
                return View(author);
            }
            db.Authors.Add(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var data = db.Authors.SingleOrDefault(c => c.AuthorId == id);

            if (data == null) return View("NotFound");
            return View(data);
        }
        public ActionResult Edit(int id)
        {
            var data = db.Authors.SingleOrDefault(c => c.AuthorId == id);

            if (data == null) return View("NotFound");
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Author author)
        {

            if (!ModelState.IsValid)
            {
                return View(author);
            }
            var AuthorsDb = db.Authors.SingleOrDefault(c => c.AuthorId == author.AuthorId);
            AuthorsDb.ProfilePictureUrl = author.ProfilePictureUrl;
            AuthorsDb.FirstName = author.FirstName;
            AuthorsDb.LastName = author.LastName;
            AuthorsDb.Age = author.Age;
            AuthorsDb.Bio = author.Bio;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var AuthorsDb = db.Authors.SingleOrDefault(c => c.AuthorId == Id);
            db.Authors.Remove(AuthorsDb);
            db.SaveChanges();
            return Json(new { result = 1 }, JsonRequestBehavior.AllowGet);
        }

    }
}