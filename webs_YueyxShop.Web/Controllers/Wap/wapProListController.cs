using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using webs_YueyxShop.Model;
using Common;

namespace webs_YueyxShop.Web.Controllers.Wap
{
    public class wapProListController : BaseWapController
    {
        //
        // GET: /ProDetails/

        private BLL.Adert adertbll = new BLL.Adert();
        int gifCount;//商品总数量
        double pagecountnum;//总页数
        int pCount;
        int pagenum = 1;//当前页
        int pagegif = 1;//每页显示的商品数
        int typeid = 3;//类别ID
        BLL.BrandBase bbll = new BLL.BrandBase();
        BLL.ProductBase pbll = new BLL.ProductBase();
        BLL.ProductTypeBase ptbll = new BLL.ProductTypeBase();


        //手机
        public ActionResult wapProList()
        {
            string type = Request.QueryString["type"] == null ? "ProList" : Request.QueryString["type"].ToString();
            if (type == "ProList" || string.IsNullOrEmpty(type) || type == "undefined")
            {
                int pagerows =4;
                string where = "";
                string sortby = "";
                string page = Request.QueryString["page"] == null ? "1" : Request.QueryString["page"].ToString();
                string ptype = Request.QueryString["ptype"] == null ? "" : Request.QueryString["ptype"].ToString();
                int typeid = int.Parse(ptype);//类别ID
                string tui = Request.QueryString["tui"] == null ? "" : Request.QueryString["tui"].ToString();
                string price = Request.QueryString["price"] == null ? "" : Request.QueryString["price"].ToString();
                string brand = Request.QueryString["brand"] == null ? "" : Request.QueryString["brand"].ToString();
                string sort = Request.QueryString["sort"] == null ? "" : Request.QueryString["sort"].ToString();
                string typeidd = ptype;//需进行类别判断
                Model.ProductTypeBase ptmodel = ptbll.GetModel(int.Parse(typeidd));
                if (ptmodel.pt_Layer == 1)//大类
                {
                    where += " and pt_ID in(select pt_ID  from ProductTypeBase where pt_ParentId =" + ptype + ")";
                }
                else if (ptmodel.pt_Layer == 2)
                {
                    where += " and pt_id=" + ptype;
                }
                ViewData["type"] = ptype;
                //else if (ptmodel.pt_Layer == 3)
                //{
                //    where += " and pt_id=" + ptype;
                //}
                ////string ptype = " and pt_id=" + ptype;//需进行类别判断

                if (!string.IsNullOrEmpty(brand) && brand != "undefined")
                    where += " and b_id=" + brand;
                if (!string.IsNullOrEmpty(price) && price != "undefined")
                {
                    if (price == "5000以上")
                        where += "and sku_Price>5000";
                    else
                    {
                        string[] prilist = price.Split('-');
                        where += " and sku_Price>=" + prilist[0] + " and sku_Price<=" + prilist[1];
                    }
                }
                if (!string.IsNullOrEmpty(sort) && sort != "undefined")
                {
                    if (sort == "sku")
                        sortby = " order by sku_ID desc";
                    if (sort == "xliang")
                        sortby = " order by sku_SalesCount desc ";
                    if (sort == "spric")
                        sortby = " order by sku_Price desc";
                    if (sort == "pinglun")
                        sortby = " order by pinglun desc";
                    if (sort == "selltime")
                        sortby = " order by p_ModifyOn desc";
                }
                var model = new ListModel();
                model.blist = bbll.GetbrandByTypeId(typeid);
                model.ptlist = ptbll.GetModelList(" pt_parentId=" + typeid + " and pt_Isdel=0 and pt_statusCode=0");
                model.vmpinfolist = new BLL.vw_PInfo().GetModelList(" p_IsDel=0" + where, int.Parse(page), pagerows, sortby);
                List<Model.vw_PInfo> list = new BLL.vw_PInfo().GetModelList(" p_IsDel=0" + where);
                model.proattr = new BLL.ProductAttributesBase().GetModelList("  pa_IsDel=0 and pa_StatusCode=0 and pa_Type=1 ");

                ViewData["count"] = list.Count;
                ViewData["pagerows"] = pagerows;
                ViewData["page"] = page;
                ViewData["pagecount"] = Math.Ceiling((double)list.Count / (double)pagerows);
                ViewData["typename"] = new BLL.ProductTypeBase().GetModel(int.Parse(typeidd)).pt_Name;
                var cpt = adertbll.GetModelList(" a_PID=28 and a_spare2=3 and a_Delete=0 ");
                ViewBag.GuangGao = cpt.ToList();
                return View(model);
            }
            else
                return View();
        }

