using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Common;
using DBUtility;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using System.Configuration;
using System.Text;
namespace webs_YueyxShop.Web.Controllers.YueyXing
{
    public class RegisterController : BaseYYController
    {
        //
        // GET: /Register/

        private BLL.NewsBase _newsBase = new BLL.NewsBase();
        private BLL.RegionBase _regionBase = new BLL.RegionBase();
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
        /// 个人注册页面
        /// </summary>
        /// <returns></returns>
        public ActionResult singleRegister()
        {
            var xieyi = _newsBase.GetModelList(" n_Title='个人注册协议'  and n_StatusCode=0 and n_IsDel=0");
            if (xieyi != null && xieyi.Any())
            {
                ViewBag.xieyi = Server.HtmlDecode(xieyi[0].n_Content);
            }
            else
            {
                ViewBag.xieyi = "暂无注册协议";
            }
            return View();
        }

        public string GetUrl()
        {
            string url = HttpContext.Request.Url.Authority;//域名

            string path = ConfigurationManager.AppSettings["RegisterSuccessPage"].ToString();//物理路径
            string stringurl = url + path;
            return stringurl;
        }

        /// <summary>
        /// 注册个人会员方法
        /// </summary>
        /// <returns></returns>
        public ActionResult singleRegisterAdd()
        {
            string username = Request.Form["userName"];
            string password = Request.Form["password"];
            string md5password = Utils.MD5(password);
            string email = Request.Form["email"];
            string phone = Request.Form["phone"];
            try
            {
                Model.MemberBase mb = new Model.MemberBase();
                mb.m_UserName = username;
                mb.m_Password = md5password;
                mb.m_Email = email;
                mb.m_Phone = phone;
                mb.m_Score = 0;
                mb.m_Rank = 1;
                mb.m_ZheK = 1;
                mb.m_StatusCode = 0;
                mb.m_ShenPstatus = 1;
                string url = GetUrl();
                ////发送邮件
                //string successemailpage=ConfigurationManager.AppSettings["RegisterSuccessPage"].ToString();
                //string mailAccount = ConfigurationManager.AppSettings["mailAccount"].ToString();//发送者邮箱
                //string mima = ConfigurationManager.AppSettings["mailPassWord"].ToString();//发送者邮箱密码
                //string mailShowName = ConfigurationManager.AppSettings["mailShowName"].ToString();//邮件主题
                //string body = "欢迎注册月月兴个人会员！请点击<div><a href='http://" + url + "?username=" + username + "&usertype=0'>月月兴验证</a>链接完成注册！</div>";
                //if (MailMessageExtensions.SendMail(mailShowName, body, mailAccount, mb.m_Email, mima))
                //{
                Session["newpmid"]=new BLL.MemberBase().Add(mb);
                if (int.Parse(Session["newpmid"].ToString())> 0)
                {
                    Session["registerusername"] = username;
                    Session["registeremail"] = email;
                    return View("successRegiser");
                }
                else
                {
                    return Content("<script>alert('注册失败，系统信息异常！');location.href='singleRegister'</script>");
                }
                //}
                //else
                //{
                //    return Content("<script>alert('注册失败，您输入邮箱的不存在！');location.href='singleRegister'</script>");
                //}
            }
            catch (Exception)
            {
                return Content("<script>alert('注册失败，系统信息异常！');location.href='singleRegister'</script>");
            }
        }
        /// <summary>
        /// 企业会员
        /// </summary>
        /// <returns></returns>
        public ActionResult companyRegister()
        {
            var modelList = _regionBase.GetModelList(" reg_PId = 0");

            List<SelectListItem> selectType = new List<SelectListItem>();
            selectType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            foreach (var model in modelList)
            {
                selectType.Add(new SelectListItem
                {
                    Value = model.reg_Code.ToString(),
                    Text = model.reg_Name
                });
            }
            ViewData["selectType"] = new SelectList(selectType, "Value", "Text", "请选择");
            List<SelectListItem> selectType2 = new List<SelectListItem>();
            selectType2 = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            ViewData["selectType2"] = new SelectList(selectType2, "Value", "Text", "请选择");
            List<SelectListItem> selectType3 = new List<SelectListItem>();
            selectType3 = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            ViewData["selectType3"] = new SelectList(selectType3, "Value", "Text", "请选择");

            var xieyi = _newsBase.GetModelList(" n_Title='企业注册协议'  and n_StatusCode=0 and n_IsDel=0");
            if (xieyi != null && xieyi.Any())
            {
                ViewBag.xieyi = xieyi[0].n_Content;
            }
            else
            {
                ViewBag.xieyi = "暂无注册协议";
            }
            return View();
        }
        /// <summary>
        /// 企业会员注册方法
        /// </summary>
        /// <returns></returns>
        public ActionResult companyRegisterAdd()
        {
            string username = Request.Form["email"];
            string password = Request.Form["password"];
            //转换md5
            string md5password = Utils.MD5(password);
            string lianxiren = Request.Form["lxname"];
            string phone = Request.Form["phone"];
            string lxemail = Request.Form["lxemail"];
            string qq = Request.Form["qq"];
            string gsname = Request.Form["gsname"];
            string yyzz = Request.Form["yyzz"];
            string xxdizhi = Request.Form["xxadress"];
            //省份地区
            int shengfen = Convert.ToInt32(Request.Form["selectType"]);
            int shi = Convert.ToInt32(Request.Form["selectType2"]);
            int quyu = Convert.ToInt32(Request.Form["selectType3"]);

            //固定电话
            string quhao = Request.Form["quhao"];
            string gdhaoma = Request.Form["gdhaoma"];
            string fenji = Request.Form["fenji"];
            string gudingdianhao = "";//固定电话
            if (quhao != null && quhao != "")
            {
                gudingdianhao += quhao;
            }
            if (gdhaoma != null && gdhaoma != "")
            {
                gudingdianhao += gdhaoma;
            }
            if (fenji != null && fenji != "")
            {
                gudingdianhao += fenji;
            }
            try
            {
                Model.MemberBase mb = new Model.MemberBase();
                mb.m_UserName = username;
                mb.m_Password = md5password;
                mb.m_RealName = lianxiren;//联系人
                if (gudingdianhao != "")
                {
                    mb.m_GDPhone = gudingdianhao;
                }
                mb.m_Phone = phone;
                mb.m_Email = lxemail;
                mb.m_QQ = qq;
                mb.m_GongSiName = gsname;
                mb.m_YingYZZ = yyzz;
                mb.m_Provice = shengfen;
                mb.m_City = shi;
                mb.m_Count = quyu;
                mb.m_GongSiAddress = xxdizhi;

                mb.m_Score = 0;
                mb.m_Rank = 1;
                mb.m_ZheK = 1;
                mb.m_UserType = 2;
                mb.m_StatusCode = 0;
                mb.m_ShenPstatus = 0;
                ////发送邮件
                //string url = GetUrl();
                //string mailAccount = ConfigurationManager.AppSettings["mailAccount"].ToString();//发送者邮箱
                //string mima = ConfigurationManager.AppSettings["mailPassWord"].ToString();//发送者邮箱密码
                //string mailShowName = ConfigurationManager.AppSettings["mailShowName"].ToString();//邮件主题
                //string body = "欢迎注册月月兴企业会员！请点击<div><a href='http://" + url + "?username=" + username + "&usertype=2'>月月兴验证</a>链接完成注册！</div>";
                //if (MailMessageExtensions.SendMail(mailShowName, body, mailAccount, mb.m_Email, mima))
                //{
                Session["newcmid"]=new BLL.MemberBase().Add(mb);
                if (int.Parse(Session["newcmid"].ToString()) > 0)
                {
                    Session["registerusername"] = username;
                    Session["registeremail"] = lxemail;
                    Session["usertype"] = "2";
                    return View("successRegiser"  );
                }
                else
                {
                    return Content("<script>alert('注册失败，系统信息异常！');location.href='companyRegister'</script>");
                }
                //}
                //else
                //{
                //    return Content("<script>alert('注册失败，您输入邮箱的不存在！');location.href='companyRegister'</script>");
                //}
            }
            catch (Exception)
            {
                return Content("<script>alert('注册失败，系统异常！');location.href='companyRegister'</script>");
            }
        }
        /// <summary>
        ///验证用户名是否存在
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        [ValidateInput(false)]
        public string validatename()
        {
            #region 验证用户名是否存在
            DataSet isds = new BLL.MemberBase().GetList(" m_UserName='" + RequestBase.GetString("name") + "'");
            if (isds.Tables[0].Rows.Count > 0)
            {
                return "error";
            }
            else
            {
                return "success";
            }
            #endregion
        }
        /// <summary>
        ///验证企业登录邮箱是否被注册
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        [ValidateInput(false)]
        public string validateemal()
        {
            #region 验证企业登录邮箱
            DataSet isds = new BLL.MemberBase().GetList(" m_UserName='" + RequestBase.GetString("name") + "'");
            if (isds.Tables[0].Rows.Count > 0)
            {
                return "error";
            }
            else
            {
                return "success";
            }
            #endregion
        }

