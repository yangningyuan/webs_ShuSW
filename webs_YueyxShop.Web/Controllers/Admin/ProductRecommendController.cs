using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using PagedList;
using System.Text;
using System.Data;

namespace webs_YueyxShop.Web.Controllers
{
    public class ProductRecommendController : BaseController
    {
        private readonly BLL.SKUBase _skuBase = new BLL.SKUBase();
        private readonly BLL.ProductBase _product = new BLL.ProductBase();
        private readonly BLL.ProductRecommendDetail _productRecommendDetail = new BLL.ProductRecommendDetail();
        private readonly BLL.ProductRecommendTypeBase _productRecommendTypeBase = new BLL.ProductRecommendTypeBase();
        private readonly RoleManager _roleManager = new RoleManager();

        public ActionResult ProductRecommendMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            ViewData["prt_ID"] = RequestBase.GetString("prt_ID");
            if (ViewData["prt_ID"] != null && !string.IsNullOrWhiteSpace(ViewData["prt_ID"].ToString()))
            {
                try
                {
                    var model = _productRecommendTypeBase.GetModel(Convert.ToInt32(ViewData["prt_ID"]));
                    ViewData["prt_Name"] = model.prt_Name;
                }
                catch
                { }
            }
            return View();
        }

        public ActionResult ProductRecommendList()
        {
            string id = RequestBase.GetString("prt_ID");
            ViewData["prt_ID"] = id;
            int total = 0;//总行数
            int pageSize = 25;//每一页的行数
            int pageNumber = 1;//当前页数 
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }

            var list = _productRecommendDetail.GetRecommendProductList("and prt_ID = " + id + "and prd_IsDelete = 0");

