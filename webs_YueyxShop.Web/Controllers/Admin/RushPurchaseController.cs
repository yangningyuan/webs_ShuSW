using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using PagedList;
using System.Data.Common;
using Common;
using System.Configuration;
using System.Text;


namespace webs_YueyxShop.Web.Controllers
{
    public class RushPurchaseController : BaseController
    {
        private RoleManager Rolemanager = new RoleManager();
        private BLL.ProductBase pbll = new BLL.ProductBase();
        private BLL.RushPurchaseBase rpbll = new BLL.RushPurchaseBase();
        private BLL.vm_RPDetails vrpbll = new BLL.vm_RPDetails();
        private BLL.ProductTypeBase ptbll = new BLL.ProductTypeBase();
        private readonly RoleManager _roleManager = new RoleManager();

        #region 商品信息
        public ActionResult RushPurchaseMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限

            List<Model.ProductTypeBase> modelType = ptbll.GetModelList(" pt_parentId = 0  and pt_IsDel=0 and pt_StatusCode=0");
            List<SelectListItem> selectType = new List<SelectListItem>();
            selectType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            for (int i = 0; i < modelType.Count; i++)
            {
                selectType.Add(new SelectListItem
                {
                    Value = modelType[i].pt_ID.ToString(),
                    Text = modelType[i].pt_Name
                });
            }
            ViewData["selectType"] = new SelectList(selectType, "Value", "Text", "请选择");
            return View();
        }

        public ActionResult ProductsList()
        {
            int total = 0;//总行数
            int pageSize = 25;//每一页的行数
            int pageNumber = 1;//当前页数 
            string ptparentid = "0";
            string sortby = "";
            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            if (!string.IsNullOrEmpty(Request.Form["txtPrCode"]))
            {
                strSql.AppendFormat(" and p_ID in (select distinct p_id from SKUBase where sku_Code like '%{0}%') ", Request.Form["txtPrCode"]);
            }
            if (!string.IsNullOrEmpty(Request.Form["txtPrName"]))
            {
                strSql.AppendFormat(" and p_Name like'%{0}%'", Request.Form["txtPrName"]);
            }
            if (Request.Form["selectType"] != "chose")
            {

                if (!string.IsNullOrEmpty(Request.Form["selectType2"]) && Request.Form["selectType2"] != "chose")
                {
                    strSql.AppendFormat(" and pt_id={0}", Request.Form["selectType2"]);
                }
                else
                {
                    strSql.AppendFormat(" and pt_ID in(select pt_ID  from ProductTypeBase where pt_ParentId ={0})", Request.Form["selectType"]);
                }
            }
            if (RequestBase.GetString("hfPid") != "")
            {
                ptparentid = RequestBase.GetString("hfPid").ToString();
            }
            List<Model.vw_PInfo> list = new BLL.vw_PInfo().GetModelList(" p_IsDel=0 and p_SellStatus=1 and p_StatusCode=0   " + strSql);
            //var cpt = pbll.GetModelListById(" p_IsDel=0  and p_SellStatus=1 " + strSql);
            total = list.Count;
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            ViewBag.ProductsList = new BLL.vw_PInfo().GetModelList(" p_IsDel=0 and p_StatusCode=0 and p_SellStatus=1   " + strSql, pageNumber, pageSize, sortby);
            return View(ViewBag.ProductsList);
        }


        public ActionResult ProductsMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限

