using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Text;
using Common;

namespace webs_YueyxShop.Web.Controllers.YueyXing
{
    public class IndexController : MasterPageController
    {
        BLL.ProductTypeBase _proType = new BLL.ProductTypeBase();

        public ActionResult Index()
        {
            GetAdert();
            GetRecommend();
            GetGroupPurchase();
            GetNewAd();
            GetBrandBase();
            GetProductTypes("ProductType", 0);
            return View();
        }

        # region 广告管理

        /// <summary>
        /// 轮播广告
        /// </summary>
        /// <returns></returns>
        public void GetAdert()
        {
            GetAdertsFormServer("AdTuanG", 22);//首页疯狂团购固定广告 
            GetAdertsFormServer("Adtgban1", 23);//首页右边广告1
            GetAdertsFormServer("Adtgban2", 24);//首页右边广告2
            GetAdertsFormServer("Adbt", 25);//首页专区下面广告
            GetAdertsFormServer("AdertTop", 26);//首页顶部轮播
        }

        # endregion

        # region 推荐类型

        /// <summary>
        /// 获取推荐类型
        /// </summary>
        public void GetRecommend()
        {
            GetProductRecommend(1, "热卖专区");//热卖专区
            GetProductRecommend(3, "新品专区");//新品专区
            GetProductRecommend(5, "特价专区");//特价专区
            GetProductRecommend(7, "超值推荐");//超值推荐
        }

        private object GetProductRecommend(int id, string viewName, string ptIds = "")
        {
            BLL.ProductRecommendTypeBase proRecType = new BLL.ProductRecommendTypeBase();
            var model = proRecType.GetModel(id);
            ViewData[viewName] = model.prt_Name;
            ViewData[viewName + "list"] = GetProductsList(id, ptIds);
            return ViewData[viewName];
        }

        private object GetProductsList(int id, string ptIds = "")
        {
            BLL.ProductRecommendDetail proRecDetail = new BLL.ProductRecommendDetail();
            string sql = " and p_SellStatus=1 and p_IsDel=0 and p_StatusCode=0 and sku_IsDel=0 and sku_StatusCode=0 and prt_ID = " + id + " and prd_IsDelete = 0 and pi_isDel = 0";
            if (!string.IsNullOrWhiteSpace(ptIds))
            {
                sql += " and pt_ID in (" + ptIds + ") ";
            }
            var dt = proRecDetail.GetRecommendProductDefaultSKUList(sql);
            if (dt == null || dt.Rows.Count == 0)
            {
                dt = null;
            }
            return dt;
        }

        /// <summary>
        /// 团购
        /// </summary>
        /// <returns></returns>
        public object GetGroupPurchase()
        {
            BLL.GroupPurchaseBase groupPurchase = new BLL.GroupPurchaseBase();
            BLL.vm_GBDetails vm_GBDetails = new BLL.vm_GBDetails();
                DateTime thistime = DateTime.Now;
                var list = vm_GBDetails.GetModelList("p_IsDel=0 and p_StatusCode=0 and gp_IsDel=0 and gp_pCount-gp_SaleCount>0 and gp_StatusCode=0 and p_SellStatus=1 and gp_endtime>'" + thistime + "' order by gp_EndTime");
            ViewData["GroupPurchase"] = list;
            return ViewData["GroupPurchase"];
        }

        # endregion

        # region 右侧数据

        private object GetNewsBase(string mID)
        {
            BLL.NewsBase newsBase = new BLL.NewsBase();
            var list = newsBase.GetModelList("m_ID = '" + mID + "' and n_IsTop = 1 and n_IsDel = 0 and n_StatusCode = 0 order by n_Sort");

            return list;
        }

        /// <summary>
        /// 最新公告
        /// </summary>
        /// <returns></returns>
        public object GetNewAd()
        {
            ViewData["NewAd"] = GetNewsBase("983c6027-3bb7-4be2-a30a-f7553eb390a2");
            return ViewData["NewAd"];
        }

        # endregion

        # region 品牌推荐

        private readonly int pCount = 5;

        public void GetBrandBase()
        {
            BLL.BrandBase brandBase = new BLL.BrandBase();
            var list = brandBase.GetModelList("b_IsDel = 0 and b_StatusCode = 0");
            ViewData["BarndBaseLogo"] = GetBrandBaseLogoString(list);//品牌logo
            GetBrandBaseAdert();
            //ViewData["BrandBase"] = GetBrandBaseString(list);
            //ViewData["BrandBaseSpan"] = GetBrandBaseSpanString(list.Count);
        }

