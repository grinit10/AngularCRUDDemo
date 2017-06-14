using Dac.Interfaces;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Viewmodels;
using Common.Models;
using Reposiitry.Utility;
using Common.Identity;

namespace Repository.Repositories
{
    public class UserRepository : IDisposable, IUserRepository
    {
        private IApplicationDBContext _db;

        public UserRepository(IApplicationDBContext ctx)
        {
            _db = ctx;
        }

        public bool ActivateUser(string email,Guid ActivationCode)
        {
            try
            {
                User user = _db.Users.FirstOrDefault(u => u.email == email);
                if (user == null)
                    throw new Exception("User with name" + user.Name + " doesn't exists");
                else
                {
                    user.ActivationCode = ActivationCode;
                    _db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Authenticate(Uservm usr)
        {
            throw new NotImplementedException();
        }

        public Activationvm Register(Uservm usr)
        {
            try
            {
                User user = _db.Users.FirstOrDefault(u => u.Name == usr.Name);
                if (user != null)
                    throw new Exception("User with name" + usr.Name + " exists");
                else
                {
                    user = new User();
                    user.Name = usr.Name;
                    user.password = Crypto.sha256_hash(usr.password);
                    user.ActivationCode = Guid.NewGuid();
                    user.email = usr.email;
                    user.IsActive = false;
                    user.IsDeleted = false;
                    _db.Users.Add(user);
                    _db.SaveChanges();
                }
                return new Activationvm() { email = user.email, ActivationCode = user.ActivationCode };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User FindById(int id)
        {
            return _db.Users.SingleOrDefault(u => u.Id == id);
        }

        public User FindByName(string name)
        {
            User user  = _db.Users.SingleOrDefault(u => u.Name == name);
            if(user.Roles == null || user.Roles.Count == 0)
            {
                user.Roles = RolesbyUser(user.Name);
            }
            return user;
        }

        public void UpdateAsync(User user)
        {
            User usr = _db.Users.SingleOrDefault(u => u.Name == user.Name);
            usr.Name = user.Name;
            usr.email = user.email;
            usr.IsActive = user.IsActive;
            usr.IsDeleted = user.IsDeleted;
            _db.SaveChanges();
        }

        public void AddToRole(User user, string rolename)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (string.IsNullOrEmpty(rolename))
            {
                throw new ArgumentNullException("rolename");
            }

            Role role = _db.Roles.FirstOrDefault(r => r.RoleName == rolename);
            User usr = _db.Users.FirstOrDefault(u => u.Id == user.Id);
            if(usr != null)
            {
                if ((role != null) && (usr.Roles != null) && (!usr.Roles.Any( r => r.RoleName == rolename)))
                {
                    usr.Roles.Add(role);
                }
            }
            
        }

        public IList<Role> RolesbyUser(string name)
        {
            User user = _db.Users.SingleOrDefault(u => u.Name == name);
            IList<int> rolIdlst = _db.UserRoles.Where(u => u.UserId == user.Id).Select(r => r.Id).ToList();
            IList<Role> roles = new List<Role>();
            roles = _db.Roles.Where(r => rolIdlst.Contains(r.Id)).ToList();
            return roles;
        }

        public void Dispose()
        {

        }
    }
}