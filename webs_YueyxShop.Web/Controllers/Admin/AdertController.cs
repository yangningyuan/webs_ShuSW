using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Text;
using Common;
using DBUtility;
using PagedList;
namespace webs_YueyxShop.Web.Controllers
{
    public class AdertController :BaseController
    {

        private BLL.Adert adertbll = new BLL.Adert();

        //广告管理
        // GET: /Adert/
        /// <summary>
        /// 广告列表页
        /// </summary>
        /// <returns></returns>
        public ActionResult AdertMsg()
        {
            //绑定广告分类
            BLL.ProductTypeBase ptbll = new BLL.ProductTypeBase();
            List<Model.ProductTypeBase> modelType = ptbll.GetModelList(" pt_ParentId = 0  and pt_IsDel=0 and pt_StatusCode=0");

            List<SelectListItem> selectType = new List<SelectListItem>();
            selectType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "-1" } };
            for (int i = 0; i < modelType.Count; i++)
            {
                selectType.Add(new SelectListItem
                {
                    Value = modelType[i].pt_ID.ToString(),
                    Text = modelType[i].pt_Name
                });
            }
            ViewData["AdertFenLeiPosition"] = new SelectList(selectType, "Value", "Text", "请选择");


            //绑定广告位置
            BLL.AdertPositionBase apbll = new BLL.AdertPositionBase();
            List<Model.AdertPositionBase> listap = apbll.GetModelList(" p_Status = 0 and p_Delete=0");

