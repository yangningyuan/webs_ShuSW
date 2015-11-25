/**  版本信息模板在安装目录下，可自行修改。
* vm_GBDetails.cs
*
* 功 能： N/A
* 类 名： vm_GBDetails
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/21 11:14:06   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using webs_YueyxShop.IDAL;
using DBUtility;//Please add references
namespace webs_YueyxShop.DAL
{
	/// <summary>
	/// 数据访问类:vm_GBDetails
	/// </summary>
	public partial class vm_GBDetails:Ivm_GBDetails
	{
		public vm_GBDetails()
		{}
		#region  BasicMethod

        

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(webs_YueyxShop.Model.vm_GBDetails model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into vm_GBDetails(");
			strSql.Append("p_ID,pt_ID,p_Name,p_Sort,p_MeasurementUnit,p_Province,p_City,p_County,p_CreatedOn,p_CreatedBy,p_ModifyOn,p_ModifyBy,p_StatusCode,p_IsDel,p_SellStatus,ct_ID,pi_Url,gp_StartTime,gp_EndTime,gp_pCount,gp_pPric,sku_Price,sku_CostPrice,sku_SalesCount,sku_Stock,sku_IsDel,sku_ismoren,sku_Code,sku_ID,shuxing,b_ID,gp_IsDel,gp_StatusCode,gp_Logo,gp_Slogan,gp_SaleCount)");
			strSql.Append(" values (");
			strSql.Append("@p_ID,@pt_ID,@p_Name,@p_Sort,@p_MeasurementUnit,@p_Province,@p_City,@p_County,@p_CreatedOn,@p_CreatedBy,@p_ModifyOn,@p_ModifyBy,@p_StatusCode,@p_IsDel,@p_SellStatus,@ct_ID,@pi_Url,@gp_StartTime,@gp_EndTime,@gp_pCount,@gp_pPric,@sku_Price,@sku_CostPrice,@sku_SalesCount,@sku_Stock,@sku_IsDel,@sku_ismoren,@sku_Code,@sku_ID,@shuxing,@b_ID,@gp_IsDel,@gp_StatusCode,@gp_Logo,@gp_Slogan,@gp_SaleCount)");
			SqlParameter[] parameters = {
					new SqlParameter("@p_ID", SqlDbType.Int,4),
					new SqlParameter("@pt_ID", SqlDbType.Int,4),
					new SqlParameter("@p_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@p_Sort", SqlDbType.Int,4),
					new SqlParameter("@p_MeasurementUnit", SqlDbType.VarChar,20),
					new SqlParameter("@p_Province", SqlDbType.Int,4),
					new SqlParameter("@p_City", SqlDbType.Int,4),
					new SqlParameter("@p_County", SqlDbType.Int,4),
					new SqlParameter("@p_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@p_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@p_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@p_ModifyBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@p_StatusCode", SqlDbType.SmallInt,2),
					new SqlParameter("@p_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@p_SellStatus", SqlDbType.Int,4),
					new SqlParameter("@ct_ID", SqlDbType.Int,4),
					new SqlParameter("@pi_Url", SqlDbType.VarChar,100),
					new SqlParameter("@gp_StartTime", SqlDbType.DateTime),
					new SqlParameter("@gp_EndTime", SqlDbType.DateTime),
					new SqlParameter("@gp_pCount", SqlDbType.Int,4),
					new SqlParameter("@gp_pPric", SqlDbType.Decimal,5),
					new SqlParameter("@sku_Price", SqlDbType.Decimal,5),
					new SqlParameter("@sku_CostPrice", SqlDbType.Decimal,5),
					new SqlParameter("@sku_SalesCount", SqlDbType.Int,4),
					new SqlParameter("@sku_Stock", SqlDbType.Int,4),
					new SqlParameter("@sku_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@sku_ismoren", SqlDbType.Bit,1),
					new SqlParameter("@sku_Code", SqlDbType.VarChar,30),
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@shuxing", SqlDbType.NVarChar,200),
					new SqlParameter("@b_ID", SqlDbType.Int,4),
					new SqlParameter("@gp_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@gp_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@gp_Logo", SqlDbType.NVarChar,20),
					new SqlParameter("@gp_Slogan", SqlDbType.NVarChar,200),
					new SqlParameter("@gp_SaleCount", SqlDbType.Int,4)};
			parameters[0].Value = model.p_ID;
			parameters[1].Value = model.pt_ID;
			parameters[2].Value = model.p_Name;
			parameters[3].Value = model.p_Sort;
			parameters[4].Value = model.p_MeasurementUnit;
			parameters[5].Value = model.p_Province;
			parameters[6].Value = model.p_City;
			parameters[7].Value = model.p_County;
			parameters[8].Value = model.p_CreatedOn;
			parameters[9].Value = Guid.NewGuid();
			parameters[10].Value = model.p_ModifyOn;
			parameters[11].Value = Guid.NewGuid();
			parameters[12].Value = model.p_StatusCode;
			parameters[13].Value = model.p_IsDel;
			parameters[14].Value = model.p_SellStatus;
			parameters[15].Value = model.ct_ID;
			parameters[16].Value = model.pi_Url;
			parameters[17].Value = model.gp_StartTime;
			parameters[18].Value = model.gp_EndTime;
			parameters[19].Value = model.gp_pCount;
			parameters[20].Value = model.gp_pPric;
			parameters[21].Value = model.sku_Price;
			parameters[22].Value = model.sku_CostPrice;
			parameters[23].Value = model.sku_SalesCount;
			parameters[24].Value = model.sku_Stock;
			parameters[25].Value = model.sku_IsDel;
			parameters[26].Value = model.sku_ismoren;
			parameters[27].Value = model.sku_Code;
			parameters[28].Value = model.sku_ID;
			parameters[29].Value = model.shuxing;
			parameters[30].Value = model.b_ID;
			parameters[31].Value = model.gp_IsDel;
			parameters[32].Value = model.gp_StatusCode;
			parameters[33].Value = model.gp_Logo;
			parameters[34].Value = model.gp_Slogan;
			parameters[35].Value = model.gp_SaleCount;

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
		public bool Update(webs_YueyxShop.Model.vm_GBDetails model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update vm_GBDetails set ");
			strSql.Append("p_ID=@p_ID,");
			strSql.Append("pt_ID=@pt_ID,");
			strSql.Append("p_Name=@p_Name,");
			strSql.Append("p_Sort=@p_Sort,");
			strSql.Append("p_MeasurementUnit=@p_MeasurementUnit,");
			strSql.Append("p_Province=@p_Province,");
			strSql.Append("p_City=@p_City,");
			strSql.Append("p_County=@p_County,");
			strSql.Append("p_CreatedOn=@p_CreatedOn,");
			strSql.Append("p_CreatedBy=@p_CreatedBy,");
			strSql.Append("p_ModifyOn=@p_ModifyOn,");
			strSql.Append("p_ModifyBy=@p_ModifyBy,");
			strSql.Append("p_StatusCode=@p_StatusCode,");
			strSql.Append("p_IsDel=@p_IsDel,");
			strSql.Append("p_SellStatus=@p_SellStatus,");
			strSql.Append("ct_ID=@ct_ID,");
			strSql.Append("pi_Url=@pi_Url,");
			strSql.Append("gp_StartTime=@gp_StartTime,");
			strSql.Append("gp_EndTime=@gp_EndTime,");
			strSql.Append("gp_pCount=@gp_pCount,");
			strSql.Append("gp_pPric=@gp_pPric,");
			strSql.Append("sku_Price=@sku_Price,");
			strSql.Append("sku_CostPrice=@sku_CostPrice,");
			strSql.Append("sku_SalesCount=@sku_SalesCount,");
			strSql.Append("sku_Stock=@sku_Stock,");
			strSql.Append("sku_IsDel=@sku_IsDel,");
			strSql.Append("sku_ismoren=@sku_ismoren,");
			strSql.Append("sku_Code=@sku_Code,");
			strSql.Append("sku_ID=@sku_ID,");
			strSql.Append("shuxing=@shuxing,");
			strSql.Append("b_ID=@b_ID,");
			strSql.Append("gp_IsDel=@gp_IsDel,");
			strSql.Append("gp_StatusCode=@gp_StatusCode,");
			strSql.Append("gp_Logo=@gp_Logo,");
			strSql.Append("gp_Slogan=@gp_Slogan,");
			strSql.Append("gp_SaleCount=@gp_SaleCount");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@p_ID", SqlDbType.Int,4),
					new SqlParameter("@pt_ID", SqlDbType.Int,4),
					new SqlParameter("@p_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@p_Sort", SqlDbType.Int,4),
					new SqlParameter("@p_MeasurementUnit", SqlDbType.VarChar,20),
					new SqlParameter("@p_Province", SqlDbType.Int,4),
					new SqlParameter("@p_City", SqlDbType.Int,4),
					new SqlParameter("@p_County", SqlDbType.Int,4),
					new SqlParameter("@p_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@p_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@p_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@p_ModifyBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@p_StatusCode", SqlDbType.SmallInt,2),
					new SqlParameter("@p_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@p_SellStatus", SqlDbType.Int,4),
					new SqlParameter("@ct_ID", SqlDbType.Int,4),
					new SqlParameter("@pi_Url", SqlDbType.VarChar,100),
					new SqlParameter("@gp_StartTime", SqlDbType.DateTime),
					new SqlParameter("@gp_EndTime", SqlDbType.DateTime),
					new SqlParameter("@gp_pCount", SqlDbType.Int,4),
					new SqlParameter("@gp_pPric", SqlDbType.Decimal,5),
					new SqlParameter("@sku_Price", SqlDbType.Decimal,5),
					new SqlParameter("@sku_CostPrice", SqlDbType.Decimal,5),
					new SqlParameter("@sku_SalesCount", SqlDbType.Int,4),
					new SqlParameter("@sku_Stock", SqlDbType.Int,4),
					new SqlParameter("@sku_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@sku_ismoren", SqlDbType.Bit,1),
					new SqlParameter("@sku_Code", SqlDbType.VarChar,30),
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@shuxing", SqlDbType.NVarChar,200),
					new SqlParameter("@b_ID", SqlDbType.Int,4),
					new SqlParameter("@gp_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@gp_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@gp_Logo", SqlDbType.NVarChar,20),
					new SqlParameter("@gp_Slogan", SqlDbType.NVarChar,200),
					new SqlParameter("@gp_SaleCount", SqlDbType.Int,4)};
			parameters[0].Value = model.p_ID;
			parameters[1].Value = model.pt_ID;
			parameters[2].Value = model.p_Name;
			parameters[3].Value = model.p_Sort;
			parameters[4].Value = model.p_MeasurementUnit;
			parameters[5].Value = model.p_Province;
			parameters[6].Value = model.p_City;
			parameters[7].Value = model.p_County;
			parameters[8].Value = model.p_CreatedOn;
			parameters[9].Value = model.p_CreatedBy;
			parameters[10].Value = model.p_ModifyOn;
			parameters[11].Value = model.p_ModifyBy;
			parameters[12].Value = model.p_StatusCode;
			parameters[13].Value = model.p_IsDel;
			parameters[14].Value = model.p_SellStatus;
			parameters[15].Value = model.ct_ID;
			parameters[16].Value = model.pi_Url;
			parameters[17].Value = model.gp_StartTime;
			parameters[18].Value = model.gp_EndTime;
			parameters[19].Value = model.gp_pCount;
			parameters[20].Value = model.gp_pPric;
			parameters[21].Value = model.sku_Price;
			parameters[22].Value = model.sku_CostPrice;
			parameters[23].Value = model.sku_SalesCount;
			parameters[24].Value = model.sku_Stock;
			parameters[25].Value = model.sku_IsDel;
			parameters[26].Value = model.sku_ismoren;
			parameters[27].Value = model.sku_Code;
			parameters[28].Value = model.sku_ID;
			parameters[29].Value = model.shuxing;
			parameters[30].Value = model.b_ID;
			parameters[31].Value = model.gp_IsDel;
			parameters[32].Value = model.gp_StatusCode;
			parameters[33].Value = model.gp_Logo;
			parameters[34].Value = model.gp_Slogan;
			parameters[35].Value = model.gp_SaleCount;

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
			strSql.Append("delete from vm_GBDetails ");
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
		public webs_YueyxShop.Model.vm_GBDetails GetModel(int pid)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 * from vm_GBDetails ");
			strSql.Append(" where gp_ID="+pid);
			
			webs_YueyxShop.Model.vm_GBDetails model=new webs_YueyxShop.Model.vm_GBDetails();
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public webs_YueyxShop.Model.vm_GBDetails DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.vm_GBDetails model=new webs_YueyxShop.Model.vm_GBDetails();
			if (row != null)
			{
                if (row["gp_ID"] != null && row["gp_ID"].ToString() != "")
                {
                    model.gp_ID = int.Parse(row["gp_ID"].ToString());
                }
				if(row["p_ID"]!=null && row["p_ID"].ToString()!="")
				{
					model.p_ID=int.Parse(row["p_ID"].ToString());
				}
				if(row["pt_ID"]!=null && row["pt_ID"].ToString()!="")
				{
					model.pt_ID=int.Parse(row["pt_ID"].ToString());
				}
				if(row["p_Name"]!=null)
				{
					model.p_Name=row["p_Name"].ToString();
				}
				if(row["p_Sort"]!=null && row["p_Sort"].ToString()!="")
				{
					model.p_Sort=int.Parse(row["p_Sort"].ToString());
				}
				if(row["p_MeasurementUnit"]!=null)
				{
					model.p_MeasurementUnit=row["p_MeasurementUnit"].ToString();
				}
				if(row["p_Province"]!=null && row["p_Province"].ToString()!="")
				{
					model.p_Province=int.Parse(row["p_Province"].ToString());
				}
				if(row["p_City"]!=null && row["p_City"].ToString()!="")
				{
					model.p_City=int.Parse(row["p_City"].ToString());
				}
				if(row["p_County"]!=null && row["p_County"].ToString()!="")
				{
					model.p_County=int.Parse(row["p_County"].ToString());
				}
				if(row["p_CreatedOn"]!=null && row["p_CreatedOn"].ToString()!="")
				{
					model.p_CreatedOn=DateTime.Parse(row["p_CreatedOn"].ToString());
				}
				if(row["p_CreatedBy"]!=null && row["p_CreatedBy"].ToString()!="")
				{
					model.p_CreatedBy= new Guid(row["p_CreatedBy"].ToString());
				}
				if(row["p_ModifyOn"]!=null && row["p_ModifyOn"].ToString()!="")
				{
					model.p_ModifyOn=DateTime.Parse(row["p_ModifyOn"].ToString());
				}
				if(row["p_ModifyBy"]!=null && row["p_ModifyBy"].ToString()!="")
				{
					model.p_ModifyBy= new Guid(row["p_ModifyBy"].ToString());
				}
				if(row["p_StatusCode"]!=null && row["p_StatusCode"].ToString()!="")
				{
					model.p_StatusCode=int.Parse(row["p_StatusCode"].ToString());
				}
				if(row["p_IsDel"]!=null && row["p_IsDel"].ToString()!="")
				{
					if((row["p_IsDel"].ToString()=="1")||(row["p_IsDel"].ToString().ToLower()=="true"))
					{
						model.p_IsDel=true;
					}
					else
					{
						model.p_IsDel=false;
					}
				}
				if(row["p_SellStatus"]!=null && row["p_SellStatus"].ToString()!="")
				{
					model.p_SellStatus=int.Parse(row["p_SellStatus"].ToString());
				}
				if(row["ct_ID"]!=null && row["ct_ID"].ToString()!="")
				{
					model.ct_ID=int.Parse(row["ct_ID"].ToString());
				}
				if(row["pi_Url"]!=null)
				{
					model.pi_Url=row["pi_Url"].ToString();
				}
				if(row["gp_StartTime"]!=null && row["gp_StartTime"].ToString()!="")
				{
					model.gp_StartTime=DateTime.Parse(row["gp_StartTime"].ToString());
				}
				if(row["gp_EndTime"]!=null && row["gp_EndTime"].ToString()!="")
				{
					model.gp_EndTime=DateTime.Parse(row["gp_EndTime"].ToString());
				}
				if(row["gp_pCount"]!=null && row["gp_pCount"].ToString()!="")
				{
					model.gp_pCount=int.Parse(row["gp_pCount"].ToString());
				}
				if(row["gp_pPric"]!=null && row["gp_pPric"].ToString()!="")
				{
					model.gp_pPric=decimal.Parse(row["gp_pPric"].ToString());
				}
				if(row["sku_Price"]!=null && row["sku_Price"].ToString()!="")
				{
					model.sku_Price=decimal.Parse(row["sku_Price"].ToString());
				}
				if(row["sku_CostPrice"]!=null && row["sku_CostPrice"].ToString()!="")
				{
					model.sku_CostPrice=decimal.Parse(row["sku_CostPrice"].ToString());
				}
                if (row["sku_scPric"] != null && row["sku_scPric"].ToString() != "")
				{
                    model.sku_scPrice = decimal.Parse(row["sku_scPric"].ToString());
				}
				if(row["sku_SalesCount"]!=null && row["sku_SalesCount"].ToString()!="")
				{
					model.sku_SalesCount=int.Parse(row["sku_SalesCount"].ToString());
				}
				if(row["sku_Stock"]!=null && row["sku_Stock"].ToString()!="")
				{
					model.sku_Stock=int.Parse(row["sku_Stock"].ToString());
				}
				if(row["sku_IsDel"]!=null && row["sku_IsDel"].ToString()!="")
				{
					if((row["sku_IsDel"].ToString()=="1")||(row["sku_IsDel"].ToString().ToLower()=="true"))
					{
						model.sku_IsDel=true;
					}
					else
					{
						model.sku_IsDel=false;
					}
				}
				if(row["sku_ismoren"]!=null && row["sku_ismoren"].ToString()!="")
				{
					if((row["sku_ismoren"].ToString()=="1")||(row["sku_ismoren"].ToString().ToLower()=="true"))
					{
						model.sku_ismoren=true;
					}
					else
					{
						model.sku_ismoren=false;
					}
				}
				if(row["sku_Code"]!=null)
				{
					model.sku_Code=row["sku_Code"].ToString();
				}
				if(row["sku_ID"]!=null && row["sku_ID"].ToString()!="")
				{
					model.sku_ID=int.Parse(row["sku_ID"].ToString());
				}
				if(row["shuxing"]!=null)
				{
					model.shuxing=row["shuxing"].ToString();
				}
				if(row["b_ID"]!=null && row["b_ID"].ToString()!="")
				{
					model.b_ID=int.Parse(row["b_ID"].ToString());
				}
				if(row["gp_IsDel"]!=null && row["gp_IsDel"].ToString()!="")
				{
					if((row["gp_IsDel"].ToString()=="1")||(row["gp_IsDel"].ToString().ToLower()=="true"))
					{
						model.gp_IsDel=true;
					}
					else
					{
						model.gp_IsDel=false;
					}
				}
				if(row["gp_StatusCode"]!=null && row["gp_StatusCode"].ToString()!="")
				{
					model.gp_StatusCode=int.Parse(row["gp_StatusCode"].ToString());
				}
				if(row["gp_Logo"]!=null)
				{
					model.gp_Logo=row["gp_Logo"].ToString();
				}
				if(row["gp_Slogan"]!=null)
				{
					model.gp_Slogan=row["gp_Slogan"].ToString();
				}
				if(row["gp_SaleCount"]!=null && row["gp_SaleCount"].ToString()!="")
				{
					model.gp_SaleCount=int.Parse(row["gp_SaleCount"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM vm_GBDetails ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 获取数据分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="page"></param>
        /// <param name="pagerows"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere,int page,int pagerows)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top "+pagerows+" * ");
            strSql.Append(" FROM vm_GBDetails ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + " and gp_id not in (select top " + (page - 1) * pagerows + " gp_id from vm_GBDetails where "+strWhere+" order by gp_id)  order by gp_id");
            }
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
			strSql.Append(" * ");
			strSql.Append(" FROM vm_GBDetails ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM vm_GBDetails ");
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
			strSql.Append(")AS Row, T.*  from vm_GBDetails T ");
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
			parameters[0].Value = "vm_GBDetails";
			parameters[1].Value = "";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

