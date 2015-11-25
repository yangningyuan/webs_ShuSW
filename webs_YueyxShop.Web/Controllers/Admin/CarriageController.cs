using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Common;
using Common;
using PagedList;
using System.Configuration;
using System.Text;

namespace webs_YueyxShop.Web.Controllers
{
    public class CarriageController : BaseController
    {

        private RoleManager Rolemanager = new RoleManager();
        private BLL.CarriageTempleteBase pctbll = new BLL.CarriageTempleteBase();
        private Model.CarriageTempleteBase ctmodel = new Model.CarriageTempleteBase();
        private BLL.CarriageBase pcbll = new BLL.CarriageBase();
        private Model.CarriageBase cmodel = new Model.CarriageBase();
        private BLL.RegionBase regbll = new BLL.RegionBase();
        private Model.RegionBase regmodel = new Model.RegionBase();
        private readonly RoleManager _roleManager = new RoleManager();
        private string reg_list = "";
        #region  运费模板
        public ActionResult CarriageTempleteMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            List<SelectListItem> select1 = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "0" }, new SelectListItem { Text = "按件数", Value = "1" }, new SelectListItem { Text = "按重量", Value = "2" }, new SelectListItem { Text = "按体积", Value = "3" } };
            ViewData["select1"] = new SelectList(select1, "Value", "Text");
            return View();
        }


        public ActionResult CarriageTempleteList()
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
            if (RequestBase.GetString("hfPid") != "")
            {
                ptparentid = RequestBase.GetString("hfPid").ToString();
            }
            if (!string.IsNullOrEmpty(Request.Form["txtctname"]))
            {
                strSql.AppendFormat(" and ct_Name like '%{0}%'", Request.Form["txtctname"]);// = Request.Form["txtctname"].ToString();
            }
            if (int.Parse(Request.Form["select1"])!=0)
            {
                strSql.AppendFormat(" and ct_ValuationType={0}", Request.Form["select1"]);// Request.Form["select1"].ToString();
            }
            var cpt = pctbll.GetModelList(" ct_IsDel =0" +strSql );
            total = cpt.Count();
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            return View(cpt.ToPagedList(pageNumber, pageSize));
        }


        // 编辑
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult CarriageTempleteEdit()
        {
            this.ViewData["texOtype"] = RequestBase.GetString("otype");
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限

            List<SelectListItem> select1 = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "0" }, new SelectListItem { Text = "按件数", Value = "1" }, new SelectListItem { Text = "按重量", Value = "2" }, new SelectListItem { Text = "按体积", Value = "3" } };
            ViewData["select1"] = new SelectList(select1, "Value", "Text");
            if (RequestBase.GetString("otype") == "modify")//编辑
            {
                string ids = RequestBase.GetString("dli_id");
                string id = ids.Split('|')[0];//属性ID
                int ptid = int.Parse(id);
                ctmodel = pctbll.GetModel(ptid);

                ViewData["select1"] = new SelectList(select1, "Value", "Text",ctmodel.ct_ValuationType.ToString());

                    return View(ctmodel);
            }
            else//添加
            {
                return View();
            }
        }

        // 修改/添加
        public ActionResult CarriageTempleteEdit(Model.CarriageTempleteBase CarriageTemplete)
        {
            int result = 0;
            bool resultup = false;
            string Message = "";
            if (Request.Form["texOtype"] == "add")
            {
                var hfpid = Request.Form["hfPId"];
                var pid = hfpid.Split('|')[0];
                if (Request.Form["select1"] != "0")
                {
                    CarriageTemplete.ct_ValuationType = int.Parse(Request.Form["select1"]);
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "请选择计价方式！！", "", "", ""));
                }
                CarriageTemplete.ct_CreateOn = DateTime.Now;
                CarriageTemplete.ct_CreateBy = EmployeeBase.e_ID;
                CarriageTemplete.ct_ModifyBy = EmployeeBase.e_ID;
                CarriageTemplete.ct_ModifyOn = DateTime.Now;
                result = pctbll.Add(CarriageTemplete);

            }
            else
            {
                Model.CarriageTempleteBase newpt = pctbll.GetModel(CarriageTemplete.ct_ID);
                newpt.ct_Name = CarriageTemplete.ct_Name;
                newpt.ct_ValuationType = int.Parse(Request.Form["select1"].ToString());
                resultup = pctbll.Update(newpt);
            }
            if (result > 0 || resultup)
            {
                return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功!!", "", "", "closeCurrent", "carrtBox", ""));
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
        public ActionResult CarriageTempleteDelete()
        {
            bool result = false;
            string Message = "";
            try
            {
                string id = RequestBase.GetString("dli_id");
                string pid = id.Split('|')[0];
                int ptid = int.Parse(pid);//商品ID
                
                var list = new BLL.ProductBase().GetModelList(" p_IsDel=0 and ct_ID="+ptid);
                if (list.Count > 0)
                {
                    return Content(DWZUtil.GetResultJson("300", "该运费模板已被引用，无法删除", "", "", ""));
                }
                else
                {
                    Model.CarriageTempleteBase NewP = pctbll.GetModel(ptid);
                    NewP.ct_IsDel = true;
                    result = pctbll.Update(NewP);
                }
                if (result)
                {
                    Message = "删除成功！";
                    return Content(DWZUtil.GetAjaxTodoJson("200", Message, "", "", "", "carrtBox", ""));
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
        public ActionResult CarriageTempleteEnable(string otype, string dli_id)
        {

            bool result = false;
            try
            {
                string dliid = RequestBase.GetString("dli_id");
                string pid = dliid.Split('|')[0];
                Model.CarriageTempleteBase NewP = pctbll.GetModel(int.Parse(pid));
                if (otype == "disable")
                {
                    NewP.ct_StatusCode = 1;
                }
                else
                {
                    NewP.ct_StatusCode = 0;
                }
                result = pctbll.Update(NewP);
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "forward", "", "carrtBox", ""));
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


        #region 模板详情
        public ActionResult CarriageMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            string  ptparentid="";
            if (RequestBase.GetString("dli_id") != "")
            {
               ptparentid = RequestBase.GetString("dli_id").ToString();
            }
            ViewData["ctId"] = ptparentid.Split('|')[0];
            return View();
        }


        public ActionResult CarriageList()
        {
            int total = 0;//总行数
            int pageSize = 25;//每一页的行数
            int pageNumber = 1;//当前页数 
            int ctid = 0;
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            if (RequestBase.GetString("hfPid") != "")
            {
                ctid = int.Parse(RequestBase.GetString("hfPid"));
            }
            var cpt = pcbll.GetModelListByid("and  c.car_IsDel =0 and c.ct_ID=" + ctid);
            total = cpt.Tables[0].Rows.Count;
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            this.ViewData["PageList"] = GetPagedTable(cpt.Tables[0], pageNumber, pageSize);
            return View(ViewData["PageList"]);
            //return View(cpt.ToPagedList(pageNumber, pageSize));
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
        public ActionResult CarriageEdit()
        {
            this.ViewData["texOtype"] = RequestBase.GetString("otype");
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限

            string pids = RequestBase.GetString("dli_id");//1/43
            ViewData["hfPId"] = pids;
            BLL.ShipTypeBase pstbll = new BLL.ShipTypeBase();
            List<Model.ShipTypeBase> stmodel = pstbll.GetModelList(" st_IsDel = 0 and st_StatusCode=0 ");
            List<SelectListItem> shipType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            for (int i = 0; i < stmodel.Count; i++)
            {
                shipType.Add(new SelectListItem
                {
                    Value = stmodel[i].st_ID.ToString(),
                    Text = stmodel[i].st_Name
                });
            }
            ViewData["shipType"] = new SelectList(shipType, "Value", "Text");

            Model.CarriageTempleteBase pctmodel = pctbll.GetModel(int.Parse(pids.Split('|')[0]));
            int? units = pctmodel.ct_ValuationType;
            List<SelectListItem> measurementUnits = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "0" }, new SelectListItem { Text = "件", Value = "1" }, new SelectListItem { Text = "千克", Value = "2" }, new SelectListItem { Text = "立方米", Value = "3" } };
            ViewData["measurementUnits"] = new SelectList(measurementUnits, "Value", "Text",units.ToString());
            ViewData["measurementUnits2"] = new SelectList(measurementUnits, "Value", "Text",units.ToString());
            if (RequestBase.GetString("otype") == "modify")//编辑
            {
                string ids = RequestBase.GetString("dli_id");//模板ID|运费ID
                string id = ids.Split('|')[1];//运费ID
                string ctid = ids.Split('|')[0];//模板ID
                int ptid = int.Parse(id);
                cmodel = pcbll.GetModel(ptid);
                ViewData["shipType"] = new SelectList(shipType, "Value", "Text", cmodel.St_ID);
                ViewData["measurementUnits"] = new SelectList(measurementUnits, "Value", "Text", cmodel.car_measurementUnits.ToString());
                ViewData["hfPId"] = ids;
                string regname = "";
                if (!string.IsNullOrEmpty(RequestBase.GetString("list")))
                {
                    string regID = RequestBase.GetString("list");
                    if (regID.Length > 0)
                    {
                        regID = regID.Substring(0, regID.Length - 1);
                        var reg = regbll.GetModelList(" reg_ID in(" + regID + ")");
                        foreach (var item in reg)
                        {
                            regname += item.reg_Name + ",";
                        }
                        if (regname.Length > 0)
                            regname = regname.Substring(0, regname.Length - 1);
                        reg_list = regID;
                    }
                    ViewData["reglist"] = RequestBase.GetString("list").Substring(0, RequestBase.GetString("list").Length-1);
                    ViewData["regName"] = regname;
                }
                else
                {
                    ViewData["reglist"] = cmodel.car_area;
                    if (cmodel.car_area != "all" && cmodel.car_area != null)
                    {
                        var reg = regbll.GetModelList(" reg_ID in(" + cmodel.car_area + ")");
                        foreach (var item in reg)
                        {
                            regname += item.reg_Name + ",";
                        }
                        if (regname.Length > 0)
                            regname = regname.Substring(0, regname.Length - 1);
                    }
                    else
                    {
                        regname = "全国";
                    }
                    ViewData["regName"] = regname;
                }
                ViewData["shipType"] = new SelectList(shipType, "Value", "Text", cmodel.St_ID);
                return View(cmodel);
            }
            else//添加
            {
                if (!string.IsNullOrEmpty(RequestBase.GetString("list")))
                {
                    string regID = RequestBase.GetString("list");
                        string regname = "";
                    if (regID.Length > 0)
                    {
                        regID = regID.Substring(0, regID.Length - 1);
                        var reg = regbll.GetModelList(" reg_ID in(" + regID + ")");
                        foreach (var item in reg)
                        {
                            regname += item.reg_Name+",";
                        }
                        if(regname.Length>0)
                        regname = regname.Substring(0, regname.Length - 1);
                    }
                    ViewData["reglist"] = RequestBase.GetString("list");
                    ViewData["regName"] = regname;
                }
                else
                {
                    ViewData["reglist"] = "";
                    ViewData["regName"] = "";
                }
                return View();
            }
        }

        // 修改/添加
        public ActionResult CarriageEdit(Model.CarriageBase Carriage)
        {
            int result = 0;
            bool resultup = false;
            string Message = "";
            int stid = 0;
            if (Request.Form["texOtype"] == "add" )
            {
                var hfpid = Request.Form["hfPId"];
                var pid = hfpid.Split('|')[0];
                if (Request.Form["shipType"] != "chose")
                {
                    //Carriage.St_ID 
                    Carriage.St_ID = Request.Form["shipType"];
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "请选择配送方式！！", "", "", ""));
                }
                if (Request.Form["measurementUnits"] != "0")
                {
                    Model.CarriageTempleteBase pctmodel = pctbll.GetModel(int.Parse(pid));
                    int? units = pctmodel.ct_ValuationType;
                    Carriage.car_measurementUnits = int.Parse(Request.Form["measurementUnits"]);
                    if (Request.Form["measurementUnits"] != units.ToString())
                    {
                        return Content(DWZUtil.GetResultJson("300", "请选择与模板相符的计量单位！！", "", "", ""));
                    }
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "请选择计量单位！！", "", "", ""));
                }
                if (Request.Form["moren"] == "on")
                {
                    Carriage.car_Ismoren = true;
                }
                else
                {
                    Carriage.car_Ismoren = false;
                }
                Carriage.ct_ID = int.Parse(pid);
                if (Request.Form["regionList"] == "all")
                {
                    Carriage.car_area = Request.Form["regionList"];
                }
                else if (Request.Form["regionList"] == "")
                {
                    return Content(DWZUtil.GetResultJson("300", "请选择配送地区！！", "", "", ""));
                }
                else if (Request.Form["regionList"] == "")
                { 
                    Carriage.car_area = (Request.Form["regionList"]).Substring(0, Request.Form["regionList"].Length-1);
                }
                Carriage.car_CreateOn = DateTime.Now;
                Carriage.car_CreateBy = EmployeeBase.e_ID;
                Carriage.car_ModifyBy = EmployeeBase.e_ID;
                Carriage.car_ModifyOn = DateTime.Now;
                result = pcbll.Add(Carriage);

            }
            else
            {
                Model.CarriageBase newpt = pcbll.GetModel(Carriage.car_ID);

                if (Request.Form["shipType"] != "chose")
                {
                    //Carriage.St_ID 
                    newpt.St_ID =Request.Form["shipType"];
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "请选择配送方式！！", "", "", ""));
                }
                newpt.car_ModifyBy = EmployeeBase.e_ID;
                newpt.car_ModifyOn = DateTime.Now;
                newpt.car_shouCarriage = Carriage.car_shouCarriage;
                newpt.car_shouCount = Carriage.car_shouCount;
                newpt.car_xuCarriage = Carriage.car_xuCarriage;
                newpt.car_xuCount = Carriage.car_xuCount;
                if (int.Parse(Request.Form["measurementUnits"]) == 0)
                {
                    return Content(DWZUtil.GetResultJson("300", "请选择计量单位！！", "", "", ""));
                }
                else
                {
                    newpt.car_measurementUnits = int.Parse(Request.Form["measurementUnits"]);
                }

                if (Request.Form["moren"] == "on")
                {
                    newpt.car_Ismoren = true;
                    newpt.car_area = "all";
                }
                else
                {
                    newpt.car_Ismoren = false;
                    if (Request.Form["regionList"] != "")
                    {
                        newpt.car_area = Request.Form["regionList"];
                    }
                    else  
                    {
                        return Content(DWZUtil.GetResultJson("300", "请选择配送地区！！", "", "", ""));
                    }
                }
                resultup = pcbll.Update(newpt);
            }
            if (result > 0 || resultup)
            {
                return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功！！", "", "forward", "closeCurrent", "cBox", ""));
            }
            else
            {
                return Content(DWZUtil.GetResultJson("300", "保存失败！！", "", "", ""));
            }
        }

        //删除
        public ActionResult CarriageDelete()
        {
            bool result = false;
            string Message = "";
            try
            {
                string id = RequestBase.GetString("dli_id");
                string pid = id.Split('|')[1];
                int ptid = int.Parse(pid);//运费模板ID
                
                var list = new BLL.ProductBase().GetModelList(" p_IsDel=0 and ct_ID="+ptid);
                if (list.Count > 0)
                {
                    return Content(DWZUtil.GetResultJson("300", "该运费模板已被引用，无法删除", "", "", ""));
                }
                else
                {
                    Model.CarriageBase NewP = pcbll.GetModel(ptid);
                    NewP.car_IsDel = true;
                    result = pcbll.Update(NewP);
                }
                if (result)
                {
                    Message = "删除成功！";
                    return Content(DWZUtil.GetAjaxTodoJson("200", Message, "", "", "", "cBox", ""));
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
        public ActionResult CarriageEnable(string otype, string dli_id)
        {

            bool result = false;
            try
            {
                string dliid = RequestBase.GetString("dli_id");
                string pid = dliid.Split('|')[1];
                Model.CarriageBase NewP = pcbll.GetModel(int.Parse(pid));
                if (otype == "disable")
                {
                    NewP.car_StatusCode = 1;
                }
                else
                {
                    NewP.car_StatusCode = 0;
                }
                result = pcbll.Update(NewP);
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "forward", "", "cBox", ""));
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

        //选择地区
        public ActionResult RegionBase()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            var RegList = regbll.GetModelList("");
            var cartype = RequestBase.GetString("cartype");
            var pid = RequestBase.GetString("pid");
            ViewData["texOtype"] = cartype;
            ViewData["ctid"] = pid;
            return View(RegList.ToList());
        }

        #endregion
    }
}