            List<SelectListItem> selectposition = new List<SelectListItem>();
            selectposition = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "-1" } };
            for (int i = 0; i < listap.Count; i++)
            {
                selectposition.Add(new SelectListItem
                {
                    Value = listap[i].p_ID.ToString(),
                    Text = listap[i].p_PositionName
                });
            }
            ViewData["AdertPosition"] = new SelectList(selectposition, "Value", "Text", "请选择");

            return View();
        }
        /// <summary>
        /// 广告列表
        /// </summary>
        /// <returns></returns>
        public ActionResult AdertList() 
        {
            int total = 0;//总行数
            int pageSize = 25;//每页25行
            int pageNumber = 1;//当前页
            StringBuilder sb = new StringBuilder();
            sb.Append(" a_Delete=0 ");//1代表已删除
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            string aderttitle = RequestBase.GetString("txttitle");
            if (!string.IsNullOrEmpty(aderttitle)) 
            {
                sb.AppendFormat(" and a_Title like'%{0}%'", aderttitle);
            }
            if (Request.Form["AdertFenLeiPosition"] != "-1") 
            {
                sb.AppendFormat(" and a_spare2=" + Request.Form["AdertFenLeiPosition"]);
            }
            if (Request.Form["AdertPosition"] != "-1")
            {
                sb.AppendFormat(" and a_PID=" + Request.Form["AdertPosition"]);
            }
            sb.Append(" order by a_ID");
            var cpt = adertbll.GetModelList(sb.ToString());
            total = cpt.Count();
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            return View(cpt.ToPagedList(pageNumber, pageSize));
        }
        /// <summary>
        /// 添加/编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult AdertEdit() 
        {
            //绑定广告位置
            BLL.AdertPositionBase apbll = new BLL.AdertPositionBase();
            List<Model.AdertPositionBase> listadert= apbll.GetModelList(" p_Delete=0 and p_Status=0 ");
            List<SelectListItem> seltype = new List<SelectListItem>();
            seltype = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "-1" } };
            for (int i = 0; i < listadert.Count; i++)
            {
                seltype.Add(new SelectListItem
                {
                    Value = listadert[i].p_ID.ToString(),
                    Text = listadert[i].p_PositionName
                });
            }
            ViewData["AdertPosition"] = new SelectList(seltype, "Value", "Text", "请选择");

            //绑定广告分类
            BLL.ProductTypeBase ptbll = new BLL.ProductTypeBase();
            List<Model.ProductTypeBase> modelType = ptbll.GetModelList(" pt_ParentId = 0  and pt_IsDel=0 and pt_StatusCode=0");

            List<SelectListItem> selectType = new List<SelectListItem>();
            selectType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "-1" } };
            for (int i = 0; i < modelType.Count; i++)
            {
                selectType.Add(new SelectListItem
                {
                    Value = modelType[i].pt_ID.ToString(),
                    Text = modelType[i].pt_Name
                });
            }
            ViewData["AdertFenLeiPosition"] = new SelectList(selectType, "Value", "Text", "请选择");




            ViewData["otype"] = RequestBase.GetString("otype");
            if (RequestBase.GetString("a_ID") != null && RequestBase.GetString("a_ID") != "")
            {
                Model.Adert adert = new BLL.Adert().GetModel(int.Parse(RequestBase.GetString("a_ID")));
                ViewData["AdertPosition"] = new SelectList(seltype, "Value", "Text", adert.a_PID);

                if (adert.a_spare2 != null)
                {
                    ViewData["AdertFenLeiPosition"] = new SelectList(selectType, "Value", "Text", adert.a_spare2);
                }
                else { 
                    
                }

                ViewData["picurl"] = adert.a_Image;
                return View(adert);
            }
            else {
                return View();
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Save(Model.Adert model) 
        {
            bool result = false;
            
            try
            {
                if (Request.Form["AdertPosition"] == "-1")
                {
                    return Content(DWZUtil.GetResultJson("300", "保存失败！！请选择广告位置", "", "", ""));
                }
                else if (Request.Form["FileInputEId"].ToString() == "") {
                    return Content(DWZUtil.GetResultJson("300", "保存失败！！请上传一张广告图片", "", "", ""));
                }
                else
                {
                    if (Request.Form["txbotype"] == "add")
                    {
                        model.a_PID = int.Parse(Request.Form["AdertPosition"]);//广告位置ID
                        Model.AdertPositionBase apmodel = new BLL.AdertPositionBase().GetModel(int.Parse(Request.Form["AdertPosition"]));
                        model.a_spare1 = apmodel.p_PositionName;//广告位置名称
                        if (Request.Form["AdertFenLeiPosition"] == "-1")
                        {
                        }
                        else {
                            model.a_spare2 = int.Parse(Request.Form["AdertFenLeiPosition"]);
                        }

                        model.a_Image = Request.Form["FileInputEId"].ToString();
                        model.a_CreateUser = base.EmployeeBase.e_ID;
                        result = adertbll.Add(model) > 0 ? true : false;

                    }
                    else
                    {
                        model.a_PID = int.Parse(Request.Form["AdertPosition"]);
                        if (Request.Form["AdertFenLeiPosition"] == "-1")
                        {

                        }
                        else {
                            model.a_spare2 = int.Parse(Request.Form["AdertFenLeiPosition"]);
                        }
                        Model.AdertPositionBase adertmodel =new BLL.AdertPositionBase().GetModel(model.a_PID);
                        model.a_spare1 = adertmodel.p_PositionName;
                        model.a_Image = Request.Form["FileInputEId"].ToString();
                        result = adertbll.Update(model);
                    }
                }
                
                if (result)
                {
                    return Content(DWZUtil.GetResultJson("200", "操作成功！！", "w_广告管理", "", "closeCurrent"));
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
        public ActionResult Delete() 
        {
            bool result = false;
            int a_id = int.Parse(RequestBase.GetString("a_ID"));
            try
            {
                Model.Adert adert = adertbll.GetModel(a_id);
                adert.a_Delete = 1;
                result = adertbll.Update(adert);
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "删除成功！！", "w_广告管理", "", "forward", "AdertBox", ""));
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "删除失败！！", "", "", ""));
                }
            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "删除失败！！", "", "", ""));
            }
        
        }

        /// <summary>
        /// 启用
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult AdertStatus()
        {
            bool result = false;
            int a_id = int.Parse(RequestBase.GetString("a_ID"));
            try
            {
                Model.Adert adert = adertbll.GetModel(a_id);
                if (adert.a_Status == 1)
                {
                    adert.a_Status = 0;
                    result = adertbll.Update(adert);
                    if (result)
                    {
                        return Content(DWZUtil.GetAjaxTodoJson("200", "启用成功！！", "w_广告", "", "forward", "AdertBox", ""));
                    }
                    else
                    {
                        return Content(DWZUtil.GetResultJson("300", "启用失败！！", "", "", ""));
                    }
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "启用失败,此数据已启用，请不要重复操作！！", "", "", ""));
                }
            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "启用失败！！", "", "", ""));
            }
        }
        /// <summary>
        /// 禁用
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult AdertEnd()
        {
            bool result = false;
            int a_id = int.Parse(RequestBase.GetString("a_ID"));
            try
            {
                Model.Adert adert = adertbll.GetModel(a_id);
                if (adert.a_Status == 0)
                {
                    adert.a_Status = 1;
                    result = adertbll.Update(adert);
                    if (result)
                    {
                        return Content(DWZUtil.GetAjaxTodoJson("200", "禁用成功！！", "w_广告管理", "", "forward", "AdertBox", ""));
                    }
                    else
                    {
                        return Content(DWZUtil.GetResultJson("300", "禁用失败！！", "", "", ""));
                    }
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "禁用失败，此数据已禁用，请不要重复操作！！", "", "", ""));
                }
            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "禁用失败！！", "", "", ""));
            }
        }
        /// <summary>
        /// 输入积分控制下拉框value
        /// </summary>
        /// <returns></returns>
        public string getScore()
        {
            string data = "";//返回页面的数据
            try
            {
                int score = int.Parse(RequestBase.GetString("aa"));//得到广告位置id
                if (score.ToString() != "")//如果页面输入的是正整数
                {
                    Model.AdertPositionBase moap = new BLL.AdertPositionBase().GetModel(score);
                    data = moap.p_PositionExplain;
                }
                else
                {
                    data = "error 请选择广告位置";
                }
            }
            catch (Exception)
            {

                data = "error";
            }
            return data;
        }
    }
}
