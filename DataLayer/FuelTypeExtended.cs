using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [MetadataTypeAttribute(typeof(FuelTypeMetadata))]
    public partial class FuelType
    {
        public override string ToString()
        {
            return this.Name;
        }
    }


    class FuelTypeMetadata
    {

        [Required]
        [Display(Name = "نوع سوخت")]
        public string Name { get; set; } 

        [Display(Name = "ترتیب")]
        public Nullable<int> SortOrder { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "کد")]
        public string Code { get; set; }
        
    }
}
