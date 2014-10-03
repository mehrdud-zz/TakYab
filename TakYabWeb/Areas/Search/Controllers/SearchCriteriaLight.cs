using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace TakYab.Areas.Search.Controllers
{
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


        public string FirstImage { get; set; }

    }
}