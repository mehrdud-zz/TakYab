using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace TakYab.Areas.Ads.Controllers
{
    public class CarShowController : Controller
    {
        private TakYabEntities db = new TakYabEntities();

        public ActionResult LeftBarCarList()
        {
            var cars = db.Cars.Include(c => c.SubModel).Include(c => c.SubModel.Model)
           .OrderBy(m => m.Priority.SortOrder).Where(m => m.Priority.Code == "SideBar").OrderBy(m => m.SortOrder).Take(5);
            return View(cars.ToList());
        }

        public ActionResult BottomPageCarList()
        {
            var cars = db.Cars.Include(c => c.AdType).Include(c => c.BuildYear).Include(c => c.PriceRange).Include(c => c.Priority).Include(c => c.Province).Include(c => c.SubModel)
                .OrderBy(m => m.Priority.SortOrder).OrderBy(m => m.SortOrder).Take(50);
            return View(cars.ToList());
        }



        public ActionResult CarRotator()
        {
            var selectedCars = db.Cars.Where(m => m.Priority.Code == "Homepage" && !String.IsNullOrEmpty(m.ImageURI1)).OrderBy(m => m.SortOrder).Take(5);
            return View(selectedCars.ToList());
        }
    }
}