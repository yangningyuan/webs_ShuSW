using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace webs_YueyxShop.Web.Controllers.YueyXing
{
    public class UserInfoController : MasterPageController
    {
        private readonly BLL.ProductRecommendDetail _productRecommendDetail = new BLL.ProductRecommendDetail();
        private readonly BLL.RegionBase regbll = new BLL.RegionBase();
        private readonly BLL.NewsBase _newsBase = new BLL.NewsBase();
        //
        // GET: /UserInfo/

        public ActionResult Index()
        {
            Model.MemberInfo model = null;
            if (Request.Cookies["UserInfo"] != null)
            {
                model = new BLL.MemberBase().getMemberInfo((CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID);
                var tjlist = _productRecommendDetail.GetTop4List(" order by prt_id desc");
                var models = new Models.ListModel();
                models.dt = tjlist;
                models.Minfo = model;

                try
                {
                    ViewBag.dengji = _newsBase.GetModelList(" n_Title='等级特权'  and n_StatusCode=0 and n_IsDel=0")[0].n_Content;
                }
                catch
                {
                    ViewBag.dengji = "暂无等级特权";
                }
                try
                {
                    ViewBag.shengji = _newsBase.GetModelList(" n_Title='升级机制'  and n_StatusCode=0 and n_IsDel=0")[0].n_Content;
                }
                catch
                {
                    ViewBag.shengji = "暂无升级机制";
                }

                return View(models);
            }
            else
            {
                Response.Redirect("/Index/Index");
                return View();
            }
        }

        public string InsertintoCollect()
        {
            string skuid = "";
            string type = ""; bool result = false;
            if (Request.Cookies["UserInfo"] != null)
            {
                if (!string.IsNullOrEmpty(RequestBase.GetString("skuid")))
                {
                    skuid = RequestBase.GetString("skuid").ToString();
                }
                if (!string.IsNullOrEmpty(RequestBase.GetString("type")))
                {
                    type = RequestBase.GetString("type").ToString();
                }
                Model.VipCollectionBase cmodel = new Model.VipCollectionBase();
                int mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;

                new BLL.VipCollectionBase().Deletebyskuid(mid, int.Parse(skuid));


                cmodel.sku_ID = int.Parse(skuid);
                cmodel.m_ID = mid;
                cmodel.vc_CreateOn = DateTime.Now;
                result = new BLL.VipCollectionBase().Add(cmodel);

                if (result)
                {
                    return "操作成功";
                }
                else
                {
                    return "操作失败";
                }
            }
            else
            {
                return "未登陆";

            }
        }

        public ActionResult CompanyData()
        {
            List<Model.RegionBase> reglist = regbll.GetModelList(" reg_PId=0");
            var models = new Models.ListModel();
            
            models.regList = reglist;
            Model.MemberInfo model = null;
            if (Request.Cookies["UserInfo"] != null)
            {
                model = new BLL.MemberBase().getMemberInfo((CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID);
                var tjlist = _productRecommendDetail.GetTop4List(" order by prt_id desc");
                models.dt = tjlist;
                models.Minfo = model;
                ViewData["proviceid"] = model.m_Provice;
                if (model.m_Provice != null)
                {
                    ViewData["provicename"] = regbll.GetModelByCode((int)model.m_Provice).reg_Name;
                }
                else
                    ViewData["provicename"] = "选择省";
                ViewData["cityid"] = model.m_City;
                if (model.m_City != null)
                {
                    ViewData["cityname"] = regbll.GetModelByCode((int)model.m_City).reg_Name;
                }
                else
                    ViewData["cityname"] = "选择市";
                ViewData["xianid"] = model.m_Count;
                if (model.m_Count != null)
                {
                    ViewData["xianname"] = regbll.GetModelByCode((int)model.m_Count).reg_Name;
                }
                else
                    ViewData["xianname"] = "选择区/县";
            }
            else
            {
                Response.Redirect("/logon/logon");
            }
            return View(models);
        }

    }
}
