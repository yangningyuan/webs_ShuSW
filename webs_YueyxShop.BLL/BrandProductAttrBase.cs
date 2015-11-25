using System;
using System.Data;
using System.Collections.Generic;
using  Common;
using webs_YueyxShop.Model;
using webs_YueyxShop.DALFactory;
using webs_YueyxShop.IDAL;
namespace webs_YueyxShop.BLL
{
	/// <summary>
	/// 品牌商品属性明细
	/// </summary>
	public partial class BrandProductAttrBase
	{
		private readonly IBrandProductAttrBase dal=DataAccess.CreateBrandProductAttrBase();
		public BrandProductAttrBase()
		{}
		#region  Method

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
		public bool Exists(int bpa_ID)
		{
			return dal.Exists(bpa_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(webs_YueyxShop.Model.BrandProductAttrBase model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(webs_YueyxShop.Model.BrandProductAttrBase model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int bpa_ID)
		{
			
			return dal.Delete(bpa_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string bpa_IDlist )
		{
			return dal.DeleteList(bpa_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public webs_YueyxShop.Model.BrandProductAttrBase GetModel(int bpa_ID)
		{
			
			return dal.GetModel(bpa_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public webs_YueyxShop.Model.BrandProductAttrBase GetModelByCache(int bpa_ID)
		{
			
			string CacheKey = "BrandProductAttrBaseModel-" + bpa_ID;
			object objModel =  Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(bpa_ID);
					if (objModel != null)
					{
						int ModelCache =  Common.ConfigHelper.GetConfigInt("ModelCache");
						 Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (webs_YueyxShop.Model.BrandProductAttrBase)objModel;
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
		public List<webs_YueyxShop.Model.BrandProductAttrBase> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<webs_YueyxShop.Model.BrandProductAttrBase> DataTableToList(DataTable dt)
		{
			List<webs_YueyxShop.Model.BrandProductAttrBase> modelList = new List<webs_YueyxShop.Model.BrandProductAttrBase>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				webs_YueyxShop.Model.BrandProductAttrBase model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new webs_YueyxShop.Model.BrandProductAttrBase();
					if(dt.Rows[n]["bpa_ID"]!=null && dt.Rows[n]["bpa_ID"].ToString()!="")
					{
						model.bpa_ID=int.Parse(dt.Rows[n]["bpa_ID"].ToString());
					}
					if(dt.Rows[n]["pa_ID"]!=null && dt.Rows[n]["pa_ID"].ToString()!="")
					{
						model.pa_ID=int.Parse(dt.Rows[n]["pa_ID"].ToString());
					}
					if(dt.Rows[n]["b_ID"]!=null && dt.Rows[n]["b_ID"].ToString()!="")
					{
						model.b_ID=int.Parse(dt.Rows[n]["b_ID"].ToString());
					}
					modelList.Add(model);
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

		#endregion  Method
	}
}

