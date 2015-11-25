using System;
using System.Linq;
using System.Web.Mvc;
using Common;
using PagedList;

namespace webs_YueyxShop.Web
{
    public class FunctionBaseController : BaseController
    {
        private readonly BLL.FunctionBase _db = new BLL.FunctionBase();
        private readonly RoleManager _roleManager = new RoleManager();

        public ActionResult FunctionMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001004001"); //是否拥有管理的权限
            return View();
        }

        #region 列表页

        /// <summary>
        /// 加载列表信息
        /// </summary>
        [HttpPost]
        public ActionResult FunctionList()
        {
            const int pageSize = 30;
            //当前页
            int pageNumber = 1;
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }

            var functionList = _db.GetModelList("f_DeleteStateCode = 0");

            # region 暂时不用

            ////"管理"权限
            //bool manageAuth = true; //new CRM.Public.RoleManager().IsHasFunRole(EmployeeInfo.e_ID, "006008001");
            //if (!manageAuth)
            //{
            //    functionList = functionList.Where(func => func.f_ID == new Guid("00000000-0000-0000-0000-000000000000")).ToList();
            //}

            # endregion

            if (!string.IsNullOrEmpty(RequestBase.GetString("hfPid")))
            {
                functionList =
                    functionList.Where(func => func.f_ParentId == new Guid(RequestBase.GetString("hfPid"))).ToList();
            }
           
            functionList = functionList.OrderBy(func => func.f_PaiX).ToList(); //排序
            
            //查询总条数
            int total = functionList.Count();

            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();

