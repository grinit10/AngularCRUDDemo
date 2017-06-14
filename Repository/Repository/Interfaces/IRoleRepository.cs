using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRoleRepository
    {
        void AddRole(Role role);
        void RemoveRole(int id);
        Role FindRolebyId(int id);
        Role FindRolebyName(string name);
        void UpdateRole(Role role);
    }
}
