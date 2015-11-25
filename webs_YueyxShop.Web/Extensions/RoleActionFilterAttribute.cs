using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Common;

namespace webs_YueyxShop.Web
{
    /// <summary>
    /// 权限验证
    /// </summary>
    public class RoleActionFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 页面类型
        /// </summary>
        public string ViewType { get; set; }
        /// <summary>
        /// 功能编码
        /// </summary>
        public string FunctionCode { get; set; }

        /// <summary>
        /// 验证权限（action执行前会先执行这里）
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string functionCode = FunctionCode;
            string pageType = ViewType == null ? "ajaxTodo" : ViewType;

            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            //普通页面权限判断
            webs_YueyxShop.Model.EmployeeBase _employeeBase = CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["WeiXin"].Value) as webs_YueyxShop.Model.EmployeeBase;
            if (_employeeBase == null)
            {
                throw new Exception("no login");
            }

            var url = filterContext.HttpContext.Request.Url.ToString().ToLower();
            if (url.Contains("otype=details"))
                return;//忽略对detail页的权限判定
            if (FunctionCode.Contains(","))
            {
                string[] array = FunctionCode.Split(',');
                if (url.Contains("otype=add"))
                {
                    functionCode = array[0];
                }
                else
                {
                    functionCode = array[1];
                }
            }
            if (!new RoleManager().IsHasFunRole(_employeeBase.e_ID, functionCode))
            {
                if (pageType == "ajaxTodo")
                {
                    filterContext.Result = new JavaScriptResult { Script = " alertMsg.info('你没有操作权限！！！');" };
                }
                else if (pageType == "navTab")
                {
                    filterContext.Result = new JavaScriptResult { Script = " alertMsg.info('你没有操作权限！！！');navTab.closeCurrentTab();" };
                }
                else if (pageType == "dialog")
                {
                    filterContext.Result = new JavaScriptResult { Script = " alertMsg.info('你没有操作权限！！！');$.pdialog.closeCurrent(); " };
                }
                else
                {
                    filterContext.Result = new JavaScriptResult { Script = " alertMsg.info('你没有操作权限！！！');" + pageType + ";" };
                }
            }

        }
    }
}