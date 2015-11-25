using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webs_YueyxShop.Web.Controllers.ShuSW
{
    public class sswNewsController:Controller
    {
        public ActionResult NewsList() 
        {
            ViewBag.Title = "财富金-大学生喜爱的购物平台";
            DataTable dtcfj= new BLL.NewsBase().GetList(" m_ID='8960F09C-EC5A-4F66-8A02-27D6079CFF3B' and n_StatusCode=0 and n_IsDel=0 order by n_IsTop desc,n_Sort desc,n_CreatedOn desc;").Tables[0];
            ViewData["dtcfjlist"] = dtcfj;

            return View();
        }

        public ActionResult NewsDetails() 
        {
            

            string nid = Request.QueryString["nid"];
            Model.NewsBase model = new BLL.NewsBase().GetModel(int.Parse(nid));
            if (model != null)
            {
                ViewBag.Title = model.n_Title+"-书生网shusheng360.com";
            }
            else {
                ViewBag.Title = "新闻详细页-书生网shusheng360.com";
            }
            
            return View(model);
        }
    }
}