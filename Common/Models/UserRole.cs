using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class UserRole : AuditableEntity<int>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
