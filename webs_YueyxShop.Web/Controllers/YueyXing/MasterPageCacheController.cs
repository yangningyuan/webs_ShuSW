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
    public class MasterPageCacheController : MasterPageController
    {
        /// <summary>
        /// 通用主页
        /// </summary>
        public MasterPageCacheController():this("主母版页")
        {
        }

        /// <summary>
        /// 不加载产品分类列表
        /// 用于不需要产品的页面
        /// </summary>
        /// <param name="obj">无实际意义(可任意传值)</param>
        public MasterPageCacheController(object obj)
        {
        }

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
