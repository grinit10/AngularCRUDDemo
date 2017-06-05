using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
{
    public enum ImageType
    {
        [Description("None")]
        None = 0,
        [Description("Zone 0")]
        Zone0 = 1,
        [Description("Zone 35")]
        Zone35 = 2,
        [Description("Zone 65")]
        Zone65 = 3,
        [Description("NDVI 0")]
        NDVI0 = 4,
        [Description("NDVI35 0")]
        NDVI35 = 5,
        [Description("NDVI65 0")]
        NDVI65 = 6
    }
}
