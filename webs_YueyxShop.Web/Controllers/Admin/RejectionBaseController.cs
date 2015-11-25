using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using PagedList;
using System.Text;

namespace webs_YueyxShop.Web.Controllers
{
    public class RejectionBaseController : BaseController
    {
        private readonly RoleManager _roleManager = new RoleManager();
        private readonly BLL.RejectionBase _rejectionBase = new BLL.RejectionBase();
        private readonly BLL.OrderBase _orderBase = new BLL.OrderBase();
        private readonly BLL.MemberBase _memberBase = new BLL.MemberBase();
        public ActionResult RejectionBaseMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            return View();
        }

        public ActionResult RejectionBaseList()
        {
            int total = 0;//总行数
            int pageSize = 30;//每一页的行数
            int pageNumber = 1;//当前页数 
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }

            # region 查询条件

            StringBuilder strSql = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(RequestBase.GetString("txtr_Code")))
            {
                strSql.Append(" and r_Code like '%" + RequestBase.GetString("txtr_Code") + "%'");
            }
            if (!string.IsNullOrWhiteSpace(RequestBase.GetString("txtOrderCode")))
            {
                strSql.Append(" and o_Code like '%" + RequestBase.GetString("txtOrderCode") + "%'");
            }
            if (!string.IsNullOrWhiteSpace(RequestBase.GetString("txtStartDate")))
            {
                strSql.Append(" and r_Date >= '" + RequestBase.GetString("txtStartDate") + "'");
            }
            if (!string.IsNullOrWhiteSpace(RequestBase.GetString("txtEndDate")))
            {
                strSql.Append(" and r_Date <= '" + RequestBase.GetString("txtEndDate") + "'");
            }
            if (!string.IsNullOrWhiteSpace(RequestBase.GetString("o_Status")))
            {
                strSql.Append(" and r_Status = " + RequestBase.GetString("o_Status"));
            }

            strSql.Append(" and r_IsDelete = 0");

            # endregion

            var list = _rejectionBase.GetRejectionBaseListDetail(strSql.ToString());
            total = list.Rows.Count;
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            //ViewData["PageList"] = list;
            ViewData["PageList"] = GetPagedTable(list, pageNumber, pageSize); 
            return View(ViewData["PageList"]);
        }

        public ActionResult RejectionBaseEdit()
        {
            return View();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public ActionResult RejectionBaseDelete()
        {
            bool result = false;
            string Message = "";
            try
            {
                string pid = RequestBase.GetString("r_ID");
                result = _rejectionBase.Delete(int.Parse(pid));
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "删除成功！！", "", "forward", "", "RejectionBox", ""));
                }
                else
                {
                    Message = "删除失败！";
                    return Content(DWZUtil.GetResultJson("300", Message, "", "", ""));
                }
            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "删除失败！！", "", "", ""));
            }
            finally
            {

            }
        }

        public ActionResult RejectionStatus()
        {
            try
            {
                this.ViewData["hfOtype"] = RequestBase.GetString("otype");
                string id = RequestBase.GetString("r_ID");
                var model = _rejectionBase.GetModel(Convert.ToInt32(id));
                switch (ViewData["hfOtype"].ToString())
                {
                    case "deny"://拒绝
                        if (model.r_Status != null && model.r_Status.Value != 0)
                        {
                            return Content(DWZUtil.GetResultJson("300", "错误的操作！！", "", "", ""));
                        }
                        model.r_Status = 1;
                        break;
                    case "agree"://同意
                        if (model.r_Status != null && model.r_Status.Value != 0)
                        {
                            return Content(DWZUtil.GetResultJson("300", "错误的操作！！", "", "", ""));
                        }
                        var order = _orderBase.GetModel(model.o_ID.Value);
                        var member = _memberBase.GetModel(model.m_ID.Value);
                        member.m_Score -= order.o_Score;
                        _memberBase.Update(member);
                        model.r_Status = 2;
                        break;
                    case "delete"://删除
                        if (model.r_Status == null || model.r_Status.Value == 0)
                        {
                            return Content(DWZUtil.GetResultJson("300", "未确认的退货单不能删除！！", "", "", ""));
                        }
                        model.r_IsDelete = true;
                        break;
                }
                if (_rejectionBase.Update(model))
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "forward", "", "RejectionBox", ""));
                }
            }
            catch
            {
            }
            return Content(DWZUtil.GetResultJson("300", "操作失败！！", "", "", ""));
        }

        # region 退货商品列表

        public ActionResult RejectionBaseProductMsg()
        {
            ViewData["r_ID"] = RequestBase.GetString("r_ID");
            if (ViewData["r_ID"] != null && !string.IsNullOrWhiteSpace(ViewData["r_ID"].ToString()))
            {
                ViewData["r_Code"] = _rejectionBase.GetModel(Convert.ToInt32(ViewData["r_ID"].ToString())).r_Code;
            }
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001004001"); //是否拥有管理的权限
            return View();
        }

        public ActionResult RejectionBaseProductList()
        {
            string id = RequestBase.GetString("r_ID");
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
                strSql.Append(" and r_ID = " + id);
            }

            # endregion

            var list = _rejectionBase.GetRejectionProductList(strSql.ToString());

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

        # region 会员信息查看

        public ActionResult RejectionBaseMemberEdit()
        {
            ViewData["r_ID"] = RequestBase.GetString("r_ID");
            var dt = _rejectionBase.GetRejectionBaseListDetail(" and r_ID = " + ViewData["r_ID"]);
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
