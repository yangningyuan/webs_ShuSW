using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace webs_YueyxShop.Web.Controllers.YueyXing
{
    public class HelpCenterController : MasterPageController
    {
        //
        public ActionResult Index()
        {
            if (!string.IsNullOrWhiteSpace(RequestBase.GetString("id")))
            {
                ViewData["nid"] = RequestBase.GetString("id");
            }
            GetMenu();
            return View();
        }

        public void GetMenu()
        {
            //GetNewsBase("Link", "eb9595fa-89cd-4815-8f7c-fa563db7f5bc", false);//友情链接
            GetNewsBase("mHelper", "b2092e66-6d92-449d-b32c-b84047f5a64f", false);//新手入门
            GetNewsBase("mAboutUs", "a7e89dd5-281d-403f-a9b1-a45b5574b4c8", false);//关于我们
            GetNewsBase("mShipType", "7f4659b5-9161-4f63-8cb5-c6960b6f7b1b", false);//配送方式
            GetNewsBase("mPaymentType", "2907dd64-7cc1-4ef2-b0b1-244144342403", false);//支付方式
            GetNewsBase("mService", "d09e52e5-d884-4c0e-9039-3371f1347fa7", false);//售后服务
            GetNewsBase("mCharacteristicService", "fb9f0894-952c-4df7-b857-fe9fb9341fe6", false);//特色服务
        }

        public Model.NewsBase GetArticle(string id)
        {
            int nid = 0;
            if (int.TryParse(id, out nid))
            {
                BLL.NewsBase _newsBase = new BLL.NewsBase();
                var model = _newsBase.GetModel(nid);
                return model;
            }

            return null;
        }


        public ActionResult Detial()
        {
            Model.NewsBase newsBase = null;
            if (!string.IsNullOrWhiteSpace(RequestBase.GetString("id")))
            {
                newsBase = GetArticle(RequestBase.GetString("id"));
            }
            return View(newsBase);
        }
    }
}