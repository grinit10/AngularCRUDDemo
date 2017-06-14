using Common.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class RoleController : ApiController
    {
        private IRoleRepository _repository;

        public RoleController(IRoleRepository repo)
        {
            _repository = repo;
        }
        [HttpPut]
        public HttpResponseMessage UpdateRole(Role role)
        {
            _repository.UpdateRole(role);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        [HttpPost]
        public HttpResponseMessage AddRole(Role role)
        {
            _repository.AddRole(role);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpGet]
        public Role GetRolebyID(int id)
        {
            return _repository.FindRolebyId(id);
        }

        [HttpGet]
        public Role GetRolebyName(string name)
        {
            return _repository.FindRolebyName(name);
        }

        [HttpDelete]
        public HttpResponseMessage RemoveRole(int id)
        {
            _repository.RemoveRole(id);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}