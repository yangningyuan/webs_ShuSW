using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Models;
namespace webs_YueyxShop.Web.Controllers.ShuSW
{
    public class sswCommodityController : Controller
    {
        public ActionResult Commodity() 
        {
            ViewBag.Title = "商品列表-书生网";
            //商品导航
            StringBuilder sb = new StringBuilder();
            DataTable dtptb1 = new BLL.ProductTypeBase().GetList(" pt_Layer=1 and pt_StatusCode=0 and pt_IsDel=0 order by pt_Sort asc").Tables[0];//一级商品类型

            if (dtptb1.Rows.Count > 0) 
            {
                for (int i = 0; i < dtptb1.Rows.Count; i++)
                {
                    sb.Append("<dt class=\"odd\">" + dtptb1.Rows[i]["pt_Name"] + "</dt>");
                    DataTable dtptb2 = new BLL.ProductTypeBase().GetList(" pt_Layer=2 and pt_StatusCode=0 and pt_IsDel=0  and pt_ParentId="+dtptb1.Rows[i]["pt_ID"]+" order by pt_Sort asc").Tables[0];//二级商品类型
                    if (dtptb2.Rows.Count > 0) 
                    {
                        sb.Append("<dd class=\"odd\">");
                        sb.Append("<ol>");
                        for (int n = 0; n < dtptb2.Rows.Count; n++)
                        {
                            sb.Append("<li>");
                            sb.Append("<a href='/sswCommodity/Commodity?pt_id="+dtptb2.Rows[n]["pt_ID"]+"'><span class=\"price1\">"+dtptb2.Rows[n]["pt_Name"]+"</span></a>("+dtptb2.Rows.Count+")");
                            sb.Append("</li>");
                        }
                        sb.Append("</ol>");
                        sb.Append("</dd>");
                    }
                    ViewBag.CommodityTitle = sb.ToString();
                }
            }

            
            string ptb_id = Request.QueryString["pt_id"] == null ? "0" : Request.QueryString["pt_id"].ToString();
            string brand_id = Request.QueryString["b_id"] == null ? "0" : Request.QueryString["b_id"].ToString();
            DataTable dtmztm=null;
            if (ptb_id != "0")
            {
                dtmztm = new webs_YueyxShop.BLL.SKUBase().GetDefaultSKUDetial(" and pt_ID=" + ptb_id + "  and pi_type=0 and pt_IsDel=0 and pt_StatusCode=0 and b_IsDel=0 and sku_IsDel=0 and sku_StatusCode=0 and pi_StatusCode=0 and pi_IsDel=0 and p_IsDel=0 and p_StatusCode=0");
            }
            else if(brand_id!="0") {
                dtmztm = new webs_YueyxShop.BLL.SKUBase().GetDefaultSKUDetial(" and b_ID=" + brand_id + "  and pi_type=0 and pt_IsDel=0 and pt_StatusCode=0 and b_IsDel=0 and sku_IsDel=0 and sku_StatusCode=0 and pi_StatusCode=0 and pi_IsDel=0 and p_IsDel=0 and p_StatusCode=0");
            }
            else
            {
                dtmztm = new webs_YueyxShop.BLL.SKUBase().GetDefaultSKUDetial("  and pi_type=0 and pt_IsDel=0 and pt_StatusCode=0 and b_IsDel=0 and sku_IsDel=0 and sku_StatusCode=0 and pi_StatusCode=0 and pi_IsDel=0 and p_IsDel=0 and p_StatusCode=0");
            }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
            //得到全部商品列表

            ViewData["pcCommodityList"] = dtmztm;
            //List<Model.SKUBase> list= new webs_YueyxShop.BLL.SKUBase().DataTableToList(dtmztm);
            //int total = 0;//总行数
            //int pageSize = 300;//每页25行
            //int pageNumber = 1;//当前页

            
            
            
            
            //var skucc= new BLL.SKUBase().GetModelList(" sku_StatusCode=0 and sku_IsDel=0 ");
            //total = skucc.Count();

            //this.ViewData["TotalCount"] = total.ToString();
            //this.ViewData["NumberPage"] = pageSize.ToString();
            //this.ViewData["PagenumShown"] = "10";
            //this.ViewData["CurrentPage"] = pageNumber.ToString();

            //return View(skucc.ToPagedList(pageNumber, pageSize));

            return View();
        }

