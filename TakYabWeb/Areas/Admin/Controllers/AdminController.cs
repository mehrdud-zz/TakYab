using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using TakYab.Areas.User.Controllers;


namespace TakYab.Areas.Admin.Controllers
{



    [Authorize(Roles = "administrator")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/Admin/


        private TakYabEntities db = new TakYabEntities();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult NewAds()
        {
            var cars = db.Cars.Include(c => c.AdType).Include(c => c.BuildYear).Include(c => c.PriceRange).Include(c => c.Priority).
                Include(c => c.Province).Include(c => c.SubModel).OrderBy(m => m.AdStatus.SortOrder).Include(c => c.AdStatus).Where(m => m.AdStatus.Code == "New");
            return View(cars.ToList());
        }


        public ActionResult FirstPageAds()
        {
            var firstPageCars = (
                from fpa in db.FirstPageAds
                join cars2 in db.Cars on fpa.CarId equals cars2.CarId
                select cars2).Distinct();
            return View(firstPageCars.ToList());
        }

        public ActionResult ConfirmAds()
        {
            var cars = db.Cars.Where(m => m.AdStatus.Code == "New").OrderBy(m => m.SortOrder);
            return View(cars.ToList());
        }


        [HttpPost]
        public ActionResult ConfirmAd(string CarId)
        {
            Guid CarGuidId = (!String.IsNullOrEmpty(CarId) ? Guid.Parse(CarId) : Guid.Empty);
            var car = db.Cars.First(m => m.CarId == CarGuidId);
            car.AdStatusId = db.AdStatus.First(m => m.Code == "Approved").AdStatusId;
            db.SaveChanges();
            return View();
        }



        public ActionResult RemoveFromFirstPage(Guid CarId)
        {
            var firstPageCars = db.FirstPageAds.Where(m => m.CarId == CarId);
            foreach (var firstPageCar in firstPageCars)
            {
                db.FirstPageAds.Remove(firstPageCar);
            }
            db.SaveChanges();
            return RedirectToAction("FirstPageAds");
        }

        [HttpPost]
        public ActionResult ConfirmAdJson(string CarId)
        {
            Guid CarGuidId = (!String.IsNullOrEmpty(CarId) ? Guid.Parse(CarId) : Guid.Empty);
            var car = db.Cars.First(m => m.CarId == CarGuidId);
            car.AdStatusId = db.AdStatus.First(m => m.Code == "Approved").AdStatusId;
            db.SaveChanges();
            return Json(
           new
           {
               Result = ""
           }
           , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddToFirstPageAds(string CarId)
        {

            Guid CarGuidId = (!String.IsNullOrEmpty(CarId) ? Guid.Parse(CarId) : Guid.Empty);
            var username = TakYab.Areas.User.Controllers.UserController.GetUsername();
            var maxSortOrder = db.FirstPageAds.Max(m => m.SortOrder);
            var firstPageAd = new FirstPageAd() { CarId = CarGuidId, SortOrder = maxSortOrder.HasValue ? maxSortOrder.Value + 1 : 1 };
            db.FirstPageAds.Add(firstPageAd);
            db.SaveChanges();
            return View();
        }

        public ActionResult Ads()
        {
            var cars = db.Cars.Include(c => c.AdType).Include(c => c.BuildYear).Include(c => c.PriceRange).Include(c => c.Priority).Include(c => c.Province).Include(c => c.SubModel);
            return View(cars.ToList());
        }

        public ActionResult AddtoFirstPage()
        {
            List<Guid?> carIdsForFirstPage = (from carsinFirstPage in db.FirstPageAds
                                             where carsinFirstPage.CarId != null
                                             select carsinFirstPage.CarId).ToList();

            var cars = db.Cars.Include(c => c.AdType).Include(c => c.BuildYear).Include(c => c.PriceRange).Include(c => c.Priority).Include(c => c.Province).Include(c => c.SubModel)
              .Where(m => !carIdsForFirstPage.Contains(m.CarId));

            return View(cars.ToList());
        }
    }
}
