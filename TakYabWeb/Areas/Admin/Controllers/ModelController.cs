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
    public class ModelController : Controller
    {
        private TakYabEntities db = new TakYabEntities();

        //
        // GET: /Advertising/Model/

        public ActionResult Index()
        {
            return View(db.Models.OrderBy(m => m.SortOrder).ToList());
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

                if (Request.Files != null)
                    for (var i = 0; i < Request.Files.Count && i < 1; i++)
                    {
                        if (Request.Files[i].ContentLength > 0)
                        {
                            var fileName = System.IO.Path.GetFileName(Request.Files[i].FileName);
                            var photoPath = "00Models\\" + model.ModelId + "\\ImageURI" + (i + 1) + "\\";
                            var directory = System.Configuration.ConfigurationManager.AppSettings["ImagesFolderName"] + photoPath;
                            if (!System.IO.Directory.Exists(directory))
                                System.IO.Directory.CreateDirectory(directory);

                            var path = System.IO.Path.Combine(directory, fileName);
                            Request.Files[i].SaveAs(path);

                            var thumbnail = directory + "Thumbnail.png";
                            TakYab.Controllers.ImageManagerController.resizeImage(path, 200, 150, thumbnail, System.Drawing.Imaging.ImageFormat.Png);

                            var medium = directory + "Medium.png";
                            TakYab.Controllers.ImageManagerController.resizeImage(path, 640, 480, medium, System.Drawing.Imaging.ImageFormat.Png);


                            var large = directory + "Large.png";
                            TakYab.Controllers.ImageManagerController.resizeImage(path, 960, 720, large, System.Drawing.Imaging.ImageFormat.Png);

                            model.ImageURI1 = photoPath;
                        }
                    }
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
                if (Request.Files != null)
                    for (var i = 0; i < Request.Files.Count && i < 1; i++)
                    {
                        if (Request.Files[i].ContentLength > 0)
                        {
                            var fileName = System.IO.Path.GetFileName(Request.Files[i].FileName);
                            var photoPath = "00Models\\" + model.ModelId + "\\ImageURI" + (i + 1) + "\\";
                            var directory = System.Configuration.ConfigurationManager.AppSettings["ImagesFolderName"] + photoPath;
                            if (!System.IO.Directory.Exists(directory))
                                System.IO.Directory.CreateDirectory(directory);

                            var path = System.IO.Path.Combine(directory, fileName);
                            Request.Files[i].SaveAs(path);

                            var thumbnail = directory + "Thumbnail.png";
                            TakYab.Controllers.ImageManagerController.resizeImage(path, 200, 150, thumbnail, System.Drawing.Imaging.ImageFormat.Png);

                            var medium = directory + "Medium.png";
                            TakYab.Controllers.ImageManagerController.resizeImage(path, 640, 480, medium, System.Drawing.Imaging.ImageFormat.Png);


                            var large = directory + "Large.png";
                            TakYab.Controllers.ImageManagerController.resizeImage(path, 960, 720, large, System.Drawing.Imaging.ImageFormat.Png);

                            model.ImageURI1 = photoPath;
                        }
                    }

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


    }
}