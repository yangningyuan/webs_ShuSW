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
	/// vw_PInfo
	/// </summary>
	public partial class vw_PInfo
	{
		private readonly Ivw_PInfo dal=DataAccess.Createvw_PInfo();
		public vw_PInfo()
		{}
		#region  Method 

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(webs_YueyxShop.Model.vw_PInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(webs_YueyxShop.Model.vw_PInfo model)
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
        public webs_YueyxShop.Model.vw_PInfo GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public webs_YueyxShop.Model.vw_PInfo GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "vw_PInfoModel-" ;
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
            return (webs_YueyxShop.Model.vw_PInfo)objModel;
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
        public List<webs_YueyxShop.Model.vw_PInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<webs_YueyxShop.Model.vw_PInfo> DataTableToList2(DataTable dt)
		{
            List<webs_YueyxShop.Model.vw_PInfo> modelList = new List<webs_YueyxShop.Model.vw_PInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                webs_YueyxShop.Model.vw_PInfo model;
				for (int n = 0; n < rowsCount; n++)
                {
                    model = new webs_YueyxShop.Model.vw_PInfo();
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
						model.pi_Type=bool.Parse(dt.Rows[n]["pi_Type"].ToString());
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
                    if (dt.Rows[n]["sku_tdcode"] != null && dt.Rows[n]["sku_tdcode"].ToString() != "")
					{
                        model.sku_tdcode = dt.Rows[n]["sku_tdcode"].ToString();
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
					if(dt.Rows[n]["shuxing"]!=null && dt.Rows[n]["shuxing"].ToString()!="")
					{
					model.shuxing=dt.Rows[n]["shuxing"].ToString();
					}
                    if (dt.Rows[n]["pinglun"] != null && dt.Rows[n]["pinglun"].ToString() != "")
                    {
                        model.pinglun = int.Parse(dt.Rows[n]["pinglun"].ToString());
                    }
                    if (dt.Rows[n]["vc_id"] != null && dt.Rows[n]["vc_id"].ToString() != "")
                    {
                        model.vc_id = int.Parse(dt.Rows[n]["vc_id"].ToString());
                    }
                    if (dt.Rows[n]["vc_CreateOn"] != null && dt.Rows[n]["vc_CreateOn"].ToString() != "")
                    {
                        model.vc_CreateOn = DateTime.Parse(dt.Rows[n]["vc_CreateOn"].ToString());
                    }
                    if (dt.Rows[n]["vc_IsDel"] != null && dt.Rows[n]["vc_IsDel"].ToString() != "")
                    {
                        model.vc_IsDel = bool.Parse(dt.Rows[n]["vc_IsDel"].ToString());
                    }
					modelList.Add(model);
				}
			}
			return modelList;
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<webs_YueyxShop.Model.vw_PInfo> DataTableToList(DataTable dt)
        {
            List<webs_YueyxShop.Model.vw_PInfo> modelList = new List<webs_YueyxShop.Model.vw_PInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                webs_YueyxShop.Model.vw_PInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new webs_YueyxShop.Model.vw_PInfo();
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
                    if (dt.Rows[n]["b_ID"] != null && dt.Rows[n]["b_ID"].ToString() != "")
                    {
                        model.b_ID = int.Parse(dt.Rows[n]["b_ID"].ToString());
                    }
                    if (dt.Rows[n]["b_Name"] != null && dt.Rows[n]["b_Name"].ToString() != "")
                    {
                        model.b_Name = dt.Rows[n]["b_Name"].ToString();
                    }
                    if (dt.Rows[n]["p_ID"] != null && dt.Rows[n]["p_ID"].ToString() != "")
                    {
                        model.p_ID = int.Parse(dt.Rows[n]["p_ID"].ToString());
                    }
                    if (dt.Rows[n]["p_Name"] != null && dt.Rows[n]["p_Name"].ToString() != "")
                    {
                        model.p_Name = dt.Rows[n]["p_Name"].ToString();
                    }
                    if (dt.Rows[n]["p_ModifyOn"] != null && dt.Rows[n]["p_ModifyOn"].ToString() != "")
                    {
                        model.p_ModifyOn = DateTime.Parse(dt.Rows[n]["p_ModifyOn"].ToString());
                    }
                    if (dt.Rows[n]["p_ModifyBy"] != null && dt.Rows[n]["p_ModifyBy"].ToString() != "")
                    {
                        model.p_ModifyBy = new Guid(dt.Rows[n]["p_ModifyBy"].ToString());
                    }
                    if (dt.Rows[n]["p_StatusCode"] != null && dt.Rows[n]["p_StatusCode"].ToString() != "")
                    {
                        model.p_StatusCode = int.Parse(dt.Rows[n]["p_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["p_IsDel"] != null && dt.Rows[n]["p_IsDel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["p_IsDel"].ToString() == "1") || (dt.Rows[n]["p_IsDel"].ToString().ToLower() == "true"))
                        {
                            model.p_IsDel = true;
                        }
                        else
                        {
                            model.p_IsDel = false;
                        }
                    }
                    if (dt.Rows[n]["p_SellStatus"] != null && dt.Rows[n]["p_SellStatus"].ToString() != "")
                    {
                        model.p_SellStatus = int.Parse(dt.Rows[n]["p_SellStatus"].ToString());
                    }
                    if (dt.Rows[n]["pi_ID"] != null && dt.Rows[n]["pi_ID"].ToString() != "")
                    {
                        model.pi_ID = int.Parse(dt.Rows[n]["pi_ID"].ToString());
                    }
                    if (dt.Rows[n]["pi_Url"] != null && dt.Rows[n]["pi_Url"].ToString() != "")
                    {
                        model.pi_Url = dt.Rows[n]["pi_Url"].ToString();
                    }
                    if (dt.Rows[n]["pi_Type"] != null && dt.Rows[n]["pi_Type"].ToString() != "")
                    {
                        model.pi_Type = bool.Parse(dt.Rows[n]["pi_Type"].ToString());
                    }
                    if (dt.Rows[n]["pi_isDel"] != null && dt.Rows[n]["pi_isDel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["pi_isDel"].ToString() == "1") || (dt.Rows[n]["pi_isDel"].ToString().ToLower() == "true"))
                        {
                            model.pi_isDel = true;
                        }
                        else
                        {
                            model.pi_isDel = false;
                        }
                    }
                    if (dt.Rows[n]["pi_StatusCode"] != null && dt.Rows[n]["pi_StatusCode"].ToString() != "")
                    {
                        model.pi_StatusCode = int.Parse(dt.Rows[n]["pi_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["p_MeasurementUnit"] != null && dt.Rows[n]["p_MeasurementUnit"].ToString() != "")
                    {
                        model.p_MeasurementUnit = dt.Rows[n]["p_MeasurementUnit"].ToString();
                    }
                    if (dt.Rows[n]["pt_ID"] != null && dt.Rows[n]["pt_ID"].ToString() != "")
                    {
                        model.pt_ID = int.Parse(dt.Rows[n]["pt_ID"].ToString());
                    }
                    if (dt.Rows[n]["pt_Name"] != null && dt.Rows[n]["pt_Name"].ToString() != "")
                    {
                        model.pt_Name = dt.Rows[n]["pt_Name"].ToString();
                    }
                    if (dt.Rows[n]["pt_ParentId"] != null && dt.Rows[n]["pt_ParentId"].ToString() != "")
                    {
                        model.pt_ParentId = int.Parse(dt.Rows[n]["pt_ParentId"].ToString());
                    }
                    if (dt.Rows[n]["pt_StatusCode"] != null && dt.Rows[n]["pt_StatusCode"].ToString() != "")
                    {
                        model.pt_StatusCode = int.Parse(dt.Rows[n]["pt_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["pt_CreatedBy"] != null && dt.Rows[n]["pt_CreatedBy"].ToString() != "")
                    {
                        model.pt_CreatedBy = new Guid(dt.Rows[n]["pt_CreatedBy"].ToString());
                    }
                    if (dt.Rows[n]["pt_CreatedOn"] != null && dt.Rows[n]["pt_CreatedOn"].ToString() != "")
                    {
                        model.pt_CreatedOn = DateTime.Parse(dt.Rows[n]["pt_CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["pt_IsDel"] != null && dt.Rows[n]["pt_IsDel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["pt_IsDel"].ToString() == "1") || (dt.Rows[n]["pt_IsDel"].ToString().ToLower() == "true"))
                        {
                            model.pt_IsDel = true;
                        }
                        else
                        {
                            model.pt_IsDel = false;
                        }
                    }
                    if (dt.Rows[n]["pt_ImgUrl"] != null && dt.Rows[n]["pt_ImgUrl"].ToString() != "")
                    {
                        model.pt_ImgUrl = dt.Rows[n]["pt_ImgUrl"].ToString();
                    }
                    if (dt.Rows[n]["sku_ID"] != null && dt.Rows[n]["sku_ID"].ToString() != "")
                    {
                        model.sku_ID = int.Parse(dt.Rows[n]["sku_ID"].ToString());
                    }
                    //if (dt.Rows[n]["sku_Price"] != null && dt.Rows[n]["sku_Price"].ToString() != "")
                    //{
                    //    model.sku_Price = decimal.Parse(dt.Rows[n]["sku_Price"].ToString());
                    //}
                    if (dt.Rows[n]["sku_CostPrice"] != null && dt.Rows[n]["sku_CostPrice"].ToString() != "")
                    {
                        model.sku_CostPrice = decimal.Parse(dt.Rows[n]["sku_CostPrice"].ToString());
                    }
                    if (dt.Rows[n]["sku_SalesCount"] != null && dt.Rows[n]["sku_SalesCount"].ToString() != "")
                    {
                        model.sku_SalesCount = int.Parse(dt.Rows[n]["sku_SalesCount"].ToString());
                    }
                    if (dt.Rows[n]["sku_Stock"] != null && dt.Rows[n]["sku_Stock"].ToString() != "")
                    {
                        model.sku_Stock = int.Parse(dt.Rows[n]["sku_Stock"].ToString());
                    }
                    if (dt.Rows[n]["sku_Code"] != null && dt.Rows[n]["sku_Code"].ToString() != "")
                    {
                        model.sku_Code = dt.Rows[n]["sku_Code"].ToString();
                    }
                    if (dt.Rows[n]["sku_CreatedOn"] != null && dt.Rows[n]["sku_CreatedOn"].ToString() != "")
                    {
                        model.sku_CreatedOn = DateTime.Parse(dt.Rows[n]["sku_CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["sku_CreatedBy"] != null && dt.Rows[n]["sku_CreatedBy"].ToString() != "")
                    {
                        model.sku_CreatedBy = new Guid(dt.Rows[n]["sku_CreatedBy"].ToString());
                    }
                    if (dt.Rows[n]["sku_ModifyOn"] != null && dt.Rows[n]["sku_ModifyOn"].ToString() != "")
                    {
                        model.sku_ModifyOn = DateTime.Parse(dt.Rows[n]["sku_ModifyOn"].ToString());
                    }
                    if (dt.Rows[n]["sku_tdcode"] != null && dt.Rows[n]["sku_tdcode"].ToString() != "")
                    {
                        model.sku_tdcode = dt.Rows[n]["sku_tdcode"].ToString();
                    }
                    if (dt.Rows[n]["sku_ModifyBy"] != null && dt.Rows[n]["sku_ModifyBy"].ToString() != "")
                    {
                        model.sku_ModifyBy = new Guid(dt.Rows[n]["sku_ModifyBy"].ToString());
                    }
                    if (dt.Rows[n]["sku_StatusCode"] != null && dt.Rows[n]["sku_StatusCode"].ToString() != "")
                    {
                        model.sku_StatusCode = int.Parse(dt.Rows[n]["sku_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["sku_IsDel"] != null && dt.Rows[n]["sku_IsDel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["sku_IsDel"].ToString() == "1") || (dt.Rows[n]["sku_IsDel"].ToString().ToLower() == "true"))
                        {
                            model.sku_IsDel = true;
                        }
                        else
                        {
                            model.sku_IsDel = false;
                        }
                    }
                    if (dt.Rows[n]["sku_scPric"] != null && dt.Rows[n]["sku_scPric"].ToString() != "")
                    {
                        model.sku_scPric = decimal.Parse(dt.Rows[n]["sku_scPric"].ToString());
                    }
                    if (dt.Rows[n]["sku_ismoren"] != null && dt.Rows[n]["sku_ismoren"].ToString() != "")
                    {
                        if ((dt.Rows[n]["sku_ismoren"].ToString() == "1") || (dt.Rows[n]["sku_ismoren"].ToString().ToLower() == "true"))
                        {
                            model.sku_ismoren = true;
                        }
                        else
                        {
                            model.sku_ismoren = false;
                        }
                    }
                    if (dt.Rows[n]["p_Province"] != null && dt.Rows[n]["p_Province"].ToString() != "")
                    {
                        model.p_Province = int.Parse(dt.Rows[n]["p_Province"].ToString());
                    }
                    if (dt.Rows[n]["p_City"] != null && dt.Rows[n]["p_City"].ToString() != "")
                    {
                        model.p_City = int.Parse(dt.Rows[n]["p_City"].ToString());
                    }
                    if (dt.Rows[n]["p_County"] != null && dt.Rows[n]["p_County"].ToString() != "")
                    {
                        model.p_County = int.Parse(dt.Rows[n]["p_County"].ToString());
                    }
                    if (dt.Rows[n]["p_CreatedBy"] != null && dt.Rows[n]["p_CreatedBy"].ToString() != "")
                    {
                        model.p_CreatedBy = new Guid(dt.Rows[n]["p_CreatedBy"].ToString());
                    }
                    if (dt.Rows[n]["p_CreatedOn"] != null && dt.Rows[n]["p_CreatedOn"].ToString() != "")
                    {
                        model.p_CreatedOn = DateTime.Parse(dt.Rows[n]["p_CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["b_Key"] != null && dt.Rows[n]["b_Key"].ToString() != "")
                    {
                        model.b_Key = dt.Rows[n]["b_Key"].ToString();
                    }
                    if (dt.Rows[n]["b_SiteUrl"] != null && dt.Rows[n]["b_SiteUrl"].ToString() != "")
                    {
                        model.b_SiteUrl = dt.Rows[n]["b_SiteUrl"].ToString();
                    }
                    if (dt.Rows[n]["b_LogoUrl"] != null && dt.Rows[n]["b_LogoUrl"].ToString() != "")
                    {
                        model.b_LogoUrl = dt.Rows[n]["b_LogoUrl"].ToString();
                    }
                    if (dt.Rows[n]["b_Sort"] != null && dt.Rows[n]["b_Sort"].ToString() != "")
                    {
                        model.b_Sort = int.Parse(dt.Rows[n]["b_Sort"].ToString());
                    }
                    if (dt.Rows[n]["b_CreatedOn"] != null && dt.Rows[n]["b_CreatedOn"].ToString() != "")
                    {
                        model.b_CreatedOn = DateTime.Parse(dt.Rows[n]["b_CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["b_CreatedBy"] != null && dt.Rows[n]["b_CreatedBy"].ToString() != "")
                    {
                        model.b_CreatedBy = new Guid(dt.Rows[n]["b_CreatedBy"].ToString());
                    }
                    if (dt.Rows[n]["b_StatusCode"] != null && dt.Rows[n]["b_StatusCode"].ToString() != "")
                    {
                        model.b_StatusCode = int.Parse(dt.Rows[n]["b_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["b_IsDel"] != null && dt.Rows[n]["b_IsDel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["b_IsDel"].ToString() == "1") || (dt.Rows[n]["b_IsDel"].ToString().ToLower() == "true"))
                        {
                            model.b_IsDel = true;
                        }
                        else
                        {
                            model.b_IsDel = false;
                        }
                    }
                    if (dt.Rows[n]["b_IsTui"] != null && dt.Rows[n]["b_IsTui"].ToString() != "")
                    {
                        if ((dt.Rows[n]["b_IsTui"].ToString() == "1") || (dt.Rows[n]["b_IsTui"].ToString().ToLower() == "true"))
                        {
                            model.b_IsTui = true;
                        }
                        else
                        {
                            model.b_IsTui = false;
                        }
                    }
                    if (dt.Rows[n]["b_TuiImg"] != null && dt.Rows[n]["b_TuiImg"].ToString() != "")
                    {
                        model.b_TuiImg = (byte[])dt.Rows[n]["b_TuiImg"];
                    }
                    if (dt.Rows[n]["shuxing"] != null && dt.Rows[n]["shuxing"].ToString() != "")
                    {
                        model.shuxing = dt.Rows[n]["shuxing"].ToString();
                    }
                    if (dt.Rows[n]["pinglun"] != null && dt.Rows[n]["pinglun"].ToString() != "")
                    {
                        model.pinglun = int.Parse(dt.Rows[n]["pinglun"].ToString());
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
        /// 获得数据列表
        /// </summary>
        public List<webs_YueyxShop.Model.vw_PInfo> DataTableToList3(DataTable dt)
        {
            List<webs_YueyxShop.Model.vw_PInfo> modelList = new List<webs_YueyxShop.Model.vw_PInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                webs_YueyxShop.Model.vw_PInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new webs_YueyxShop.Model.vw_PInfo();
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
                    if (dt.Rows[n]["b_ID"] != null && dt.Rows[n]["b_ID"].ToString() != "")
                    {
                        model.b_ID = int.Parse(dt.Rows[n]["b_ID"].ToString());
                    }
                    if (dt.Rows[n]["b_Name"] != null && dt.Rows[n]["b_Name"].ToString() != "")
                    {
                        model.b_Name = dt.Rows[n]["b_Name"].ToString();
                    }
                    if (dt.Rows[n]["p_ID"] != null && dt.Rows[n]["p_ID"].ToString() != "")
                    {
                        model.p_ID = int.Parse(dt.Rows[n]["p_ID"].ToString());
                    }
                    if (dt.Rows[n]["p_Name"] != null && dt.Rows[n]["p_Name"].ToString() != "")
                    {
                        model.p_Name = dt.Rows[n]["p_Name"].ToString();
                    }
                    if (dt.Rows[n]["p_ModifyOn"] != null && dt.Rows[n]["p_ModifyOn"].ToString() != "")
                    {
                        model.p_ModifyOn = DateTime.Parse(dt.Rows[n]["p_ModifyOn"].ToString());
                    }
                    if (dt.Rows[n]["p_ModifyBy"] != null && dt.Rows[n]["p_ModifyBy"].ToString() != "")
                    {
                        model.p_ModifyBy = new Guid(dt.Rows[n]["p_ModifyBy"].ToString());
                    }
                    if (dt.Rows[n]["p_StatusCode"] != null && dt.Rows[n]["p_StatusCode"].ToString() != "")
                    {
                        model.p_StatusCode = int.Parse(dt.Rows[n]["p_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["p_IsDel"] != null && dt.Rows[n]["p_IsDel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["p_IsDel"].ToString() == "1") || (dt.Rows[n]["p_IsDel"].ToString().ToLower() == "true"))
                        {
                            model.p_IsDel = true;
                        }
                        else
                        {
                            model.p_IsDel = false;
                        }
                    }
                    if (dt.Rows[n]["p_SellStatus"] != null && dt.Rows[n]["p_SellStatus"].ToString() != "")
                    {
                        model.p_SellStatus = int.Parse(dt.Rows[n]["p_SellStatus"].ToString());
                    }
                    if (dt.Rows[n]["pi_ID"] != null && dt.Rows[n]["pi_ID"].ToString() != "")
                    {
                        model.pi_ID = int.Parse(dt.Rows[n]["pi_ID"].ToString());
                    }
                    if (dt.Rows[n]["pi_Url"] != null && dt.Rows[n]["pi_Url"].ToString() != "")
                    {
                        model.pi_Url = dt.Rows[n]["pi_Url"].ToString();
                    }
                    if (dt.Rows[n]["pi_Type"] != null && dt.Rows[n]["pi_Type"].ToString() != "")
                    {
                        model.pi_Type = bool.Parse(dt.Rows[n]["pi_Type"].ToString());
                    }
                    if (dt.Rows[n]["pi_isDel"] != null && dt.Rows[n]["pi_isDel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["pi_isDel"].ToString() == "1") || (dt.Rows[n]["pi_isDel"].ToString().ToLower() == "true"))
                        {
                            model.pi_isDel = true;
                        }
                        else
                        {
                            model.pi_isDel = false;
                        }
                    }
                    if (dt.Rows[n]["pi_StatusCode"] != null && dt.Rows[n]["pi_StatusCode"].ToString() != "")
                    {
                        model.pi_StatusCode = int.Parse(dt.Rows[n]["pi_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["p_MeasurementUnit"] != null && dt.Rows[n]["p_MeasurementUnit"].ToString() != "")
                    {
                        model.p_MeasurementUnit = dt.Rows[n]["p_MeasurementUnit"].ToString();
                    }
                    if (dt.Rows[n]["pt_ID"] != null && dt.Rows[n]["pt_ID"].ToString() != "")
                    {
                        model.pt_ID = int.Parse(dt.Rows[n]["pt_ID"].ToString());
                    }
                    if (dt.Rows[n]["pt_Name"] != null && dt.Rows[n]["pt_Name"].ToString() != "")
                    {
                        model.pt_Name = dt.Rows[n]["pt_Name"].ToString();
                    }
                    if (dt.Rows[n]["pt_ParentId"] != null && dt.Rows[n]["pt_ParentId"].ToString() != "")
                    {
                        model.pt_ParentId = int.Parse(dt.Rows[n]["pt_ParentId"].ToString());
                    }
                    if (dt.Rows[n]["pt_StatusCode"] != null && dt.Rows[n]["pt_StatusCode"].ToString() != "")
                    {
                        model.pt_StatusCode = int.Parse(dt.Rows[n]["pt_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["pt_CreatedBy"] != null && dt.Rows[n]["pt_CreatedBy"].ToString() != "")
                    {
                        model.pt_CreatedBy = new Guid(dt.Rows[n]["pt_CreatedBy"].ToString());
                    }
                    if (dt.Rows[n]["pt_CreatedOn"] != null && dt.Rows[n]["pt_CreatedOn"].ToString() != "")
                    {
                        model.pt_CreatedOn = DateTime.Parse(dt.Rows[n]["pt_CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["pt_IsDel"] != null && dt.Rows[n]["pt_IsDel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["pt_IsDel"].ToString() == "1") || (dt.Rows[n]["pt_IsDel"].ToString().ToLower() == "true"))
                        {
                            model.pt_IsDel = true;
                        }
                        else
                        {
                            model.pt_IsDel = false;
                        }
                    }
                    if (dt.Rows[n]["pt_ImgUrl"] != null && dt.Rows[n]["pt_ImgUrl"].ToString() != "")
                    {
                        model.pt_ImgUrl = dt.Rows[n]["pt_ImgUrl"].ToString();
                    }
                    if (dt.Rows[n]["sku_ID"] != null && dt.Rows[n]["sku_ID"].ToString() != "")
                    {
                        model.sku_ID = int.Parse(dt.Rows[n]["sku_ID"].ToString());
                    }
                    //if (dt.Rows[n]["sku_Price"] != null && dt.Rows[n]["sku_Price"].ToString() != "")
                    //{
                    //    model.sku_Price = decimal.Parse(dt.Rows[n]["sku_Price"].ToString());
                    //}
                    if (dt.Rows[n]["sku_CostPrice"] != null && dt.Rows[n]["sku_CostPrice"].ToString() != "")
                    {
                        model.sku_CostPrice = decimal.Parse(dt.Rows[n]["sku_CostPrice"].ToString());
                    }
                    if (dt.Rows[n]["sku_SalesCount"] != null && dt.Rows[n]["sku_SalesCount"].ToString() != "")
                    {
                        model.sku_SalesCount = int.Parse(dt.Rows[n]["sku_SalesCount"].ToString());
                    }
                    if (dt.Rows[n]["sku_Stock"] != null && dt.Rows[n]["sku_Stock"].ToString() != "")
                    {
                        model.sku_Stock = int.Parse(dt.Rows[n]["sku_Stock"].ToString());
                    }
                    if (dt.Rows[n]["sku_Code"] != null && dt.Rows[n]["sku_Code"].ToString() != "")
                    {
                        model.sku_Code = dt.Rows[n]["sku_Code"].ToString();
                    }
                    if (dt.Rows[n]["sku_CreatedOn"] != null && dt.Rows[n]["sku_CreatedOn"].ToString() != "")
                    {
                        model.sku_CreatedOn = DateTime.Parse(dt.Rows[n]["sku_CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["sku_CreatedBy"] != null && dt.Rows[n]["sku_CreatedBy"].ToString() != "")
                    {
                        model.sku_CreatedBy = new Guid(dt.Rows[n]["sku_CreatedBy"].ToString());
                    }
                    if (dt.Rows[n]["sku_ModifyOn"] != null && dt.Rows[n]["sku_ModifyOn"].ToString() != "")
                    {
                        model.sku_ModifyOn = DateTime.Parse(dt.Rows[n]["sku_ModifyOn"].ToString());
                    }
                    if (dt.Rows[n]["sku_tdcode"] != null && dt.Rows[n]["sku_tdcode"].ToString() != "")
                    {
                        model.sku_tdcode = dt.Rows[n]["sku_tdcode"].ToString();
                    }
                    if (dt.Rows[n]["sku_ModifyBy"] != null && dt.Rows[n]["sku_ModifyBy"].ToString() != "")
                    {
                        model.sku_ModifyBy = new Guid(dt.Rows[n]["sku_ModifyBy"].ToString());
                    }
                    if (dt.Rows[n]["sku_StatusCode"] != null && dt.Rows[n]["sku_StatusCode"].ToString() != "")
                    {
                        model.sku_StatusCode = int.Parse(dt.Rows[n]["sku_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["sku_IsDel"] != null && dt.Rows[n]["sku_IsDel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["sku_IsDel"].ToString() == "1") || (dt.Rows[n]["sku_IsDel"].ToString().ToLower() == "true"))
                        {
                            model.sku_IsDel = true;
                        }
                        else
                        {
                            model.sku_IsDel = false;
                        }
                    }
                    if (dt.Rows[n]["sku_scPric"] != null && dt.Rows[n]["sku_scPric"].ToString() != "")
                    {
                        model.sku_scPric = decimal.Parse(dt.Rows[n]["sku_scPric"].ToString());
                    }
                    if (dt.Rows[n]["sku_ismoren"] != null && dt.Rows[n]["sku_ismoren"].ToString() != "")
                    {
                        if ((dt.Rows[n]["sku_ismoren"].ToString() == "1") || (dt.Rows[n]["sku_ismoren"].ToString().ToLower() == "true"))
                        {
                            model.sku_ismoren = true;
                        }
                        else
                        {
                            model.sku_ismoren = false;
                        }
                    }
                    if (dt.Rows[n]["p_Province"] != null && dt.Rows[n]["p_Province"].ToString() != "")
                    {
                        model.p_Province = int.Parse(dt.Rows[n]["p_Province"].ToString());
                    }
                    if (dt.Rows[n]["p_City"] != null && dt.Rows[n]["p_City"].ToString() != "")
                    {
                        model.p_City = int.Parse(dt.Rows[n]["p_City"].ToString());
                    }
                    if (dt.Rows[n]["p_County"] != null && dt.Rows[n]["p_County"].ToString() != "")
                    {
                        model.p_County = int.Parse(dt.Rows[n]["p_County"].ToString());
                    }
                    if (dt.Rows[n]["p_CreatedBy"] != null && dt.Rows[n]["p_CreatedBy"].ToString() != "")
                    {
                        model.p_CreatedBy = new Guid(dt.Rows[n]["p_CreatedBy"].ToString());
                    }
                    if (dt.Rows[n]["p_CreatedOn"] != null && dt.Rows[n]["p_CreatedOn"].ToString() != "")
                    {
                        model.p_CreatedOn = DateTime.Parse(dt.Rows[n]["p_CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["b_Key"] != null && dt.Rows[n]["b_Key"].ToString() != "")
                    {
                        model.b_Key = dt.Rows[n]["b_Key"].ToString();
                    }
                    if (dt.Rows[n]["b_SiteUrl"] != null && dt.Rows[n]["b_SiteUrl"].ToString() != "")
                    {
                        model.b_SiteUrl = dt.Rows[n]["b_SiteUrl"].ToString();
                    }
                    if (dt.Rows[n]["b_LogoUrl"] != null && dt.Rows[n]["b_LogoUrl"].ToString() != "")
                    {
                        model.b_LogoUrl = dt.Rows[n]["b_LogoUrl"].ToString();
                    }
                    if (dt.Rows[n]["b_Sort"] != null && dt.Rows[n]["b_Sort"].ToString() != "")
                    {
                        model.b_Sort = int.Parse(dt.Rows[n]["b_Sort"].ToString());
                    }
                    if (dt.Rows[n]["b_CreatedOn"] != null && dt.Rows[n]["b_CreatedOn"].ToString() != "")
                    {
                        model.b_CreatedOn = DateTime.Parse(dt.Rows[n]["b_CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["b_CreatedBy"] != null && dt.Rows[n]["b_CreatedBy"].ToString() != "")
                    {
                        model.b_CreatedBy = new Guid(dt.Rows[n]["b_CreatedBy"].ToString());
                    }
                    if (dt.Rows[n]["b_StatusCode"] != null && dt.Rows[n]["b_StatusCode"].ToString() != "")
                    {
                        model.b_StatusCode = int.Parse(dt.Rows[n]["b_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["b_IsDel"] != null && dt.Rows[n]["b_IsDel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["b_IsDel"].ToString() == "1") || (dt.Rows[n]["b_IsDel"].ToString().ToLower() == "true"))
                        {
                            model.b_IsDel = true;
                        }
                        else
                        {
                            model.b_IsDel = false;
                        }
                    }
                    if (dt.Rows[n]["b_IsTui"] != null && dt.Rows[n]["b_IsTui"].ToString() != "")
                    {
                        if ((dt.Rows[n]["b_IsTui"].ToString() == "1") || (dt.Rows[n]["b_IsTui"].ToString().ToLower() == "true"))
                        {
                            model.b_IsTui = true;
                        }
                        else
                        {
                            model.b_IsTui = false;
                        }
                    }
                    if (dt.Rows[n]["b_TuiImg"] != null && dt.Rows[n]["b_TuiImg"].ToString() != "")
                    {
                        model.b_TuiImg = (byte[])dt.Rows[n]["b_TuiImg"];
                    }
                    if (dt.Rows[n]["shuxing"] != null && dt.Rows[n]["shuxing"].ToString() != "")
                    {
                        model.shuxing = dt.Rows[n]["shuxing"].ToString();
                    }
                    if (dt.Rows[n]["pinglun"] != null && dt.Rows[n]["pinglun"].ToString() != "")
                    {
                        model.pinglun = int.Parse(dt.Rows[n]["pinglun"].ToString());
                    }
                    if (dt.Rows[n]["gz"] != null && dt.Rows[n]["gz"].ToString() != "")
                    {
                        model.gz = int.Parse(dt.Rows[n]["gz"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<webs_YueyxShop.Model.vw_PInfo> DataTableToList4(DataTable dt)
        {
            List<webs_YueyxShop.Model.vw_PInfo> modelList = new List<webs_YueyxShop.Model.vw_PInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                webs_YueyxShop.Model.vw_PInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new webs_YueyxShop.Model.vw_PInfo();
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

                    if (dt.Rows[n]["b_ID"] != null && dt.Rows[n]["b_ID"].ToString() != "")
                    {
                        model.b_ID = int.Parse(dt.Rows[n]["b_ID"].ToString());
                    }
                    if (dt.Rows[n]["b_Name"] != null && dt.Rows[n]["b_Name"].ToString() != "")
                    {
                        model.b_Name = dt.Rows[n]["b_Name"].ToString();
                    }
                    if (dt.Rows[n]["p_ID"] != null && dt.Rows[n]["p_ID"].ToString() != "")
                    {
                        model.p_ID = int.Parse(dt.Rows[n]["p_ID"].ToString());
                    }
                    if (dt.Rows[n]["p_Name"] != null && dt.Rows[n]["p_Name"].ToString() != "")
                    {
                        model.p_Name = dt.Rows[n]["p_Name"].ToString();
                    }
                    if (dt.Rows[n]["p_ModifyOn"] != null && dt.Rows[n]["p_ModifyOn"].ToString() != "")
                    {
                        model.p_ModifyOn = DateTime.Parse(dt.Rows[n]["p_ModifyOn"].ToString());
                    }
                    if (dt.Rows[n]["p_ModifyBy"] != null && dt.Rows[n]["p_ModifyBy"].ToString() != "")
                    {
                        model.p_ModifyBy = new Guid(dt.Rows[n]["p_ModifyBy"].ToString());
                    }
                    if (dt.Rows[n]["p_StatusCode"] != null && dt.Rows[n]["p_StatusCode"].ToString() != "")
                    {
                        model.p_StatusCode = int.Parse(dt.Rows[n]["p_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["p_IsDel"] != null && dt.Rows[n]["p_IsDel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["p_IsDel"].ToString() == "1") || (dt.Rows[n]["p_IsDel"].ToString().ToLower() == "true"))
                        {
                            model.p_IsDel = true;
                        }
                        else
                        {
                            model.p_IsDel = false;
                        }
                    }
                    if (dt.Rows[n]["p_SellStatus"] != null && dt.Rows[n]["p_SellStatus"].ToString() != "")
                    {
                        model.p_SellStatus = int.Parse(dt.Rows[n]["p_SellStatus"].ToString());
                    }
                    if (dt.Rows[n]["pi_ID"] != null && dt.Rows[n]["pi_ID"].ToString() != "")
                    {
                        model.pi_ID = int.Parse(dt.Rows[n]["pi_ID"].ToString());
                    }
                    if (dt.Rows[n]["pi_Url"] != null && dt.Rows[n]["pi_Url"].ToString() != "")
                    {
                        model.pi_Url = dt.Rows[n]["pi_Url"].ToString();
                    }
                    if (dt.Rows[n]["pi_Type"] != null && dt.Rows[n]["pi_Type"].ToString() != "")
                    {
                        model.pi_Type = bool.Parse(dt.Rows[n]["pi_Type"].ToString());
                    }
                    if (dt.Rows[n]["pi_isDel"] != null && dt.Rows[n]["pi_isDel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["pi_isDel"].ToString() == "1") || (dt.Rows[n]["pi_isDel"].ToString().ToLower() == "true"))
                        {
                            model.pi_isDel = true;
                        }
                        else
                        {
                            model.pi_isDel = false;
                        }
                    }
                    if (dt.Rows[n]["pi_StatusCode"] != null && dt.Rows[n]["pi_StatusCode"].ToString() != "")
                    {
                        model.pi_StatusCode = int.Parse(dt.Rows[n]["pi_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["p_MeasurementUnit"] != null && dt.Rows[n]["p_MeasurementUnit"].ToString() != "")
                    {
                        model.p_MeasurementUnit = dt.Rows[n]["p_MeasurementUnit"].ToString();
                    }
                    if (dt.Rows[n]["pt_ID"] != null && dt.Rows[n]["pt_ID"].ToString() != "")
                    {
                        model.pt_ID = int.Parse(dt.Rows[n]["pt_ID"].ToString());
                    }
                    if (dt.Rows[n]["pt_Name"] != null && dt.Rows[n]["pt_Name"].ToString() != "")
                    {
                        model.pt_Name = dt.Rows[n]["pt_Name"].ToString();
                    }
                    if (dt.Rows[n]["pt_ParentId"] != null && dt.Rows[n]["pt_ParentId"].ToString() != "")
                    {
                        model.pt_ParentId = int.Parse(dt.Rows[n]["pt_ParentId"].ToString());
                    }
                    if (dt.Rows[n]["pt_StatusCode"] != null && dt.Rows[n]["pt_StatusCode"].ToString() != "")
                    {
                        model.pt_StatusCode = int.Parse(dt.Rows[n]["pt_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["pt_CreatedBy"] != null && dt.Rows[n]["pt_CreatedBy"].ToString() != "")
                    {
                        model.pt_CreatedBy = new Guid(dt.Rows[n]["pt_CreatedBy"].ToString());
                    }
                    if (dt.Rows[n]["pt_CreatedOn"] != null && dt.Rows[n]["pt_CreatedOn"].ToString() != "")
                    {
                        model.pt_CreatedOn = DateTime.Parse(dt.Rows[n]["pt_CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["pt_IsDel"] != null && dt.Rows[n]["pt_IsDel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["pt_IsDel"].ToString() == "1") || (dt.Rows[n]["pt_IsDel"].ToString().ToLower() == "true"))
                        {
                            model.pt_IsDel = true;
                        }
                        else
                        {
                            model.pt_IsDel = false;
                        }
                    }
                    if (dt.Rows[n]["pt_ImgUrl"] != null && dt.Rows[n]["pt_ImgUrl"].ToString() != "")
                    {
                        model.pt_ImgUrl = dt.Rows[n]["pt_ImgUrl"].ToString();
                    }
                    if (dt.Rows[n]["sku_ID"] != null && dt.Rows[n]["sku_ID"].ToString() != "")
                    {
                        model.sku_ID = int.Parse(dt.Rows[n]["sku_ID"].ToString());
                    }
                    //if(dt.Rows[n]["sku_Price"]!=null && dt.Rows[n]["sku_Price"].ToString()!="")
                    //{
                    //    model.sku_Price=decimal.Parse(dt.Rows[n]["sku_Price"].ToString());
                    //}
                    if (dt.Rows[n]["sku_CostPrice"] != null && dt.Rows[n]["sku_CostPrice"].ToString() != "")
                    {
                        model.sku_CostPrice = decimal.Parse(dt.Rows[n]["sku_CostPrice"].ToString());
                    }
                    if (dt.Rows[n]["sku_SalesCount"] != null && dt.Rows[n]["sku_SalesCount"].ToString() != "")
                    {
                        model.sku_SalesCount = int.Parse(dt.Rows[n]["sku_SalesCount"].ToString());
                    }
                    if (dt.Rows[n]["sku_Stock"] != null && dt.Rows[n]["sku_Stock"].ToString() != "")
                    {
                        model.sku_Stock = int.Parse(dt.Rows[n]["sku_Stock"].ToString());
                    }
                    if (dt.Rows[n]["sku_Code"] != null && dt.Rows[n]["sku_Code"].ToString() != "")
                    {
                        model.sku_Code = dt.Rows[n]["sku_Code"].ToString();
                    }
                    if (dt.Rows[n]["sku_tdcode"] != null && dt.Rows[n]["sku_tdcode"].ToString() != "")
                    {
                        model.sku_tdcode = dt.Rows[n]["sku_tdcode"].ToString();
                    }
                    if (dt.Rows[n]["sku_CreatedOn"] != null && dt.Rows[n]["sku_CreatedOn"].ToString() != "")
                    {
                        model.sku_CreatedOn = DateTime.Parse(dt.Rows[n]["sku_CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["sku_CreatedBy"] != null && dt.Rows[n]["sku_CreatedBy"].ToString() != "")
                    {
                        model.sku_CreatedBy = new Guid(dt.Rows[n]["sku_CreatedBy"].ToString());
                    }
                    if (dt.Rows[n]["sku_ModifyOn"] != null && dt.Rows[n]["sku_ModifyOn"].ToString() != "")
                    {
                        model.sku_ModifyOn = DateTime.Parse(dt.Rows[n]["sku_ModifyOn"].ToString());
                    }
                    if (dt.Rows[n]["sku_ModifyBy"] != null && dt.Rows[n]["sku_ModifyBy"].ToString() != "")
                    {
                        model.sku_ModifyBy = new Guid(dt.Rows[n]["sku_ModifyBy"].ToString());
                    }
                    if (dt.Rows[n]["sku_StatusCode"] != null && dt.Rows[n]["sku_StatusCode"].ToString() != "")
                    {
                        model.sku_StatusCode = int.Parse(dt.Rows[n]["sku_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["sku_IsDel"] != null && dt.Rows[n]["sku_IsDel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["sku_IsDel"].ToString() == "1") || (dt.Rows[n]["sku_IsDel"].ToString().ToLower() == "true"))
                        {
                            model.sku_IsDel = true;
                        }
                        else
                        {
                            model.sku_IsDel = false;
                        }
                    }
                    if (dt.Rows[n]["sku_scPric"] != null && dt.Rows[n]["sku_scPric"].ToString() != "")
                    {
                        model.sku_scPric = decimal.Parse(dt.Rows[n]["sku_scPric"].ToString());
                    }
                    if (dt.Rows[n]["sku_ismoren"] != null && dt.Rows[n]["sku_ismoren"].ToString() != "")
                    {
                        if ((dt.Rows[n]["sku_ismoren"].ToString() == "1") || (dt.Rows[n]["sku_ismoren"].ToString().ToLower() == "true"))
                        {
                            model.sku_ismoren = true;
                        }
                        else
                        {
                            model.sku_ismoren = false;
                        }
                    }
                    if (dt.Rows[n]["p_Province"] != null && dt.Rows[n]["p_Province"].ToString() != "")
                    {
                        model.p_Province = int.Parse(dt.Rows[n]["p_Province"].ToString());
                    }
                    if (dt.Rows[n]["p_City"] != null && dt.Rows[n]["p_City"].ToString() != "")
                    {
                        model.p_City = int.Parse(dt.Rows[n]["p_City"].ToString());
                    }
                    if (dt.Rows[n]["p_County"] != null && dt.Rows[n]["p_County"].ToString() != "")
                    {
                        model.p_County = int.Parse(dt.Rows[n]["p_County"].ToString());
                    }
                    if (dt.Rows[n]["p_CreatedBy"] != null && dt.Rows[n]["p_CreatedBy"].ToString() != "")
                    {
                        model.p_CreatedBy = new Guid(dt.Rows[n]["p_CreatedBy"].ToString());
                    }
                    if (dt.Rows[n]["p_CreatedOn"] != null && dt.Rows[n]["p_CreatedOn"].ToString() != "")
                    {
                        model.p_CreatedOn = DateTime.Parse(dt.Rows[n]["p_CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["b_Key"] != null && dt.Rows[n]["b_Key"].ToString() != "")
                    {
                        model.b_Key = dt.Rows[n]["b_Key"].ToString();
                    }
                    if (dt.Rows[n]["b_SiteUrl"] != null && dt.Rows[n]["b_SiteUrl"].ToString() != "")
                    {
                        model.b_SiteUrl = dt.Rows[n]["b_SiteUrl"].ToString();
                    }
                    if (dt.Rows[n]["b_LogoUrl"] != null && dt.Rows[n]["b_LogoUrl"].ToString() != "")
                    {
                        model.b_LogoUrl = dt.Rows[n]["b_LogoUrl"].ToString();
                    }
                    if (dt.Rows[n]["b_Sort"] != null && dt.Rows[n]["b_Sort"].ToString() != "")
                    {
                        model.b_Sort = int.Parse(dt.Rows[n]["b_Sort"].ToString());
                    }
                    if (dt.Rows[n]["b_CreatedOn"] != null && dt.Rows[n]["b_CreatedOn"].ToString() != "")
                    {
                        model.b_CreatedOn = DateTime.Parse(dt.Rows[n]["b_CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["b_CreatedBy"] != null && dt.Rows[n]["b_CreatedBy"].ToString() != "")
                    {
                        model.b_CreatedBy = new Guid(dt.Rows[n]["b_CreatedBy"].ToString());
                    }
                    if (dt.Rows[n]["b_StatusCode"] != null && dt.Rows[n]["b_StatusCode"].ToString() != "")
                    {
                        model.b_StatusCode = int.Parse(dt.Rows[n]["b_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["b_IsDel"] != null && dt.Rows[n]["b_IsDel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["b_IsDel"].ToString() == "1") || (dt.Rows[n]["b_IsDel"].ToString().ToLower() == "true"))
                        {
                            model.b_IsDel = true;
                        }
                        else
                        {
                            model.b_IsDel = false;
                        }
                    }
                    if (dt.Rows[n]["b_IsTui"] != null && dt.Rows[n]["b_IsTui"].ToString() != "")
                    {
                        if ((dt.Rows[n]["b_IsTui"].ToString() == "1") || (dt.Rows[n]["b_IsTui"].ToString().ToLower() == "true"))
                        {
                            model.b_IsTui = true;
                        }
                        else
                        {
                            model.b_IsTui = false;
                        }
                    }
                    if (dt.Rows[n]["b_TuiImg"] != null && dt.Rows[n]["b_TuiImg"].ToString() != "")
                    {
                        model.b_TuiImg = (byte[])dt.Rows[n]["b_TuiImg"];
                    }
                    if (dt.Rows[n]["shuxing"] != null && dt.Rows[n]["shuxing"].ToString() != "")
                    {
                        model.shuxing = dt.Rows[n]["shuxing"].ToString();
                    }
                    if (dt.Rows[n]["pinglun"] != null && dt.Rows[n]["pinglun"].ToString() != "")
                    {
                        model.pinglun = int.Parse(dt.Rows[n]["pinglun"].ToString());
                    }
                    if (dt.Rows[n]["pa_Satisfied"] != null && dt.Rows[n]["pa_Satisfied"].ToString() != "")
                    {
                        model.pa_Satisfied = int.Parse(dt.Rows[n]["pa_Satisfied"].ToString());
                    }
                    if (dt.Rows[n]["pa_Content"] != null && dt.Rows[n]["pa_Content"].ToString() != "")
                    {
                        model.pa_Content = dt.Rows[n]["pa_Content"].ToString();
                    }
                    if (dt.Rows[n]["pa_id"] != null && dt.Rows[n]["pa_id"].ToString() != "")
                    {
                        model.pa_id = int.Parse(dt.Rows[n]["pa_id"].ToString());
                    }
                    if (dt.Rows[n]["pa_CreatedOn"] != null && dt.Rows[n]["pa_CreatedOn"].ToString() != "")
                    {
                        model.pa_CreatedOn = DateTime.Parse(dt.Rows[n]["pa_CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["pa_IsDel"] != null && dt.Rows[n]["pa_IsDel"].ToString() != "")
                    {
                        model.pa_IsDel = bool.Parse(dt.Rows[n]["pa_IsDel"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<webs_YueyxShop.Model.vw_PInfo> DataTableToList5(DataTable dt)
        {
            List<webs_YueyxShop.Model.vw_PInfo> modelList = new List<webs_YueyxShop.Model.vw_PInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                webs_YueyxShop.Model.vw_PInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new webs_YueyxShop.Model.vw_PInfo();
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
                    if (dt.Rows[n]["skucount"] != null && dt.Rows[n]["skucount"].ToString() != "")
                    {
                        model.skucount = int.Parse(dt.Rows[n]["skucount"].ToString());
                    }
                    if (dt.Rows[n]["b_ID"] != null && dt.Rows[n]["b_ID"].ToString() != "")
                    {
                        model.b_ID = int.Parse(dt.Rows[n]["b_ID"].ToString());
                    }
                    if (dt.Rows[n]["b_Name"] != null && dt.Rows[n]["b_Name"].ToString() != "")
                    {
                        model.b_Name = dt.Rows[n]["b_Name"].ToString();
                    }
                    if (dt.Rows[n]["p_ID"] != null && dt.Rows[n]["p_ID"].ToString() != "")
                    {
                        model.p_ID = int.Parse(dt.Rows[n]["p_ID"].ToString());
                    }
                    if (dt.Rows[n]["p_Name"] != null && dt.Rows[n]["p_Name"].ToString() != "")
                    {
                        model.p_Name = dt.Rows[n]["p_Name"].ToString();
                    }
                    if (dt.Rows[n]["p_ModifyOn"] != null && dt.Rows[n]["p_ModifyOn"].ToString() != "")
                    {
                        model.p_ModifyOn = DateTime.Parse(dt.Rows[n]["p_ModifyOn"].ToString());
                    }
                    if (dt.Rows[n]["p_ModifyBy"] != null && dt.Rows[n]["p_ModifyBy"].ToString() != "")
                    {
                        model.p_ModifyBy = new Guid(dt.Rows[n]["p_ModifyBy"].ToString());
                    }
                    if (dt.Rows[n]["p_StatusCode"] != null && dt.Rows[n]["p_StatusCode"].ToString() != "")
                    {
                        model.p_StatusCode = int.Parse(dt.Rows[n]["p_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["p_IsDel"] != null && dt.Rows[n]["p_IsDel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["p_IsDel"].ToString() == "1") || (dt.Rows[n]["p_IsDel"].ToString().ToLower() == "true"))
                        {
                            model.p_IsDel = true;
                        }
                        else
                        {
                            model.p_IsDel = false;
                        }
                    }
                    if (dt.Rows[n]["p_SellStatus"] != null && dt.Rows[n]["p_SellStatus"].ToString() != "")
                    {
                        model.p_SellStatus = int.Parse(dt.Rows[n]["p_SellStatus"].ToString());
                    }
                    if (dt.Rows[n]["pi_ID"] != null && dt.Rows[n]["pi_ID"].ToString() != "")
                    {
                        model.pi_ID = int.Parse(dt.Rows[n]["pi_ID"].ToString());
                    }
                    if (dt.Rows[n]["pi_Url"] != null && dt.Rows[n]["pi_Url"].ToString() != "")
                    {
                        model.pi_Url = dt.Rows[n]["pi_Url"].ToString();
                    }
                    if (dt.Rows[n]["pi_Type"] != null && dt.Rows[n]["pi_Type"].ToString() != "")
                    {
                        model.pi_Type = bool.Parse(dt.Rows[n]["pi_Type"].ToString());
                    }
                    if (dt.Rows[n]["pi_isDel"] != null && dt.Rows[n]["pi_isDel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["pi_isDel"].ToString() == "1") || (dt.Rows[n]["pi_isDel"].ToString().ToLower() == "true"))
                        {
                            model.pi_isDel = true;
                        }
                        else
                        {
                            model.pi_isDel = false;
                        }
                    }
                    if (dt.Rows[n]["pi_StatusCode"] != null && dt.Rows[n]["pi_StatusCode"].ToString() != "")
                    {
                        model.pi_StatusCode = int.Parse(dt.Rows[n]["pi_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["p_MeasurementUnit"] != null && dt.Rows[n]["p_MeasurementUnit"].ToString() != "")
                    {
                        model.p_MeasurementUnit = dt.Rows[n]["p_MeasurementUnit"].ToString();
                    }
                    if (dt.Rows[n]["pt_ID"] != null && dt.Rows[n]["pt_ID"].ToString() != "")
                    {
                        model.pt_ID = int.Parse(dt.Rows[n]["pt_ID"].ToString());
                    }
                    if (dt.Rows[n]["pt_Name"] != null && dt.Rows[n]["pt_Name"].ToString() != "")
                    {
                        model.pt_Name = dt.Rows[n]["pt_Name"].ToString();
                    }
                    if (dt.Rows[n]["pt_ParentId"] != null && dt.Rows[n]["pt_ParentId"].ToString() != "")
                    {
                        model.pt_ParentId = int.Parse(dt.Rows[n]["pt_ParentId"].ToString());
                    }
                    if (dt.Rows[n]["pt_StatusCode"] != null && dt.Rows[n]["pt_StatusCode"].ToString() != "")
                    {
                        model.pt_StatusCode = int.Parse(dt.Rows[n]["pt_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["pt_CreatedBy"] != null && dt.Rows[n]["pt_CreatedBy"].ToString() != "")
                    {
                        model.pt_CreatedBy = new Guid(dt.Rows[n]["pt_CreatedBy"].ToString());
                    }
                    if (dt.Rows[n]["pt_CreatedOn"] != null && dt.Rows[n]["pt_CreatedOn"].ToString() != "")
                    {
                        model.pt_CreatedOn = DateTime.Parse(dt.Rows[n]["pt_CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["pt_IsDel"] != null && dt.Rows[n]["pt_IsDel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["pt_IsDel"].ToString() == "1") || (dt.Rows[n]["pt_IsDel"].ToString().ToLower() == "true"))
                        {
                            model.pt_IsDel = true;
                        }
                        else
                        {
                            model.pt_IsDel = false;
                        }
                    }
                    if (dt.Rows[n]["pt_ImgUrl"] != null && dt.Rows[n]["pt_ImgUrl"].ToString() != "")
                    {
                        model.pt_ImgUrl = dt.Rows[n]["pt_ImgUrl"].ToString();
                    }
                    if (dt.Rows[n]["sku_ID"] != null && dt.Rows[n]["sku_ID"].ToString() != "")
                    {
                        model.sku_ID = int.Parse(dt.Rows[n]["sku_ID"].ToString());
                    }
                    if (dt.Rows[n]["sku_CostPrice"] != null && dt.Rows[n]["sku_CostPrice"].ToString() != "")
                    {
                        model.sku_CostPrice = decimal.Parse(dt.Rows[n]["sku_CostPrice"].ToString());
                    }
                    if (dt.Rows[n]["sku_SalesCount"] != null && dt.Rows[n]["sku_SalesCount"].ToString() != "")
                    {
                        model.sku_SalesCount = int.Parse(dt.Rows[n]["sku_SalesCount"].ToString());
                    }
                    if (dt.Rows[n]["sku_Stock"] != null && dt.Rows[n]["sku_Stock"].ToString() != "")
                    {
                        model.sku_Stock = int.Parse(dt.Rows[n]["sku_Stock"].ToString());
                    }
                    if (dt.Rows[n]["sku_Code"] != null && dt.Rows[n]["sku_Code"].ToString() != "")
                    {
                        model.sku_Code = dt.Rows[n]["sku_Code"].ToString();
                    }
                    if (dt.Rows[n]["sku_tdcode"] != null && dt.Rows[n]["sku_tdcode"].ToString() != "")
                    {
                        model.sku_tdcode = dt.Rows[n]["sku_tdcode"].ToString();
                    }
                    if (dt.Rows[n]["sku_CreatedOn"] != null && dt.Rows[n]["sku_CreatedOn"].ToString() != "")
                    {
                        model.sku_CreatedOn = DateTime.Parse(dt.Rows[n]["sku_CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["sku_CreatedBy"] != null && dt.Rows[n]["sku_CreatedBy"].ToString() != "")
                    {
                        model.sku_CreatedBy = new Guid(dt.Rows[n]["sku_CreatedBy"].ToString());
                    }
                    if (dt.Rows[n]["sku_ModifyOn"] != null && dt.Rows[n]["sku_ModifyOn"].ToString() != "")
                    {
                        model.sku_ModifyOn = DateTime.Parse(dt.Rows[n]["sku_ModifyOn"].ToString());
                    }
                    if (dt.Rows[n]["sku_ModifyBy"] != null && dt.Rows[n]["sku_ModifyBy"].ToString() != "")
                    {
                        model.sku_ModifyBy = new Guid(dt.Rows[n]["sku_ModifyBy"].ToString());
                    }
                    if (dt.Rows[n]["sku_StatusCode"] != null && dt.Rows[n]["sku_StatusCode"].ToString() != "")
                    {
                        model.sku_StatusCode = int.Parse(dt.Rows[n]["sku_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["sku_IsDel"] != null && dt.Rows[n]["sku_IsDel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["sku_IsDel"].ToString() == "1") || (dt.Rows[n]["sku_IsDel"].ToString().ToLower() == "true"))
                        {
                            model.sku_IsDel = true;
                        }
                        else
                        {
                            model.sku_IsDel = false;
                        }
                    }
                    if (dt.Rows[n]["sku_scPric"] != null && dt.Rows[n]["sku_scPric"].ToString() != "")
                    {
                        model.sku_scPric = decimal.Parse(dt.Rows[n]["sku_scPric"].ToString());
                    }
                    if (dt.Rows[n]["sku_ismoren"] != null && dt.Rows[n]["sku_ismoren"].ToString() != "")
                    {
                        if ((dt.Rows[n]["sku_ismoren"].ToString() == "1") || (dt.Rows[n]["sku_ismoren"].ToString().ToLower() == "true"))
                        {
                            model.sku_ismoren = true;
                        }
                        else
                        {
                            model.sku_ismoren = false;
                        }
                    }
                    if (dt.Rows[n]["p_Province"] != null && dt.Rows[n]["p_Province"].ToString() != "")
                    {
                        model.p_Province = int.Parse(dt.Rows[n]["p_Province"].ToString());
                    }
                    if (dt.Rows[n]["p_City"] != null && dt.Rows[n]["p_City"].ToString() != "")
                    {
                        model.p_City = int.Parse(dt.Rows[n]["p_City"].ToString());
                    }
                    if (dt.Rows[n]["p_County"] != null && dt.Rows[n]["p_County"].ToString() != "")
                    {
                        model.p_County = int.Parse(dt.Rows[n]["p_County"].ToString());
                    }
                    if (dt.Rows[n]["p_CreatedBy"] != null && dt.Rows[n]["p_CreatedBy"].ToString() != "")
                    {
                        model.p_CreatedBy = new Guid(dt.Rows[n]["p_CreatedBy"].ToString());
                    }
                    if (dt.Rows[n]["p_CreatedOn"] != null && dt.Rows[n]["p_CreatedOn"].ToString() != "")
                    {
                        model.p_CreatedOn = DateTime.Parse(dt.Rows[n]["p_CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["b_Key"] != null && dt.Rows[n]["b_Key"].ToString() != "")
                    {
                        model.b_Key = dt.Rows[n]["b_Key"].ToString();
                    }
                    if (dt.Rows[n]["b_SiteUrl"] != null && dt.Rows[n]["b_SiteUrl"].ToString() != "")
                    {
                        model.b_SiteUrl = dt.Rows[n]["b_SiteUrl"].ToString();
                    }
                    if (dt.Rows[n]["b_LogoUrl"] != null && dt.Rows[n]["b_LogoUrl"].ToString() != "")
                    {
                        model.b_LogoUrl = dt.Rows[n]["b_LogoUrl"].ToString();
                    }
                    if (dt.Rows[n]["b_Sort"] != null && dt.Rows[n]["b_Sort"].ToString() != "")
                    {
                        model.b_Sort = int.Parse(dt.Rows[n]["b_Sort"].ToString());
                    }
                    if (dt.Rows[n]["b_CreatedOn"] != null && dt.Rows[n]["b_CreatedOn"].ToString() != "")
                    {
                        model.b_CreatedOn = DateTime.Parse(dt.Rows[n]["b_CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["b_CreatedBy"] != null && dt.Rows[n]["b_CreatedBy"].ToString() != "")
                    {
                        model.b_CreatedBy = new Guid(dt.Rows[n]["b_CreatedBy"].ToString());
                    }
                    if (dt.Rows[n]["b_StatusCode"] != null && dt.Rows[n]["b_StatusCode"].ToString() != "")
                    {
                        model.b_StatusCode = int.Parse(dt.Rows[n]["b_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["b_IsDel"] != null && dt.Rows[n]["b_IsDel"].ToString() != "")
                    {
                        if ((dt.Rows[n]["b_IsDel"].ToString() == "1") || (dt.Rows[n]["b_IsDel"].ToString().ToLower() == "true"))
                        {
                            model.b_IsDel = true;
                        }
                        else
                        {
                            model.b_IsDel = false;
                        }
                    }
                    if (dt.Rows[n]["b_IsTui"] != null && dt.Rows[n]["b_IsTui"].ToString() != "")
                    {
                        if ((dt.Rows[n]["b_IsTui"].ToString() == "1") || (dt.Rows[n]["b_IsTui"].ToString().ToLower() == "true"))
                        {
                            model.b_IsTui = true;
                        }
                        else
                        {
                            model.b_IsTui = false;
                        }
                    }
                    if (dt.Rows[n]["b_TuiImg"] != null && dt.Rows[n]["b_TuiImg"].ToString() != "")
                    {
                        model.b_TuiImg = (byte[])dt.Rows[n]["b_TuiImg"];
                    }
                    if (dt.Rows[n]["shuxing"] != null && dt.Rows[n]["shuxing"].ToString() != "")
                    {
                        model.shuxing = dt.Rows[n]["shuxing"].ToString();
                    }
                    if (dt.Rows[n]["pinglun"] != null && dt.Rows[n]["pinglun"].ToString() != "")
                    {
                        model.pinglun = int.Parse(dt.Rows[n]["pinglun"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
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

        public List<webs_YueyxShop.Model.vw_PInfo> GetModelList(string p, int p_2, int pagerows,string sort)
        {

            DataSet ds = dal.GetList(p, p_2, pagerows,sort);
            return DataTableToList(ds.Tables[0]);
        }

        public List<Model.vw_PInfo> GetModelListVC(string p, int page, int pagerows, string sortby)
        {

            DataSet ds = dal.GetListVC(p, page, pagerows, sortby);
            return DataTableToList2(ds.Tables[0]);
        }

        public List<Model.vw_PInfo> getguanzhu(string p, int page, int pagerows)
        {
            DataSet ds = dal.getguanzhu(p, page, pagerows);
            return DataTableToList3(ds.Tables[0]);
        }

        public List<Model.vw_PInfo> GetModelListPA(string p, int page, int pagerows, string sortby)
        {
            DataSet ds = dal.GetListPA(p, page, pagerows, sortby);
            return DataTableToList4(ds.Tables[0]);
        }

        public List<Model.vw_PInfo> getmodelListPH()
        {
            DataSet ds = dal.getmodelListPH();
            return DataTableToList5(ds.Tables[0]);
        }
    }
}

