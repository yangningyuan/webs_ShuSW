using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using webs_YueyxShop.Model;
using Common;

namespace webs_YueyxShop.Web.Controllers.YueyXing
{
    public class ProListController : MasterPageController
    {
        //
        // GET: /ProDetails/

        private BLL.Adert adertbll = new BLL.Adert();
        int gifCount;//商品总数量
        double pagecountnum;//总页数
        int pCount;
        int pagenum = 1;//当前页
        int pagegif = 28;//每页显示的商品数
        int typeid = 3;//类别ID
        BLL.BrandBase bbll = new BLL.BrandBase();
        BLL.ProductBase pbll = new BLL.ProductBase();
        BLL.ProductTypeBase ptbll = new BLL.ProductTypeBase();

        public ActionResult ProList()
        {
            string type = Request.QueryString["type"] == null ? "ProList" : Request.QueryString["type"].ToString();
            if (type == "ProList" || string.IsNullOrEmpty(type) || type == "undefined")
            {
                int pagerows = 12;
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
                        where += "and sku_Price>=5000" + " and p_id not in(select p_id from skubase where sku_id in(select sku_id from GroupPurchaseBase where gp_pPric<5000 and sku_ID in(select  sku_ID from skubase where p_ID in( select p_ID from ProductRecommendDetail where prt_ID=1 and prd_Status=0 and prd_IsDelete=0))))";
                    else
                    {
                        string[] prilist = price.Split('-');
                        where += " and sku_Price>=" + prilist[0] + " and sku_Price<=" + prilist[1] + " and p_id not in(select p_id from skubase where sku_id in(select sku_id from GroupPurchaseBase where gp_pPric<" + prilist[0] + " or gp_pPric>" + prilist[1] + " and sku_ID in(select  sku_ID from skubase where p_ID in( select p_ID from ProductRecommendDetail where prt_ID=1 and prd_Status=0 and prd_IsDelete=0))))";
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
                model.ptlist = ptbll.GetModelList(" pt_parentId=" + typeid+" and pt_Isdel=0 and pt_statusCode=0");
                model.vmpinfolist = new BLL.vw_PInfo().GetModelList(" p_IsDel=0 " + where, int.Parse(page), pagerows, sortby);
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
        [HttpPost]
        public string GetTypeName()
        {
            int typeid = 0;
            string html = "";
            if (!string.IsNullOrEmpty(RequestBase.GetString("type")))
            {
                typeid = int.Parse(RequestBase.GetString("type").ToString());
            }
            Model.ProductTypeBase ptmodel = ptbll.GetModel(typeid);
            List<Model.ProductTypeBase> zmodel;
            List<Model.ProductTypeBase> xmodel;
            if (ptmodel.pt_Layer == 1)//大类
            {
                html = " > <a href=\"/ProList/ProList?ptype=" + ptmodel.pt_ID + "\" target=\"_blank\" class=\"hovers\">" + ptmodel.pt_Name + "</a>";
            }
            else if (ptmodel.pt_Layer == 2)
            {
                zmodel = ptbll.GetModelList(" pt_ID=(select pt_ParentId from ProductTypeBase where pt_ID=" + typeid + ")");
                html = " > <a href=\"/ProList/ProList?ptype=" + zmodel[0].pt_ID + "\" target=\"_blank\" class=\"hovers\">" + zmodel[0].pt_Name + "</a>  ><a href=\"/ProList/ProList?ptype=" + ptmodel.pt_ID + "\" target=\"_blank\" class=\"hovers\">" + ptmodel.pt_Name + "</a>";
            }
            //else if (ptmodel.pt_Layer == 3)
            //{
            //    zmodel = ptbll.GetModelList(" pt_ID=(select pt_ParentId from ProductTypeBase where pt_ID=" + typeid + ")");
            //    xmodel = ptbll.GetModelList(" pt_ID=(select pt_ParentId from ProductTypeBase where pt_ID=(select pt_ParentId from ProductTypeBase where pt_ID=" + typeid + "))");
            //    html = " > <a href=\"/ProList/ProList?ptype=" + xmodel[0].pt_ID + "\" target=\"_blank\" class=\"hovers\">" + xmodel[0].pt_Name + "</a> > <a href=\"/ProList/ProList?ptype=" + zmodel[0].pt_ID + "\" target=\"_blank\" class=\"hovers\">" + zmodel[0].pt_Name + "</a> > <a href=\"/ProList/ProList?ptype=" + ptmodel.pt_ID + "\" target=\"_blank\" class=\"hovers\">" + ptmodel.pt_Name + "</a>";
            //}
            return html;
        }

        public ActionResult ProTuiList()
        {
            string type = Request.QueryString["type"] == null ? "ProTuiList" : Request.QueryString["type"].ToString();
            if (type == "ProTuiList" || string.IsNullOrEmpty(type) || type == "undefined")
            {
                int pagerows = 4;
                string where = "";
                string sortby = "";
                //页数
                string page = Request.QueryString["page"] == null ? "1" : Request.QueryString["page"].ToString();
                //推荐
                string tui = Request.QueryString["tui"] == null ? "" : Request.QueryString["tui"].ToString();
                //分类ID
                string ptid = Request.QueryString["ptype"] == null ? "" : Request.QueryString["ptype"].ToString();
                //查询条件
                string condition = Request.QueryString["condition"] == null ? "" : Request.QueryString["condition"].ToString();
                //价格
                string price = Request.QueryString["price"] == null ? "" : Request.QueryString["price"].ToString();
                //品牌
                string brand = Request.QueryString["brand"] == null ? "" : Request.QueryString["brand"].ToString();
                //排序
                string sort = Request.QueryString["sort"] == null ? "" : Request.QueryString["sort"].ToString();
                //存在推荐分类
                if (!string.IsNullOrEmpty(tui) && tui != "undefined")
                {
                    where += " and p_ID in (select p_ID from ProductRecommendDetail where prt_ID=" + tui + " and prd_Status=0 and prd_IsDelete=0)   ";
                }
                else
                {
                    string strptCon = "";
                    if (!string.IsNullOrWhiteSpace(ptid) && ptid != "undefined")
                    {
                        ptid = HttpUtility.UrlDecode(ptid);
                        var proType = new BLL.ProductTypeBase().GetModelList(" pt_IsDel = 0 and pt_StatusCode = 0 and pt_Name = '" + ptid +"'").FirstOrDefault();
                        if (proType != null)
                        {
                            strptCon = " and pt_ID=" + proType.pt_ID;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(condition) && condition != "undefined")
                    {
                        condition = HttpUtility.UrlDecode(condition);
                        where += " and p_ID in (select p_ID from ProductBase where p_Name like '%[" + condition + "]%' and p_SellStatus=1 and p_IsDel=0 and p_StatusCode=0 " + strptCon + ")    ";
                    }
                }
                //存在分类
                if (!string.IsNullOrEmpty(ptid) && ptid != "undefined")
                {
                    where += " and pt_ID=" + ptid;
                }
                //存在品牌
                if (!string.IsNullOrEmpty(brand) && brand != "undefined")
                {
                    where += " and b_id=" + brand;
                }
                //价格
                if (!string.IsNullOrEmpty(price) && price != "undefined")
                {
                    if (price == "5000以上")
                        where += "and sku_Price>=5000" + " and p_id not in(select p_id from skubase where sku_id in(select sku_id from GroupPurchaseBase where gp_pPric<5000 and sku_ID in(select  sku_ID from skubase where p_ID in( select p_ID from ProductRecommendDetail where prt_ID=1 and prd_Status=0 and prd_IsDelete=0))))";
                    else
                    {
                        string[] prilist = price.Split('-');
                        where += " and sku_Price>=" + prilist[0] + " and sku_Price<=" + prilist[1] + " and p_id not in(select p_id from skubase where sku_id in(select sku_id from GroupPurchaseBase where gp_pPric<" + prilist[0] + " or gp_pPric>"+prilist[1] +" and sku_ID in(select  sku_ID from skubase where p_ID in( select p_ID from ProductRecommendDetail where prt_ID=1 and prd_Status=0 and prd_IsDelete=0))))";
                    }
                }
                //排序
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
                    model.blist = bbll.GetModelList("  b_IsDel=0 and b_StatusCode=0 and b_ID in(select b_ID from ProductTypeBrandBase where pt_ID in(select pt_ID from productbase where p_ID in(select p_ID from ProductRecommendDetail where prt_ID=" + tui + " and prd_IsDelete=0 and prd_Status=0)))");
                    model.ptlist = ptbll.GetModelList(" pt_IsDel=0 and pt_StatusCode=0 and pt_ID in(select pt_ID from productbase where p_ID in(select p_ID from ProductRecommendDetail where prt_ID=" + tui + "  and prd_IsDelete=0 and prd_Status=0))");
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

        //热门推荐
        public ActionResult Partialremaituijian()
        {
            List<Model.ProductBase> pinfo = pbll.GetpInfoByRecommendTypeId(1);
            return View(pinfo.ToList());
        }

        //看过此页面用户最终购买
        public ActionResult Zuizhonggoumai()
        {
            List<Model.ProductBase> pinfo = pbll.GetpInfoByRecommendTypeId(7);
            return View(pinfo.ToList());

        }

        //广告
        public ActionResult getguanggao()
        {

            return View();
        }



    }
}