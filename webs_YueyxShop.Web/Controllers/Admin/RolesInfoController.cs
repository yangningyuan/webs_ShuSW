using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using PagedList;
using System.Text;
using System.Transactions;
using webs_YueyxShop.BLL;
using webs_YueyxShop.Model;

namespace webs_YueyxShop.Web
{
    public class RolesInfoController : BaseController
    {
        private BLL.RolesInfo rBLL = new BLL.RolesInfo();
        private BLL.FunctionBase fBLL = new BLL.FunctionBase();
        private RoleManager Rolemanager = new RoleManager();
        private BLL.RolesMenuDetails rmdBLL = new BLL.RolesMenuDetails();
        private BLL.RolesFunctionDetails rfdBLL = new BLL.RolesFunctionDetails();
        public ActionResult RolesInfoMsg()
        {
            //ViewData["IsHasFunRole"] = Rolemanager.IsHasFunRole(EmployeeInfo.e_ID, "001003001");//是否拥有管理的权限
            ViewData["IsHasFunRole"] = true;
            return View();
        }
        #region 列表页
        /// <summary>
        /// 列表页
        /// </summary>
        [HttpPost]
        public ActionResult RolesInfoList()
        {
            int pageSize = 30;
            //当前页
            int pageNumber = 1;
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(" r_DeleteStateCode=0");
            if (!string.IsNullOrEmpty(RequestBase.GetString("txtRolename")))
            {
                sqlStr.AppendFormat(" and r_MingCh like '%{0}%'", RequestBase.GetString("txtRolename").Trim());
            }
            sqlStr.Append(" order by r_PaiX ");

            var rolesinfoList = rBLL.GetModelList(sqlStr.ToString());
            //查询总条数
            int total = rolesinfoList.Count();

            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            return View(rolesinfoList.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region 编辑
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult RolesInfoEdit()
        {
            this.ViewData["hfOtype"] = RequestBase.GetString("otype");
            //ViewData["IsHasFunRole"] = Rolemanager.IsHasFunRole(EmployeeInfo.e_ID, "001003001");//是否拥有管理的权限
            ViewData["IsHasFunRole"] = true;
            switch (ViewData["hfOtype"].ToString())
            {
                case "modify":
                    ViewData["hfRid"] = RequestBase.GetString("r_ID");
                    RolesInfoObj = rBLL.GetModel(new Guid(RequestBase.GetString("r_ID")));
                    break;
                case "add":
                    ViewData["txtRMiaos"] = "";
                    break;
                default:
                    break;
            }
            return View();
        }
        #endregion

        #region 保存
        public ActionResult Save()
        {
            string message = "";
            bool result = false;
            int ReturnValue = Request.Form["hfOtype"] == "add" ? 0 : 1;
            try
            {

                if (Request.Form["hfOtype"] == "add")
                {
                    #region 验证 是否存在同名
                    if (!string.IsNullOrEmpty(RolesInfoObj.r_MingCh))
                    {
                        if (rBLL.IsExists(RolesInfoObj.r_MingCh))
                        {
                            return Content(DWZUtil.GetResultJson("300", "名称已存在", "", "", ""));
                        }
                    }
                    #endregion
                    result = rBLL.Add(RolesInfoObj);
                }
                else if (Request.Form["hfOtype"] == "modify")
                {
                    Guid id = new Guid(Request.Form["hfRid"].ToString());
                    Model.RolesInfo model = null;
                    model = rBLL.GetModel(id);
                    #region 验证 是否存在同名
                    if (!string.IsNullOrEmpty(model.r_MingCh))
                    {
                        if (model.r_MingCh != RolesInfoObj.r_MingCh)
                        {
                            if (rBLL.IsExists(RolesInfoObj.r_MingCh))
                            {
                                return Content(DWZUtil.GetResultJson("300", "名称已存在", "", "", ""));
                            }
                        }
                    }
                    #endregion
                    model.r_MingCh = RolesInfoObj.r_MingCh;
                    model.r_MiaoS = RolesInfoObj.r_MiaoS;
                    model.r_PaiX = RolesInfoObj.r_PaiX;
                    result = rBLL.Update(model);
                }
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功！！", "", "", "closeCurrent", "RolesInfoBox", ""));
                }
                return Content(DWZUtil.GetResultJson("300", "保存失败！！", "", "", ""));

            }
            catch (Exception)
            {
                return Content(DWZUtil.GetResultJson("300", "保存失败！！", "", "", ""));
            }
        }
        #endregion

        #region 实体
        Model.RolesInfo RolesInfoObj
        {
            get
            {
                Model.RolesInfo model = new Model.RolesInfo();
                if (Request.Form["hfOtype"] == "add")
                {
                    model.r_ID = Guid.NewGuid();
                    model.r_DeleteStateCode = 0;
                    model.r_StateCode = 0;
                    model.r_CreatedBy = EmployeeBase.e_ID;
                    model.r_CreatedOn = DateTime.Now;
                }
                model.r_MingCh = Request.Form["txtRname"].ToString().Trim();
                model.r_MiaoS = Request.Form["txtRMiaos"].ToString();
                if (!string.IsNullOrEmpty(Request.Form["txtRPaix"].ToString()))
                {
                    model.r_PaiX = int.Parse(Request.Form["txtRPaix"].ToString());
                }
                else model.r_PaiX = 0;

                return model;
            }
            set
            {
                ViewData["txtRname"] = value.r_MingCh;
                ViewData["txtRMiaos"] = value.r_MiaoS;
                ViewData["txtRPaix"] = value.r_PaiX;
            }
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        public ActionResult Delete()
        {
            try
            {
                bool result = false;
                if (!string.IsNullOrEmpty(RequestBase.GetString("r_ID")))
                    result = rBLL.Delete(new Guid(RequestBase.GetString("r_ID")));//逻辑删除
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "", "", "RolesInfoBox", ""));
                }
                return Content(DWZUtil.GetResultJson("300", "操作失败！！", "", "", ""));
            }
            catch (Exception ex)
            {
                return Content(DWZUtil.GetResultJson("300", "操作失败！！", "", "", ""));
            }
        }
        #endregion

