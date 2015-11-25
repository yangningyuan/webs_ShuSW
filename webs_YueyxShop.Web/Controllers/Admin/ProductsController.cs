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
using System.Transactions;


namespace webs_YueyxShop.Web.Controllers
{
    public class ProductsController : BaseController
    {
        private RoleManager Rolemanager = new RoleManager();
        private BLL.ProductBase pbll = new BLL.ProductBase();
        private BLL.ProductTypeBase ptbll = new BLL.ProductTypeBase();
        private BLL.RegionBase regbll = new BLL.RegionBase();
        private readonly RoleManager _roleManager = new RoleManager();

        #region 商品信息
        public ActionResult ProductsMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限

            List<Model.ProductTypeBase> modelType = ptbll.GetModelList(" pt_parentId = 0 and pt_IsDel=0 and pt_StatusCode=0");
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
            List<SelectListItem> SellStatus = new List<SelectListItem>();
            SellStatus = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" }, new SelectListItem { Text = "待处理", Value = "0" }, new SelectListItem { Text = "已上架", Value = "1" }, new SelectListItem { Text = "已下架", Value = "2" } };
            ViewData["SellStatus"] = new SelectList(SellStatus, "Value", "Text", "请选择");
            ViewData["Title"] = ConfigurationManager.AppSettings["title"].ToString();
            return View();
        }

        
        /// <summary>
        /// 展示商品信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductsList()
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
                strSql.AppendFormat(" and p_ID in (select distinct p_id from SKUBase where sku_Code like '%{0}%') ", Request.Form["txtPrCode"]);
            }
            if (!string.IsNullOrEmpty(Request.Form["txtPrName"]))
            {
                strSql.AppendFormat(" and p_Name like'%{0}%'", Request.Form["txtPrName"]);
            }
            if (Request.Form["SellStatus"] != "chose")
            {
                strSql.AppendFormat(" and p.p_SellStatus ={0}", Request.Form["SellStatus"]);
            }
            if (Request.Form["selectType"]!="chose")
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
            if (RequestBase.GetString("hfPid") != "")
            {
                ptparentid = RequestBase.GetString("hfPid").ToString();
            }
            var cpt = pbll.GetModelListById(" p.p_IsDel=0 " + strSql);
            total = cpt.Tables[0].Rows.Count;
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            ViewData["ProductsList"] = GetPagedTable(cpt.Tables[0], pageNumber, pageSize); 
            return View(ViewData["ProductsList"]);
        }
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
        /// 批量上架
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductsShangjia()
        {
            string dliid = RequestBase.GetString("dli_id");
            string pid="";
            if (dliid.Length > 1)
            {
                pid = dliid.Substring(0, dliid.Length - 1);
            }
            bool result = pbll.UpdateList(pid);
            if (result )
            {
                return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功!!", "w_商品信息管理", "", "", "pBox", ""));
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
                return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功!!", "w_商品信息管理", "", "", "pBox", ""));
            }
            else
            {
                return Content(DWZUtil.GetResultJson("300", "保存失败！！", "", "", ""));
            }

        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProductsEdit()
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
            List<Model.ProductTypeBase> modelType = ptbll.GetModelList(" pt_parentId = 0 and pt_IsDel=0 and pt_StatusCode=0");
            List<SelectListItem> pType = new List<SelectListItem>();
            pType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            for (int i = 0; i < modelType.Count; i++)
            {
                pType.Add(new SelectListItem
                {
                    Value = modelType[i].pt_ID.ToString(),
                    Text = modelType[i].pt_Name
                });
            }
            ViewData["pType"] = new SelectList(pType, "Value", "Text", "请选择");
            //中类
            List<SelectListItem> zType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            ViewData["zType"] = new SelectList(zType, "Value", "Text", "请选择");
            #endregion

            #region 地区信息下拉菜单
            List<Model.RegionBase> Pregion = regbll.GetModelList(" reg_PId = 0");
            List<SelectListItem> Province = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            for (int i = 0; i < Pregion.Count; i++)
            {
                Province.Add(new SelectListItem
                {
                    Value = Pregion[i].reg_ID.ToString(),
                    Text = Pregion[i].reg_Name
                });
            }

            ViewData["Province"] = new SelectList(Province, "Value", "Text", "请选择");
            List<SelectListItem> City = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            ViewData["City"] = new SelectList(City, "Value", "Text", "请选择");
            List<SelectListItem> Country = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            ViewData["Country"] = new SelectList(Country, "Value", "Text", "请选择");
            List<SelectListItem> brandlist = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            ViewData["brands"] = new SelectList(brandlist, "Value", "Text", "请选择");

            #endregion


            if (RequestBase.GetString("otype") == "modify")
            {
                string ids = RequestBase.GetString("dli_id");
                ViewData["hfPId"] = ids;
                int id = int.Parse(ids.Split('|')[0]);
                string typeid = ids.Split('|')[1];//类别ID
                #region 修改时加载分类下拉列表
                model = pbll.GetModel(id);
                Model.ProductTypeBase modelm = ptbll.GetModel(int.Parse(typeid));//当前小类，它的父ID是大类ID,PID=208，大类ID是207
                List<Model.ProductTypeBase> modelType2 = ptbll.GetModelList(" pt_parentId =0 " );//大类
                List<Model.ProductTypeBase> modelType3 = ptbll.GetModelList(" pt_parentId = " + modelm.pt_ParentId);//小类
                //加载大类的下拉菜单
                for (int i = 0; i < modelType2.Count; i++)
                {
                    pType.Add(new SelectListItem
                    {
                        Value = modelType2[i].pt_ID.ToString(),
                        Text = modelType2[i].pt_Name
                    });
                }

                ViewData["pType"] = new SelectList(pType, "Value", "Text", modelm.pt_ParentId);
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
                ViewData["brands"] = new SelectList(selectbrand, "Value", "Text",new BLL.ProductBase().GetModel(id).b_ID);
                #endregion
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
        public ActionResult ProductsEdit(Model.ProductBase PBase)
        {
            int result = 0;
            bool result2 = false;
            string Message = "";
            try
            {
                if (Request.Form["texOtype"] == "add")
                {
                    string pids = Request.Form["hfPId"];
                    string id = pids.Split('|')[0];
                    int ptid = int.Parse(id);//商品ID
                    PBase.p_ID = ptid;
                    PBase.p_CreatedOn = DateTime.Now;
                    PBase.p_CreatedBy = EmployeeBase.e_ID;
                    PBase.p_ModifyBy = EmployeeBase.e_ID;
                    PBase.p_ModifyOn = DateTime.Now;
                    if (Request.Form["zType"] != "chose" && Request.Form["zType"] != null)
                    {
                        PBase.pt_ID = int.Parse(Request.Form["zType"]);
                    }
                    else
                    {
                        return Content(DWZUtil.GetResultJson("300", "保存失败,请完善商品类别信息！", "", "", ""));
                    }
                    if (Request.Form["brands"] != "chose" && Request.Form["brands"] != null)
                    {
                        PBase.b_ID = int.Parse(Request.Form["brands"]);
                    }
                    else
                    {
                        return Content(DWZUtil.GetResultJson("300", "保存失败,请完善商品品牌信息！", "", "", ""));
                    }
                    if (Request.Form["Province"] != "chose" && Request.Form["City"] != "chose" && Request.Form["Country"] != "chose")
                    {
                        PBase.p_Province = int.Parse(Request.Form["Province"]);
                        PBase.p_City = int.Parse(Request.Form["City"]);
                        PBase.p_County = int.Parse(Request.Form["Country"]);
                    }
                    else
                    {
                        return Content(DWZUtil.GetResultJson("300", "请选择商品所在地！！", "", "", ""));
                    }

                    if (Request.Form["carriageTemplete"]!="chose")
                    {
                     PBase.ct_ID = int.Parse(Request.Form["carriageTemplete"]);
                    }
                    else
                    {
                        return Content(DWZUtil.GetResultJson("300", "请选择运费模板！！", "", "", ""));
                    }
                    int sort = pbll.GetSort();
                    PBase.p_Sort = sort;
                    result = pbll.Add(PBase);
                }
                else
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
                }
                if (result>0|| result2)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功!!", "", "", "closeCurrent", "pBox", ""));
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
                    return Content(DWZUtil.GetAjaxTodoJson("200", Message, "", "", "", "pBox", ""));
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
        public ActionResult ProductsEnable(string otype, string dli_id)
        {

            bool result = false;
            try
            {
                string dliid = RequestBase.GetString("dli_id");
                string pid = dliid.Split('|')[0];
                Model.ProductBase NewP = pbll.GetModel(int.Parse(pid));
                if (otype == "disable")
                {
                    NewP.p_StatusCode = 1;
                }
                else
                {
                    NewP.p_StatusCode = 0;
                }
                result = pbll.Update(NewP);
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "forward", "", "pBox", ""));
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

        //地区联动下拉菜单
        [HttpGet]
        public string GetCity(string id)
        {
            StringBuilder attr = new StringBuilder();
            if (RequestBase.GetString("code") != "")
            {
                id = RequestBase.GetString("code");
            }
            if (id == "chose")
            {
                return "refresh";
            }
            else
            {
                List<SelectListItem> selectattrP = new List<SelectListItem>();
                Model.RegionBase rmodel = regbll.GetModel(int.Parse(id));
                List<Model.RegionBase> modelCity = regbll.GetModelList(" reg_PId = " + rmodel.reg_Code);
                StringBuilder sbGoodsName = new StringBuilder();
                attr.Append("[[\"chose\",\"请选择\"]");
                for (int i = 0; i < modelCity.Count; i++)
                {
                    attr.Append(",[");
                    attr.Append("\"" + modelCity[i].reg_ID.ToString() + "\",");
                    attr.Append("\"" + modelCity[i].reg_Name + "\"");
                    attr.Append("]");
                }


                attr.Append("]");

                return attr.ToString();
            }
        }
        [HttpGet]
        public string GetCountry(string id)
        {
            StringBuilder attr = new StringBuilder();
            if (RequestBase.GetString("code") != "")
            {
                id = RequestBase.GetString("code");
            }
            if (id == "chose")
            {
                return "refresh";
            }
            else
            {
                List<SelectListItem> selectattrP = new List<SelectListItem>();
                Model.RegionBase rmodel = regbll.GetModel(int.Parse(id));
                List<Model.RegionBase> modelCountry = regbll.GetModelList(" reg_PId = " + rmodel.reg_Code);
                StringBuilder sbGoodsName = new StringBuilder();
                attr.Append("[[\"chose\",\"请选择\"]");

                for (int i = 0; i < modelCountry.Count; i++)
                {
                    attr.Append(",[");
                    attr.Append("\"" + modelCountry[i].reg_ID.ToString() + "\",");
                    attr.Append("\"" + modelCountry[i].reg_Name + "\"");
                    attr.Append("]");
                }

                attr.Append("]");

                return attr.ToString();
            }
        }

        //加载品牌下拉列表
        [HttpGet]
        public string Getbrand(string id)
        {
            StringBuilder attr = new StringBuilder();
            if (RequestBase.GetString("code") != "")
            {
                id = RequestBase.GetString("code");
            }
            if (id == "chose")
            {
                return "refresh";
            }
            else
            {
                List<SelectListItem> selectattrP = new List<SelectListItem>();
                List<Model.BrandBase> modelbrand = new BLL.BrandBase().GetModelList(" b_ID in (select b_ID from ProductTypeBrandBase where pt_ID="+id+")");
                StringBuilder sbGoodsName = new StringBuilder();
                attr.Append("[[\"chose\",\"请选择\"]");

                for (int i = 0; i < modelbrand.Count; i++)
                {

                    attr.Append(",[");
                    attr.Append("\"" + modelbrand[i].b_ID.ToString() + "\",");
                    attr.Append("\"" + modelbrand[i].b_Name + "\"");
                    attr.Append("]");
                }


                attr.Append("]");

                return attr.ToString();
            }
        }

        #endregion
        #region  商品详情
        /// <summary>
        /// 展示所有的商品信息(三个tab)
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductsDetail()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            string pids = RequestBase.GetString("dli_id");
            ViewData["hfPId"] = pids;
            return View();
            
        }


        #region  商品SEO信息

      
        /// <summary>
        /// 展示商品SEO信息
        /// </summary>
        /// <returns></returns>
        BLL.ProductSEOBase pseobll = new BLL.ProductSEOBase();
        public ActionResult ProductSEOList()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            int total = 0;//总行数
            int pageSize = 25;//每一页的行数
            int pageNumber = 1;//当前页数 
            string ptparentid = "0";
            int pid = 0;
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            if (RequestBase.GetString("hfPids") != "")
            {
                ptparentid = RequestBase.GetString("hfPids").ToString();
                pid=int.Parse(ptparentid.Split('|')[0]);
            }
            var cpt = pseobll.GetModelList(" p_id=" + pid);
            total = cpt.Count();
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            return View(cpt.ToPagedList(pageNumber, pageSize));
            
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProductSEOEdit()
        {
            this.ViewData["texOtype"] = RequestBase.GetString("otype");
            BindControl bc = new BindControl();
            ViewData["IsHasFunRole"] = Rolemanager.IsHasFunRole(EmployeeBase.e_ID, "001001001");//是否拥有管理的权限
            if (RequestBase.GetString("otype") == "modify")
            {
                Model.ProductSEOBase model = new Model.ProductSEOBase();
                string ids = RequestBase.GetString("dli_id");
                ViewData["hfPId"] = ids;
                string id = ids.Split('|')[0];
                int ptid = int.Parse(id);
                var seo = new BLL.ProductSEOBase().GetModelList(" p_ID=" + ptid);
                model = seo[0];
                return View(model);
            }
            else
            {
                string pids = RequestBase.GetString("dli_id");//1|9|1
                int ptid = int.Parse(pids.Split('|')[0]);//商品ID
                BLL.ProductSEOBase seobll = new BLL.ProductSEOBase();
                var seo = new BLL.ProductSEOBase().GetModelList(" p_ID=" + ptid);
                if (seo.Count>0)
                {
                    return Content(DWZUtil.GetResultJson("300", "该商品已存在SEO信息，请选择修改！！", "", "", "")); 
                }
                else
                {
                    ViewData["hfPId"] = pids;
                    return View();
                }
            
            }
        }

        /// <summary>
        /// 添加/修改
        /// </summary>
        public ActionResult ProductSEOEdit(Model.ProductSEOBase PseoBase)
        {
            bool result = false;
            string Message = "";
            try
            {
                if (Request.Form["texOtype"] == "add")
                {
                    string pids = Request.Form["hfPId"];
                    string id = pids.Split('|')[0];
                    int ptid = int.Parse(id);//商品ID
                    PseoBase.p_ID = ptid;
                    result = new BLL.ProductSEOBase().Add(PseoBase);
                }
                else
                {
                    string ids = Request.Form["hfPId"];
                    int pseoid = int.Parse(ids.Split('|')[0]);
                    Model.ProductSEOBase NewPseo = pseobll.GetModel(pseoid);
                    NewPseo.pseo_Content = PseoBase.pseo_Content;
                    NewPseo.pseo_Keys = PseoBase.pseo_Keys;
                    NewPseo.pseo_PicAlt = PseoBase.pseo_PicAlt;
                    NewPseo.pseo_PicTitle = PseoBase.pseo_PicTitle;
                    NewPseo.pseo_Title = PseoBase.pseo_Title;
                    result = pseobll.Update(NewPseo);
                }
               
                if (result)
                {
                    Message = "保存成功！";
                    return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功！！", "w_商品详情", "", "closeCurrent", "pseoBox", ""));
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

        #region 商品介绍

        BLL.ProductInfoBase pibll = new BLL.ProductInfoBase();
        /// <summary>
        /// 展示商品介绍 的信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductinfoList()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            int total = 0;//总行数
            int pageSize = 25;//每一页的行数
            int pageNumber = 1;//当前页数 
            string ptparentid = "0";
            int pid = 0;
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            if (RequestBase.GetString("hfPid") != "")
            {
                ptparentid = RequestBase.GetString("hfPid").ToString();
                pid = int.Parse(ptparentid.Split('|')[0]);
            }
            var cpt = pibll.GetModelList(" p_id="+pid+" and pin_isdel=0");
            total = cpt.Count();
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            return View(cpt.ToPagedList(pageNumber, pageSize));
            
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProductinfoEdit()
        {
            this.ViewData["texOtype"] = RequestBase.GetString("otype");
            BindControl bc = new BindControl();
            ViewData["IsHasFunRole"] = Rolemanager.IsHasFunRole(EmployeeBase.e_ID, "001001001");//是否拥有管理的权限
            Model.ProductInfoBase model = new Model.ProductInfoBase();
            List<SelectListItem> infoType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" }, new SelectListItem { Text = "商品推荐", Value = "1" }, new SelectListItem { Text = "商品介绍", Value = "2" } };
            ViewData["infoType"] = new SelectList(infoType, "Value", "Text");
            if (RequestBase.GetString("otype") == "modify")
            {
                string ids = RequestBase.GetString("dli_id");
                string id = ids.Split('|')[0];
                int ptid = int.Parse(id);
                model = pibll.GetModel(ptid);
                if(model.pin_Type=="商品推荐")
                {
                ViewData["infoType"] = new SelectList(infoType, "Value", "Text",1);
                }
                else if(model.pin_Type=="商品介绍")
                {
                ViewData["infoType"] = new SelectList(infoType, "Value", "Text",2);
                }

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
        [ValidateInput(false)]
        public ActionResult ProductinfoEdit(Model.ProductInfoBase PinfoBase)
        {
            bool result = false;
            string Message = "";
            int type=0;
            try
            {
                if (Request.Form["texOtype"] == "add")
                {
                    string pids = Request.Form["hfPId"];
                    string id = pids.Split('|')[0];
                    int ptid = int.Parse(id);//商品ID
                    PinfoBase.p_ID = ptid;
                    PinfoBase.pin_CreatedOn = DateTime.Now;
                    PinfoBase.pin_CreatedBy = EmployeeBase.e_ID;
                    PinfoBase.pin_MoidfyBy = EmployeeBase.e_ID;
                    PinfoBase.pin_ModifyOn = DateTime.Now;
                    PinfoBase.pin_Content = PinfoBase.pin_Content;
                    if (Request.Form["infoType"] != "chose" && Request.Form["infoType"] != null)
                    {
                        type = int.Parse(Request.Form["infoType"]);
                        if(type==1)
                        {
                            PinfoBase.pin_Type = "商品推荐";
                        } 
                        if (type == 2)
                        {
                            PinfoBase.pin_Type = "商品介绍";
                        }
                    }
                    else
                    {
                        return Content(DWZUtil.GetResultJson("300", "保存失败,请完善商品信息类别！", "", "", ""));
                    }

                    result = pibll.Add(PinfoBase);
                }
                else
                {
                    Model.ProductInfoBase NewPinfo = pibll.GetModel(PinfoBase.pin_ID);
                    if (Request.Form["infoType"] != "chose" && Request.Form["infoType"] != null)
                    {
                        type = int.Parse(Request.Form["infoType"]);
                        if (type == 1)
                        {
                            NewPinfo.pin_Type = "商品推荐";
                        }
                        if (type == 2)
                        {
                            NewPinfo.pin_Type = "商品介绍";
                        }
                    }
                    else
                    {
                        return Content(DWZUtil.GetResultJson("300", "保存失败,请完善商品信息类别！", "", "", ""));
                    }
                    NewPinfo.pin_Content = PinfoBase.pin_Content;
                    NewPinfo.pin_Title = PinfoBase.pin_Title;
                    NewPinfo.pin_Content = PinfoBase.pin_Content;
                    NewPinfo.pin_MoidfyBy = EmployeeBase.e_ID;
                    NewPinfo.pin_ModifyOn = DateTime.Now;
                    result = pibll.Update(NewPinfo);
                }
                if (result)
                {
                    Message = "保存成功！";
                    return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功！！", "", "", "closeCurrent", "piBox", ""));
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
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductinfoDelete()
        {
            bool result = false;
            string Message = "";
            try
            {
                string id = RequestBase.GetString("dli_id");
                string pid = id.Split('|')[0];
                int ptid = int.Parse(pid);//商品ID
                Model.ProductInfoBase NewPinfo = pibll.GetModel(ptid);
                NewPinfo.pin_IsDel = true;
                result = pibll.Update(NewPinfo);
                if (result)
                {
                    Message = "删除成功！";
                    return Content(DWZUtil.GetAjaxTodoJson("200", Message, "", "", "", "piBox", ""));
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
        /// <param name="otype"></param>
        /// <param name="dli_id"></param>
        /// <returns></returns>
        public ActionResult ProductinfoEnable(string otype, string dli_id)
        {

            bool result = false;
            try
            {
                string dliid = RequestBase.GetString("dli_id");
                string pid = dliid.Split('|')[0];
                Model.ProductInfoBase NewPinfo = pibll.GetModel(int.Parse(pid));
                if (otype == "disable")
                {
                    NewPinfo.pin_StatusCode = 1;
                }
                else
                {
                    NewPinfo.pin_StatusCode = 0;
                }
                result = pibll.Update(NewPinfo);
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "forward", "", "piBox", ""));
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

        #region 商品单品信息
        #region SKU
        BLL.SKUBase psbll = new BLL.SKUBase();
        BLL.ProductAttributesBase patbll = new BLL.ProductAttributesBase();
        BLL.ProductAttributeDetails padbll = new BLL.ProductAttributeDetails();
        /// <summary>
        /// 展示商品单品信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductSKUList()
        {
            int pid = 0;
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            int total = 0;//总行数
            int pageSize = 25;//每一页的行数
            int pageNumber = 1;//当前页数 
            string ptparentid = "0";
            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("txtSkucode")))
            {
                strSql.AppendFormat(" and s.sku_code like '%{0}%'", Request.Form["txtSkucode"].ToString());
            }
            if (RequestBase.GetString("hfPid") != "")
            {
                ptparentid = RequestBase.GetString("hfPid").ToString();
                pid=int.Parse(ptparentid.Split('|')[0]);
            }
            var cpt = psbll.GetModelListById(" p.p_ID="+pid+" and s.sku_isdel=0"+strSql);
            total = cpt.Tables[0].Rows.Count;
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            this.ViewData["PageList"] = cpt.Tables[0];
            return View(ViewData["PageList"]);
        }

        /// <summary>
        /// 修改
        /// </summary>
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProductSKUEdit()
        {
            this.ViewData["texOtype"] = RequestBase.GetString("otype");
            BindControl bc = new BindControl();
            ViewData["IsHasFunRole"] = Rolemanager.IsHasFunRole(EmployeeBase.e_ID, "001001001");//是否拥有管理的权限
            Model.SKUBase model = new Model.SKUBase();
            if (RequestBase.GetString("otype") == "modify")
            {
                string ids = RequestBase.GetString("dli_id");
                string id = ids.Split('|')[0];
                int ptid = int.Parse(id);
                model = psbll.GetModel(ptid);
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
        public ActionResult ProductSKUEdit(Model.SKUBase skuBase)
        {
            int result = 0;
            bool result2 = false;
            string Message = "";
            try
            {
                if (Request.Form["texOtype"] == "add")
                {
                    string pids = Request.Form["hfPId"];
                    string id = pids.Split('|')[0];
                    int ptid = int.Parse(id);//商品ID
                    skuBase.p_ID = ptid;
                    skuBase.sku_CreatedOn = DateTime.Now;
                    skuBase.sku_CreatedBy = EmployeeBase.e_ID;
                    skuBase.sku_ModifyBy= EmployeeBase.e_ID;
                    skuBase.sku_ModifyOn = DateTime.Now;
                    //保存时生成二维码
                    using (var scope = new TransactionScope())
                    {
                        result = psbll.Add(skuBase);
                        //二维码未生成成功
                        string tdCode = CreateQRCode(result);
                        if (string.IsNullOrWhiteSpace(tdCode))
                        {
                            result = -1;
                        }
                        else
                        {
                            skuBase.sku_ID = result;
                            skuBase.sku_tdcode = tdCode;
                            result2 = psbll.Update(skuBase);
                        }
                        scope.Complete();
                    }
                }
                else
                {
                    Model.SKUBase Newsku = psbll.GetModel(skuBase.sku_ID);
                    Newsku.sku_scPric = skuBase.sku_scPric;
                    Newsku.sku_Price = skuBase.sku_Price;
                    Newsku.sku_CostPrice = skuBase.sku_CostPrice;
                    Newsku.sku_Stock = skuBase.sku_Stock;
                    Newsku.sku_SalesCount = skuBase.sku_SalesCount;
                    Newsku.sku_Code = skuBase.sku_Code;
                    Newsku.sku_ModifyBy= EmployeeBase.e_ID;
                    Newsku.sku_ModifyOn = DateTime.Now;
                    result2 = psbll.Update(Newsku);
                }
                if (result > 0 || result2)
                {
                    Message = "保存成功！";
                    return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功！！", "w_商品详情", "", "closeCurrent", "pskuBox", ""));
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

        public string CreateQRCode(int id)
        {
            string result = "";
            int size = 6;
            string linkUrl,color,savePath;
            string fileName = CreateFileName(id);
            string filePath = ConfigurationManager.AppSettings["SaveQRCode"].ToString();
            linkUrl = ConfigurationManager.AppSettings["QRCodeUrl"].ToString();
            linkUrl = linkUrl + "skuid=" + id.ToString();
            color = "#000000";

            savePath = System.Web.HttpContext.Current.Server.MapPath(filePath) + fileName;
            if (QRCodeCreater.CreateQRCode(linkUrl, color, size, savePath))
            {
                result = filePath + fileName;
            }

            return result;
        }

        /// <summary>
        /// 生成文件名
        /// </summary>
        /// <param name="id">产品Id</param>
        /// <returns></returns>
        public string CreateFileName(int id)
        {
            string fileName = "";

            fileName = DateTime.Now.ToUnixTimeStamp() + id.ToString() + ".png";

            return fileName;
        }


        /// <summary>
        /// 删除
        /// </summary>
        public ActionResult ProductSKUDelete()
        {
            bool result = false;
            string Message = "";
            try
            {
                string id = RequestBase.GetString("dli_id");
                string pid = id.Split('|')[0];
                int ptid = int.Parse(pid);//商品ID
                Model.SKUBase NewSku = psbll.GetModel(ptid);
                NewSku.sku_IsDel = true;
                result = psbll.Update(NewSku);
                if (result)
                {
                    Message = "删除成功！";
                    return Content(DWZUtil.GetAjaxTodoJson("200", Message, "", "", "", "pskuBox", ""));
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
        public ActionResult ProductSKUEnable(string otype, string dli_id)
        {

            bool result = false;
            try
            {
                string dliid = RequestBase.GetString("dli_id");
                string pid = dliid.Split('|')[0];
                Model.SKUBase NewPsku = psbll.GetModel(int.Parse(pid));
                if (otype == "disable")
                {
                    NewPsku.sku_StatusCode = 1;
                }
                else
                {
                    NewPsku.sku_StatusCode = 0;
                }
                result = psbll.Update(NewPsku);
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "", "", "psBox", ""));
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
        #region 属性
        /// <summary>
        /// 属性信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductAttMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            string skuid = RequestBase.GetString("dli_id");
            string pids = RequestBase.GetString("pid");
            ViewData["hfPId"] = skuid + "|" + pids;
            return View();
        }

        public ActionResult ProductAttList()
        {
            int skuid=0;
            int pid = 0;
            int total = 0;//总行数
            int pageSize = 25;//每一页的行数
            int pageNumber = 1;//当前页数 
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            if (RequestBase.GetString("hfPId") != "")
            {
                string bb = RequestBase.GetString("hfPId");//1|1 KSUID PID
                if (bb.IndexOf(',') != -1)
                {
                    bb = bb.Substring(0, bb.IndexOf(','));
                }
                skuid = int.Parse(bb.Split('|')[0]);
                pid = int.Parse(bb.Split('|')[1]);
            }
            var cpt = patbll.GetModelListById(" and p.p_ID=" + pid + " and s.sku_ID=" + skuid);
            total = cpt.Tables[0].Rows.Count;
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            this.ViewData["PageList"] = cpt.Tables[0];
            return View(ViewData["PageList"]);
        }

        string paid="";//类别
        string parentpaid = "";//父ID
        string attrpaid = "";//值id
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProductAttrEdit()
        {
            this.ViewData["texOtype"] = RequestBase.GetString("otype");
            BindControl bc = new BindControl();
            ViewData["IsHasFunRole"] = Rolemanager.IsHasFunRole(EmployeeBase.e_ID, "001001001");//是否拥有管理的权限
            Model.ProductAttributeDetails model = new Model.ProductAttributeDetails();
            Model.ProductAttributesBase pabmodel = new Model.ProductAttributesBase();

            List<SelectListItem> selectattrType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "0" }, new SelectListItem { Text = "属性", Value = "1" }, new SelectListItem { Text = "规格", Value = "2" }, new SelectListItem { Text = "颜色", Value = "3" } };
            ViewData["selectattrType"] = new SelectList(selectattrType, "Value", "Text");


            List<SelectListItem> attribute = new List<SelectListItem>();
            attribute = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = null }, new SelectListItem { Text = "ww", Value = "40" } };
            ViewData["attribute"] = new SelectList(attribute, "Value", "Text", "请选择");


            List<SelectListItem> attrValue = new List<SelectListItem>();
            attrValue = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = null } };
            ViewData["attrValue"] = new SelectList(attrValue, "Value", "Text", "请选择");

            if (RequestBase.GetString("otype") == "modify")
            {
                string ids = RequestBase.GetString("dli_id");
                ViewData["hfPId"] = ids;
                attrpaid = ids.Split('|')[0];//pa_id
                int skuid = int.Parse(ids.Split('|')[1]);//sku_ID
                int pid = int.Parse(ids.Split('|')[2]);//p_ID
                pabmodel = patbll.GetModel(int.Parse(attrpaid));
                paid = pabmodel.pa_Type.ToString();
                parentpaid = pabmodel.pa_ParentId.ToString();
                ViewData["paid"] = paid;
                ViewData["parentpaid"] = parentpaid;
                ViewData["attrpaid"] = attrpaid;


                ViewData["selectattrType"] = new SelectList(selectattrType, "Value", "Text", paid);

                List<Model.ProductAttributesBase> modelType = patbll.GetModelList(" pa_type = " + paid+" and pa_parentId=0");
                for (int i = 0; i < modelType.Count; i++)
                {
                    attribute.Add(new SelectListItem
                    {
                        Value = modelType[i].pa_ID.ToString(),
                        Text = modelType[i].pa_Name
                    });
                }
                ViewData["attribute"] = new SelectList(attribute, "Value", "Text", parentpaid);

                List<Model.ProductAttributesBase> modelType2 = patbll.GetModelList("  pa_parentId = " + parentpaid);
                for (int i = 0; i < modelType2.Count; i++)
                {
                    attrValue.Add(new SelectListItem
                    {
                        Value = modelType2[i].pa_ID.ToString(),
                        Text = modelType2[i].pa_Name
                    });
                }
                ViewData["attrValue"] = new SelectList(attrValue, "Value", "Text", attrpaid);
                return View();
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
        public ActionResult ProductAttrEdit(Model.ProductAttributesBase attrbase)
        {
            bool result = false;
            string Message = "";
            Model.ProductAttributeDetails dmodel = new Model.ProductAttributeDetails();
            try
            {
                if (Request.Form["texOtype"] == "add")
                {
                    string hfpid = Request.Form["hfPId"];//1|1
                    int skuid = int.Parse(hfpid.Split('|')[0]);
                    string typeid = Request.Form["selectattrType"];
                    string parentid = Request.Form["attribute"];
                    string paid = Request.Form["attrValue"];
                    dmodel.pa_ID = int.Parse(paid);
                    dmodel.sku_ID = skuid;
                    result = padbll.Add(dmodel);
                }
                else
                {
                    string pids = Request.Form["attrValue"];
                    string hfpid = Request.Form["hfPId"];//44|1|1|1
                    int skuid = int.Parse(hfpid.Split('|')[1]);
                    int padid = int.Parse(hfpid.Split('|')[3]);
                    dmodel.pa_ID = int.Parse(pids);
                    dmodel.sku_ID = skuid;
                    dmodel.pad_ID = padid;
                    result = padbll.Update(dmodel);
                }
                if (result)
                {
                    Message = "保存成功！";
                    return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功！！", "", "", "closeCurrent", "patBox", ""));
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

        public ActionResult ProductAttrDelete()
        {
            bool result = false;
            string Message = "";
            try
            {
                string id = RequestBase.GetString("dli_id");
                string pid = id.Split('|')[3];
                int ptid = int.Parse(pid);//pad_id
                result = padbll.Delete(ptid);
                if (result)
                {
                    Message = "删除成功！";
                    return Content(DWZUtil.GetAjaxTodoJson("200", Message, "", "", "", "patBox", ""));
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
        /// <param name="otype"></param>
        /// <param name="dli_id"></param>
        /// <returns></returns>
        //public ActionResult ProductAttrEnable(string otype, string dli_id)
        //{

        //    bool result = false;
        //    try
        //    {
        //        string dliid = RequestBase.GetString("dli_id");
        //        string pid = dliid.Split('|')[0];
        //        BLL.ProductAttributesBase pabll = new BLL.ProductAttributesBase();
        //        Model.ProductAttributesBase NewPsku = pabll.GetModel(int.Parse(pid));
        //        if (otype == "disable")
        //        {
        //            NewPsku.pa_StatusCode = 1;
        //        }
        //        else
        //        {
        //            NewPsku.pa_StatusCode = 0;
        //        }
        //        result = pabll.Update(NewPsku);
        //        if (result)
        //        {
        //            return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "", "", "patBox", ""));
        //        }
        //        else
        //        {
        //            return Content(DWZUtil.GetResultJson("300", "操作失败！！", "", "", ""));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content(DWZUtil.GetResultJson("300", "操作失败！！", "", "", ""));
        //    }

        //}

        //联动下拉菜单
        [HttpGet]
        public string Getattr(string id)
        {
            StringBuilder attr = new StringBuilder();
            if (RequestBase.GetString("code") != "")
            {
                id = RequestBase.GetString("code");
            }
            List<SelectListItem> selectattrP = new List<SelectListItem>();
            BLL.ProductAttributesBase ptbll = new BLL.ProductAttributesBase();
            List<Model.ProductAttributesBase> modelType = ptbll.GetModelList(" pa_parentId = 0 and pa_type=" + id);
            StringBuilder sbGoodsName = new StringBuilder();
            attr.Append("[[\"0\",\"请选择\"]");
            for (int i = 0; i < modelType.Count; i++)
            {
                attr.Append(",[");
                attr.Append("\"" + modelType[i].pa_ID.ToString() + "\",");
                attr.Append("\"" + modelType[i].pa_Name + "\"");
                attr.Append("]");
            }


            attr.Append("]");

            return attr.ToString();
        }
        [HttpGet]
        public string Getattrvalue(string id)
        {
            StringBuilder attr = new StringBuilder();
            if (RequestBase.GetString("code") != "")
            {
                id = RequestBase.GetString("code");
            }
            List<SelectListItem> selectattrP = new List<SelectListItem>();
            BLL.ProductAttributesBase ptbll = new BLL.ProductAttributesBase();
            List<Model.ProductAttributesBase> modelType = ptbll.GetModelList(" pa_parentId = " + id);
            StringBuilder sbGoodsName = new StringBuilder();
            attr.Append("[[\"0\",\"请选择\"]");

            for (int i = 0; i < modelType.Count; i++)
            {

                attr.Append(",[");
                attr.Append("\"" + modelType[i].pa_ID.ToString() + "\",");
                attr.Append("\"" + modelType[i].pa_Name + "\"");
                attr.Append("]");
            }


            attr.Append("]");

            return attr.ToString();
        }

        #endregion
        #region  图册
        /// <summary>
        /// 属性信息
        /// </summary>
        /// <returns></returns>
        BLL.ProductImgBase pingbll = new BLL.ProductImgBase();
        public ActionResult ProductImgMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            string skuid = RequestBase.GetString("dli_id");
            string pids = RequestBase.GetString("pid");
            ViewData["hfPId"] = skuid + "|" + pids;
            return View();
        }

        public ActionResult ProductImgList()
        {
            int skuid = 0;
            int pid = 0;
            int total = 0;//总行数
            int pageSize = 25;//每一页的行数
            int pageNumber = 1;//当前页数 
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            if (RequestBase.GetString("hfPId") != "")
            {
                string bb = RequestBase.GetString("hfPId");//1|1 KSUID PID
                if (bb.IndexOf(',') > 0)
                {
                    bb = bb.Substring(0, bb.Length - 1);
                }
                skuid = int.Parse(bb.Split('|')[0]);
                pid = int.Parse(bb.Split('|')[1]);
            }
            var cpt = pingbll.GetModelListById("and pimg.pi_isDel=0 and s.sku_ID=" + skuid);
            total = cpt.Tables[0].Rows.Count;
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            this.ViewData["PageList"] = cpt.Tables[0];
            return View(ViewData["PageList"]);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProductImgEdit()
        {
            Model.ProductImgBase pimodel = new Model.ProductImgBase();
            this.ViewData["texOtype"] = RequestBase.GetString("otype");
            ViewData["hf_luj"] = ConfigurationManager.AppSettings["SaveImage"];//图片的存储路径
            BindControl bc = new BindControl();
            ViewData["IsHasFunRole"] = Rolemanager.IsHasFunRole(EmployeeBase.e_ID, "001001001");//是否拥有管理的权限

            List<SelectListItem> ImgType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" }, new SelectListItem { Text = "封面", Value = "1" }, new SelectListItem { Text = "非封面", Value = "0" } };
            ViewData["ImgType"] = new SelectList(ImgType, "Value", "Text");

            if (RequestBase.GetString("otype") == "modify")
            {
                string ids = RequestBase.GetString("dli_id");
                ViewData["hfPId"] = ids;
                int piid = int.Parse(ids.Split('|')[0]);//图片ID
                int skuid = int.Parse(ids.Split('|')[1]);
                bool typeid = bool.Parse(ids.Split('|')[2]);//图片类别
                pimodel = pingbll.GetModel(piid);
                ViewData["LogoUrl"] = pimodel.pi_Url;
                if (bool.Parse(ids.Split('|')[2]))
                {
                ViewData["ImgType"] = new SelectList(ImgType, "Value", "Text",1);
                }
                else
                {
                    ViewData["ImgType"] = new SelectList(ImgType, "Value", "Text", 0);
                }
                return View(pimodel);
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
        public ActionResult ProductImgEdit(Model.ProductImgBase imgbase)
        {
            bool result = false;
            string Message = "";
            Model.ProductImgBase imodel = new Model.ProductImgBase();
            try
            {
                if (Request.Form["texOtype"] == "add")
                {
                    string hfpid = Request.Form["hfPId"];//1|1 skuid pid
                    int skuid = int.Parse(hfpid.Split('|')[0]);
                    imgbase.pi_Url = Request.Form["FileInputEId"].ToString();
                    ViewData["LogoUrl"] = imgbase.pi_Url;
                    imgbase.sku_ID = skuid;
                    imgbase.pi_IsDel = false;
                    imgbase.pi_StatusCode = 0;
                    var imodellist = pingbll.GetModelList(" sku_Id=" + skuid + " and pi_Type=1 and pi_isDel=0"); 
                    if (Request.Form["ImgType"] == "chose")
                    {
                        return Content(DWZUtil.GetResultJson("300", "请选择图片类别！！", "", "", ""));
                    }
                    else if (int.Parse(Request.Form["ImgType"]) == 1 && imodellist.Count > 0)
                    {
                        return Content(DWZUtil.GetResultJson("300", "该商品已设置封面图片，请选择其他类别！！", "", "", ""));
                    }
                    else
                    {
                        if (Request.Form["ImgType"] == "1")
                        {
                            imgbase.pi_Type = true;
                        }
                        else
                        {
                            imgbase.pi_Type = false;
                        }
                    }
                    result = pingbll.Add(imgbase);
                }
                else
                {
                    string pids = Request.Form["attrValue"];
                    string hfpid = Request.Form["hfPId"];//2|1|2 m["pi_ID"]|@item["sku_ID"]|@item["pi_Type"
                    int skuid = int.Parse(hfpid.Split('|')[1]);
                    int piid = int.Parse(hfpid.Split('|')[0]);
                    //bool pitype = bool.Parse(hfpid.Split('|')[2]);
                    Model.ProductImgBase newimg = pingbll.GetModel(piid);
                    newimg.pi_Url = Request.Form["FileInputEId"].ToString();
                    var imodellist = pingbll.GetModelList(" sku_Id=" + skuid + " and pi_Type=1  and pi_isDel=0");

                    if (Request.Form["ImgType"] == "chose")
                    {
                        return Content(DWZUtil.GetResultJson("300", "请选择图片类别！！", "", "", ""));
                    }
                    else if (int.Parse(Request.Form["ImgType"]) == 1 && imodellist.Count > 0 && imodellist[0].pi_ID != newimg.pi_ID)
                    {
                        return Content(DWZUtil.GetResultJson("300", "该商品已设置封面图片，请选择其他类别！！", "", "", ""));
                    }
                    else
                    {
                        if (Request.Form["ImgType"] == "1")
                        { 
                            newimg.pi_Type = true;
                        }
                        else
                        { 
                        newimg.pi_Type=false;
                        }
                    }
                    result = pingbll.Update(newimg);
                }
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功！！", "", "forward", "closeCurrent", "pimgBox", ""));
                   // return Content(DWZUtil.GetResultJson("200", "操作成功！！", "w_商品图册", "", "closeCurrent"));
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "保存失败！！", "", "", ""));
                }
            }
            catch
            {
                Message = "程序异常，保存失败";
                return Content(DWZUtil.GetResultJson("300", "保存失败！！", "", "", ""));
            }
        }

        public ActionResult ProductImgDelete()
        {
            bool result = false;
            string Message = "";
            try
            {
                string id = RequestBase.GetString("dli_id");
                string pid = id.Split('|')[0];
                int ptid = int.Parse(pid);//pad_id
                Model.ProductImgBase NewPimg = pingbll.GetModel(int.Parse(pid));
                NewPimg.pi_IsDel = true;
                result = pingbll.Update(NewPimg);
                if (result)
                {
                    Message = "删除成功！";
                    return Content(DWZUtil.GetAjaxTodoJson("200", Message, "", "", "", "pimgBox", ""));
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
        /// <param name="otype"></param>
        /// <param name="dli_id"></param>
        /// <returns></returns>
        public ActionResult ProductImgEnable(string otype, string dli_id)
        {

            bool result = false;
            try
            {
                string dliid = RequestBase.GetString("dli_id");
                string pid = dliid.Split('|')[0];
                Model.ProductImgBase NewPsku = pingbll.GetModel(int.Parse(pid));
                if (otype == "disable")
                {
                    NewPsku.pi_StatusCode = 1;
                }
                else
                {
                    NewPsku.pi_StatusCode = 0;
                }
                result = pingbll.Update(NewPsku);
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "", "", "pimgBox", ""));
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
        #endregion

        #endregion
    }
}
