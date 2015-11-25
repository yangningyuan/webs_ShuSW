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
	/// 品牌管理
	/// </summary>
	public partial class BrandBase
	{
		private readonly IBrandBase dal=DataAccess.CreateBrandBase();
		public BrandBase()
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
		public bool Exists(int b_ID)
		{
			return dal.Exists(b_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(webs_YueyxShop.Model.BrandBase model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(webs_YueyxShop.Model.BrandBase model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int b_ID)
		{
			
			return dal.Delete(b_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string b_IDlist )
		{
			return dal.DeleteList(b_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public webs_YueyxShop.Model.BrandBase GetModel(int b_ID)
		{
			
			return dal.GetModel(b_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public webs_YueyxShop.Model.BrandBase GetModelByCache(int b_ID)
		{
			
			string CacheKey = "BrandBaseModel-" + b_ID;
			object objModel = Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(b_ID);
					if (objModel != null)
					{
						int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
						Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (webs_YueyxShop.Model.BrandBase)objModel;
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
		public List<webs_YueyxShop.Model.BrandBase> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<webs_YueyxShop.Model.BrandBase> DataTableToList(DataTable dt)
		{
			List<webs_YueyxShop.Model.BrandBase> modelList = new List<webs_YueyxShop.Model.BrandBase>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				webs_YueyxShop.Model.BrandBase model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new webs_YueyxShop.Model.BrandBase();
					if(dt.Rows[n]["b_ID"]!=null && dt.Rows[n]["b_ID"].ToString()!="")
					{
						model.b_ID=int.Parse(dt.Rows[n]["b_ID"].ToString());
					}
					if(dt.Rows[n]["b_Name"]!=null && dt.Rows[n]["b_Name"].ToString()!="")
					{
					model.b_Name=dt.Rows[n]["b_Name"].ToString();
					}
					if(dt.Rows[n]["b_Key"]!=null && dt.Rows[n]["b_Key"].ToString()!="")
					{
					model.b_Key=dt.Rows[n]["b_Key"].ToString();
					}
					if(dt.Rows[n]["b_LogoUrl"]!=null && dt.Rows[n]["b_LogoUrl"].ToString()!="")
					{
					model.b_LogoUrl=dt.Rows[n]["b_LogoUrl"].ToString();
					}
					if(dt.Rows[n]["b_SiteUrl"]!=null && dt.Rows[n]["b_SiteUrl"].ToString()!="")
					{
					model.b_SiteUrl=dt.Rows[n]["b_SiteUrl"].ToString();
					}
					if(dt.Rows[n]["b_Sort"]!=null && dt.Rows[n]["b_Sort"].ToString()!="")
					{
						model.b_Sort=int.Parse(dt.Rows[n]["b_Sort"].ToString());
					}
					if(dt.Rows[n]["b_CreatedOn"]!=null && dt.Rows[n]["b_CreatedOn"].ToString()!="")
					{
						model.b_CreatedOn=DateTime.Parse(dt.Rows[n]["b_CreatedOn"].ToString());
					}
					if(dt.Rows[n]["b_CreatedBy"]!=null && dt.Rows[n]["b_CreatedBy"].ToString()!="")
					{
						model.b_CreatedBy=new Guid(dt.Rows[n]["b_CreatedBy"].ToString());
					}
					if(dt.Rows[n]["b_StatusCode"]!=null && dt.Rows[n]["b_StatusCode"].ToString()!="")
					{
						model.b_StatusCode=int.Parse(dt.Rows[n]["b_StatusCode"].ToString());
					}
					if(dt.Rows[n]["b_IsDel"]!=null && dt.Rows[n]["b_IsDel"].ToString()!="")
					{
						if((dt.Rows[n]["b_IsDel"].ToString()=="1")||(dt.Rows[n]["b_IsDel"].ToString().ToLower()=="true"))
						{
						model.b_IsDel=true;
						}
						else
						{
							model.b_IsDel=false;
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

        public List<Model.BrandBase> GetbrandByTypeId(int typeid)
        {
            return dal.GetbrandByTypeId(typeid);
        }
    }
}

