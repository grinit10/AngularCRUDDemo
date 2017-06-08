using Common.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularCRUDDemo.Controllers
{
    public class AccountController : Controller
    {
        // GET: Accounnt
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Registervm usr)
        {
            return View();
        }
    }
}