        /// <summary>
        /// 注册成功页面
        /// </summary>
        /// <returns></returns>
        public ActionResult successRegiser()
        {
            int mid = 0;
            
            if (!string.IsNullOrEmpty(RequestBase.GetString("mid")))
            {
                mid = int.Parse(RequestBase.GetString("mid"));
            }
            ViewData["mid"] = Session["newmid"];
            
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

        [HttpGet]
        public string GetBattr(string id)
        {
            StringBuilder attr = new StringBuilder();
            if (RequestBase.GetString("code") != "")
            {
                id = RequestBase.GetString("code");
            }
            if (id == "chose")
            {
                return "refresh";
            }
            else
            {
                List<SelectListItem> selectattrP = new List<SelectListItem>();
                var modelList = _regionBase.GetModelList(" reg_PId = " + id);
                StringBuilder sbGoodsName = new StringBuilder();
                attr.Append("[[\"chose\",\"请选择\"]");
                foreach (var model in modelList)
                {
                    attr.Append(",[");
                    attr.Append("\"" + model.reg_Code.ToString() + "\",");
                    attr.Append("\"" + model.reg_Name + "\"");
                    attr.Append("]");
                }

                attr.Append("]");

                return attr.ToString();
            }
        }

        [HttpPost]
        public string sendemail()
        {
            int mid = 0;
            int mtype = 0;

            if (Session["newcmid"] != null && !string.IsNullOrEmpty(Session["newcmid"].ToString()))
            {
                mid = int.Parse(Session["newcmid"].ToString());
                mtype = 1;
            }
            if (Session["newpmid"] != null && !string.IsNullOrEmpty(Session["newpmid"].ToString()))
            {
                mid = int.Parse(Session["newpmid"].ToString());
                mtype = 0;
            }
            string successemailpage = ConfigurationManager.AppSettings["RegisterSuccessPage"].ToString();
            string mailAccount = ConfigurationManager.AppSettings["mailAccount"].ToString();//发送者邮箱
            string mima = ConfigurationManager.AppSettings["mailPassWord"].ToString();//发送者邮箱密码
            string mailShowName = ConfigurationManager.AppSettings["mailShowName"].ToString();//邮件主题
            string url = GetUrl();
            Model.MemberBase model = new BLL.MemberBase().GetModel(mid);

            string body = "欢迎注册月月兴会员！请点击<div><a href='http://" + url + "?username=" + model.m_UserName + "&usertype=" + mtype + "'>月月兴验证</a>链接完成注册！(若不是本人操作，请忽略此邮件)</div>";
            if (MailMessageExtensions.SendMail(mailShowName, body, mailAccount, model.m_Email, mima))
            {
                model.m_ShenPstatus = 1;
                bool result = new BLL.MemberBase().Update(model);
                return "http://www.mail." + model.m_Email.Substring(model.m_Email.IndexOf('@') + 1, model.m_Email.Length - model.m_Email.IndexOf('@') - 1); ;
            }
            else
            {
                return "";
            }
        }


    }
}
