
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webs_YueyxShop.Web.Filters;

namespace webs_YueyxShop.Web.Controllers.ShuSW
{
    public class sswLoginController : Controller
    {
        //[CurAction]
        //[Exception]
        
        public ActionResult Login() 
        {
            ViewBag.Title = "用户登录-书生网";
            
            return View();
        }

    }
}