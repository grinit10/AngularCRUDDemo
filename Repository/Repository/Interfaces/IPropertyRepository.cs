using Common.Models;
using Common.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IPropertyRepository
    {
        IEnumerable<Propertyvm> Getproperties();
        Propertyvm GetByID(int id);
        void Add(Propertyvm prop);
        void Edit(Propertyvm prop);
        void Remove(int id);
    }
}
