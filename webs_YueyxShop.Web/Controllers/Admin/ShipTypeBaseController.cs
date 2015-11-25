using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using PagedList;

namespace webs_YueyxShop.Web.Controllers
{
    /// <summary>
    /// 付款方式
    /// </summary>
    public class ShipTypeBaseController : BaseController
    {
        private readonly RoleManager _roleManager = new RoleManager();
        private readonly BLL.ShipTypeBase _ShipTypeBase = new BLL.ShipTypeBase();
        public ActionResult ShipTypeBaseMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            return View();
        }

        public ActionResult ShipTypeBaseList()
        {
            int total = 0;//总行数
            int pageSize = 30;//每一页的行数
            int pageNumber = 1;//当前页数 
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            var list = _ShipTypeBase.GetModelList(" st_IsDel = 0");
            total = list.Count();
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            return View(list.ToPagedList(pageNumber, pageSize));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ShipTypeBaseEdit()
        {
            Model.ShipTypeBase ptmodel = new Model.ShipTypeBase();
            this.ViewData["otype"] = RequestBase.GetString("otype");

            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            if (RequestBase.GetString("otype") == "modify")
            {
                int id = int.Parse(RequestBase.GetString("st_ID"));
                ptmodel = _ShipTypeBase.GetModel(id);
                return View(ptmodel);
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// 修改/添加
        /// </summary>
        public ActionResult ShipTypeBaseEdit(Model.ShipTypeBase shipType)
        {
            bool result = false;
            if (Request.Form["otype"] == "add")
            {
                result = _ShipTypeBase.Add(shipType);
            }
            else
            {
                Model.ShipTypeBase newpt = _ShipTypeBase.GetModel(shipType.st_ID);
                newpt.st_Name = shipType.st_Name;
                result = _ShipTypeBase.Update(newpt);
            }
            if (result)
            {
                return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功！！", "", "forward", "closeCurrent", "ShipTypeBox", ""));
            }
            else
            {
                return Content(DWZUtil.GetResultJson("300", "保存失败！！", "", "", ""));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ShipTypeBaseDelete()
        {
            bool result = false;
            string Message = "";
            try
            {
                string pid = RequestBase.GetString("st_ID");
                result = _ShipTypeBase.Delete(int.Parse(pid));
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "删除成功！！", "", "forward", "", "ShipTypeBox", ""));
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

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ShipTypeBaseEnable()
        {
            bool result = false;
            string Message = "";
            try
            {
                string pid = RequestBase.GetString("st_ID");
                var model = _ShipTypeBase.GetModel(int.Parse(pid));
                switch (RequestBase.GetString("otype"))
                {
                    case "enable":
                        model.st_StatusCode = 0;
                        break;
                    case "disable":
                        model.st_StatusCode = 1;
                        break;
                }
                result = _ShipTypeBase.Update(model);
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "forward", "", "ShipTypeBox", ""));
                }
                else
                {
                    Message = "操作失败！";
                    return Content(DWZUtil.GetResultJson("300", Message, "", "", ""));
                }
            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "操作失败！！", "", "", ""));
            }
            finally
            {

            }
        }
    }
}