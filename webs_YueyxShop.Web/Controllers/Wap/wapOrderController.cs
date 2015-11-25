using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using System.Data;

namespace webs_YueyxShop.Web.Controllers.Wap
{
    public class wapOrderController : BaseWapController
    {
        private readonly BLL.VipRank _vipRank = new BLL.VipRank();
        private readonly RoleManager Rolemanager = new RoleManager();
        private readonly BLL.ProductAttributesBase pabll = new BLL.ProductAttributesBase();
        private readonly BLL.RegionBase _regionBase = new BLL.RegionBase();
        private readonly RoleManager _roleManager = new RoleManager();
        private readonly BLL.ConsigneeInfoBase _consigneeInfo = new BLL.ConsigneeInfoBase();
        private readonly BLL.GroupPurchaseBase _gpBase = new BLL.GroupPurchaseBase();
        private readonly BLL.SKUBase _skuBase = new BLL.SKUBase(); 

        # region 订单

        public ActionResult Order()
        {
            ViewData["mID"] = LoginMember.m_ID;
            string ids = RequestBase.GetString("ids");
            ViewData["skuIdList"] = ids;
            //加载商品清单
            GetProductsList(ids);
            //加载支付方式
            GetPayType();
            //加载配送方式
            GetShipType();
            //获取折扣
            ViewData["discount"] = GetMemberDisCount(LoginMember.m_ID);
            //加载收货地址
            GetConsigneeInfo();
            return View();
        }

        /// <summary>
        /// 获取折扣
        /// </summary>
        /// <returns></returns>
        public decimal GetMemberDisCount(int mid)
        {
            decimal discount = 1.0M;
            Model.MemberBase member = new BLL.MemberBase().GetModel(mid);
            discount = member.m_ZheK.Value;
            //var vipRanks = _vipRank.GetModelList(" r_Status = 0 and r_Score <= " + LoginMember.m_Score);
            //if (vipRanks != null && vipRanks.Any())
            //{
            //    var model = vipRanks.OrderByDescending(m => m.r_Score).FirstOrDefault();
            //    if (model != null)
            //    {
            //        discount = model.r_ZheK.Value;
            //    }
            //}

            return discount;
        }

        /// <summary>
        /// 加载支付方式
        /// </summary>
        public object GetPayType()
        {
            BLL.PaymentBase pay = new BLL.PaymentBase();
            var list = pay.GetModelList(" pay_IsDel = 0 and pay_isPhone = 1");
            ViewData["PayTypeList"] = list;
            return ViewData["PayTypeList"];
        }

        /// <summary>
        /// 加载配送方式
        /// </summary>
        public object GetShipType()
        {
            BLL.ShipTypeBase shipType = new BLL.ShipTypeBase();
            var list = shipType.GetModelList(" st_StatusCode = 0 and st_IsDel = 0");
            ViewData["ShipTypeList"] = list;
            return ViewData["ShipTypeList"];
        }

        /// <summary>
        /// 加载商品清单
        /// </summary>
        public object GetProductsList(string ids)
        {
            ids = ids.Trim(',');
            //会员ID
            BLL.ShoppingCartBase shop = new BLL.ShoppingCartBase();
            var list = shop.GetModelList(" sc_IsDel = 0 and m_ID = " + LoginMember.m_ID + "and sku_ID in (" + ids + ")");

            if (!string.IsNullOrWhiteSpace(ids))
            {
                var dt = new BLL.SKUBase().GetSKUDetial(" and sku_ID in (" + ids + ")", true);
                if (dt != null)
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
                            string sql = " sku_ID = " + row["sku_ID"] + " and gp_IsDel = 0 and gp_StatusCode = 0 and gp_StartTime <= '" + DateTime.Now + "' and gp_EndTime >= '" + DateTime.Now + "'";
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
                ViewData["OrderProducts"] = dt;
            }
            return ViewData["OrderProducts"];
        }

        /// <summary>
        /// 获取收货地址
        /// </summary>
        public object GetConsigneeInfo()
        {
            BLL.ConsigneeInfoBase conInfoBase = new BLL.ConsigneeInfoBase();
            ViewData["ConsigneeInfo"] = null;
            var list = conInfoBase.GetModelList(" c_StatusCode = 0 and c_IsDel = 0 and m_ID = " + LoginMember.m_ID);
            if (list.Count > 0)
            {
                var model = list.Where(m => m.c_Moren == 1).FirstOrDefault();
                if (model == null)
                {
                    model = list.FirstOrDefault();
                }
                ViewData["DefaultCI"] = model;
                ViewData["cID"] = model.c_ID;
                ViewData["ConsigneeInfo"] = list;
            }
            return ViewData["ConsigneeInfo"];
        }

        # endregion

        # region 订单成功

        public ActionResult successOrder()
        {
            //获取订单ID或者编号
            int id = 0;// Convert.ToInt32(RequestBase.GetString("id"));
            if (!string.IsNullOrWhiteSpace(RequestBase.GetString("id")))
            {
                id = Convert.ToInt32(RequestBase.GetString("id"));
            }
            else
            {
                return View();
            }

            BLL.OrderBase order = new BLL.OrderBase();
            var model = order.GetModel(id);
            var shipType = new BLL.ShipTypeBase().GetModel(model.st_ID.Value);
            ViewData["shipTypeName"] = shipType.st_Name;
            ViewData["OrderCode"] = model.o_Code;
            ViewData["OrderPrice"] = model.o_Pric;
            return View();
        }

        # endregion
    }
}