            List<Model.ProductTypeBase> modelType = ptbll.GetModelList(" pt_parentId = 0  and pt_IsDel=0 and pt_StatusCode=0");
            List<SelectListItem> selectType = new List<SelectListItem>();
            selectType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            for (int i = 0; i < modelType.Count; i++)
            {
                selectType.Add(new SelectListItem
                {
                    Value = modelType[i].pt_ID.ToString(),
                    Text = modelType[i].pt_Name
                });
            }
            ViewData["selectType"] = new SelectList(selectType, "Value", "Text", "请选择");
            return View();
        }

        
        /// <summary>
        /// 展示商品信息
        /// </summary>
        /// <returns></returns>
        public ActionResult RushPurchaseList()
        {
            int total = 0;//总行数
            int pageSize = 25;//每一页的行数
            int pageNumber = 1;//当前页数
            string ptparentid = "0";
            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            if (!string.IsNullOrEmpty(Request.Form["txtPrName"]))
            {
                strSql.AppendFormat(" and p_name like '%{0}%' ", Request.Form["txtPrName"]);
            }
            if (!string.IsNullOrEmpty(Request.Form["txtDatetime"]))
            {
                strSql.AppendFormat(" and rp_StartTime <= '{0}' and rp_EndTiime >= '{1}'", Request.Form["txtDatetime"], Request.Form["txtDatetime"]);
            }
            if (RequestBase.GetString("hfPid") != "")
            {
                ptparentid = RequestBase.GetString("hfPid").ToString();
            }
            var cpt = vrpbll.GetModelList(" rp_IsDel=0 " + strSql);
            
            total = cpt.Count;
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            
            return View(cpt.ToPagedList(pageNumber, pageSize));
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult RushPurchaseEdit()
        {
            this.ViewData["texOtype"] = RequestBase.GetString("otype");
            BindControl bc = new BindControl();
            ViewData["IsHasFunRole"] = Rolemanager.IsHasFunRole(EmployeeBase.e_ID, "001001001");//是否拥有管理的权限
            Model.vm_RPDetails model = new Model.vm_RPDetails();


            if (RequestBase.GetString("otype") == "modify")
            {
                string ids = RequestBase.GetString("dli_id");
                ViewData["hfPId"] = ids;
                int id = int.Parse(ids.Split('|')[0]);
                model = vrpbll.GetModel(id);
                ViewData["starttime"] = model.rp_StartTime;
                ViewData["endtime"] = model.rp_EndTiime;
                ViewData["p_Name"] = model.p_Name;
                ViewData["p_ID"] = model.p_ID;
                return View(model);
            }
            else
            {
                string pids = RequestBase.GetString("dli_id");
                ViewData["hfPId"] = pids;
                return View();
            }
        }

        /// <summary>
        /// 添加/修改
        /// </summary>
        public ActionResult RushPurchaseEdit(Model.RushPurchaseBase RPBase)
        {
            bool result = false;
            
            try
            {
                if (Request.Form["texOtype"] == "add")
                {
                    string pid = Request.Form["orgLookup.id"];
                    
                    int ptid = int.Parse(pid);//商品ID
                    
                    RPBase.p_ID = ptid;
                    RPBase.rp_CreateOn = DateTime.Now;
                    RPBase.rp_CreateBy = EmployeeBase.e_ID;
                    RPBase.rp_StartTime = DateTime.Parse(Request.Form["starttime"]);
                    RPBase.rp_EndTiime = DateTime.Parse(Request.Form["endtime"]);
                    RPBase.rp_isdel = false;
                   
                    result = rpbll.Add( RPBase);
                    
                }
                else
                {
                    string pids = Request.Form["hfPId"];
                    string pid = Request.Form["orgLookup.id"];
                    int ptid = int.Parse(pid);
                    int id = int.Parse(pids);
                    Model.RushPurchaseBase model = rpbll.GetModel(id);
                    model.p_ID = ptid;
                    model.rp_pCount = RPBase.rp_pCount;
                    model.rp_pPric = RPBase.rp_pPric;
                    model.rp_StartTime = DateTime.Parse(Request.Form["starttime"]);
                    model.rp_EndTiime = DateTime.Parse(Request.Form["endtime"]);
                    result = rpbll.Update(model);
                    
                }
                if (result)
                {
                    
                    return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功!!", "", "", "closeCurrent", "rpBox", ""));
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
        public ActionResult RushPurchaseDelete()
        {
            bool result = false;
            string Message = "";
            try
            {
                string id = RequestBase.GetString("dli_id");
                string pid = id.Split('|')[0];
                int ptid = int.Parse(pid);//商品ID
                Model.RushPurchaseBase rpmodel = rpbll.GetModel(ptid);
                rpmodel.rp_isdel = true;
                result = rpbll.Update(rpmodel);
                if (result)
                {
                    Message = "删除成功！";
                    return Content(DWZUtil.GetAjaxTodoJson("200", Message, "", "", "", "rpBox", ""));
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
        /// <summary>
        /// 启/禁用
        /// </summary>
        public ActionResult RushPurchaseEnable(string otype, string dli_id)
        {

            bool result = false;
            try
            {
                string dliid = RequestBase.GetString("dli_id");
                string pid = dliid.Split('|')[0];
                Model.RushPurchaseBase NewP = rpbll.GetModel(int.Parse(pid));
                if (otype == "disable")
                {
                    NewP.rp_StatusCode = 1;
                }
                else
                {
                    NewP.rp_StatusCode = 0;
                }
                result = rpbll.Update(NewP);
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "forward", "", "rpBox", ""));
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
        #region  商品详情
        /// <summary>
        /// 展示所有的商品信息(三个tab)
        /// </summary>
        /// <returns></returns>
        public ActionResult RushPurchaseDetail()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            string pids = RequestBase.GetString("dli_id");
            ViewData["hfPId"] = pids;
            return View();
            
        }
        #endregion

       
    }
}
