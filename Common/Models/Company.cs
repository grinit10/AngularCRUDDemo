using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Company : AuditableEntity<int>
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Company Name")]
        public string Name { get; set; }

        public virtual List<Property> Properties { get; set; }
    }
}
