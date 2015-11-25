using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webs_YueyxShop.Web.Controllers.ShuSW
{
    public class sswShopCartController:Controller
    {
        
        public ActionResult ShopCartList() 
        {
            ViewBag.Title = "我的购物车-书生网";

            string mid=Request.QueryString["mid"];
            ViewData["ordermid"] = mid;
            dataWork dwgwc = new dataWork();
            DataTable dtgwc = dwgwc.GetTab(string.Format("select ProductBase.p_ID as p_id,ShoppingCartBase.m_ID as m_id,ProductImgBase.pi_Url as pi_url,ProductBase.p_Name as p_name,SKUBase.sku_Price as sku_price,ShoppingCartBase.sc_pCount as sc_pcount,ShoppingCartBase.sc_ID as sc_id,ShoppingCartBase.sku_ID as sku_id from ShoppingCartBase,SKUBase,ProductBase,ProductImgBase where ProductImgBase.sku_ID=SKUBase.sku_ID and ShoppingCartBase.sku_ID=SKUBase.sku_ID AND SKUBase.p_ID=ProductBase.p_ID and sc_IsDel=0 and sc_Status=0 and sc_IsGP=0 and ProductImgBase.pi_isDel=0 and ProductImgBase.pi_StatusCode=0 and ProductImgBase.pi_Type=1 and ShoppingCartBase.m_ID={0}", mid));

            ViewData["shoplistnum"] = dtgwc.Rows.Count;
            
            string shopids = "";
            decimal totalprice = 0;//总价
            if(dtgwc!=null&& dtgwc.Rows.Count>0)
            {
                for (int i = 0; i < dtgwc.Rows.Count; i++)
                {
                    totalprice += Convert.ToInt32(dtgwc.Rows[i]["sc_pcount"]) * Convert.ToDecimal(dtgwc.Rows[i]["sku_price"]);
                    shopids += dtgwc.Rows[i]["sku_id"]+",";
                } 
            }
            ViewData["shopids"] = shopids;
            ViewData["shoplistprice"] = totalprice;
            if (dtgwc.Rows.Count > 0)
            {
                ViewData["shopCartList"]= dtgwc;
                
                return View();
            }
            else {
                return View("ShopCartNull");
            }
        }

        public ActionResult ShopCartNull() 
        {
            ViewBag.Title = "空空如也的购物车-书生网";
            return View();
        }
        /// <summary>
        /// 确认订单填写送货信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ShopCartOrder() 
        {

            ViewBag.Title = "确认订单填写收货信息-书生网";

            string mid = Request.QueryString["mid"];

            dataWork dwgwc = new dataWork();
            DataTable dtgwc = dwgwc.GetTab(string.Format("select ProductBase.p_ID as p_id,ShoppingCartBase.m_ID as m_id,ProductImgBase.pi_Url as pi_url,ProductBase.p_Name as p_name,SKUBase.sku_Price as sku_price,ShoppingCartBase.sc_pCount as sc_pcount,ShoppingCartBase.sc_ID as sc_id from ShoppingCartBase,SKUBase,ProductBase,ProductImgBase where ProductImgBase.sku_ID=SKUBase.sku_ID and ShoppingCartBase.sku_ID=SKUBase.sku_ID AND SKUBase.p_ID=ProductBase.p_ID and sc_IsDel=0 and sc_Status=0 and sc_IsGP=0 and ProductImgBase.pi_isDel=0 and ProductImgBase.pi_StatusCode=0 and ProductImgBase.pi_Type=1 and ShoppingCartBase.m_ID={0}", mid));

            ViewData["shoplistnum"] = dtgwc.Rows.Count;
            decimal totalprice = 0;//总价
            if (dtgwc != null && dtgwc.Rows.Count > 0)
            {
                for (int i = 0; i < dtgwc.Rows.Count; i++)
                {
                    totalprice += Convert.ToInt32(dtgwc.Rows[i]["sc_pcount"]) * Convert.ToDecimal(dtgwc.Rows[i]["sku_price"]);
                }
            }

            ViewData["shoplistprice"] = totalprice;
            if (dtgwc.Rows.Count > 0)
            {
                ViewData["shopCartList"] = dtgwc;

                return View();
            }
            else
            {
                return View("ShopCartNull");
            }
        }



        
    }
}