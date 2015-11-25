using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBUtility;
using Common;
using System.Data;
namespace webs_YueyxShop.Web.Controllers.YueyXing
{
    public class RegisterSuccessMailController : MasterPageController
    {
        //注册成功页面  验证邮箱页面
        // GET: /RegisterSuccessMail/

        public ActionResult RegisterSuccessPage()
        {
            string successname = RequestBase.GetString("username");
            string successusertype = RequestBase.GetString("usertype");
            if (LoginMember != null)
            {
                ViewData["IsLogin"] = true;
            }
            else
            {
                ViewData["IsLogin"] = false;
            }
            if (successname != null && successname != "" && successusertype == "0")
            {
                BLL.MemberBase mbbll = new BLL.MemberBase();
                DataSet ds = mbbll.GetList(" m_UserName='" + successname + "' and m_UserType=0");
                string id = ds.Tables[0].Rows[0]["m_ID"].ToString();
                Model.MemberBase mbmodel = new Model.MemberBase();
                mbmodel = mbbll.GetModel(int.Parse(id));
                mbmodel.m_StatusCode = 0;
                mbmodel.m_mailyanzheng = true;
                if (mbbll.Update(mbmodel))
                {
                    ViewData["ueername"] = "恭喜您，" + successname + "，邮箱验证成功！";
                    return View();
                }
                else
                {
                    ViewData["ueername"] = successname + "，数据异常，邮箱验证失败，请联系管理员！";
                    return View();
                }
            }
            else
            {
                BLL.MemberBase mbbll = new BLL.MemberBase();
                DataSet ds = mbbll.GetList(" m_UserName='" + successname + "' and m_UserType=2");
                string id = ds.Tables[0].Rows[0]["m_ID"].ToString();
                Model.MemberBase mbmodel = new Model.MemberBase();
                mbmodel = mbbll.GetModel(int.Parse(id));
                mbmodel.m_StatusCode = 0;
                mbmodel.m_ShenPstatus = 1;
                if (mbbll.Update(mbmodel))
                {
                    ViewData["ueername"] = "恭喜您，" + successname + "，邮箱验证成功！";
                    return View();
                }
                else
                {
                    ViewData["ueername"] = successname + "，数据异常，邮箱验证失败，请联系管理员！";
                    return View();
                }
            }
        }

    }
}
