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
    public class InsuranceTypeController : Controller
    {
        private TakYabEntities db = new TakYabEntities();

        //
        // GET: /Admin/InsuranceType/

        public ActionResult Index()
        {
            return View(db.InsuranceTypes.OrderBy(m => m.SortOrder).ToList());
        }

        //
        // GET: /Admin/InsuranceType/Details/5

        public ActionResult Details(Guid id)
        {
            InsuranceType insurancetype = db.InsuranceTypes.Find(id);
            if (insurancetype == null)
            {
                return HttpNotFound();
            }
            return View(insurancetype);
        }

        //
        // GET: /Admin/InsuranceType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/InsuranceType/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InsuranceType insurancetype)
        {
            if (ModelState.IsValid)
            {
                insurancetype.InsuranceTypeId = Guid.NewGuid();
                db.InsuranceTypes.Add(insurancetype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insurancetype);
        }

        //
        // GET: /Admin/InsuranceType/Edit/5

        public ActionResult Edit(Guid id)
        {
            InsuranceType insurancetype = db.InsuranceTypes.Find(id);
            if (insurancetype == null)
            {
                return HttpNotFound();
            }
            return View(insurancetype);
        }

        //
        // POST: /Admin/InsuranceType/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InsuranceType insurancetype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insurancetype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insurancetype);
        }

        //
        // GET: /Admin/InsuranceType/Delete/5

        public ActionResult Delete(Guid id)
        {
            InsuranceType insurancetype = db.InsuranceTypes.Find(id);
            if (insurancetype == null)
            {
                return HttpNotFound();
            }
            return View(insurancetype);
        }

        //
        // POST: /Admin/InsuranceType/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            InsuranceType insurancetype = db.InsuranceTypes.Find(id);
            db.InsuranceTypes.Remove(insurancetype);
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