        /// <summary>
        /// 品牌推广
        /// </summary>
        /// <returns></returns>
        public object GetBrandBaseAdert()
        {
            var brandBig = GetAdertsFormServer("BrandBase", 33) as List<Model.Adert>;
            var brandsmall = GetAdertsFormServer("BrandBaseSpan", 35) as List<Model.Adert>;

            if (!brandBig.Any() && !brandsmall.Any())
            {//都没有数据
                ViewData["BrandBase"] = "";
                ViewData["BrandBaseSpan"] = "";
            }
            else
            {
                int bigCount = brandBig.Count;
                int smallCount = brandsmall.Count;
                int bigPage = bigCount / 3 + (bigCount % 3 == 0 ? 0 : 1);
                int smallPage = smallCount / 4 + (bigCount % 4 == 0 ? 0 : 1);
                int page = bigPage > smallPage ? bigPage : smallPage;
                Model.Adert adertBig = new Model.Adert ();
                adertBig.a_Link = "/Index/Index";
                adertBig.a_Image = "/images/brand/brand_01.jpg";
                while (bigCount / 3 != page)
                {
                    brandBig.Add(adertBig);
                    bigCount++;
                }
                Model.Adert adertSmall = new Model.Adert();
                adertSmall.a_Link = "/Index/Index";
                adertSmall.a_Image = "/images/brand/brand_03.jpg";
                while (smallCount / 4 != page)
                {
                    brandsmall.Add(adertSmall);
                    smallCount++;
                }
                //广告
                StringBuilder brandStr = new StringBuilder();
                StringBuilder brandSpan = new StringBuilder();
                //组合
                for (int i = 0; i < page; i++)
                {
                    brandStr.AppendFormat("<li>");
                    brandStr.AppendFormat("<a href='{0}' target='_blank' class='brand-pos1'><img name='page_cnt_1' src='{1}' /></a>", brandBig[i * 3 + 0].a_Link, brandBig[i * 3 + 0].a_Image);
                    brandStr.AppendFormat("<a href='{0}' target='_blank' class='brand-pos2'><img name='page_cnt_1' src='{1}' /></a>", brandsmall[i * 4 + 0].a_Link, brandsmall[i * 4 + 0].a_Image);
                    brandStr.AppendFormat("<a href='{0}' target='_blank' class='brand-pos3'><img name='page_cnt_1' src='{1}' /></a>", brandsmall[i * 4 + 1].a_Link, brandsmall[i * 4 + 1].a_Image);
                    brandStr.AppendFormat("<a href='{0}' target='_blank' class='brand-pos4'><img name='page_cnt_1' src='{1}' /></a>", brandBig[i * 3 + 1].a_Link, brandBig[i * 3 + 1].a_Image);
                    brandStr.AppendFormat("<a href='{0}' target='_blank' class='brand-pos5'><img name='page_cnt_1' src='{1}' /></a>", brandsmall[i * 4 + 2].a_Link, brandsmall[i * 4 + 2].a_Image);
                    brandStr.AppendFormat("<a href='{0}' target='_blank' class='brand-pos6'><img name='page_cnt_1' src='{1}' /></a>", brandsmall[i * 4 + 3].a_Link, brandsmall[i * 4 + 3].a_Image);
                    brandStr.AppendFormat("<a href='{0}' target='_blank' class='brand-pos7'><img name='page_cnt_1' src='{1}' /></a>", brandBig[i * 3 + 2].a_Link, brandBig[i * 3 + 2].a_Image);
                    brandStr.AppendFormat("</li>");
                    brandSpan.AppendFormat("<span>{0}</span>", i + 1);
                }
                ViewData["BrandBase"] = brandStr.ToString();
                ViewData["BrandBaseSpan"] = brandSpan.ToString();
            }

            return ViewData["BrandBase"];
        }

        /// <summary>
        /// 下标
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public string GetBrandBaseSpanString(int c)
        {
            StringBuilder strSql = new StringBuilder();
            int count = c / pCount + (c % 7 == 0 ? 0 : 1);
            for (int i = 1; i <= count; i++)
            {
                strSql.Append(string.Format("<span>{0}</span>", i));
            }

            return strSql.ToString();
        }

