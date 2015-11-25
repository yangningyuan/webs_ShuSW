using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace webs_YueyxShop.Web.Controllers.Wap
{
    public class wapgroupBuyController : BaseWapController
    {
        //
        // GET: /wapgroupBuy/

        public ActionResult groupBuy()
        {

            string type = Request.QueryString["type"] == null ? "groupBuy" : Request.QueryString["type"].ToString();
            if (type == "groupBuy" || string.IsNullOrEmpty(type) || type == "undefined")
            {
                int pagerows = 2;
                string page = Request.QueryString["page"] == null ? "1" : Request.QueryString["page"].ToString();
                string ptype = Request.QueryString["ptype"] == null ? "" : Request.QueryString["ptype"].ToString();
                string price = Request.QueryString["price"] == null ? "" : Request.QueryString["price"].ToString();
                string brand = Request.QueryString["brand"] == null ? "" : Request.QueryString["brand"].ToString();
                string where = "";
                if (!string.IsNullOrEmpty(ptype) && ptype != "undefined")
                    where += " and pt_id=" + ptype;
                if (!string.IsNullOrEmpty(brand) && brand != "undefined")
                    where += " and b_id=" + brand;
                if (!string.IsNullOrEmpty(price) && price != "undefined")
                {
                    if (price == "5000以上")
                        where += "and gp_ppric>5000";
                    else
                    {
                        string[] prilist = price.Split('-');

                        where += " and gp_ppric>=" + prilist[0] + " and gp_ppric<=" + prilist[1];
                    }

                }
                var model = new ListModel();
                model.blist = new BLL.BrandBase().GetModelList(" b_isdel=0 and b_statuscode=0");
                model.ptlist = new BLL.ProductTypeBase().GetModelList(" pt_IsDel=0 and pt_StatusCode=0");
                DateTime thistime = DateTime.Now;
                model.vmgblist = new BLL.vm_GBDetails().GetModelList(" p_IsDel=0 and p_StatusCode=0 and gp_IsDel=0 and gp_pCount-gp_SaleCount>0 and gp_StatusCode=0 and p_SellStatus=1 and gp_endtime>'" + thistime + "' " + where);
                model.vmgblistpage = new BLL.vm_GBDetails().GetModelList(" p_IsDel=0 and p_StatusCode=0 and gp_IsDel=0 and gp_pCount-gp_SaleCount>0 and gp_StatusCode=0 and p_SellStatus=1 and gp_endtime>'" + thistime + "' " + where, int.Parse(page), pagerows);
                model.path = "团购";
                ViewData["count"] = model.vmgblist.Count;
                ViewData["pagerows"] = pagerows;
                ViewData["page"] = page;
                ViewData["pagecount"] = Math.Ceiling((double)model.vmgblist.Count / (double)pagerows);

                return View(model);
            }
            else
                return View();
        }

    }
}
