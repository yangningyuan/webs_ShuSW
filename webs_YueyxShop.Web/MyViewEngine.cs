using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webs_YueyxShop.Web
{
    public sealed class MyViewEngine : RazorViewEngine
    {
        public MyViewEngine()
        {
            ViewLocationFormats = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Admin/{1}/{0}.cshtml",//我们的后台规则
                "~/Views/ShuSW/{1}/{0}.cshtml",//书生网前台规则
                "~/Views/YueyXing/{1}/{0}.cshtml",//我们的前台规则
                "~/Views/Wap/{1}/{0}.cshtml"//我们的手机站规则
            };
        }

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            return base.FindView(controllerContext, viewName, masterName, useCache);
        }
    }
}