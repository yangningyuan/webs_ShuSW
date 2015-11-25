/**  版本信息模板在安装目录下，可自行修改。
* ShoppingCartBase.cs
*
* 功 能： N/A
* 类 名： ShoppingCartBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/22 16:19:25   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Common;
using System.Linq;
using webs_YueyxShop.Model;
using webs_YueyxShop.DALFactory;
using webs_YueyxShop.IDAL;
namespace webs_YueyxShop.BLL
{
	/// <summary>
	/// ShoppingCartBase
	/// </summary>
	public partial class ShoppingCartBase
	{
		private readonly IShoppingCartBase dal=DataAccess.CreateShoppingCartBase();
		public ShoppingCartBase()
		{}
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
		public bool Exists(int sc_ID)
		{
			return dal.Exists(sc_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(webs_YueyxShop.Model.ShoppingCartBase model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(webs_YueyxShop.Model.ShoppingCartBase model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int sc_ID)
		{
			
			return dal.Delete(sc_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string sc_IDlist )
		{
			return dal.DeleteList(sc_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public webs_YueyxShop.Model.ShoppingCartBase GetModel(int sc_ID)
		{
			
			return dal.GetModel(sc_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public webs_YueyxShop.Model.ShoppingCartBase GetModelByCache(int sc_ID)
		{
			
			string CacheKey = "ShoppingCartBaseModel-" + sc_ID;
			object objModel = Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(sc_ID);
					if (objModel != null)
					{
						int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
						Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (webs_YueyxShop.Model.ShoppingCartBase)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<webs_YueyxShop.Model.ShoppingCartBase> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<webs_YueyxShop.Model.ShoppingCartBase> DataTableToList(DataTable dt)
		{
			List<webs_YueyxShop.Model.ShoppingCartBase> modelList = new List<webs_YueyxShop.Model.ShoppingCartBase>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				webs_YueyxShop.Model.ShoppingCartBase model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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

        /// <summary>
        /// 更新数据
        /// </summary>
        public bool UpdateCount(int mid, int id, int count)
        {
            bool result = false;
            var chart = GetModelList(string.Format(" sku_ID = {0} and m_ID = {1} and sc_Status = 0 and sc_IsDel = 0", id, mid)).FirstOrDefault();
            if (chart != null)
            {
                chart.sc_pCount = count;
                result = dal.Update(chart);
            }
            return result;
        }

        /// <summary>
        /// 修改状态(删除和状态)
        /// </summary>
        /// <param name="isDelete">是否删除</param>
        /// <param name="mID">会员ID</param>
        /// <param name="ids">产品Id集合</param>
        public bool ChangeStatus(bool isDelete, int mID, string ids)
        {
            return dal.ChangeStatus(isDelete, mID, ids);
        }

		#endregion  ExtensionMethod
	}
}