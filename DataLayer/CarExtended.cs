﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [MetadataTypeAttribute(typeof(CarMetadata))]
    public partial class Car
    {

        public List<string> CarImages
        {
            get
            {
                var carImages = new List<string>();
                if (!String.IsNullOrEmpty(this.ImageURI1))
                    carImages.Add(this.ImageURI1.Replace("\\", "/"));

                if (!String.IsNullOrEmpty(this.ImageURI2))
                    carImages.Add(this.ImageURI2.Replace("\\", "/"));

                if (!String.IsNullOrEmpty(this.ImageURI3))
                    carImages.Add(this.ImageURI3.Replace("\\", "/"));

                if (!String.IsNullOrEmpty(this.ImageURI4))
                    carImages.Add(this.ImageURI4.Replace("\\", "/"));

                if (!String.IsNullOrEmpty(this.ImageURI5))
                    carImages.Add(this.ImageURI5.Replace("\\", "/"));

                return carImages;

            }
        }


        public string FirstImage
        {
            get
            {
                var _firstImage = "";
                if (!String.IsNullOrEmpty(this.ImageURI1))
                    _firstImage = this.ImageURI1.Replace("\\", "/");

                else if (!String.IsNullOrEmpty(this.ImageURI2))
                    _firstImage = this.ImageURI2.Replace("\\", "/");

                else if (!String.IsNullOrEmpty(this.ImageURI3))
                    _firstImage = this.ImageURI3.Replace("\\", "/");

                else if (!String.IsNullOrEmpty(this.ImageURI4))
                    _firstImage = this.ImageURI4.Replace("\\", "/");

                else if (!String.IsNullOrEmpty(this.ImageURI5))
                    _firstImage = this.ImageURI5.Replace("\\", "/");

                return _firstImage;
            }
        }

        public String InsideColour { get; set; }
        public String OutsideColour { get; set; }



        [Display(Name = "مدل خودرو")]
        public string ModelName
        {
            get
            {
                string _modelName = "";
                if (this.SubModel != null && this.SubModel.Model != null)
                {
                    _modelName =
                        String.Format("{0}->{1}", this.SubModel.Name, this.SubModel.Model.Name);
                }
                return _modelName;
            }
        }


        public string PriceString
        {
            get
            {
                return String.Format("{0:n0}", this.Price);
            }
        }

        public bool ImageURI1Checkbox { get; set; }
        public bool ImageURI2Checkbox { get; set; }
        public bool ImageURI3Checkbox { get; set; }
        public bool ImageURI4Checkbox { get; set; }
        public bool ImageURI5Checkbox { get; set; }
    }


    class CarMetadata
    {
        [ScaffoldColumn(false)]
        public System.Guid CarId { get; set; }

        [Display(Name = "مدل خودرو")]
        public Nullable<System.Guid> SubModelId { get; set; }

        [Display(Name = "استان")]
        public Nullable<System.Guid> ProvinceId { get; set; }

        [Display(Name = "نوع آگهی")]
        public Nullable<System.Guid> AdTypeId { get; set; }


        [Display(Name = "توضیحات بیشتر")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "سال تولید")]
        public Nullable<System.Guid> BuildYearId { get; set; }

        [ScaffoldColumn(false)]
        public Nullable<System.Guid> PriceRangeId { get; set; }

        [Display(Name = "قیمت")]
        public decimal Price { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "الویت")]
        public Nullable<System.Guid> PriorityId { get; set; }



        [ScaffoldColumn(false)]
        public Nullable<int> SortOrder { get; set; }

        [Display(Name = "رنگ بیرونی")]
        public Nullable<System.Guid> OutsideColourId { get; set; }

        [Display(Name = "رنگ داخلی")]
        public Nullable<System.Guid> InsideColourId { get; set; }


        [Display(Name = "صفر/کارکرده")]
        public Nullable<System.Guid> CarStatusId { get; set; }


        [Display(Name = "شماره تلفن آگهی")]
        public string PhoneNumber { get; set; }

        [Display(Name = "نوع سوخت")]
        public Nullable<System.Guid> FuelTypeId { get; set; }

        [Display(Name = "بیمه")]
        public Nullable<System.Guid> InsuranceTypeId { get; set; }

        [Display(Name = "کارکرد")]
        public Nullable<long> Milage { get; set; }

        [Display(Name = "عکس 1")]
        public string ImageURI1 { get; set; }

        [Display(Name = "عکس 2")]
        public string ImageURI2 { get; set; }

        [Display(Name = "عکس 3")]
        public string ImageURI3 { get; set; }

        [Display(Name = "عکس 4")]
        public string ImageURI4 { get; set; }

        [Display(Name = "عکس 5")]
        public string ImageURI5 { get; set; }

        [Display(Name = "تاریخ ثبت آگهی")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public Nullable<System.DateTime> AdCreatedDate { get; set; }

        [Display(Name = "تاریخ انقضا آگهی")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public Nullable<System.DateTime> AdValidUntil { get; set; }



        [Display(Name = "نوع دنده")]
        public string GearType { get; set; }
    
    }
}
