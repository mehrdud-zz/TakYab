using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace TakYab.Areas.Advertising.Controllers
{
    public class ColourController : Controller
    {
        private TakYabEntities db = new TakYabEntities();

        //
        // GET: /Advertising/Colour/

        public ActionResult Index()
        {
            return View(db.Colours.ToList());
        }

        //
        // GET: /Advertising/Colour/Details/5

        public ActionResult Details(Guid id)
        {
            Colour colour = db.Colours.Find(id);
            if (colour == null)
            {
                return HttpNotFound();
            }
            return View(colour);
        }

        //
        // GET: /Advertising/Colour/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Advertising/Colour/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Colour colour)
        {
            if (ModelState.IsValid)
            {
                colour.ColourId = Guid.NewGuid();
                db.Colours.Add(colour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colour);
        }

        //
        // GET: /Advertising/Colour/Edit/5

        public ActionResult Edit(Guid id)
        {
            Colour colour = db.Colours.Find(id);
            if (colour == null)
            {
                return HttpNotFound();
            }
            return View(colour);
        }

        //
        // POST: /Advertising/Colour/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Colour colour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colour);
        }

        //
        // GET: /Advertising/Colour/Delete/5

        public ActionResult Delete(Guid id)
        {
            Colour colour = db.Colours.Find(id);
            if (colour == null)
            {
                return HttpNotFound();
            }
            return View(colour);
        }

        //
        // POST: /Advertising/Colour/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Colour colour = db.Colours.Find(id);
            db.Colours.Remove(colour);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public Colour GetColourById(Guid id)
        {
            var colour = db.Colours.Find(id);
            return colour;

        }



        public List<Colour> GetColours()
        {
            var colour = db.Colours.OrderBy(m => m.SortOrder);
            return colour.ToList();

        }
    }
}