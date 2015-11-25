using System;
using System.Data;
using System.Collections.Generic;
using Common;
using webs_YueyxShop.Model;
using webs_YueyxShop.DALFactory;
using webs_YueyxShop.IDAL;
namespace webs_YueyxShop.BLL
{
	/// <summary>
	/// CarriageTempleteBase
	/// </summary>
	public partial class CarriageTempleteBase
	{
		private readonly ICarriageTempleteBase dal=DataAccess.CreateCarriageTempleteBase();
		public CarriageTempleteBase()
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
		public bool Exists(int ct_ID)
		{
			return dal.Exists(ct_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(webs_YueyxShop.Model.CarriageTempleteBase model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(webs_YueyxShop.Model.CarriageTempleteBase model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ct_ID)
		{
			
			return dal.Delete(ct_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ct_IDlist )
		{
			return dal.DeleteList(ct_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public webs_YueyxShop.Model.CarriageTempleteBase GetModel(int ct_ID)
		{
			
			return dal.GetModel(ct_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public webs_YueyxShop.Model.CarriageTempleteBase GetModelByCache(int ct_ID)
		{
			
			string CacheKey = "CarriageTempleteBaseModel-" + ct_ID;
			object objModel =Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ct_ID);
					if (objModel != null)
					{
						int ModelCache =Common.ConfigHelper.GetConfigInt("ModelCache");
						Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (webs_YueyxShop.Model.CarriageTempleteBase)objModel;
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
		public List<webs_YueyxShop.Model.CarriageTempleteBase> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<webs_YueyxShop.Model.CarriageTempleteBase> DataTableToList(DataTable dt)
		{
			List<webs_YueyxShop.Model.CarriageTempleteBase> modelList = new List<webs_YueyxShop.Model.CarriageTempleteBase>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				webs_YueyxShop.Model.CarriageTempleteBase model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new webs_YueyxShop.Model.CarriageTempleteBase();
					if(dt.Rows[n]["ct_ID"]!=null && dt.Rows[n]["ct_ID"].ToString()!="")
					{
						model.ct_ID=int.Parse(dt.Rows[n]["ct_ID"].ToString());
					}
					if(dt.Rows[n]["ct_Name"]!=null && dt.Rows[n]["ct_Name"].ToString()!="")
					{
					model.ct_Name=dt.Rows[n]["ct_Name"].ToString();
					}
					if(dt.Rows[n]["ct_ValuationType"]!=null && dt.Rows[n]["ct_ValuationType"].ToString()!="")
					{
						model.ct_ValuationType=int.Parse(dt.Rows[n]["ct_ValuationType"].ToString());
					}
					if(dt.Rows[n]["ct_StatusCode"]!=null && dt.Rows[n]["ct_StatusCode"].ToString()!="")
					{
						model.ct_StatusCode=int.Parse(dt.Rows[n]["ct_StatusCode"].ToString());
					}
					if(dt.Rows[n]["ct_IsDel"]!=null && dt.Rows[n]["ct_IsDel"].ToString()!="")
					{
						if((dt.Rows[n]["ct_IsDel"].ToString()=="1")||(dt.Rows[n]["ct_IsDel"].ToString().ToLower()=="true"))
						{
						model.ct_IsDel=true;
						}
						else
						{
							model.ct_IsDel=false;
						}
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

