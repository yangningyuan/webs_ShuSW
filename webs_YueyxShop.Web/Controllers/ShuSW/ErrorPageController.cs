using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webs_YueyxShop.Web.Controllers.ShuSW
{
    public class ErrorPageController:Controller
    {
        public ActionResult Error404()
        {
            ViewBag.Title = "异常跳转页面-书生网";
            return View();
        }
    }
}