using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using PagedList;
using System.Configuration;
using System.Text;
using webs_YueyxShop.Model;

namespace webs_YueyxShop.Web.Controllers
{
    public class BrandBaseController : BaseController
    {
        //
        // GET: /BrandBase/
        private BLL.BrandBase bll = new BLL.BrandBase();
        BLL.ProductTypeBrandBase ptbBll = new BLL.ProductTypeBrandBase();
        Model.ProductTypeBrandBase ptbmodel = new Model.ProductTypeBrandBase();
        BLL.ProductTypeBase ptypebBll = new BLL.ProductTypeBase();
        Model.ProductTypeBase ptmodel = new Model.ProductTypeBase();
        private readonly RoleManager _roleManager = new RoleManager();

        #region 品牌管理主页
        public ActionResult BrandMsg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BrandList()
        {
            int total = 0;//总行数
            int pageSize = 25;//每一页的行数
            int pageNumber = 1;//当前页数 
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" b_IsDel=0");
            string bname = RequestBase.GetString("txtName");
            if (!string.IsNullOrEmpty(bname))
            {//首字母查询
                strSql.AppendFormat(" and( dbo.GetPiny(b_Name) like '%{0}%' or b_Name like '%{0}%')", bname);
            }
            string bkeys = RequestBase.GetString("txtKeys");
            if (!string.IsNullOrEmpty(bkeys))
            {
                strSql.AppendFormat(" and b_Key like'%{0}%'", bkeys);
            }
            strSql.Append(" order by b_Name ");
            var brandList = bll.GetModelList(strSql.ToString());
            total = brandList.Count();
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();

