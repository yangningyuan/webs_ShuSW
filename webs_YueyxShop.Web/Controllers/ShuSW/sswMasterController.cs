using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webs_YueyxShop.Model;
namespace webs_YueyxShop.Web.Controllers.ShuSW
{
    public class sswMasterController : Controller
    {
        
        public ActionResult LayoutPage() 
        {

            //ViewData[":LoginStatus"] = "";
            //if (System.Web.HttpContext.Current.Request.Cookies[":userlogin"] == null || System.Web.HttpContext.Current.Request.Cookies[":userlogin"].Value == "")
            //{
            //    ViewData[":LoginStatus"] = "fou";
            //}
            //else {
            //    ViewData[":LoginStatus"] = "shi";
            //    MemberBase mimodel = CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies[":userlogin"].Value) as MemberBase;
            //     ViewData[":LoginName"] = mimodel.m_NickName;
            //}
            

            return View();
        }
    }
}