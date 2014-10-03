using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace TakYab.Areas.Admin.Controllers
{
    public class PriceRangeController : Controller
    {
        private TakYabEntities db = new TakYabEntities();

        //
        // GET: /Admin/PriceRange/

        public ActionResult Index()
        {
            return View(db.PriceRanges.OrderBy(m => m.SortOrder).ToList());
        }

        //
        // GET: /Admin/PriceRange/Details/5

        public ActionResult Details(Guid id)
        {
            PriceRange pricerange = db.PriceRanges.Find(id);
            if (pricerange == null)
            {
                return HttpNotFound();
            }
            return View(pricerange);
        }

        //
        // GET: /Admin/PriceRange/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/PriceRange/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PriceRange pricerange)
        {
            if (ModelState.IsValid)
            {
                pricerange.PriceRangeId = Guid.NewGuid();
                db.PriceRanges.Add(pricerange);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pricerange);
        }

        //
        // GET: /Admin/PriceRange/Edit/5

        public ActionResult Edit(Guid id)
        {
            PriceRange pricerange = db.PriceRanges.Find(id);
            if (pricerange == null)
            {
                return HttpNotFound();
            }
            return View(pricerange);
        }

        //
        // POST: /Admin/PriceRange/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PriceRange pricerange)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pricerange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pricerange);
        }

        //
        // GET: /Admin/PriceRange/Delete/5

        public ActionResult Delete(Guid id)
        {
            PriceRange pricerange = db.PriceRanges.Find(id);
            if (pricerange == null)
            {
                return HttpNotFound();
            }
            return View(pricerange);
        }

        //
        // POST: /Admin/PriceRange/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            PriceRange pricerange = db.PriceRanges.Find(id);
            db.PriceRanges.Remove(pricerange);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}