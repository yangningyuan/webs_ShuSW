using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webs_YueyxShop.Web.Controllers
{
    public class UnSalesProductController : BaseController
    {
        private RoleManager Rolemanager = new RoleManager();
        private readonly RoleManager _roleManager = new RoleManager();

        public ActionResult UnSalesProductMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            return View();
        }


        public ActionResult UnSalesProductList()
        {
            return View();
        }
            
    }
}
