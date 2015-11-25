using System;
using System.Data;
using System.Collections.Generic;
using  Common;
using webs_YueyxShop.Model;
using webs_YueyxShop.DALFactory;
using webs_YueyxShop.IDAL;
using webs_YueyxShop.DAL;
namespace webs_YueyxShop.BLL
{
	/// <summary>
	/// 商品属性
	/// </summary>
	public partial class ProductAttributesBase
	{
		private readonly IProductAttributesBase dal=DataAccess.CreateProductAttributesBase();
		public ProductAttributesBase()
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
		public bool Exists(int pa_ID)
		{
			return dal.Exists(pa_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(webs_YueyxShop.Model.ProductAttributesBase model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(webs_YueyxShop.Model.ProductAttributesBase model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int pa_ID)
		{
			
			return dal.Delete(pa_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string pa_IDlist )
		{
			return dal.DeleteList(pa_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public webs_YueyxShop.Model.ProductAttributesBase GetModel(int pa_ID)
		{
			
			return dal.GetModel(pa_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public webs_YueyxShop.Model.ProductAttributesBase GetModelByCache(int pa_ID)
		{
			
			string CacheKey = "ProductAttributesBaseModel-" + pa_ID;
			object objModel =  Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(pa_ID);
					if (objModel != null)
					{
						int ModelCache =  Common.ConfigHelper.GetConfigInt("ModelCache");
						 Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (webs_YueyxShop.Model.ProductAttributesBase)objModel;
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
		public List<webs_YueyxShop.Model.ProductAttributesBase> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<webs_YueyxShop.Model.ProductAttributesBase> DataTableToList(DataTable dt)
		{
			List<webs_YueyxShop.Model.ProductAttributesBase> modelList = new List<webs_YueyxShop.Model.ProductAttributesBase>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				webs_YueyxShop.Model.ProductAttributesBase model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new webs_YueyxShop.Model.ProductAttributesBase();
					if(dt.Rows[n]["pa_ID"]!=null && dt.Rows[n]["pa_ID"].ToString()!="")
					{
						model.pa_ID=int.Parse(dt.Rows[n]["pa_ID"].ToString());
					}
					if(dt.Rows[n]["pa_Name"]!=null && dt.Rows[n]["pa_Name"].ToString()!="")
					{
					model.pa_Name=dt.Rows[n]["pa_Name"].ToString();
					}
					if(dt.Rows[n]["pa_Alias"]!=null && dt.Rows[n]["pa_Alias"].ToString()!="")
					{
					model.pa_Alias=dt.Rows[n]["pa_Alias"].ToString();
					}
					if(dt.Rows[n]["pa_Type"]!=null && dt.Rows[n]["pa_Type"].ToString()!="")
					{
						model.pa_Type=int.Parse(dt.Rows[n]["pa_Type"].ToString());
					}
					if(dt.Rows[n]["pa_Layer"]!=null && dt.Rows[n]["pa_Layer"].ToString()!="")
					{
						model.pa_Layer=int.Parse(dt.Rows[n]["pa_Layer"].ToString());
					}
					if(dt.Rows[n]["pa_Code"]!=null && dt.Rows[n]["pa_Code"].ToString()!="")
					{
					model.pa_Code=dt.Rows[n]["pa_Code"].ToString();
					}
					if(dt.Rows[n]["pa_Sort"]!=null && dt.Rows[n]["pa_Sort"].ToString()!="")
					{
						model.pa_Sort=int.Parse(dt.Rows[n]["pa_Sort"].ToString());
					}
					if(dt.Rows[n]["pa_SelectType"]!=null && dt.Rows[n]["pa_SelectType"].ToString()!="")
					{
						model.pa_SelectType=int.Parse(dt.Rows[n]["pa_SelectType"].ToString());
					}
					if(dt.Rows[n]["pa_StatusCode"]!=null && dt.Rows[n]["pa_StatusCode"].ToString()!="")
					{
						model.pa_StatusCode=int.Parse(dt.Rows[n]["pa_StatusCode"].ToString());
					}
					if(dt.Rows[n]["pa_CreatedOn"]!=null && dt.Rows[n]["pa_CreatedOn"].ToString()!="")
					{
						model.pa_CreatedOn=DateTime.Parse(dt.Rows[n]["pa_CreatedOn"].ToString());
					}
					if(dt.Rows[n]["pa_CreatedBy"]!=null && dt.Rows[n]["pa_CreatedBy"].ToString()!="")
					{
						model.pa_CreatedBy=new Guid(dt.Rows[n]["pa_CreatedBy"].ToString());
					}
					if(dt.Rows[n]["pa_IsDel"]!=null && dt.Rows[n]["pa_IsDel"].ToString()!="")
					{
						if((dt.Rows[n]["pa_IsDel"].ToString()=="1")||(dt.Rows[n]["pa_IsDel"].ToString().ToLower()=="true"))
						{
						model.pa_IsDel=true;
						}
						else
						{
							model.pa_IsDel=false;
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

        public string GetCode(string code, int layer)
        {
            return dal.GetCode(code, layer);
        }

        public int GetSort(string pid, int layer)
        {
            return dal.GetSort(pid, layer);
        }

        public bool UpdateList(Model.ProductAttributesBase pa)
        {
            return dal.UpdateList(pa);
        }
        public bool UpdateList2(int code, int id)
        {
            return dal.UpdateList2(code, id);
        }

        public DataSet GetListwithtype(string p)
        {
            DataSet ds = dal.GetListwithtype(p);
            return ds;
        }


        public DataSet GetModelListById(string p)
        {
            return dal.GetModelListById(p);
        }

        public List<Model.ProductAttributesBase> GetModelListByskuId(string p)
        {
            return dal.GetModelListByskuId(p);
        }

        public List<Model.ProductAttributesBase> GetModelListByPid(string p)
        {
            return dal.GetModelListByPid(p);
        }
    }
}

