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
    public class ProductConsultController : BaseController
    {
        private RoleManager Rolemanager = new RoleManager();
        private BLL.ProductConsultBase pcbll = new BLL.ProductConsultBase();
        private BLL.vm_PCdetails vmbll = new BLL.vm_PCdetails();
        private readonly RoleManager _roleManager = new RoleManager();

        #region 咨询信息
        public ActionResult ProductConsultMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            List<Model.SysCodeBase> modelType = new BLL.SysCodeBase().GetModelList(" substring(sc_BianM,0,5)='0004' and len(sc_BianM)=8 and sc_DeleteStateCode=0");
            List<SelectListItem> selectType = new List<SelectListItem>();
            selectType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "0" } };
            for (int i = 0; i < modelType.Count; i++)
            {
                selectType.Add(new SelectListItem
                {
                    Value = modelType[i].sc_BianM.ToString(),
                    Text = modelType[i].sc_MingCh
                });
            }
            ViewData["selectType"] = new SelectList(selectType, "Value", "Text", "请选择");
            return View();
        }

        /// <summary>
        /// 展示咨询信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductConsultList()
        {
            int total = 0;//总行数
            int pageSize = 25;//每一页的行数
            int pageNumber = 1;//当前页数
            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            if (!string.IsNullOrEmpty(Request.Form["txtPName"]))
            {
                strSql.AppendFormat(" and p_name like '%{0}%' ", Request.Form["txtPrName"]);
            }
            if (!string.IsNullOrEmpty(Request.Form["txtCode"]))
            {
                strSql.AppendFormat(" and sku_Code like '%{0}%' ", Request.Form["txtCode"]);
            }
            if (Request.Form["selType"] != "0")
            {
                switch (Request.Form["selType"])
                {
                    case "1":
                        strSql.Append(" and pc_Type = '售前咨询'");
                        break;
                    case "2":
                        strSql.Append(" and pc_Type = '售后咨询'");
                        break;
                }
            }

            strSql.Append(" order by pc_CreatedOn desc");

            var cpt = vmbll.GetModelList(" pc_IsDel=0 " + strSql);

            total = cpt.Count;
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();

            return View(cpt.ToPagedList(pageNumber, pageSize));
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProductConsultEdit()
        {
            this.ViewData["texOtype"] = RequestBase.GetString("otype");
            BindControl bc = new BindControl();
            ViewData["IsHasFunRole"] = Rolemanager.IsHasFunRole(EmployeeBase.e_ID, "001001001");//是否拥有管理的权限
            Model.vm_PCdetails model = new Model.vm_PCdetails();

            string ids = RequestBase.GetString("dli_id");
            ViewData["hfPId"] = ids;
            int id = int.Parse(ids.Split('|')[0]);
            model = vmbll.GetModel(id);
            ViewData["consulttime"] = model.pc_CreatedOn;
            ViewData["pc_id"] = model.pc_ID;
            List<Model.ProductReplyBase> prmodel = new BLL.ProductReplyBase().GetModelList(" pc_id=" + model.pc_ID);
            if (prmodel != null && prmodel.Count > 0)
            {
                ViewData["prContent"] = prmodel[0].pr_Content;
                ViewData["pr_id"] = prmodel[0].pr_ID;
            }
            return View(model);

        }


        /// <summary>
        /// 添加/修改
        /// </summary>
        public ActionResult ProductConsultEdit(Model.vm_PCdetails vmBase)
        {
            bool result = false;

            try
            {
                int pcid = int.Parse(Request.Form["pc_ID"].ToString());
                string content = RequestBase.GetString("prContent");
                BLL.ProductReplyBase prbll = new BLL.ProductReplyBase();
                List<Model.ProductReplyBase> list = prbll.GetModelList(" pr_isdel=0 and pc_id=" + pcid);
                if (list.Count > 0)
                {
                    Model.ProductReplyBase model = list[0];
                    model.pr_Content = content;
                    Model.ProductConsultBase pcmodel = new BLL.ProductConsultBase().GetModel(pcid);
                    pcmodel.pc_huifu = 1;
                    result = new BLL.ProductReplyBase().Update(model);
                    result = new BLL.ProductConsultBase().Update(pcmodel);
                }
                else
                {
                    Model.ProductReplyBase model = new Model.ProductReplyBase();
                    model.pc_ID = pcid;
                    model.pr_Content = content;
                    model.pr_CreatedBy = EmployeeBase.e_ID;
                    model.pr_CreatedOn = DateTime.Now;
                    model.pr_IsDel = false;
                    model.pr_StatusCode = 0;
                    result = new BLL.ProductReplyBase().Add(model)>0? true:false;
                    if (result)
                    {
                        Model.ProductConsultBase pcmodel = new BLL.ProductConsultBase().GetModel(pcid);
                        pcmodel.pc_huifu = 1;
                        result = new BLL.ProductConsultBase().Update(pcmodel);
                        if (result == false)
                        {

                            new BLL.ProductReplyBase().DeleteList(" (select pr_id from ProductReplyBase where pc_id=" + pcid);
                        }
                    }
                }

                if (result)
                {

                    return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功!!", "", "", "closeCurrent", "pcBox", ""));
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
        /// 绑定咨询分类
        /// </summary>
        /// <returns></returns>
        public ActionResult bindSelType()
        {
            StringBuilder strHtml = new StringBuilder();
            BLL.SysCodeBase bll = new BLL.SysCodeBase();
            List<Model.SysCodeBase> list = bll.GetModelList(" substring(sc_BianM,0,5)='0004' and length(sc_BianM)=8 and sc_DeleteStateCode=0");
            foreach (Model.SysCodeBase model in list)
            {
                strHtml.AppendFormat("<option value='{0}'>{1}</option>", model.sc_BianM, model.sc_MingCh);
            }
            return Content(strHtml.ToString());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductConsultDelete()
        {
            bool result = false;
            string Message = "";
            try
            {
                string id = RequestBase.GetString("dli_id");
                string pid = id.Split('|')[0];
                int ptid = int.Parse(pid);
                Model.ProductConsultBase rpmodel = pcbll.GetModel(ptid);
                rpmodel.pc_IsDel = true;
                result = pcbll.Update(rpmodel);
                if (result)
                {
                    Message = "删除成功！";
                    return Content(DWZUtil.GetAjaxTodoJson("200", Message, "", "", "", "pcBox", ""));
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
        public ActionResult ProductConsultEnable(string otype, string dli_id)
        {

            bool result = false;
            try
            {
                string dliid = RequestBase.GetString("dli_id");
                string pid = dliid.Split('|')[0];
                Model.ProductConsultBase NewP = pcbll.GetModel(int.Parse(pid));
                if (otype == "disable")
                {
                    NewP.pc_StatusCode = 1;
                }
                else
                {
                    NewP.pc_StatusCode = 0;
                }
                result = pcbll.Update(NewP);
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "forward", "", "pcBox", ""));
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


    }
}
