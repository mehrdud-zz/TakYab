using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [MetadataTypeAttribute(typeof(ProvinceMetadata))]
    public partial class Province
    {
        public override string ToString()
        {
            return this.Name;
        }
    }


    class ProvinceMetadata
    {

        
    }
}
