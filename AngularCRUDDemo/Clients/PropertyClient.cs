using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Configuration;
using Common.Viewmodels;

namespace AngularCRUDDemo.Clients
{
    public class PropertyClient : IDisposable
    {
        HttpClient client;
        //The URL of the WEB API Service
        string Baseurl = WebConfigurationManager.AppSettings["Baseurl"];

        public PropertyClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HttpResponseMessage> GetProperties()
        {
            string url = Baseurl + "GetProperties";
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> GetPropertyByID(int id)
        {
            string url = Baseurl + "GetPropertybyId?id=" + id;
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> AddProperty(Propertyvm prop)
        {
            string url = Baseurl + "AddProperty";
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, prop);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> UpdateProperty(Propertyvm prop)
        {
            string url = Baseurl + "EditProperty";
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url, prop);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> RemoveProperty(int id)
        {
            string url = Baseurl + "DeleteProperty?id=" + id;
            HttpResponseMessage responseMessage = await client.DeleteAsync(url);
            return responseMessage;
        }

        public void Dispose()
        {
            
        }
    }
}