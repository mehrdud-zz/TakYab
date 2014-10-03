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
    public class PriorityController : Controller
    {
        private TakYabEntities db = new TakYabEntities();

        //
        // GET: /Admin/Priority/

        public ActionResult Index()
        {
            return View(db.Priorities.OrderBy(m => m.SortOrder).ToList());
        }

        //
        // GET: /Admin/Priority/Details/5

        public ActionResult Details(Guid id)
        {
            Priority priority = db.Priorities.Find(id);
            if (priority == null)
            {
                return HttpNotFound();
            }
            return View(priority);
        }

        //
        // GET: /Admin/Priority/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Priority/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Priority priority)
        {
            if (ModelState.IsValid)
            {
                priority.PriorityId = Guid.NewGuid();
                db.Priorities.Add(priority);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(priority);
        }

        //
        // GET: /Admin/Priority/Edit/5

        public ActionResult Edit(Guid id)
        {
            Priority priority = db.Priorities.Find(id);
            if (priority == null)
            {
                return HttpNotFound();
            }
            return View(priority);
        }

        //
        // POST: /Admin/Priority/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Priority priority)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priority).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(priority);
        }

        //
        // GET: /Admin/Priority/Delete/5

        public ActionResult Delete(Guid id)
        {
            Priority priority = db.Priorities.Find(id);
            if (priority == null)
            {
                return HttpNotFound();
            }
            return View(priority);
        }

        //
        // POST: /Admin/Priority/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Priority priority = db.Priorities.Find(id);
            db.Priorities.Remove(priority);
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