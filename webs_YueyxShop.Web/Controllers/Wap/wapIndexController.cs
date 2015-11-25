using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Text;

namespace webs_YueyxShop.Web.Controllers.Wap
{
    public class wapIndexController : BaseWapController
    {
        BLL.ProductTypeBase _proType = new BLL.ProductTypeBase();
        BLL.Adert _adert = new BLL.Adert();

        public ActionResult Index()
        {
            GetAdert();
            GetRecommend();
            GetGroupPurchase();
            return View();
        }

        # region 广告管理

        /// <summary>
        /// 轮播广告
        /// </summary>
        /// <returns></returns>
        public void GetAdert()
        {
            GetAdertsFormServer("AdertTop", 26);//首页顶部轮播
            GetAdertsFormServer("wapad1", 29);//首页专区下面广告
            GetAdertsFormServer("wapad2", 30);//首页专区下面广告
            GetAdertsFormServer("wapad3", 31);//首页专区下面广告
            GetAdertsFormServer("wapad4", 32);//首页专区下面广告
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
            GetProductRecommend(8, "手机专享");//超值推荐
        }

        private object GetProductRecommend(int id, string viewName)
        {
            BLL.ProductRecommendTypeBase proRecType = new BLL.ProductRecommendTypeBase();
            var model = proRecType.GetModel(id);
            if (model != null)
            {
                ViewData[viewName] = model.prt_Name;
                ViewData[viewName + "list"] = GetProductsList(id);
            }
            else
            { 
                ViewData[viewName] =null;
                ViewData[viewName + "list"] = null;
            }
            return ViewData[viewName];
        }

        private object GetProductsList(int id)
        {
            BLL.ProductRecommendDetail proRecDetail = new BLL.ProductRecommendDetail();
            var dt = proRecDetail.GetRecommendProductDefaultSKUList(" and prt_ID = " + id + " and prd_IsDelete = 0 and p_Statuscode=0 and p_SellStatus=1 and pi_IsDel=0");
            //dt.Columns.Add("pi_Url", typeof(System.String));
            //BLL.ProductImgBase _proImg = new BLL.ProductImgBase();
            //foreach (DataRow row in dt.Rows)
            //{
            //    var model = _proImg.GetModelList("sku_ID = " + row["sku_ID"] + "and pi_Type = 1 and pi_isDel = 0").FirstOrDefault();
            //    if (model != null)
            //    {
            //        row["pi_Url"] = model.pi_Url;
            //    }
            //}
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
            var list = vm_GBDetails.GetModelList("gp_IsDel = 0 and gp_StatusCode = 0 order by gp_EndTime");
            ViewData["GroupPurchase"] = list;
            return ViewData["GroupPurchase"];
        }

        # endregion



        # region 商品分类分布页

        /// <summary>
        /// 商品分类分布页
        /// </summary>
        /// <param name="ptID">分类ID</param>
        /// <param name="ptName"></param>
        /// <returns></returns>
        public ActionResult productType()
        {
            GetProductTypes("ProductType", 0);
            ViewBag.producttype = ViewData["ProductType"];
            List<Model.ProductTypeBase> lvlist = new BLL.ProductTypeBase().GetModelList(" pt_IsDel=0 and pt_StatusCode=0");
            return View(lvlist.ToList());
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