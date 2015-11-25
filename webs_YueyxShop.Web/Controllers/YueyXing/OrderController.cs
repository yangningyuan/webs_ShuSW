using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Common;
using System.Text;

namespace webs_YueyxShop.Web.Controllers.YueyXing
{
    public class OrderController : MasterPageController
    {
        private readonly BLL.VipRank _vipRank = new BLL.VipRank();
        private readonly RoleManager Rolemanager = new RoleManager();
        private readonly BLL.ProductAttributesBase pabll = new BLL.ProductAttributesBase();
        private readonly BLL.RegionBase _regionBase = new BLL.RegionBase();
        private readonly RoleManager _roleManager = new RoleManager();
        private readonly BLL.ConsigneeInfoBase _consigneeInfo = new BLL.ConsigneeInfoBase();
        private readonly BLL.GroupPurchaseBase _gpBase = new BLL.GroupPurchaseBase();
        private readonly BLL.SKUBase _skuBase = new BLL.SKUBase();

        public OrderController()
            : base("订单页")
        {
        }

        /// <summary>
        /// 折扣计算
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
        /// 提交订单页面
        /// </summary>
        public ActionResult Order()
        {
            if (LoginMember == null)
            {
                Response.Redirect("/Logon/Logon", true);
            }
            else
            {
                ViewData["mID"] = LoginMember.m_ID;
                string ids = RequestBase.GetString("ids");
                ViewData["skuIdList"] = ids;
                ViewData["discount"] = GetMemberDisCount(LoginMember.m_ID);
                GetConsigneeInfo();
                //GetOrderProducts(LoginMember.m_ID);
                GetOrderProducts(ids);
                GetShipType();
                GetPayType();

                var modelList = _regionBase.GetModelList(" reg_PId = 0");

                List<SelectListItem> selectType = new List<SelectListItem>();
                selectType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
                foreach (var model in modelList)
                {
                    selectType.Add(new SelectListItem
                    {
                        Value = model.reg_ID.ToString(),
                        Text = model.reg_Name
                    });
                }
                ViewData["selectType"] = new SelectList(selectType, "Value", "Text", "请选择");
                List<SelectListItem> selectType2 = new List<SelectListItem>();
                selectType2 = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
                ViewData["selectType2"] = new SelectList(selectType2, "Value", "Text", "请选择");
                List<SelectListItem> selectType3 = new List<SelectListItem>();
                selectType3 = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
                ViewData["selectType3"] = new SelectList(selectType3, "Value", "Text", "请选择");
            }
            return View();
        }

        /// <summary>
        /// 订单提交成功
        /// </summary>
        public ActionResult SuccessOrder()
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
            ViewData["OrderStatus"] = "提交订单";
            return View(model);
        }

        /// <summary>
        /// 收货人信息
        /// </summary>
        public void GetConsigneeInfo()
        {
            //根据登录用户ID获取收货人列表
            BLL.ConsigneeInfoBase conInfoBase = new BLL.ConsigneeInfoBase();
            var list = conInfoBase.GetModelList(" c_StatusCode = 0 and c_IsDel = 0 and m_ID = " + LoginMember.m_ID);
            ViewData["ConsigneeInfo"] = list;
        }

        /// <summary>
        /// 添加收货人
        /// </summary>
        public ActionResult AddConsigneeInfo()
        {
            int cid = 0;
            bool isAdd = true;
            if (RequestBase.GetString("otype") == "modify")
            {
                cid = Convert.ToInt32(RequestBase.GetString("cid"));
                isAdd = false;
            }
            var name = RequestBase.GetString("name");
            var selectType = RequestBase.GetString("selectType");
            var selectType2 = RequestBase.GetString("selectType2");
            var selectType3 = RequestBase.GetString("selectType3");
            var Address = RequestBase.GetString("Address");
            var phone = RequestBase.GetString("phone");
            var tphone = RequestBase.GetString("tphone");
            var zipcode = RequestBase.GetString("zipcode");

            var model = new Model.ConsigneeInfoBase();
            if (!isAdd)
            {
                model = _consigneeInfo.GetModel(cid);
            }
            else
            {
                model.c_IsDel = 0;
                model.c_Moren = 0;
                model.c_StatusCode = 0;
                model.m_ID = LoginMember.m_ID;
            }
            model.c_Provice = Convert.ToInt32(selectType);
            model.c_City = Convert.ToInt32(selectType2);
            model.c_Count = Convert.ToInt32(selectType3);
            model.c_FullAddress = Address;
            model.c_Mobilephone = phone;
            model.c_Telephone = tphone;
            model.c_Name = name;
            model.c_Zipcode = zipcode;
            try
            {
                if (isAdd)
                {
                    int id = _consigneeInfo.Add(model);
                    model = _consigneeInfo.GetModel(id);
                }
                else
                {
                    if (_consigneeInfo.Update(model))
                    {
                        model = _consigneeInfo.GetModel(model.c_ID);
                    }
                    else
                    {
                        model = null;
                    }
                }
            }
            catch
            {
                model = null;
            }
            return View(model);
        }

