using Common.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace AngularCRUDDemo.Clients
{
    public class AccountClient : IDisposable
    {
        HttpClient client;
        //The URL of the WEB API Service
        string Baseurl = WebConfigurationManager.AppSettings["Baseurl"] + "/Account/";

        public AccountClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HttpResponseMessage> Register(Uservm usr)
        {
            string url = Baseurl + "Register";
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, usr);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> ActivateUser(Activationvm act)
        {
            string url = Baseurl + "ActivateUser";
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url, act);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> FindUserByName(string name)
        {
            string url = Baseurl + "FindUserByName?name=" + name;
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> FindRolesbyUser(string name)
        {
            string url = Baseurl + "FindRolesbyUser?name=" + name;
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            return responseMessage;
        }

        public void Dispose()
        {
        }
    }
}