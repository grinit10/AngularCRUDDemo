using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Viewmodels
{
    public class Activationvm
    {
        [Required]
        public string email { get; set; }

        [Required]
        public Guid ActivationCode { get; set; }
    }
}
