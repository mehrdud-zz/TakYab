using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [MetadataTypeAttribute(typeof(PriorityMetadata))]
    public partial class Priority
    {
        public override string ToString()
        {
            return this.Name;
        }
    }


    class PriorityMetadata
    {
        [Required]
        [Display(Name = "الویت")]
        public string Name { get; set; }

        [Display(Name = "توضیحات بیشتر")]
        public string Description { get; set; }

        [Display(Name = "ترتیب")]
        public Nullable<int> SortOrder { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "کد")]
        public string Code { get; set; }
        
    }
}
