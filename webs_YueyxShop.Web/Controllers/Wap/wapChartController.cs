using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace webs_YueyxShop.Web.Controllers.Wap
{
    public class wapChartController : BaseWapController
    {
        private readonly BLL.SKUBase _skuBase = new BLL.SKUBase();
        private readonly BLL.GroupPurchaseBase _gpBase = new BLL.GroupPurchaseBase();

        public ActionResult Chart()
        {
            if (GetChartList())
            {
                ViewData["isempty"] = "full";
            }
            else
            {
                ViewData["isempty"] = "";
            }
            return View();
        }

        /// <summary>
        /// 获取购物车数据
        /// </summary>
        /// <returns>有数据返回true</returns>
        public bool GetChartList()
        {
            //会员ID
            if (LoginMember != null)
            {
                BLL.ShoppingCartBase shop = new BLL.ShoppingCartBase();
                var list = shop.GetModelList(" sc_Status = 0 and sc_IsDel = 0 and m_ID = " + LoginMember.m_ID);
                //获取SKU Id列表
                string ids = "";
                foreach (var model in list)
                {
                    if (!string.IsNullOrWhiteSpace(ids))
                    {
                        ids += ",";
                    }
                    ids += model.sku_ID;
                }
                if (!string.IsNullOrWhiteSpace(ids))
                {
                    var dt = new BLL.SKUBase().GetSKUDetial(" and sku_ID in (" + ids + ")", true);
                    if (dt != null && dt.Rows.Count != 0)
                    {
                        dt.Columns.Add("sc_pCount", Type.GetType("System.Int32"));//商品数量
                        dt.Columns.Add("sc_pCountStatus", Type.GetType("System.String"));//商品库存状态
                        dt.Columns.Add("sc_IsGP", Type.GetType("System.Boolean"));//团购标识
                        foreach (DataRow row in dt.Rows)
                        {
                            var model = list.Where(m => m.sku_ID == Convert.ToInt32(row["sku_ID"])).FirstOrDefault();
                            if (model != null)
                            {
                                row["sc_pCount"] = model.sc_pCount;
                                string sql = " sku_ID = " + row["sku_ID"] + " and gp_IsDel = 0 and gp_StatusCode = 0 and gp_EndTime > '" + DateTime.Now + "' and gp_pCount-gp_SaleCount>0";
                                if (model.sc_IsGP)
                                {
                                    //团购
                                    var gpBase = _gpBase.GetModelList(sql).FirstOrDefault();
                                    if (gpBase != null)
                                    {
                                        //团购取团购价格
                                        row["sku_Price"] = gpBase.gp_pPric;
                                        row["sc_IsGP"] = true;
                                        if (model.sc_pCount <= gpBase.gp_pCount - gpBase.gp_SaleCount)
                                        {
                                            row["sc_pCountStatus"] = "有货";
                                        }
                                        else
                                        {
                                            row["sc_pCountStatus"] = "库存不足";
                                        }
                                    }
                                    else
                                    {
                                        row["sc_pCountStatus"] = "团购结束";
                                    }
                                }
                                else
                                {
                                    row["sc_IsGP"] = false;
                                    //库存
                                    var skuBase = _skuBase.GetModel(Convert.ToInt32(row["sku_ID"]));
                                    if (model.sc_pCount <= skuBase.sku_Stock)
                                    {
                                        row["sc_pCountStatus"] = "有货";
                                    }
                                    else
                                    {
                                        row["sc_pCountStatus"] = "库存不足";
                                    }
                                }
                            }
                        }
                        ViewData["chartList"] = dt;
                        return true;
                    }
                }
                return false;
            }
            else
            {
                Response.Redirect("/wapLogin/Login");
                return false;
            }
        }
    }
}