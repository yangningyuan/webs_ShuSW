using System;
using System.Linq;
using System.Web.Mvc;
using webs_YueyxShop.BLL;
using Common;
using webs_YueyxShop.Model;
using PagedList;
using System.Collections.Generic;

namespace webs_YueyxShop.Web
{
    public class MenuBaseController : BaseController
    {
        private RoleManager Rolemanager = new RoleManager();
        private BLL.MenuBase mbBLL = new BLL.MenuBase();
        public ActionResult MenuBaseMsg()
        {
            // ViewData["IsHasFunRole"] = Rolemanager.IsHasFunRole(EmployeeInfo.e_ID, "001001001");//是否拥有管理的权限
            ViewData["IsHasFunRole"] = true;
            return View();
        }

        [HttpPost]
        public ActionResult MenuBaseList()
        {
            int total = 0;//总行数
            int pageSize = 25;//每一页的行数
            int pageNumber = 1;//当前页数 
            string ParentId = "00000000-0000-0000-0000-000000000000";
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            if (RequestBase.GetString("hfPid") != "")
            {
                ParentId = RequestBase.GetString("hfPid");
            }
            var mlist = mbBLL.GetModelList(" m_ParentId='" + ParentId + "' and m_DeleteStateCode=0 order by m_PaiX");

            total = mlist.Count();
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            return View(mlist.ToPagedList(pageNumber, pageSize));
        }
        #region 编辑
        //[RoleActionFilterAttribute(FunctionCode = "006004001", ViewType = "dialog")]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult MenuBaseEdit()
        {
            ViewData["IsShow"] = false;//是否显示资讯信息(顶级或系统管理不显示)
            ViewData["hfShow"] = true;
            BindControl bc = new BindControl();
            ViewData["mPageType"] = bc.BindSysCodeBase("0001", 2, false, false);//资讯类型
            // ViewData["IsHasFunRole"] = Rolemanager.IsHasFunRole(EmployeeInfo.e_ID, "001001001");//是否拥有管理的权限
            ViewData["IsHasFunRole"] = true;
            Model.MenuBase model = new Model.MenuBase();
            this.ViewData["texOtype"] = RequestBase.GetString("otype");
            switch (RequestBase.GetString("otype"))
            {
                case "modify":
                    string ids = RequestBase.GetString("dli_id");
                    Guid id = new Guid(ids.Split('|')[0]);
                    model = mbBLL.GetModel(id);
                    ViewData["hfShow"] = model.m_IsShow;//是否显示导航
                    //系统管理
                    string bianm = model.m_BianM.Trim();
                    if (bianm.Substring(0, 3) == "002" && bianm.Length != 3)
                    { ViewData["IsShow"] = true; }
                    return View(model);
                default:
                    string pids = RequestBase.GetString("dli_id");
                    ViewData["hfPId"] = pids;
                    string pid = pids.Split('|')[0];
                    if (pid != "00000000-0000-0000-0000-000000000000")
                    {
                        string pbianm = pids.Split('|')[2];
                        if (pbianm.Substring(0, 3) == "002")
                            ViewData["IsShow"] = true;
                    }
                    return View();
            }
        }

        /// <summary>
        /// 添加/修改
        /// </summary>
        public ActionResult MenuBaseEdit(Model.MenuBase menuBase)
        {
            bool result = false;
            string Message = "";
            try
            {
                if (Request.Form["texOtype"] == "add")
                {
                    menuBase.m_ID = Guid.NewGuid();
                    menuBase.m_CreatedOn = DateTime.Now;
                    menuBase.m_StateCode = 0;
                    menuBase.m_DeleteStateCode = 0;

                    string parent = Request.Form["hfPId"];
                    menuBase.m_ParentId = new Guid(parent.Split('|')[0]);
                    int mcengj = Convert.ToInt32(parent.Split('|')[1]) + 1;
                    menuBase.m_CengJ = mcengj;
                    string ParentBianma = parent.Split('|')[2];
                    menuBase.m_CreatedBy = EmployeeBase.e_ID;
                    //自动生成编码
                    string BianMa = mbBLL.GetCode(ParentBianma, mcengj);
                    menuBase.m_BianM = BianMa;//001003
                    int sort = mbBLL.GetSort(parent.Split('|')[0].ToString(), mcengj);
                    menuBase.m_PaiX = sort; 
                    menuBase.m_BianM = BianMa;
                    menuBase.m_Path = menuBase.m_Path == null ? "" : menuBase.m_Path.Trim();
                    menuBase.m_IsShow = Request.Form["hfShow"].ToLower() == "true" ? true : false;
                    result = mbBLL.Add(menuBase);
                }
                else
                {
                    Model.MenuBase NewMenu = mbBLL.GetModel(menuBase.m_ID);
                    NewMenu.m_MingCh = menuBase.m_MingCh;
                    NewMenu.m_Path = menuBase.m_Path == null ? "" : menuBase.m_Path.Trim();
                    NewMenu.m_PageType = menuBase.m_PageType;
                    menuBase.m_IsShow = Request.Form["hfShow"].ToLower() == "true" ? true : false;
                    result = mbBLL.Update(NewMenu);
                }
                if (result)
                {
                    Message = "保存成功！";
                    return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功！！", "", "", "closeCurrent", "MenuBox", ""));
                }
                else
                {
                    Message = "程序异常，保存失败";
                    return Content(DWZUtil.GetResultJson("300", "保存失败！！", "", "", ""));
                }
            }
            catch
            {
                Message = "程序异常，保存失败";
                return Content(DWZUtil.GetResultJson("300", "保存失败！！", "", "", ""));
            }
        }
        #endregion

        #region 删除
        public ActionResult Delete()
        {
            bool result = false;
            string Message = "";
            try
            {
                string id = RequestBase.GetString("dli_id");
                Guid MenuId = new Guid(id.Split('|')[0]);
                Model.MenuBase NewMenu = mbBLL.GetModel(MenuId);
                NewMenu.m_DeleteStateCode = 1;
                result = mbBLL.Update(NewMenu);
                if (result)
                {
                    Message = "删除成功！";
                    return Content(DWZUtil.GetAjaxTodoJson("200", Message, "", "", "", "MenuBox", ""));
                }
                else
                {
                    Message = "程序异常，删除失败";
                    return Content(DWZUtil.GetResultJson("300", Message, "", "", ""));
                }
            }
            catch
            {
                Message = "程序异常，删除失败";
                return Content(DWZUtil.GetResultJson("300", Message, "", "", ""));
            }
        }
        #endregion

        #region 启，禁用
        public ActionResult Enable(string otype, string dli_id)
        {
            bool result = false;
            try
            {
                Guid MenuId = new Guid(dli_id.Split('|')[0]);
                Model.MenuBase NewMenu = mbBLL.GetModel(MenuId);
                if (otype == "disable")
                {
                    NewMenu.m_StateCode = 1;
                }
                else
                {
                    NewMenu.m_StateCode = 0;
                }
                result = mbBLL.Update(NewMenu);
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "", "", "MenuBox", ""));
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "操作失败！！", "", "", ""));
                }
            }
            catch (Exception ex)
            {
                return Content(DWZUtil.GetResultJson("300", "操作失败！！", "", "", ""));
            }
        }
        #endregion
    }
}
