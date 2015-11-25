using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace webs_YueyxShop.Web._ashx
{
    /// <summary>
    /// Logon 的摘要说明
    /// </summary>
    public class Logon : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request.QueryString["type"].ToString();
            switch (type)
            {
                case "SingleLogon":
                    SingleLogon(context);
                    break;
                case "wapLogon":
                    WapLogon(context);
                    break;
                case "DsnsLogon":
                    DsnsLogon(context);
                    break;
                case "LogOut":
                    LogOut(context);
                    break;
            }
        }

        public void DsnsLogon(HttpContext context)
        {
            string username = context.Request.QueryString["uname"].ToString().Trim();
            string passwd = context.Request.QueryString["passwd"].ToString().Trim();
            passwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(passwd, "MD5");
            string AutoLogon = context.Request.QueryString["AutoLogon"].ToString();
            BLL.MemberBase bll = new BLL.MemberBase();
            DataSet ds = bll.GetList(string.Format(" m_UserName='{0}' and m_Password='{1}' and m_UserType=2", username, passwd));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (dr["m_StatusCode"].ToString() == "1")
                {
                    context.Response.Write("账号异常,请联系工作人员");
                }
                else if (dr["m_ShenPstatus"].ToString() == "0")
                {
                    context.Response.Write("账号未审核");
                }
                else
                {
                    DateTime ckExpires = DateTime.Now.AddHours(1);
                    if (AutoLogon == "1")
                    {
                        ckExpires = DateTime.Now.AddDays(7);
                    }
                    Model.MemberBase model = bll.GetModel(int.Parse(dr["m_id"].ToString()));
                    context.Response.Cookies["UserInfo"].Value = CookieEncrypt.SerializeObject(model);
                    context.Response.Cookies["UserInfo"].Expires = ckExpires;

                    string url = context.Request.UrlReferrer.AbsoluteUri;
                    context.Response.Write("1");

                }
            }
            else
            {
                context.Response.Write("账号不存在或用户名密码错误");
            }
        }

        public void WapLogon(HttpContext context)
        {
            string username = context.Request.QueryString["uname"].ToString().Trim();
            string passwd = context.Request.QueryString["passwd"].ToString().Trim();
            passwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(passwd, "MD5");
            BLL.MemberBase bll = new BLL.MemberBase();
            DataSet ds = bll.GetList(string.Format(" m_UserName='{0}' and m_Password='{1}'", username, passwd));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (dr["m_StatusCode"].ToString() == "1")
                {
                    context.Response.Write("账号异常,请联系工作人员");
                }
                else
                {
                    DateTime ckExpires = DateTime.Now.AddHours(3);
                    Model.MemberBase model = bll.GetModel(int.Parse(dr["m_id"].ToString()));
                    context.Response.Cookies["UserInfo"].Value = CookieEncrypt.SerializeObject(model);
                    context.Response.Cookies["UserInfo"].Expires = ckExpires;
                    string url = context.Request["referer"] == null ? "/" : context.Request["referer"].ToString();
                    context.Response.Write("1");
                }
            }
            else
            {
                context.Response.Write("账号不存在或用户名密码错误");
            }
        }

        public void SingleLogon(HttpContext context)
        {
            string username = context.Request.QueryString["uname"].ToString().Trim();
            string passwd = context.Request.QueryString["passwd"].ToString().Trim();
            passwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(passwd, "MD5");
            string AutoLogon = context.Request.QueryString["AutoLogon"].ToString();
            BLL.MemberBase bll = new BLL.MemberBase();
            DataSet ds = bll.GetList(string.Format(" m_UserName='{0}' and m_Password='{1}' and (m_UserType=0 or m_UserType=1)", username, passwd));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                if (dr["m_StatusCode"].ToString() == "1")
                {
                    context.Response.Write("账号异常,请联系工作人员");
                }
                else
                {
                    DateTime ckExpires = DateTime.Now.AddHours(1);
                    if (AutoLogon == "1")
                    {
                        ckExpires = DateTime.Now.AddDays(7);
                    }
                    Model.MemberBase model = bll.GetModel(int.Parse(dr["m_id"].ToString()));
                    context.Response.Cookies["UserInfo"].Value = CookieEncrypt.SerializeObject(model);
                    context.Response.Cookies["UserInfo"].Expires = ckExpires;
                    string url = context.Request["referer"] == null? "/": context.Request["referer"].ToString();
                    context.Response.Write("1");
                }
            }
            else
            {
                context.Response.Write("账号不存在或用户名密码错误");
            }
        }

        public void LogOut(HttpContext context)
        {
            var cookies = context.Response.Cookies["UserInfo"];
            if (cookies != null)
            {
                context.Response.Cookies["UserInfo"].Expires = DateTime.Now.AddDays(-1);
                context.Response.Write("1");
                return;
            }

            context.Response.Write("退出失败！");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}