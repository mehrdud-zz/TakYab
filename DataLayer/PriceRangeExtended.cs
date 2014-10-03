using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [MetadataTypeAttribute(typeof(PriceRangeMetadata))]
    public partial class PriceRange
    {
        public override string ToString()
        {
            return this.Name;
        }
    }


    class PriceRangeMetadata
    {

        [Required]
        [Display(Name = "گروه قیمت")]
        public string Name { get; set; }
         
        [Display(Name = "ترتیب")]
        public Nullable<int> SortOrder { get; set; }

        [Required]
        [Display(Name = "شروع")]
        public Nullable<decimal> StartRange { get; set; }

        [Required]
        [Display(Name = "پایان")]
        public Nullable<decimal> EndRange { get; set; }
    }
}
