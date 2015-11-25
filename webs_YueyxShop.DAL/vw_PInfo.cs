using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using webs_YueyxShop.IDAL;

using DBUtility;//Please add references
namespace webs_YueyxShop.DAL
{
	/// <summary>
	/// 数据访问类:vw_PInfo
	/// </summary>
	public partial class vw_PInfo:Ivw_PInfo
	{
		public vw_PInfo()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(webs_YueyxShop.Model.vw_PInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into vw_PInfo(");
			strSql.Append("b_ID,b_Name,p_ID,p_Name,p_ModifyOn,p_ModifyBy,p_StatusCode,p_IsDel,p_SellStatus,pi_ID,pi_Url,pi_Type,pi_isDel,pi_StatusCode,p_MeasurementUnit,pt_ID,pt_Name,pt_ParentId,pt_StatusCode,pt_CreatedBy,pt_CreatedOn,pt_IsDel,pt_ImgUrl,sku_ID,sku_Price,sku_CostPrice,sku_SalesCount,sku_Stock,sku_Code,sku_CreatedOn,sku_CreatedBy,sku_ModifyOn,sku_ModifyBy,sku_StatusCode,sku_IsDel,sku_scPric,sku_ismoren,p_Province,p_City,p_County,p_CreatedBy,p_CreatedOn,b_Key,b_SiteUrl,b_LogoUrl,b_Sort,b_CreatedOn,b_CreatedBy,b_StatusCode,b_IsDel,b_IsTui,b_TuiImg,shuxing,pinglun)");
			strSql.Append(" values (");
			strSql.Append("@b_ID,@b_Name,@p_ID,@p_Name,@p_ModifyOn,@p_ModifyBy,@p_StatusCode,@p_IsDel,@p_SellStatus,@pi_ID,@pi_Url,@pi_Type,@pi_isDel,@pi_StatusCode,@p_MeasurementUnit,@pt_ID,@pt_Name,@pt_ParentId,@pt_StatusCode,@pt_CreatedBy,@pt_CreatedOn,@pt_IsDel,@pt_ImgUrl,@sku_ID,@sku_Price,@sku_CostPrice,@sku_SalesCount,@sku_Stock,@sku_Code,@sku_CreatedOn,@sku_CreatedBy,@sku_ModifyOn,@sku_ModifyBy,@sku_StatusCode,@sku_IsDel,@sku_scPric,@sku_ismoren,@p_Province,@p_City,@p_County,@p_CreatedBy,@p_CreatedOn,@b_Key,@b_SiteUrl,@b_LogoUrl,@b_Sort,@b_CreatedOn,@b_CreatedBy,@b_StatusCode,@b_IsDel,@b_IsTui,@b_TuiImg,@shuxing,@pinglun)");
			SqlParameter[] parameters = {
					new SqlParameter("@b_ID", SqlDbType.Int,4),
					new SqlParameter("@b_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@p_ID", SqlDbType.Int,4),
					new SqlParameter("@p_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@p_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@p_ModifyBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@p_StatusCode", SqlDbType.SmallInt,2),
					new SqlParameter("@p_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@p_SellStatus", SqlDbType.Int,4),
					new SqlParameter("@pi_ID", SqlDbType.Int,4),
					new SqlParameter("@pi_Url", SqlDbType.VarChar,100),
					new SqlParameter("@pi_Type", SqlDbType.Int,4),
					new SqlParameter("@pi_isDel", SqlDbType.Bit,1),
					new SqlParameter("@pi_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@p_MeasurementUnit", SqlDbType.VarChar,20),
					new SqlParameter("@pt_ID", SqlDbType.Int,4),
					new SqlParameter("@pt_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@pt_ParentId", SqlDbType.Int,4),
					new SqlParameter("@pt_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@pt_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@pt_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@pt_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@pt_ImgUrl", SqlDbType.VarChar,200),
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@sku_Price", SqlDbType.Decimal,5),
					new SqlParameter("@sku_CostPrice", SqlDbType.Decimal,5),
					new SqlParameter("@sku_SalesCount", SqlDbType.Int,4),
					new SqlParameter("@sku_Stock", SqlDbType.Int,4),
					new SqlParameter("@sku_Code", SqlDbType.VarChar,30),
					new SqlParameter("@sku_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@sku_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@sku_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@sku_ModifyBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@sku_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@sku_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@sku_scPric", SqlDbType.Decimal,5),
					new SqlParameter("@sku_ismoren", SqlDbType.Bit,1),
					new SqlParameter("@p_Province", SqlDbType.Int,4),
					new SqlParameter("@p_City", SqlDbType.Int,4),
					new SqlParameter("@p_County", SqlDbType.Int,4),
					new SqlParameter("@p_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@p_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@b_Key", SqlDbType.VarChar,20),
					new SqlParameter("@b_SiteUrl", SqlDbType.VarChar,50),
					new SqlParameter("@b_LogoUrl", SqlDbType.VarChar,100),
					new SqlParameter("@b_Sort", SqlDbType.Int,4),
					new SqlParameter("@b_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@b_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@b_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@b_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@b_IsTui", SqlDbType.Bit,1),
					new SqlParameter("@b_TuiImg", SqlDbType.VarBinary,50),
					new SqlParameter("@shuxing", SqlDbType.NVarChar,200),
					new SqlParameter("@pinglun", SqlDbType.Int,4)};
			parameters[0].Value = model.b_ID;
			parameters[1].Value = model.b_Name;
			parameters[2].Value = model.p_ID;
			parameters[3].Value = model.p_Name;
			parameters[4].Value = model.p_ModifyOn;
			parameters[5].Value = Guid.NewGuid();
			parameters[6].Value = model.p_StatusCode;
			parameters[7].Value = model.p_IsDel;
			parameters[8].Value = model.p_SellStatus;
			parameters[9].Value = model.pi_ID;
			parameters[10].Value = model.pi_Url;
			parameters[11].Value = model.pi_Type;
			parameters[12].Value = model.pi_isDel;
			parameters[13].Value = model.pi_StatusCode;
			parameters[14].Value = model.p_MeasurementUnit;
			parameters[15].Value = model.pt_ID;
			parameters[16].Value = model.pt_Name;
			parameters[17].Value = model.pt_ParentId;
			parameters[18].Value = model.pt_StatusCode;
			parameters[19].Value = Guid.NewGuid();
			parameters[20].Value = model.pt_CreatedOn;
			parameters[21].Value = model.pt_IsDel;
			parameters[22].Value = model.pt_ImgUrl;
			parameters[23].Value = model.sku_ID;
			parameters[24].Value = model.sku_Price;
			parameters[25].Value = model.sku_CostPrice;
			parameters[26].Value = model.sku_SalesCount;
			parameters[27].Value = model.sku_Stock;
			parameters[28].Value = model.sku_Code;
			parameters[29].Value = model.sku_CreatedOn;
			parameters[30].Value = Guid.NewGuid();
			parameters[31].Value = model.sku_ModifyOn;
			parameters[32].Value = Guid.NewGuid();
			parameters[33].Value = model.sku_StatusCode;
			parameters[34].Value = model.sku_IsDel;
			parameters[35].Value = model.sku_scPric;
			parameters[36].Value = model.sku_ismoren;
			parameters[37].Value = model.p_Province;
			parameters[38].Value = model.p_City;
			parameters[39].Value = model.p_County;
			parameters[40].Value = Guid.NewGuid();
			parameters[41].Value = model.p_CreatedOn;
			parameters[42].Value = model.b_Key;
			parameters[43].Value = model.b_SiteUrl;
			parameters[44].Value = model.b_LogoUrl;
			parameters[45].Value = model.b_Sort;
			parameters[46].Value = model.b_CreatedOn;
			parameters[47].Value = Guid.NewGuid();
			parameters[48].Value = model.b_StatusCode;
			parameters[49].Value = model.b_IsDel;
			parameters[50].Value = model.b_IsTui;
			parameters[51].Value = model.b_TuiImg;
			parameters[52].Value = model.shuxing;
			parameters[53].Value = model.pinglun;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(webs_YueyxShop.Model.vw_PInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update vw_PInfo set ");
			strSql.Append("b_ID=@b_ID,");
			strSql.Append("b_Name=@b_Name,");
			strSql.Append("p_ID=@p_ID,");
			strSql.Append("p_Name=@p_Name,");
			strSql.Append("p_ModifyOn=@p_ModifyOn,");
			strSql.Append("p_ModifyBy=@p_ModifyBy,");
			strSql.Append("p_StatusCode=@p_StatusCode,");
			
			strSql.Append("pi_ID=@pi_ID,");
			strSql.Append("pi_Url=@pi_Url,");
			strSql.Append("pi_Type=@pi_Type,");
			strSql.Append("pi_isDel=@pi_isDel,");
			strSql.Append("pi_StatusCode=@pi_StatusCode,");
			strSql.Append("p_MeasurementUnit=@p_MeasurementUnit,");
			strSql.Append("pt_ID=@pt_ID,");
			strSql.Append("pt_Name=@pt_Name,");
			strSql.Append("pt_ParentId=@pt_ParentId,");
			strSql.Append("pt_StatusCode=@pt_StatusCode,");
			strSql.Append("pt_CreatedBy=@pt_CreatedBy,");
			strSql.Append("pt_CreatedOn=@pt_CreatedOn,");
			strSql.Append("pt_IsDel=@pt_IsDel,");
			strSql.Append("pt_ImgUrl=@pt_ImgUrl,");
			
			strSql.Append("p_Province=@p_Province,");
			strSql.Append("p_City=@p_City,");
			strSql.Append("p_County=@p_County,");
			strSql.Append("p_CreatedBy=@p_CreatedBy,");
			strSql.Append("p_CreatedOn=@p_CreatedOn,");
			strSql.Append("b_Key=@b_Key,");
			strSql.Append("b_SiteUrl=@b_SiteUrl,");
			strSql.Append("b_LogoUrl=@b_LogoUrl,");
			strSql.Append("b_Sort=@b_Sort,");
			strSql.Append("b_CreatedOn=@b_CreatedOn,");
			strSql.Append("b_CreatedBy=@b_CreatedBy,");
			strSql.Append("b_StatusCode=@b_StatusCode,");
			strSql.Append("b_IsDel=@b_IsDel,");
			strSql.Append("b_IsTui=@b_IsTui,");
			strSql.Append("b_TuiImg=@b_TuiImg,");
			strSql.Append("shuxing=@shuxing,");
			strSql.Append("pinglun=@pinglun");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@b_ID", SqlDbType.Int,4),
					new SqlParameter("@b_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@p_ID", SqlDbType.Int,4),
					new SqlParameter("@p_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@p_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@p_ModifyBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@p_StatusCode", SqlDbType.SmallInt,2),
					
					new SqlParameter("@pi_ID", SqlDbType.Int,4),
					new SqlParameter("@pi_Url", SqlDbType.VarChar,100),
					new SqlParameter("@pi_Type", SqlDbType.Int,4),
					new SqlParameter("@pi_isDel", SqlDbType.Bit,1),
					new SqlParameter("@pi_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@p_MeasurementUnit", SqlDbType.VarChar,20),
					new SqlParameter("@pt_ID", SqlDbType.Int,4),
					new SqlParameter("@pt_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@pt_ParentId", SqlDbType.Int,4),
					new SqlParameter("@pt_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@pt_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@pt_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@pt_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@pt_ImgUrl", SqlDbType.VarChar,200),
					
					new SqlParameter("@p_Province", SqlDbType.Int,4),
					new SqlParameter("@p_City", SqlDbType.Int,4),
					new SqlParameter("@p_County", SqlDbType.Int,4),
					new SqlParameter("@p_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@p_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@b_Key", SqlDbType.VarChar,20),
					new SqlParameter("@b_SiteUrl", SqlDbType.VarChar,50),
					new SqlParameter("@b_LogoUrl", SqlDbType.VarChar,100),
					new SqlParameter("@b_Sort", SqlDbType.Int,4),
					new SqlParameter("@b_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@b_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@b_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@b_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@b_IsTui", SqlDbType.Bit,1),
					new SqlParameter("@b_TuiImg", SqlDbType.VarBinary,50),
					new SqlParameter("@shuxing", SqlDbType.NVarChar,200),
					new SqlParameter("@pinglun", SqlDbType.Int,4)};
			parameters[0].Value = model.b_ID;
			parameters[1].Value = model.b_Name;
			parameters[2].Value = model.p_ID;
			parameters[3].Value = model.p_Name;
			parameters[4].Value = model.p_ModifyOn;
			parameters[5].Value = model.p_ModifyBy;
			parameters[6].Value = model.p_StatusCode;
			
			parameters[7].Value = model.pi_ID;
			parameters[8].Value = model.pi_Url;
			parameters[9].Value = model.pi_Type;
			parameters[10].Value = model.pi_isDel;
			parameters[11].Value = model.pi_StatusCode;
			parameters[12].Value = model.p_MeasurementUnit;
			parameters[13].Value = model.pt_ID;
			parameters[14].Value = model.pt_Name;
			parameters[15].Value = model.pt_ParentId;
			parameters[16].Value = model.pt_StatusCode;
			parameters[17].Value = model.pt_CreatedBy;
			parameters[28].Value = model.pt_CreatedOn;
			parameters[29].Value = model.pt_IsDel;
			parameters[30].Value = model.pt_ImgUrl;
			
			parameters[31].Value = model.p_Province;
			parameters[32].Value = model.p_City;
			parameters[33].Value = model.p_County;
			parameters[34].Value = model.p_CreatedBy;
			parameters[35].Value = model.p_CreatedOn;
			parameters[36].Value = model.b_Key;
			parameters[37].Value = model.b_SiteUrl;
			parameters[38].Value = model.b_LogoUrl;
			parameters[39].Value = model.b_Sort;
			parameters[40].Value = model.b_CreatedOn;
			parameters[41].Value = model.b_CreatedBy;
			parameters[42].Value = model.b_StatusCode;
			parameters[43].Value = model.b_IsDel;
			parameters[44].Value = model.b_IsTui;
			parameters[45].Value = model.b_TuiImg;
			parameters[46].Value = model.shuxing;
			parameters[47].Value = model.pinglun;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from vw_PInfo ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public webs_YueyxShop.Model.vw_PInfo GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 b_ID,b_Name,p_ID,p_Name,p_ModifyOn,p_ModifyBy,p_StatusCode,p_IsDel,p_SellStatus,pi_ID,pi_Url,pi_Type,pi_isDel,pi_StatusCode,p_MeasurementUnit,pt_ID,pt_Name,pt_ParentId,pt_StatusCode,pt_CreatedBy,pt_CreatedOn,pt_IsDel,pt_ImgUrl,sku_ID,sku_Price,sku_CostPrice,sku_SalesCount,sku_Stock,sku_Code,sku_tdcode,sku_CreatedOn,sku_CreatedBy,sku_ModifyOn,sku_ModifyBy,sku_StatusCode,sku_IsDel,sku_scPric,sku_ismoren,p_Province,p_City,p_County,p_CreatedBy,p_CreatedOn,b_Key,b_SiteUrl,b_LogoUrl,b_Sort,b_CreatedOn,b_CreatedBy,b_StatusCode,b_IsDel,b_IsTui,b_TuiImg,shuxing,pinglun from vw_PInfo ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

            webs_YueyxShop.Model.vw_PInfo model = new webs_YueyxShop.Model.vw_PInfo();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{

               
				if(ds.Tables[0].Rows[0]["b_ID"]!=null && ds.Tables[0].Rows[0]["b_ID"].ToString()!="")
				{
					model.b_ID=int.Parse(ds.Tables[0].Rows[0]["b_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["b_Name"]!=null && ds.Tables[0].Rows[0]["b_Name"].ToString()!="")
				{
					model.b_Name=ds.Tables[0].Rows[0]["b_Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["p_ID"]!=null && ds.Tables[0].Rows[0]["p_ID"].ToString()!="")
				{
					model.p_ID=int.Parse(ds.Tables[0].Rows[0]["p_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["p_Name"]!=null && ds.Tables[0].Rows[0]["p_Name"].ToString()!="")
				{
					model.p_Name=ds.Tables[0].Rows[0]["p_Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["p_ModifyOn"]!=null && ds.Tables[0].Rows[0]["p_ModifyOn"].ToString()!="")
				{
					model.p_ModifyOn=DateTime.Parse(ds.Tables[0].Rows[0]["p_ModifyOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["p_ModifyBy"]!=null && ds.Tables[0].Rows[0]["p_ModifyBy"].ToString()!="")
				{
					model.p_ModifyBy= new Guid(ds.Tables[0].Rows[0]["p_ModifyBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["p_StatusCode"]!=null && ds.Tables[0].Rows[0]["p_StatusCode"].ToString()!="")
				{
					model.p_StatusCode=int.Parse(ds.Tables[0].Rows[0]["p_StatusCode"].ToString());
				}
				if(ds.Tables[0].Rows[0]["p_IsDel"]!=null && ds.Tables[0].Rows[0]["p_IsDel"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["p_IsDel"].ToString()=="1")||(ds.Tables[0].Rows[0]["p_IsDel"].ToString().ToLower()=="true"))
					{
						model.p_IsDel=true;
					}
					else
					{
						model.p_IsDel=false;
					}
				}
				if(ds.Tables[0].Rows[0]["p_SellStatus"]!=null && ds.Tables[0].Rows[0]["p_SellStatus"].ToString()!="")
				{
					model.p_SellStatus=int.Parse(ds.Tables[0].Rows[0]["p_SellStatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pi_ID"]!=null && ds.Tables[0].Rows[0]["pi_ID"].ToString()!="")
				{
					model.pi_ID=int.Parse(ds.Tables[0].Rows[0]["pi_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pi_Url"]!=null && ds.Tables[0].Rows[0]["pi_Url"].ToString()!="")
				{
					model.pi_Url=ds.Tables[0].Rows[0]["pi_Url"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pi_Type"]!=null && ds.Tables[0].Rows[0]["pi_Type"].ToString()!="")
				{
					model.pi_Type=bool.Parse(ds.Tables[0].Rows[0]["pi_Type"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pi_isDel"]!=null && ds.Tables[0].Rows[0]["pi_isDel"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["pi_isDel"].ToString()=="1")||(ds.Tables[0].Rows[0]["pi_isDel"].ToString().ToLower()=="true"))
					{
						model.pi_isDel=true;
					}
					else
					{
						model.pi_isDel=false;
					}
				}
				if(ds.Tables[0].Rows[0]["pi_StatusCode"]!=null && ds.Tables[0].Rows[0]["pi_StatusCode"].ToString()!="")
				{
					model.pi_StatusCode=int.Parse(ds.Tables[0].Rows[0]["pi_StatusCode"].ToString());
				}
				if(ds.Tables[0].Rows[0]["p_MeasurementUnit"]!=null && ds.Tables[0].Rows[0]["p_MeasurementUnit"].ToString()!="")
				{
					model.p_MeasurementUnit=ds.Tables[0].Rows[0]["p_MeasurementUnit"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pt_ID"]!=null && ds.Tables[0].Rows[0]["pt_ID"].ToString()!="")
				{
					model.pt_ID=int.Parse(ds.Tables[0].Rows[0]["pt_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pt_Name"]!=null && ds.Tables[0].Rows[0]["pt_Name"].ToString()!="")
				{
					model.pt_Name=ds.Tables[0].Rows[0]["pt_Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pt_ParentId"]!=null && ds.Tables[0].Rows[0]["pt_ParentId"].ToString()!="")
				{
					model.pt_ParentId=int.Parse(ds.Tables[0].Rows[0]["pt_ParentId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pt_StatusCode"]!=null && ds.Tables[0].Rows[0]["pt_StatusCode"].ToString()!="")
				{
					model.pt_StatusCode=int.Parse(ds.Tables[0].Rows[0]["pt_StatusCode"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pt_CreatedBy"]!=null && ds.Tables[0].Rows[0]["pt_CreatedBy"].ToString()!="")
				{
					model.pt_CreatedBy= new Guid(ds.Tables[0].Rows[0]["pt_CreatedBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pt_CreatedOn"]!=null && ds.Tables[0].Rows[0]["pt_CreatedOn"].ToString()!="")
				{
					model.pt_CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["pt_CreatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pt_IsDel"]!=null && ds.Tables[0].Rows[0]["pt_IsDel"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["pt_IsDel"].ToString()=="1")||(ds.Tables[0].Rows[0]["pt_IsDel"].ToString().ToLower()=="true"))
					{
						model.pt_IsDel=true;
					}
					else
					{
						model.pt_IsDel=false;
					}
				}
				if(ds.Tables[0].Rows[0]["pt_ImgUrl"]!=null && ds.Tables[0].Rows[0]["pt_ImgUrl"].ToString()!="")
				{
					model.pt_ImgUrl=ds.Tables[0].Rows[0]["pt_ImgUrl"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sku_ID"]!=null && ds.Tables[0].Rows[0]["sku_ID"].ToString()!="")
				{
					model.sku_ID=int.Parse(ds.Tables[0].Rows[0]["sku_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sku_Price"]!=null && ds.Tables[0].Rows[0]["sku_Price"].ToString()!="")
				{
					model.sku_Price=decimal.Parse(ds.Tables[0].Rows[0]["sku_Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sku_CostPrice"]!=null && ds.Tables[0].Rows[0]["sku_CostPrice"].ToString()!="")
				{
					model.sku_CostPrice=decimal.Parse(ds.Tables[0].Rows[0]["sku_CostPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sku_SalesCount"]!=null && ds.Tables[0].Rows[0]["sku_SalesCount"].ToString()!="")
				{
					model.sku_SalesCount=int.Parse(ds.Tables[0].Rows[0]["sku_SalesCount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sku_Stock"]!=null && ds.Tables[0].Rows[0]["sku_Stock"].ToString()!="")
				{
					model.sku_Stock=int.Parse(ds.Tables[0].Rows[0]["sku_Stock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sku_Code"]!=null && ds.Tables[0].Rows[0]["sku_Code"].ToString()!="")
				{
					model.sku_Code=ds.Tables[0].Rows[0]["sku_Code"].ToString();
				}
                if (ds.Tables[0].Rows[0]["sku_tdcode"] != null && ds.Tables[0].Rows[0]["sku_tdcode"].ToString() != "")
				{
                    model.sku_tdcode = ds.Tables[0].Rows[0]["sku_tdcode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sku_CreatedOn"]!=null && ds.Tables[0].Rows[0]["sku_CreatedOn"].ToString()!="")
				{
					model.sku_CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["sku_CreatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sku_CreatedBy"]!=null && ds.Tables[0].Rows[0]["sku_CreatedBy"].ToString()!="")
				{
					model.sku_CreatedBy= new Guid(ds.Tables[0].Rows[0]["sku_CreatedBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sku_ModifyOn"]!=null && ds.Tables[0].Rows[0]["sku_ModifyOn"].ToString()!="")
				{
					model.sku_ModifyOn=DateTime.Parse(ds.Tables[0].Rows[0]["sku_ModifyOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sku_ModifyBy"]!=null && ds.Tables[0].Rows[0]["sku_ModifyBy"].ToString()!="")
				{
					model.sku_ModifyBy= new Guid(ds.Tables[0].Rows[0]["sku_ModifyBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sku_StatusCode"]!=null && ds.Tables[0].Rows[0]["sku_StatusCode"].ToString()!="")
				{
					model.sku_StatusCode=int.Parse(ds.Tables[0].Rows[0]["sku_StatusCode"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sku_IsDel"]!=null && ds.Tables[0].Rows[0]["sku_IsDel"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["sku_IsDel"].ToString()=="1")||(ds.Tables[0].Rows[0]["sku_IsDel"].ToString().ToLower()=="true"))
					{
						model.sku_IsDel=true;
					}
					else
					{
						model.sku_IsDel=false;
					}
				}
				if(ds.Tables[0].Rows[0]["sku_ismoren"]!=null && ds.Tables[0].Rows[0]["sku_ismoren"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["sku_ismoren"].ToString()=="1")||(ds.Tables[0].Rows[0]["sku_ismoren"].ToString().ToLower()=="true"))
					{
						model.sku_ismoren=true;
					}
					else
					{
						model.sku_ismoren=false;
					}
				}
				if(ds.Tables[0].Rows[0]["p_Province"]!=null && ds.Tables[0].Rows[0]["p_Province"].ToString()!="")
				{
					model.p_Province=int.Parse(ds.Tables[0].Rows[0]["p_Province"].ToString());
				}
				if(ds.Tables[0].Rows[0]["p_City"]!=null && ds.Tables[0].Rows[0]["p_City"].ToString()!="")
				{
					model.p_City=int.Parse(ds.Tables[0].Rows[0]["p_City"].ToString());
				}
				if(ds.Tables[0].Rows[0]["p_County"]!=null && ds.Tables[0].Rows[0]["p_County"].ToString()!="")
				{
					model.p_County=int.Parse(ds.Tables[0].Rows[0]["p_County"].ToString());
				}
				if(ds.Tables[0].Rows[0]["p_CreatedBy"]!=null && ds.Tables[0].Rows[0]["p_CreatedBy"].ToString()!="")
				{
					model.p_CreatedBy= new Guid(ds.Tables[0].Rows[0]["p_CreatedBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["p_CreatedOn"]!=null && ds.Tables[0].Rows[0]["p_CreatedOn"].ToString()!="")
				{
					model.p_CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["p_CreatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["b_Key"]!=null && ds.Tables[0].Rows[0]["b_Key"].ToString()!="")
				{
					model.b_Key=ds.Tables[0].Rows[0]["b_Key"].ToString();
				}
				if(ds.Tables[0].Rows[0]["b_SiteUrl"]!=null && ds.Tables[0].Rows[0]["b_SiteUrl"].ToString()!="")
				{
					model.b_SiteUrl=ds.Tables[0].Rows[0]["b_SiteUrl"].ToString();
				}
				if(ds.Tables[0].Rows[0]["b_LogoUrl"]!=null && ds.Tables[0].Rows[0]["b_LogoUrl"].ToString()!="")
				{
					model.b_LogoUrl=ds.Tables[0].Rows[0]["b_LogoUrl"].ToString();
				}
				if(ds.Tables[0].Rows[0]["b_Sort"]!=null && ds.Tables[0].Rows[0]["b_Sort"].ToString()!="")
				{
					model.b_Sort=int.Parse(ds.Tables[0].Rows[0]["b_Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["b_CreatedOn"]!=null && ds.Tables[0].Rows[0]["b_CreatedOn"].ToString()!="")
				{
					model.b_CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["b_CreatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["b_CreatedBy"]!=null && ds.Tables[0].Rows[0]["b_CreatedBy"].ToString()!="")
				{
					model.b_CreatedBy= new Guid(ds.Tables[0].Rows[0]["b_CreatedBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["b_StatusCode"]!=null && ds.Tables[0].Rows[0]["b_StatusCode"].ToString()!="")
				{
					model.b_StatusCode=int.Parse(ds.Tables[0].Rows[0]["b_StatusCode"].ToString());
				}
				if(ds.Tables[0].Rows[0]["b_IsDel"]!=null && ds.Tables[0].Rows[0]["b_IsDel"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["b_IsDel"].ToString()=="1")||(ds.Tables[0].Rows[0]["b_IsDel"].ToString().ToLower()=="true"))
					{
						model.b_IsDel=true;
					}
					else
					{
						model.b_IsDel=false;
					}
				}
				if(ds.Tables[0].Rows[0]["b_IsTui"]!=null && ds.Tables[0].Rows[0]["b_IsTui"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["b_IsTui"].ToString()=="1")||(ds.Tables[0].Rows[0]["b_IsTui"].ToString().ToLower()=="true"))
					{
						model.b_IsTui=true;
					}
					else
					{
						model.b_IsTui=false;
					}
				}
				if(ds.Tables[0].Rows[0]["b_TuiImg"]!=null && ds.Tables[0].Rows[0]["b_TuiImg"].ToString()!="")
				{
					model.b_TuiImg=(byte[])ds.Tables[0].Rows[0]["b_TuiImg"];
				}
				if(ds.Tables[0].Rows[0]["shuxing"]!=null && ds.Tables[0].Rows[0]["shuxing"].ToString()!="")
				{
					model.shuxing=ds.Tables[0].Rows[0]["shuxing"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pinglun"]!=null && ds.Tables[0].Rows[0]["pinglun"].ToString()!="")
				{
					model.pinglun=int.Parse(ds.Tables[0].Rows[0]["pinglun"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select b_ID,b_Name,p_ID,p_Name,p_ModifyOn,p_ModifyBy,p_StatusCode,p_IsDel,p_SellStatus,pi_ID,pi_Url,pi_Type,pi_isDel,pi_StatusCode,p_MeasurementUnit,pt_ID,pt_Name,pt_ParentId,pt_StatusCode,pt_CreatedBy,pt_CreatedOn,pt_IsDel,pt_ImgUrl,sku_ID,sku_Price,sku_CostPrice,sku_SalesCount,sku_Stock,sku_Code,sku_tdcode,sku_CreatedOn,sku_CreatedBy,sku_ModifyOn,sku_ModifyBy,sku_StatusCode,sku_IsDel,sku_scPric,sku_ismoren,p_Province,p_City,p_County,p_CreatedBy,p_CreatedOn,b_Key,b_SiteUrl,b_LogoUrl,b_Sort,b_CreatedOn,b_CreatedBy,b_StatusCode,b_IsDel,b_IsTui,b_TuiImg,shuxing,pinglun ");
			strSql.Append(" FROM vw_PInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet getmodelListPH()
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select *,(select sum(os_pCount) from orderskudetail where sku_Id =vw_PInfo.sku_ID and o_id in (select o_ID from orderbase where o_StatusCode>0)) as skucount from vw_PInfo where  EXISTS  (select top 8 sku_ID,(select sum(os_pCount) from orderskudetail where sku_Id =vw_PInfo.sku_ID and o_id in (select o_ID from orderbase where o_StatusCode>0)) as skucount  from skubase  where sku_IsDel=0 and p_Id in(select p_Id from productbase where p_IsDel=0)) order by skucount desc");
			return DbHelperSQL.Query(strSql.ToString());
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" b_ID,b_Name,p_ID,p_Name,p_ModifyOn,p_ModifyBy,p_StatusCode,p_IsDel,p_SellStatus,pi_ID,pi_Url,pi_Type,pi_isDel,pi_StatusCode,p_MeasurementUnit,pt_ID,pt_Name,pt_ParentId,pt_StatusCode,pt_CreatedBy,pt_CreatedOn,pt_IsDel,pt_ImgUrl,sku_ID,sku_Price,sku_CostPrice,sku_SalesCount,sku_Stock,sku_Code,sku_CreatedOn,sku_CreatedBy,sku_ModifyOn,sku_ModifyBy,sku_StatusCode,sku_IsDel,sku_scPric,sku_ismoren,p_Province,p_City,p_County,p_CreatedBy,p_CreatedOn,b_Key,b_SiteUrl,b_LogoUrl,b_Sort,b_CreatedOn,b_CreatedBy,b_StatusCode,b_IsDel,b_IsTui,b_TuiImg,shuxing,pinglun ");
			strSql.Append(" FROM vw_PInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获取数据分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="page"></param>
        /// <param name="pagerows"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere, int page, int pagerows,string sort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pagerows + " * ");
            strSql.Append(" FROM vw_PInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + " and sku_id not in (select top " + (page - 1) * pagerows + " sku_id from vw_PInfo where " + strWhere + ") " + sort);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取数据分页 与收藏联合查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="page"></param>
        /// <param name="pagerows"></param>
        /// <returns></returns>
        public DataSet GetListVC(string strWhere, int page, int pagerows, string sort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pagerows + " *,vc.vc_id,vc.vc_CreateOn,vc.vc_IsDel ");
            strSql.Append(" FROM VipCollectionBase vc,vw_PInfo vw ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + " and p_id not in (select top " + (page - 1) * pagerows + " p_id from VipCollectionBase vc,vw_PInfo vw where " + strWhere + " order by p_id) " + sort);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取数据分页 与评论联合查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="page"></param>
        /// <param name="pagerows"></param>
        /// <returns></returns>
        public DataSet GetListPA(string strWhere, int page, int pagerows, string sort)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pagerows + " *,pa.pa_Satisfied,pa.pa_Content,pa.pa_id,pa.pa_CreatedOn,pa.pa_IsDel ");
            strSql.Append(" FROM ProductAppraiseBase pa,vw_PInfo vw ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + " and  pa.pa_ID  not in (select top " + (page - 1) * pagerows + "  pa.pa_ID  from ProductAppraiseBase pa,vw_PInfo vw where " + strWhere + " order by pa.pa_ID ) " + sort);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取数据分页 与收藏联合查询(收藏人数)
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="page"></param>
        /// <param name="pagerows"></param>
        /// <returns></returns>
        public DataSet getguanzhu(string strWhere, int page, int pagerows) 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pagerows + " *,(select count(m_Id) from VipCollectionBase where sku_ID = vw_PInfo.sku_ID) gz ");
            strSql.Append(" FROM vw_PInfo  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + " and sku_id not in (select top " + (page - 1) * pagerows + " sku_id from VipCollectionBase  where " + strWhere + " order by p_id) ");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM vw_PInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from vw_PInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "vw_PInfo";
			parameters[1].Value = "";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

