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

        int SaveChanges();
    }
}
