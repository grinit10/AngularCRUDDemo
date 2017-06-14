using System.Collections.Generic;
using System.Web.Mvc;
using Common.Viewmodels;
using AngularCRUDDemo.Clients;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using AngularCRUDDemo.Security;

namespace AngularCRUDDemo.Controllers
{
    
    public class PropertyController : Controller
    {
        private PropertyClient client = null;

        [CustomAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetProperties()
        {
            List<Propertyvm> properties = new List<Propertyvm>();
            using (client = new PropertyClient())
            {
                HttpResponseMessage responseMessage = await client.GetProperties();
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    properties = JsonConvert.DeserializeObject<List<Propertyvm>>(responseData);
                }
            }
            return Json(properties, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetPropertyById(int id)
        {
            Propertyvm prop = new Propertyvm();
            using (client = new PropertyClient())
            {
                HttpResponseMessage responseMessage = await client.GetPropertyByID(id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    prop = JsonConvert.DeserializeObject<Propertyvm>(responseData);
                }
            }
            return Json(prop, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "superadmin,admin")]
        public async Task<JsonResult> AddProperty(Propertyvm prop)
        {
            using (client = new PropertyClient())
            {
                HttpResponseMessage responseMessage = await client.AddProperty(prop);
                if (responseMessage.IsSuccessStatusCode)
                    return Json(new { message = "Record added successfully" });
                else
                    return Json(new { message = "Record not added" });
            }
        }

        [HttpPost]
        [CustomAuthorize(Roles = "superadmin,admin")]
        public async Task<JsonResult> UpdateProperty(Propertyvm prop)
        {
            using (client = new PropertyClient())
            {
                HttpResponseMessage responseMessage = await client.UpdateProperty(prop);
                if (responseMessage.IsSuccessStatusCode)
                    return Json(new { message = "Record updated successfully" });
                else
                    return Json(new { message = "Record not added" });
            }
        }

        [HttpPost]
        [CustomAuthorize(Roles = "superadmin")]
        public async Task<JsonResult> DeleteProperty(int id)
        {
            using (client = new PropertyClient())
            {
                HttpResponseMessage responseMessage = await client.RemoveProperty(id);
                if (responseMessage.IsSuccessStatusCode)
                    return Json(new { message = "Record deleted successfully" });
                else
                    return Json(new { message = "Record not deleted" });
            }
        }
    }
}