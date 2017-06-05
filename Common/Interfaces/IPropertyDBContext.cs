using Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IPropertyDBContext
    {
        IDbSet<Property> Properties { get; set; }
        IDbSet<Company> Companies { get; set; }

        int SaveChanges();
    }
}
