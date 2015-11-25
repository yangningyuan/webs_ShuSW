using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using PagedList;
using System.Text;
using System.Transactions;

namespace webs_YueyxShop.Web.Controllers
{
    /// <summary>
    /// 订单信息
    /// </summary>
    public class OrderBaseController : BaseController
    {
        private readonly RoleManager _roleManager = new RoleManager();
        private readonly BLL.OrderBase _orderBase = new BLL.OrderBase();
        private readonly BLL.MemberBase _memberBase = new BLL.MemberBase();

        public ActionResult OrderBaseMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001004001"); //是否拥有管理的权限
            return View();
        }

        /// <summary>
        /// 加载列表信息
        /// </summary>
        [HttpPost]
        public ActionResult OrderBaseList()
        {
            const int pageSize = 30;
            //当前页
            int pageNumber = 1;
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }

            # region 查询条件

            StringBuilder strSql = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(RequestBase.GetString("txtPAname")))
            {
                strSql.Append(" and p_Name like '%" + RequestBase.GetString("txtPAname") + "%'");
            }
            if (!string.IsNullOrWhiteSpace(RequestBase.GetString("txtNickName")))
            {
                strSql.Append(" and m_NickName like '%" + RequestBase.GetString("txtNickName") + "%'");
            }
            if (!string.IsNullOrWhiteSpace(RequestBase.GetString("txtOrderCode")))
            {
                strSql.Append(" and o_Code like '%" + RequestBase.GetString("txtOrderCode") + "%'");
            }
            if (!string.IsNullOrWhiteSpace(RequestBase.GetString("txtStartDate")))
            {
                strSql.Append(" and o_CreateOn >= '" + RequestBase.GetString("txtStartDate") + "'");
            }
            if (!string.IsNullOrWhiteSpace(RequestBase.GetString("txtEndDate")))
            {
                strSql.Append(" and o_CreateOn <= '" + RequestBase.GetString("txtEndDate") + "'");
            }
            if (!string.IsNullOrWhiteSpace(RequestBase.GetString("o_Status")))
            {
                strSql.Append(" and o_StatusCode = " + RequestBase.GetString("o_Status"));
            }
            # endregion

            var list = _orderBase.GetOrderDetialList(strSql.ToString());

            if (list == null)
                return View();

            //查询总条数
            int total = list.Rows.Count;

            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            //this.ViewData["PageList"] = list;
            ViewData["PageList"] = GetPagedTable(list, pageNumber, pageSize);

            return View(ViewData["PageList"]);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult OrderBaseEdit()
        {
            this.ViewData["hfOtype"] = RequestBase.GetString("otype");
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001004001"); //是否拥有管理的权限

            string id = RequestBase.GetString("o_ID");
            var model = _orderBase.GetModel(Convert.ToInt32(id));
            # region 注释

            //switch (ViewData["hfOtype"].ToString())
            //{
            //    case "detail":
            //        int id = Convert.ToInt32(RequestBase.GetString("o_ID"));
            //        //获取数据
            //        var model = _db.GetOrderDetialList(" and o_ID = " + id);
            //        if (model != null && model.Rows.Count > 0)
            //        {
            //            //买家信息
            //            ViewData["txtm_NickName"] = model.Rows[0]["m_NickName"];
            //            ViewData["txtm_RealName"] = model.Rows[0]["m_RealName"];
            //            //ViewData["txtm_Area"] = model.Rows[0]["txtm_Area"];
            //            ViewData["txtm_Phone"] = model.Rows[0]["m_Phone"];
            //            //订单信息
            //            ViewData["txto_Code"] = model.Rows[0]["o_Code"];
            //            ViewData["txto_CreateOn"] = model.Rows[0]["o_CreateOn"];
            //            ViewData["txtp_Name"] = model.Rows[0]["p_Name"];
            //            //ViewData["txtName"] = model.Rows[0]["m_NickName"];
            //            ViewData["txto_StatusCode"] = model.Rows[0]["o_StatusCode"];
            //            ViewData["txtsku_Price"] = model.Rows[0]["sku_Price"];
            //            ViewData["txtos_Count"] = model.Rows[0]["os_pCount"];
            //            ViewData["txto_Pric"] = model.Rows[0]["o_Pric"];
            //            //ViewData["txtName"] = model.Rows[0]["m_NickName"];
            //            //ViewData["txtName"] = model.Rows[0]["m_NickName"];
            //            //收货信息
            //            ViewData["txtc_Address"] = model.Rows[0]["c_Address"];
            //            ViewData["txto_Send"] = model.Rows[0]["o_Send"];
            //            //ViewData["txtm_NickName"] = model.Rows[0]["m_NickName"];
            //            //ViewData["txtm_NickName"] = model.Rows[0]["m_NickName"];
            //        }
            //        break;
            //}

            # endregion

            return View(model);
        }

        public ActionResult OrderBaseEdit(Model.OrderBase order) 
        {
            var model = _orderBase.GetModel(order.o_ID);
            model.o_LogisticsNo = order.o_LogisticsNo;
            model.o_StatusCode = Model.OrderStatus.等待收货.GetHashCode();
            if (_orderBase.Update(model))
            {
                return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功！！", "", "forward", "closeCurrent", "OrderBox", ""));
            }
            else
            {
                return Content(DWZUtil.GetResultJson("300", "保存失败！！", "", "", ""));
            }
        }

        public ActionResult OrderBaseDelete()
        {
            try
            {
                string id = RequestBase.GetString("o_ID");
                var model = _orderBase.GetModel(Convert.ToInt32(id));
                model.o_IsDel = true;
                if (_orderBase.Update(model))
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "订单取消成功！！", "", "forward", "", "OrderBox", ""));
                }
            }
            catch
            {
            }
            return Content(DWZUtil.GetResultJson("300", "取消失败！！", "", "", ""));
        }

        public ActionResult OrderBaseStatus()
        {
            try
            {
                this.ViewData["hfOtype"] = RequestBase.GetString("otype");
                string id = RequestBase.GetString("o_ID");
                var model = _orderBase.GetModel(Convert.ToInt32(id));
                var member = _memberBase.GetModel(model.m_ID.Value);
                bool ispay = false;
                bool isjianhuo = false;
                if (model.o_StatusCode ==1)//已付钱的才能捡货
                {
                    ispay = true;
                }
                if (model.o_StatusCode == 2)//捡过货，状态为已出库的才能发货
                {
                    isjianhuo = true;
                }
                using (var scope = new TransactionScope())
                {
                    switch (ViewData["hfOtype"].ToString())
                    {
                        case "select"://捡货
                            if (model.o_StatusCode.Value >= Model.OrderStatus.商品出库.GetHashCode())
                            {
                                return Content(DWZUtil.GetResultJson("300", "错误的操作", "", "", ""));
                            }
                            if (ispay)
                            {
                                model.o_StatusCode = Model.OrderStatus.商品出库.GetHashCode();
                            }
                            else
                            {
                                return Content(DWZUtil.GetResultJson("300", "该订单未付款，不能捡货！！", "", "", ""));
                            }
                            break;
                        case "send"://发货
                            if (model.o_StatusCode.Value >= Model.OrderStatus.等待收货.GetHashCode()  )
                            {
                                return Content(DWZUtil.GetResultJson("300", "错误的操作！！", "", "", ""));
                            }
                            if (isjianhuo)
                            {
                                model.o_StatusCode = Model.OrderStatus.等待收货.GetHashCode();
                            }
                            else
                            {
                                return Content(DWZUtil.GetResultJson("300", "该订单未捡货，不能发货！！", "", "", ""));
                            }
                            break;
                        case "complete"://完成
                            if (model.o_StatusCode.Value >= Model.OrderStatus.交易完成.GetHashCode())
                            {
                                return Content(DWZUtil.GetResultJson("300", "错误的操作！！", "", "", ""));
                            }
                            // 会员添加积分
                         
                            member.m_Score = member.m_Score + model.o_Score;
                            var rank = new BLL.VipRank().GetModelList(member.m_Score + " between r_score and r_upperscore");
                            if (rank.Count > 0)
                            {
                                member.m_Rank = rank[0].r_Rank;
                                member.m_ZheK = rank[0].r_ZheK;
                            }
                            model.o_StatusCode = Model.OrderStatus.交易完成.GetHashCode();
                            break;
                    }
                    if (_orderBase.Update(model))
                    {
                        _memberBase.Update(member);
                        scope.Complete();
                        return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "forward", "", "OrderBox", ""));
                    }
                }
            }
            catch
            {
            }
            return Content(DWZUtil.GetResultJson("300", "操作失败！！", "", "", ""));
        }

        # region 订单商品详细

        public ActionResult OrderBaseProductMsg()
        {
            ViewData["o_ID"] = RequestBase.GetString("o_ID");
            if (ViewData["o_ID"] != null && !string.IsNullOrWhiteSpace(ViewData["o_ID"].ToString()))
            {
                ViewData["o_Code"] = _orderBase.GetModel(Convert.ToInt32(ViewData["o_ID"].ToString())).o_Code;
            }
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001004001"); //是否拥有管理的权限
            return View();
        }

        public ActionResult OrderBaseProductList()
        {
            string id = RequestBase.GetString("o_ID");
            const int pageSize = 30;
            //当前页
            int pageNumber = 1;
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }

            # region 查询条件

            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(id))
            {
                strSql.Append(" and o_ID = " + id);
            }

            # endregion

            var list = _orderBase.GetOrderProductList(strSql.ToString());

            if (list == null)
                return View();

            //查询总条数
            int total = list.Rows.Count;

            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            //this.ViewData["PageList"] = list;
            ViewData["PageList"] = GetPagedTable(list, pageNumber, pageSize);

            return View(ViewData["PageList"]);
        }

        # endregion

        # region 查看会员信息

        public ActionResult OrderBaseMemberEdit()
        {
            ViewData["o_ID"] = RequestBase.GetString("o_ID");
            var dt = _orderBase.GetOrderDetialList(" and o_ID = " + ViewData["o_ID"]);
            if (dt != null && dt.Rows.Count > 0)
            {
                //赋值
                ViewData["m_UserName"] = dt.Rows[0]["m_UserName"];
                ViewData["m_NickName"] = dt.Rows[0]["m_NickName"];
                ViewData["m_RealName"] = dt.Rows[0]["m_RealName"];
                ViewData["m_Phone"] = dt.Rows[0]["m_Phone"];
                ViewData["m_Email"] = dt.Rows[0]["m_Email"];
                ViewData["m_QQ"] = dt.Rows[0]["m_QQ"];
                ViewData["m_CreatedOn"] = dt.Rows[0]["m_CreatedOn"];
                ViewData["m_StatusCode"] = dt.Rows[0]["m_StatusCode"];
            }

            return View();
        }

        # endregion
    }
}