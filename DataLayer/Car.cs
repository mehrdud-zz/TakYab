//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        public Car()
        {
            this.CarViews = new HashSet<CarView>();
            this.FavouritCars = new HashSet<FavouritCar>();
            this.FirstPageAds = new HashSet<FirstPageAd>();
        }
    
        public System.Guid CarId { get; set; }
        public Nullable<System.Guid> SubModelId { get; set; }
        public Nullable<System.Guid> ProvinceId { get; set; }
        public Nullable<System.Guid> AdTypeId { get; set; }
        public Nullable<System.Guid> BuildYearId { get; set; }
        public Nullable<System.Guid> PriceRangeId { get; set; }
        public Nullable<System.Guid> PriorityId { get; set; }
        public Nullable<System.Guid> AdStatusId { get; set; }
        public Nullable<System.Guid> OutsideColourId { get; set; }
        public Nullable<System.Guid> InsideColourId { get; set; }
        public Nullable<System.Guid> FuelTypeId { get; set; }
        public Nullable<System.Guid> InsuranceTypeId { get; set; }
        public Nullable<System.Guid> CarStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Nullable<int> SortOrder { get; set; }
        public Nullable<System.DateTime> AdCreatedDate { get; set; }
        public Nullable<System.DateTime> AdValidUntil { get; set; }
        public string GearType { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageURI1 { get; set; }
        public string ImageURI2 { get; set; }
        public string ImageURI3 { get; set; }
        public string ImageURI4 { get; set; }
        public string ImageURI5 { get; set; }
        public Nullable<long> Milage { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual AdStatus AdStatus { get; set; }
        public virtual AdType AdType { get; set; }
        public virtual BuildYear BuildYear { get; set; }
        public virtual CarStatus CarStatus { get; set; }
        public virtual FuelType FuelType { get; set; }
        public virtual InsuranceType InsuranceType { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual Province Province { get; set; }
        public virtual SubModel SubModel { get; set; }
        public virtual PriceRange PriceRange { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<CarView> CarViews { get; set; }
        public virtual ICollection<FavouritCar> FavouritCars { get; set; }
        public virtual ICollection<FirstPageAd> FirstPageAds { get; set; }
    }
}
