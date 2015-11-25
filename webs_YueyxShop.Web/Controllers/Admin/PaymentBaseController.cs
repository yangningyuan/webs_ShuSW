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
    public class PaymentBaseController : BaseController
    {
        private readonly RoleManager _roleManager = new RoleManager();
        private readonly BLL.PaymentBase _paymentBase = new BLL.PaymentBase();
        public ActionResult PaymentBaseMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            return View();
        }

        public ActionResult PaymentBaseList()
        {
            int total = 0;//总行数
            int pageSize = 30;//每一页的行数
            int pageNumber = 1;//当前页数 
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            var list = _paymentBase.GetModelList(" pay_IsDel = 0");
            total = list.Count();
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            return View(list.ToPagedList(pageNumber, pageSize));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult PaymentBaseEdit()
        {
            Model.PaymentBase ptmodel = new Model.PaymentBase();
            this.ViewData["otype"] = RequestBase.GetString("otype");

            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            if (RequestBase.GetString("otype") == "modify")
            {
                int id = int.Parse(RequestBase.GetString("pay_ID"));
                ptmodel = _paymentBase.GetModel(id);
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
        public ActionResult PaymentBaseEdit(Model.PaymentBase producttype)
        {
            bool result = false;
            if (Request.Form["otype"] == "add")
            {
                result = _paymentBase.Add(producttype);
            }
            else
            {
                Model.PaymentBase newpt = _paymentBase.GetModel(producttype.pay_ID);
                newpt.pay_Name = producttype.pay_Name;
                newpt.pay_Url = producttype.pay_Url;
                newpt.pay_isPhone = newpt.pay_isPhone;
                result = _paymentBase.Update(newpt);
            }
            if (result)
            {
                return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功！！", "", "forward", "closeCurrent", "PaymentBox", ""));
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
        public ActionResult PaymentBaseDelete()
        {
            bool result = false;
            string Message = "";
            try
            {
                string pid = RequestBase.GetString("pay_ID");
                result = _paymentBase.Delete(int.Parse(pid));
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "删除成功！！", "", "forward", "", "PaymentBox", ""));
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
    }
}