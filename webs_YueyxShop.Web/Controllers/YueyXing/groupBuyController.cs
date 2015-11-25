using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Common;
using webs_YueyxShop.Model;


namespace webs_YueyxShop.Web.Controllers.YueyXing
{
    
    public class groupBuyController : MasterPageController
    {
        //
        // GET: /groupBuy/

        BLL.ProductBase pbll = new BLL.ProductBase();
        public ActionResult Index()
        {
            string type = Request.QueryString["type"] == null ? "groupBuy" : Request.QueryString["type"].ToString();
            if (type == "groupBuy" || string.IsNullOrEmpty(type) || type == "undefined")
            {
                string ptype = Request.QueryString["ptype"] == null ? "" : Request.QueryString["ptype"].ToString();
                string price = Request.QueryString["price"] == null ? "" : Request.QueryString["price"].ToString();
                string brand = Request.QueryString["brand"] == null ? "" : Request.QueryString["brand"].ToString();
                string where = "";
                if (!string.IsNullOrEmpty(ptype) && ptype != "undefined")
                    where += " and pt_id="+ptype;
                if (!string.IsNullOrEmpty(brand) && brand != "undefined")
                    where += " and b_id=" + brand;
                if (!string.IsNullOrEmpty(price) && price != "undefined")
                {
                    if (price == "5000以上")
                        where += "and gp_ppric>5000";
                    else
                    {
                        string[] prilist = price.Split('-');
                        
                        where += " and gp_ppric>="+prilist[0]+" and gp_ppric<="+prilist[1];
                    }

                }
                var model = new ListModel();
                model.blist = new BLL.BrandBase().GetModelList(" b_isdel=0 and b_statuscode=0");
                model.ptlist = new BLL.ProductTypeBase().GetModelList(" pt_isdel=0 and pt_statuscode=0");
                DateTime thistime = DateTime.Now;
                model.vmgblist = new BLL.vm_GBDetails().GetModelList(" p_IsDel=0 and p_StatusCode=0 and gp_IsDel=0 and gp_pCount-gp_SaleCount>0 and gp_StatusCode=0 and p_SellStatus=1 and gp_endtime>'" + thistime + "' " + where);
                model.path = "团购";

                return View(model);
            }
            else
                return View();
        }
        public ActionResult groupDetails()
        {
            return View();
        }

