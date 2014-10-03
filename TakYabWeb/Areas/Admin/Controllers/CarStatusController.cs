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
    public class CarStatusController : Controller
    {
        private TakYabEntities db = new TakYabEntities();

        //
        // GET: /Admin/CarStatus/

        public ActionResult Index()
        {
            return View(db.CarStatus.OrderBy(m => m.SortOrder).ToList());
        }

        //
        // GET: /Admin/CarStatus/Details/5

        public ActionResult Details(Guid id)
        {
            CarStatus carstatus = db.CarStatus.Find(id);
            if (carstatus == null)
            {
                return HttpNotFound();
            }
            return View(carstatus);
        }

        //
        // GET: /Admin/CarStatus/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/CarStatus/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarStatus carstatus)
        {
            if (ModelState.IsValid)
            {
                carstatus.CarStatusId = Guid.NewGuid();
                db.CarStatus.Add(carstatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carstatus);
        }

        //
        // GET: /Admin/CarStatus/Edit/5

        public ActionResult Edit(Guid id)
        {
            CarStatus carstatus = db.CarStatus.Find(id);
            if (carstatus == null)
            {
                return HttpNotFound();
            }
            return View(carstatus);
        }

        //
        // POST: /Admin/CarStatus/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarStatus carstatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carstatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carstatus);
        }

        //
        // GET: /Admin/CarStatus/Delete/5

        public ActionResult Delete(Guid id)
        {
            CarStatus carstatus = db.CarStatus.Find(id);
            if (carstatus == null)
            {
                return HttpNotFound();
            }
            return View(carstatus);
        }

        //
        // POST: /Admin/CarStatus/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CarStatus carstatus = db.CarStatus.Find(id);
            db.CarStatus.Remove(carstatus);
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