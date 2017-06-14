using Common.Identity;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dac.Interfaces
{
    public interface IApplicationDBContext
    {
        IDbSet<Property> Properties { get; set; }
        IDbSet<Company> Companies { get; set; }
        IDbSet<User> Users { get; set; }
        IDbSet<Role> Roles { get; set; }
        IDbSet<UserRole> UserRoles { get; set; }
        //IDbSet<UserClaim> UserClaims { get; set; }
        int SaveChanges();
    }
}
