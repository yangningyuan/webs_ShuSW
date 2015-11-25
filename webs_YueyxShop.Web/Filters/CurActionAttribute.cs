using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webs_YueyxShop.Web.Filters
{
    public class CurActionAttribute:ActionFilterAttribute,IActionFilter,IResultFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //filterContext.HttpContext.Response.Write("action执行前");
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //filterContext.HttpContext.Response.Write("action执行后");
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //filterContext.HttpContext.Response.Write("result执行前");
            base.OnResultExecuting(filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //filterContext.HttpContext.Response.Write("result执行前");
            base.OnResultExecuted(filterContext);
        }
    }
}