        public ActionResult groupBuyDetails()
        {
            string gpid = Request.QueryString["gpid"] == null ? "" : Request.QueryString["gpid"].ToString();
            Model.vm_GBDetails model = new BLL.vm_GBDetails().GetModel(int.Parse(gpid));
            List<Model.ProductInfoBase> list = new BLL.ProductInfoBase().GetModelList(" pin_isdel=0 and pin_statuscode=0 and p_ID="+model.p_ID);
            List<Model.Adert> adlist = new BLL.Adert().GetModelList(string.Format(" a_PID=27 and a_Delete=0 and  a_spare2=(select pt_parentid from ProductTypeBase where pt_ID = (select pt_ParentId from ProductTypeBase where pt_ID={0})) ", model.pt_ID));
            var modellist = new ListModel();
            //System.Web.HttpContext.Current.Application.Lock();
            //System.Web.HttpContext.Current.Application["UserCount"] = Int32.Parse(System.Web.HttpContext.Current.Application["UserCount"].ToString()) + 1;
            //System.Web.HttpContext.Current.Application.UnLock();
            modellist.path = "<a href=\"/groupBuy/index\"><strong>团购列表</strong></a> > "+model.p_Name;
            modellist.pinfoList = list;
            modellist.gbmodel = model;
            modellist.adlist = adlist;

            List<Model.vw_PInfo> pinfo = new BLL.vw_PInfo().getguanzhu(" sku_ID in(select distinct sku_ID  from VipCollectionBase)", 1, 5);
            ViewBag.pinfo = pinfo.ToList();
            List<Model.vw_PInfo> pinfo2 = new BLL.vw_PInfo().getguanzhu(" sku_ID in(select distinct sku_ID  from VipCollectionBase)", 2, 5);
            ViewBag.pinfo2 = pinfo2.ToList();
            return View(modellist);
        }
        [HttpPost]
        public string insertintoCart()
        {
            int pid = 0;
            int count = 0;
            int result = 0;
            bool result2 = false;
            string mm = "";
            decimal pric=0;
            if (!string.IsNullOrEmpty(RequestBase.GetString("skuid")))
            {
                pid = int.Parse(RequestBase.GetString("skuid").ToString());
            }

            if (!string.IsNullOrEmpty(RequestBase.GetString("pric")))
            {
                pric = decimal.Parse(RequestBase.GetString("pric").ToString());
            }

            if (!string.IsNullOrEmpty(RequestBase.GetString("count")))
            {
                count = int.Parse(RequestBase.GetString("count").ToString());
            }
            if (Request.Cookies["UserInfo"] != null)
            {
                int mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
                Model.ShoppingCartBase scmodel = new ShoppingCartBase();

                var model = new ListModel();
                model.vmgblist = new BLL.vm_GBDetails().GetModelList(" gp_isdel=0 and gp_statuscode=0  and sku_id=" + pid + " and gp_pCount-gp_SaleCount>0");
                if (model.vmgblist.Count > 0)
                {
                    var sclist = new BLL.ShoppingCartBase().GetModelList(" m_ID=" + mid + " and sku_ID=" + model.vmgblist[0].sku_ID + " and sc_IsDel=0 and sc_IsGP=1");
                    if (sclist.Count > 0)
                    {
                        Model.ShoppingCartBase upmodel = new BLL.ShoppingCartBase().GetModel(sclist[0].sc_ID);
                        //改数量
                        upmodel.sc_pCount += count;
                        upmodel.sc_pPric = pric;
                        upmodel.sc_CreateOn = DateTime.Now;
                        upmodel.sc_IsGP = true;
                        result2 = new BLL.ShoppingCartBase().Update(upmodel);

                    }
                    else
                    {
                        //添加
                        scmodel.m_ID = mid;
                        scmodel.sc_pCount = count;
                        scmodel.sc_pPric = pric;
                        scmodel.sc_CreateOn = DateTime.Now;
                        scmodel.sku_ID = pid;
                        scmodel.sc_IsGP = true;
                        result = new BLL.ShoppingCartBase().Add(scmodel);
                    }
                    if (result > 0 || result2)
                    {
                        int? pcount = 0;
                        decimal? ppric;
                        decimal pricecount = 0;
                        int? allpcount = 0;
                        var scalllist = new BLL.ShoppingCartBase().GetModelList("  m_ID=" + mid + " and sc_IsDel=0");
                        //ViewData["pcount"] = sclist.Count;
                        foreach (var item in scalllist)
                        {
                            pcount = item.sc_pCount;
                            ppric = item.sc_pPric;
                            pricecount += decimal.Parse(((double)pcount * (double)ppric).ToString());
                            allpcount += pcount;
                        }
                        string html = "<div class=\"modal\" id=\"chart-modal\"><a class=\"close\"   id=\"close\" onclick=\"closeit()\">X</a><div class=\"yes-chart\"><div class=\"yes-icon alignleft\"></div><div class=\"chart-font alignright\"><dl><dt><strong>添加成功！</strong></dt><dd>购物车共有<span> " + allpcount + "</span>件商品，商品总价：<span>¥ " + pricecount + " </span></dd></dl><div class=\"clear\"></div><a class=\"total-chart\" href=\"/Chart/Chart\">去购物车结算 ></a><a class=\"go-shop\" href=\"javascript:void(0)\" id=\"keepshopping\" onclick=\"closeit()\">继续购物</a></div><!--chart-font end--></div>";
                        return html;
                    }
                    else
                    {
                        mm = "fail";
                        return mm;
                    }
                }
                else
                {
                    string html = "<div class=\"modal\" id=\"chart-modal\"><a class=\"close\"   id=\"close\" onclick=\"closeit()\">X</a><div class=\"yes-chart\"><div class=\"no-icon alignleft\"></div><div class=\"chart-font alignright\"><dl><dt><strong>该款团购已被抢光啦，下次记得早点来哦！</strong></dt></dl><div class=\"clear\"></div><a class=\"total-chart\" href=\"/Chart/Chart\">去购物车结算 ></a><a class=\"go-shop\" href=\"javascript:void(0)\" id=\"keepshopping\" onclick=\"closeit()\">继续购物</a></div><!--chart-font end--></div>";
                    return html;
                }
            }
            else
            {
                mm = "nologon";

                return mm;
            }
        }

    }
}


