using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webs_YueyxShop.Web.Controllers.YueyXing
{
    /// <summary>
    /// 登录页面cookies判断
    /// </summary>
    public class CookiesController : BaseYYController
    {
        #region 判断cookies是否过期

        /// <summary>
        /// OnActionExecuting 判断cookies是否过期
        /// </summary>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (System.Web.HttpContext.Current.Request.Cookies["UserInfo"] == null)
            {
                PageRedirect();
            }
        }

        #endregion
    }
}
