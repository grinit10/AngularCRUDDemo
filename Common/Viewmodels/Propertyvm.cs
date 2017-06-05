using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Viewmodels
{
    public class Propertyvm
    {
        public int id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Bounds - Origin Lat")]
        public double BoundsLatA { get; set; }

        [Display(Name = "Bounds - Origin Lng")]
        public double BoundsLngA { get; set; }

        [Display(Name = "Bounds - Closing Lat")]
        public double BoundsLatB { get; set; }

        [Display(Name = "Bounds - Closing Lng")]
        public double BoundsLngB { get; set; }

        public string CompanyName { get; set; }
    }
}