        /// <summary>
        /// 品牌图片
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string GetBrandBaseString(List<Model.BrandBase> list)
        {
            StringBuilder strSql = new StringBuilder();
            int i;
            for (i = 0; i < list.Count; i++)
            {
                if (i % pCount == 0)//li开始标签
                {
                    strSql.Append("<li>");
                }

                strSql.Append(string.Format("<a href='{0}' target='_blank' class='brand-pos{1}'><img style=\"width:228xp;height:230px;\" name='page_cnt_1' src='{2}' /></a>", list[i].b_SiteUrl, i % pCount + 1, list[i].b_LogoUrl));

                if (i % pCount == pCount - 1)//li结束标签
                {
                    strSql.Append("</li>");
                }
            }
            if (i % pCount != pCount - 1)
            {
                strSql.Append("</li>");
            }
            return strSql.ToString();
        }

        /// <summary>
        /// 品牌Logo
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string GetBrandBaseLogoString(List<Model.BrandBase> list)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (var model in list)
            {
                if (!string.IsNullOrWhiteSpace(model.b_LogoUrl))
                {
                    strSql.Append(string.Format("<li><a target='_blank' href='{0}'><img style=\"width:90xp;height:28px;\" name='page_cnt_1' src='{1}' /></a></li>", model.b_SiteUrl, model.b_LogoUrl));
                }
            }
            return strSql.ToString();
        }

        # endregion

        # region 商品分类分布页

        /// <summary>
        /// 商品分类分布页
        /// </summary>
        /// <param name="ptID">分类ID</param>
        /// <param name="ptName"></param>
        /// <returns></returns>
        public ActionResult ProductType(int ptID, string ptName)
        {
            ViewData["typeName"] = ptName;
            ViewData["typeID"] = ptID;
            GetProductTypes("subType", ptID);
            //ViewData["productInfoList"] = GetpInfoByTypeId(ptID);
            string ids = GetAllsubTypeIds(ptID);
            //商品列表
            ViewData["productInfoList"] = GetProductPropertyDetail(string.Format(" and pt_ID in ({0}) and p_IsDel=0 and p_StatusCode=0 and p_SellStatus = 1 and pi_isDel = 0 and pi_StatusCode = 0 and pi_Type = 1 and sku_StatusCode = 0 and sku_IsDel = 0", ids));
            //热门推荐
            GetProductRecommend(7, "热门推荐", ids);
            //最新优惠
            GetProductRecommend(5, "最新优惠", ids);
            GetAdertsFormServer("AdBanner", 19, ptID);//分类顶部广告
            GetAdertsFormServer("AdBottom", 20, ptID);//分类底部广告
            return View();
        }

        /// <summary>
        /// 获取分类下的所有子分类Id
        /// </summary>
        public string GetAllsubTypeIds(int ptID)
        {
            string ids = ptID.ToString();
            var list = _proType.GetModelList("pt_IsDel = 0 and pt_StatusCode = 0 and pt_ParentId = " + ptID);
            if (list != null)
            {
                foreach (var model in list)
                {
                    ids += "," + GetAllsubTypeIds(model.pt_ID);
                }
            }

            return ids;
        }

        public void GetProductTypes(string viewName, int prID)
        {
            ViewData[viewName] = _proType.GetModelList(" pt_ParentId = " + prID + " and pt_IsDel = 0 and pt_StatusCode = 0 order by pt_Sort");
        }

        public List<Model.ProductBase> GetpInfoByTypeId(int ptID)
        {
            BLL.ProductBase productBase = new BLL.ProductBase();
            var list = productBase.GetpInfoByTypeId(ptID);
            return list;
        }

        public DataTable GetProductPropertyDetail(string strWhere = "")
        {
            BLL.ProductBase productBase = new BLL.ProductBase();

            return productBase.GetProductPropertyDetail(strWhere);
        }

        /// <summary>
        /// 获取广告
        /// </summary>
        /// <param name="viewName">view名称</param>
        /// <param name="ptID">分类ID</param>
        /// <param name="isBottom">是否底部</param>
        public void GetProductTypeAds(string viewName, int ptID, bool isBottom)
        {
            BLL.AdertPositionBase adp = new BLL.AdertPositionBase();
            string sql = string.Empty;
            if (isBottom)
            {
                sql = "p_Status = 0 and p_Delete = 0 and p_producttype = " + ptID + "and p_showposition = 1";
            }
            else
            {
                sql = "p_Status = 0 and p_Delete = 0 and p_producttype = " + ptID + "and p_showposition = 0";
            }

            var model = adp.GetModelList(sql).FirstOrDefault();
            if (model != null)
            {
                var list = new BLL.Adert().GetModelList(" a_Status = 0 and a_Delete = 0 and a_PID = " + model.p_ID);
                ViewData[viewName] = list;
            }
        }

        # endregion
    }
}