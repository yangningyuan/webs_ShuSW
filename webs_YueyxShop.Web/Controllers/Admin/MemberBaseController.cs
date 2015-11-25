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
    public class MemberBaseController : BaseController
    {
        private RoleManager Rolemanager = new RoleManager();
        private BLL.MemberBase memberbll = new BLL.MemberBase();
        private readonly RoleManager _roleManager = new RoleManager();
        private BLL.MenuBase mebll = new BLL.MenuBase();
        // GET: /MemberBase/

        public ActionResult MemberBaseMag()
        {
            string m_id = RequestBase.GetString("m_ID");
            List<SelectListItem> selstatus = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "-1" }, new SelectListItem { Text = "启用", Value = "0" }, new SelectListItem { Text = "禁用", Value = "1" } };
            ViewData["selstatus"] = new SelectList(selstatus, "Value", "Text", "请选择");
            List<SelectListItem> selshenhestatus = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "-1" }, new SelectListItem { Text = "未审批", Value = "0" }, new SelectListItem { Text = "审批通过", Value = "1" }, new SelectListItem { Text = "打回", Value = "2" } };
            ViewData["selshenhestatus"] = new SelectList(selshenhestatus, "Value", "Text", "请选择");
            List<SelectListItem> selusertype = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "-1" }, new SelectListItem { Text = "零售用户", Value = "0" }, new SelectListItem { Text = "散批用户", Value = "1" }, new SelectListItem { Text = "加盟商", Value = "2" } };
            ViewData["selusertype"] = new SelectList(selusertype, "Value", "Text", "请选择");
            ViewData["mid"] = m_id;
            return View();
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MemberBaseList()
        {
            int total = 0;//总行数
            int pageSize = 25;//每一页的行数
            int pageNumber = 1;//当前页数 
            StringBuilder sb = new StringBuilder();
            sb.Append(" m_StatusCode!=2 ");//2代表已删除
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            string txtName = RequestBase.GetString("txtName");
            if (!string.IsNullOrEmpty(txtName))
            {
                sb.AppendFormat(" and m_UserName like'%{0}%'", RequestBase.GetString("txtName"));
            }
            string txtphone = RequestBase.GetString("txtphone");
            if (!string.IsNullOrEmpty(txtphone))
            {
                sb.AppendFormat(" and m_Phone='{0}'", RequestBase.GetString("txtphone"));
            }
            if (Request.Form["selstatus"] != "-1")
            {
                sb.AppendFormat(" and m_StatusCode={0}", Request.Form["selstatus"]);
            }
            if (Request.Form["selshenhestatus"] != "-1")
            {
                sb.AppendFormat(" and m_ShenPstatus={0}", Request.Form["selshenhestatus"]);
            }
            if (Request.Form["selusertype"] != "-1")
            {
                sb.AppendFormat(" and m_UserType={0}", Request.Form["selusertype"]);
            }
            var cpt = memberbll.GetModelList(sb.ToString());
            total = cpt.Count();
            this.ViewData["TotalCount"] = total.ToString();
            this.ViewData["NumberPage"] = pageSize.ToString();
            this.ViewData["PagenumShown"] = "10";
            this.ViewData["CurrentPage"] = pageNumber.ToString();
            return View(cpt.ToPagedList(pageNumber, pageSize));
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public ActionResult MemberBaseEdit()
        {
            BLL.VipRank vipbll = new BLL.VipRank();
            List<Model.VipRank> modelVipType = vipbll.GetModelList(" r_Status != 2 and r_Status!=1");
            List<SelectListItem> selectType = new List<SelectListItem>();
            //selectType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "0" } };
            for (int i = 0; i < modelVipType.Count; i++)
            {
                selectType.Add(new SelectListItem
                {
                    Value = modelVipType[i].r_Rank.ToString(),
                    Text = modelVipType[i].r_Name + "---" + modelVipType[i].r_ZheK + "折扣"
                });
            }
            ViewData["addselviprank"] = new SelectList(selectType, "Value", "Text", "请选择");

            return View();
        }
        /// <summary>
        /// 保存添加
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Save(Model.MemberBase model)
        {
            bool result = false;
            #region 验证用户名是否存在
            DataSet isds = new BLL.MemberBase().GetList(" m_UserName='"+model.m_UserName+"'");
            if (isds.Tables[0].Rows.Count>0) 
            {
                return Content(DWZUtil.GetResultJson("300", "保存失败，用户名已存在，请修改！！", "", "", ""));
            }
            #endregion


            #region 验证输入的积分是否在会员等级范围之内
            DataSet ds = new BLL.VipRank().GetList(1, "r_Status!=2  and r_Status!=1", " r_UpperScore desc");
            DataTable dt = ds.Tables[0];
            List<Model.VipRank> listviprankall = new BLL.VipRank().DataTableToList(dt);//得到最大等级积分

            for (int i = 0; i < listviprankall.Count; i++)
            {
                if (model.m_Score > listviprankall[i].r_UpperScore || model.m_Score == null)
                {
                    return Content(DWZUtil.GetResultJson("300", "保存失败，积分不在此会员等级范围内，请修改！！", "", "", ""));
                }
                else
                {
                    if (model.m_Score != null && model.m_Score.ToString() != "" && Request.Form["addselviprank"] != null)
                    {
                        List<Model.VipRank> listviprank = new BLL.VipRank().GetModelList("r_Status!=2  and r_Status!=1 and r_Rank=" + Request.Form["addselviprank"]);
                        for (int j = 0; j < listviprank.Count; j++)
                        {
                            model.m_Rank = listviprank[j].r_Rank;
                            model.m_ZheK = listviprank[j].r_ZheK;
                        }
                    }
                    else {
                        return Content(DWZUtil.GetResultJson("300", "保存失败，积分为空或数据有误！！", "", "", ""));
                    }
                }
            }
            #endregion
            try
            {
                bool istongguo = false;//积分是否在选中的会员等级范围内
                List<Model.VipRank> viprank = new BLL.VipRank().GetModelList("r_Status!=2  and r_Status!=1 and r_Rank=" + Request.Form["addselviprank"]);
                for (int i = 0; i < viprank.Count; i++)
                {
                    if (model.m_Score < viprank[i].r_Score || model.m_Score > viprank[i].r_UpperScore)
                    {
                        istongguo = false;
                    }
                    else
                    {
                        istongguo = true;
                    }
                }
                if (istongguo) //为true时执行
                {
                    model.m_UserType = 1;
                    model.m_Password = Utils.MD5(model.m_Password);
                    result = memberbll.Add(model) > 0 ? true : false;
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "保存失败，积分不在此会员等级范围内，请修改！！", "", "", ""));
                }

                if (result)
                {
                    return Content(DWZUtil.GetResultJson("200", "操作成功！！", "w_会员管理", "", "closeCurrent"));
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
        [HttpPost]
        public ActionResult Delete()
        {
            bool resu = false;
            try
            {
                string m_ID = RequestBase.GetString("m_ID");
                Model.MemberBase mb = memberbll.GetModel(int.Parse(m_ID));
                mb.m_ID = int.Parse(m_ID);
                mb.m_StatusCode = 2;
                if (memberbll.Update(mb))
                {
                    resu = true;
                }
                if (resu)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "删除成功！！", "", "", "", "MemberBox", ""));
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
        public ActionResult MemberBaseStart()
        {
            bool resu = false;
            try
            {
                int m_ID = int.Parse(RequestBase.GetString("m_ID"));
                Model.MemberBase mb = memberbll.GetModel(m_ID);
                mb.m_ID = m_ID;
                mb.m_StatusCode = 0;
                if (memberbll.Update(mb))
                {
                    resu = true;
                }
                if (resu)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "启用成功！！", "", "", "", "MemberBox", ""));
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
        public ActionResult MemberBaseEnd()
        {
            bool resu = false;
            try
            {
                int m_ID = int.Parse(RequestBase.GetString("m_ID"));
                Model.MemberBase mb = memberbll.GetModel(m_ID);
                mb.m_ID = m_ID;
                mb.m_StatusCode = 1;
                if (memberbll.Update(mb))
                {
                    resu = true;
                }
                if (resu)
                {
                    return Content(DWZUtil.GetAjaxTodoJson("200", "冻结成功！！", "", "", "", "MemberBox", ""));
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "程序异常，冻结失败", "", "", ""));
                }
            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "冻结失败！！", "", "", ""));
            }
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult MemberBaseModify()
        {
            int mid = int.Parse(RequestBase.GetString("m_ID"));
            Model.MemberBase mb = memberbll.GetModel(mid);
            BLL.VipRank vipbll = new BLL.VipRank();
            #region 根据积分得到等级
            decimal discount = 1.0M;

            var vipRanks = vipbll.GetModelList(" r_Status = 0 and r_Score <= " + mb.m_Score);
            
            if (vipRanks != null && vipRanks.Any())
            {
                 var model= vipRanks.OrderByDescending(m => m.r_Score).FirstOrDefault();
                if (model != null)
                {
                    //discount = model.r_ZheK.Value;
                    List<Model.VipRank> modelVipType = vipbll.GetModelList(" r_Status != 2  and r_Status!=1");
                    List<SelectListItem> selectType = new List<SelectListItem>();
                    //selectType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "0" } };
                    for (int i = 0; i < modelVipType.Count; i++)
                    {
                        selectType.Add(new SelectListItem
                        {
                            Value = modelVipType[i].r_Rank.ToString(),
                            Text = modelVipType[i].r_Name + "---" + modelVipType[i].r_ZheK + "折扣"
                        });
                    }
                    ViewData["selviprank"] = new SelectList(selectType, "Value", "Text", model.r_Rank);
                }
            }
            #endregion
            return View(mb);
        }
        /// <summary>
        /// 编辑方法
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Modify(Model.MemberBase model)
        {
            bool result = false;

            #region 验证用户名是否存在
            Model.MemberBase member = new BLL.MemberBase().GetModel(model.m_ID);
            if (member.m_UserName == model.m_UserName)//如果没有修改用户名不操作
            {

            }
            else {
                DataSet isds = new BLL.MemberBase().GetList(" m_UserName='" + model.m_UserName + "'");
                if (isds.Tables[0].Rows.Count > 0)
                {
                    return Content(DWZUtil.GetResultJson("300", "修改失败，用户名已存在，请修改！！", "", "", ""));
                }
            }
            #endregion

            #region 验证输入的积分是否在会员等级范围之内
            DataSet ds = new BLL.VipRank().GetList(1, "r_Status!=2  and r_Status!=1", " r_UpperScore desc");
            DataTable dt = ds.Tables[0];
            List<Model.VipRank> listviprankall = new BLL.VipRank().DataTableToList(dt);//得到最大等级积分
            string xx = Request.Form["selviprank"];
            for (int i = 0; i < listviprankall.Count; i++)
            {
                if (model.m_Score > listviprankall[i].r_UpperScore || model.m_Score == null)
                {
                    return Content(DWZUtil.GetResultJson("300", "保存失败，积分不在此会员等级范围内，请修改！！", "", "", ""));
                }
                else
                {
                    if (model.m_Score != null && model.m_Score.ToString() != "" && Request.Form["selviprank"] != null)
                    {
                        List<Model.VipRank> listviprank = new BLL.VipRank().GetModelList("r_Status!=2  and r_Status!=1 and r_Rank=" + Request.Form["selviprank"]);
                        for (int j = 0; j < listviprank.Count; j++)
                        {
                            model.m_Rank = listviprank[j].r_Rank;
                            model.m_ZheK = listviprank[j].r_ZheK;
                        }
                    }
                    else {
                        return Content(DWZUtil.GetResultJson("300", "保存失败，积分为空或数据有误！！", "", "", ""));
                    }
                }
            }
            #endregion
            
            try
            {
                bool istongguo = false;//积分是否在选中的会员等级范围内时
                List<Model.VipRank> viprank = new BLL.VipRank().GetModelList("r_Status!=2  and r_Status!=1 and r_Rank=" + Request.Form["selviprank"]);
                for (int i = 0; i < viprank.Count; i++)
                {
                    if (model.m_Score < viprank[i].r_Score ||model.m_Score > viprank[i].r_UpperScore)
                    {
                        istongguo = false;
                    }
                    else {
                        istongguo = true;
                    }
                }
                if (istongguo) //为true时执行
                {
                    result = memberbll.Update(model);
                }
                else {
                    return Content(DWZUtil.GetResultJson("300", "保存失败，积分不在此会员等级范围内，请修改！！", "", "", ""));
                }
               
                if (result)
                {
                    return Content(DWZUtil.GetResultJson("200", "操作成功！！", "w_会员管理", "", "closeCurrent"));
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
        /// 审核通过
        /// </summary>
        /// <returns></returns>
        public ActionResult MemberBaseShenheyes()
        {
            bool resu = false;
            try
            {
                int m_ID = int.Parse(RequestBase.GetString("m_ID"));
                Model.MemberBase mb = memberbll.GetModel(m_ID);
                mb.m_ID = m_ID;
                if (mb.m_UserType != 0)
                {
                    mb.m_ShenPstatus = 1;
                    if (memberbll.Update(mb))
                    {
                        resu = true;
                    }
                    if (resu)
                    {
                        return Content(DWZUtil.GetAjaxTodoJson("200", "审核通过！！", "", "", "", "MemberBox", ""));
                    }
                    else
                    {
                        return Content(DWZUtil.GetResultJson("300", "程序异常，审核失败", "", "", ""));
                    }
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "审核失败!!! 此账户不在审核流程！", "", "", ""));
                }

            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "审核失败！！", "", "", ""));
            }
        }
        /// <summary>
        /// 审核打回
        /// </summary>
        /// <returns></returns>
        public ActionResult MemberBaseShenheno()
        {
            bool resu = false;
            try
            {
                int m_ID = int.Parse(RequestBase.GetString("m_ID"));
                Model.MemberBase mb = memberbll.GetModel(m_ID);
                mb.m_ID = m_ID;
                if (mb.m_UserType != 0)
                {
                    mb.m_ShenPstatus = 2;
                    if (memberbll.Update(mb))
                    {
                        resu = true;
                    }
                    if (resu)
                    {
                        return Content(DWZUtil.GetAjaxTodoJson("200", "打回成功！！", "", "", "", "MemberBox", ""));
                    }
                    else
                    {
                        return Content(DWZUtil.GetResultJson("300", "程序异常，打回失败", "", "", ""));
                    }
                }
                else
                {
                    return Content(DWZUtil.GetResultJson("300", "打回失败!!! 此帐号不在打回流程！", "", "", ""));
                }
            }
            catch
            {
                return Content(DWZUtil.GetResultJson("300", "打回失败！！", "", "", ""));
            }
        }
        /// <summary>
        /// 输入积分控制下拉框value
        /// </summary>
        /// <returns></returns>
        public string getScore()
        {
            string data="";//返回页面的数据
            bool into =false;//是否在一个等级里边
            try
            {
                int score = int.Parse(RequestBase.GetString("score"));//得到页面输入的积分
                if (score.ToString() != "")//如果页面输入的是正整数
                {
                    List<Model.VipRank> listvip = new BLL.VipRank().GetModelList(" r_Status=0");//得到所有会员等级信息
                    for (int i = 0; i < listvip.Count; i++)
                    {
                        if (listvip[i].r_Score<=score&&listvip[i].r_UpperScore>=score) //比较如果输入的会员积分在等级里边的一个区间
                        {
                            data = listvip[i].r_Rank.ToString();
                            into = true;
                        }
                    }
                }
                else
                {
                    data="error 请输入整数";
                }

                if (into == true)
                {

                }
                else {
                    data = "intofalse";
                }
            }
            catch (Exception)
            {

                data="error";
            }
            return data;
        }
    }
}
