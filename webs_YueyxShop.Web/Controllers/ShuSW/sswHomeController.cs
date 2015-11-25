using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webs_YueyxShop.Model;

namespace webs_YueyxShop.Web.Controllers.ShuSW
{
    public class sswHomeController : sswMasterController
    {
        public ActionResult Index() 
        {
            ViewBag.Title = "书生网-大学生喜爱的购物平台";


            DateTime  sysdate =  Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss"));//系统当前时间
            int sda = sysdate.Hour * 3600 + sysdate.Minute * 60 + sysdate.Second;
            string xx="23:59:59";
            DateTime getdate = Convert.ToDateTime(xx);//1天的当前时间
            int gda = getdate.Hour * 3600 + getdate.Minute * 60 + getdate.Second;

            int de = gda - sda;
            ViewData["datetime"] = de;


            //ViewData[":LoginStatus"] = "";
            //if (System.Web.HttpContext.Current.Request.Cookies[":userlogin"] == null || System.Web.HttpContext.Current.Request.Cookies[":userlogin"].Value == "")
            //{
            //    ViewData[":LoginStatus"] = "fou";
            //}
            //else
            //{
            //    ViewData[":LoginStatus"] = "shi";
            //    MemberBase mimodel = CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies[":userlogin"].Value) as MemberBase;
            //    ViewData[":LoginName"] = mimodel.m_NickName;
            //}


            adert();
            changxiao();
            cuixiao();
            caifujin();
            miaosha();
            return View();
        }

        public void caifujin() 
        {
            DataTable dtcfj = new BLL.NewsBase().GetList(4, " m_ID='8960F09C-EC5A-4F66-8A02-27D6079CFF3B' and n_StatusCode=0 and n_IsDel=0 ", " n_IsTop desc,n_Sort desc,n_CreatedOn desc; ").Tables[0];
            ViewData["dtcfjlist"] = dtcfj;
        }
        /// <summary>
        /// 获取首页轮播图
        /// </summary>
        private void adert() 
        {
            ViewData["pc首页轮播图"] = new BLL.Adert().GetModelList(" a_Status = 0 and a_Delete = 0 and a_PID =37 ");
        }
        /// <summary>
        /// 最畅销
        /// </summary>
        private void changxiao() 
        {
            System.Data.DataTable dtmztm = new webs_YueyxShop.BLL.SKUBase().GetDefaultSKUDetial(" and p_id in( select p_ID from ProductRecommendDetail where prt_ID=1  and prd_Status=0 and prd_IsDelete=0 ) and pi_type=1 and pt_IsDel=0 and pt_StatusCode=0 and b_IsDel=0 and sku_IsDel=0 and sku_StatusCode=0 and pi_StatusCode=0 and pi_IsDel=0 and p_IsDel=0 and p_StatusCode=0");
            ViewData["pc首页最畅销"] = dtmztm;
        }

        /// <summary>
        /// 限时秒杀
        /// </summary>
        private void miaosha()
        {
            System.Data.DataTable dtxsms = new webs_YueyxShop.BLL.SKUBase().GetDefaultSKUDetial(" and p_id in( select p_ID from ProductRecommendDetail where prt_ID=15 and prd_Status=0 and prd_IsDelete=0 ) and pi_type=1 and pt_IsDel=0 and pt_StatusCode=0 and b_IsDel=0 and sku_IsDel=0 and sku_StatusCode=0 and pi_StatusCode=0 and pi_IsDel=0 and p_IsDel=0 and p_StatusCode=0");
            if (dtxsms.Rows.Count > 0)
            {
                ViewData["pc首页限时秒杀"] = dtxsms;
                
            }
            else {
                ViewData["pc首页限时秒杀"] = "";
            }
        }

        /// <summary>
        /// 促销商品推荐
        /// </summary>
        private void cuixiao()
        {
            System.Data.DataTable dtcuxiao = new webs_YueyxShop.BLL.SKUBase().GetDefaultSKUDetial(" and p_id in( select p_ID from ProductRecommendDetail where prt_ID=7  and prd_Status=0 and prd_IsDelete=0 ) and pi_type=1 and pt_IsDel=0 and pt_StatusCode=0 and b_IsDel=0 and sku_IsDel=0 and sku_StatusCode=0 and pi_StatusCode=0 and pi_IsDel=0 and p_IsDel=0 and p_StatusCode=0");
            ViewData["pc首页促销"] = dtcuxiao;
        }

    }
}