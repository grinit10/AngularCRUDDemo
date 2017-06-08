using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Viewmodels
{
    public class Registervm : AuditableEntity<int>
    {
        [Required]
        public string Name { get; set; }
        public string password { get; set; }
        public string RepeatPassword { get; set; }
        public string email { get; set; }
    }
}