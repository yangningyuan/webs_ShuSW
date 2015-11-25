using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using PagedList;
using System.Configuration;

namespace webs_YueyxShop.Web.Controllers
{
    public class ProductRecommendTypeController : BaseController
    {
        private readonly BLL.ProductRecommendTypeBase _productRecommendType = new BLL.ProductRecommendTypeBase();
        private readonly BLL.ProductRecommendDetail _productRecommendDetail = new BLL.ProductRecommendDetail();
        private readonly RoleManager _roleManager = new RoleManager();

        public ActionResult ProductRecommendTypeMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            return View();
        }

        public ActionResult ProductRecommendTypeList()
        {
            int total = 0;//总行数
            int pageSize = 25;//每一页的行数
            int pageNumber = 1;//当前页数 
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            var list = _productRecommendType.GetModelList("prt_IsDelete = 0");

            total = list.Count;
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            return View(list.ToPagedList(pageNumber, pageSize));
        }


        /// <summary>
        /// 编辑
        /// </summary>
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProductRecommendTypeEdit()
        {
            Model.ProductRecommendTypeBase ptmodel = new Model.ProductRecommendTypeBase();
            this.ViewData["Otype"] = RequestBase.GetString("otype");

            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            if (RequestBase.GetString("otype") == "modify")
            {
                string id = RequestBase.GetString("prt_ID");
                int ptid = int.Parse(id);
                ptmodel = _productRecommendType.GetModel(ptid);
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
        public ActionResult ProductRecommendTypeEdit(Model.ProductRecommendTypeBase productRecommend)
        {
            int result = 0;
            bool resultup = false;
            if (Request.Form["Otype"] == "add")
            {
                productRecommend.prt_IsDelete = false;
                productRecommend.prt_Status = false;
                result = _productRecommendType.Add(productRecommend);
            }
            else
            {
                Model.ProductRecommendTypeBase newpt = _productRecommendType.GetModel(productRecommend.prt_ID);
                newpt.prt_Name = productRecommend.prt_Name;
                newpt.prt_Title = productRecommend.prt_Title;
                newpt.prt_Directions = productRecommend.prt_Directions;
                resultup = _productRecommendType.Update(newpt);
            }
            if (result > 0 || resultup)
            {
                return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功！！", "", "forward", "closeCurrent", "ProductRecommendTypeBox", ""));
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
        public ActionResult ProductRecommendTypeDelete()
        {

            bool result = false;
            string Message = "";
            try
            {
                string id = RequestBase.GetString("prt_ID");
                var model = _productRecommendDetail.GetModelList(" prt_ID = " + id + " and prd_IsDelete = 0");
                if (model.Count > 0)
                {
                    Message = "该推荐类型下有推荐的商品，不允许删除！";
                    return Content(DWZUtil.GetResultJson("300", Message, "", "", ""));
                }
                result = _productRecommendType.Delete(int.Parse(id));
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "删除成功！！", "", "forward", "", "ProductRecommendTypeBox", ""));
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
        /// 启/禁用
        /// </summary>
        /// <param name="otype"></param>
        /// <param name="dli_id"></param>
        /// <returns></returns>
        public ActionResult ProductRecommendTypeEnable(string otype, string dli_id)
        {

            bool result = false;
            try
            {
                string pid = RequestBase.GetString("prt_ID");
                Model.ProductRecommendTypeBase model = _productRecommendType.GetModel(int.Parse(pid));
                if (otype == "disable")
                {
                    model.prt_Status = false;
                }
                else
                {
                    model.prt_Status = true;
                }
                result = _productRecommendType.Update(model);
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "forward", "", "ProductRecommendTypeBox", ""));
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
    }
}