            return View(brandList.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region 编辑
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult BrandEdit()
        {
            string ptidlist = "";
            string ptname = "";
            ViewData["IsHasFunRole"] = true;//管理权限
            ViewData["hf_luj"] = ConfigurationManager.AppSettings["SaveImage"];//图片的存储路径
            Model.BrandBase model = new Model.BrandBase();
            ViewData["texOtype"] = RequestBase.GetString("otype");

            List<SelectListItem> selectType2 = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            List<SelectListItem> selectType3 = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            ViewData["selectType2"] = new SelectList(selectType2, "Value", "Text");
            ViewData["selectType3"] = new SelectList(selectType3, "Value", "Text");
            switch (RequestBase.GetString("otype"))
            {
                case "modify":
                    string id = RequestBase.GetString("b_ID");//44
                    ViewData["b_ID"] = id;
                    #region 实体
                    model = bll.GetModel(Convert.ToInt32(id));
                    ViewData["LogoUrl"] = model.b_LogoUrl;
                    #endregion 
                    if (!string.IsNullOrEmpty(RequestBase.GetString("pt_id")))
                    {
                        string ptidlist2 = RequestBase.GetString("pt_id").ToString();
                        ptidlist2 = ptidlist2.Substring(0, ptidlist2.Length - 1);
                        var ptlist = ptypebBll.GetModelList(" pt_ID in(" + ptidlist2 + ")");

                        foreach (var item in ptlist)
                        {
                            ptname += item.pt_Name + ",";
                        }
                        if (ptname.Length > 0)
                            ptname = ptname.Substring(0, ptname.Length - 1);
                        ViewData["ptidlist"] = ptidlist2;
                        ViewData["ptname"] = ptname;
                    }
                    else
                    {

                        //查品牌分类明细中指定品牌所属的类别
                        var ptblist = ptbBll.GetModelList(" b_ID=" + id);
                        if (ptblist.Count > 0)
                        {
                            foreach (var i in ptblist)
                            {
                                ptidlist += i.pt_ID + ",";
                            }
                            ptidlist = ptidlist.Substring(0, ptidlist.Length - 1);
                            var pt = ptypebBll.GetModelList(" pt_ID in(" + ptidlist + ")");

                            foreach (var item in pt)
                            {
                                ptname += item.pt_Name + ",";
                            }
                            if (ptname.Length > 0)
                                ptname = ptname.Substring(0, ptname.Length - 1);
                            ViewData["ptidlist"] = ptidlist;
                            ViewData["ptname"] = ptname;
                        }
                        else
                        {
                            ViewData["ptidlist"] = "";
                            ViewData["ptname"] = "";
                        }
                    }
                        return View(model);
                    
                default:
                    if (!string.IsNullOrEmpty(RequestBase.GetString("pt_id")))
                    {
                        string ptidlist2 = RequestBase.GetString("pt_id").ToString();
                        ptidlist2 = ptidlist2.Substring(0, ptidlist2.Length - 1);
                        var ptlist = ptypebBll.GetModelList(" pt_ID in(" + ptidlist2 + ")");

                        foreach (var item in ptlist)
                        {
                            ptname += item.pt_Name + ",";
                        }
                        if (ptname.Length > 0)
                            ptname = ptname.Substring(0, ptname.Length - 1);
                        ViewData["ptidlist"] = ptidlist2;
                        ViewData["ptname"] = ptname;
                    }
                    else
                    {
                        ViewData["ptidlist"] = "";
                        ViewData["ptname"] = "";
                    }
                    ViewData["b_ID"] = RequestBase.GetString("b_ID");
                    return View();
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        public ActionResult Save(Model.BrandBase model)
        {
            int result = 0;
            int ptbresult = 0;
            bool upresult = false;
            try
            {
                if (Request.Form["texOtype"] == "add")
                {
                    //menuBase.m_ID = Guid.NewGuid();
                    model.b_CreatedOn = DateTime.Now;
                    model.b_CreatedBy = EmployeeBase.e_ID;
                    model.b_LogoUrl = Request.Form["FileInputEId"].ToString();

                    result = bll.Add(model);

                    if (Request.Form["ptidlist"] != "")
                    {
                        string ptidlist = Request.Form["ptidlist"];
                        string[] ptid = ptidlist.Split(',');
                        for (int i = 0; i < ptid.Length; i++)
                        {
                            ptbmodel.pt_ID = int.Parse(ptid[i]);
                            ptbmodel.b_ID = result;
                            ptbresult = ptbBll.Add(ptbmodel);
                        }

                    }
                    else
                    {
                        return Content(DWZUtil.GetResultJson("300", "请选择品牌所属类别！！", "", "", ""));
                    }
                }
                else
                {
                    Model.BrandBase NewModel = bll.GetModel(model.b_ID);
                    NewModel.b_Name = model.b_Name;
                    NewModel.b_Key = model.b_Key;
                    NewModel.b_LogoUrl = Request.Form["FileInputEId"].ToString();
                    NewModel.b_SiteUrl = model.b_SiteUrl;
                    NewModel.b_Sort = model.b_Sort;
                    upresult = bll.Update(NewModel);
                    var ptypebrand = ptbBll.GetModelList(" b_ID="+model.b_ID);
                    if (ptypebrand.Count > 0)
                    {
                        bool del = ptbBll.Deletebybid(model.b_ID);
                    }
                    if (Request.Form["ptidlist"] != "")
                    {
                        string ptidlist = Request.Form["ptidlist"];
                        string[] ptid = ptidlist.Split(',');
                        for (int i = 0; i < ptid.Length; i++)
                        {
                            ptbmodel.pt_ID = int.Parse(ptid[i]);
                            ptbmodel.b_ID = model.b_ID;
                            ptbresult = ptbBll.Add(ptbmodel);
                        }
                    }
                    else
                    {
                        return Content(DWZUtil.GetResultJson("300", "请选择品牌所属类别！！", "", "", ""));
                    }
                }
                if ((result > 0 && ptbresult > 0)||upresult)
                {
                    return Content(DWZUtil.GetResultJson("200", "操作成功！！", "w_品牌管理", "", "closeCurrent"));
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
        #endregion

        #region 删除
        public ActionResult Delete()
        {
            bool result = true;
            try
            {
                string id = RequestBase.GetString("b_ID");
                Model.BrandBase NewModel = bll.GetModel(Convert.ToInt32(id));
                NewModel.b_IsDel = true;
                var ptypebrand = new BLL.ProductBase().GetModelList(" p_IsDel=0 and b_Id=" + int.Parse(id));
                if (ptypebrand.Count > 0)
                {
                    return Content(DWZUtil.GetResultJson("300", "该品牌已被商品引用，不允许删除！！", "", "", ""));
                }
                else
                {
                    result = bll.Update(NewModel);
                    if (result)
                        return Content(DWZUtil.GetAjaxTodoJson("200", "删除成功！！", "", "", "", "BrandBox", ""));
                    else
                        return Content(DWZUtil.GetResultJson("300", "程序异常，删除失败", "", "", ""));
                }
            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "删除失败！！", "", "", ""));
            }
        }
        #endregion

        #region 设置品牌分类
        public ActionResult BrandTypeMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            ViewData["texOtype"] = RequestBase.GetString("otype");
            ViewData["b_ID"] = RequestBase.GetString("b_ID");
            return View();
        }

        [HttpPost]
        public ActionResult BrandTypeList()
        {
            int total = 0;//总行数
            int pageSize = 25;//每一页的行数
            int pageNumber = 1;//当前页数 
            string ptparentid = "0";
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            if (RequestBase.GetString("hfPid") != "")
            {
                ptparentid = RequestBase.GetString("hfPid").ToString();
            }
            var cpt = ptypebBll.GetModelList(" pt_parentid =" + int.Parse(ptparentid) + " and pt_isdel=0 ");
            total = cpt.Count();
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            return View(cpt.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult BrandClass()
        {
            ViewData["hf_IsManage"] = true; // new CRM.Public.RoleManager().IsHasFunRole(EmployeeInfo.e_ID, "006007001");//管理权限
            //所有商品分类
            BLL.ProductTypeBase rtBll = new BLL.ProductTypeBase();

            var List = rtBll.GetModelList(" pt_IsDel=0  order by pt_Sort ASC");
            var Ids = ptbBll.GetModelList(" b_ID='" + RequestBase.GetString("b_ID") + "'");//拥有分类
            string PTIds = "";
            foreach (Model.ProductTypeBrandBase j in Ids)
            {
                PTIds += j.pt_ID + ",";
            }
            @ViewData["hfItems"] = PTIds;
            @ViewData["hfbId"] = RequestBase.GetString("b_ID");
            return View(List.ToList());
        }
        /// <summary>
        /// 品牌分类的保存
        /// </summary>
        public string AddBrandClass(string ptid, string bid, string otype)
        {
            try
            {
                bool result = false;
                //单选时
                if (otype == "del")
                {
                    result = ptbBll.Delete(ptid, bid);
                }
                else
                {
                    result = ptbBll.Add(Convert.ToInt32(ptid), Convert.ToInt32(bid)) > 0 ? true : false;
                }
                if (result)
                {
                    return "保存成功！";
                }
                return "保存失败！";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        #endregion
    }
}