        /// <summary>
        /// 促销商品推荐
        /// </summary>
        private void cuixiao()
        {
            System.Data.DataTable dtcuxiao = new webs_YueyxShop.BLL.SKUBase().GetDefaultSKUDetial(" and p_id in( select p_ID from ProductRecommendDetail where prt_ID=7 ) and pi_type=1 and pt_IsDel=0 and pt_StatusCode=0 and b_IsDel=0 and sku_IsDel=0 and sku_StatusCode=0 and pi_StatusCode=0 and pi_IsDel=0 and p_IsDel=0 and p_StatusCode=0");
            ViewData["pc首页促销"] = dtcuxiao;
        }
        /// <summary>
        /// 详细商品页
        /// </summary>
        /// <returns></returns>
        public ActionResult CommodityDetails() 
        {

            cuixiao();

             string pid=Request.QueryString["p_id"]==null?"0":Request.QueryString["p_id"].ToString();
             ViewData["p_id"] = pid;

             dataWork dw = new dataWork();//相似产品
             DataTable dtxssp = dw.GetTab(string.Format("select top(5) pi_Url,skubase.p_ID,p_Name from ProductImgBase,SKUBase,ProductBase where ProductBase.p_IsDel=0 and ProductBase.p_StatusCode=0 and ProductBase.p_ID=SKUBase.p_ID and  ProductImgBase.sku_ID=SKUBase.sku_ID and  pi_type=1 and pi_StatusCode=0 and pi_isDel=0 and ProductImgBase.sku_ID in(select sku_ID  from SKUBase where sku_IsDel=0 and sku_StatusCode=0 and p_ID in(select p_ID from ProductBase where p_isdel=0 and pt_id in(select pt_id from ProductTypeBase where pt_parentid in(select pt_parentid from ProductTypeBase where pt_id=( select pt_id from productbase where p_ID={0}))))) ", pid));
             
           
             ViewData["相似商品"] = dtxssp;



            if(pid=="0")
            {
                return View("~/ErrorPage/Error404");
            }else
            {
                ListModel model = new ListModel();

                List<Model.SKUBase> list = new BLL.SKUBase().GetModelList("  p_id=" + pid + " and sku_StatusCode=0 and sku_IsDel=0");

                //model.productinfo = new BLL.ProductInfoBase().GetModelList(" and pin_StatusCode=0 and pin_IsDel=0 and p_ID= "+pid);
                model.vmpinfolist = new BLL.vw_PInfo().GetModelList(" p_IsDel=0 and p_StatusCode=0 and p_SellStatus=1  and sku_ID= " + list[0].sku_ID);//商品信息

                if (model.vmpinfolist.Count > 0) 
                {
                   ViewBag.Title=model.vmpinfolist[0].p_Name+"-书生网";
                }
                else
                {
                    ViewBag.Title = "商品详细信息-书生网";
                }

                ViewData["ifcmys"]="0";//尺码颜色0：不显示1：显示

                if (model.vmpinfolist.Count > 0)
                {
                    if (model.vmpinfolist[0].pt_ParentId == 488 || model.vmpinfolist[0].pt_ParentId == 489) //男鞋或女鞋的话显示尺码颜色
                    {
                        ViewData["ifcmys"] = "1";
                    }
                    else
                    {
                        ViewData["ifcmys"] = "0";
                    }
                }
                else {
                    ViewData["ifcmys"] = "0";
                }

                model.pimglist = new BLL.ProductImgBase().GetModelList(" sku_ID=" + list[0].sku_ID);//图片列表
                model.productinfotuijian = new BLL.ProductInfoBase().GetModelList(" p_ID=(select p_ID from SKUBase where sku_ID=" + list[0].sku_ID + ") and pin_StatusCode=0 and pin_IsDel=0 and pin_Type='推荐理由'");//推荐理由 
                model.productinfo = new BLL.ProductInfoBase().GetModelList(" p_ID=(select p_ID from SKUBase where sku_ID=" + list[0].sku_ID + ") and pin_StatusCode=0 and pin_IsDel=0 and pin_Type='商品介绍'");//商品介绍
                
                model.proattr = new BLL.ProductAttributesBase().GetModelListByskuId("pa2.pa_Type=1 and pad.sku_ID= " + list[0].sku_ID);//属性
                model.proattr2 = new BLL.ProductAttributesBase().GetModelListByPid(" and pa.pa_Type=2 and pa.pa_ID in(select pa_ID from ProductAttributeDetails where  sku_ID in (select sku_ID from SKUBase where p_ID=(select p_ID from SKUBase where sku_ID=" + list[0].sku_ID + "))) and sku.sku_ID in (select sku_ID from SKUBase where p_ID=(select p_ID from SKUBase where sku_ID=" + list[0].sku_ID + "))");//规格

                model.proattr3 = new BLL.ProductAttributesBase().GetModelListByPid(" and pa.pa_Type=3 and pa.pa_ID in(select pa_ID from ProductAttributeDetails where  sku_ID in (select sku_ID from SKUBase where p_ID=(select p_ID from SKUBase where sku_ID=" + list[0].sku_ID + "))) and sku.sku_ID in (select sku_ID from SKUBase where p_ID=(select p_ID from SKUBase where sku_ID=" + list[0].sku_ID + "))");//颜色


                List<SelectListItem> pchima = new List<SelectListItem>();//商品尺码
                pchima = new List<SelectListItem> {new SelectListItem{Text="请选择",Value="0"} };
                for (int i = 0; i < model.proattr2.Count; i++)
                {
                    pchima.Add(new SelectListItem {
                        Text = model.proattr2[i].pa_Name.ToString(),
                        Value = model.proattr2[i].pa_ID.ToString()
                    });
                }
                ViewData["pchima"] = new SelectList(pchima,"Value","Text","请选择");

                List<SelectListItem> pyanse = new List<SelectListItem>();//商品颜色
                pyanse = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "0" } };
                for (int i = 0; i < model.proattr3.Count; i++)
                {
                    pyanse.Add(new SelectListItem
                    {
                        Text = model.proattr3[i].pa_Name.ToString(),
                        Value = model.proattr3[i].pa_ID.ToString()
                    });
                }
                ViewData["pyanse"] = new SelectList(pyanse, "Value", "Text", "请选择");



                return View(model);
            }
        }
    }
}