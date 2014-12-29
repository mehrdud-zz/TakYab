using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TakYab.Areas.Search.Controllers
{
    public class LightCar
    {
        public Guid CarId { get; set; }
        public string ImageURI { get; set; }

        public string Model { get; set; }
        public Nullable<Guid> ModelId { get; set; }


        public string CarStatus { get; set; }
        public Nullable<Guid> CarStatusId { get; set; }


        public string SubModel { get; set; }
        public Nullable<Guid> SubModelId { get; set; }

        public decimal Price;

        public Nullable<Guid> PriceRangeId { get; set; }

        public string Province;
        public Nullable<Guid> ProvinceId { get; set; }

        public string BuildYear;
        public Nullable<Guid> BuildYearId { get; set; }


        public string AdType;
        public Nullable<Guid> AdTypeId { get; set; }

        public string FirstImage { get; set; }


        public string ModelName
        {
            get
            {
                return String.Format("{0}->{1}", this.Model, this.SubModel);
            }
        }

    }
}