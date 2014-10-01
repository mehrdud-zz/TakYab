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

        
    }
}
