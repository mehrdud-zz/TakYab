﻿using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TakYab.Areas.Search.Controllers
{
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
            var searchCriterias = new SearchCriteria();
            searchCriterias.CarStatusList = db.CarStatus.OrderBy(m => m.SortOrder).ToList();
            searchCriterias.ModelList = db.Models.OrderBy(m => m.SortOrder).ToList();
            searchCriterias.SubModelList = db.SubModels.OrderBy(m => m.SortOrder).ToList();
            searchCriterias.AdTypeList = db.AdTypes.OrderBy(m => m.SortOrder).ToList();
            searchCriterias.PriceRangeList = db.PriceRanges.OrderBy(m => m.SortOrder).ToList();
            searchCriterias.BuildYearList = db.BuildYears.OrderBy(m => m.SortOrder).ToList();
            searchCriterias.ProvinceList = db.Provinces.OrderBy(m => m.SortOrder).ToList();


            string sefrKarkarde = !String.IsNullOrEmpty(Request.Form["carStatusHidden"]) ? Request.Form["carStatusHidden"] : String.Empty;

            if (!String.IsNullOrEmpty(sefrKarkarde) && sefrKarkarde != "-1")
            {
                var carStatus = db.CarStatus.First(m => m.Code == sefrKarkarde);
                if (carStatus != null)
                    searchCriterias.CarStatusId = carStatus.CarStatusId;
            }

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

        public ActionResult SearchComponentNew()
        {
            var searchForm = ReadSearchForm();

            var searchResult = Search(
                searchForm.CarStatusId,
                searchForm.ProvinceId,
                searchForm.ModelId,
                searchForm.SubModelId,
                searchForm.PriceRangeId,
                searchForm.BuildYearId,
                searchForm.AdTypeId
                );

            var searchCriterias = new SearchCriteria();

            var submodelCount =
                 from car in searchResult
                 where
                    (searchForm.CarStatusId == Guid.Empty || car.CarStatusId == searchForm.CarStatusId) &&
                    (searchForm.ProvinceId == Guid.Empty || car.ProvinceId == searchForm.ProvinceId) &&
                    (searchForm.ModelId == Guid.Empty || car.ModelId == searchForm.ModelId) &&
                    (searchForm.SubModelId == Guid.Empty || car.SubModelId == searchForm.SubModelId) &&
                    (searchForm.PriceRangeId == Guid.Empty || car.PriceRangeId == searchForm.PriceRangeId) &&
                    (searchForm.BuildYearId == Guid.Empty || car.BuildYearId == searchForm.BuildYearId) &&
                    (searchForm.AdTypeId == Guid.Empty || car.AdTypeId == searchForm.AdTypeId)
                 group car by new { SubModelId = car.SubModelId, SubModel = car.SubModel } into counts
                 select new SearchCriteriaItem { Count = counts.Count(), ItemId = counts.Key.SubModelId, Name = counts.Key.SubModel };

            searchCriterias.SubModelSearchCriteriaItemList =
                submodelCount.ToList();


            var modelCount =
                from car in searchResult
                where
                   (searchForm.CarStatusId == Guid.Empty || car.CarStatusId == searchForm.CarStatusId) &&
                   (searchForm.ProvinceId == Guid.Empty || car.ProvinceId == searchForm.ProvinceId) &&
                   (searchForm.ModelId == Guid.Empty || car.ModelId == searchForm.ModelId) &&
                   (searchForm.SubModelId == Guid.Empty || car.SubModelId == searchForm.SubModelId) &&
                   (searchForm.PriceRangeId == Guid.Empty || car.PriceRangeId == searchForm.PriceRangeId) &&
                   (searchForm.BuildYearId == Guid.Empty || car.BuildYearId == searchForm.BuildYearId) &&
                   (searchForm.AdTypeId == Guid.Empty || car.AdTypeId == searchForm.AdTypeId)
                group car by new { ModelId = car.ModelId, Model = car.Model } into counts
                select new SearchCriteriaItem { Count = counts.Count(), ItemId = counts.Key.ModelId, Name = counts.Key.Model };

            searchCriterias.ModelSearchCriteriaItemList =
                modelCount.ToList();


            var provinceCount =
                from car in searchResult
                where
                   (searchForm.CarStatusId == Guid.Empty || car.CarStatusId == searchForm.CarStatusId) &&
                   (searchForm.ProvinceId == Guid.Empty || car.ProvinceId == searchForm.ProvinceId) &&
                   (searchForm.ModelId == Guid.Empty || car.ModelId == searchForm.ModelId) &&
                   (searchForm.SubModelId == Guid.Empty || car.SubModelId == searchForm.SubModelId) &&
                   (searchForm.PriceRangeId == Guid.Empty || car.PriceRangeId == searchForm.PriceRangeId) &&
                   (searchForm.BuildYearId == Guid.Empty || car.BuildYearId == searchForm.BuildYearId) &&
                   (searchForm.AdTypeId == Guid.Empty || car.AdTypeId == searchForm.AdTypeId)
                group car by new { ProvinceId = car.ProvinceId, Province = car.Province } into counts
                select new SearchCriteriaItem { Count = counts.Count(), ItemId = counts.Key.ProvinceId, Name = counts.Key.Province };

            searchCriterias.ProvinceSearchCriteriaItemList =
                provinceCount.ToList();


            var buildYearCount =
                from car in searchResult
                where
                   (searchForm.CarStatusId == Guid.Empty || car.CarStatusId == searchForm.CarStatusId) &&
                   (searchForm.ProvinceId == Guid.Empty || car.ProvinceId == searchForm.ProvinceId) &&
                   (searchForm.ModelId == Guid.Empty || car.ModelId == searchForm.ModelId) &&
                   (searchForm.SubModelId == Guid.Empty || car.SubModelId == searchForm.SubModelId) &&
                   (searchForm.PriceRangeId == Guid.Empty || car.PriceRangeId == searchForm.PriceRangeId) &&
                   (searchForm.BuildYearId == Guid.Empty || car.BuildYearId == searchForm.BuildYearId) &&
                   (searchForm.AdTypeId == Guid.Empty || car.AdTypeId == searchForm.AdTypeId)
                group car by new { BuildYearId = car.BuildYearId, BuildYear = car.BuildYear } into counts
                select new SearchCriteriaItem { Count = counts.Count(), ItemId = counts.Key.BuildYearId, Name = counts.Key.BuildYear };

            searchCriterias.BuildYearSearchCriteriaItemList =
                buildYearCount.ToList();


            var adTypeCount =
                from car in searchResult
                where
                   (searchForm.CarStatusId == Guid.Empty || car.CarStatusId == searchForm.CarStatusId) &&
                   (searchForm.ProvinceId == Guid.Empty || car.ProvinceId == searchForm.ProvinceId) &&
                   (searchForm.ModelId == Guid.Empty || car.ModelId == searchForm.ModelId) &&
                   (searchForm.SubModelId == Guid.Empty || car.SubModelId == searchForm.SubModelId) &&
                   (searchForm.PriceRangeId == Guid.Empty || car.PriceRangeId == searchForm.PriceRangeId) &&
                   (searchForm.BuildYearId == Guid.Empty || car.BuildYearId == searchForm.BuildYearId) &&
                   (searchForm.AdTypeId == Guid.Empty || car.AdTypeId == searchForm.AdTypeId)
                group car by new { AdTypeId = car.AdTypeId, AdType = car.AdType } into counts
                select new SearchCriteriaItem { Count = counts.Count(), ItemId = counts.Key.AdTypeId, Name = counts.Key.AdType };

            searchCriterias.AdTypeSearchCriteriaItemList =
                adTypeCount.ToList();


            searchCriterias.PriceRangeSearchCriteriaItemList =
                new List<SearchCriteriaItem>();

            string sefrKarkarde = !String.IsNullOrEmpty(Request.Form["carStatusHidden"]) ? Request.Form["carStatusHidden"] : String.Empty;

            if (!String.IsNullOrEmpty(sefrKarkarde) && sefrKarkarde != "-1")
            {
                var carStatus = db.CarStatus.First(m => m.Code == sefrKarkarde);
                if (carStatus != null)
                {
                    searchCriterias.CarStatusId = carStatus.CarStatusId;
                    searchCriterias.CarStatus = carStatus.Name;
                }
            }

            searchCriterias.ProvinceId = searchForm.ProvinceId;
            searchCriterias.Province = searchForm.Province;

            searchCriterias.ModelId = searchForm.ModelId;
            searchCriterias.Model = searchForm.Model;

            searchCriterias.SubModelId = searchForm.SubModelId;
            searchCriterias.SubModel = searchForm.SubModel;

            searchCriterias.PriceRangeId = searchForm.PriceRangeId;
            searchCriterias.PriceRange = searchForm.PriceRange;

            searchCriterias.BuildYearId = searchForm.BuildYearId;
            searchCriterias.BuildYear = searchForm.BuildYear;

            searchCriterias.AdTypeId = searchForm.AdTypeId;
            searchCriterias.AdType = searchForm.AdType;

            searchCriterias.TotalNumberofCars = searchResult.Count;

            return View(searchCriterias);
        }


        [HttpPost]
        public JsonResult SearchComponentNewJson(
            String CarStatusString,
            String ProvinceString,
            String ModelString,
            String SubModelString,
            String PriceRangeString,
            String BuildYearString,
            String AdTypeString
            )
        {
            Guid CarStatusId = Guid.Empty;
            int sefrKarKarde = (!String.IsNullOrEmpty(CarStatusString) ? Convert.ToInt32(CarStatusString) : -1);
            if (sefrKarKarde >= 0)
            {
                var carStatus = db.CarStatus.First(m => m.Code == CarStatusString);
                if (carStatus != null)
                    CarStatusId = carStatus.CarStatusId;
            }



            Guid ProvinceId = (!String.IsNullOrEmpty(ProvinceString) ? Guid.Parse(ProvinceString) : Guid.Empty);
            Guid ModelId = (!String.IsNullOrEmpty(ModelString) ? Guid.Parse(ModelString) : Guid.Empty);
            Guid SubModelId = (!String.IsNullOrEmpty(SubModelString) ? Guid.Parse(SubModelString) : Guid.Empty);
            Guid PriceRangeId = (!String.IsNullOrEmpty(PriceRangeString) ? Guid.Parse(PriceRangeString) : Guid.Empty);
            Guid BuildYearId = (!String.IsNullOrEmpty(BuildYearString) ? Guid.Parse(BuildYearString) : Guid.Empty);
            Guid AdTypeId = (!String.IsNullOrEmpty(AdTypeString) ? Guid.Parse(AdTypeString) : Guid.Empty);

            var searchResult = Search(
               CarStatusId,
               ProvinceId,
               ModelId,
               SubModelId,
               PriceRangeId,
               BuildYearId,
               AdTypeId);

            var searchCriterias = new SearchCriteria();

            if (searchResult.Count > 0)
            {

                var submodelCount =
                     from car in searchResult
                     where
                        (CarStatusId == Guid.Empty || car.CarStatusId == CarStatusId) &&
                        (ProvinceId == Guid.Empty || car.ProvinceId == ProvinceId) &&
                        (ModelId == Guid.Empty || car.ModelId == ModelId) &&
                        (SubModelId == Guid.Empty || car.SubModelId == SubModelId) &&
                        (PriceRangeId == Guid.Empty || car.PriceRangeId == PriceRangeId) &&
                        (BuildYearId == Guid.Empty || car.BuildYearId == BuildYearId) &&
                        (AdTypeId == Guid.Empty || car.AdTypeId == AdTypeId)
                     group car by new { SubModelId = car.SubModelId, SubModel = car.SubModel } into counts
                     select new SearchCriteriaItem { Count = counts.Count(), ItemId = counts.Key.SubModelId, Name = counts.Key.SubModel };

                searchCriterias.SubModelSearchCriteriaItemList =
                    submodelCount.ToList();


                var modelCount =
                    from car in searchResult
                    where
                       (CarStatusId == Guid.Empty || car.CarStatusId == CarStatusId) &&
                       (ProvinceId == Guid.Empty || car.ProvinceId == ProvinceId) &&
                       (ModelId == Guid.Empty || car.ModelId == ModelId) &&
                       (SubModelId == Guid.Empty || car.SubModelId == SubModelId) &&
                       (PriceRangeId == Guid.Empty || car.PriceRangeId == PriceRangeId) &&
                       (BuildYearId == Guid.Empty || car.BuildYearId == BuildYearId) &&
                       (AdTypeId == Guid.Empty || car.AdTypeId == AdTypeId)
                    group car by new { ModelId = car.ModelId, Model = car.Model } into counts
                    select new SearchCriteriaItem { Count = counts.Count(), ItemId = counts.Key.ModelId, Name = counts.Key.Model };

                searchCriterias.ModelSearchCriteriaItemList =
                    modelCount.ToList();


                var provinceCount =
                    from car in searchResult
                    where
                       (CarStatusId == Guid.Empty || car.CarStatusId == CarStatusId) &&
                       (ProvinceId == Guid.Empty || car.ProvinceId == ProvinceId) &&
                       (ModelId == Guid.Empty || car.ModelId == ModelId) &&
                       (SubModelId == Guid.Empty || car.SubModelId == SubModelId) &&
                       (PriceRangeId == Guid.Empty || car.PriceRangeId == PriceRangeId) &&
                       (BuildYearId == Guid.Empty || car.BuildYearId == BuildYearId) &&
                       (AdTypeId == Guid.Empty || car.AdTypeId == AdTypeId)
                    group car by new { ProvinceId = car.ProvinceId, Province = car.Province } into counts
                    select new SearchCriteriaItem { Count = counts.Count(), ItemId = counts.Key.ProvinceId, Name = counts.Key.Province };

                searchCriterias.ProvinceSearchCriteriaItemList =
                    provinceCount.ToList();


                var buildYearCount =
                    from car in searchResult
                    where
                       (CarStatusId == Guid.Empty || car.CarStatusId == CarStatusId) &&
                       (ProvinceId == Guid.Empty || car.ProvinceId == ProvinceId) &&
                       (ModelId == Guid.Empty || car.ModelId == ModelId) &&
                       (SubModelId == Guid.Empty || car.SubModelId == SubModelId) &&
                       (PriceRangeId == Guid.Empty || car.PriceRangeId == PriceRangeId) &&
                       (BuildYearId == Guid.Empty || car.BuildYearId == BuildYearId) &&
                       (AdTypeId == Guid.Empty || car.AdTypeId == AdTypeId)
                    group car by new { BuildYearId = car.BuildYearId, BuildYear = car.BuildYear } into counts
                    select new SearchCriteriaItem { Count = counts.Count(), ItemId = counts.Key.BuildYearId, Name = counts.Key.BuildYear };

                searchCriterias.BuildYearSearchCriteriaItemList =
                    buildYearCount.ToList();


                var adTypeCount =
                    from car in searchResult
                    where
                       (CarStatusId == Guid.Empty || car.CarStatusId == CarStatusId) &&
                       (ProvinceId == Guid.Empty || car.ProvinceId == ProvinceId) &&
                       (ModelId == Guid.Empty || car.ModelId == ModelId) &&
                       (SubModelId == Guid.Empty || car.SubModelId == SubModelId) &&
                       (PriceRangeId == Guid.Empty || car.PriceRangeId == PriceRangeId) &&
                       (BuildYearId == Guid.Empty || car.BuildYearId == BuildYearId) &&
                       (AdTypeId == Guid.Empty || car.AdTypeId == AdTypeId)
                    group car by new { AdTypeId = car.AdTypeId, AdType = car.AdType } into counts
                    select new SearchCriteriaItem { Count = counts.Count(), ItemId = counts.Key.AdTypeId, Name = counts.Key.AdType };

                searchCriterias.AdTypeSearchCriteriaItemList =
                    adTypeCount.ToList();


                searchCriterias.PriceRangeSearchCriteriaItemList =
                    new List<SearchCriteriaItem>();
            }


            string sefrKarkarde = !String.IsNullOrEmpty(Request.Form["carStatusHidden"]) ? Request.Form["carStatusHidden"] : String.Empty;

            if (!String.IsNullOrEmpty(sefrKarkarde) && sefrKarkarde != "-1")
            {
                var carStatus = db.CarStatus.First(m => m.Code == sefrKarkarde);
                if (carStatus != null)
                    searchCriterias.CarStatusId = carStatus.CarStatusId;
            }

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


            searchCriterias.TotalNumberofCars = searchResult.Count;
            return Json(new { Result = searchCriterias }, JsonRequestBehavior.AllowGet);
        }



        public SearchCriteriaLight ReadSearchForm()
        {
            var searchCriteriaLight = new SearchCriteriaLight();
            string sefrKarkarde = !String.IsNullOrEmpty(Request.Form["carStatusHidden"]) ? Request.Form["carStatusHidden"] : String.Empty;

            if (!String.IsNullOrEmpty(sefrKarkarde) && sefrKarkarde != "-1")
            {
                var carStatus = db.CarStatus.First(m => m.Code == sefrKarkarde);
                if (carStatus != null)
                    searchCriteriaLight.CarStatusId = carStatus.CarStatusId;
            }



            searchCriteriaLight.ProvinceId = !String.IsNullOrEmpty(Request.Form["provinceHidden"]) ? Guid.Parse(Request.Form["provinceHidden"]) : Guid.Empty;
            if (searchCriteriaLight.ProvinceId != Guid.Empty)
                searchCriteriaLight.Province = db.Provinces.First(m => m.ProvinceId == searchCriteriaLight.ProvinceId).Name;

            searchCriteriaLight.ModelId = !String.IsNullOrEmpty(Request.Form["modelHidden"]) ? Guid.Parse(Request.Form["modelHidden"]) : Guid.Empty;
            if (searchCriteriaLight.ModelId != Guid.Empty)
                searchCriteriaLight.Model = db.Models.First(m => m.ModelId == searchCriteriaLight.ModelId).Name;


            searchCriteriaLight.SubModelId = !String.IsNullOrEmpty(Request.Form["subModelHidden"]) ? Guid.Parse(Request.Form["subModelHidden"]) : Guid.Empty;
            if (searchCriteriaLight.SubModelId != Guid.Empty)
                searchCriteriaLight.SubModel = db.SubModels.First(m => m.SubModelId == searchCriteriaLight.SubModelId).Name;


            searchCriteriaLight.PriceRangeId = !String.IsNullOrEmpty(Request.Form["priceRangeHidden"]) ? Guid.Parse(Request.Form["priceRangeHidden"]) : Guid.Empty;
            if (searchCriteriaLight.PriceRangeId != Guid.Empty)
                searchCriteriaLight.PriceRange = db.PriceRanges.First(m => m.PriceRangeId == searchCriteriaLight.PriceRangeId).Name;


            searchCriteriaLight.BuildYearId = !String.IsNullOrEmpty(Request.Form["buildYearHidden"]) ? Guid.Parse(Request.Form["buildYearHidden"]) : Guid.Empty;
            if (searchCriteriaLight.BuildYearId != Guid.Empty)
                searchCriteriaLight.BuildYear = db.BuildYears.First(m => m.BuildYearId == searchCriteriaLight.BuildYearId).Name;


            searchCriteriaLight.AdTypeId = !String.IsNullOrEmpty(Request.Form["adTypeHidden"]) ? Guid.Parse(Request.Form["adTypeHidden"]) : Guid.Empty;
            if (searchCriteriaLight.AdTypeId != Guid.Empty)
                searchCriteriaLight.AdType = db.AdTypes.First(m => m.AdTypeId == searchCriteriaLight.AdTypeId).Name;

            return searchCriteriaLight;
        }
        public List<LightCar> Search(
            Guid CarStatusId,
            Guid ProvinceId,
            Guid ModelId,
            Guid SubModelId,
            Guid PriceRangeId,
            Guid BuildYearId,
            Guid AdTypeId)
        {



            var searchResults =
                from cars in db.Cars
                where
                     (CarStatusId == Guid.Empty || cars.CarStatusId == CarStatusId) &&
                     (ProvinceId == Guid.Empty || cars.ProvinceId == ProvinceId) &&
                    (ModelId == Guid.Empty || cars.SubModel.ModelId == ModelId) &&
                    (SubModelId == Guid.Empty || cars.SubModelId == SubModelId) &&
                    (PriceRangeId == Guid.Empty || cars.PriceRangeId == PriceRangeId) &&
                    (BuildYearId == Guid.Empty || cars.BuildYearId == BuildYearId) &&
                    (AdTypeId == Guid.Empty || cars.AdTypeId == AdTypeId) &&
                    (cars.AdStatusId != Guid.Empty && cars.AdStatus.Code == "Approved")

                select new LightCar()
                {
                    CarId = cars.CarId,
                    ImageURI = cars.ImageURI1.Replace("\\", "/"),
                    Model = cars.SubModel != null && cars.SubModel.Model != null ? cars.SubModel.Model.Name : String.Empty,
                    ModelId = (cars.SubModel != null ? cars.SubModel.ModelId : Guid.Empty),
                    SubModel = cars.SubModel != null ? cars.SubModel.Name : String.Empty,
                    SubModelId = (cars.SubModel != null ? cars.SubModelId : Guid.Empty),
                    Price = cars.Price,
                    Province = cars.Province != null ? cars.Province.Name : String.Empty,
                    ProvinceId = (cars.Province != null ? cars.ProvinceId : Guid.Empty),
                    AdType = cars.AdType != null ? cars.AdType.Name : String.Empty,
                    AdTypeId = (cars.AdType != null ? cars.AdTypeId : Guid.Empty),
                    BuildYear = cars.BuildYear != null ? cars.BuildYear.Name : String.Empty,
                    BuildYearId = (cars.BuildYear != null ? cars.BuildYearId : Guid.Empty),
                    CarStatus = cars.CarStatus != null ? cars.CarStatus.Name : String.Empty,
                    CarStatusId = (cars.CarStatus != null ? cars.CarStatusId : Guid.Empty),
                    FirstImage = cars.ImageURI1
                };


            List<LightCar> lightCarsList = searchResults.ToList<LightCar>();
            return lightCarsList;
        }


        public ActionResult SearchResults()
        {
            var searchCriteriaLight = new SearchCriteriaLight();
            string sefrKarkarde = !String.IsNullOrEmpty(Request.Form["carStatusHidden"]) ? Request.Form["carStatusHidden"] : String.Empty;

            if (!String.IsNullOrEmpty(sefrKarkarde) && sefrKarkarde != "-1")
            {
                var carStatus = db.CarStatus.First(m => m.Code == sefrKarkarde);
                if (carStatus != null)
                    searchCriteriaLight.CarStatusId = carStatus.CarStatusId;
            }



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
                    ModelId = (cars.SubModel != null ? cars.SubModel.ModelId : Guid.Empty),
                    SubModel = cars.SubModel != null ? cars.SubModel.Name : String.Empty,
                    SubModelId = (cars.SubModel != null ? cars.SubModelId : Guid.Empty),
                    Price = cars.Price,
                    Province = cars.Province != null ? cars.Province.Name : String.Empty,
                    ProvinceId = (cars.Province != null ? cars.ProvinceId : Guid.Empty),
                    BuildYear = cars.BuildYear != null ? cars.BuildYear.Name : String.Empty,
                    BuildYearId = (cars.BuildYear != null ? cars.BuildYearId : Guid.Empty),
                    FirstImage = cars.ImageURI1
                };


            searchCriteriaLight.LightCarsList = searchResults.ToList<LightCar>();
            return View(searchCriteriaLight);

        }
    }
}