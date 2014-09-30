using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TakYab.Areas.Advertising.Controllers
{

    public class SearchCriterias
    {
        public List<DataLayer.Model> ModelList { get; set; }
        public List<DataLayer.SubModel> SubModelList { get; set; }

        public List<DataLayer.AdType> AdTypeList { get; set; }

        public List<DataLayer.PriceRange> PriceRangeList { get; set; }

        public List<DataLayer.BuildYear> BuildYearList { get; set; }

        public List<DataLayer.Province> ProvinceList { get; set; }
    }
    public class SearchController : Controller
    {
        private TakYabEntities db = new TakYabEntities();


        //
        // GET: /Advertising/Search/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SearchComponent()
        {
            var searchCriterias = new SearchCriterias();
            searchCriterias.ModelList = db.Models.OrderBy(m => m.SortOrder).ToList();
            searchCriterias.SubModelList = db.SubModels.OrderBy(m => m.SortOrder).ToList();
            searchCriterias.AdTypeList = db.AdTypes.OrderBy(m => m.SortOrder).ToList();
            searchCriterias.PriceRangeList = db.PriceRanges.OrderBy(m => m.SortOrder).ToList();
            searchCriterias.BuildYearList = db.BuildYears.OrderBy(m => m.SortOrder).ToList();
            searchCriterias.ProvinceList = db.Provinces.OrderBy(m => m.SortOrder).ToList();
            return View(searchCriterias);
        }

        public ActionResult CarRotator()
        {
            var selectedCars = db.Cars.Where(m => m.Priority.Code == "Homepage" && !String.IsNullOrEmpty(m.ImageURI1)).OrderBy(m => m.SortOrder);
            return View(selectedCars.ToList());
        }



        public JsonResult SearchAds(
            string usedCar,
         string province,
         string model,
         string subModel,
         string priceRange,
         string buildYear,
         string adType)
        {
            var modelId = !String.IsNullOrEmpty(model) ? Guid.Parse(model.Replace("\"", "")) : Guid.Empty;
            var subModelId = !String.IsNullOrEmpty(subModel) ? Guid.Parse(model.Replace("\"", "")) : Guid.Empty;


            var searchResults =
                from cars in db.Cars
                where

                (modelId != Guid.Empty && cars.SubModel.ModelId == modelId) ||
                (subModelId != Guid.Empty && cars.SubModelId == subModelId)

                select new
                {
                    CarId = cars.CarId,
                    ImageURI = cars.ImageURI1.Replace("\\", "/"),
                    Model = cars.SubModel.Model.Name,
                    SubModel = cars.SubModel.Name
                };


            return Json(new { Results = searchResults.ToList(), counter = searchResults.ToList().Count() }, JsonRequestBehavior.AllowGet);
        }
    }


}
