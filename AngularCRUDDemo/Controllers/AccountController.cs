using AngularCRUDDemo.Clients;
using Common.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Newtonsoft.Json;
using AngularCRUDDemo.Security;
using Common.Models;

namespace AngularCRUDDemo.Controllers
{
    public class AccountController : Controller
    {
        private AccountClient client;
        // GET: Accounnt
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> FindUserByNameAsync(string name)
        {
            using (client = new AccountClient())
            {
                HttpResponseMessage responseMessage = await client.FindUserByName(name);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    User act = JsonConvert.DeserializeObject<User>(responseData);
                    return View(act);
                }
                else
                    return View();
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(Uservm usr)
        {
            if (!ModelState.IsValid)
                return View();
            else
            {
                using (client = new AccountClient())
                {
                    HttpResponseMessage responseMessage = await client.Register(usr);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                        Activationvm act = JsonConvert.DeserializeObject<Activationvm>(responseData);
                        sendmail(act);
                        return RedirectToAction("Index", "Property");
                    }
                    else
                        return View();
                }
            }
        }

        [NonAction]
        private void sendmail(Activationvm act)
        {
            string verifyUrl = "/Account/Activation" + act.ActivationCode.ToString();
            string link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            var fromEmail = new MailAddress("arnabdotnet2015@gmail.com","Account verification system");
            var toEmail = new MailAddress(act.email);
            var fromEmailPwd = "seahawk.349";
            string subject = "Your account is successfully created!";
            string body = "Congratulations! Your account has been created successfuly.<br/>Please click<a href='" + link + "'>here</a> to activate your account.";

            using (var client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(fromEmail.Address,fromEmailPwd),
            })
            {
                using (var message = new MailMessage()
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    //client.Send(message);
                    client.Send(fromEmail.Address, toEmail.Address, subject, body);
                }
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Uservm usr)
        {
            if (string.IsNullOrEmpty(usr.Name) || string.IsNullOrEmpty(usr.password))
                return View("Login");
            else
            {
                SessionPersister.Username = usr.Name;
                return RedirectToAction("Index", "Property");
            }
        }
    }
}