            total = list.Rows.Count;
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            //ViewData["PageList"] = list;
            ViewData["PageList"] = GetPagedTable(list, pageNumber, pageSize); 
            return View(ViewData["PageList"]);
        }

        public ActionResult ProductRecommendEdit()
        {
            return View();
        }

        public ActionResult ProductRecommendChange()
        {
            try
            {
                ViewData["otype"] = RequestBase.GetString("otype");
                string id = RequestBase.GetString("prd_ID");
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update ProductRecommendDetail ");
                switch (ViewData["otype"].ToString())
                {
                    case "delete"://删除单个
                        strSql.Append(" set prd_IsDelete = 1 where prd_ID = " + id);
                        break;
                    case "clear"://清空
                        string prt_ID = RequestBase.GetString("prt_ID");
                        strSql.Append(" set prd_IsDelete = 1 where prt_ID = " + prt_ID);
                        break;
                    case "enable"://启用
                        strSql.Append(" set prd_Status = 0 where prd_ID = " + id);
                        break;
                    case "disable"://禁用
                        strSql.Append(" set prd_Status = 1 where prd_ID = " + id);
                        break;
                    default:
                        strSql.Append(" set prd_Status = prd_Status ");
                        break;
                }

                if (_productRecommendDetail.ExecuteNonQuery(strSql.ToString()))
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功！！", "", "forward", "", "ProductRecommendBox", ""));
                }
            }
            catch
            {
            }
            return Content(DWZUtil.GetResultJson("300", "操作失败！！", "", "", ""));
        }

        public ActionResult SelectProductsMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            ViewData["prt_ID"] = RequestBase.GetString("prt_ID");


            List<Model.ProductTypeBase> modelType = new BLL.ProductTypeBase().GetModelList(" pt_parentId = 0 and pt_IsDel=0 and pt_StatusCode=0");
            List<SelectListItem> selectTypeTui = new List<SelectListItem>();
            selectTypeTui = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            for (int i = 0; i < modelType.Count; i++)
            {
                selectTypeTui.Add(new SelectListItem
                {
                    Value = modelType[i].pt_ID.ToString(),
                    Text = modelType[i].pt_Name
                });
            }
            ViewData["selectTypeTui"] = new SelectList(selectTypeTui, "Value", "Text", "请选择");
            return View();
        }

        public ActionResult SelectProductsList()
        {
            int total = 0;//总行数
            int pageSize = 25;//每一页的行数
            int pageNumber = 1;//当前页数
            string sortby = "";
            int prtid = 0;
            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            if (!string.IsNullOrEmpty(Request.Form["prt_ID"]))
            {
                prtid = Convert.ToInt32(Request.Form["prt_ID"]);
            }

            # region 查询条件

            //StringBuilder strSql = new StringBuilder();

            //if (!string.IsNullOrWhiteSpace(RequestBase.GetString("txtPrName")))
            //{
            //    strSql.Append(" and p_Name like '%" + RequestBase.GetString("txtPrName") + "%'");
            //}
            //if (!string.IsNullOrWhiteSpace(RequestBase.GetString("txtPtName")))
            //{
            //    strSql.Append(" and pt_Name like '%" + RequestBase.GetString("txtPtName") + "%'");
            //}
            //if (!string.IsNullOrWhiteSpace(RequestBase.GetString("txtBName")))
            //{
            //    strSql.Append(" and b_Name like '%" + RequestBase.GetString("txtBName") + "%'");
            //}
            ////if (!string.IsNullOrWhiteSpace(RequestBase.GetString("txtpSeSt")))
            ////{
            ////    strSql.Append(" and p_SellStatus = '%" + RequestBase.GetString("txtpSeSt") + "%'");
            ////}

            //# region 获取该类型下存在的商品pID

            //string prtID = RequestBase.GetString("prt_ID");
            //var _list = _productRecommendDetail.GetModelList("prt_ID = " + prtID + " and prd_IsDelete = 0");
            //string ids = "";
            //foreach (var id in _list)
            //{
            //    if (!string.IsNullOrWhiteSpace(ids))
            //    {
            //        ids += "," + id.p_ID;
            //    }
            //    else
            //    {
            //        ids = id.p_ID.ToString();
            //    }
            //}
            //string sql = "";
            //if (!string.IsNullOrWhiteSpace(ids))
            //{
            //    sql = " and p_ID not in (" + ids + ") order by pt_ID";
            //}
            //else
            //{
            //    sql = "";
            //}

            //# endregion

            //strSql.Append(sql);

           # endregion

            if (!string.IsNullOrEmpty(Request.Form["txtPrCode"]))
            {
                strSql.AppendFormat(" and p_ID in (select distinct p_id from SKUBase where sku_Code like '%{0}%') ", Request.Form["txtPrCode"]);
            }
            if (!string.IsNullOrEmpty(Request.Form["txtPrName"]))
            {
                strSql.AppendFormat(" and p_Name like'%{0}%'", Request.Form["txtPrName"]);
            }
            if (Request.Form["selectTypeTui"] != "chose")
            {

                if (!string.IsNullOrEmpty(Request.Form["selectTypeTui2"]) && Request.Form["selectTypeTui2"] != "chose")
                {
                    strSql.AppendFormat(" and pt_id={0}", Request.Form["selectTypeTui2"]);
                }
                else
                {
                    strSql.AppendFormat(" and pt_ID in(select pt_ID  from ProductTypeBase where pt_ParentId ={0})", Request.Form["selectType"]);
                }
            }
            //获取所有商品
            //var list = _product.GetProductDetail(strSql.ToString());

            List<Model.vw_PInfo> list = new BLL.vw_PInfo().GetModelList("  p_ID not in(select p_ID from   ProductRecommendDetail where prt_ID=" + prtid + " and prd_IsDelete=0) and p_IsDel=0 and p_SellStatus=1 and p_StatusCode=0   " + strSql);
            total = list.Count;
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            ViewBag.ProductsList = new BLL.vw_PInfo().GetModelList("   p_ID not in(select p_ID from   ProductRecommendDetail where prt_ID=" + prtid + " and prd_IsDelete=0) and p_IsDel=0 and p_StatusCode=0 and p_SellStatus=1   " + strSql, pageNumber, pageSize, sortby);
            //ViewData["PageList"] = list;
            //ViewData["PageList"] = GetPagedTable(list, pageNumber, pageSize); 
            return View(ViewBag.ProductsList);
        }

        public ActionResult AddProduct()
        {
            string pids = RequestBase.GetString("pids");
            string prtID = RequestBase.GetString("prtID");

            if (!string.IsNullOrWhiteSpace(pids) && !string.IsNullOrWhiteSpace(prtID))
            {
                string[] pidss = pids.Split(',');
                Model.ProductRecommendDetail model = new Model.ProductRecommendDetail();
                model.prd_IsDelete = false;
                model.prd_Status = false;
                foreach (string id in pidss)
                {
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        model.prt_ID = Convert.ToInt32(prtID);
                        model.p_ID = Convert.ToInt32(id);
                        _productRecommendDetail.Add(model);
                    }
                }
            }
            return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功！！", "", "forward", "", "ProductRecommendBox", ""));
        }

        public ActionResult Cancel()
        {
            return Content(DWZUtil.GetResultJson("300", "操作取消！！", "", "", "closeCurrent"));
        }
    }
}