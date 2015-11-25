using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace webs_YueyxShop.Web.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Default()
        {
            string url = HttpContext.Request.Url.Authority;//域名
            string wapUrl = ConfigurationManager.AppSettings["wapUrl"];
            if (url != wapUrl)
            {
                Response.Redirect("/sswHome/Index", true);
            }
            else
            {
                Response.Redirect("/wapIndex/Index", true);
            }
            return View();
        }
    }
}
