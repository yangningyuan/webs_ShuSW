using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data.Common;
using Common;
using System.Configuration;
using System.Text;
using System.Data;

namespace webs_YueyxShop.Web.Controllers
{
    public class ProductAttributesController : BaseController
    {

        private RoleManager Rolemanager = new RoleManager();
        private BLL.ProductAttributesBase pabll = new BLL.ProductAttributesBase();
        private BLL.ProductTypeBase ptbll = new BLL.ProductTypeBase();
        private readonly RoleManager _roleManager = new RoleManager();
        public ActionResult ProductAttributesMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            List<SelectListItem> select1 = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "0" },new SelectListItem { Text = "商品属性", Value = "1" }, new SelectListItem { Text = "商品规格", Value = "2" } ,new SelectListItem { Text = "商品颜色", Value = "3" } };
            ViewData["select1"] = new SelectList(select1, "Value", "Text", "请选择");
            BLL.ProductTypeBase ptbll = new BLL.ProductTypeBase();
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
            List<SelectListItem> selectType2 = new List<SelectListItem>();
            selectType2 = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            ViewData["selectType2"] = new SelectList(selectType2, "Value", "Text", "请选择");
            return View();
        }


        [HttpPost]
        public ActionResult ProductAttributesList()
        {
            int total = 0;//总行数
            int pageSize = 25;//每一页的行数
            int pageNumber = 1;//当前页数 
            string paparentid = "0";
            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrEmpty(Request.Form["txtPAname"]))
            {
                strSql.AppendFormat(" and  pa.pa_Name='{0}' ", Request.Form["txtPAname"]);
            }
            if (Request.Form["select1"]!="0")
            {
                strSql.AppendFormat(" and pa.pa_Type={0}", Request.Form["select1"]);
            }
            if (Request.Form["selectType"]!="chose")
            {
                if (!string.IsNullOrEmpty(Request.Form["selectType2"]) && Request.Form["selectType2"] != "chose")
                {
                    strSql.AppendFormat(" and pt.pt_ID in(select pt_id from ProductTypeBase where pt_ParentId={0} and pt_Isdel=0 and pt_statusCode=0)", Request.Form["selectType2"]);
                }
                else
                {
                    strSql.AppendFormat(" and pt.pt_ID in(select pt_id from ProductTypeBase where pt_ParentId in (select pt_id from ProductTypeBase where pt_ParentId={0}  and pt_Isdel=0 and pt_statusCode=0))", Request.Form["selectType"]);

                }
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            if (RequestBase.GetString("hfPid") != "")
            {
                paparentid = RequestBase.GetString("hfPid").ToString();
            }
            var cpt = pabll.GetListwithtype(" pt.pt_ID=pa.pt_Id and pa.pa_parentId=" + int.Parse(paparentid) + " and pa.pa_isdel=0 "+strSql);

            total = cpt.Tables[0].Rows.Count;
            //string typeName;
            //Model.ProductTypeBase typemodel = ptbll.GetModel(cpt[0].pt_Id);
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            this.ViewData["PageList"] = GetPagedTable(cpt.Tables[0], pageNumber, pageSize);
            //iewBag.painfo = cpt.ToPagedList(pageNumber, pageSize);
            //this.ViewData["TypeName"] = typeName;
            return View(ViewData["PageList"]);
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

        // 编辑
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProductAttributesEdit()
        {
            Model.ProductAttributesBase pamodel = new Model.ProductAttributesBase();
            this.ViewData["texOtype"] = RequestBase.GetString("otype");
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限

            List<SelectListItem> selectType2 = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            ViewData["selectType2"] = new SelectList(selectType2, "Value", "Text");
            if (RequestBase.GetString("otype") == "modify")//编辑
            {
                string ids = RequestBase.GetString("dli_id");
                string id = ids.Split('|')[0];//属性ID
                string typeid = ids.Split('|')[4];//属性类别
                string Pid = ids.Split('|')[5];//类别ID
                int ptid = int.Parse(id);
                pamodel = pabll.GetModel(ptid);
                if (pamodel.pa_Type == 1&&pamodel.pa_ParentId!=0)
                {
                    List<SelectListItem> select1 = new List<SelectListItem> { new SelectListItem { Text = "商品属性", Value = "1" } };
                    ViewData["select1"] = new SelectList(select1, "Value", "Text");
                    ViewData["selectType"] = null;
                }
                else if (pamodel.pa_Type == 2 && pamodel.pa_ParentId != 0)
                {
                    List<SelectListItem> select1 = new List<SelectListItem> { new SelectListItem { Text = "商品规格", Value = "2" } };
                    ViewData["select1"] = new SelectList(select1, "Value", "Text");
                    ViewData["selectType"] = null;
                }
                else if (pamodel.pa_Type == 3 && pamodel.pa_ParentId != 0)
                {
                    List<SelectListItem> select1 = new List<SelectListItem> { new SelectListItem { Text = "商品颜色", Value = "3" } };
                    ViewData["select1"] = new SelectList(select1, "Value", "Text");
                    ViewData["selectType"] = null;
                }
                else
                {
                    List<SelectListItem> select1 = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "0" }, new SelectListItem { Text = "商品属性", Value = "1" }, new SelectListItem { Text = "商品规格", Value = "2" }, new SelectListItem { Text = "商品颜色", Value = "3" } };
                    ViewData["select1"] = new SelectList(select1, "Value", "Text", typeid);
                    List<Model.ProductTypeBase> modelType = ptbll.GetModelList(" pt_parentId = 0 and pt_IsDel=0 and pt_StatusCode=0");//大类

                    Model.ProductTypeBase modelm = ptbll.GetModel(int.Parse(Pid));//当前小类，它的父ID是中类ID,PID=9，中类ID是7
                    Model.ProductTypeBase modelb = ptbll.GetModel(modelm.pt_ParentId);//当前中类,它的父ID是大类ID，大类ID是3
                    List<Model.ProductTypeBase> modelType2 = ptbll.GetModelList("  pt_IsDel=0 and pt_StatusCode=0 and pt_parentId = " + modelb.pt_ParentId);//中类
                    List<Model.ProductTypeBase> modelType3 = ptbll.GetModelList(" pt_IsDel=0 and pt_StatusCode=0 and pt_parentId = " + modelm.pt_ParentId);//小类
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
                    ViewData["selectType"] = new SelectList(selectType, "Value", "Text", modelb.pt_ParentId);

                    //加载中类的下拉菜单
                    for (int i = 0; i < modelType2.Count; i++)
                    {
                        selectType2.Add(new SelectListItem
                        {
                            Value = modelType2[i].pt_ID.ToString(),
                            Text = modelType2[i].pt_Name
                        });
                    }
                    ViewData["selectType2"] = new SelectList(selectType2, "Value", "Text", modelb.pt_ID);

                   
                
                }
                return View(pamodel);
            }
            else//添加
            {
                string pids = RequestBase.GetString("dli_id");
                ViewData["hfPId"] = pids;
                string fid = pids.Split('|')[0];
                string type = pids.Split('|')[3];
                int ffid = 0;
                int ttype = 0;
                if (fid != "" && type != "")
                {
                    ffid = int.Parse(fid);
                    ttype = int.Parse(type);
                } 
                if (ttype == 1 && ffid != 0)
                {
                    List<SelectListItem> select1 = new List<SelectListItem> { new SelectListItem { Text = "商品属性", Value = "1" } };
                    ViewData["select1"] = new SelectList(select1, "Value", "Text");
                    ViewData["selectType"] = null;
                }
                else if (ttype == 2 && ffid != 0)
                {
                    List<SelectListItem> select1 = new List<SelectListItem> { new SelectListItem { Text = "商品规格", Value = "2" } };
                    ViewData["select1"] = new SelectList(select1, "Value", "Text");
                    ViewData["selectType"] = null;
                }
                else if (ttype == 3 && ffid != 0)
                {
                    List<SelectListItem> select1 = new List<SelectListItem> { new SelectListItem { Text = "商品颜色", Value = "3" } };
                    ViewData["select1"] = new SelectList(select1, "Value", "Text");
                    ViewData["selectType"] = null;
                }
                else
                {
                    List<SelectListItem> select1 = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "0" }, new SelectListItem { Text = "商品属性", Value = "1" }, new SelectListItem { Text = "商品规格", Value = "2" }, new SelectListItem { Text = "商品颜色", Value = "3" } };
                    ViewData["select1"] = new SelectList(select1, "Value", "Text");
                    BLL.ProductTypeBase ptbll = new BLL.ProductTypeBase();
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
                
                }
                return View();
            }
        }

        // 修改/添加
        public ActionResult ProductAttributesEdit(Model.ProductAttributesBase ProductAttributes)
        {
            int result = 0;
            bool resultup = false;
            string Message = "";
            if (Request.Form["texOtype"] == "add")
            {
                ViewData["hf_luj"] = ConfigurationManager.AppSettings["SaveImage"];//图片的存储路径
                var hfpid = Request.Form["hfPId"];
                var pid = hfpid.Split('|')[0];
                string player = hfpid.Split('|')[1];
                int layer = int.Parse(player);
                var code = hfpid.Split('|')[2];
                var typeid = hfpid.Split('|')[3];
                //                DataSet fupt = pabll.GetList(" pa_parentId =" + pid);
                if (pid != "0")
                {
                    Model.ProductAttributesBase fupt = pabll.GetModel(int.Parse(pid));
                    if (fupt.pa_Type == 1)
                    {
                        ProductAttributes.pa_Type = 1;
                    }
                    else if (fupt.pa_Type == 0)
                    {
                        ProductAttributes.pa_Type = 2;
                    }
                    else
                    {
                        ProductAttributes.pa_Type = int.Parse(Request.Form["select1"]);
                    }
                    ProductAttributes.pt_Id = fupt.pt_Id;
                }
                else
                {
                    if (Request.Form["select1"] == "0")
                    {
                        return Content(DWZUtil.GetResultJson("300", "请选择属性类别！！", "", "", ""));
                    }
                    else
                    {
                        ProductAttributes.pa_Type = int.Parse(Request.Form["select1"]);
                    }
                    if (Request.Form["selectType2"] == "chose")
                    {
                        return Content(DWZUtil.GetResultJson("300", "请选择商品类别！！", "", "", ""));
                    }
                    else
                    { 
                        ProductAttributes.pt_Id = int.Parse(Request.Form["selectType2"]);
                    }
                }
                ProductAttributes.pa_ParentId = int.Parse(pid);
                ProductAttributes.pa_IsDel = false;
                ProductAttributes.pa_CreatedOn = DateTime.Now;
                if (int.Parse(pid) == 0)
                {
                    ProductAttributes.pa_Layer = layer;
                    code = "";
                }
                else
                {
                    ProductAttributes.pa_Layer = layer + 1;
                }
                ProductAttributes.pa_StatusCode = 0;
                string BianMa = pabll.GetCode(code, layer);
                ProductAttributes.pa_Code = BianMa;//001003
                int sort = pabll.GetSort(pid, layer);
                ProductAttributes.pa_Sort = sort;
                
                result = pabll.Add(ProductAttributes);

            }
            else
            {
                Model.ProductAttributesBase newpt = pabll.GetModel(ProductAttributes.pa_ID);
                newpt.pa_Name = ProductAttributes.pa_Name;
                if (newpt.pa_ParentId == 0)
                {
                    if (Request.Form["select1"] == "0")
                    {
                        return Content(DWZUtil.GetResultJson("300", "请选择属性类别！！", "", "", ""));
                    }
                    else
                    {
                        newpt.pa_Type = int.Parse(Request.Form["select1"]);
                    }
                    if (Request.Form["selectType2"] == "chose")
                    {
                        return Content(DWZUtil.GetResultJson("300", "请选择商品类别！！", "", "", ""));
                    }
                    else
                    {
                        newpt.pt_Id = int.Parse(Request.Form["selectType2"]);
                    }
                }
                if (newpt.pa_ParentId == 0)
                {
                    resultup = pabll.UpdateList(newpt);
                }
                else
                {
                    resultup = pabll.Update(newpt);
                }
            }
            if (result > 0 || resultup )
            {
                return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功!!", "", "", "closeCurrent", "patBox", ""));
            }
            else
            {
                return Content(DWZUtil.GetResultJson("300", "保存失败！！", "", "", ""));
            }
        }

        //联动下拉菜单
        [HttpGet]
        public string GetBattr(string id)
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
                List<Model.ProductTypeBase> modelType = ptbll.GetModelList(" pt_parentId = " + id + " and pt_isdel =0 and pt_statusCode=0");
                StringBuilder sbGoodsName = new StringBuilder();
                attr.Append("[[\"chose\",\"请选择\"]");
                for (int i = 0; i < modelType.Count; i++)
                {
                    attr.Append(",[");
                    attr.Append("\"" + modelType[i].pt_ID.ToString() + "\",");
                    attr.Append("\"" + modelType[i].pt_Name + "\"");
                    attr.Append("]");
                }


                attr.Append("]");

                return attr.ToString();
            }
        }
        [HttpGet]
        public string GetMattr(string id)
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
                List<Model.ProductTypeBase> modelType = ptbll.GetModelList(" pt_parentId = " + id + " and pt_isdel =0 and pt_statusCode=0");
                StringBuilder sbGoodsName = new StringBuilder();
                attr.Append("[[\"chose\",\"请选择\"]");

                for (int i = 0; i < modelType.Count; i++)
                {

                    attr.Append(",[");
                    attr.Append("\"" + modelType[i].pt_ID.ToString() + "\",");
                    attr.Append("\"" + modelType[i].pt_Name + "\"");
                    attr.Append("]");
                }


                attr.Append("]");

                return attr.ToString();
            }
        }




        // 删除
        [HttpPost]
        public ActionResult ProductAttributesDelete()
        {

            bool result = false;
            string Message = "";
            try
            {
                string dliid = RequestBase.GetString("dli_id");
                string pid = dliid.Split('|')[0];
                List<Model.ProductAttributesBase> model = pabll.GetModelList(" pa_parentid =" + pid);
                if (model.Count > 0)
                {
                    Message = "该类别下有其它子类，不允许删除！";
                    return Content(DWZUtil.GetResultJson("300", Message, "", "", ""));

                }
                var palist = new BLL.ProductAttributeDetails().GetModelList(" sku_ID in (select sku_ID from skubase where sku_IsDel=0) and pa_ID=" + pid);
                if (palist.Count > 0)
                {
                    return Content(DWZUtil.GetResultJson("300", "该属性已被引用，不允许删除", "", "", ""));
                }
                else
                {
                    Model.ProductAttributesBase pamodel = new BLL.ProductAttributesBase().GetModel(int.Parse(pid));
                    pamodel.pa_IsDel = true;
                    result = pabll.Update(pamodel);
                }
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "删除成功！！", "", "forward", "", "patBox", ""));
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



        // 启/禁用
        public ActionResult ProductAttributesEnable(string otype, string dli_id)
        {

            bool result = false;
            try
            {
                string dliid = RequestBase.GetString("dli_id");
                string pid = dliid.Split('|')[0];
                Model.ProductAttributesBase NewMenu = pabll.GetModel(int.Parse(pid));
                if (NewMenu.pa_Layer == 1)
                { 
                    if (otype == "disable")
                    {
                        result = pabll.UpdateList2(1, int.Parse(pid));
                    }
                    else
                    {
                        result = pabll.UpdateList2(0, int.Parse(pid));
                    }
                }
                else
                { 
                if (otype == "disable")
                {
                    NewMenu.pa_StatusCode = 1;
                }
                else
                {
                    NewMenu.pa_StatusCode = 0;
                }
                result = pabll.Update(NewMenu);
                }
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "forward", "", "patBox", ""));
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