        public string GetConsigneeInfoBase()
        {
            string result = string.Empty;
            string cid = RequestBase.GetString("cID");
            if (!string.IsNullOrWhiteSpace(cid))
            {
                var model = _consigneeInfo.GetModel(Convert.ToInt32(cid));
                //省，市，县，完整地址，移动电话，座机，名字，邮编
                result += model.c_Provice.ToString() + ",";
                result += model.c_City.ToString() + ",";
                result += model.c_Count.ToString() + ",";
                result += model.c_FullAddress + ",";
                result += model.c_Mobilephone + ",";
                result += model.c_Telephone + ",";
                result += model.c_Name + ",";
                result += model.c_Zipcode;

                result = "{result:'" + result + "',city:'" + GetCity(model.c_Provice.ToString()) + "',country:'" + GetCountry(model.c_City.ToString()) + "'}";
            }

            return result;
        }

        /// <summary>
        /// 获取产品
        /// </summary>
        public void GetOrderProducts(string ids)
        {
            ids = ids.Trim(',');
            //会员ID
            BLL.ShoppingCartBase shop = new BLL.ShoppingCartBase();
            var list = shop.GetModelList(" sc_IsDel = 0 and m_ID = " + LoginMember.m_ID + "and sku_ID in (" + ids + ")");

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

        /// <summary>
        /// 支付方式
        /// </summary>
        public void GetPayType()
        {
            BLL.PaymentBase pay = new BLL.PaymentBase();
            var list = pay.GetModelList(" pay_IsDel = 0 and pay_isPhone = 0");
            ViewData["PayTypeList"] = list;
        }

        /// <summary>
        /// 配送方式
        /// </summary>
        public void GetShipType()
        {
            BLL.ShipTypeBase shipType = new BLL.ShipTypeBase();
            var list = shipType.GetModelList(" st_StatusCode = 0 and st_IsDel = 0");
            ViewData["ShipTypeList"] = list;
        }

        //地区联动下拉菜单
        [HttpGet]
        public string GetCity(string id)
        {
            StringBuilder attr = new StringBuilder();
            if (RequestBase.GetString("code") != "")
            {
                id = RequestBase.GetString("code");
            }
            if (id == "chose")
            {
                return "refresh";
            }
            else
            {
                List<SelectListItem> selectattrP = new List<SelectListItem>();
                Model.RegionBase rmodel = _regionBase.GetModel(int.Parse(id));
                List<Model.RegionBase> modelCity = _regionBase.GetModelList(" reg_PId = " + rmodel.reg_Code);
                StringBuilder sbGoodsName = new StringBuilder();
                attr.Append("[[\"chose\",\"请选择\"]");
                for (int i = 0; i < modelCity.Count; i++)
                {
                    attr.Append(",[");
                    attr.Append("\"" + modelCity[i].reg_ID.ToString() + "\",");
                    attr.Append("\"" + modelCity[i].reg_Name + "\"");
                    attr.Append("]");
                }

                attr.Append("]");

                return attr.ToString();
            }
        }

        [HttpGet]
        public string GetCountry(string id)
        {
            StringBuilder attr = new StringBuilder();
            if (RequestBase.GetString("code") != "")
            {
                id = RequestBase.GetString("code");
            }
            if (id == "chose")
            {
                return "refresh";
            }
            else
            {
                List<SelectListItem> selectattrP = new List<SelectListItem>();
                Model.RegionBase rmodel = _regionBase.GetModel(int.Parse(id));
                List<Model.RegionBase> modelCountry = _regionBase.GetModelList(" reg_PId = " + rmodel.reg_Code);
                StringBuilder sbGoodsName = new StringBuilder();
                attr.Append("[[\"chose\",\"请选择\"]");

                for (int i = 0; i < modelCountry.Count; i++)
                {
                    attr.Append(",[");
                    attr.Append("\"" + modelCountry[i].reg_ID.ToString() + "\",");
                    attr.Append("\"" + modelCountry[i].reg_Name + "\"");
                    attr.Append("]");
                }

                attr.Append("]");

                return attr.ToString();
            }
        }
    }
}