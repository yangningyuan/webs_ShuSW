using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
namespace webs_YueyxShop.Web.Controllers.YueyXing
{

    public class LogonController : MasterPageController
    {
        //
        // GET: /YueyXing/
        public LogonController()
            : base("登陆")
        {
    
    }

        public ActionResult Logon()
        {
            return View();
        }

    }
}
