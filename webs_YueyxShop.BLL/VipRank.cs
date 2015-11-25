using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using webs_YueyxShop.DALFactory;
using webs_YueyxShop.IDAL;
using System.Data;
namespace webs_YueyxShop.BLL
{
    /// <summary>
    /// VipRank
    /// </summary>
    public partial class VipRank
    {
        private readonly IVipRank dal = DataAccess.CreateVipRank();
        public VipRank()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int r_ID)
        {
            return dal.Exists(r_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.VipRank model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.VipRank model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int r_ID)
        {

            return dal.Delete(r_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string r_IDlist)
        {
            return dal.DeleteList(r_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.VipRank GetModel(int r_ID)
        {

            return dal.GetModel(r_ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.VipRank GetModelByCache(int r_ID)
        {

            string CacheKey = "VipRankModel-" + r_ID;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(r_ID);
                    if (objModel != null)
                    {
                        int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Model.VipRank)objModel;
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
        public List<Model.VipRank> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.VipRank> DataTableToList(DataTable dt)
        {
            List<Model.VipRank> modelList = new List<Model.VipRank>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.VipRank model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.VipRank();
                    if (dt.Rows[n]["r_ID"] != null && dt.Rows[n]["r_ID"].ToString() != "")
                    {
                        model.r_ID = int.Parse(dt.Rows[n]["r_ID"].ToString());
                    }
                    if (dt.Rows[n]["r_Name"] != null && dt.Rows[n]["r_Name"].ToString() != "")
                    {
                        model.r_Name = dt.Rows[n]["r_Name"].ToString();
                    }
                    if (dt.Rows[n]["r_ZheK"] != null && dt.Rows[n]["r_ZheK"].ToString() != "")
                    {
                        model.r_ZheK =  decimal.Parse(dt.Rows[n]["r_ZheK"].ToString());
                    }
                    if (dt.Rows[n]["r_Score"] != null && dt.Rows[n]["r_Score"].ToString() != "")
                    {
                        model.r_Score = int.Parse(dt.Rows[n]["r_Score"].ToString());
                    }
                    if (dt.Rows[n]["r_Status"] != null && dt.Rows[n]["r_Status"].ToString() != "")
                    {
                        model.r_Status = int.Parse(dt.Rows[n]["r_Status"].ToString());
                    }
                    if (dt.Rows[n]["r_Rank"] != null && dt.Rows[n]["r_Rank"].ToString() != "")
                    {
                        model.r_Rank = int.Parse(dt.Rows[n]["r_Rank"].ToString());
                    }
                    if (dt.Rows[n]["r_UpperScore"] != null && dt.Rows[n]["r_UpperScore"].ToString() != "")
                    {
                        model.r_UpperScore = int.Parse(dt.Rows[n]["r_UpperScore"].ToString());
                    }
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

        #endregion  ExtensionMethod
    }
}
