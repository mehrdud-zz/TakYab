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
    public class ModelController : Controller
    {
        private TakYabEntities db = new TakYabEntities();

        //
        // GET: /Advertising/Model/

        public ActionResult Index()
        {
            return View(db.Models.ToList());
        }

        //
        // GET: /Advertising/Model/Details/5

        public ActionResult Details(Guid id)
        {
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        //
        // GET: /Advertising/Model/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Advertising/Model/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Model model)
        {
            if (ModelState.IsValid)
            {
                model.ModelId = Guid.NewGuid();
                db.Models.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        //
        // GET: /Advertising/Model/Edit/5

        public ActionResult Edit(Guid id)
        {
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        //
        // POST: /Advertising/Model/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Model model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //
        // GET: /Advertising/Model/Delete/5

        public ActionResult Delete(Guid id)
        {
            Model model = db.Models.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        //
        // POST: /Advertising/Model/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Model model = db.Models.Find(id);
            db.Models.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        public ActionResult GetModelList()
        {
            var models = db.SubModels.Include(s => s.Model);
            return View(models.ToList());
        }


        public ActionResult GetModelListforFooter() {
            var models = db.Models.Where(m=>m.SubNav==true).OrderBy(m=>m.SortOrder);
            return View(models.ToList());
        }
    }
}