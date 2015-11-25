using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using webs_YueyxShop.BLL;
using Common;
using webs_YueyxShop.Model;
using PagedList;

namespace webs_YueyxShop.Web
{
    public class DepartmentBaseController : BaseController
    {
        private RoleManager Rolemanager = new RoleManager();
        private BLL.DepartmentBase dBLL = new BLL.DepartmentBase();
        public ActionResult DepartmentBaseMsg()
        {
            ViewData["IsHasFunRole"] = Rolemanager.IsHasFunRole(EmployeeBase.e_ID, "001006001");//是否拥有管理的权限
            return View();
        }

        #region 获取数据列表
        [HttpPost]
        public ActionResult DepartmentBaseList()
        {
            #region
            int pageSize = 20;
            //当前页
            int pageNumber = 1;
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(" d_DeleteStateCode=0 ");
            //var departmentList = from depart in unit.db_Department.All()
            //                     where depart.d_DeleteStateCode == 0
            //                     select depart;

            string hfpid = RequestBase.GetString("hf_pid");
            if (hfpid.Trim() != "")
            {
                sqlStr.Append(" and d_ParentId='" + hfpid.Trim() + "'");
            }
            sqlStr.Append(" order by d_CreatedOn");
            var departmentList = dBLL.GetModelList(sqlStr.ToString());
            //查询总条数
            int total = departmentList.Count();

            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            return View(departmentList.ToPagedList(pageNumber, pageSize));

            #endregion
        }
        #endregion

        #region 读取数据
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult DepartmentBaseEdit()
        {
            ViewData["IsHasFunRole"] = Rolemanager.IsHasFunRole(EmployeeBase.e_ID, "001006001");//是否拥有管理的权限
            Model.DepartmentBase model = new Model.DepartmentBase();
            this.ViewData["texOtype"] = RequestBase.GetString("otype");
            BindControl bc = new BindControl();
            ViewData["Guoji"] = bc.BindSysCodeBase("0002", 2, true, true);
            ViewData["c_name"] = "";//暂时无用 2014-8-29
            switch (RequestBase.GetString("otype"))
            {
                case "modify":
                    Guid id = new Guid(RequestBase.GetString("dli_id").Split('|')[0]);
                    model = dBLL.GetModel(id);
                    //ViewData["c_id"] = model.cs_ID;
                    //ViewData["c_name"] = new EnergyBLL.CollegeSchoolBase().GetModel(model.cs_ID).cs_MingCh;
                    return View(model);
                case "details":
                    Guid id1 = new Guid(RequestBase.GetString("dli_id").Split('|')[0]);
                    model = dBLL.GetModel(id1);
                    //ViewData["c_id"] = model.cs_ID;
                    //ViewData["c_name"] = new EnergyBLL.CollegeSchoolBase().GetModel(model.cs_ID).cs_MingCh;
                    return View(model);
                default:
                    this.ViewData["pid"] = RequestBase.GetString("pid");
                    //if (RequestBase.GetString("pid") != "00000000-0000-0000-0000-000000000000")
                    //{
                    //    model = dBLL.GetModel(new Guid(RequestBase.GetString("pid")));
                    //    //ViewData["c_id"] = model.cs_ID;
                    //    //ViewData["c_name"] = new EnergyBLL.CollegeSchoolBase().GetModel(model.cs_ID).cs_MingCh;
                    //}
                    this.ViewData["hfcengj"] = RequestBase.GetString("cengj");
                    this.ViewData["hfbianm"] = RequestBase.GetString("bianm");
                    return View();
            }
        }
        #endregion

