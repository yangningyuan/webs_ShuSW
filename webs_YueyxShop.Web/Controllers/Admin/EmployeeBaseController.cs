using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using PagedList;
using System.Data;
using System.Text;
using webs_YueyxShop.Model;
using System.Transactions;
using webs_YueyxShop.BLL;

namespace webs_YueyxShop.Web
{
    public class EmployeeBaseController : BaseController
    {
        private readonly BLL.EmployeeBase _employeeBase = new BLL.EmployeeBase();
        private readonly BLL.EmpRolesDetails _rolesDetails = new BLL.EmpRolesDetails();
        private readonly BLL.RolesInfo _rolesInfo = new BLL.RolesInfo();
        private readonly BLL.DepartmentBase _departmentBase = new BLL.DepartmentBase();
        private readonly RoleManager _roleManager = new RoleManager();

        #region 用户列表页

        public ActionResult EmployeeMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            this.ViewData["departId"] = RequestBase.GetString("d_id"); //部门编辑页面的员工列表
            if (!string.IsNullOrEmpty(RequestBase.GetString("d_id")))
            {
                this.ViewData["listbox"] = "bmEmployeeBox"; //部门编辑页面的员工列表
            }
            else
            {
                this.ViewData["listbox"] = "EmployeeBox";
            }
            return View();
        }


