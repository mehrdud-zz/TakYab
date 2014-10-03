using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [MetadataTypeAttribute(typeof(ModelMetadata))]
    public partial class Model
    {
        public override string ToString()
        {
            return this.Name;
        }
    }


    class ModelMetadata
    { 
        [Required]
        [Display(Name = "کمپانی خودرو سازی")]
        public string Name { get; set; }

        [Display(Name = "توضیحات بیشتر")]
        public string Description { get; set; }

        [Display(Name = "ترتیب")]
        public Nullable<int> SortOrder { get; set; }
    }
}