        #region 启，禁用
        public ActionResult Enable()
        {
            try
            {
                if (string.IsNullOrEmpty(RequestBase.GetString("r_ID")))
                {
                    return Content(DWZUtil.GetResultJson("300", "操作失败,请刷新后重试！！", "", "", ""));
                }
                bool result = false;
                if (RequestBase.GetString("otype") == "enable")
                    result = rBLL.UpdateState(0, new Guid(RequestBase.GetString("r_ID")));//启用
                else if (RequestBase.GetString("otype") == "disable")
                    result = rBLL.UpdateState(1, new Guid(RequestBase.GetString("r_ID"))); //禁用

                if (result)
                    return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "", "", "RolesInfoBox", ""));
                else
                    return Content(DWZUtil.GetResultJson("300", "操作失败！！", "", "", ""));
            }
            catch (Exception ex)
            {
                return Content(DWZUtil.GetResultJson("300", "操作失败！！", "", "", ""));
            }
        }
        #endregion

        #region 设置菜单权限
        //Menu authority
        public ActionResult MenuAuthority()
        {
            ViewData["hf_IsManage"] = true; // new CRM.Public.RoleManager().IsHasFunRole(EmployeeInfo.e_ID, "006007001");//管理权限
            //string ParentId = "00000000-0000-0000-0000-000000000000";
            //var menuList = new BLL.MenuBase().GetModelList("m_ParentId='" + ParentId + "' and m_DeleteStateCode=0 and m_StateCode=0 order by m_PaiX");
            //所有菜单
            var menuList = new BLL.MenuBase().GetModelList(" m_DeleteStateCode=0 and m_StateCode=0 order by m_PaiX ASC");
            var MenuIds = rmdBLL.GetModelList(" r_ID='" + RequestBase.GetString("r_ID") + "'");//拥有菜单
            string RoleMenuIds = "";
            foreach (Model.RolesMenuDetails j in MenuIds)
            {
                RoleMenuIds += j.m_ID + ",";
            }
            ViewData["hfItems"] = RoleMenuIds;
            ViewData["hfRoleId"] = RequestBase.GetString("r_ID");
            return View(menuList.ToList());

        }
        [HttpPost]
        public ActionResult AddMenuAuthority(string hfItems, string hfRoleId)
        {
            bool result = false;
            try
            {
                result = rmdBLL.AddRoleMenu(hfItems, hfRoleId);
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "", "closeCurrent", "RolesInfoBox", ""));
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "操作失败！！", "", "", ""));
                }
            }
            catch (Exception)
            {
                return Content(DWZUtil.GetResultJson("300", "操作失败！！", "", "", ""));
            }
        }


        #endregion

        #region 角色功能权限
        public ActionResult RolesFunc()
        {
            //string ParentId = "00000000-0000-0000-0000-000000000000";
            //var FuncList = fBLL.GetModelList("f_ParentId='" + ParentId + "' and f_DeleteStateCode=0 and f_StatusCode=0 order by f_PaiX");
            var FuncList = fBLL.GetModelList(" f_DeleteStateCode=0 and f_StatusCode=0 order by f_PaiX");
            var FuncIds = rfdBLL.GetModelList(" r_ID='" + RequestBase.GetString("r_ID") + "'");

            string FuncMenuIds = "";
            foreach (Model.RolesFunctionDetails j in FuncIds)
            {
                FuncMenuIds += j.f_ID + ",";
            }
            @ViewData["hfItems"] = FuncMenuIds;
            @ViewData["hfRoleId"] = RequestBase.GetString("r_ID");
            return View(FuncList.ToList());

        }
        /// <summary>
        /// 角色功能的保存
        /// </summary>
        /// <param name="funid">功能id</param>
        /// <param name="otype">操作状态</param>
        /// <param name="roelid">角色id</param>
        /// <returns></returns>
        public string AddFRolesFunc(string funid, string roelid, string otype)
        {
            bool result = false;
            try
            {
                int i = 0;
                string sqlF = " f_ID='" + funid + "' and f_DeleteStateCode =0 and f_CengJ = 2";
                var FuncList = fBLL.GetModelList(sqlF);

                if (FuncList.Count() > 0)
                {//为全选
                    //var FuncIds = from funct in FunctDb.GetFunctionBases()
                    //              where funct.f_ParentId == new Guid(funid) && funct.f_DeleteStateCode == 0
                    //              select funct.f_ID;
                    //string sqlF2 = " f_ParentId='" + funid + "' and f_DeleteStateCode=0 ";
                    //var FuncIds = fBLL.GetModelList(sqlF2);
                    StringBuilder sqlSel = new StringBuilder();
                    string strSql = "";
                    StringBuilder sqlSel2 = new StringBuilder();
                    string strSql2 = "";
                    //if (FuncIds.Count() > 0)
                    //{//全选且有子集
                        if (otype == "del")
                        {
                            i = rfdBLL.DelAll(roelid, funid) ? 1 : 0;
                            //sqlSel.Append(" delete from RolesFunctionDetails where r_ID='" + roelid + "' and f_ID in(");
                            //foreach (Guid j in FuncIds)
                            //{
                            //    sqlSel.Append("'" + j.ToString() + "',");
                            //}
                            //sqlSel.Append("#");
                            //strSql = sqlSel.ToString().Replace(",#", "").Replace("#", "");
                            //strSql = strSql + ")";
                            //i = EnergyContext.Database.ExecuteSqlCommand(strSql);
                        }
                        if (otype == "add")
                        {//先删再加
                            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                            //{
                            //    sqlSel.Append(" delete from RolesFunctionDetails where r_ID='" + roelid + "' and f_ID in(");
                            //    foreach (Guid j in FuncIds)
                            //    {
                            //        sqlSel.Append("'" + j.ToString() + "',");
                            //    }
                            //    sqlSel.Append("#");
                            //    strSql = sqlSel.ToString().Replace(",#", "").Replace("#", "");
                            //    strSql = strSql + ")";
                            //    i = EnergyContext.Database.ExecuteSqlCommand(strSql);

                            //    sqlSel2.Append("insert into RolesFunctionDetails ");
                            //    foreach (Guid j in FuncIds)
                            //    {
                            //        sqlSel2.Append(" select '" + roelid + "','" + j.ToString() + "' union ");
                            //    }
                            //    sqlSel2.Append("#");
                            //    strSql2 = sqlSel2.ToString().Replace("union #", "").Replace("#", "");
                            //    i = EnergyContext.Database.ExecuteSqlCommand(strSql2);
                            //    scope.Complete();
                            //}
                        }
                    //}
                    //else { i = 3; }
                }
                else
                {//单选时
                    if (otype == "del")
                    {
                        i = rfdBLL.Delete(new Guid(roelid), new Guid(funid)) ? 1 : 0;
                    }
                    else { i = rfdBLL.Add(roelid, funid) ? 1 : 0; }
                }

                if (i > 0)
                {
                    if (i == 3)
                    {
                        return "没有数据";
                    }
                    else
                    {
                        result = true;
                        return "操作成功！！";
                    }
                }
                else
                {
                    return "操作失败！！";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        #endregion
    }
}
