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
	/// 商品分类信息
	/// </summary>
	public partial class ProductTypeBase
	{
		private readonly IProductTypeBase dal=new DAL.ProductTypeBase();
		public ProductTypeBase()
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
		public bool Exists(int pt_ID)
		{
			return dal.Exists(pt_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(webs_YueyxShop.Model.ProductTypeBase model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(webs_YueyxShop.Model.ProductTypeBase model)
		{
			return dal.Update(model);
		}

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateList(int code,int ptid)
        {
            return dal.UpdateList(code, ptid);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int pt_ID)
		{
			
			return dal.Delete(pt_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string pt_IDlist )
		{
			return dal.DeleteList(pt_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public webs_YueyxShop.Model.ProductTypeBase GetModel(int pt_ID)
		{
			
			return dal.GetModel(pt_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public webs_YueyxShop.Model.ProductTypeBase GetModelByCache(int pt_ID)
		{
			
			string CacheKey = "ProductTypeBaseModel-" + pt_ID;
			object objModel =  Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(pt_ID);
					if (objModel != null)
					{
						int ModelCache =  Common.ConfigHelper.GetConfigInt("ModelCache");
						 Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (webs_YueyxShop.Model.ProductTypeBase)objModel;
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
		public List<webs_YueyxShop.Model.ProductTypeBase> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<webs_YueyxShop.Model.ProductTypeBase> DataTableToList(DataTable dt)
		{
			List<webs_YueyxShop.Model.ProductTypeBase> modelList = new List<webs_YueyxShop.Model.ProductTypeBase>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				webs_YueyxShop.Model.ProductTypeBase model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new webs_YueyxShop.Model.ProductTypeBase();
					if(dt.Rows[n]["pt_ID"]!=null && dt.Rows[n]["pt_ID"].ToString()!="")
					{
						model.pt_ID=int.Parse(dt.Rows[n]["pt_ID"].ToString());
					}
					if(dt.Rows[n]["pt_Name"]!=null && dt.Rows[n]["pt_Name"].ToString()!="")
					{
					model.pt_Name=dt.Rows[n]["pt_Name"].ToString();
					}
					if(dt.Rows[n]["pt_Code"]!=null && dt.Rows[n]["pt_Code"].ToString()!="")
					{
					model.pt_Code=dt.Rows[n]["pt_Code"].ToString();
					}
					if(dt.Rows[n]["pt_Layer"]!=null && dt.Rows[n]["pt_Layer"].ToString()!="")
					{
						model.pt_Layer=int.Parse(dt.Rows[n]["pt_Layer"].ToString());
					}
					if(dt.Rows[n]["pt_Sort"]!=null && dt.Rows[n]["pt_Sort"].ToString()!="")
					{
						model.pt_Sort=int.Parse(dt.Rows[n]["pt_Sort"].ToString());
					}
					if(dt.Rows[n]["pt_ParentId"]!=null && dt.Rows[n]["pt_ParentId"].ToString()!="")
					{
						model.pt_ParentId=int.Parse(dt.Rows[n]["pt_ParentId"].ToString());
					}
					if(dt.Rows[n]["pt_Content"]!=null && dt.Rows[n]["pt_Content"].ToString()!="")
					{
					model.pt_Content=dt.Rows[n]["pt_Content"].ToString();
					}
					if(dt.Rows[n]["pt_ImgUrl"]!=null && dt.Rows[n]["pt_ImgUrl"].ToString()!="")
					{
					model.pt_ImgUrl=dt.Rows[n]["pt_ImgUrl"].ToString();
					}
					if(dt.Rows[n]["pt_StatusCode"]!=null && dt.Rows[n]["pt_StatusCode"].ToString()!="")
					{
						model.pt_StatusCode=int.Parse(dt.Rows[n]["pt_StatusCode"].ToString());
					}
					if(dt.Rows[n]["pt_CreatedBy"]!=null && dt.Rows[n]["pt_CreatedBy"].ToString()!="")
					{
						model.pt_CreatedBy=new Guid(dt.Rows[n]["pt_CreatedBy"].ToString());
					}
					if(dt.Rows[n]["pt_CreatedOn"]!=null && dt.Rows[n]["pt_CreatedOn"].ToString()!="")
					{
						model.pt_CreatedOn=DateTime.Parse(dt.Rows[n]["pt_CreatedOn"].ToString());
					}
					if(dt.Rows[n]["pt_IsDel"]!=null && dt.Rows[n]["pt_IsDel"].ToString()!="")
					{
						if((dt.Rows[n]["pt_IsDel"].ToString()=="1")||(dt.Rows[n]["pt_IsDel"].ToString().ToLower()=="true"))
						{
						model.pt_IsDel=true;
						}
						else
						{
							model.pt_IsDel=false;
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
        /// <summary>
        /// 获取菜单编码
        /// </summary>
        /// <param name="m_BianM">父级编码</param>
        /// <param name="m_CengJ">当前层级</param>
        public string GetCode(string m_BianM, int m_CengJ)
        {
            return dal.GetCode(m_BianM, m_CengJ);
        }

        public int GetSort(string pid, int layer)
        {
            return dal.GetSort(pid, layer);
        }
    }
}

