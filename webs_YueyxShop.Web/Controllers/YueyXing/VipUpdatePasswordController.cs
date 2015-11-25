using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using System.Data;

namespace webs_YueyxShop.Web.Controllers.YueyXing
{
    public class VipUpdatePasswordController : MasterPageController
    {
        //
        // GET: /VipUpdatePassword/
        private BLL.NewsBase _newsBase = new BLL.NewsBase();
        private BLL.MemberBase _memberBase = new BLL.MemberBase();

        # region CMS

        private void GetCMS()
        {
            GetNewsBase("Link", "eb9595fa-89cd-4815-8f7c-fa563db7f5bc", true);//友情链接
            GetNewsBase("Helper", "b2092e66-6d92-449d-b32c-b84047f5a64f", true);//新手入门
            GetNewsBase("AboutUs", "a7e89dd5-281d-403f-a9b1-a45b5574b4c8", true);//关于我们
            GetNewsBase("ShipType", "7f4659b5-9161-4f63-8cb5-c6960b6f7b1b", true);//配送方式
            GetNewsBase("PaymentType", "2907dd64-7cc1-4ef2-b0b1-244144342403", true);//支付方式
            GetNewsBase("Service", "d09e52e5-d884-4c0e-9039-3371f1347fa7", true);//售后服务
            GetNewsBase("CharacteristicService", "fb9f0894-952c-4df7-b857-fe9fb9341fe6", true);//特色服务
        }

        /// <summary>
        /// 获取菜单内容
        /// </summary>
        /// <param name="viewName">前台ViewData名称</param>
        /// <param name="mID">菜单ID</param>
        /// <param name="isTop">首页显示内容</param>
        /// <returns></returns>
        protected virtual object GetNewsBase(string viewName, string mID, bool isTop)
        {
            string sql = "m_ID = '" + mID + "' and n_IsDel = 0 and n_StatusCode = 0";
            if (isTop)
                sql += " and n_IsTop = 1 ";
            ViewData[viewName] = _newsBase.GetModelList(sql);
            return ViewData[viewName];
        }

        # endregion




        /// <summary>
        /// 验证身份page
        /// </summary>
        /// <returns></returns>
        public ActionResult vipPasswordValidation()
        {
            GetCMS();
            return View();
        }
        /// <summary>
        /// 验证身份方法
        /// </summary>
        /// <returns></returns>
        public ActionResult passwordValid() 
        {
            int mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
            string password = Request.Form["updatepassword"];
            string md5pass=Utils.MD5(password);
            BLL.MemberBase mbbll = new BLL.MemberBase();
            Model.MemberBase mbmodel = mbbll.GetModel(mid);
            if (md5pass == mbmodel.m_Password)
            {
                return RedirectToAction("vipChangePassword", "VipUpdatePassword");
            }
            else {
                return Content("<script>alert('原始密码错误，请检查！');location.href='vipPasswordValidation'</script>");
            }
        }
        /// <summary>
        ///输入新密码page 
        /// </summary>
        /// <returns></returns>
        public ActionResult vipChangePassword()
        {
            GetCMS();
            return View();
        }
        /// <summary>
        /// 输入新密码方法
        /// </summary>
        /// <returns></returns>
        public ActionResult vipChangePasswordValid() 
        {
            try
            {
                int mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
                string password = Request.Form["password"];
                string md5pass = Utils.MD5(password);
                BLL.MemberBase mbbll = new BLL.MemberBase();
                Model.MemberBase mbmodel = mbbll.GetModel(mid);
                mbmodel.m_ID = mid;
                mbmodel.m_Password = md5pass;
                if (new BLL.MemberBase().Update(mbmodel))
                {
                    //重新保存登录缓存
                    var model = _memberBase.GetModel(LoginMember.m_ID);
                    System.Web.HttpContext.Current.Response.Cookies["UserInfo"].Value = CookieEncrypt.SerializeObject(model);
                    System.Web.HttpContext.Current.Response.Cookies["UserInfo"].Expires = DateTime.Now.AddMinutes(180);
                    return RedirectToAction("vipSuccessPassword");
                }
                else {
                    return Content("<script>alert('修改密码失败，系统异常！');location.href='vipChangePassword'</script>");
                }
            }
            catch (Exception)
            {
              return Content("<script>alert('修改密码失败，系统异常！');location.href='vipChangePassword'</script>");
            }
        }
        /// <summary>
        /// 修改成功page
        /// </summary>
        /// <returns></returns>
        public ActionResult vipSuccessPassword()
        {
            GetCMS();
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
    }
}
