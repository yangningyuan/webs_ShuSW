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
	/// vw_Orderpinfo
	/// </summary>
	public partial class vw_Orderpinfo
	{
		private readonly Ivw_Orderpinfo dal=DataAccess.Createvw_Orderpinfo();
		public vw_Orderpinfo()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(webs_YueyxShop.Model.vw_Orderpinfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(webs_YueyxShop.Model.vw_Orderpinfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public webs_YueyxShop.Model.vw_Orderpinfo GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public webs_YueyxShop.Model.vw_Orderpinfo GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "vw_OrderpinfoModel-" ;
			object objModel = Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
						Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (webs_YueyxShop.Model.vw_Orderpinfo)objModel;
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
		public List<webs_YueyxShop.Model.vw_Orderpinfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<webs_YueyxShop.Model.vw_Orderpinfo> DataTableToList(DataTable dt)
		{
			List<webs_YueyxShop.Model.vw_Orderpinfo> modelList = new List<webs_YueyxShop.Model.vw_Orderpinfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				webs_YueyxShop.Model.vw_Orderpinfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new webs_YueyxShop.Model.vw_Orderpinfo();
                    if (dt.Rows[n]["sku_Price"] != null && dt.Rows[n]["sku_Price"].ToString() != "")
                    {
                        string sql = " sku_ID=" + dt.Rows[n]["sku_ID"] + " and gp_StatusCode=0 and gp_IsDel=0 and gp_EndTime > '" + DateTime.Now + "'";
                        var gplist = new BLL.GroupPurchaseBase().GetModelList(sql);
                        if (gplist.Count > 0)
                        {
                            model.sku_Price = decimal.Parse(gplist[0].gp_pPric.ToString());
                        }
                        else
                        {
                            model.sku_Price = decimal.Parse(dt.Rows[n]["sku_Price"].ToString());
                        }
                    }
					if(dt.Rows[n]["b_ID"]!=null && dt.Rows[n]["b_ID"].ToString()!="")
					{
						model.b_ID=int.Parse(dt.Rows[n]["b_ID"].ToString());
					}
					if(dt.Rows[n]["b_Name"]!=null && dt.Rows[n]["b_Name"].ToString()!="")
					{
					model.b_Name=dt.Rows[n]["b_Name"].ToString();
					}
					if(dt.Rows[n]["p_ID"]!=null && dt.Rows[n]["p_ID"].ToString()!="")
					{
						model.p_ID=int.Parse(dt.Rows[n]["p_ID"].ToString());
					}
					if(dt.Rows[n]["p_Name"]!=null && dt.Rows[n]["p_Name"].ToString()!="")
					{
					model.p_Name=dt.Rows[n]["p_Name"].ToString();
					}
					if(dt.Rows[n]["p_ModifyOn"]!=null && dt.Rows[n]["p_ModifyOn"].ToString()!="")
					{
						model.p_ModifyOn=DateTime.Parse(dt.Rows[n]["p_ModifyOn"].ToString());
					}
					if(dt.Rows[n]["p_ModifyBy"]!=null && dt.Rows[n]["p_ModifyBy"].ToString()!="")
					{
						model.p_ModifyBy=new Guid(dt.Rows[n]["p_ModifyBy"].ToString());
					}
					if(dt.Rows[n]["p_StatusCode"]!=null && dt.Rows[n]["p_StatusCode"].ToString()!="")
					{
						model.p_StatusCode=int.Parse(dt.Rows[n]["p_StatusCode"].ToString());
					}
					if(dt.Rows[n]["p_IsDel"]!=null && dt.Rows[n]["p_IsDel"].ToString()!="")
					{
						if((dt.Rows[n]["p_IsDel"].ToString()=="1")||(dt.Rows[n]["p_IsDel"].ToString().ToLower()=="true"))
						{
						model.p_IsDel=true;
						}
						else
						{
							model.p_IsDel=false;
						}
					}
					if(dt.Rows[n]["p_SellStatus"]!=null && dt.Rows[n]["p_SellStatus"].ToString()!="")
					{
						model.p_SellStatus=int.Parse(dt.Rows[n]["p_SellStatus"].ToString());
					}
					if(dt.Rows[n]["pi_ID"]!=null && dt.Rows[n]["pi_ID"].ToString()!="")
					{
						model.pi_ID=int.Parse(dt.Rows[n]["pi_ID"].ToString());
					}
					if(dt.Rows[n]["pi_Url"]!=null && dt.Rows[n]["pi_Url"].ToString()!="")
					{
					model.pi_Url=dt.Rows[n]["pi_Url"].ToString();
					}
					if(dt.Rows[n]["pi_Type"]!=null && dt.Rows[n]["pi_Type"].ToString()!="")
					{
						if((dt.Rows[n]["pi_Type"].ToString()=="1")||(dt.Rows[n]["pi_Type"].ToString().ToLower()=="true"))
						{
						model.pi_Type=true;
						}
						else
						{
							model.pi_Type=false;
						}
					}
					if(dt.Rows[n]["pi_isDel"]!=null && dt.Rows[n]["pi_isDel"].ToString()!="")
					{
						if((dt.Rows[n]["pi_isDel"].ToString()=="1")||(dt.Rows[n]["pi_isDel"].ToString().ToLower()=="true"))
						{
						model.pi_isDel=true;
						}
						else
						{
							model.pi_isDel=false;
						}
					}
					if(dt.Rows[n]["pi_StatusCode"]!=null && dt.Rows[n]["pi_StatusCode"].ToString()!="")
					{
						model.pi_StatusCode=int.Parse(dt.Rows[n]["pi_StatusCode"].ToString());
					}
					if(dt.Rows[n]["p_MeasurementUnit"]!=null && dt.Rows[n]["p_MeasurementUnit"].ToString()!="")
					{
					model.p_MeasurementUnit=dt.Rows[n]["p_MeasurementUnit"].ToString();
					}
					if(dt.Rows[n]["pt_ID"]!=null && dt.Rows[n]["pt_ID"].ToString()!="")
					{
						model.pt_ID=int.Parse(dt.Rows[n]["pt_ID"].ToString());
					}
					if(dt.Rows[n]["pt_Name"]!=null && dt.Rows[n]["pt_Name"].ToString()!="")
					{
					model.pt_Name=dt.Rows[n]["pt_Name"].ToString();
					}
					if(dt.Rows[n]["pt_ParentId"]!=null && dt.Rows[n]["pt_ParentId"].ToString()!="")
					{
						model.pt_ParentId=int.Parse(dt.Rows[n]["pt_ParentId"].ToString());
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
					if(dt.Rows[n]["pt_ImgUrl"]!=null && dt.Rows[n]["pt_ImgUrl"].ToString()!="")
					{
					model.pt_ImgUrl=dt.Rows[n]["pt_ImgUrl"].ToString();
					}
					if(dt.Rows[n]["sku_ID"]!=null && dt.Rows[n]["sku_ID"].ToString()!="")
					{
						model.sku_ID=int.Parse(dt.Rows[n]["sku_ID"].ToString());
					}
                    //if(dt.Rows[n]["sku_Price"]!=null && dt.Rows[n]["sku_Price"].ToString()!="")
                    //{
                    //    model.sku_Price=decimal.Parse(dt.Rows[n]["sku_Price"].ToString());
                    //}
					if(dt.Rows[n]["sku_CostPrice"]!=null && dt.Rows[n]["sku_CostPrice"].ToString()!="")
					{
						model.sku_CostPrice=decimal.Parse(dt.Rows[n]["sku_CostPrice"].ToString());
					}
					if(dt.Rows[n]["sku_SalesCount"]!=null && dt.Rows[n]["sku_SalesCount"].ToString()!="")
					{
						model.sku_SalesCount=int.Parse(dt.Rows[n]["sku_SalesCount"].ToString());
					}
					if(dt.Rows[n]["sku_Stock"]!=null && dt.Rows[n]["sku_Stock"].ToString()!="")
					{
						model.sku_Stock=int.Parse(dt.Rows[n]["sku_Stock"].ToString());
					}
					if(dt.Rows[n]["sku_Code"]!=null && dt.Rows[n]["sku_Code"].ToString()!="")
					{
					model.sku_Code=dt.Rows[n]["sku_Code"].ToString();
					}
					if(dt.Rows[n]["sku_CreatedOn"]!=null && dt.Rows[n]["sku_CreatedOn"].ToString()!="")
					{
						model.sku_CreatedOn=DateTime.Parse(dt.Rows[n]["sku_CreatedOn"].ToString());
					}
					if(dt.Rows[n]["sku_CreatedBy"]!=null && dt.Rows[n]["sku_CreatedBy"].ToString()!="")
					{
						model.sku_CreatedBy=new Guid(dt.Rows[n]["sku_CreatedBy"].ToString());
					}
					if(dt.Rows[n]["sku_ModifyOn"]!=null && dt.Rows[n]["sku_ModifyOn"].ToString()!="")
					{
						model.sku_ModifyOn=DateTime.Parse(dt.Rows[n]["sku_ModifyOn"].ToString());
					}
					if(dt.Rows[n]["sku_ModifyBy"]!=null && dt.Rows[n]["sku_ModifyBy"].ToString()!="")
					{
						model.sku_ModifyBy=new Guid(dt.Rows[n]["sku_ModifyBy"].ToString());
					}
					if(dt.Rows[n]["sku_StatusCode"]!=null && dt.Rows[n]["sku_StatusCode"].ToString()!="")
					{
						model.sku_StatusCode=int.Parse(dt.Rows[n]["sku_StatusCode"].ToString());
					}
					if(dt.Rows[n]["sku_IsDel"]!=null && dt.Rows[n]["sku_IsDel"].ToString()!="")
					{
						if((dt.Rows[n]["sku_IsDel"].ToString()=="1")||(dt.Rows[n]["sku_IsDel"].ToString().ToLower()=="true"))
						{
						model.sku_IsDel=true;
						}
						else
						{
							model.sku_IsDel=false;
						}
					}
					if(dt.Rows[n]["sku_scPric"]!=null && dt.Rows[n]["sku_scPric"].ToString()!="")
					{
						model.sku_scPric=decimal.Parse(dt.Rows[n]["sku_scPric"].ToString());
					}
					if(dt.Rows[n]["sku_ismoren"]!=null && dt.Rows[n]["sku_ismoren"].ToString()!="")
					{
						if((dt.Rows[n]["sku_ismoren"].ToString()=="1")||(dt.Rows[n]["sku_ismoren"].ToString().ToLower()=="true"))
						{
						model.sku_ismoren=true;
						}
						else
						{
							model.sku_ismoren=false;
						}
					}
					if(dt.Rows[n]["p_Province"]!=null && dt.Rows[n]["p_Province"].ToString()!="")
					{
						model.p_Province=int.Parse(dt.Rows[n]["p_Province"].ToString());
					}
					if(dt.Rows[n]["p_City"]!=null && dt.Rows[n]["p_City"].ToString()!="")
					{
						model.p_City=int.Parse(dt.Rows[n]["p_City"].ToString());
					}
					if(dt.Rows[n]["p_County"]!=null && dt.Rows[n]["p_County"].ToString()!="")
					{
						model.p_County=int.Parse(dt.Rows[n]["p_County"].ToString());
					}
					if(dt.Rows[n]["p_CreatedBy"]!=null && dt.Rows[n]["p_CreatedBy"].ToString()!="")
					{
						model.p_CreatedBy=new Guid(dt.Rows[n]["p_CreatedBy"].ToString());
					}
					if(dt.Rows[n]["p_CreatedOn"]!=null && dt.Rows[n]["p_CreatedOn"].ToString()!="")
					{
						model.p_CreatedOn=DateTime.Parse(dt.Rows[n]["p_CreatedOn"].ToString());
					}
					if(dt.Rows[n]["b_Key"]!=null && dt.Rows[n]["b_Key"].ToString()!="")
					{
					model.b_Key=dt.Rows[n]["b_Key"].ToString();
					}
					if(dt.Rows[n]["b_SiteUrl"]!=null && dt.Rows[n]["b_SiteUrl"].ToString()!="")
					{
					model.b_SiteUrl=dt.Rows[n]["b_SiteUrl"].ToString();
					}
					if(dt.Rows[n]["b_LogoUrl"]!=null && dt.Rows[n]["b_LogoUrl"].ToString()!="")
					{
					model.b_LogoUrl=dt.Rows[n]["b_LogoUrl"].ToString();
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
					if(dt.Rows[n]["b_IsTui"]!=null && dt.Rows[n]["b_IsTui"].ToString()!="")
					{
						if((dt.Rows[n]["b_IsTui"].ToString()=="1")||(dt.Rows[n]["b_IsTui"].ToString().ToLower()=="true"))
						{
						model.b_IsTui=true;
						}
						else
						{
							model.b_IsTui=false;
						}
					}
					if(dt.Rows[n]["b_TuiImg"]!=null && dt.Rows[n]["b_TuiImg"].ToString()!="")
					{
						model.b_TuiImg=(byte[])dt.Rows[n]["b_TuiImg"];
					}
					if(dt.Rows[n]["o_ID"]!=null && dt.Rows[n]["o_ID"].ToString()!="")
					{
						model.o_ID=int.Parse(dt.Rows[n]["o_ID"].ToString());
					}
					if(dt.Rows[n]["c_ID"]!=null && dt.Rows[n]["c_ID"].ToString()!="")
					{
						model.c_ID=int.Parse(dt.Rows[n]["c_ID"].ToString());
					}
					if(dt.Rows[n]["o_Code"]!=null && dt.Rows[n]["o_Code"].ToString()!="")
					{
					model.o_Code=dt.Rows[n]["o_Code"].ToString();
					}
					if(dt.Rows[n]["m_ID"]!=null && dt.Rows[n]["m_ID"].ToString()!="")
					{
						model.m_ID=int.Parse(dt.Rows[n]["m_ID"].ToString());
					}
					if(dt.Rows[n]["o_CreateOn"]!=null && dt.Rows[n]["o_CreateOn"].ToString()!="")
					{
						model.o_CreateOn=DateTime.Parse(dt.Rows[n]["o_CreateOn"].ToString());
					}
					if(dt.Rows[n]["o_Pric"]!=null && dt.Rows[n]["o_Pric"].ToString()!="")
					{
						model.o_Pric=decimal.Parse(dt.Rows[n]["o_Pric"].ToString());
					}
                    if (dt.Rows[n]["o_Zhek"] != null && dt.Rows[n]["o_Zhek"].ToString() != "")
					{
                        model.o_Zhek = decimal.Parse(dt.Rows[n]["o_Zhek"].ToString());
					}
                    if (dt.Rows[n]["o_Score"] != null && dt.Rows[n]["o_Score"].ToString() != "")
					{
                        model.o_Score = int.Parse(dt.Rows[n]["o_Score"].ToString());
					}
					if(dt.Rows[n]["o_StatusCode"]!=null && dt.Rows[n]["o_StatusCode"].ToString()!="")
					{
						model.o_StatusCode=int.Parse(dt.Rows[n]["o_StatusCode"].ToString());
					}
					if(dt.Rows[n]["o_Mark"]!=null && dt.Rows[n]["o_Mark"].ToString()!="")
					{
					model.o_Mark=dt.Rows[n]["o_Mark"].ToString();
					}
					if(dt.Rows[n]["o_IsDel"]!=null && dt.Rows[n]["o_IsDel"].ToString()!="")
					{
						if((dt.Rows[n]["o_IsDel"].ToString()=="1")||(dt.Rows[n]["o_IsDel"].ToString().ToLower()=="true"))
						{
						model.o_IsDel=true;
						}
						else
						{
							model.o_IsDel=false;
						}
					}
					if(dt.Rows[n]["pay_ID"]!=null && dt.Rows[n]["pay_ID"].ToString()!="")
					{
						model.pay_ID=int.Parse(dt.Rows[n]["pay_ID"].ToString());
					}
					if(dt.Rows[n]["st_ID"]!=null && dt.Rows[n]["st_ID"].ToString()!="")
					{
						model.st_ID=int.Parse(dt.Rows[n]["st_ID"].ToString());
					}
					if(dt.Rows[n]["os_ID"]!=null && dt.Rows[n]["os_ID"].ToString()!="")
					{
						model.os_ID=int.Parse(dt.Rows[n]["os_ID"].ToString());
					}
                    if (dt.Rows[n]["os_IsGP"] != null && dt.Rows[n]["os_IsGP"].ToString() != "")
					{
                        model.os_IsGP = bool.Parse(dt.Rows[n]["os_IsGP"].ToString());
					}
					if(dt.Rows[n]["os_pCount"]!=null && dt.Rows[n]["os_pCount"].ToString()!="")
					{
						model.os_pCount=int.Parse(dt.Rows[n]["os_pCount"].ToString());
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

