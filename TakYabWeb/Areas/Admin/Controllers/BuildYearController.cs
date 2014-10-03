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
    public class BuildYearController : Controller
    {
        private TakYabEntities db = new TakYabEntities();

        //
        // GET: /Admin/BuildYear/

        public ActionResult Index()
        {
            return View(db.BuildYears.OrderBy(m => m.SortOrder).ToList());
        }

        //
        // GET: /Admin/BuildYear/Details/5

        public ActionResult Details(Guid id)
        {
            BuildYear buildyear = db.BuildYears.Find(id);
            if (buildyear == null)
            {
                return HttpNotFound();
            }
            return View(buildyear);
        }

        //
        // GET: /Admin/BuildYear/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/BuildYear/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BuildYear buildyear)
        {
            if (ModelState.IsValid)
            {
                buildyear.BuildYearId = Guid.NewGuid();
                db.BuildYears.Add(buildyear);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(buildyear);
        }

        //
        // GET: /Admin/BuildYear/Edit/5

        public ActionResult Edit(Guid id)
        {
            BuildYear buildyear = db.BuildYears.Find(id);
            if (buildyear == null)
            {
                return HttpNotFound();
            }
            return View(buildyear);
        }

        //
        // POST: /Admin/BuildYear/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BuildYear buildyear)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buildyear).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buildyear);
        }

        //
        // GET: /Admin/BuildYear/Delete/5

        public ActionResult Delete(Guid id)
        {
            BuildYear buildyear = db.BuildYears.Find(id);
            if (buildyear == null)
            {
                return HttpNotFound();
            }
            return View(buildyear);
        }

        //
        // POST: /Admin/BuildYear/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            BuildYear buildyear = db.BuildYears.Find(id);
            db.BuildYears.Remove(buildyear);
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