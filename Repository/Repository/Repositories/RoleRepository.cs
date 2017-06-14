using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Dac.Interfaces;

namespace Repository.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private IApplicationDBContext _db;

        public RoleRepository(IApplicationDBContext ctx)
        {
            _db = ctx;
        }

        public void AddRole(Role role)
        {
            if(role != null)
            {
                _db.Roles.Add(role);
                _db.SaveChanges();
            }
        }

        public Role FindRolebyId(int id)
        {
            if (id != 0)
                return _db.Roles.SingleOrDefault(r => r.Id == id);
            else
                return new Role();
        }

        public Role FindRolebyName(string name)
        {
            if (name != null)
                return _db.Roles.SingleOrDefault(r => r.RoleName == name);
            else
                return new Role();
        }

        public void RemoveRole(int id)
        {
            if (id != 0)
            {
                Role role = new Role();
                role = _db.Roles.SingleOrDefault(r => r.Id == id);
                _db.Roles.Remove(role);
            }
        }

        public void UpdateRole(Role role)
        {
            try
            {
                Role rol = _db.Roles.FirstOrDefault(x => x.RoleName == role.RoleName);
                if (rol != null)
                {
                    rol.IsActive = role.IsActive;
                    rol.IsDeleted = role.IsDeleted;
                    rol.RoleName = role.RoleName;
                    _db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}