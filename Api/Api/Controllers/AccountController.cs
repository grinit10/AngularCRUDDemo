using Common.Models;
using Common.Viewmodels;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class AccountController : ApiController
    {
        private IUserRepository _repository;
        public AccountController(IUserRepository repo)
        {
            _repository = repo;
        }
        
        [HttpPost]
        public Activationvm Register(Uservm usr)
        {
            return _repository.Register(usr);
        }

        [HttpPut]
        public bool ActivateUser(Activationvm act)
        {
            return _repository.ActivateUser(act.email, act.ActivationCode);
        }
        [HttpGet]
        public User FindUserByName(string name)
        {
            return _repository.FindByName(name);
        }

        [HttpGet]
        public IList<Role> FindRolesbyUser(string name)
        {
            return _repository.RolesbyUser(name);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}