        #region 添加/修改
        /// <summary>
        /// 添加/修改
        /// </summary>
        public ActionResult DepartmentBaseEdit(Model.DepartmentBase department)
        {
            bool result = false;
            bool count = false;
            try
            {
                if (Request.Form["texOtype"] == "add")
                {
                    department.cs_ID =0;//所属院系已经无用
                    department.d_ID = Guid.NewGuid();
                    department.d_CreatedOn = DateTime.Now;
                    department.d_CreatedBy = EmployeeBase.e_ID;
                    department.d_ParentId = new Guid(Request.Form["pid"]);
                    department.d_CengJ = Convert.ToInt32(Request.Form["hfcengj"]) + 1;
                    department.d_BianM = dBLL.GetCode(department.d_CengJ, Request.Form["hfbianm"]);
                    department.d_StateCode = 0;
                    //   var dIds = Context.Database.SqlQuery<DepartmentBase>("select * from dbo.DepartmentBase where  d_DeleteStateCode=0 and  d_MingCh='" + department.d_MingCh + "'").ToList();
                    //count = dIds.Count;
                    count = dBLL.IsExists("", department.d_MingCh);

                }
                else
                {
                    //var dIds = Context.Database.SqlQuery<DepartmentBase>("select * from dbo.DepartmentBase where  d_DeleteStateCode=0 and d_ID<>'" + department.d_ID + "' and d_MingCh='" + department.d_MingCh + "'").ToList();
                    //count = dIds.Count();
                    count = dBLL.IsExists(department.d_ID.ToString(), department.d_MingCh);
                }
                if (count)
                {
                    return Content(DWZUtil.GetResultJson("300", "该部门已经存在！", "", "", ""));
                }
                else
                {
                    if (Request.Form["texOtype"] == "add")
                    {
                        result = dBLL.Add(department);
                    }
                    else
                    {
                        using (var scope = new TransactionScope())
                        {
                            //department.cs_ID = RequestBase.GetFormInt("orgLookup.id", 0);
                            department.cs_ID = 0;//所属院系已经无用
                            result = dBLL.Update(department);
                            scope.Complete();
                        }
                    }
                    if (result)
                    {
                        return Content(DWZUtil.GetAjaxTodoJsonCallBack("200", "保存成功！", "", "", "DepartmentBaseM_load()", "", "", "true"));
                    }
                    else
                    {
                        return Content(DWZUtil.GetResultJson("300", "程序异常，保存失败", "", "", ""));
                    }
                }
            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "程序异常，保存失败", "", "", ""));
            }
            finally
            {
                int type = Request.Form["texOtype"] == "add" ? 0 : 1;
            }
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        public ActionResult Delete()
        {
            bool i = false;
            string Message = "";
            try
            {
                string d_id = RequestBase.GetString("dli_id").Split('|')[0];

                if (!string.IsNullOrEmpty(d_id))
                {
                    Guid did = new Guid(d_id);

                    if (dBLL.IsSub(did))
                    {
                        return Content(DWZUtil.GetAjaxTodoJson("200", "包含下属机构，删除失败！", "", "", "", "DepartmentBox", ""));
                    }
                    else
                    {
                        i = dBLL.Delete(new Guid(d_id));

                        if (i)
                        {
                            return Content(DWZUtil.GetAjaxTodoJson("200", "删除成功！", "", "", "", "DepartmentBox", ""));
                        }
                        else
                        {
                            return Content(DWZUtil.GetResultJson("300", "程序异常，保存失败", "", "", ""));
                        }
                    }
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "程序异常，保存失败", "", "", ""));
                }
            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "程序异常，设置失败", "", "", ""));
            }
        }
        #endregion

        #region 存在、关闭
        /// <summary>
        /// 修改状态
        /// </summary>
        public ActionResult UpdateState()
        {
            bool result = false;
            string Message = "";
            try
            {
                string d_id = RequestBase.GetString("dli_id").Split('|')[0];
                string statecode = RequestBase.GetString("type");
                if (statecode == "able")
                {
                    result = dBLL.UpdateState(0, new Guid(d_id));
                }
                else
                {
                    result = dBLL.UpdateState(1, new Guid(d_id));
                }
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "更改成功！", "", "", "", "DepartmentBox", ""));
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "程序异常，保存失败", "", "", ""));
                }
            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "程序异常，设置失败", "", "", ""));
            }
        }
        #endregion


        #region 选择部门数据列表
        public ActionResult SelectDepartmentBaseMsg()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SelectDepartmentBaseList()
        {
            int pageSize = 20;
            //当前页
            int pageNumber = 1;
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(" d_DeleteStateCode=0 and d_StateCode=0");
            string hfpid = RequestBase.GetString("hf_pid");
            if (hfpid.Trim() != "")
            {
                sqlStr.AppendFormat(" and d_ParentId='{0}'", hfpid.Trim());
            }
            sqlStr.Append(" order by d_CreatedOn");
            var departmentList = dBLL.GetModelList(sqlStr.ToString());
            //查询总条数
            int total = departmentList.Count();

            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            return View(departmentList.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        //#region 选择院系下属部门数据列表
        //public ActionResult SelectCsDepartmentBaseMsg()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult SelectCsDepartmentBaseList()
        //{
        //    int pageSize = 20;
        //    //当前页
        //    int pageNumber = 1;
        //    if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
        //    {
        //        pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
        //    }
        //    StringBuilder sqlStr = new StringBuilder();
        //    sqlStr.Append(" d_DeleteStateCode= 0");
        //    string hfpid = RequestBase.GetString("hf_pid");
        //    if (hfpid.Trim() != "")
        //    {
        //        sqlStr.AppendFormat(" and d_ParentId='{0}'", hfpid.Trim());
        //    }
        //    sqlStr.Append(" order by d_CreatedOn");
        //    var departmentList = dBLL.GetModelList(sqlStr.ToString());
        //    //查询总条数
        //    int total = departmentList.Count();

        //    this.ViewData["TotalCount"] = total.ToString();
        //    this.ViewData["NumberPage"] = pageSize.ToString();
        //    this.ViewData["PagenumShown"] = "10";
        //    this.ViewData["CurrentPage"] = pageNumber.ToString();
        //    return View(departmentList.ToPagedList(pageNumber, pageSize));
        //}
        //#endregion

        public ActionResult DepartmentTree()
        {
            ViewData["otype"] = RequestBase.GetQueryString("otype");
            if (RequestBase.GetString("otype") != "add")
            {
                ViewData["d_id"] = new Guid(RequestBase.GetString("dli_id").Split('|')[0]);
                ViewData["dli_id"] = RequestBase.GetQueryString("dli_id");
                return View();
            }
            else
            {
                this.ViewData["pid"] = RequestBase.GetString("pid");
                this.ViewData["hfcengj"] = RequestBase.GetString("cengj");
                this.ViewData["hfbianm"] = RequestBase.GetString("bianm");
                return View();
            }
        }
    }
}
