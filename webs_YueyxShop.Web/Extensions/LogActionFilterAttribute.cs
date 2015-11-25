using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webs_YueyxShop.Web
{
    public class LogActionFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 1：添加2：修改3：删除4：查看
        /// </summary>
        public string ActionType { get; set; }
        /// <summary>
        /// 提示信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 在Result产生之后调用
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //普通页面权限判断
            webs_YueyxShop.Model.EmployeeBase _employeeBase = CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["WeiXin"].Value) as webs_YueyxShop.Model.EmployeeBase;
            if (_employeeBase == null)
            {
                throw new Exception("no login");
            }

            //0:成功1：失败
            int resultType = 0;
            //记录操作日志，写进操作日志中
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            var result = filterContext.Result as ContentResult;
            if (result.Content.Contains("300"))
            {
                //失败
                resultType = 1;
            }

            //操作日志

        }
        /// <summary>
        ///  在Result产生之前调用
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
        }
    }
}