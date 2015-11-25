using System;
using System.Data;
using System.Collections.Generic;
using Common;
using System.Linq;
using webs_YueyxShop.Model;
using webs_YueyxShop.DALFactory;
using webs_YueyxShop.IDAL;
using webs_YueyxShop.DAL;
namespace webs_YueyxShop.BLL
{
    /// <summary>
    /// 商品信息表
    /// </summary>
    public partial class ProductBase
    {
        private readonly IProductBase dal = DataAccess.CreateProductBase();
        public ProductBase()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int p_ID)
        {
            return dal.Exists(p_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(webs_YueyxShop.Model.ProductBase model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(webs_YueyxShop.Model.ProductBase model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int p_ID)
        {

            return dal.Delete(p_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string p_IDlist)
        {
            return dal.DeleteList(p_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public webs_YueyxShop.Model.ProductBase GetModel(int p_ID)
        {

            return dal.GetModel(p_ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public webs_YueyxShop.Model.ProductBase GetModelByCache(int p_ID)
        {

            string CacheKey = "ProductBaseModel-" + p_ID;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(p_ID);
                    if (objModel != null)
                    {
                        int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (webs_YueyxShop.Model.ProductBase)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<webs_YueyxShop.Model.ProductBase> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<webs_YueyxShop.Model.ProductBase> DataTableToList(DataTable dt)
        {
            List<webs_YueyxShop.Model.ProductBase> modelList = new List<webs_YueyxShop.Model.ProductBase>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                webs_YueyxShop.Model.ProductBase model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        public DataSet GetModelListById(string p)
        {
            return dal.GetModelListById(p);
        }

        public int GetSort()
        {
            return dal.GetSort();
        }
        //批量上架
        public bool UpdateList(string pid)
        {
            return dal.UpdateList(pid);
        }
        //批量下架
        public bool UpdateListx(string pid)
        {
            return dal.UpdateListx(pid);
        }

        //
        public List<Model.ProductBase> GetpInfoByTypeId(int cid)
        {
            return dal.GetpInfoByTypeId(cid);
        }

        /// <summary>
        /// 商品详细信息(包括品牌和分类信息)
        /// </summary>
        public DataTable GetProductDetail(string strWhere)
        {
            return dal.GetProductDetail(strWhere);
        }

        /// <summary>
        /// 商品详细信息(包括品牌、分类、默认SKU和SKU属性等信息)
        /// </summary>
        public DataTable GetProductPropertyDetail(string strWhere)
        {
            DataTable dt = dal.GetProductPropertyDetail(strWhere);

            return GetGroupPurchasePrice(dt);
        }

        /// <summary>
        /// 团购价格替换原价格
        /// </summary>
        public DataTable GetGroupPurchasePrice(DataTable dt)
        {
            GroupPurchaseBase gpBase = new GroupPurchaseBase();
            foreach (DataRow row in dt.Rows)
            {
                string sql = " sku_ID = " + row["sku_ID"] + " and gp_IsDel = 0 and gp_StatusCode = 0 and gp_StartTime <= '" + DateTime.Now + "' and gp_EndTime >= '" + DateTime.Now + "'";
                var gp = gpBase.GetModelList(sql).FirstOrDefault();
                if (gp != null)
                {
                    //团购取团购价格
                    row["sku_Price"] = gp.gp_pPric;
                }
            }
            return dt;
        }

        #endregion  ExtensionMethod



        public List<Model.ProductBase> GetpInfoByRecommendTypeId(int id)
        {
            return dal.GetpInfoByRecommendTypeId(id);
        }
    }
}