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
    public class SubModelController : Controller
    {
        private TakYabEntities db = new TakYabEntities();

        //
        // GET: /Advertising/SubModel/

        public ActionResult Index()
        {
            var submodels = db.SubModels.Include(s => s.Model).OrderBy(m=>m.SortOrder);
            return View(submodels.ToList());
        }

        //
        // GET: /Advertising/SubModel/Details/5

        public ActionResult Details(Guid id)
        {
            SubModel submodel = db.SubModels.Find(id);
            if (submodel == null)
            {
                return HttpNotFound();
            }
            return View(submodel);
        }

        //
        // GET: /Advertising/SubModel/Create

        public ActionResult Create()
        {
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "Name");
            return View();
        }

        //
        // POST: /Advertising/SubModel/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubModel submodel)
        {
            if (ModelState.IsValid)
            {
                submodel.SubModelId = Guid.NewGuid();
                db.SubModels.Add(submodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "Name", submodel.ModelId);
            return View(submodel);
        }

        //
        // GET: /Advertising/SubModel/Edit/5

        public ActionResult Edit(Guid id)
        {
            SubModel submodel = db.SubModels.Find(id);
            if (submodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "Name", submodel.ModelId);
            return View(submodel);
        }

        //
        // POST: /Advertising/SubModel/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubModel submodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(submodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModelId = new SelectList(db.Models, "ModelId", "Name", submodel.ModelId);
            return View(submodel);
        }

        //
        // GET: /Advertising/SubModel/Delete/5

        public ActionResult Delete(Guid id)
        {
            SubModel submodel = db.SubModels.Find(id);
            if (submodel == null)
            {
                return HttpNotFound();
            }
            return View(submodel);
        }

        //
        // POST: /Advertising/SubModel/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SubModel submodel = db.SubModels.Find(id);
            db.SubModels.Remove(submodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        public ActionResult GetSubModelList()
        {
            var submodels = db.SubModels.Include(s => s.Model);
            return View(submodels.ToList());
        }
         

        public JsonResult GetSubModelListByModelId(Guid modelId)
        {
            var submodels = db.SubModels.Include(s => s.Model).Where(m=>m.ModelId == modelId);

            var subModelsSerialized =
                from cars in submodels
                select new { SubModelId = cars.SubModelId, Name = cars.Name };


            return Json(
            new
            {
                Result = subModelsSerialized.ToList()
            }
            , JsonRequestBehavior.AllowGet); 
        }
    }
}