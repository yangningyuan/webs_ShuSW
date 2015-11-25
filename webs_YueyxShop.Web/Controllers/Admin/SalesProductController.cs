using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Common;
using System.Data;

namespace webs_YueyxShop.Web.Controllers
{
    public class SalesProductController : BaseController
    {

        private RoleManager Rolemanager = new RoleManager();
        private BLL.ProductBase pbll = new BLL.ProductBase();
        private BLL.ProductTypeBase ptbll = new BLL.ProductTypeBase();
        private BLL.RegionBase regbll = new BLL.RegionBase();
        private readonly RoleManager _roleManager = new RoleManager();

        public ActionResult SalesProductMsg()
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


        public ActionResult SalesProductList()
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
            if (!string.IsNullOrEmpty(Request.Form["txtPrCode"]))
            {
                strSql.AppendFormat(" and p.p_ID in (select distinct p_id from SKUBase where sku_Code like '%{0}%') ", Request.Form["txtPrCode"]);
            }
            if (!string.IsNullOrEmpty(Request.Form["txtPrName"]))
            {
                strSql.AppendFormat(" and p.p_Name like'%{0}%'", Request.Form["txtPrName"]);
            }
            if (RequestBase.GetString("hfPid") != "")
            {
                ptparentid = RequestBase.GetString("hfPid").ToString();
            }
            if (Request.Form["selectType"] != "chose")
            {
               if (!string.IsNullOrEmpty(Request.Form["selectType2"]) && Request.Form["selectType2"] != "chose")
                {
                    strSql.AppendFormat(" and pt.pt_ID={0}  and pt_Isdel=0 and pt_statusCode=0", Request.Form["selectType2"]);
                }
                else
                {
                    strSql.AppendFormat(" and pt.pt_ID in(select pt_id from ProductTypeBase where pt_ParentId={0}  and pt_Isdel=0 and pt_statusCode=0)", Request.Form["selectType"]);
                }
            }
            var cpt = pbll.GetModelListById(" p.p_SellStatus=1 and p.p_isDel=0 " + strSql);
            total = cpt.Tables[0].Rows.Count;
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            ViewData["ProductsList"] = GetPagedTable(cpt.Tables[0], pageNumber, pageSize);
            return View(ViewData["ProductsList"]);
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult SalesProductsEdit()
        {
            this.ViewData["texOtype"] = RequestBase.GetString("otype");
            BindControl bc = new BindControl();
            ViewData["IsHasFunRole"] = Rolemanager.IsHasFunRole(EmployeeBase.e_ID, "001001001");//是否拥有管理的权限
            Model.ProductBase model = new Model.ProductBase();
            Model.RegionBase regmodel = new Model.RegionBase();

            #region  运费模板下拉菜单
            BLL.CarriageTempleteBase pctbll = new BLL.CarriageTempleteBase();
            List<Model.CarriageTempleteBase> carmodel = pctbll.GetModelList(" ct_IsDel=0 and ct_StatusCode=0 ");
            List<SelectListItem> carriageTemplete = new List<SelectListItem>();
            carriageTemplete = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            for (int i = 0; i < carmodel.Count; i++)
            {
                carriageTemplete.Add(new SelectListItem
                {
                    Value = carmodel[i].ct_ID.ToString(),
                    Text = carmodel[i].ct_Name
                });
            }
            ViewData["carriageTemplete"] = new SelectList(carriageTemplete, "Value", "Text", "请选择");
            #endregion 
            #region 商品分类 下拉菜单
            BLL.ProductTypeBase ptbll = new BLL.ProductTypeBase();
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
            ViewData["pType"] = new SelectList(selectType, "Value", "Text", "请选择");
            //中类
            List<SelectListItem> zType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            ViewData["zType"] = new SelectList(zType, "Value", "Text", "请选择");
            //小类
            List<SelectListItem> xType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            ViewData["xType"] = new SelectList(zType, "Value", "Text", "请选择");
            #endregion

            #region 地区信息下拉菜单
            List<Model.RegionBase> Pregion = regbll.GetModelList(" reg_PId = 0");
            List<SelectListItem> Province = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "1" } };
            for (int i = 0; i < Pregion.Count; i++)
            {
                Province.Add(new SelectListItem
                {
                    Value = Pregion[i].reg_ID.ToString(),
                    Text = Pregion[i].reg_Name
                });
            }

