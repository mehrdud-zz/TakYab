using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [MetadataTypeAttribute(typeof(ContentPageMetadata))]
    public partial class ContentPage
    {
        public override string ToString()
        {
            return this.Name;
        }
    }


    class ContentPageMetadata
    { 


        [Display(Name = "نام")]
        public string Name { get; set; }
         
        public string URL { get; set; }

        [Display(Name = "مطلب")]
        public string HtmlContent { get; set; }
    }
}
