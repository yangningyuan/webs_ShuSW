using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace webs_YueyxShop.Web.Controllers.YueyXing
{
    public class MasterPageController : BaseYYController
    {
        private readonly BLL.ProductTypeBase _productTypeBase = new BLL.ProductTypeBase();
        private readonly BLL.Adert _adert = new BLL.Adert();
        private readonly BLL.NewsBase _newsBase = new BLL.NewsBase();
        
        /// <summary>
        /// 通用主页
        /// </summary>
        public MasterPageController():this("主母版页")
        {

            var type1 = _productTypeBase.GetModelList(" pt_ParentId = 0 and pt_IsDel = 0 and pt_StatusCode = 0");
            ViewBag.type = type1;
            ViewData["products"] = GetProductType();
            ViewData["searchProType"] = _productTypeBase.GetModelList(" pt_IsDel = 0 and pt_StatusCode = 0 and pt_ParentId = 0");
        }

        /// <summary>
        /// 不加载产品分类列表
        /// 用于不需要产品的页面
        /// </summary>
        /// <param name="obj">无实际意义(可任意传值)</param>
        public MasterPageController(object obj)
        {
            GetCMS();
            if (LoginMember != null && !string.IsNullOrWhiteSpace(LoginMember.m_UserName))
            {
                ViewData["UserName"] = LoginMember.m_UserName;
                ViewData["ChartCount"] = GetChartCount();
            }
            else
            {
                ViewData["ChartCount"] = 0;
            }
        }

        /// <summary>
        /// 获取购物车商品数量
        /// </summary>
        public int GetChartCount()
        {
            int count = 0;
            BLL.ShoppingCartBase cart = new BLL.ShoppingCartBase();
            var list = cart.GetModelList(" sc_IsDel = 0 and m_ID = " + LoginMember.m_ID);
            if (list != null)
            {
                count = list.Sum(m => m.sc_pCount.Value);
            }
            return count;
        }

        # region 产品类型

        /// <summary>
        /// 加载产品类型
        /// </summary>
        /// <returns></returns>
        public string GetProductType()
        {
            StringBuilder strProType = new StringBuilder();
            var type1 = _productTypeBase.GetModelList("pt_ParentId = 0 and pt_IsDel = 0 and pt_StatusCode = 0");

            //一级菜单
            foreach (var t1 in type1)
            {
                //开始
                strProType.Append(string.Format(@"<li>
                                        <div class='cate-tag'>
                                            <strong><a href='{0}'>{1}</a></strong>
                                            <div class='listModel'>", "/ProList/ProList?ptype=" + t1.pt_ID, t1.pt_Name));
                var type2 = _productTypeBase.GetModelList(string.Format("pt_ParentId = {0} and pt_IsDel = 0 and pt_StatusCode = 0", t1.pt_ID));
                int i = 0;
                //二级菜单
                foreach (var t2 in type2)
                {
                    if (i % 2 == 0)
                    {
                        strProType.Append(string.Format(@"<p>"));
                    }
                    strProType.Append(string.Format(@"<a title='{2}' href='{0}'>{1}</a>", "/ProList/ProList?ptype=" + t2.pt_ID, CutString(t2.pt_Name, 6, "."), t2.pt_Name));

                    if (i % 2 == 1)
                    {
                        strProType.Append(string.Format(@"</p>"));
                    }
                    i++;
                }
                strProType.Append(@"</div>
                                    </div>
                                    <div class='list-item hide'>
								        <ul class='itemleft'>");
                //二级菜单
                foreach (var t2 in type2)
                {
                    strProType.Append(string.Format(@"<dl>
                                            <a  href='{0}'><dt>{1}</dt></a><dd>", "/ProList/ProList?ptype=" + t2.pt_ID, t2.pt_Name));
                    var type3 = _productTypeBase.GetModelList(string.Format("pt_ParentId = {0} and pt_IsDel = 0 and pt_StatusCode = 0", t2.pt_ID));
                    foreach (var t3 in type3)
                    {
                        strProType.Append(string.Format(@"<a href='{0}'>{1}</a>", "/ProList/ProList?ptype=" + t3.pt_ID, t3.pt_Name));
                    }
                    strProType.Append(string.Format(@"</dd></dl>
                                            <div class='clear'></div>"));
                }
                strProType.Append("</ul>");
                
//                //促销活动
//                strProType.Append(@"
//                                            <ul class='itemright'>
//                            		            <dl>
//										            <dt>促销活动</dt>
//									            </dl>
//									            <div class='ad-list mt10'>
//										            <a href='#'><img name='page_cnt_1' src='/images/img/brand_ad_01.jpg' width='210' height='100' /></a>
//										            <a href='#'><img name='page_cnt_1' _src='/images/img/brand_ad_01.jpg' width='210' height='100' /></a>
//										            <a href='#'><img name='page_cnt_1' _src='/images/img/brand_ad_01.jpg' width='210' height='100' /></a>
//									            </div>
//									            <dl>
//										            <dt>促销信息</dt>
//									            </dl>
//									            <div class='news-list'>
//										            <p><span class='red'>[杜康]</span><a href='#'>酒体窖香幽雅、陈香舒适,只需156元，值得一试的好酒</a></p>
//										            <p><span class='red'>[红星]</span><a href='#'>经典红星153元热销千瓶，敢于全网誓比价！</a></p>
//										            <p><span class='red'>[太白]</span><a href='#'>中国第一诗酒，全场满200减50</a></p>
//									            </div>
//								            </ul>
//                                ");

                strProType.Append("</div></li>");
                strProType.Append("<li></li>");
            }


            return strProType.ToString();
        }

        # endregion

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

        public bool GotoVipCenter()
        {
            if (LoginMember == null || string.IsNullOrWhiteSpace(LoginMember.m_UserName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 获取广告
        /// </summary>
        /// <param name="aPID">广告位主键</param>
        /// <param name="typeId">分类ID</param>
        public object GetAdertsFormServer(string viewName, int aPID, int? typeId = null)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("a_Status = 0 and a_Delete = 0 and a_PID = " + aPID);
            if (typeId != null)
            {
                strSql.Append(" and a_spare2 = " + typeId.Value);
            }
            ViewData[viewName] = _adert.GetModelList(strSql.ToString());
            return ViewData[viewName];
        }
    }
}