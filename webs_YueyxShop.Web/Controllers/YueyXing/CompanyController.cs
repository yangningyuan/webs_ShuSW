using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webs_YueyxShop.Web.Controllers.YueyXing
{
    public class CompanyController : MasterPageController
    {
        //
        // GET: /Company/
        private readonly BLL.NewsBase _newsBase = new BLL.NewsBase();
        private readonly BLL.MenuBase _menuBase = new BLL.MenuBase();

        public ActionResult Index()
        {

            GetAdertsFormServer("CompanyAdertTop", 34);//首页顶部轮播

            var model = _menuBase.GetModelList(" m_MingCh = '入驻须知'").FirstOrDefault();
            if (model != null)
            {
                var list = _newsBase.GetModelList(" m_ID='" + model.m_ID + "' and n_IsDel = 0");
                return View(list);
            }
            return View();
        }

        public ActionResult CompanyEenter()
        {
            BLL.MemberBase member = new BLL.MemberBase();
            var list = member.GetModelList(" m_usertype = 2 and m_shenPstatus = 1 and m_statuscode = 0 and ");
            ViewData["companyEnter"] = list;
            return View();
        }

        public ActionResult Partialremaituijian()
        {
            List<Model.ProductBase> pinfo = new BLL.ProductBase().GetpInfoByRecommendTypeId(1);
            return View(pinfo.ToList());
        }
    }
}