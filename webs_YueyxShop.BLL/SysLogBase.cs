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
	/// 系统日志
	/// </summary>
	public partial class SysLogBase
	{
		private readonly ISysLogBase dal=DataAccess.CreateSysLogBase();
		public SysLogBase()
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
		public bool Exists(int sl_ID)
		{
			return dal.Exists(sl_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(webs_YueyxShop.Model.SysLogBase model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(webs_YueyxShop.Model.SysLogBase model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int sl_ID)
		{
			
			return dal.Delete(sl_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string sl_IDlist )
		{
			return dal.DeleteList(sl_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public webs_YueyxShop.Model.SysLogBase GetModel(int sl_ID)
		{
			
			return dal.GetModel(sl_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public webs_YueyxShop.Model.SysLogBase GetModelByCache(int sl_ID)
		{
			
			string CacheKey = "SysLogBaseModel-" + sl_ID;
			object objModel =  Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(sl_ID);
					if (objModel != null)
					{
						int ModelCache =  Common.ConfigHelper.GetConfigInt("ModelCache");
						 Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (webs_YueyxShop.Model.SysLogBase)objModel;
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
		public List<webs_YueyxShop.Model.SysLogBase> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<webs_YueyxShop.Model.SysLogBase> DataTableToList(DataTable dt)
		{
			List<webs_YueyxShop.Model.SysLogBase> modelList = new List<webs_YueyxShop.Model.SysLogBase>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				webs_YueyxShop.Model.SysLogBase model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new webs_YueyxShop.Model.SysLogBase();
					if(dt.Rows[n]["sl_ID"]!=null && dt.Rows[n]["sl_ID"].ToString()!="")
					{
						model.sl_ID=int.Parse(dt.Rows[n]["sl_ID"].ToString());
					}
					if(dt.Rows[n]["sl_LeiX"]!=null && dt.Rows[n]["sl_LeiX"].ToString()!="")
					{
						model.sl_LeiX=int.Parse(dt.Rows[n]["sl_LeiX"].ToString());
					}
					if(dt.Rows[n]["sl_ShiJ"]!=null && dt.Rows[n]["sl_ShiJ"].ToString()!="")
					{
						model.sl_ShiJ=DateTime.Parse(dt.Rows[n]["sl_ShiJ"].ToString());
					}
					if(dt.Rows[n]["sl_DiZh"]!=null && dt.Rows[n]["sl_DiZh"].ToString()!="")
					{
					model.sl_DiZh=dt.Rows[n]["sl_DiZh"].ToString();
					}
					if(dt.Rows[n]["sl_MiaoSh"]!=null && dt.Rows[n]["sl_MiaoSh"].ToString()!="")
					{
					model.sl_MiaoSh=dt.Rows[n]["sl_MiaoSh"].ToString();
					}
					if(dt.Rows[n]["sl_LeiX_CaoZ"]!=null && dt.Rows[n]["sl_LeiX_CaoZ"].ToString()!="")
					{
					model.sl_LeiX_CaoZ=dt.Rows[n]["sl_LeiX_CaoZ"].ToString();
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