        /// <summary>
        /// 列表页
        /// </summary>
        [HttpPost]
        public ActionResult EmployeeList()
        {
            this.ViewData["listbox"] = RequestBase.GetFormString("listbox");
            const int pageSize = 25;
            StringBuilder strSql = new StringBuilder();
            string aa = RequestBase.GetString("orgLookup.id").Trim();
            string ab = RequestBase.GetString("orgLookupid").Trim();
            strSql.AppendFormat(" and e_ID in ({0})", GetSubEmployee(EmployeeBase.e_ID));
            if (RequestBase.GetString("orgLookup.id").Trim() != "")
            {
                strSql.AppendFormat(" and  d_ID='{0}' ", RequestBase.GetString("orgLookup.id").Trim());
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("txtEMingc")))
            {
                strSql.AppendFormat(" and e_MingC like '" + RequestBase.GetString("txtEMingc").Trim() + "%'");
            }
            DBUtility.Pagination pagination = new DBUtility.Pagination();
            try
            {
                if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
                    pagination.Sequence = Convert.ToInt32(RequestBase.GetString("pageNum"));
                else
                    pagination.Sequence = 1;
                pagination.ItemUnit = "条记录";
                pagination.SortSentence = "";
                pagination.Primarykey = "e_ID";
                pagination.SearchField = "*";
                pagination.TableName = "vw_EmployeeBase";
                pagination.PageSize = pageSize;
                pagination.UrlStr = "";
                pagination.ImagesPath = "../_imgs/grid/";
                pagination.SearchSentence = strSql.ToString();
                this.ViewData["PageList"] = pagination.GetDataTable();
                this.ViewData["TotalCount"] = pagination.RecordCount.ToString();
                this.ViewData["NumberPage"] = pageSize.ToString();
                this.ViewData["PagenumShown"] = pagination.PageCount.ToString();
                this.ViewData["CurrentPage"] = pagination.Sequence.ToString();
                this.ViewData["OrderFile"] = RequestBase.GetString("orderField");
                this.ViewData["OrderDirection"] = RequestBase.GetString("orderDirection");
                return View();
            }
            catch (Exception err)
            {
                return View(err.Message);
            }
        }

        /// <summary>
        /// 获取用户下级用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string GetSubEmployee(Guid id)
        {
            string result = "'" + id.ToString() + "'";

            var list = _employeeBase.GetModelList(string.Format(" e_CreatedBy = '{0}' and e_DeleteStateCode = 0", id));
            foreach (var model in list)
            {
                result += "," + GetSubEmployee(model.e_ID);
            }

            return result;
        }


        #endregion

        #region 绑定用户属性

        public void BindTypeDLL()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() {Text = "--请选择--", Value = "", Selected = true});
            items.Add(new SelectListItem() {Text = "普通员工", Value = "0", Selected = false});
            items.Add(new SelectListItem() {Text = "代课教师", Value = "1", Selected = false});
            ViewData["LeiBtype"] = new SelectList(items, "Value", "Text");
        }

        /// <summary>
        /// 性别下拉框
        /// </summary>
        private SelectList LoadSexList(string selectVal)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() {Text = "男", Value = "0", Selected = false});
            items.Add(new SelectListItem() {Text = "女", Value = "1", Selected = false});
            return new SelectList(items, "Value", "Text", selectVal);
        }

        #endregion

        #region 用户信息编辑

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult EmployeeEdit()
        {
            BindTypeDLL();
            //ViewData["LeiB"] = new BindControl().BindSysCodeBase("0006", 2, false, false);
            ViewData["LeiB"] = new BindControl().BindSysCodeBaseForCheckBoxList("0006", 2, false);
            this.ViewData["hfOtype"] = RequestBase.GetString("otype");
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            if (RequestBase.GetString("type") == "details")
            {
                ViewData["EmployeeBaseEdit_Type"] = "false";
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("d_ID")))
            {
                this.ViewData["o_ID"] = RequestBase.GetString("d_ID");
                this.ViewData["departId"] = RequestBase.GetString("d_ID");
                this.ViewData["departname"] = _departmentBase.GetModel(new Guid(RequestBase.GetString("d_ID"))).d_MingCh;
            }
            switch (ViewData["hfOtype"].ToString())
            {
                case "modify":
                    ViewData["hfEid"] = RequestBase.GetString("e_ID");
                    EmployeeBaseObj = _employeeBase.GetModel(new Guid(RequestBase.GetString("e_ID")));
                    //ViewData["LeiBValue"] = EmployeeLeibBaseBLL.GetFunctionCodes(new Guid(RequestBase.GetString("e_ID")));
                    break;
                case "details":
                    ViewData["hfEid"] = RequestBase.GetString("e_ID");
                    EmployeeBaseObj = _employeeBase.GetModel(new Guid(RequestBase.GetString("e_ID")));
                    //ViewData["LeiBValue"] = EmployeeLeibBaseBLL.GetFunctionCodes(new Guid(RequestBase.GetString("e_ID")));
                    break;
                default:
                    EmployeeBaseObj = new webs_YueyxShop.Model.EmployeeBase(); //添加时，set值
                    break;
            }
            return View();
        }

        #endregion


        #region 用户信息保存

        public ActionResult Save()
        {
            string result = "";
            string message = "";
            //用户类别
            //string functions = RequestBase.GetFormString("cbLieB");
            //string[] funtionArray = null;
            //if (functions.Length > 0)
            //{
            //    if (functions.Contains(","))
            //    {
            //        funtionArray = functions.Split(',');
            //    }
            //    else
            //    {
            //        funtionArray = new string[] {functions};
            //    }
            //}
            //else
            //{
            //    funtionArray = new string[] {""};
            //}
            int ReturnValue = Request.Form["hfOtype"] == "add" ? 0 : 1;
            try
            {
                string o_ID = Request.Form["hf_did"];
                string YongHM = Request.Form["txtYongh"].ToString().Trim();
                if (Request.Form["hfOtype"] == "add")
                {
                    #region 验证 是否存在同名

                    //int value = db.Exists(Request.Form["txtYongh"].ToString().Trim());
                    //if (value == 0)
                    //{
                    //    return Content(DWZUtil.GetResultJson("300", "用户名已存在", "", "", ""));
                    //}

                    var empList =
                        _employeeBase.GetModelList(" e_YongHM = '" + Request.Form["txtYongh"].ToString().Trim() + "'");
                    if (empList != null && empList.Any())
                    {
                        return Content(DWZUtil.GetResultJson("300", "用户名已存在", "", "", ""));
                    }

                    #endregion

                    //添加到数据库
                    //result = EmployeeBaseBLL.Add(EmployeeBaseObj);
                    if (_employeeBase.Add(EmployeeBaseObj))
                    {
                        result = "succeeded" + "/" + EmployeeBaseObj.e_ID;
                    }
                }
                else if (Request.Form["hfOtype"] == "modify" || Request.Form["hfOtype"] == "details")
                {
                    Guid e_ID = new Guid(Request.Form["hfEid"].ToString());

                    #region 验证 是否存在同名

                    //int value = EmployeeBaseBLL.Exists(Request.Form["txtYongh"].ToString().Trim());
                    //if (Request.Form["txtYongh"].ToString().Trim() != EmployeeBaseObj.e_YongHM)
                    //{
                    //    if (value > 0)
                    //    {
                    //        return Content(DWZUtil.GetResultJson("300", "用户名已存在", "", "", ""));
                    //    }
                    //}

                    var empList =
                        _employeeBase.GetModelList(" e_ID != '" + e_ID + "' and e_YongHM = '" +
                                        Request.Form["txtYongh"].ToString().Trim() + "'");
                    if (empList != null && empList.Any())
                    {
                        return Content(DWZUtil.GetResultJson("300", "用户名已存在", "", "", ""));
                    }

                    #endregion

                    //更新到数据库
                    //result = EmployeeBaseBLL.Update(EmployeeBaseObj);
                    if (_employeeBase.Update(EmployeeBaseObj))
                    {
                        result = "succeeded";
                    }
                }
                if (result.Contains("succeeded"))
                {
                    string[] sArray = result.Split(new char[] {'/'});
                    string value = "";
                    if (Request.Form["hfOtype"] != "add")
                    {
                        //EmployeeLeibBaseBLL.Delete(EmployeeBaseObj.e_ID);
                        value = Request.Form["hfEid"].ToString();
                    }
                    else
                    {
                        value = sArray[1];
                    }
                    //用户类别
                    //foreach (var item in funtionArray)
                    //{
                    //    //EmployeeLeibBaseModel.e_ID = new Guid(value);
                    //    //EmployeeLeibBaseModel.el_Code = item;
                    //    //EmployeeLeibBaseModel.el_Name = new BindControl().GetNameByCode(item);
                    //    //EmployeeLeibBaseBLL.Add(EmployeeLeibBaseModel);
                    //}
                    if (!string.IsNullOrEmpty(o_ID)) //部门编辑页面 员工列表
                    {
                        return
                            Content(DWZUtil.GetAjaxTodoJsonCallBack("200", "操作成功！！", "", "", "reload()", "", "",
                                                                    "trueandcloseCurrent"));
                    }
                    else
                    {
                        return Content(DWZUtil.GetResultJson("200", "操作成功！！", "w_用户信息管理", "", "closeCurrent"));
                    }
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

        #region 员工实体信息

        private webs_YueyxShop.Model.EmployeeBase EmployeeBaseObj
        {
            get
            {
                webs_YueyxShop.Model.EmployeeBase model = new webs_YueyxShop.Model.EmployeeBase();
                if (Request.Form["hfOtype"] == "add")
                {
                    model.e_ID = Guid.NewGuid();
                    model.e_CreatedBy = EmployeeBase.e_ID;
                    model.e_CreatedOn = DateTime.Now;
                    model.e_DeleteStateCode = 0;
                    model.e_StateCode = 0;
                    model.e_LeiB = 0;
                    model.e_MiM = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("123456",
                                                                                                             "MD5");
                  //  model.e_GongH = GetEmpCode(); //员工工号（公司首字母+编号）
                    model.e_GongH = "";
                }
                else if (Request.Form["hfOtype"] == "modify" || Request.Form["hfOtype"] == "details")
                {
                    model.e_ID = new Guid(Request.Form["hfEid"].ToString());
                    model.e_CreatedBy = new Guid(Request.Form["hf_CreatedBy"].ToString());
                    model.e_CreatedOn = Convert.ToDateTime(Request.Form["hf_CreatedOn"].ToString());
                    model.e_DeleteStateCode = int.Parse(Request.Form["hf_DeleteStateCode"].ToString());
                    model.e_StateCode = int.Parse(Request.Form["hf_StateCode"].ToString());
                    model.e_MiM = Request.Form["hf_MiM"].ToString();
                   // model.e_GongH = Request.Form["txtGongh"].ToString();
                    model.e_GongH = "";
                    model.e_LeiB = 0;
                }
                model.e_MingC = Request.Form["txtEname"].ToString().Trim();
                model.d_ID = new Guid(RequestBase.GetString("orgLookup.id"));
                model.e_XingB = int.Parse(Request.Form["selectXingb"].ToString());
                if (!string.IsNullOrEmpty(Request.Form["txtDatebir"].ToString()))
                {
                    model.e_ShengR = Convert.ToDateTime(Request.Form["txtDatebir"].ToString());
                }
                else
                {
                    model.e_ShengR = Convert.ToDateTime("1900-01-01");
                }
                model.e_QQ = Request.Form["txtQQ"].ToString().Trim();
                model.e_EMail = Request.Form["txtEmail"].ToString().Trim();
                model.e_ShouJ = Request.Form["txtTel"].ToString().Trim();
                model.e_YongHM = Request.Form["txtYongh"].ToString().Trim();
                return model;
            }
            set
            {
                ViewData["txtEname"] = value.e_MingC;
                ViewData["txtGongh"] = value.e_GongH;
                if (ViewData["departId"] == null || ViewData["departId"].ToString() == "")
                {
                    ViewData["departId"] = value.d_ID;
                }
                ViewData["departname"] = GetE_NameCh(value.d_ID);
                //if (value.departmentBase != null)
                //{

                //}
                ViewData["selectXingb"] = LoadSexList(value.e_XingB.ToString());
                ViewData["PositionLevel"] = null;
                if (value.e_ShengR != null)
                {
                    if (value.e_ShengR.ToString("yyyy-MM-dd") != "1900-01-01" &&
                        value.e_ShengR.ToString("yyyy-MM-dd") != "0001-01-01")
                        ViewData["txtDatebir"] = value.e_ShengR.ToString("yyyy-MM-dd");
                }
                else
                {
                    ViewData["txtDatebir"] = "";
                }
                ViewData["txtQQ"] = value.e_QQ;
                ViewData["txtEmail"] = value.e_EMail;
                ViewData["txtTel"] = value.e_ShouJ;
                ViewData["txtYongh"] = value.e_YongHM;
                ViewData["hf_MiM"] = value.e_MiM;
                ViewData["hf_CreatedBy"] = value.e_CreatedBy;
                ViewData["hf_CreatedOn"] = value.e_CreatedOn;
                ViewData["hf_DeleteStateCode"] = value.e_DeleteStateCode;
                ViewData["hf_StateCode"] = value.e_StateCode;
            }
        }

        #endregion

        #region 获取教师列表

        public ActionResult TeacherMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "002006001"); //是否拥有管理的权限
            return View();
        }

        public ActionResult TeacherList()
        {
            int pageSize = 30;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" and e_LeiB = 1 ");
            if (RequestBase.GetString("orgLookup.id").Trim() != "")
            {
                strSql.AppendFormat(" and  d_ID='{0}' ", RequestBase.GetString("orgLookup.id").Trim());
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("txtEMingc")))
            {
                strSql.AppendFormat(" and e_MingC like '" + RequestBase.GetString("txtEMingc").Trim() + "%'");
            }
            DBUtility.Pagination pagination = new DBUtility.Pagination();
            try
            {
                if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
                    pagination.Sequence = Convert.ToInt32(RequestBase.GetString("pageNum"));
                else
                    pagination.Sequence = 1;
                pagination.ItemUnit = "条记录";
                pagination.SortSentence = "";
                pagination.Primarykey = "e_ID";
                pagination.SearchField = "*";
                pagination.TableName = "vw_EmployeeBase";
                pagination.PageSize = pageSize;
                pagination.UrlStr = "";
                pagination.ImagesPath = "../_imgs/grid/";
                pagination.SearchSentence = strSql.ToString();
                this.ViewData["PageList"] = pagination.GetDataTable();
                this.ViewData["TotalCount"] = pagination.RecordCount.ToString();
                this.ViewData["NumberPage"] = pageSize.ToString();
                this.ViewData["PagenumShown"] = pagination.PageCount.ToString();
                this.ViewData["CurrentPage"] = pagination.Sequence.ToString();
                this.ViewData["OrderFile"] = RequestBase.GetString("orderField");
                this.ViewData["OrderDirection"] = RequestBase.GetString("orderDirection");
                return View();
            }
            catch (Exception err)
            {
                return View(err.Message);
            }
        }

        #endregion

        #region 教师信息编辑

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult TeacherEdit()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "002006001"); //是否拥有管理的权限
            BindTypeDLL();
            this.ViewData["hfOtype"] = RequestBase.GetString("otype");
            this.ViewData["departId"] = RequestBase.GetString("o_ID");
            this.ViewData["o_ID"] = RequestBase.GetString("o_ID"); //部门编辑页面员工列表
            ViewData["EmployeeBaseEdit_Type"] = "true";
                //new CRM.Public.RoleManager().IsHasFunRole(EmployeeInfo.e_ID, "006008001");//管理权限
            if (RequestBase.GetString("type") == "details")
            {
                ViewData["EmployeeBaseEdit_Type"] = "false";
            }
            switch (ViewData["hfOtype"].ToString())
            {
                case "modify":
                    ViewData["hfEid"] = RequestBase.GetString("e_ID");
                    EmployeeBaseObj = _employeeBase.GetModel(new Guid(RequestBase.GetString("e_ID")));
                    break;
                case "details":
                    ViewData["hfEid"] = RequestBase.GetString("e_ID");
                    EmployeeBaseObj = _employeeBase.GetModel(new Guid(RequestBase.GetString("e_ID")));
                    break;
                default:
                    EmployeeBaseObj = new webs_YueyxShop.Model.EmployeeBase(); //添加时，set值
                    break;
            }
            return View();
        }

        #endregion

        #region 教师信息保存

        public ActionResult TeacherSave()
        {
            bool result = false;
            string message = "";
            int ReturnValue = Request.Form["hfOtype"] == "add" ? 0 : 1;
            try
            {
                string o_ID = Request.Form["hfEid"];
                //string YongHM = Request.Form["txtYongh"].ToString().Trim();
                if (Request.Form["hfOtype"] == "add")
                {
                    //db.InsertEmployeeBase(TeacherBaseObj);
                    //result = db.Save();
                    result = _employeeBase.Add(TeacherBaseObj);
                }
                else if (Request.Form["hfOtype"] == "modify" || Request.Form["hfOtype"] == "details")
                {
                    Guid e_ID = new Guid(Request.Form["hfEid"].ToString());
                    //db.UpdateEmployeeBasee(TeacherBaseObj);
                    //result = db.Save();
                    result = _employeeBase.Update(TeacherBaseObj);
                }
                if (result)
                {
                    if (!string.IsNullOrEmpty(o_ID)) //部门编辑页面 员工列表
                    {
                        return
                            Content(DWZUtil.GetAjaxTodoJsonCallBack("200", "操作成功！！", "", "", "reload()", "", "",
                                                                    "trueandcloseCurrent"));
                    }
                    else
                    {
                        return Content(DWZUtil.GetResultJson("200", "操作成功！！", "w_教师管理", "", "closeCurrent"));
                    }
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

        #region 教师实体信息

        private webs_YueyxShop.Model.EmployeeBase TeacherBaseObj
        {
            get
            {
                webs_YueyxShop.Model.EmployeeBase model = new webs_YueyxShop.Model.EmployeeBase();
                if (Request.Form["hfOtype"] == "add")
                {
                    model.e_ID = Guid.NewGuid();
                    model.e_CreatedBy = EmployeeBase.e_ID;
                    model.e_CreatedOn = DateTime.Now;
                    model.e_DeleteStateCode = 0;
                    model.e_StateCode = 0;
                    model.e_LeiB = 1;
                    model.e_MiM = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("123456",
                                                                                                             "MD5");
                    model.e_GongH = GetEmpCode(); //员工工号（公司首字母+编号）
                }
                else if (Request.Form["hfOtype"] == "modify" || Request.Form["hfOtype"] == "details")
                {
                    model.e_ID = new Guid(Request.Form["hfEid"].ToString());
                    model.e_CreatedBy = new Guid(Request.Form["hf_CreatedBy"].ToString());
                    model.e_CreatedOn = Convert.ToDateTime(Request.Form["hf_CreatedOn"].ToString());
                    model.e_DeleteStateCode = int.Parse(Request.Form["hf_DeleteStateCode"].ToString());
                    model.e_StateCode = int.Parse(Request.Form["hf_StateCode"].ToString());
                    model.e_MiM = Request.Form["hf_MiM"].ToString();
                    model.e_GongH = Request.Form["txtGongh"].ToString();
                    model.e_LeiB = 1;
                }
                model.e_MingC = Request.Form["txtEname"].ToString().Trim();
                model.d_ID = new Guid(RequestBase.GetString("orgLookup.id"));
                model.e_XingB = int.Parse(Request.Form["selectXingb"].ToString());
                if (!string.IsNullOrEmpty(Request.Form["txtDatebir"].ToString()))
                {
                    model.e_ShengR = Convert.ToDateTime(Request.Form["txtDatebir"].ToString());
                }
                else
                {
                    model.e_ShengR = Convert.ToDateTime("1900-01-01");
                }
                model.e_QQ = Request.Form["txtQQ"].ToString().Trim();
                model.e_EMail = Request.Form["txtEmail"].ToString().Trim();
                model.e_ShouJ = Request.Form["txtTel"].ToString().Trim();
                model.e_YongHM = Request.Form["txtEname"].ToString().Trim();
                return model;
            }
            set
            {
                ViewData["hf_IsManage"] = true;
                    // new CRM.Public.RoleManager().IsHasFunRole(EmployeeInfo.e_ID, "006006003");//管理权限
                ViewData["txtEname"] = value.e_MingC;
                ViewData["txtGongh"] = value.e_GongH;
                if (string.IsNullOrEmpty(ViewData["departId"].ToString()))
                {
                    ViewData["departId"] = value.d_ID;
                }
                if (value.d_ID != Guid.Empty)
                {
                    var dep = _departmentBase.GetModel(value.d_ID);
                    if(dep != null)
                        ViewData["departname"] = dep.d_MingCh;
                }
                ViewData["selectXingb"] = LoadSexList(value.e_XingB.ToString());
                ViewData["PositionLevel"] = null; // LoadRoleLevel(value.rl_ID.ToString());
                if (value.e_ShengR != null)
                {
                    if (value.e_ShengR.ToString("yyyy-MM-dd") != "1900-01-01" &&
                        value.e_ShengR.ToString("yyyy-MM-dd") != "0001-01-01")
                        ViewData["txtDatebir"] = value.e_ShengR.ToString("yyyy-MM-dd");
                }
                else
                {
                    ViewData["txtDatebir"] = "";
                }
                ViewData["txtQQ"] = value.e_QQ;
                ViewData["txtEmail"] = value.e_EMail;
                ViewData["txtTel"] = value.e_ShouJ;
                //ViewData["txtYongh"] = value.e_YongHM;
                ViewData["hf_MiM"] = value.e_MiM;
                ViewData["hf_CreatedBy"] = value.e_CreatedBy;
                ViewData["hf_CreatedOn"] = value.e_CreatedOn;
                ViewData["hf_DeleteStateCode"] = value.e_DeleteStateCode;
                ViewData["hf_StateCode"] = value.e_StateCode;
                //ViewData["ddlLeib"] = value.e_LeiB;
            }
        }

        #endregion

        #region 启，禁用,重置密码

        private int UpDateStateCode(string strWhere, int stateCode)
        {
            int i = 0;

            var empList = _employeeBase.GetModelList(strWhere);
            if (empList != null)
            {
                foreach (var emp in empList)
                {
                    emp.e_StateCode = stateCode;
                    if (_employeeBase.Update(emp))
                        i++;
                }
            }

            return i;
        }

        private int UpDateMiM(string strWhere, string miM)
        {
            int i = 0;

            var empList = _employeeBase.GetModelList(strWhere);
            if (empList != null)
            {
                foreach (var emp in empList)
                {
                    emp.e_MiM = miM;
                    if (_employeeBase.Update(emp))
                        i++;
                }
            }

            return i;
        }

        public ActionResult Enable()
        {
            try
            {
                string type = RequestBase.GetString("type"); //部门编辑页面
                int i = 0;
                switch (RequestBase.GetString("otype"))
                {
                    case "enable":
                        //i =
                        //    crmContext.Database.ExecuteSqlCommand("update EmployeeBase set e_StateCode=0 where e_ID='" +
                        //                                          RequestBase.GetString("e_ID") + "'");
                        i = UpDateStateCode("e_ID='" + RequestBase.GetString("e_ID") + "'", 0);
                        break;
                    case "disable":
                        //i =
                        //    crmContext.Database.ExecuteSqlCommand("update EmployeeBase set e_StateCode=1 where e_ID='" +
                        //                                          RequestBase.GetString("e_ID") + "'");
                        i = UpDateStateCode("e_ID='" + RequestBase.GetString("e_ID") + "'", 1);
                        break;
                    case "Reset":
                        string remim =
                            System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5");
                        //i =
                        //    crmContext.Database.ExecuteSqlCommand("update EmployeeBase set e_MiM='" + remim +
                        //                                          "' where e_ID='" + RequestBase.GetString("e_ID") + "'");
                        i = UpDateMiM("e_ID='" + RequestBase.GetString("e_ID") + "'", remim);
                        break;
                    default:
                        i = 0;
                        break;
                }
                if (i > 0)
                {
                    string box = RequestBase.GetString("list") == "teacher" ? "TeacherBox" : "EmployeeBox";
                    if (type == "bm")
                    {
                        return
                            Content(DWZUtil.GetAjaxTodoJsonCallBack("200", "操作成功！！", "", "", "reload()", "", "", "true"));
                    }
                    else
                    {
                        return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "", "", box, ""));
                    }
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

        #region 离职

        public ActionResult EmployeeLeave()
        {
            webs_YueyxShop.Model.EmployeeBase model = new webs_YueyxShop.Model.EmployeeBase();
            this.ViewData["hfOtype"] = RequestBase.GetString("otype");

            switch (ViewData["hfOtype"].ToString())
            {
                case "ELeave":
                    ViewData["hfEid"] = RequestBase.GetString("e_ID");

                    model = _employeeBase.GetModel(new Guid(RequestBase.GetString("e_ID")));
                    ViewData["txtELname"] = model.e_MingC;
                    ViewData["txtLGongh"] = model.e_GongH;
                    break;
                default:
                    break;
            }
            return View();
        }

        private int UpDateLiZhRQ(string strWhere, string liZhRQ)
        {
            int i = 0;

            var empList = _employeeBase.GetModelList(strWhere);
            if (empList != null)
            {
                foreach (var emp in empList)
                {
                    emp.e_ShengR = Convert.ToDateTime(liZhRQ);
                    emp.e_StateCode = 2;
                    if (_employeeBase.Update(emp))
                        i++;
                }
            }

            return i;
        }

        /// <summary>
        /// 离职信息保存
        /// </summary>
        public ActionResult EmployLeaveSave()
        {
            try
            {
                int cuscount = Convert.ToInt32(Request.Form["hfCustCount"].ToString());

                int i = 0;
                Guid eid = new Guid(Request.Form["hfEid"].ToString());
                string LiZhRQ = Request.Form["txtLDateend"].ToString();
                //i =
                //    crmContext.Database.ExecuteSqlCommand("update EmployeeBase set  e_StateCode=2,e_LiZhRQ='" + LiZhRQ +
                //                                          "'  where e_ID='" + eid + "'");
                i = UpDateLiZhRQ("e_ID='" + eid + "'", LiZhRQ);

                if (i > 0)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功！", "", "", "closeCurrent", "EmployeeBox", ""));
                }
                return Content(DWZUtil.GetResultJson("300", "程序异常，保存失败", "", "", ""));
            }
            catch (Exception ex)
            {
                return RedirectToAction("EmployeeMsg");
            }
        }

        #endregion

        #region 设置角色权限

        /// <summary>
        /// 角色菜单
        /// </summary>
        public ActionResult EmployeeRole()
        {
            ViewData["hf_IsManage"] = true;
                //new CRM.Public.RoleManager().IsHasFunRole(EmployeeInfo.e_ID, "006006003");//管理权限
            //var RoleList = from roles in roleDB.GetRolesInfos()
            //               where roles.r_DeleteStateCode == 0
            //               orderby roles.r_PaiX
            //               select roles;

            var RoleList = _rolesInfo.GetModelList("r_DeleteStateCode = 0 and r_StateCode=0 order by r_PaiX");

            var RoleIds = _rolesDetails.GetModelList("e_id = '" + RequestBase.GetString("e_ID") + "'");

            string RoleMenuIds = "";
            foreach (webs_YueyxShop.Model.EmpRolesDetails j in RoleIds)
            {
                RoleMenuIds += j.r_ID + ",";
            }
            @ViewData["hfItems"] = RoleMenuIds;
            @ViewData["hfEId"] = RequestBase.GetString("e_ID");
            return View(RoleList.ToList());
        }

        /// <summary>
        /// 员工角色保存
        /// </summary>
        [HttpPost]
        public ActionResult EmployeeRoleSave(string hfItems, string hfEId)
        {
            bool result = _rolesDetails.UpdateRolesDetails(hfItems, hfEId);

            if (result)
            {
                return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "", "closeCurrent", "EmployeeBox", ""));
            }
            return Content(DWZUtil.GetResultJson("300", "操作失败！！", "", "", ""));

        }

        #endregion

        #region 设置用户教师编码

        public string GetEmpCode()
        {
            string EmpCode = "";
            //var EmpCount = (from s in db.GetEmployeeBases()
            //                where s.e_DeleteStateCode == 0
            //                select s.e_ID).Count();
            var EmpCount = _employeeBase.GetRecordCount("e_DeleteStateCode = 0");
            //公司首字母
            string Company = "zy";
            if (EmpCount == 0)
            {
                EmpCode = Company + "0001";
            }
            else
            {
                int Number = EmpCount + 1;
                EmpCode = Company + Number.ToString("0000");
            }
            return EmpCode;
        }

        #endregion

        #region 修改密码

        public ActionResult PasswordChange()
        {
            return View();
        }

        public ActionResult PasswordEdit()
        {
            string oldPwd =
                System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(
                    RequestBase.GetFormString("oldPassword"), "MD5");
            //var Employees = from emp in db.GetEmployeeBases()
            //                where emp.e_YongHM == EmployeeInfo.e_YongHM && emp.e_MiM == oldPwd
            //                select emp;
            var Employees = _employeeBase.GetModelList("e_YongHM ='" + EmployeeBase.e_YongHM + "' and e_MiM = '" + oldPwd + "'");
            if (Employees.Any())
            {
                string Password =
                    System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(
                        RequestBase.GetFormString("newPassword"), "MD5");
                //int i =
                //    crmContext.Database.ExecuteSqlCommand("update EmployeeBase set e_MiM='" + Password +
                //                                          "' where e_ID='" + EmployeeInfo.e_ID + "'");
                int i = UpDateMiM("e_ID='" + EmployeeBase.e_ID + "'", Password);
                if (i > 0)
                {
                    return Content(DWZUtil.GetResultJson("200", "操作成功！！", "", "", "closeCurrent"));
                }
                else
                {
                    DWZUtil.ReturnAjaxResult(DWZUtil.GetResultJson("300", "操作失败！！", "", "", ""));
                }
            }
            else
            {
                DWZUtil.ReturnAjaxResult(DWZUtil.GetResultJson("300", "旧密码输入不正确，请重试！！！", "", "", ""));
            }
            return View();
        }

        #endregion


        #region

        public ActionResult gotowx()
        {
            return View();
        }
        #endregion
        //#region 加载责任人列表
        //public ActionResult SelectEmployee()
        //{
        //    ViewData["RoleLevelId"] = RequestBase.GetQueryString("roleId");
        //    List<SelectListItem> ListItems = new List<SelectListItem>();

        //    IEnumerable<DepartmentBase> items = from d in departDB.GetDepartmentBases()
        //                                        where d.d_DeleteStateCode == 0
        //                                        && d.d_CengJ == 1
        //                                        && d.d_ParentId == new Guid("00000000-0000-0000-0000-000000000000")
        //                                        select d;
        //    if (items.Count() > 0)
        //    {
        //        ListItems.Add(new SelectListItem() { Text = "--请选择--", Value = "", Selected = true });
        //        foreach (DepartmentBase item in items)
        //        {
        //            string type = "├";
        //            ListItems.Add(new SelectListItem() { Text = type + item.d_MingCh, Value = item.d_ID.ToString() });
        //            InitProductType(ListItems, item.d_ID);
        //        }
        //    }

        //    ViewData["Department"] = ListItems;
        //    return View();
        //}
        ///// <summary>
        ///// 添加人：程晓龙
        ///// 功能：初始化部门
        ///// </summary>
        ///// <param name="SelectItem"></param>
        ///// <param name="sc_ID"></param>
        //public void InitProductType(List<SelectListItem> SelectItem, Guid sc_ID)
        //{
        //    IEnumerable<DepartmentBase> items = from d in departDB.GetDepartmentBases()
        //                                        where d.d_DeleteStateCode == 0
        //                                        && d.d_ParentId == sc_ID
        //                                        select d;
        //    if (items.Count() > 0)
        //    {

        //        foreach (DepartmentBase item in items)
        //        {
        //            string type = "├";
        //            for (int i = 0; i < item.d_CengJ - 1; i++)
        //            {
        //                type += "-";
        //            }
        //            SelectItem.Add(new SelectListItem() { Text = type + item.d_MingCh, Value = item.d_ID.ToString() });
        //            InitProductType(SelectItem, item.d_ID);
        //        }
        //    }
        //}
        ////根据职位等级ID查询关联该职位等级的人员列表
        //[HttpPost]
        //public ActionResult SelectEmployeeList(string employeeName, string RoleLevelId)
        //{
        //    string DepartmentName = RequestBase.GetFormString("Department");
        //    string GongHao = RequestBase.GetFormString("GongHao");

        //    int pageSize = 15;
        //    //当前页
        //    int pageNumber = 1;
        //    if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
        //    {
        //        pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
        //    }
        //    var list = from employee in db.GetEmployeeBases()
        //               where employee.e_DeleteStateCode.Equals(0) &&
        //               employee.e_StateCode.Equals(0) &&  //加载启用的人员信息
        //               employee.e_leiB.Equals(0)
        //               select employee;

        //    if (employeeName.Trim() != "")
        //    {
        //        list = list.Where(employee => employee.e_MingC.Contains(employeeName.Trim()));
        //    }
        //    //if (DepartmentName.Trim() != "")
        //    //{
        //    //    list = list.Where(employee => employee.o_ID == (new Guid(DepartmentName)));
        //    //}
        //    if (GongHao.Trim() != "")
        //    {
        //        list = list.Where(employee => employee.e_GongH.Contains(GongHao.Trim()));
        //    }


        //    list.OrderBy(employee => employee.e_GongH);
        //    //查询总条数
        //    int total = list.Count();

        //    this.ViewData["TotalCount"] = total.ToString();
        //    this.ViewData["NumberPage"] = pageSize.ToString();
        //    this.ViewData["PagenumShown"] = "10";
        //    this.ViewData["CurrentPage"] = pageNumber.ToString();
        //    return View(list.ToPagedList(pageNumber, pageSize));
        //}
        //#endregion

        #region 资源释放

        /// <summary>
        /// 资源释放
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            //emproleDB.Dispose();
            //roleDB.Dispose();
            //departDB.Dispose();
            //crmContext.Dispose();
            base.Dispose(disposing);
        }

        #endregion

        #region 获取部门名称

        /// <summary>
        /// 根据部门ID获取部门名称
        /// </summary>
        /// <param name="e_ID"></param>
        /// <returns></returns>
        public string GetE_NameCh(Guid e_ID)
        {
            string value = "";
            dataWork dw = new dataWork();
            string sql = "select top 1 d_MingCh from DepartmentBase where d_ID='" + e_ID + "' and d_DeleteStateCode=0 ";
            DataTable dt = dw.GetDS(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                value = dt.Rows[0]["d_MingCh"].ToString();
            }
            return value;
        }

        #endregion

        #region 选择用户列表

        public ActionResult SelectEmployee()
        {
            if (!string.IsNullOrEmpty(RequestBase.GetString("d_ID")))
            {
                ViewData["d_ID"] = RequestBase.GetString("d_ID");
                ViewData["d_MingCh"] = _departmentBase.GetModel(new Guid(RequestBase.GetString("d_ID"))).d_MingCh;
            }
            return View();
        }

        public ActionResult SelectEmployeeList()
        {
            int pageSize = 10;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" and el_Code= '00060001' and e_StateCode=0 and e_DeleteStateCode=0");
            if (RequestBase.GetString("d_ID").Trim() != "")
            {
                strSql.AppendFormat(" and  d_ID='{0}'", RequestBase.GetString("d_ID").Trim());
            }
            if (RequestBase.GetString("empName").Trim() != "")
            {
                strSql.AppendFormat(" and  e_MingC like '{0}%' ", RequestBase.GetString("empName").Trim());
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("depName")))
            {
                strSql.AppendFormat(" and d_MingCh like '{0}%'", RequestBase.GetString("depName").Trim());
            }
            DBUtility.Pagination pagination = new DBUtility.Pagination();
            try
            {
                if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
                    pagination.Sequence = Convert.ToInt32(RequestBase.GetString("pageNum"));
                else
                    pagination.Sequence = 1;
                pagination.ItemUnit = "条记录";
                pagination.SortSentence = "";
                pagination.Primarykey = "el_ID";
                pagination.SearchField = "*";
                pagination.TableName = "Vw_SelectEmployee";
                pagination.PageSize = pageSize;
                pagination.UrlStr = "";
                pagination.ImagesPath = "../_imgs/grid/";
                pagination.SearchSentence = strSql.ToString();
                this.ViewData["PageList"] = pagination.GetDataTable();
                this.ViewData["TotalCount"] = pagination.RecordCount.ToString();
                this.ViewData["NumberPage"] = pageSize.ToString();
                this.ViewData["PagenumShown"] = pagination.PageCount.ToString();
                this.ViewData["CurrentPage"] = pagination.Sequence.ToString();
                this.ViewData["OrderFile"] = RequestBase.GetString("orderField");
                this.ViewData["OrderDirection"] = RequestBase.GetString("orderDirection");
                return View();
            }
            catch (Exception err)
            {
                return View(err.Message);
            }
        }

        #endregion

        #region 选择教师列表

        public ActionResult SelectTeacherMsg()
        {
            if (!string.IsNullOrEmpty(RequestBase.GetString("d_ID")))
            {
                ViewData["d_ID"] = RequestBase.GetString("d_ID");
                ViewData["d_MingCh"] = _departmentBase.GetModel(new Guid(RequestBase.GetString("d_ID"))).d_MingCh;
            }
            return View();
        }

        public ActionResult SelectTeacherList()
        {
            int pageSize = 10;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" and el_Code= '00060002' and e_StateCode=0 and e_DeleteStateCode=0");
            if (RequestBase.GetString("d_ID").Trim() != "")
            {
                strSql.AppendFormat(" and  d_ID='{0}'", RequestBase.GetString("d_ID").Trim());
            }
            if (RequestBase.GetString("empName").Trim() != "")
            {
                strSql.AppendFormat(" and  e_MingC like '{0}%' ", RequestBase.GetString("empName").Trim());
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("depName")))
            {
                strSql.AppendFormat(" and d_MingCh like '{0}%'", RequestBase.GetString("depName").Trim());
            }
            DBUtility.Pagination pagination = new DBUtility.Pagination();
            try
            {
                if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
                    pagination.Sequence = Convert.ToInt32(RequestBase.GetString("pageNum"));
                else
                    pagination.Sequence = 1;
                pagination.ItemUnit = "条记录";
                pagination.SortSentence = "";
                pagination.Primarykey = "el_ID";
                pagination.SearchField = "*";
                pagination.TableName = "Vw_SelectEmployee";
                pagination.PageSize = pageSize;
                pagination.UrlStr = "";
                pagination.ImagesPath = "../_imgs/grid/";
                pagination.SearchSentence = strSql.ToString();
                this.ViewData["PageList"] = pagination.GetDataTable();
                this.ViewData["TotalCount"] = pagination.RecordCount.ToString();
                this.ViewData["NumberPage"] = pageSize.ToString();
                this.ViewData["PagenumShown"] = pagination.PageCount.ToString();
                this.ViewData["CurrentPage"] = pagination.Sequence.ToString();
                this.ViewData["OrderFile"] = RequestBase.GetString("orderField");
                this.ViewData["OrderDirection"] = RequestBase.GetString("orderDirection");
                return View();
            }
            catch (Exception err)
            {
                return View(err.Message);
            }
        }

        #endregion
    }
}
