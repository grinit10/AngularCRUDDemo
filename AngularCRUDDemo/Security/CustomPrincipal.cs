using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using Common.Models;
using Common.Viewmodels;
using AngularCRUDDemo.Clients;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AngularCRUDDemo.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; set; }
        private User user;
        private AccountClient client;

        public Uservm um = new Uservm();

        public CustomPrincipal(string name)
        {
            user = FindUserByNameAsync(name).Result;
            Identity = new GenericIdentity(name);
        }

        private async Task<User> FindUserByNameAsync(string name)
        {
            User usr = new User();
            using (client = new AccountClient())
            {
                HttpResponseMessage responseMessage = await client.FindUserByName(name);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    usr = JsonConvert.DeserializeObject<User>(responseData);
                }
            }

            return usr;
        }

        private async Task<IList<Role>> FindRolesbyUserAsync()
        {
            IList<Role> roles = new List<Role>();
            using (client = new AccountClient())
            {
                HttpResponseMessage responseMessage = await client.FindRolesbyUser(user.Name);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    roles = JsonConvert.DeserializeObject<List<Role>>(responseData);
                }

                return roles;
            }
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            IList<Role> UserRoles = FindRolesbyUserAsync().Result;
            return UserRoles.Any(r => roles.Contains(r.RoleName));
        }
    }
}