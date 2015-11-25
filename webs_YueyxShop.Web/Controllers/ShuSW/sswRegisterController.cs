using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webs_YueyxShop.Web.Controllers.ShuSW
{
    public class sswRegisterController : Controller
    {
        public ActionResult Register() 
        {
            ViewBag.Title = "用户注册-书生网";
            return View();
        }
    }
}