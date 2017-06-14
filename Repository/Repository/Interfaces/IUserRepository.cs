using Common.Models;
using Common.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        Activationvm Register(Uservm usr);
        bool Authenticate(Uservm usr);
        bool ActivateUser(string email, Guid ActivationCode);
        User FindByName(string name);
        IList<Role> RolesbyUser(string name);
    }
}
