using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace webs_YueyxShop.Web.Controllers.Wap
{
    public class wapRegisterController : BaseWapController
    {
        private readonly BLL.MemberBase _member = new BLL.MemberBase();

        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 保存
        /// </summary>
        public string SaveRegister()
        {
            string result = "";

            string name = RequestBase.GetString("name");
            string pwd = RequestBase.GetString("pwd");
            string phone = RequestBase.GetString("phone");
            string email = RequestBase.GetString("email");
            string yyzz = RequestBase.GetString("yyzz");
            if (name.Trim().Length < 6)
            {
                result += "用户名不能小于6位<br>";
            }
            if (pwd.Trim().Length < 6 || pwd.Trim().Length > 20)
            {
                result += "密码必须为6-20位字符串<br>";
            }
            if (!RegexHelper.IsPhone(phone))
            {
                result += "电话号码格式不正确！<br>";
            }
            if (!RegexHelper.IsEmail(email))
            {
                result += "邮箱格式不正确！<br>";
            }
            if (string.IsNullOrWhiteSpace(result))
            {
                try
                {
                    Model.MemberBase member = new Model.MemberBase();
                    member.m_UserName = name;
                    member.m_Password = Utils.MD5(pwd);
                    member.m_Email = email;
                    member.m_Phone = phone;
                    member.m_Score = 0;
                    member.m_Rank = 1;
                    member.m_ZheK = 1;
                    member.m_StatusCode = 0;
                    member.m_ShenPstatus = 1;
                    if (!string.IsNullOrWhiteSpace(yyzz))
                    {
                        member.m_YingYZZ = yyzz;
                        member.m_UserType = 2;
                    }
                    if (_member.Add(member) == 0)
                    {
                        result = "注册失败！";
                    }
                }
                catch
                {
                    result = "注册失败！";
                }
            }

            return result;
        }

        public ActionResult RegisterSuccess()
        {
            return View();
        }
    }
}
