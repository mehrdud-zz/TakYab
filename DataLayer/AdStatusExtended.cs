﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [MetadataTypeAttribute(typeof(AdStatusMetadata))]
    public partial class AdStatus
    {
        public override string ToString()
        {
            return this.Name;
        }
    }


    class AdStatusMetadata
    {

        
    }
}
