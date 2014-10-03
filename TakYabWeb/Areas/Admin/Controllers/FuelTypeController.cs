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
    public class FuelTypeController : Controller
    {
        private TakYabEntities db = new TakYabEntities();

        //
        // GET: /Admin/FuelType/

        public ActionResult Index()
        {
            return View(db.FuelTypes.OrderBy(m => m.SortOrder).ToList());
        }

        //
        // GET: /Admin/FuelType/Details/5

        public ActionResult Details(Guid id)
        {
            FuelType fueltype = db.FuelTypes.Find(id);
            if (fueltype == null)
            {
                return HttpNotFound();
            }
            return View(fueltype);
        }

        //
        // GET: /Admin/FuelType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/FuelType/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FuelType fueltype)
        {
            if (ModelState.IsValid)
            {
                fueltype.FuelTypeId = Guid.NewGuid();
                db.FuelTypes.Add(fueltype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fueltype);
        }

        //
        // GET: /Admin/FuelType/Edit/5

        public ActionResult Edit(Guid id)
        {
            FuelType fueltype = db.FuelTypes.Find(id);
            if (fueltype == null)
            {
                return HttpNotFound();
            }
            return View(fueltype);
        }

        //
        // POST: /Admin/FuelType/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FuelType fueltype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fueltype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fueltype);
        }

        //
        // GET: /Admin/FuelType/Delete/5

        public ActionResult Delete(Guid id)
        {
            FuelType fueltype = db.FuelTypes.Find(id);
            if (fueltype == null)
            {
                return HttpNotFound();
            }
            return View(fueltype);
        }

        //
        // POST: /Admin/FuelType/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            FuelType fueltype = db.FuelTypes.Find(id);
            db.FuelTypes.Remove(fueltype);
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