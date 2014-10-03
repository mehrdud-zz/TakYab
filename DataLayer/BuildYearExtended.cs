using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [MetadataTypeAttribute(typeof(BuildYearMetadata))]
    public partial class BuildYear
    {
        public override string ToString()
        {
            return this.Name;
        }
    }


    class BuildYearMetadata
    {
        [Required]
        [Display(Name = "سال تولید")]
        public string Name { get; set; } 

        [Display(Name = "ترتیب")]
        public Nullable<int> SortOrder { get; set; }
        
    }
}
