using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    class User : AuditableEntity<int>
    {
        [Required]
        public string Name { get; set; }
        public string password { get; set; }
        public string FacebookId { get; set; }
        public string email { get; set; }
        public Guid ActivationCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDemo { get; set; }
        public DateTime? LastSyncDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
    }
}
