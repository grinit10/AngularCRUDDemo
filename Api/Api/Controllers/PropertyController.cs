using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Repository.Interfaces;
using Common.Models;
using Common.Viewmodels;

namespace Api.Controllers
{
    public class PropertyController : ApiController
    {
        private IPropertyRepository _repository;
        public PropertyController(IPropertyRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public IEnumerable<Propertyvm> GetProperties()
        {
            IEnumerable<Propertyvm> properties = _repository.Getproperties();
            return properties;
        }

        [HttpGet]
        public Propertyvm GetPropertybyId(int id)
        {
            Propertyvm prop = _repository.GetByID(id);
            return prop;
        }

        [HttpPost]
        public HttpResponseMessage AddProperty(Propertyvm prop)
        {
            _repository.Add(prop);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpPut]
        public HttpResponseMessage EditProperty(Propertyvm prop)
        {
            _repository.Edit(prop);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteProperty(int id)
        {
            _repository.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
