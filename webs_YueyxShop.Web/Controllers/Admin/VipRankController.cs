using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Common;
using PagedList;
namespace webs_YueyxShop.Web.Controllers
{
    public class VipRankController : BaseController
    {
        //
        // GET: /VipRank/
        private RoleManager Rolemanager = new RoleManager();
        private BLL.VipRank viprankbll = new BLL.VipRank();
        private readonly RoleManager _roleManager = new RoleManager();
        private BLL.MenuBase mebll = new BLL.MenuBase();
        /// <summary>
        /// 会员等级管理
        /// </summary>
        /// <returns></returns>
        public ActionResult VipRankMsg()
        {
            return View();
        }
        /// <summary>
        /// 会员等级管理--列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult VipRankList()
        {
            int total = 0;//总行数
            int pageSize = 25;//每一页的行数
            int pageNumber = 1;//当前页数 
            StringBuilder sb = new StringBuilder();
            sb.Append(" r_Status!=2 ");//2代表已删除
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            sb.Append(" order by r_Rank");
            var cpt = viprankbll.GetModelList(sb.ToString());
            total = cpt.Count();
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            return View(cpt.ToPagedList(pageNumber, pageSize));
        }
        /// <summary>
        /// 会员等级管理--添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult VipRankAdd()
        {
            return View();
        }
        /// <summary>
        /// 会员等级管理--修改页面
        /// </summary>
        /// <returns></returns>
        public ActionResult VipRankModify()
        {
            int r_id = int.Parse(RequestBase.GetString("r_ID"));
            Model.VipRank model = viprankbll.GetModel(r_id);
            return View(model);
        }
        /// <summary>
        /// 会员等级管理--添加方法
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult Add(Model.VipRank model)
        {
            bool result = false;
            bool ischongfu = false;
            Model.VipRank mb = new Model.VipRank();
            List<Model.VipRank> listvip = viprankbll.GetModelList(" r_Status!=2");
            for (int i = 0; i < listvip.Count; i++)
            {
                if (listvip[i].r_Rank == model.r_Rank)
                {
                    ischongfu = true;
                }
            }
            try
            {
                if (ischongfu == false)
                {
                    model.r_Status = 0;
                    result = viprankbll.Add(model) > 0 ? true : false;

                    if (result)
                    {
                        return Content(DWZUtil.GetResultJson("200", "操作成功！！", "w_会员等级管理", "", "closeCurrent"));
                    }
                    else
                    {
                        return Content(DWZUtil.GetResultJson("300", "保存失败！！", "", "", ""));
                    }
                }
                else {
                    return Content(DWZUtil.GetResultJson("300", "保存失败,会员等级已存在！！", "", "", ""));
                }
                
            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "保存失败！！", "", "", ""));
            }
        }
        /// <summary>
        /// 会员等级管理--修改方法
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult Modify(Model.VipRank model)
        {
            bool ischongfu = false;
            bool result = false;
            List<Model.VipRank> listvip = viprankbll.GetModelList(" r_Status!=2 and r_ID!="+model.r_ID);
            for (int i = 0; i < listvip.Count; i++)
            {
                if (listvip[i].r_Rank == model.r_Rank)
                {
                    ischongfu = true;
                }
            }
            try
            {
                if (ischongfu == false)
                {
                    result = viprankbll.Update(model);
                    if (result)
                    {
                        return Content(DWZUtil.GetResultJson("200", "操作成功！！", "w_会员等级管理", "", "closeCurrent"));
                    }
                    else
                    {
                        return Content(DWZUtil.GetResultJson("300", "保存失败！！", "", "", ""));
                    }
                }
                else {
                    return Content(DWZUtil.GetResultJson("300", "保存失败,此会员等级已存在！！", "", "", ""));
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
        [ValidateInput(false)]
        public ActionResult Delete()
        {
            bool result = false;
            int r_id = int.Parse(RequestBase.GetString("r_ID"));
            try
            {
                Model.VipRank viprank = viprankbll.GetModel(r_id);
                viprank.r_Status = 2;
                result = viprankbll.Update(viprank);
                if (result)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "删除成功！！", "w_会员等级管理", "", "forward", "VipRankBox", ""));
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
        public ActionResult VipRankStatus()
        {
            bool result = false;
            int r_id = int.Parse(RequestBase.GetString("r_ID"));
            try
            {
                Model.VipRank viprank = viprankbll.GetModel(r_id);
                if (viprank.r_Status == 1)
                {
                    viprank.r_Status = 0;
                    result = viprankbll.Update(viprank);
                    if (result)
                    {
                        return Content(DWZUtil.GetAjaxTodoJson("200", "启用成功！！", "w_会员等级管理", "", "forward", "VipRankBox", ""));
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
        public ActionResult VipRankEnd()
        {
            bool result = false;
            int r_id = int.Parse(RequestBase.GetString("r_ID"));
            try
            {
                Model.VipRank viprank = viprankbll.GetModel(r_id);
                if (viprank.r_Status == 0)
                {
                    viprank.r_Status = 1;
                    result = viprankbll.Update(viprank);
                    if (result)
                    {
                        return Content(DWZUtil.GetAjaxTodoJson("200", "禁用成功！！", "w_会员等级管理", "", "forward", "VipRankBox", ""));
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
    }
}
