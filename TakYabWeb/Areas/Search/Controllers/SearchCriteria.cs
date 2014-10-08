using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace TakYab.Areas.Search.Controllers
{
    public class SearchCriteriaItem
    {
        public string Name { get; set; }
        public Nullable<Guid> ItemId { get; set; }
        public int Count { get; set; }
    }
    public class SearchCriteria
    {

        public List<SearchCriteriaItem> SubModelSearchCriteriaItemList { get; set; }
        public List<SearchCriteriaItem> ModelSearchCriteriaItemList { get; set; }
        public List<SearchCriteriaItem> AdTypeSearchCriteriaItemList { get; set; }
        public List<SearchCriteriaItem> PriceRangeSearchCriteriaItemList { get; set; }
        public List<SearchCriteriaItem> BuildYearSearchCriteriaItemList { get; set; }
        public List<SearchCriteriaItem> ProvinceSearchCriteriaItemList { get; set; }

        
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
}