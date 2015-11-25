using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webs_YueyxShop.Web.Filters
{
    public class ExceptionAttribute:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled) 
            {
                filterContext.Result = new RedirectResult("~/ErrorPage/Error404");
                filterContext.ExceptionHandled = true;
            }
            base.OnException(filterContext);
        }
    }
}