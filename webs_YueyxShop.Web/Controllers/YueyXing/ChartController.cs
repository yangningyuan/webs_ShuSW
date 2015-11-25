using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Common;

namespace webs_YueyxShop.Web.Controllers.YueyXing
{
    public class ChartController : MasterPageController
    {
        private readonly BLL.ShoppingCartBase _shoppingCart = new BLL.ShoppingCartBase();
        private readonly BLL.SKUBase _skuBase = new BLL.SKUBase();
        private readonly BLL.GroupPurchaseBase _gpBase = new BLL.GroupPurchaseBase();

        public ChartController()
            : base("购物车")
        {
        }

        /// <summary>
        /// 购物车
        /// </summary>
        /// <returns></returns>
        public ActionResult Chart()
        {
            if (LoginMember == null)
            {
                Response.Redirect("/Logon/Logon", true);
            }
            GetOrderProducts();

            return View();
        }

        /// <summary>
        /// 获取产品
        /// </summary>
        public void GetOrderProducts()
        {
            //会员ID
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
            if (string.IsNullOrWhiteSpace(ids))
                return;
            var dt = new BLL.SKUBase().GetSKUDetial(" and sku_ID in (" + ids + ")", true);
            if (dt != null)
            {
                dt.Columns.Add("sc_pCount", Type.GetType("System.Int32"));//商品数量
                dt.Columns.Add("sc_pCountStatus", Type.GetType("System.String"));//商品库存状态
                dt.Columns.Add("sc_IsGP", Type.GetType("System.Boolean"));//团购标识
                foreach (DataRow row in dt.Rows)
                {
                    //购物车
                    var model = list.Where(m => m.sku_ID == Convert.ToInt32(row["sku_ID"])).FirstOrDefault();
                    if (model != null)
                    {
                        row["sc_pCount"] = model.sc_pCount;
                        string sql = " sku_ID = " + row["sku_ID"] + " and gp_IsDel = 0 and gp_StatusCode = 0 and gp_StartTime <= '" + DateTime.Now + "' and gp_EndTime >= '" + DateTime.Now + "'";
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
            }
            ViewData["ChartProducts"] = dt;
        }

        public string UpdateChartCount()
        {
            string result = "获取库存异常";
            string id = RequestBase.GetString("id");
            string count = RequestBase.GetString("count");
            if (_shoppingCart.UpdateCount(LoginMember.m_ID, Convert.ToInt32(id), Convert.ToInt32(count)))
            {
                int stock = 0;
                string sql = " sku_ID = " + id + " and gp_IsDel = 0 and gp_StatusCode = 0 and gp_StartTime <= '" + DateTime.Now + "' and gp_EndTime >= '" + DateTime.Now + "'";
                //购物车
                var shop = _shoppingCart.GetModelList(" sc_Status = 0 and sc_IsDel = 0 and sku_ID = " + id + " and  m_ID = " + LoginMember.m_ID).FirstOrDefault();
                if (shop != null && shop.sc_IsGP)
                {
                    //团购
                    var gpBase = _gpBase.GetModelList(sql).FirstOrDefault();
                    if (gpBase != null)
                    {
                        stock = gpBase.gp_pCount.Value - gpBase.gp_SaleCount;
                    }
                    else
                    {
                        return "团购结束";
                    }
                }
                else
                {
                    var model = _skuBase.GetModel(Convert.ToInt32(id));
                    stock = model.sku_Stock.Value;
                }
                if (stock >= Convert.ToInt32(count))
                {
                    result = "有货";
                }
                else
                {
                    result = "库存不足";
                }
            }

            return result;
        }

        public string DeleteChartSKU()
        {
            string result = "删除失败";
            string id = RequestBase.GetString("ids");
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (_shoppingCart.ChangeStatus(true, LoginMember.m_ID, id.Trim(',')))
                {
                    result = "删除成功";
                }
            }

            return result;
        }

        public string StatusChartSKU()
        {
            string result = "提交失败";
            string id = RequestBase.GetString("ids");
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (_shoppingCart.ChangeStatus(false, LoginMember.m_ID, id.Trim(',')))
                {
                    result = "提交成功";
                }
            }

            return result;
        }

        public ActionResult Partialremaituijian()
        {
            List<Model.ProductBase> pinfo = new BLL.ProductBase().GetpInfoByRecommendTypeId(1);
            return View(pinfo.ToList());
        }
    }
}