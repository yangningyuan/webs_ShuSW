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

namespace webs_YueyxShop.Web.Controllers
{
    public class ProductsTypeController : BaseController
    {
        private RoleManager Rolemanager = new RoleManager();
        private BLL.ProductTypeBase ptbll = new BLL.ProductTypeBase();
        private readonly RoleManager _roleManager = new RoleManager();

        public ActionResult ProductsTypeMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            return View();
        }

        [HttpPost]
        public ActionResult ProductsTypeList()
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
            var cpt = ptbll.GetModelList(" pt_parentid =" + int.Parse(ptparentid)+" and pt_isdel=0 ");
            total = cpt.Count();
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            return View(cpt.ToPagedList(pageNumber, pageSize));
        }


        /// <summary>
        /// 编辑
        /// </summary>
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProductsTypeEdit()
        {
            Model.ProductTypeBase ptmodel = new Model.ProductTypeBase();
            this.ViewData["texOtype"] = RequestBase.GetString("otype");
            ViewData["hf_luj"] = ConfigurationManager.AppSettings["SaveImage"];//图片的存储路径

            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            if (RequestBase.GetString("otype") == "modify")
            {
                string ids = RequestBase.GetString("dli_id");
                string id = ids.Split('|')[0];
                int ptid = int.Parse(id);
                ptmodel = ptbll.GetModel(ptid);
                ViewData["LogoUrl"] = ptmodel.pt_ImgUrl;
                return View(ptmodel);
            }
            else
            {
                string pids = RequestBase.GetString("dli_id");
                ViewData["hfPId"] = pids;
                return View();
            }
        }

        /// <summary>
        /// 修改/添加
        /// </summary>
        public ActionResult ProductsTypeEdit(Model.ProductTypeBase producttype)
        {
            int result = 0;
            bool resultup = false;
            string Message = "";
            if (Request.Form["texOtype"] == "add")
            {
                var hfpid = Request.Form["hfPId"];
                var pid = hfpid.Split('|')[0];
                string player = hfpid.Split('|')[1];
                int layer = int.Parse(player);
                var code = hfpid.Split('|')[2];
                producttype.pt_ParentId = int.Parse(pid);
                producttype.pt_IsDel = false;
                producttype.pt_CreatedOn = DateTime.Now;
                if (int.Parse(pid) == 0)
                {
                    producttype.pt_Layer = layer;
                    code = "";
                }
                else
                {
                    producttype.pt_Layer = layer+1;
                }
                producttype.pt_StatusCode = 0;
                string BianMa = ptbll.GetCode(code, layer);
                producttype.pt_Code = BianMa;//001003
                int sort = ptbll.GetSort(pid, layer);
                producttype.pt_Sort = sort;
                producttype.pt_ImgUrl = Request.Form["FileInputEId"].ToString();
                result = ptbll.Add(producttype);

            }
            else
            {
                Model.ProductTypeBase newpt = ptbll.GetModel(producttype.pt_ID);
                newpt.pt_Name = producttype.pt_Name;
                newpt.pt_Content = producttype.pt_Content;
                newpt.pt_ImgUrl = Request.Form["FileInputEId"].ToString();
                resultup = ptbll.Update(newpt);
            }
            if (result > 0 || resultup)
            {
                 // return Content(DWZUtil.GetResultJson("200", "操作成功！！", "", "", "closeCurrent"));
              return Content(DWZUtil.GetAjaxTodoJson("200", "保存成功！！", "", "forward", "closeCurrent", "ptBox", ""));
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
       [HttpPost]
        public ActionResult ProductsTypeDelete()
        {

            bool result = false;
            string Message = "";
            try
            {
                string dliid = RequestBase.GetString("dli_id");
                string pid = dliid.Split('|')[0];
               List<Model.ProductTypeBase> model = ptbll.GetModelList(" pt_parentid ="+pid+" and pt_IsDel=0");
               if (model.Count > 0)
               {
                   Message = "该类别下有其它子类，不允许删除！";
                   return Content(DWZUtil.GetResultJson("300", Message, "", "", ""));

               }
               else
               {
                   var ptlist = new BLL.ProductBase().GetModelList(" p_IsDel=0 and pt_Id="+pid);
                   if (ptlist.Count > 0)
                   {
                       return Content(DWZUtil.GetResultJson("300", "该类别已被引用，不允许删除", "", "", ""));
                   }
                   else
                   {
                       Model.ProductTypeBase ptmodel = ptbll.GetModel(int.Parse(pid));
                       ptmodel.pt_IsDel = true;
                       result = ptbll.Update(ptmodel);
                   }
               }
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "删除成功！！", "", "", "", "ptBox", ""));
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



        /// <summary>
        /// 启/禁用
        /// </summary>
        /// <param name="otype"></param>
        /// <param name="dli_id"></param>
        /// <returns></returns>
       public ActionResult ProductsTypeEnable(string otype, string dli_id)
       {

           bool result = false;
           try
           {
               string dliid = RequestBase.GetString("dli_id");
               string pid = dliid.Split('|')[0];
               Model.ProductTypeBase NewMenu = ptbll.GetModel(int.Parse(pid));
               if (NewMenu.pt_Layer == 1)
               {
                   if (otype == "disable")
                   {
                       result = ptbll.UpdateList(1, int.Parse(pid));
                   }
                   else
                   {
                       result = ptbll.UpdateList(0, int.Parse(pid));
                   }
               }
               else
               {
                   if (otype == "disable")
                   {
                       NewMenu.pt_StatusCode = 1;
                   }
                   else
                   {
                       NewMenu.pt_StatusCode = 0;
                   }
                   result = ptbll.Update(NewMenu);
               }
               if (result)
               {
                   return Content(DWZUtil.GetAjaxTodoJson("200", "操作成功！！", "", "", "", "ptBox", ""));
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
