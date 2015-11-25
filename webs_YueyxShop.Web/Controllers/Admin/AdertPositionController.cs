using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using System.Text;
using PagedList;
using System.Data;
namespace webs_YueyxShop.Web.Controllers.Admin
{
    public class AdertPositionController : BaseController
    {

        private new BLL.AdertPositionBase apbll = new BLL.AdertPositionBase();
        private readonly RoleManager _roleManager = new RoleManager();
        //
        // GET: /AdertPosition/
        /// <summary>
        /// 广告位置管理页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AdertPositionMsg()
        {
            //List<SelectListItem> select1 = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "-1" }, new SelectListItem { Text = "分类广告", Value = "0" }, new SelectListItem { Text = "固定广告", Value = "1" } };
            //ViewData["adertposition"] = new SelectList(select1, "Value", "Text", "请选择");

            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限

            return View();
        }
        /// <summary>
        /// 广告位置列表
        /// </summary>
        /// <returns></returns>
        public ActionResult AdertPositionList()
        {

            int total = 0;//总行数
            int pageSize = 25;//每页25行
            int pageNumber = 1;//当前页
            StringBuilder sb = new StringBuilder();
            sb.Append(" p_Delete=0 ");//1代表已删除
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            //if (Request.Form["adertposition"].ToString() != "-1") 
            //{
            //    sb.Append(" and p_PositionExplain='" + Request.Form["adertposition"] + "'");
            //}

            if (!string.IsNullOrEmpty(RequestBase.GetString("txttitle")))
            {
                sb.Append(" and p_PositionName like '%" + RequestBase.GetString("txttitle") + "%'");
            }

            sb.Append(" order by p_ID");
            var cpt = apbll.GetModelList(sb.ToString());
            total = cpt.Count();
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            return View(cpt.ToPagedList(pageNumber, pageSize));
        }
        /// <summary>
        /// 广告位置添加
        /// </summary>
        /// <returns></returns>
        public ActionResult AdertPositionEdit()
        {
            //BLL.ProductTypeBase ptbll = new BLL.ProductTypeBase();
            //List<Model.ProductTypeBase> modelType = ptbll.GetModelList(" pt_ParentId = 0 and pt_IsDel=0");

            //List<SelectListItem> selectType = new List<SelectListItem>();
            //selectType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "-1" } };
            //for (int i = 0; i < modelType.Count; i++)
            //{
            //    selectType.Add(new SelectListItem
            //    {
            //        Value = modelType[i].pt_ID.ToString(),
            //        Text = modelType[i].pt_Name
            //    });
            //}
            //ViewData["AdertType"] = new SelectList(selectType, "Value", "Text", "请选择");
            //List<SelectListItem> select1 = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "-1" }, new SelectListItem { Text = "左边", Value = "0" }, new SelectListItem { Text = "下边", Value = "1" } };
            //ViewData["XianshiPosition"] = new SelectList(select1, "Value", "Text", "请选择");
            ViewData["otype"] = RequestBase.GetString("otype");
            if (RequestBase.GetString("p_ID") != null && RequestBase.GetString("p_ID") != "")
            {
                Model.AdertPositionBase apmodel = new Model.AdertPositionBase();
                apmodel = new BLL.AdertPositionBase().GetModel(int.Parse(RequestBase.GetString("p_ID")));

                Model.AdertPositionBase adert = new BLL.AdertPositionBase().GetModel(int.Parse(RequestBase.GetString("p_ID")));
                //DataSet ptdataset = new BLL.ProductTypeBase().GetList(" pt_Name='" + adert.p_PositionExplain + "'");
                //int ptid = int.Parse(ptdataset.Tables[0].Rows[0]["pt_ID"].ToString());
                //ViewData["AdertType"] = new SelectList(selectType, "Value", "Text", ptid);

                //if (adert.p_showposition == "0")//广告位置在左边时 
                //{
                //    ViewData["XianshiPosition"] = new SelectList(select1, "Value", "Text", 0);
                //}
                //else
                //{
                //    ViewData["XianshiPosition"] = new SelectList(select1, "Value", "Text", 1);
                //}
                return View(adert);
            }
            else
            {
                return View();
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Save(Model.AdertPositionBase model)
        {
            bool result = false;

            try
            {
                //if (Request.Form["XianshiPosition"] == "-1")
                // {
                //     return Content(DWZUtil.GetResultJson("300", "保存失败！！请选择广告显示位置", "", "", ""));
                // }
                // else
                // {
                if (Request.Form["txbotype"] == "add")
                {
                    //Model.ProductTypeBase ptmodel = new BLL.ProductTypeBase().GetModel(int.Parse(Request.Form["AdertType"]));
                    model.p_CreateUser = base.EmployeeBase.e_ID;
                    //model.p_PositionExplain = ptmodel.pt_Name;
                    //model.p_producttype = int.Parse(Request.Form["AdertType"].ToString());
                    //model.p_showposition = Request.Form["XianshiPosition"];
                    result = apbll.Add(model) > 0 ? true : false;

                }
                else
                {
                    //Model.ProductTypeBase ptmodel = new BLL.ProductTypeBase().GetModel(int.Parse(Request.Form["AdertType"]));
                    model.p_CreateUser = base.EmployeeBase.e_ID;
                    //model.p_PositionExplain = ptmodel.pt_Name;
                    //model.p_producttype = int.Parse(Request.Form["AdertType"].ToString());
                    model.p_showposition = Request.Form["XianshiPosition"];
                    result = apbll.Update(model);
                }
                //}

                if (result)
                {
                    return Content(DWZUtil.GetResultJson("200", "操作成功！！", "w_广告位置管理", "", "closeCurrent"));
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
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete()
        {
            string pid = RequestBase.GetString("p_ID");
            Model.AdertPositionBase apmodel = new Model.AdertPositionBase();
            apmodel = new BLL.AdertPositionBase().GetModel(int.Parse(pid));
            bool result = false;
            try
            {
                if (apmodel.p_PositionExplain == "1")
                {
                    return Content(DWZUtil.GetResultJson("300", "删除失败！！此广告位为固定广告位不能进行此操作！", "", "", ""));
                }
                else
                {
                    Model.AdertPositionBase adertposition = apbll.GetModel(int.Parse(RequestBase.GetString("p_ID")));
                    adertposition.p_Delete = 1;
                    result = apbll.Update(adertposition);
                    if (result)
                    {
                        return Content(DWZUtil.GetAjaxTodoJson("200", "删除成功！！", "w_广告位置管理", "", "forward", "AdertPositionBox", ""));
                    }
                    else
                    {
                        return Content(DWZUtil.GetResultJson("300", "删除失败！！", "", "", ""));
                    }
                }

            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "删除失败！！", "", "", ""));
            }

        }
        /// <summary>
        /// 启用
        /// </summary>
        /// <returns></returns>
        public ActionResult AdertPositionStatus()
        {
            bool result = false;
            int pid = int.Parse(RequestBase.GetString("p_ID"));
            try
            {
                Model.AdertPositionBase adertposition = apbll.GetModel(pid);
                if (adertposition.p_Status == 1)
                {
                    adertposition.p_Status = 0;
                    result = apbll.Update(adertposition);
                    if (result)
                    {
                        return Content(DWZUtil.GetAjaxTodoJson("200", "启用成功！！", "w_广告位置管理", "", "forward", "AdertPositionBaseBox", ""));
                    }
                    else
                    {
                        return Content(DWZUtil.GetResultJson("300", "启用失败！！", "", "", ""));
                    }
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "启用失败,此数据已启用，请不要重复操作！！", "", "", ""));
                }
            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "启用失败！！", "", "", ""));
            }
        }
        /// <summary>
        /// 禁用
        /// </summary>
        /// <returns></returns>
        public ActionResult AdertPositionEnd()
        {
            bool result = false;
            int pid = int.Parse(RequestBase.GetString("p_ID"));
            try
            {
                Model.AdertPositionBase adertposition = apbll.GetModel(pid);
                if (adertposition.p_Status == 0)
                {
                    adertposition.p_Status = 1;
                    result = apbll.Update(adertposition);
                    if (result)
                    {
                        return Content(DWZUtil.GetAjaxTodoJson("200", "禁用成功！！", "w_广告位置管理", "", "forward", "AdertPositionBaseBox", ""));
                    }
                    else
                    {
                        return Content(DWZUtil.GetResultJson("300", "禁用失败！！", "", "", ""));
                    }
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "禁用失败,此数据已禁用，请不要重复操作！！", "", "", ""));
                }
            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "启用失败！！", "", "", ""));
            }
        }
    }
}
