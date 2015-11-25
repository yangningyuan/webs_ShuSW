using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace webs_YueyxShop.Web.Controllers.Wap
{
    public class BaseWapController : Controller, IAuthorizationFilter
    {
        #region 判断cookies是否过期
        /// <summary>
        /// OnActionExecuting 判断cookies是否过期
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (System.Web.HttpContext.Current.Request.Cookies["Energy"] == null)
            {
                PageRedirect();
            }
        }
        #endregion

        #region 属性
        /// <summary>
        /// 用户信息实体
        /// </summary>
        public webs_YueyxShop.Model.MemberBase LoginMember
        {
            get
            {
                return GetParaValue();
            }
        }
        /// <summary>
        /// 获取页面参数的值
        /// </summary>
        public webs_YueyxShop.Model.MemberBase GetParaValue()
        {
            webs_YueyxShop.Model.MemberBase _employeeBase = null;
            //如果Session中能够找到相应的参数值，则返回参数值
            try
            {
                var cookies = System.Web.HttpContext.Current.Request.Cookies["UserInfo"];
                //if (cookies != null && cookies.Expires > DateTime.Now)
                {
                    _employeeBase = CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as webs_YueyxShop.Model.MemberBase;
                }
            }
            catch (Exception err)
            {
                PageRedirect();
            }

            return _employeeBase;
        }
        #endregion

        /// <summary>
        /// 超时登录
        /// </summary>
        void PageRedirect()
        {
            //string str = RouteData.Values["controller"].ToString();
            //if (RouteData.Values["controller"].ToString() == "Home" || str == "YUDA")
            //    Response.Redirect("http://" + Request.Url.Authority, true);
            //else
            //    Response.Redirect("http://" + Request.Url.Authority + "/Login/TimeOut", true);


        }

        //protected Model.MemberBase GetCurrentMemberInfo()
        //{
        //    Model.MemberBase mi = Session["CurrentMember"] as Model.MemberBase;
        //    return mi;
        //}

        //protected int SetCurrentMemberInfo(Model.MemberBase mi)
        //{
        //    Session["CurrentMember"] = mi;
        //    return 0;
        //}

        protected string GetClientIP()
        {
            string ipString;
            if (string.IsNullOrEmpty(Request.ServerVariables["HTTP_X_FORWARDED_FOR"]))
            {
                ipString = Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                ipString = Request.ServerVariables["HTTP_X_FORWARDED_FOR"]
                   .Split(",".ToCharArray(),
                   StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
            }

            return ipString;
        }

        public DataTable GetPagedTable(DataTable dt, int PageIndex, int PageSize)
        {
            if (PageIndex == 0)
                return dt;
            DataTable newdt = dt.Copy();
            newdt.Clear();

            int rowbegin = (PageIndex - 1) * PageSize;
            int rowend = PageIndex * PageSize;

            if (rowbegin >= dt.Rows.Count)
                return newdt;

            if (rowend > dt.Rows.Count)
                rowend = dt.Rows.Count;
            for (int i = rowbegin; i <= rowend - 1; i++)
            {
                DataRow newdr = newdt.NewRow();
                DataRow dr = dt.Rows[i];
                foreach (DataColumn column in dt.Columns)
                {
                    newdr[column.ColumnName] = dr[column.ColumnName];
                }
                newdt.Rows.Add(newdr);
            }

            return newdt;
        }
    }
}