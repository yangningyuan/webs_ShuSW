using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using System.Configuration;

namespace webs_YueyxShop.Web.Controllers.YueyXing
{
    public class FindPassWordController : BaseYYController
    {
        private readonly BLL.MemberBase _member = new BLL.MemberBase();

        /// <summary>
        /// 输入账户名
        /// </summary>
        public ActionResult Find1()
        {
            return View();
        }

        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult GetValidateCode()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(5);
            Session["ValidateCode"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }

        //Categories/Num 拿到验证码生成的字符串
        public ActionResult Num(string yanzheng)
        {
            string number = Session["ValidateCode"].ToString();
            if (yanzheng == number)
            {
                return Content("PASS");
            }
            else
            {
                return Content("FALSE");
            }
        }

        /// <summary>
        /// 获取当前验证用户
        /// </summary>
        /// <returns></returns>
        private Model.MemberBase GetCurrentMember()
        {
            var cook = System.Web.HttpContext.Current.Request.Cookies["_findLoginName"];
            if(cook == null)
            {
                return null;
            }

            var model = _member.GetModelList(" m_UserName = '" + cook.Value + "'").FirstOrDefault();

            return model;
        }

        /// <summary>
        /// 保存要找回的用户名
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public string SaveLoginName(string loginName)
        {
            string result = "";
            var model = _member.GetModelList(" m_UserName = '" + loginName + "'").FirstOrDefault();
            if (model != null)
            {
                System.Web.HttpContext.Current.Response.Cookies["_findLoginName"].Value = loginName;
                System.Web.HttpContext.Current.Response.Cookies["_findLoginName"].Expires = DateTime.Now.AddMinutes(180);
            }
            else
            {
                result = "False";
            }
            
            return result;
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        private bool SendMail(Model.MemberBase member)
        {
            bool result = false;

            if (member == null)
            {
                throw new Exception("用户不存在,请重新输入！");
            }

            try
            {
                if (string.IsNullOrWhiteSpace(member.m_Email))
                {
                    throw new Exception("您的账户没有邮箱！");
                }

                string subject = ConfigurationManager.AppSettings["月月兴密码找回邮件"];
                string body = GetEmailValidateCode();
                string fromAddress = ConfigurationManager.AppSettings["mailAccount"];
                string fromPwd = ConfigurationManager.AppSettings["mailPassWord"];
                if (MailMessageExtensions.SendMail(subject, body, fromAddress, member.m_Email, fromPwd))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return result;
        }

        /// <summary>
        /// 生成邮箱验证码
        /// </summary>
        /// <returns></returns>
        private string GetEmailValidateCode()
        {
            string result = CreateValidateCode(7);

            System.Web.HttpContext.Current.Response.Cookies["_findValidateCode"].Value = result;
            System.Web.HttpContext.Current.Response.Cookies["_findValidateCode"].Expires = DateTime.Now.AddMinutes(180);
            
            return result;
        }

        /// <summary>
        /// 生成字母加数字的随机验证码
        /// </summary>
        /// <param name="length">验证码长度</param>
        /// <returns></returns>
        private string CreateValidateCode(int length)
        {
            var random = new Random((int)DateTime.Now.Ticks);
            const string textArray = "0123456789ABCDEFGHGKLMNPQRSTUVWXYZ";
            string result = "";

            for (int i = 0; i < length; i++)
            {
                result += textArray.Substring(random.Next() % textArray.Length, 1);
            }

            return result;
        }

        /// <summary>
        /// 验证身份
        /// </summary>
        /// <returns></returns>
        public ActionResult Find2()
        {
            //获取邮箱
            var model = GetCurrentMember();
            string email = model.m_Email;
            int index = email.IndexOf("@");
            string pemail = email.Substring(0, 2);//前两位
            pemail = pemail + "******";//加六位*
            pemail = pemail + email.Substring(index);
            ViewData["pemail"] = pemail;
            return View();
        }

        /// <summary>
        /// 获取邮箱验证码
        /// </summary>
        /// <returns></returns>
        public string GetEmailCode()
        {
            string result = "";

            try
            {
                //邮件发送成功
                if (SendMail(GetCurrentMember()))
                {
                    result = "True";
                }
                else
                {
                    result = "邮件发送失败！";
                }
            }
            catch (Exception e)
            {
                result = "邮件发送失败！" + e.Message;
            }

            return result;
        }

        /// <summary>
        /// 验证验证码是否正确
        /// </summary>
        /// <returns></returns>
        public string ValidateEmailCode(string vaildCode)
        {
            var cook = System.Web.HttpContext.Current.Request.Cookies["_findValidateCode"];
            string result = "";

            if (cook == null)
            {
                result = "验证码已过期！";
            }
            else
            {
                if (cook.Value == vaildCode)
                {
                    result = "True";
                }
                else
                {
                    result = "验证码不正确！";
                }
            }

            return result;
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <returns></returns>
        public ActionResult Find3()
        {
            return View();
        }

        /// <summary>
        /// 设置新密码
        /// </summary>
        /// <returns></returns>
        public string SetNewPassWord(string pwd)
        {
            string result = "";
            var model = GetCurrentMember();
            if (model == null)
            {
                result = "数据失效，请重新找回密码！";
            }
            else
            {
                model.m_Password = Utils.MD5(pwd);
                if (_member.Update(model))
                {
                    result = "True";
                }
                else
                {
                    result = "系统异常，密码重置失败！";
                }
            }

            return result;
        }

        /// <summary>
        /// 完成
        /// </summary>
        /// <returns></returns>
        public ActionResult Find4()
        {
            return View();
        }
    }
}