        public ActionResult wapProTuiList()
        {
            string type = Request.QueryString["type"] == null ? "ProTuiList" : Request.QueryString["type"].ToString();
            if (type == "ProTuiList" || string.IsNullOrEmpty(type) || type == "undefined")
            {
                int pagerows = 4;
                string where = "";
                string sortby = "";
                string page = Request.QueryString["page"] == null ? "1" : Request.QueryString["page"].ToString();
                string tui = Request.QueryString["tui"] == null ? "" : Request.QueryString["tui"].ToString();
                string price = Request.QueryString["price"] == null ? "" : Request.QueryString["price"].ToString();
                string brand = Request.QueryString["brand"] == null ? "" : Request.QueryString["brand"].ToString();
                string sort = Request.QueryString["sort"] == null ? "" : Request.QueryString["sort"].ToString();
                //分类ID
                string ptid = Request.QueryString["ptid"] == null ? "" : Request.QueryString["ptid"].ToString();
                //查询条件
                string condition = Request.QueryString["condition"] == null ? "" : Request.QueryString["condition"].ToString();

                if (!string.IsNullOrEmpty(tui) && tui != "undefined")
                {
                    where += " and p_ID in (select p_ID from ProductRecommendDetail where prt_ID=" + tui + " and prd_Status=0 and prd_IsDelete=0)  and sku_ismoren=1";
                }
                else
                {
                    string strptCon = "";
                    if (!string.IsNullOrWhiteSpace(ptid) && ptid != "undefined")
                    {
                        ptid = HttpUtility.UrlDecode(ptid);
                        var proType = new BLL.ProductTypeBase().GetModelList(" pt_IsDel = 0 and pt_StatusCode = 0 and pt_Name = '" + ptid + "'").FirstOrDefault();
                        if (proType != null)
                        {
                            strptCon = " and pt_ID=" + proType.pt_ID;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(condition) && condition != "undefined")
                    {
                        condition = HttpUtility.UrlDecode(condition);
                        where += " and p_ID in (select p_ID from ProductBase where p_Name like '%[" + condition + "]%' and p_SellStatus=1 and p_IsDel=0 and p_StatusCode=0 " + strptCon + ")  and sku_ismoren=1";
                    }
                }
                if (!string.IsNullOrEmpty(brand) && brand != "undefined")
                    where += " and b_id=" + brand;
                if (!string.IsNullOrEmpty(price) && price != "undefined")
                {
                    if (price == "5000以上")
                        where += "and sku_Price>5000";
                    else
                    {
                        string[] prilist = price.Split('-');
                        where += " and sku_Price>=" + prilist[0] + " and sku_Price<=" + prilist[1];
                    }
                }
                if (!string.IsNullOrEmpty(sort) && sort != "undefined")
                {
                    if (sort == "sku")
                        sortby = " order by sku_ID desc";
                    if (sort == "xliang")
                        sortby = " order by sku_SalesCount desc ";
                    if (sort == "spric")
                        sortby = " order by sku_Price desc";
                    if (sort == "pinglun")
                        sortby = " order by pinglun desc";
                    if (sort == "selltime")
                        sortby = " order by p_ModifyOn desc";
                }
                var model = new ListModel();
                if (!string.IsNullOrWhiteSpace(tui) && tui != "undefined")
                {
                    model.blist = bbll.GetModelList("  b_IsDel=0 and b_StatusCode=0 and b_ID in(select b_ID from ProductTypeBrandBase where pt_ID in(select pt_ID from productbase where p_ID in(select p_ID from ProductRecommendDetail where prt_ID=" + tui + ")))");
                    model.ptlist = ptbll.GetModelList(" pt_IsDel=0 and pt_StatusCode=0 and pt_ID in(select pt_ID from productbase where p_ID in(select p_ID from ProductRecommendDetail where prt_ID=" + tui + "))");
                    ViewData["typename"] = new BLL.ProductRecommendTypeBase().GetModel(int.Parse(tui)).prt_Name;
                }
                else
                {
                    model.blist = new List<BrandBase>();
                    model.ptlist = new List<ProductTypeBase>();
                    ViewData["typename"] = "";
                }
                model.vmpinfolist = new BLL.vw_PInfo().GetModelList(" p_IsDel=0 and p_StatusCode=0 and p_SellStatus=1   " + where, int.Parse(page), pagerows, sortby);
                List<Model.vw_PInfo> list = new BLL.vw_PInfo().GetModelList(" p_IsDel=0 and p_SellStatus=1 and p_StatusCode=0   " + where);

                ViewData["count"] = list.Count;
                ViewData["pagerows"] = pagerows;
                ViewData["page"] = page;
                ViewData["pagecount"] = Math.Ceiling((double)list.Count / (double)pagerows);
                return View(model);

            }
            else
                return View();
        }

    }
}