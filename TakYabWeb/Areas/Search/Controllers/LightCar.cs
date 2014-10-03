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
        public string SubModel { get; set; }

        public decimal Price;

        public string Province;

        public string BuildYear;
        public string FirstImage { get; set; }


        public string ModelName
        {
            get
            {
                return String.Format("{0}->{1}", this.SubModel, this.Model);
            }
        }

    }
}