using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TakYab.Areas.Advertising.Controllers
{

    public class LightCar
    {
        public Guid CarId { get; set; }
        public string ImageURI { get; set; }
        public string Model { get; set; }
        public string SubModel { get; set; }

        public decimal Price;

        public string Province;

        public string BuildYear;

    }

    public class SearchCriteriaLight
    {
        public Guid AdTypeId { get; set; }
        public Guid CarStatusId { get; set; }
        public Guid ModelId { get; set; }
        public Guid SubModelId { get; set; }
        public Guid PriceRangeId { get; set; }
        public Guid BuildYearId { get; set; }
        public Guid ProvinceId { get; set; }

        public string AdType { get; set; }
        public string CarStatus { get; set; }
        public string Model { get; set; }
        public string SubModel { get; set; }
        public string PriceRange { get; set; }
        public string BuildYear { get; set; }
        public string Province { get; set; }

        public List<LightCar> LightCarsList { get; set; }
    }
    public class SearchCriterias
    {
        public List<DataLayer.CarStatus> CarStatusList { get; set; }
        public List<DataLayer.Model> ModelList { get; set; }
        public List<DataLayer.SubModel> SubModelList { get; set; }

        public List<DataLayer.AdType> AdTypeList { get; set; }

        public List<DataLayer.PriceRange> PriceRangeList { get; set; }

        public List<DataLayer.BuildYear> BuildYearList { get; set; }

        public List<DataLayer.Province> ProvinceList { get; set; }

        public Guid AdTypeId { get; set; }
        public Guid CarStatusId { get; set; }
        public Guid ModelId { get; set; }
        public Guid SubModelId { get; set; }
        public Guid PriceRangeId { get; set; }
        public Guid BuildYearId { get; set; }
        public Guid ProvinceId { get; set; }

        public string AdType { get; set; }
        public string CarStatus { get; set; }
        public string Model { get; set; }
        public string SubModel { get; set; }
        public string PriceRange { get; set; }
        public string BuildYear { get; set; }
        public string Province { get; set; } 
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
            searchCriterias.CarStatusList = db.CarStatus.OrderBy(m => m.SortOrder).ToList();
            searchCriterias.ModelList = db.Models.OrderBy(m => m.SortOrder).ToList();
            searchCriterias.SubModelList = db.SubModels.OrderBy(m => m.SortOrder).ToList();
            searchCriterias.AdTypeList = db.AdTypes.OrderBy(m => m.SortOrder).ToList();
            searchCriterias.PriceRangeList = db.PriceRanges.OrderBy(m => m.SortOrder).ToList();
            searchCriterias.BuildYearList = db.BuildYears.OrderBy(m => m.SortOrder).ToList();
            searchCriterias.ProvinceList = db.Provinces.OrderBy(m => m.SortOrder).ToList();


            searchCriterias.CarStatusId = !String.IsNullOrEmpty(Request.Form["carStatusHidden"]) ? Guid.Parse(Request.Form["carStatusHidden"]) : Guid.Empty;
            searchCriterias.ProvinceId = !String.IsNullOrEmpty(Request.Form["provinceHidden"]) ? Guid.Parse(Request.Form["provinceHidden"]) : Guid.Empty;
            searchCriterias.ModelId = !String.IsNullOrEmpty(Request.Form["modelHidden"]) ? Guid.Parse(Request.Form["modelHidden"]) : Guid.Empty;
            searchCriterias.SubModelId = !String.IsNullOrEmpty(Request.Form["subModelHidden"]) ? Guid.Parse(Request.Form["subModelHidden"]) : Guid.Empty;
            searchCriterias.PriceRangeId = !String.IsNullOrEmpty(Request.Form["priceRangeHidden"]) ? Guid.Parse(Request.Form["priceRangeHidden"]) : Guid.Empty;
            searchCriterias.BuildYearId = !String.IsNullOrEmpty(Request.Form["buildYearHidden"]) ? Guid.Parse(Request.Form["buildYearHidden"]) : Guid.Empty;
            searchCriterias.AdTypeId = !String.IsNullOrEmpty(Request.Form["adTypeHidden"]) ? Guid.Parse(Request.Form["adTypeHidden"]) : Guid.Empty;

            if (searchCriterias.CarStatusId != Guid.Empty)
                searchCriterias.CarStatus = db.CarStatus.First(m => m.CarStatusId == searchCriterias.CarStatusId).Name;

            if (searchCriterias.ProvinceId != Guid.Empty)
                searchCriterias.Province = db.Provinces.First(m => m.ProvinceId == searchCriterias.ProvinceId).Name;

            if (searchCriterias.ModelId != Guid.Empty)
                searchCriterias.Model = db.Models.First(m => m.ModelId == searchCriterias.ModelId).Name;

            if (searchCriterias.SubModelId != Guid.Empty)
                searchCriterias.SubModel = db.SubModels.First(m => m.SubModelId == searchCriterias.SubModelId).Name;

            if (searchCriterias.PriceRangeId != Guid.Empty)
                searchCriterias.PriceRange = db.PriceRanges.First(m => m.PriceRangeId == searchCriterias.PriceRangeId).Name;

            if (searchCriterias.BuildYearId != Guid.Empty)
                searchCriterias.BuildYear = db.BuildYears.First(m => m.BuildYearId == searchCriterias.BuildYearId).Name;

            if (searchCriterias.AdTypeId != Guid.Empty)
                searchCriterias.AdType = db.AdTypes.First(m => m.AdTypeId == searchCriterias.AdTypeId).Name;



            return View(searchCriterias);
        }

        public ActionResult CarRotator()
        {
            var selectedCars = db.Cars.Where(m => m.Priority.Code == "Homepage" && !String.IsNullOrEmpty(m.ImageURI1)).OrderBy(m => m.SortOrder);
            return View(selectedCars.ToList());
        }

         
        public ActionResult SearchResults()
        {
            var searchCriteriaLight = new SearchCriteriaLight(); 
            searchCriteriaLight.CarStatusId = !String.IsNullOrEmpty(Request.Form["carStatusHidden"]) ? Guid.Parse(Request.Form["carStatusHidden"]) : Guid.Empty;
            searchCriteriaLight.ProvinceId = !String.IsNullOrEmpty(Request.Form["provinceHidden"]) ? Guid.Parse(Request.Form["provinceHidden"]) : Guid.Empty;
            searchCriteriaLight.ModelId = !String.IsNullOrEmpty(Request.Form["modelHidden"]) ? Guid.Parse(Request.Form["modelHidden"]) : Guid.Empty;
            searchCriteriaLight.SubModelId = !String.IsNullOrEmpty(Request.Form["subModelHidden"]) ? Guid.Parse(Request.Form["subModelHidden"]) : Guid.Empty;
            searchCriteriaLight.PriceRangeId = !String.IsNullOrEmpty(Request.Form["priceRangeHidden"]) ? Guid.Parse(Request.Form["priceRangeHidden"]) : Guid.Empty;
            searchCriteriaLight.BuildYearId = !String.IsNullOrEmpty(Request.Form["buildYearHidden"]) ? Guid.Parse(Request.Form["buildYearHidden"]) : Guid.Empty;
            searchCriteriaLight.AdTypeId = !String.IsNullOrEmpty(Request.Form["adTypeHidden"]) ? Guid.Parse(Request.Form["adTypeHidden"]) : Guid.Empty; 

            if (searchCriteriaLight.CarStatusId != Guid.Empty)
                searchCriteriaLight.CarStatus = db.CarStatus.First(m => m.CarStatusId == searchCriteriaLight.CarStatusId).Name;

            if (searchCriteriaLight.ProvinceId != Guid.Empty)
                searchCriteriaLight.Province = db.Provinces.First(m => m.ProvinceId == searchCriteriaLight.ProvinceId).Name;

            if (searchCriteriaLight.ModelId != Guid.Empty)
                searchCriteriaLight.Model = db.Models.First(m => m.ModelId == searchCriteriaLight.ModelId).Name;

            if (searchCriteriaLight.SubModelId != Guid.Empty)
                searchCriteriaLight.SubModel = db.SubModels.First(m => m.SubModelId == searchCriteriaLight.SubModelId).Name;

            if (searchCriteriaLight.PriceRangeId != Guid.Empty)
                searchCriteriaLight.PriceRange = db.PriceRanges.First(m => m.PriceRangeId == searchCriteriaLight.PriceRangeId).Name;

            if (searchCriteriaLight.BuildYearId != Guid.Empty)
                searchCriteriaLight.BuildYear = db.BuildYears.First(m => m.BuildYearId == searchCriteriaLight.BuildYearId).Name;

            if (searchCriteriaLight.AdTypeId != Guid.Empty)
                searchCriteriaLight.AdType = db.AdTypes.First(m => m.AdTypeId == searchCriteriaLight.AdTypeId).Name;





            var searchResults =
                from cars in db.Cars
                where
                     (searchCriteriaLight.CarStatusId == Guid.Empty || cars.CarStatusId == searchCriteriaLight.CarStatusId) &&
                     (searchCriteriaLight.ProvinceId == Guid.Empty || cars.ProvinceId == searchCriteriaLight.ProvinceId) &&
                    (searchCriteriaLight.ModelId == Guid.Empty || cars.SubModel.ModelId == searchCriteriaLight.ModelId) &&
                    (searchCriteriaLight.SubModelId == Guid.Empty || cars.SubModelId == searchCriteriaLight.SubModelId) &&
                    (searchCriteriaLight.PriceRangeId == Guid.Empty || cars.PriceRangeId == searchCriteriaLight.PriceRangeId) &&
                    (searchCriteriaLight.BuildYearId == Guid.Empty || cars.BuildYearId == searchCriteriaLight.BuildYearId) &&
                    (searchCriteriaLight.AdTypeId == Guid.Empty || cars.AdTypeId == searchCriteriaLight.AdTypeId)

                select new LightCar()
                {
                    CarId = cars.CarId,
                    ImageURI = cars.ImageURI1.Replace("\\", "/"),
                    Model = cars.SubModel != null && cars.SubModel.Model != null ? cars.SubModel.Model.Name : String.Empty,
                    SubModel = cars.SubModel != null ? cars.SubModel.Name : String.Empty,
                    Price = cars.Price,
                    Province = cars.Province != null ? cars.Province.Name : String.Empty,
                    BuildYear = cars.BuildYear != null ? cars.BuildYear.Name : String.Empty
                };

           
            searchCriteriaLight.LightCarsList = searchResults.ToList<LightCar>();
            return View(searchCriteriaLight);

        }

        //public JsonResult SearchAds(
        //    string usedCar,
        // string province,
        // string model,
        // string subModel,
        // string priceRange,
        // string buildYear,
        // string adType)
        //{
        //    var modelId = !String.IsNullOrEmpty(model) ? Guid.Parse(model.Replace("\"", "")) : Guid.Empty;
        //    var subModelId = !String.IsNullOrEmpty(subModel) ? Guid.Parse(model.Replace("\"", "")) : Guid.Empty;


        //    var searchResults =
        //        from cars in db.Cars
        //        where

        //        (modelId != Guid.Empty && cars.SubModel.ModelId == modelId) ||
        //        (subModelId != Guid.Empty && cars.SubModelId == subModelId)

        //        select new
        //        {
        //            CarId = cars.CarId,
        //            ImageURI = cars.ImageURI1.Replace("\\", "/"),
        //            Model = cars.SubModel.Model.Name,
        //            SubModel = cars.SubModel.Name,
        //            Price = cars.Price
        //        };


        //    return Json(new { Results = searchResults.ToList(), counter = searchResults.ToList().Count() }, JsonRequestBehavior.AllowGet);
        //}
    }


}
