using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace webs_YueyxShop.Web.Controllers.YueyXing
{
    public class NewsController : MasterPageController
    {
        public ActionResult newsList()
        {

            GetNewsBase("newsList", "983c6027-3bb7-4be2-a30a-f7553eb390a2 ", false);//新闻中心

            return View();
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

        public ActionResult newsDetails()
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