            return View(functionList.ToPagedList(pageNumber, pageSize));
        }

        #endregion

        #region 编辑

        /// <summary>
        /// 修改前，显示的视图数据
        /// </summary>
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult FunctionEdit()
        {
            this.ViewData["hfOtype"] = RequestBase.GetString("otype");
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001004001"); //是否拥有管理的权限
            switch (ViewData["hfOtype"].ToString())
            {
                case "modify":
                    //获取选中功能的f_ID
                    Guid id = new Guid(RequestBase.GetString("f_ID").Split('|')[0]);
                    //将选中的f_ID记为子列表的hfid
                    this.ViewData["hfid"] = RequestBase.GetString("f_ID").Split('|')[0];
                    
                    //获取当前实体
                    webs_YueyxShop.Model.FunctionBase model2 = _db.GetModel(id);
                    Guid parentid = model2.f_ParentId;
                    //将实体内容记录到内存
                    this.ViewData["txtMingc"] = model2.f_MingCh;
                    this.ViewData["txtPaix"] = model2.f_PaiX;
                    this.ViewData["txtMiaos"] = model2.f_MiaoSh;
                    this.ViewData["txtZhujm"] = model2.f_ZhuJM;
                    this.ViewData["hfid"] = model2.f_ID;
                    
                    //获取当前模块的上级模块
                    webs_YueyxShop.Model.FunctionBase model3 = _db.GetModel(parentid);
                    if (model3 != null)
                    {
                        //存在记录名称
                        ViewData["txtPid"] = model3.f_MingCh;
                    }
                    break;
                case "add":
                    ViewData["hfPid"] = RequestBase.GetString("hf_add").Split('|')[0];
                    ViewData["hf_Cengj"] = RequestBase.GetString("hf_add").Split('|')[1];
                    //非顶级层级
                    if ((string) ViewData["hf_Cengj"] != "0")
                    {
                        webs_YueyxShop.Model.FunctionBase model = _db.GetModel(new Guid(RequestBase.GetString("hf_add").Split('|')[0]));
                        if (model != null)
                        {
                            ViewData["hfbianm"] = model.f_BianM;
                            ViewData["txtPid"] = model.f_MingCh;
                        }
                    }
                    break;
                default:
                    FunctionObj = new webs_YueyxShop.Model.FunctionBase();
                    break;
            }
            return View();
        }

        #endregion

        #region 保存

        //[HttpPost]
        /// <summary>
        /// 添加/修改
        /// </summary>
        public ActionResult Save()
        {
            try
            {
                bool result = false;
                switch (Request.Form["hfOtype"])
                {
                    case "add":
                        {
                            Guid parentid = new Guid(Request.Form["hfPid"].ToString()); //父id
                            string mingc = Request.Form["txtMingc"].ToString(); //名称
                            string zhujm = Request.Form["txtZhujm"].ToString(); //助记码

                            #region 验证 判断是否存在（名称、助记码）

                            //同级下是否名称重复
                            var functionlist =
                                _db.GetModelList(
                                    string.Format(
                                        "f_DeleteStateCode = 0 and f_MingCh = '{0}' and f_ParentId = '{1}'",
                                        mingc, parentid));

                            if (functionlist.Any())
                            {
                                return Content(DWZUtil.GetResultJson("300", "名称已存在", "", "", ""));
                            }

                            if (!string.IsNullOrEmpty(zhujm))
                            {
                                //同级下是否助记码重复
                                var functionlist2 =
                                    _db.GetModelList(
                                        string.Format(
                                            "f_DeleteStateCode = 0 and f_ZhuJM = '{0}' and f_ParentId = '{1}'",
                                            zhujm, parentid));
                                if (functionlist2.Any())
                                {
                                    return Content(DWZUtil.GetResultJson("300", "名称已存在", "", "", ""));
                                }
                            }

                            #endregion

                            result = _db.Add(FunctionObj);
                        }
                        break;
                    case "modify":
                        {
                            #region 修改时的实体

                            Guid id = new Guid(Request.Form["hfid"].ToString().Split('|')[0]);
                            webs_YueyxShop.Model.FunctionBase model = _db.GetModel(id);

                            model.f_MingCh = Request.Form["txtMingc"].ToString();
                            model.f_MiaoSh = Request.Form["txtMiaos"].ToString();
                            model.f_ZhuJM = Request.Form["txtZhujm"].ToString();
                            if (!string.IsNullOrEmpty(Request.Form["txtPaix"].ToString()))
                            {
                                model.f_PaiX = int.Parse(Request.Form["txtPaix"].ToString());
                            }
                            else
                            {
                                model.f_PaiX = 0;
                            }

                            #endregion

                            #region 验证 判断是否存在（名称、助记码）

                            var functionlist =
                                _db.GetModelList(
                                    string.Format(
                                        "f_DeleteStateCode = 0 and f_MingCh = '{0}' and f_ParentId = '{1}' and f_ID != '{2}'",
                                        model.f_MingCh, model.f_ParentId, model.f_ID));
                            if (functionlist.Any())
                            {
                                return Content(DWZUtil.GetResultJson("300", "名称已存在", "", "", ""));
                            }
                            if (!string.IsNullOrEmpty(model.f_ZhuJM))
                            {
                                var functionlist2 =
                                    _db.GetModelList(
                                        string.Format(
                                            "f_DeleteStateCode = 0 and f_ZhuJM = '{0}' and f_ParentId = '{1}' and f_ID != '{2}'",
                                            model.f_ZhuJM, model.f_ParentId, model.f_ID));
                                if (functionlist2.Any())
                                {
                                    return Content(DWZUtil.GetResultJson("300", "名称已存在", "", "", ""));
                                }
                            }

                            #endregion

                            result = _db.Update(model);
                        }
                        break;
                }
                return Content(result ? DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "", "closeCurrent", "functionBox", "") 
                                      : DWZUtil.GetResultJson("300", "操作失败！！", "", "", ""));
            }
            catch (Exception ex)
            {
                return Content(DWZUtil.GetResultJson("300", "操作失败！！", "", "", ""));
            }
        }

        #endregion

        #region 实体

        /// <summary>
        /// 获取实体
        /// </summary>
        private webs_YueyxShop.Model.FunctionBase FunctionObj
        {
            get
            {
                webs_YueyxShop.Model.FunctionBase model = new webs_YueyxShop.Model.FunctionBase();
                if (Request.Form["hfOtype"] == "add")
                {
                    model.f_ID = Guid.NewGuid();
                    int cengji = int.Parse(Request.Form["hf_Cengj"].ToString()) + 1;
                    string bianma = Request.Form["hfbianm"].ToString();
                    model.f_BianM = GetCode(cengji, bianma); //编码
                    model.f_CengJ = cengji; //层级
                    model.f_ParentId = new Guid(Request.Form["hfPid"].ToString()); //上级
                    model.f_CreatedOn = DateTime.Now;
                    model.f_CreatedBy = EmployeeBase.e_ID; //添加者
                    model.f_StatusCode = 0;
                    model.f_DeleteStateCode = 0;
                }
                model.f_MingCh = Request.Form["txtMingc"].ToString();
                model.f_MiaoSh = Request.Form["txtMiaos"].ToString();
                model.f_ZhuJM = Request.Form["txtZhujm"].ToString();
                if (!string.IsNullOrEmpty(Request.Form["txtPaix"].ToString()))
                {
                    model.f_PaiX = int.Parse(Request.Form["txtPaix"].ToString());
                }
                else
                {
                    model.f_PaiX = 0;
                }
                return model;
            }
            set { }
        }

        #endregion

        #region 获取编码

        /// <summary>
        /// 获取代码
        /// 增加时，生成的BianM
        /// </summary>
        public string GetCode(int nLayer, string bianM)
        {
            string returnCode = "";
            string maxBianm = "";
            if (nLayer == 1)
            {
                var maxFunctionBase =
                    _db.GetModelList(
                        string.Format(
                            "f_BianM in ( select max(f_BianM) from FunctionBase where f_DeleteStateCode = 0 and f_CengJ = 1 and f_ParentId = '00000000-0000-0000-0000-000000000000')"))
                       .FirstOrDefault();
                if (maxFunctionBase != null)
                {
                    maxBianm = maxFunctionBase.f_BianM;
                }

                if (string.IsNullOrEmpty(maxBianm))
                {
                    returnCode = "001";
                }
                else
                {
                    int number = Convert.ToInt32(maxBianm) + 1;
                    returnCode = number.ToString("000");
                }
            }
            else
            {
                var maxFunctionBase =
                    _db.GetModelList(
                        string.Format(
                            "f_BianM in ( select max(f_BianM) from FunctionBase where f_DeleteStateCode = 0 and f_CengJ = '{0}' and f_BianM like '{1}%')",
                            nLayer, bianM))
                       .FirstOrDefault();
                if (maxFunctionBase != null)
                {
                    maxBianm = maxFunctionBase.f_BianM;
                }
                if (string.IsNullOrEmpty(maxBianm))
                {
                    returnCode = bianM + "001";
                }
                else
                {
                    int number = Convert.ToInt32(maxBianm.Substring(bianM.Length, 3)) + 1;
                    returnCode = bianM + number.ToString("000");
                }
            }
            return returnCode;
        }

        #endregion

        #region 删除

        /// <summary>
        /// 设置删除状态代码
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="stateCode"></param>
        /// <returns>成功更新的数目</returns>
        private int UpDateDeleteStateCode(string strWhere, int stateCode)
        {
            int i = 0;

            var functionList = _db.GetModelList(strWhere);
            foreach (webs_YueyxShop.Model.FunctionBase fBase in functionList)
            {
                try
                {
                    fBase.f_DeleteStateCode = stateCode;
                    if (_db.Update(fBase))
                        i++;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return i;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public ActionResult DataDel()
        {
            try
            {
                int i = UpDateDeleteStateCode("f_ID='" + RequestBase.GetString("f_ID").Split('|')[0] + "'", 1);

                return Content(i > 0 ? DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "", "", "functionBox", "") 
                                     : DWZUtil.GetResultJson("300", "操作失败！！", "", "", ""));
            }
            catch (Exception ex)
            {
                return RedirectToAction("FunctionMsg");
            }
        }

        #endregion

        #region 启，禁用

        /// <summary>
        /// 设置状态代码
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="statusCode"></param>
        /// <returns>成功更新的数目</returns>
        private int UpDateStatusCode(string strWhere, int statusCode)
        {
            int i = 0;

            var functionList = _db.GetModelList(strWhere);
            foreach (webs_YueyxShop.Model.FunctionBase fBase in functionList)
            {
                try
                {
                    fBase.f_StatusCode = statusCode;
                    if (_db.Update(fBase))
                        i++;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return i;
        }

        public ActionResult Enable()
        {
            try
            {
                int i = 0;
                if (RequestBase.GetString("otype") == "enable")
                {
                    i = UpDateStatusCode("f_ID='" + RequestBase.GetString("f_ID").Split('|')[0] + "'", 0);
                }
                if (RequestBase.GetString("otype") == "disable")
                {
                    i = UpDateStatusCode("f_ID='" + RequestBase.GetString("f_ID").Split('|')[0] + "'", 1);
                }
                if (i > 0)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "", "", "functionBox", ""));
                }
                return Content(DWZUtil.GetResultJson("300", "操作失败！！", "", "", ""));

            }
            catch (Exception ex)
            {
                return RedirectToAction("FunctionMsg");
            }
        }

        #endregion
    }
}
