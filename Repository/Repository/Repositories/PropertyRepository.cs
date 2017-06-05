using Common.Interfaces;
using Common.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Viewmodels;

namespace Repository.Repositories
{
    public class PropertyRepository : IDisposable, IPropertyRepository
    {
        private IPropertyDBContext _db;

        public PropertyRepository(IPropertyDBContext ctx)
        {
            _db = ctx;
        }

        public PropertyRepository()
        {
        }

        public IEnumerable<Propertyvm> Getproperties()
        {
            try
            {
                IList<Propertyvm> propLst = new List<Propertyvm>();
                propLst = (from p in _db.Properties
                           join c in _db.Companies on p.CompanyId equals c.Id
                           select new Propertyvm
                           {
                               Name = p.Name,
                               BoundsLatA = p.BoundsLatA,
                               BoundsLatB = p.BoundsLatB,
                               BoundsLngA = p.BoundsLngA,
                               BoundsLngB = p.BoundsLngB,
                               CompanyName = c.Name,
                               id = p.Id
                           }).ToList();
                return propLst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public Propertyvm GetByID(int id)
        {
            try
            {
                Propertyvm prop = (from   p in _db.Properties
                                   join   c in _db.Companies on p.CompanyId equals c.Id
                                   where  p.Id == id
                                   select new Propertyvm
                                   {
                                       Name = p.Name,
                                       BoundsLatA = p.BoundsLatA,
                                       BoundsLatB = p.BoundsLatB,
                                       BoundsLngA = p.BoundsLngA,
                                       BoundsLngB = p.BoundsLngB,
                                       CompanyName = c.Name,
                                       id = p.Id
                                   }).SingleOrDefault();
                return prop;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Add(Propertyvm prop)
        {
            try
            {
                Company cmp = _db.Companies.FirstOrDefault(x => x.Name == prop.CompanyName);
                if (cmp == null)
                {
                    cmp = new Company();
                    cmp.Name = prop.CompanyName;
                    _db.Companies.Add(cmp);
                    _db.SaveChanges();
                }

                Property property = CopyProperty(prop);

                _db.Properties.Add(property);

                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Edit(Propertyvm prop)
        {
            try
            {
                Company cmp = _db.Companies.FirstOrDefault(x => x.Name == prop.CompanyName);
                if (cmp == null)
                {
                    cmp = new Company();
                    cmp.Name = prop.CompanyName;
                    _db.Companies.Add(cmp);
                    _db.SaveChanges();
                }
                Property property = _db.Properties.FirstOrDefault(x => x.Id == prop.id);
                if(property != null)
                {
                    property.Name = prop.Name;
                    property.BoundsLatA = prop.BoundsLatA;
                    property.BoundsLatB = prop.BoundsLatB;
                    property.BoundsLngA = prop.BoundsLngA;
                    property.BoundsLngB = prop.BoundsLngB;
                    property.CompanyId = _db.Companies.FirstOrDefault(x => x.Name == prop.CompanyName).Id;
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Remove(int Id)
        {
            try
            {
                Property property = _db.Properties.FirstOrDefault(x => x.Id == Id);
                if(property != null)
                {
                    _db.Properties.Remove(property);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private Property CopyProperty(Propertyvm prop)
        {
            Property property = new Property();
            property.Name = prop.Name;
            property.BoundsLatA = prop.BoundsLatA;
            property.BoundsLatB = prop.BoundsLatB;
            property.BoundsLngA = prop.BoundsLngA;
            property.BoundsLngB = prop.BoundsLngB;
            property.CompanyId = _db.Companies.FirstOrDefault(x => x.Name == prop.CompanyName).Id;

            return property;
        }

        public void Dispose()
        {

        }
    }
}
