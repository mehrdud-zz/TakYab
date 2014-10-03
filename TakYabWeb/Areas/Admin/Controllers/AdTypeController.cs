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
    public class AdTypeController : Controller
    {
        private TakYabEntities db = new TakYabEntities();

        //
        // GET: /Admin/AdType/

        public ActionResult Index()
        {
            return View(db.AdTypes.OrderBy(m => m.SortOrder).ToList());
        }

        //
        // GET: /Admin/AdType/Details/5

        public ActionResult Details(Guid id)
        {
            AdType adtype = db.AdTypes.Find(id);
            if (adtype == null)
            {
                return HttpNotFound();
            }
            return View(adtype);
        }

        //
        // GET: /Admin/AdType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/AdType/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdType adtype)
        {
            if (ModelState.IsValid)
            {
                adtype.AdTypeId = Guid.NewGuid();
                db.AdTypes.Add(adtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adtype);
        }

        //
        // GET: /Admin/AdType/Edit/5

        public ActionResult Edit(Guid id)
        {
            AdType adtype = db.AdTypes.Find(id);
            if (adtype == null)
            {
                return HttpNotFound();
            }
            return View(adtype);
        }

        //
        // POST: /Admin/AdType/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdType adtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adtype);
        }

        //
        // GET: /Admin/AdType/Delete/5

        public ActionResult Delete(Guid id)
        {
            AdType adtype = db.AdTypes.Find(id);
            if (adtype == null)
            {
                return HttpNotFound();
            }
            return View(adtype);
        }

        //
        // POST: /Admin/AdType/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AdType adtype = db.AdTypes.Find(id);
            db.AdTypes.Remove(adtype);
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