using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace webs_YueyxShop.Web.Controllers.YueyXing
{
    public class BaseYYController : Controller
    {
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
                if (cookies != null)
                {
                    _employeeBase = CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as webs_YueyxShop.Model.MemberBase;
                }
            }
            catch
            {
                PageRedirect();
            }

            return _employeeBase;
        }

        #endregion

        public void PageRedirect()
        {
            Response.Write("<script>window.location=\"/Logon/Logon\";</script>");
            Response.End();
            return;
        }

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

        /// <summary>
        /// 字符串长度限制
        /// </summary>
        /// <param name="org">原始字符串</param>
        /// <param name="length">要现实的长度</param>
        /// <param name="suffix">后缀字符</param>
        /// <returns></returns>
        public string CutString(string strOrg, int length, string suffix = "")
        {
            int clength = strOrg.Length;
            if (clength <= length)
            {
                return strOrg;
            }
            string result = strOrg.Substring(0, length);
            result = result + suffix + suffix + suffix;

            return result;
        }
    }
}