            ViewData["Province"] = new SelectList(Province, "Value", "Text", "请选择");
            List<SelectListItem> City = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "1" } };
            ViewData["City"] = new SelectList(City, "Value", "Text", "请选择");
            List<SelectListItem> Country = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "1" } };
            ViewData["Country"] = new SelectList(Country, "Value", "Text", "请选择");

            #endregion

            string ids = RequestBase.GetString("dli_id");
            ViewData["hfPId"] = ids;
            int id = int.Parse(ids.Split('|')[0]);
            string typeid = ids.Split('|')[1];//类别ID
            #region 修改时加载分类下拉列表
            model = pbll.GetModel(id);
            Model.ProductTypeBase modelm = ptbll.GetModel(int.Parse(typeid));//当前小类，它的父ID是大类ID,PID=208，大类ID是207
            List<Model.ProductTypeBase> modelType2 = ptbll.GetModelList(" pt_parentId =0 ");//大类
            List<Model.ProductTypeBase> modelType3 = ptbll.GetModelList(" pt_parentId = " + modelm.pt_ParentId);//小类
            //加载大类的下拉菜单
            for (int i = 0; i < modelType2.Count; i++)
            {
                selectType.Add(new SelectListItem
                {
                    Value = modelType2[i].pt_ID.ToString(),
                    Text = modelType2[i].pt_Name
                });
            }

            ViewData["pType"] = new SelectList(selectType, "Value", "Text", modelm.pt_ParentId);
            //加载小类的下拉菜单
            for (int i = 0; i < modelType3.Count; i++)
            {
                zType.Add(new SelectListItem
                {
                    Value = modelType3[i].pt_ID.ToString(),
                    Text = modelType3[i].pt_Name
                });
            }
            ViewData["zType"] = new SelectList(zType, "Value", "Text", modelm.pt_ID);

            #endregion

            #region 修改时加载地区下拉列表
            regmodel = regbll.GetModel(model.p_Province);//43
            Model.RegionBase citymodel = regbll.GetModel(model.p_City);//44
            Model.RegionBase countrymodel = regbll.GetModel(model.p_County);//45
            List<Model.RegionBase> model2 = regbll.GetModelList(" reg_PId = " + regmodel.reg_Code);//市
            List<Model.RegionBase> model3 = regbll.GetModelList(" reg_PId = " + citymodel.reg_Code);//县

            ViewData["Province"] = new SelectList(Province, "Value", "Text", regmodel.reg_ID);
            //加载市的下拉菜单
            for (int i = 0; i < model2.Count; i++)
            {
                City.Add(new SelectListItem
                {
                    Value = model2[i].reg_ID.ToString(),
                    Text = model2[i].reg_Name
                });
            }
            ViewData["City"] = new SelectList(City, "Value", "Text", citymodel.reg_ID);

            //加载县的下拉菜单
            for (int i = 0; i < model3.Count; i++)
            {
                Country.Add(new SelectListItem
                {
                    Value = model3[i].reg_ID.ToString(),
                    Text = model3[i].reg_Name
                });
            }
            ViewData["Country"] = new SelectList(Country, "Value", "Text", countrymodel.reg_ID);
            #endregion

            #region 修改时加载运费模板下拉列表
            ViewData["carriageTemplete"] = new SelectList(carriageTemplete, "Value", "Text", model.ct_ID);


            #endregion
            #region 加载品牌下拉菜单
            List<SelectListItem> selectbrand = new List<SelectListItem>();
            List<Model.BrandBase> modelbrand = new BLL.BrandBase().GetModelList(" b_ID in (select b_ID from ProductTypeBrandBase where pt_ID=" + modelm.pt_ID + ")");
            //加载品牌的下拉菜单
            for (int i = 0; i < modelbrand.Count; i++)
            {
                selectbrand.Add(new SelectListItem
                {
                    Value = modelbrand[i].b_ID.ToString(),
                    Text = modelbrand[i].b_Name
                });
            }
            ViewData["brands"] = new SelectList(selectbrand, "Value", "Text", new BLL.ProductBase().GetModel(id).b_ID);
            #endregion
            return View(model);
        }

        /// <summary>
        /// 添加/修改
        /// </summary>
        public ActionResult SalesProductsEdit(Model.ProductBase PBase)
        {
            int result = 0;
            bool result2 = false;
            string Message = "";
            try
            {
                string pids = Request.Form["hfPId"];
                int p_id = int.Parse(pids.Split('|')[0]);
                Model.ProductBase NewP = pbll.GetModel(p_id);
                NewP.p_Name = PBase.p_Name;
                NewP.p_MeasurementUnit = PBase.p_MeasurementUnit;
                if (Request.Form["zType"] != "chose" && Request.Form["zType"] != null)
                {
                    NewP.pt_ID = int.Parse(Request.Form["zType"]);
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "保存失败,请完善商品类别信息！", "", "", ""));
                }
                if (Request.Form["brands"] != "chose" && Request.Form["brands"] != null)
                {
                    NewP.b_ID = int.Parse(Request.Form["brands"]);
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "保存失败,请完善商品品牌信息！", "", "", ""));
                }
                if (Request.Form["Province"] != "chose" && Request.Form["City"] != "chose" && Request.Form["Country"] != "chose")
                {
                    NewP.p_Province = int.Parse(Request.Form["Province"]);
                    NewP.p_City = int.Parse(Request.Form["City"]);
                    NewP.p_County = int.Parse(Request.Form["Country"]);
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "请选择商品所在地！！", "", "", ""));
                }

                if (Request.Form["carriageTemplete"] != "chose")
                {
                    NewP.ct_ID = int.Parse(Request.Form["carriageTemplete"]);
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "请选择运费模板！！", "", "", ""));
                }
                NewP.p_ModifyBy = EmployeeBase.e_ID;
                NewP.p_ModifyOn = DateTime.Now;
                result2 = pbll.Update(NewP);
                if (result > 0 || result2)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功！！", "", "", "closeCurrent", "spBox", ""));
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
        /// 批量上架
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductsShangjia()
        {
            string dliid = RequestBase.GetString("dli_id");
            string pid = "";
            if (dliid.Length > 1)
            {
                pid = dliid.Substring(0, dliid.Length - 1);
            }
            bool result = pbll.UpdateList(pid);
            if (result)
            {
                return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功!!", "w_下架商品", "", "", "UnSBox", ""));
            }
            else
            {
                return Content(DWZUtil.GetResultJson("300", "保存失败！！", "", "", ""));
            }

        }
        /// <summary>
        /// 批量下架
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductsXiajia()
        {
            string dliid = RequestBase.GetString("dli_id");
            string pid = "";
            if (dliid.Length > 1)
            {
                pid = dliid.Substring(0, dliid.Length - 1);
            }
            bool result = pbll.UpdateListx(pid);
            if (result)
            {
                return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功!!", "", "", "", "spBox", ""));
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
        public ActionResult SjProductsDelete()
        {
            bool result = false;
            string Message = "";
            try
            {
                string id = RequestBase.GetString("dli_id");
                string pid = id.Split('|')[0];
                int ptid = int.Parse(pid);//商品ID
                Model.ProductBase NewP = pbll.GetModel(ptid);
                NewP.p_IsDel = true;
                result = pbll.Update(NewP);
                if (result)
                {
                    Message = "删除成功！";
                    return Content(DWZUtil.GetAjaxTodoJson("200", Message, "", "", "", "spBox", ""));
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
        #region 下架商品管理
        public ActionResult UnSalesProductMsg()
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

        public ActionResult UnSalesProductList()
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
            if (!string.IsNullOrEmpty(Request.Form["txtPrCode"]))
            {
                strSql.AppendFormat(" and p.p_ID in (select distinct p_id from SKUBase where sku_Code like '%{0}%') ", Request.Form["txtPrCode"]);
            }
            if (!string.IsNullOrEmpty(Request.Form["txtPrName"]))
            {
                strSql.AppendFormat(" and p.p_Name like'%{0}%'", Request.Form["txtPrName"]);
            }
            if (RequestBase.GetString("hfPid") != "")
            {
                ptparentid = RequestBase.GetString("hfPid").ToString();
            }
            if (Request.Form["selectType"] != "chose")
            {
                if (!string.IsNullOrEmpty(Request.Form["selectType2"]) && Request.Form["selectType2"] != "chose")
                {
                    strSql.AppendFormat(" and pt.pt_ID={0}  and pt_Isdel=0 and pt_statusCode=0", Request.Form["selectType2"]);
                }
                else
                {
                    strSql.AppendFormat(" and pt.pt_ID in(select pt_id from ProductTypeBase where pt_ParentId={0}  and pt_Isdel=0 and pt_statusCode=0)", Request.Form["selectType"]);
                }
            }
            var cpt = pbll.GetModelListById(" p.p_SellStatus=2  and p.p_IsDel=0 " + strSql);
            total = cpt.Tables[0].Rows.Count;
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            ViewData["ProductsList"] = GetPagedTable(cpt.Tables[0], pageNumber, pageSize);
            return View(ViewData["ProductsList"]);
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult UnSalesProductsEdit()
        {
            this.ViewData["texOtype"] = RequestBase.GetString("otype");
            BindControl bc = new BindControl();
            ViewData["IsHasFunRole"] = Rolemanager.IsHasFunRole(EmployeeBase.e_ID, "001001001");//是否拥有管理的权限
            Model.ProductBase model = new Model.ProductBase();
            Model.RegionBase regmodel = new Model.RegionBase();

            #region  运费模板下拉菜单
            BLL.CarriageTempleteBase pctbll = new BLL.CarriageTempleteBase();
            List<Model.CarriageTempleteBase> carmodel = pctbll.GetModelList(" ct_IsDel=0 and ct_StatusCode=0 ");
            List<SelectListItem> carriageTemplete = new List<SelectListItem>();
            carriageTemplete = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            for (int i = 0; i < carmodel.Count; i++)
            {
                carriageTemplete.Add(new SelectListItem
                {
                    Value = carmodel[i].ct_ID.ToString(),
                    Text = carmodel[i].ct_Name
                });
            }
            ViewData["carriageTemplete"] = new SelectList(carriageTemplete, "Value", "Text", "请选择");
            #endregion
            #region 商品分类 下拉菜单
            BLL.ProductTypeBase ptbll = new BLL.ProductTypeBase();
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
            ViewData["pType"] = new SelectList(selectType, "Value", "Text", "请选择");
            //中类
            List<SelectListItem> zType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            ViewData["zType"] = new SelectList(zType, "Value", "Text", "请选择");
            //小类
            List<SelectListItem> xType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            ViewData["xType"] = new SelectList(zType, "Value", "Text", "请选择");
            #endregion

            #region 地区信息下拉菜单
            List<Model.RegionBase> Pregion = regbll.GetModelList(" reg_PId = 0");
            List<SelectListItem> Province = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "1" } };
            for (int i = 0; i < Pregion.Count; i++)
            {
                Province.Add(new SelectListItem
                {
                    Value = Pregion[i].reg_ID.ToString(),
                    Text = Pregion[i].reg_Name
                });
            }

            ViewData["Province"] = new SelectList(Province, "Value", "Text", "请选择");
            List<SelectListItem> City = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "1" } };
            ViewData["City"] = new SelectList(City, "Value", "Text", "请选择");
            List<SelectListItem> Country = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "1" } };
            ViewData["Country"] = new SelectList(Country, "Value", "Text", "请选择");

            #endregion

            string ids = RequestBase.GetString("dli_id");
            ViewData["hfPId"] = ids;
            int id = int.Parse(ids.Split('|')[0]);
            string typeid = ids.Split('|')[1];//类别ID
            #region 修改时加载分类下拉列表
            model = pbll.GetModel(id);
            Model.ProductTypeBase modelm = ptbll.GetModel(int.Parse(typeid));//当前小类，它的父ID是大类ID,PID=208，大类ID是207
            List<Model.ProductTypeBase> modelType2 = ptbll.GetModelList(" pt_parentId =0 ");//大类
            List<Model.ProductTypeBase> modelType3 = ptbll.GetModelList(" pt_parentId = " + modelm.pt_ParentId);//小类
            //加载大类的下拉菜单
            for (int i = 0; i < modelType2.Count; i++)
            {
                selectType.Add(new SelectListItem
                {
                    Value = modelType2[i].pt_ID.ToString(),
                    Text = modelType2[i].pt_Name
                });
            }

            ViewData["pType"] = new SelectList(selectType, "Value", "Text", modelm.pt_ParentId);
            //加载小类的下拉菜单
            for (int i = 0; i < modelType3.Count; i++)
            {
                zType.Add(new SelectListItem
                {
                    Value = modelType3[i].pt_ID.ToString(),
                    Text = modelType3[i].pt_Name
                });
            }
            ViewData["zType"] = new SelectList(zType, "Value", "Text", modelm.pt_ID);

            #endregion

            #region 修改时加载地区下拉列表
            regmodel = regbll.GetModel(model.p_Province);//43
            Model.RegionBase citymodel = regbll.GetModel(model.p_City);//44
            Model.RegionBase countrymodel = regbll.GetModel(model.p_County);//45
            List<Model.RegionBase> model2 = regbll.GetModelList(" reg_PId = " + regmodel.reg_Code);//市
            List<Model.RegionBase> model3 = regbll.GetModelList(" reg_PId = " + citymodel.reg_Code);//县

            ViewData["Province"] = new SelectList(Province, "Value", "Text", regmodel.reg_ID);
            //加载市的下拉菜单
            for (int i = 0; i < model2.Count; i++)
            {
                City.Add(new SelectListItem
                {
                    Value = model2[i].reg_ID.ToString(),
                    Text = model2[i].reg_Name
                });
            }
            ViewData["City"] = new SelectList(City, "Value", "Text", citymodel.reg_ID);

            //加载县的下拉菜单
            for (int i = 0; i < model3.Count; i++)
            {
                Country.Add(new SelectListItem
                {
                    Value = model3[i].reg_ID.ToString(),
                    Text = model3[i].reg_Name
                });
            }
            ViewData["Country"] = new SelectList(Country, "Value", "Text", countrymodel.reg_ID);
            #endregion

            #region 修改时加载运费模板下拉列表
            ViewData["carriageTemplete"] = new SelectList(carriageTemplete, "Value", "Text", model.ct_ID);


            #endregion
            #region 加载品牌下拉菜单
            List<SelectListItem> selectbrand = new List<SelectListItem>();
            List<Model.BrandBase> modelbrand = new BLL.BrandBase().GetModelList(" b_ID in (select b_ID from ProductTypeBrandBase where pt_ID=" + modelm.pt_ID + ")");
            //加载品牌的下拉菜单
            for (int i = 0; i < modelbrand.Count; i++)
            {
                selectbrand.Add(new SelectListItem
                {
                    Value = modelbrand[i].b_ID.ToString(),
                    Text = modelbrand[i].b_Name
                });
            }
            ViewData["brands"] = new SelectList(selectbrand, "Value", "Text", new BLL.ProductBase().GetModel(id).b_ID);
            #endregion
            return View(model);
        }

        /// <summary>
        /// 添加/修改
        /// </summary>
        public ActionResult UnSalesProductsEdit(Model.ProductBase PBase)
        {
            int result = 0;
            bool result2 = false;
            string Message = "";
            try
            {
                string pids = Request.Form["hfPId"];
                int p_id = int.Parse(pids.Split('|')[0]);
                Model.ProductBase NewP = pbll.GetModel(p_id);
                NewP.p_Name = PBase.p_Name;
                NewP.p_MeasurementUnit = PBase.p_MeasurementUnit;
                if (Request.Form["zType"] != "chose" && Request.Form["zType"] != null)
                {
                    NewP.pt_ID = int.Parse(Request.Form["zType"]);
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "保存失败,请完善商品类别信息！", "", "", ""));
                }
                if (Request.Form["brands"] != "chose" && Request.Form["brands"] != null)
                {
                    NewP.b_ID = int.Parse(Request.Form["brands"]);
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "保存失败,请完善商品品牌信息！", "", "", ""));
                }
                if (Request.Form["Province"] != "chose" && Request.Form["City"] != "chose" && Request.Form["Country"] != "chose")
                {
                    NewP.p_Province = int.Parse(Request.Form["Province"]);
                    NewP.p_City = int.Parse(Request.Form["City"]);
                    NewP.p_County = int.Parse(Request.Form["Country"]);
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "请选择商品所在地！！", "", "", ""));
                }

                if (Request.Form["carriageTemplete"] != "chose")
                {
                    NewP.ct_ID = int.Parse(Request.Form["carriageTemplete"]);
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "请选择运费模板！！", "", "", ""));
                }
                NewP.p_ModifyBy = EmployeeBase.e_ID;
                NewP.p_ModifyOn = DateTime.Now;
                result2 = pbll.Update(NewP);
                if (result > 0 || result2)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功！！", "", "", "closeCurrent", "UnSBox", ""));
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

        //Datatable转list
        public static DataTable GetPagedTable(DataTable dt, int PageIndex, int PageSize)
        {
            if (PageIndex == 0)
                return dt;
            DataTable newdt = dt.Copy();
            newdt.Clear();

            int rowbegin = (PageIndex - 1) * PageSize;
            int rowend = PageIndex * PageSize;

            if (rowbegin >= dt.Rows.Count)
                return newdt;

            if (rowend > dt.Rows.Count)
                rowend = dt.Rows.Count;
            for (int i = rowbegin; i <= rowend - 1; i++)
            {
                DataRow newdr = newdt.NewRow();
                DataRow dr = dt.Rows[i];
                foreach (DataColumn column in dt.Columns)
                {
                    newdr[column.ColumnName] = dr[column.ColumnName];
                }
                newdt.Rows.Add(newdr);
            }

            return newdt;
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductsDelete()
        {
            bool result = false;
            string Message = "";
            try
            {
                string id = RequestBase.GetString("dli_id");
                string pid = id.Split('|')[0];
                int ptid = int.Parse(pid);//商品ID
                Model.ProductBase NewP = pbll.GetModel(ptid);
                NewP.p_IsDel = true;
                result = pbll.Update(NewP);
                if (result)
                {
                    Message = "删除成功！";
                    return Content(DWZUtil.GetAjaxTodoJson("200", Message, "", "", "", "UnSBox", ""));
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
    }
}
