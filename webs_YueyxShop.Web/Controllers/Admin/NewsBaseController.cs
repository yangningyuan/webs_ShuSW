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
    public class NewsBaseController : BaseController
    {
        private RoleManager Rolemanager = new RoleManager();
        private BLL.NewsBase newsbll = new BLL.NewsBase();
        private readonly RoleManager _roleManager = new RoleManager();
        private BLL.MenuBase mebll = new BLL.MenuBase();


        // GET: /NewsBase/

        public ActionResult NewsBaseMsg()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            string mid = RequestBase.GetString("mid").ToString();
            Model.MenuBase mb = mebll.GetModel(new Guid(mid));
            ViewData["mid"] = mid;
            ViewData["pagetype"] = mb.m_PageType;
            ViewData["tabid"] = mb.m_MingCh;//得到当前要显示的窗体
            return View();
        }
        /// <summary>
        /// 列表页
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult NewsBaseList()
        {
            int total = 0;//总行数
            int pageSize = 25;//每一页的行数
            int pageNumber = 1;//当前页数 
            string mid = RequestBase.GetString("mid");//菜单id
            Model.MenuBase mb = mebll.GetModel(new Guid(mid));
            ViewData["mbmc"] = mb.m_MingCh;//菜单名称
            StringBuilder sb = new StringBuilder();
            sb.Append(" n_IsDel=0 ");
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("mid")))
            {
                sb.AppendFormat(" and m_ID='{0}'", new Guid(RequestBase.GetString("mid")));
            }
            string txtkeys = RequestBase.GetString("txtKeys");
            if (!string.IsNullOrEmpty(txtkeys))
            {
                sb.AppendFormat(" and n_Title like'%{0}%'", RequestBase.GetString("txtkeys"));
            }
            var cpt = newsbll.GetModelList(sb.ToString());
            total = cpt.Count();
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            return View(cpt.ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        /// 保存
        /// </summary>
        [ValidateInput(false)]
        public ActionResult Save(Model.NewsBase model)
        {
            bool result = false;
            Model.MenuBase mb = new Model.MenuBase();
            try
            {
                if (Request.Form["txbotype"] == "add")
                {
                    Model.NewsBase nb = new Model.NewsBase();

                    //根据菜单id得到菜单名称供返回
                    mb = mebll.GetModel(new Guid(RequestBase.GetString("mid")));

                    //menuBase.m_ID = Guid.NewGuid();
                    nb.m_ID = new Guid(RequestBase.GetString("mid").ToString());//菜单id
                    nb.n_Content = model.n_Content;
                    nb.n_CreatedBy = base.EmployeeBase.e_ID;
                    nb.n_PicUrl = Request.Form["FileInputEId"].ToString();
                    nb.n_QRCode = model.n_QRCode;
                    nb.n_RedirectUrl = model.n_RedirectUrl;
                    nb.n_Sort = model.n_Sort;
                    nb.n_Title = model.n_Title;
                    nb.n_Writer = base.EmployeeBase.e_MingC;
                    result = newsbll.Add(nb) > 0 ? true : false;
                }
                else
                {
                    Guid userid = base.EmployeeBase.e_ID;//用户id
                    Model.NewsBase nb = newsbll.GetModel(model.n_ID);
                    nb.n_Title = model.n_Title;
                    nb.n_RedirectUrl = model.n_RedirectUrl;
                    nb.n_QRCode = model.n_QRCode;
                    nb.n_Sort = model.n_Sort;
                    nb.n_PicUrl = Request.Form["FileInputEId"].ToString();
                    nb.n_Content = model.n_Content;
                    nb.n_CreatedBy = userid;
                    nb.n_Writer = base.EmployeeBase.e_MingC;
                    result = newsbll.Update(nb);
                }
                if (result)
                {
                    return Content(DWZUtil.GetResultJson("200", "操作成功！！", "w_" + mb.m_MingCh, "", "closeCurrent"));
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
        /// 单页面
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult SinglePage()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            Model.NewsBase nb = new Model.NewsBase();
            this.ViewData["otype"] = RequestBase.GetString("otype");
            this.ViewData["mid"] = RequestBase.GetString("mid");
            ViewData["n_id"] = RequestBase.GetString("n_id");
            switch (RequestBase.GetString("otype"))
            {
                case "modify":
                    string id = RequestBase.GetString("n_id");
                    nb = newsbll.GetModel(int.Parse(id));
                    ViewData["picurl"] = nb.n_PicUrl;
                    return View(nb);
            }
            return View();
        }
        /// <summary>
        /// 文字列表页面
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult LangListPage()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            Model.NewsBase nb = new Model.NewsBase();
            this.ViewData["otype"] = RequestBase.GetString("otype");
            this.ViewData["mid"] = RequestBase.GetString("mid");
            ViewData["n_id"] = RequestBase.GetString("n_id");
            switch (RequestBase.GetString("otype"))
            {
                case "modify":
                    string id = RequestBase.GetString("n_id");
                    nb = newsbll.GetModel(int.Parse(id));
                    ViewData["picurl"] = nb.n_PicUrl;
                    return View(nb);
            }
            return View();
        }
        /// <summary>
        /// 图片列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ImageListPage()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            Model.NewsBase nb = new Model.NewsBase();
            this.ViewData["otype"] = RequestBase.GetString("otype");
            this.ViewData["mid"] = RequestBase.GetString("mid");
            ViewData["n_id"] = RequestBase.GetString("n_id");
            switch (RequestBase.GetString("otype"))
            {
                case "modify":
                    string id = RequestBase.GetString("n_id");
                    nb = newsbll.GetModel(int.Parse(id));
                    ViewData["picurl"] = nb.n_PicUrl;
                    return View(nb);
            }
            return View();
        }
        /// <summary>
        /// 非咨询页面
        /// </summary>
        /// <returns></returns>
        public ActionResult FalseConsultPage()
        {
            ViewData["IsHasFunRole"] = _roleManager.IsHasFunRole(EmployeeBase.e_ID, "001002001"); //是否拥有管理的权限
            Model.NewsBase nb = new Model.NewsBase();
            this.ViewData["otype"] = RequestBase.GetString("otype");
            this.ViewData["mid"] = RequestBase.GetString("mid");
            ViewData["n_id"] = RequestBase.GetString("n_id");
            switch (RequestBase.GetString("otype"))
            {
                case "modify":
                    string id = RequestBase.GetString("n_id");
                    nb = newsbll.GetModel(int.Parse(id));
                    ViewData["picurl"] = nb.n_PicUrl;
                    return View(nb);
            }
            return View();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete()
        {
            bool resu = false;
            try
            {
                string n_id = RequestBase.GetString("n_ID");
                Model.NewsBase nb = newsbll.GetModel(int.Parse(n_id));
                nb.n_ID = int.Parse(n_id);
                nb.n_IsDel = true;
                if (newsbll.Update(nb))
                {
                    resu = true;
                }
                if (resu)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "删除成功！！", "w_品牌管理", "", "forward", "BrandBox", ""));
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "程序异常，删除失败", "", "", ""));
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
        public ActionResult NewsBaseStart()
        {
            bool resu = false;
            try
            {
                int n_id = int.Parse(RequestBase.GetString("n_ID"));
                Model.NewsBase nb = newsbll.GetModel(n_id);
                nb.n_ID = n_id;
                nb.n_StatusCode = 0;
                if (newsbll.Update(nb))
                {
                    resu = true;
                }
                if (resu)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "启用成功！！", "w_品牌管理", "", "forward", "BrandBox", ""));
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "程序异常，启用失败", "", "", ""));
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
        public ActionResult NewsBaseEnd()
        {
            bool resu = false;
            try
            {
                int n_id = int.Parse(RequestBase.GetString("n_ID"));
                Model.NewsBase nb = newsbll.GetModel(n_id);
                nb.n_ID = n_id;
                nb.n_StatusCode = 1;
                if (newsbll.Update(nb))
                {
                    resu = true;
                }
                if (resu)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "冻结成功！！", "w_品牌管理", "", "forward", "BrandBox", ""));
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "程序异常，禁用失败", "", "", ""));
                }
            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "禁用失败！！", "", "", ""));
            }
        }
        /// <summary>
        /// 置顶
        /// </summary>
        /// <returns></returns>
        public ActionResult NewsBaseStick()
        {
            bool resu = false;
            try
            {
                int n_id = int.Parse(RequestBase.GetString("n_ID"));
                Model.NewsBase nb = newsbll.GetModel(n_id);
                nb.n_ID = n_id;
                nb.n_IsTop = true;
                if (newsbll.Update(nb))
                {
                    resu = true;
                }
                if (resu)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "置顶成功！！", "w_品牌管理", "", "forward", "BrandBox", ""));
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "程序异常，置顶失败", "", "", ""));
                }
            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "置顶失败！！", "", "", ""));
            }
        }

        /// <summary>
        /// 取消置顶
        /// </summary>
        /// <returns></returns>
        public ActionResult NewsBaseCancelStick()
        {
            bool resu = false;
            try
            {
                int n_id = int.Parse(RequestBase.GetString("n_ID"));
                Model.NewsBase nb = newsbll.GetModel(n_id);
                nb.n_ID = n_id;
                nb.n_IsTop = false;
                if (newsbll.Update(nb))
                {
                    resu = true;
                }
                if (resu)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "取消置顶成功！！", "w_品牌管理", "", "forward", "BrandBox", ""));
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "程序异常，取消置顶失败", "", "", ""));
                }
            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "取消置顶失败！！", "", "", ""));
            }
        }
        /// <summary>
        /// 友情链接管理页面
        /// </summary>
        /// <returns></returns>
        public ActionResult NewsBaseYouQingLinkMsg()
        {
            string mid = RequestBase.GetString("mid").ToString();
            ViewData["mid"] = mid;
            return View();
        }
        /// <summary>
        /// 友情链接数据列表页
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult NewsBaseYouQingLinkList()
        {
            int total = 0;//总行数
            int pageSize = 25;//每一页的行数
            int pageNumber = 1;//当前页数 
            string mid = RequestBase.GetString("mid");//菜单id
            Model.MenuBase mb = mebll.GetModel(new Guid(mid));
            StringBuilder sb = new StringBuilder();
            sb.Append(" n_IsDel=0 ");
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("mid")))
            {
                sb.AppendFormat(" and m_ID='{0}'", new Guid(RequestBase.GetString("mid")));
            }
            string txtkeys = RequestBase.GetString("txtKeys");
            if (!string.IsNullOrEmpty(txtkeys))
            {
                sb.AppendFormat(" and n_Title like'%{0}%'", RequestBase.GetString("txtkeys"));
            }
            sb.AppendFormat(" order by n_ID");
            var cpt = newsbll.GetModelList(sb.ToString());
            total = cpt.Count();
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            return View(cpt.ToPagedList(pageNumber, pageSize));
        }
        /// <summary>
        /// 友情链接添加页面
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult NewsBaseYouQingLinkAdd()
        {
            Model.NewsBase nb = new Model.NewsBase();
            this.ViewData["otype"] = RequestBase.GetString("otype");
            this.ViewData["mid"] = RequestBase.GetString("mid");
            switch (RequestBase.GetString("otype"))
            {
                case "modify":
                    string nid = RequestBase.GetString("n_ID");
                    Model.NewsBase model = new BLL.NewsBase().GetModel(int.Parse(nid));
                    return View(model);
                default:
                    break;
            }
            return View();
        }
        /// <summary>
        /// 添加友情链接方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult YouQingAdd(Model.NewsBase model)
        {
            bool result = false;
            Model.MenuBase mb = new Model.MenuBase();
            try
            {
                if (Request.Form["txbotype"] == "add")
                {
                    Model.NewsBase nb = new Model.NewsBase();

                    nb.m_ID = new Guid(RequestBase.GetString("mid").ToString());//菜单id
                    nb.n_CreatedBy = base.EmployeeBase.e_ID;
                    nb.n_RedirectUrl = model.n_RedirectUrl;
                    nb.n_Sort = model.n_Sort;
                    nb.n_Title = model.n_Title;
                    result = newsbll.Add(nb) > 0 ? true : false;
                }
                else
                {
                    Guid userid = base.EmployeeBase.e_ID;//用户id
                    Model.NewsBase nb = newsbll.GetModel(model.n_ID);
                    nb.n_Title = model.n_Title;
                    nb.n_RedirectUrl = model.n_RedirectUrl;
                    nb.n_Sort = model.n_Sort;
                    nb.n_Synopsis = model.n_Synopsis;
                    result = newsbll.Update(nb);
                }
                if (result)
                {
                    return Content(DWZUtil.GetResultJson("200", "操作成功！！", "w_友情链接", "", "closeCurrent"));
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
    }
}
