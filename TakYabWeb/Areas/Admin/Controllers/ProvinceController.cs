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
    public class ProvinceController : Controller
    {
        private TakYabEntities db = new TakYabEntities();

        //
        // GET: /Admin/Province/

        public ActionResult Index()
        {
            return View(db.Provinces.OrderBy(m => m.SortOrder).ToList());
        }

        //
        // GET: /Admin/Province/Details/5

        public ActionResult Details(Guid id)
        {
            Province province = db.Provinces.Find(id);
            if (province == null)
            {
                return HttpNotFound();
            }
            return View(province);
        }

        //
        // GET: /Admin/Province/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Province/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Province province)
        {
            if (ModelState.IsValid)
            {
                province.ProvinceId = Guid.NewGuid();
                db.Provinces.Add(province);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(province);
        }

        //
        // GET: /Admin/Province/Edit/5

        public ActionResult Edit(Guid id)
        {
            Province province = db.Provinces.Find(id);
            if (province == null)
            {
                return HttpNotFound();
            }
            return View(province);
        }

        //
        // POST: /Admin/Province/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Province province)
        {
            if (ModelState.IsValid)
            {
                db.Entry(province).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(province);
        }

        //
        // GET: /Admin/Province/Delete/5

        public ActionResult Delete(Guid id)
        {
            Province province = db.Provinces.Find(id);
            if (province == null)
            {
                return HttpNotFound();
            }
            return View(province);
        }

        //
        // POST: /Admin/Province/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Province province = db.Provinces.Find(id);
            db.Provinces.Remove(province);
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