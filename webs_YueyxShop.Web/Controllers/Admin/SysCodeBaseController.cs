using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Common;
using System.Linq.Expressions;
using System.Text;
using webs_YueyxShop.Model;
using webs_YueyxShop.BLL;
using PagedList;
using System.Reflection.Emit;


namespace webs_YueyxShop.Web
{
    public class SysCodeBaseController : BaseController
    {
        private RoleManager Rolemanager = new RoleManager();
        private BLL.SysCodeBase sBLL = new BLL.SysCodeBase();
        public ActionResult SysCodeBaseMsg()
        {
            //ViewData["IsHasFunRole"] = Rolemanager.IsHasFunRole(EmployeeInfo.e_ID, "001005001");//是否拥有管理的权限
            ViewData["IsHasFunRole"] = true;
            ViewData["Type"] = RequestBase.GetQueryString("type");
            return View();
        }
        #region 列表页
        [HttpPost]
        public ActionResult SysCodeBaseList()
        {
            int pageSize = 30;
            //当前页
            int pageNumber = 1;
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            StringBuilder sqlStr = new StringBuilder();
            string pid = RequestBase.GetString("hf_pid");
            sqlStr.AppendFormat(" sc_DeleteStateCode=0 and sc_LeiB=0 and sc_ParentId='{0}'", pid);

            string type = RequestBase.GetString("type");
            if (type != "" && new Guid(pid) == Guid.Empty)
            {
                sqlStr.AppendFormat(" and sc_SuoSMK like'%{0}%'", type);
            }
            sqlStr.Append(" order by sc_BianM");

            var syscodebaseList = sBLL.GetModelList(sqlStr.ToString());

            //查询总条数
            int total = syscodebaseList.Count();

            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            return View(syscodebaseList.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region 添加、编辑 保存
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult SysCodeBaseEdit()
        {
            //ViewData["IsHasFunRole"] = Rolemanager.IsHasFunRole(EmployeeInfo.e_ID, "001005001");//是否拥有管理的权限
            ViewData["IsHasFunRole"] = true;
            Model.SysCodeBase model = new Model.SysCodeBase();
            this.ViewData["texOtype"] = RequestBase.GetString("otype");
            switch (RequestBase.GetString("otype"))
            {
                case "modify":
                    Guid id = new Guid(RequestBase.GetString("sc_ID").Split('|')[0]);
                    model = sBLL.GetModel(id);
                    this.ViewData["pid"] = model.sc_ParentId;
                    return View(model);
                case "details":
                    Guid id1 = new Guid(RequestBase.GetString("sc_ID").Split('|')[0]);
                    model = sBLL.GetModel(id1);
                    this.ViewData["pid"] = model.sc_ParentId;
                    return View(model);
                default:
                    this.ViewData["pid"] = RequestBase.GetString("pid");
                    this.ViewData["hfcengj"] = RequestBase.GetString("cengj");
                    this.ViewData["hfbianm"] = RequestBase.GetString("bianm");
                    return View();
            }
        }

        /// <summary>
        /// 添加/修改
        /// </summary>
        public ActionResult SysCodeBaseEdit(Model.SysCodeBase Model)
        {
            bool result = false;
            try
            {
                if (Request.Form["texOtype"] == "add")
                {
                    Model.sc_SuoSMK = Model.sc_SuoSMK == null ? "" : Model.sc_SuoSMK;
                    Model.sc_ID = Guid.NewGuid();
                    Model.sc_LeiB = 0;//0普通 1系统
                    Model.sc_CreatedOn = DateTime.Now;
                    Model.sc_CreatedBy = EmployeeBase.e_ID;
                    Model.sc_ParentId = new Guid(Request.Form["pid"]);
                    Model.sc_CengJ = Convert.ToInt32(Request.Form["hfcengj"]) + 1;
                    Model.sc_BianM = sBLL.GetCode(Model.sc_CengJ, Request.Form["hfbianm"]);
                    Model.sc_StateCode = 0;

                    result = sBLL.Add(Model);
                }
                else
                {
                    Model.sc_SuoSMK = Model.sc_SuoSMK == null ? "" : Model.sc_SuoSMK;
                    result = sBLL.Update(Model);
                }
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功！！", "", "", "closeCurrent", "SysCodeBaseBox", ""));
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "保存失败！！", "", "", ""));
                }
            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "保存失败！！", "", "", ""));
            }
        }
        #endregion

        #region 删除
        public ActionResult Delete()
        {
            bool result = false;
            try
            {
                string sc_ID = RequestBase.GetString("sc_ID").Split('|')[0];
                Guid MenuId = new Guid(sc_ID);
                Model.SysCodeBase NewMenu = sBLL.GetModel(MenuId);
                NewMenu.sc_DeleteStateCode = 1;
                result = sBLL.Update(NewMenu);
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "删除成功！！", "", "", "", "SysCodeBaseBox", ""));
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "删除失败！！", "", "", ""));
                }
            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "删除失败！！", "", "", ""));
            }
        }
        #endregion


        #region 选择列表
        public ActionResult SelectSysCodeBaseMsg()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SelectSysCodeBaseList()
        {
            int pageSize = 30;
            //当前页
            int pageNumber = 1;
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append(" sc_DeleteStateCode=0");
            string hfpid = RequestBase.GetString("hf_pid");
            if (hfpid.Trim() != "")
            {
                sqlStr.AppendFormat(" and sc_ParentId='{0}'",hfpid.Trim());
            }
            sqlStr.Append(" order by sc_CreatedOn");
            var syscodebaseList = sBLL.GetModelList(sqlStr.ToString());
            //查询总条数
            int total = syscodebaseList.Count();

            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "5";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            return View(syscodebaseList.ToPagedList(pageNumber, pageSize));
        }
        #endregion
    }
}
