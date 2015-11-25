using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webs_YueyxShop.BLL;
using webs_YueyxShop.Model;


namespace webs_YueyxShop.Web
{
    public class LoginController : Controller
    {

        BLL.EmployeeBase ebBll = new BLL.EmployeeBase();

        public ActionResult Login()
        {
            return View();
        }
        // [LogActionFilter(Message = "登录")]
        public ActionResult UserLogin()
        {
            string username = Request.Form["username"].Trim();
            string password = Request.Form["password"].Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return Content("false");
            }

            password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");

            //var empList = from emp in db.GetEmployeeBases()
            //              where emp.e_DeleteStateCode == 0 &&
            //              emp.e_StateCode == 0 &&
            //              emp.e_YongHM == username &&
            //              emp.e_MiM == password
            //              select emp;

            var empList = ebBll.GetModelList(" e_DeleteStateCode=0 and e_StateCode=0 and e_YongHM='" + username.Trim() + "' and  e_MiM='" + password.Trim() + "'");
            if (empList.Count() > 0)
            {
                foreach (webs_YueyxShop.Model.EmployeeBase emodel in empList)
                {
                    webs_YueyxShop.Model.EmployeeBase o = ebBll.GetModel(emodel.e_ID);
                    System.Web.HttpContext.Current.Response.Cookies["Energy"].Value = CookieEncrypt.SerializeObject(o);
                    System.Web.HttpContext.Current.Response.Cookies["Energy"].Expires = DateTime.Now.AddMinutes(180);
                    return Content("true");
                }
            }
            else
            {
                return Content("false");
            }

            return Content("false");
        }

        public ActionResult TimeOut()
        {
            return View();
        }

        public ActionResult LoginOut()
        {
            if (System.Web.HttpContext.Current.Request.Cookies["Energy"] != null)
            {
                System.Web.HttpContext.Current.Request.Cookies["Energy"].Expires = DateTime.Now.AddDays(-1);
                System.Web.HttpContext.Current.Request.Cookies.Clear();

                Response.Redirect("/Login/Login");
                //Response.Redirect("~/");
            }
            return View();
        }
    }
}
