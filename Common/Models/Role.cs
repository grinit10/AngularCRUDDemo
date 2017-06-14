using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Role : AuditableEntity<int>
    {
        public Role()
        {
            this.Users = new List<User>();
        }
        [Required]
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public IList<User> Users { get; set; }
    }
}
