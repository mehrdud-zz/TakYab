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
    public class ContentPageController : Controller
    {
        private TakYabEntities db = new TakYabEntities();

        //
        // GET: /Admin/ContentPage/

        public ActionResult Index()
        {
            return View(db.ContentPages.ToList());
        }

        //
        // GET: /Admin/ContentPage/Details/5

        public ActionResult Details(Guid id)
        {
            ContentPage contentpage = db.ContentPages.Find(id);
            if (contentpage == null)
            {
                return HttpNotFound();
            }
            return View(contentpage);
        }

        //
        // GET: /Admin/ContentPage/Create

        public ActionResult Create()
        {

         

            return View();
        }

        //
        // POST: /Admin/ContentPage/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)] 
        public ActionResult Create(ContentPage contentpage)
        {
            if (ModelState.IsValid)
            {
                contentpage.ContentPageId = Guid.NewGuid();
                db.ContentPages.Add(contentpage); 
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contentpage);
        }

        //
        // GET: /Admin/ContentPage/Edit/5

        public ActionResult Edit(Guid id)
        {
            ContentPage contentpage = db.ContentPages.Find(id);
            if (contentpage == null)
            {
                return HttpNotFound();
            }
            return View(contentpage);
        }

        //
        // POST: /Admin/ContentPage/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)] 
        public ActionResult Edit(ContentPage contentpage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contentpage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contentpage);
        }

        //
        // GET: /Admin/ContentPage/Delete/5

        public ActionResult Delete(Guid id)
        {
            ContentPage contentpage = db.ContentPages.Find(id);
            if (contentpage == null)
            {
                return HttpNotFound();
            }
            return View(contentpage);
        }

        //
        // POST: /Admin/ContentPage/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ContentPage contentpage = db.ContentPages.Find(id);
            db.ContentPages.Remove(contentpage);
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