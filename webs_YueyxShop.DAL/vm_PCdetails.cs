/**  版本信息模板在安装目录下，可自行修改。
* vm_PCdetails.cs
*
* 功 能： N/A
* 类 名： vm_PCdetails
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/19 13:53:58   N/A    初版
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
	/// 数据访问类:vm_PCdetails
	/// </summary>
	public partial class vm_PCdetails:Ivm_PCdetails
	{
		public vm_PCdetails()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(webs_YueyxShop.Model.vm_PCdetails model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into vm_PCdetails(");
			strSql.Append("m_UserName,m_NickName,m_RealName,sku_ModifyBy,p_ID,sku_Price,sku_CostPrice,sku_Stock,sku_SalesCount,sku_Code,sku_CreatedOn,sku_CreatedBy,sku_ModifyOn,sku_StatusCode,sku_IsDel,p_Name,p_Sort,p_MeasurementUnit,p_Province,p_City,p_County,p_CreatedOn,p_ModifyOn,p_CreatedBy,p_ModifyBy,p_StatusCode,p_IsDel,p_SellStatus,ct_ID,pt_ID,m_Password,m_UserType,m_YingYZZ,m_Score,m_Rank,m_Sex,m_Birthday,m_Phone,m_Email,m_QQ,m_CreatedOn,m_ZheK,m_StatusCode,m_ShenPstatus,pc_ID,sku_ID,pc_CreatedOn,pc_Type,pc_Content,pc_CreatedBy,pc_StatusCode,pc_IsDel)");
			strSql.Append(" values (");
			strSql.Append("@m_UserName,@m_NickName,@m_RealName,@sku_ModifyBy,@p_ID,@sku_Price,@sku_CostPrice,@sku_Stock,@sku_SalesCount,@sku_Code,@sku_CreatedOn,@sku_CreatedBy,@sku_ModifyOn,@sku_StatusCode,@sku_IsDel,@p_Name,@p_Sort,@p_MeasurementUnit,@p_Province,@p_City,@p_County,@p_CreatedOn,@p_ModifyOn,@p_CreatedBy,@p_ModifyBy,@p_StatusCode,@p_IsDel,@p_SellStatus,@ct_ID,@pt_ID,@m_Password,@m_UserType,@m_YingYZZ,@m_Score,@m_Rank,@m_Sex,@m_Birthday,@m_Phone,@m_Email,@m_QQ,@m_CreatedOn,@m_ZheK,@m_StatusCode,@m_ShenPstatus,@pc_ID,@sku_ID,@pc_CreatedOn,@pc_Type,@pc_Content,@pc_CreatedBy,@pc_StatusCode,@pc_IsDel)");
			SqlParameter[] parameters = {
					new SqlParameter("@m_UserName", SqlDbType.VarChar,50),
					new SqlParameter("@m_NickName", SqlDbType.NVarChar,30),
					new SqlParameter("@m_RealName", SqlDbType.NVarChar,20),
					new SqlParameter("@sku_ModifyBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@p_ID", SqlDbType.Int,4),
					new SqlParameter("@sku_Price", SqlDbType.Decimal,5),
					new SqlParameter("@sku_CostPrice", SqlDbType.Decimal,5),
					new SqlParameter("@sku_Stock", SqlDbType.Int,4),
					new SqlParameter("@sku_SalesCount", SqlDbType.Int,4),
					new SqlParameter("@sku_Code", SqlDbType.VarChar,30),
					new SqlParameter("@sku_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@sku_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@sku_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@sku_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@sku_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@p_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@p_Sort", SqlDbType.Int,4),
					new SqlParameter("@p_MeasurementUnit", SqlDbType.VarChar,20),
					new SqlParameter("@p_Province", SqlDbType.Int,4),
					new SqlParameter("@p_City", SqlDbType.Int,4),
					new SqlParameter("@p_County", SqlDbType.Int,4),
					new SqlParameter("@p_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@p_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@p_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@p_ModifyBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@p_StatusCode", SqlDbType.SmallInt,2),
					new SqlParameter("@p_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@p_SellStatus", SqlDbType.Int,4),
					new SqlParameter("@ct_ID", SqlDbType.Int,4),
					new SqlParameter("@pt_ID", SqlDbType.Int,4),
					new SqlParameter("@m_Password", SqlDbType.VarChar,100),
					new SqlParameter("@m_UserType", SqlDbType.Int,4),
					new SqlParameter("@m_YingYZZ", SqlDbType.NVarChar,30),
					new SqlParameter("@m_Score", SqlDbType.Int,4),
					new SqlParameter("@m_Rank", SqlDbType.Int,4),
					new SqlParameter("@m_Sex", SqlDbType.Int,4),
					new SqlParameter("@m_Birthday", SqlDbType.DateTime),
					new SqlParameter("@m_Phone", SqlDbType.VarChar,50),
					new SqlParameter("@m_Email", SqlDbType.VarChar,100),
					new SqlParameter("@m_QQ", SqlDbType.VarChar,30),
					new SqlParameter("@m_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@m_ZheK", SqlDbType.Decimal,9),
					new SqlParameter("@m_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@m_ShenPstatus", SqlDbType.Int,4),
					new SqlParameter("@pc_ID", SqlDbType.Int,4),
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@pc_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@pc_Type", SqlDbType.VarChar,30),
					new SqlParameter("@pc_Content", SqlDbType.NVarChar,500),
					new SqlParameter("@pc_CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@pc_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@pc_IsDel", SqlDbType.Bit,1)};
			parameters[0].Value = model.m_UserName;
			parameters[1].Value = model.m_NickName;
			parameters[2].Value = model.m_RealName;
			parameters[3].Value = Guid.NewGuid();
			parameters[4].Value = model.p_ID;
			parameters[5].Value = model.sku_Price;
			parameters[6].Value = model.sku_CostPrice;
			parameters[7].Value = model.sku_Stock;
			parameters[8].Value = model.sku_SalesCount;
			parameters[9].Value = model.sku_Code;
			parameters[10].Value = model.sku_CreatedOn;
			parameters[11].Value = Guid.NewGuid();
			parameters[12].Value = model.sku_ModifyOn;
			parameters[13].Value = model.sku_StatusCode;
			parameters[14].Value = model.sku_IsDel;
			parameters[15].Value = model.p_Name;
			parameters[16].Value = model.p_Sort;
			parameters[17].Value = model.p_MeasurementUnit;
			parameters[18].Value = model.p_Province;
			parameters[19].Value = model.p_City;
			parameters[20].Value = model.p_County;
			parameters[21].Value = model.p_CreatedOn;
			parameters[22].Value = model.p_ModifyOn;
			parameters[23].Value = Guid.NewGuid();
			parameters[24].Value = Guid.NewGuid();
			parameters[25].Value = model.p_StatusCode;
			parameters[26].Value = model.p_IsDel;
			parameters[27].Value = model.p_SellStatus;
			parameters[28].Value = model.ct_ID;
			parameters[29].Value = model.pt_ID;
			parameters[30].Value = model.m_Password;
			parameters[31].Value = model.m_UserType;
			parameters[32].Value = model.m_YingYZZ;
			parameters[33].Value = model.m_Score;
			parameters[34].Value = model.m_Rank;
			parameters[35].Value = model.m_Sex;
			parameters[36].Value = model.m_Birthday;
			parameters[37].Value = model.m_Phone;
			parameters[38].Value = model.m_Email;
			parameters[39].Value = model.m_QQ;
			parameters[40].Value = model.m_CreatedOn;
			parameters[41].Value = model.m_ZheK;
			parameters[42].Value = model.m_StatusCode;
			parameters[43].Value = model.m_ShenPstatus;
			parameters[44].Value = model.pc_ID;
			parameters[45].Value = model.sku_ID;
			parameters[46].Value = model.pc_CreatedOn;
			parameters[47].Value = model.pc_Type;
			parameters[48].Value = model.pc_Content;
			parameters[49].Value = model.pc_CreatedBy;
			parameters[50].Value = model.pc_StatusCode;
			parameters[51].Value = model.pc_IsDel;

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
		public bool Update(webs_YueyxShop.Model.vm_PCdetails model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update vm_PCdetails set ");
			strSql.Append("m_UserName=@m_UserName,");
			strSql.Append("m_NickName=@m_NickName,");
			strSql.Append("m_RealName=@m_RealName,");
			strSql.Append("sku_ModifyBy=@sku_ModifyBy,");
			strSql.Append("p_ID=@p_ID,");
			strSql.Append("sku_Price=@sku_Price,");
			strSql.Append("sku_CostPrice=@sku_CostPrice,");
			strSql.Append("sku_Stock=@sku_Stock,");
			strSql.Append("sku_SalesCount=@sku_SalesCount,");
			strSql.Append("sku_Code=@sku_Code,");
			strSql.Append("sku_CreatedOn=@sku_CreatedOn,");
			strSql.Append("sku_CreatedBy=@sku_CreatedBy,");
			strSql.Append("sku_ModifyOn=@sku_ModifyOn,");
			strSql.Append("sku_StatusCode=@sku_StatusCode,");
			strSql.Append("sku_IsDel=@sku_IsDel,");
			strSql.Append("p_Name=@p_Name,");
			strSql.Append("p_Sort=@p_Sort,");
			strSql.Append("p_MeasurementUnit=@p_MeasurementUnit,");
			strSql.Append("p_Province=@p_Province,");
			strSql.Append("p_City=@p_City,");
			strSql.Append("p_County=@p_County,");
			strSql.Append("p_CreatedOn=@p_CreatedOn,");
			strSql.Append("p_ModifyOn=@p_ModifyOn,");
			strSql.Append("p_CreatedBy=@p_CreatedBy,");
			strSql.Append("p_ModifyBy=@p_ModifyBy,");
			strSql.Append("p_StatusCode=@p_StatusCode,");
			strSql.Append("p_IsDel=@p_IsDel,");
			strSql.Append("p_SellStatus=@p_SellStatus,");
			strSql.Append("ct_ID=@ct_ID,");
			strSql.Append("pt_ID=@pt_ID,");
			strSql.Append("m_Password=@m_Password,");
			strSql.Append("m_UserType=@m_UserType,");
			strSql.Append("m_YingYZZ=@m_YingYZZ,");
			strSql.Append("m_Score=@m_Score,");
			strSql.Append("m_Rank=@m_Rank,");
			strSql.Append("m_Sex=@m_Sex,");
			strSql.Append("m_Birthday=@m_Birthday,");
			strSql.Append("m_Phone=@m_Phone,");
			strSql.Append("m_Email=@m_Email,");
			strSql.Append("m_QQ=@m_QQ,");
			strSql.Append("m_CreatedOn=@m_CreatedOn,");
			strSql.Append("m_ZheK=@m_ZheK,");
			strSql.Append("m_StatusCode=@m_StatusCode,");
			strSql.Append("m_ShenPstatus=@m_ShenPstatus,");
			strSql.Append("pc_ID=@pc_ID,");
			strSql.Append("sku_ID=@sku_ID,");
			strSql.Append("pc_CreatedOn=@pc_CreatedOn,");
			strSql.Append("pc_Type=@pc_Type,");
			strSql.Append("pc_Content=@pc_Content,");
			strSql.Append("pc_CreatedBy=@pc_CreatedBy,");
			strSql.Append("pc_StatusCode=@pc_StatusCode,");
			strSql.Append("pc_IsDel=@pc_IsDel");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@m_UserName", SqlDbType.VarChar,50),
					new SqlParameter("@m_NickName", SqlDbType.NVarChar,30),
					new SqlParameter("@m_RealName", SqlDbType.NVarChar,20),
					new SqlParameter("@sku_ModifyBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@p_ID", SqlDbType.Int,4),
					new SqlParameter("@sku_Price", SqlDbType.Decimal,5),
					new SqlParameter("@sku_CostPrice", SqlDbType.Decimal,5),
					new SqlParameter("@sku_Stock", SqlDbType.Int,4),
					new SqlParameter("@sku_SalesCount", SqlDbType.Int,4),
					new SqlParameter("@sku_Code", SqlDbType.VarChar,30),
					new SqlParameter("@sku_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@sku_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@sku_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@sku_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@sku_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@p_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@p_Sort", SqlDbType.Int,4),
					new SqlParameter("@p_MeasurementUnit", SqlDbType.VarChar,20),
					new SqlParameter("@p_Province", SqlDbType.Int,4),
					new SqlParameter("@p_City", SqlDbType.Int,4),
					new SqlParameter("@p_County", SqlDbType.Int,4),
					new SqlParameter("@p_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@p_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@p_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@p_ModifyBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@p_StatusCode", SqlDbType.SmallInt,2),
					new SqlParameter("@p_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@p_SellStatus", SqlDbType.Int,4),
					new SqlParameter("@ct_ID", SqlDbType.Int,4),
					new SqlParameter("@pt_ID", SqlDbType.Int,4),
					new SqlParameter("@m_Password", SqlDbType.VarChar,100),
					new SqlParameter("@m_UserType", SqlDbType.Int,4),
					new SqlParameter("@m_YingYZZ", SqlDbType.NVarChar,30),
					new SqlParameter("@m_Score", SqlDbType.Int,4),
					new SqlParameter("@m_Rank", SqlDbType.Int,4),
					new SqlParameter("@m_Sex", SqlDbType.Int,4),
					new SqlParameter("@m_Birthday", SqlDbType.DateTime),
					new SqlParameter("@m_Phone", SqlDbType.VarChar,50),
					new SqlParameter("@m_Email", SqlDbType.VarChar,100),
					new SqlParameter("@m_QQ", SqlDbType.VarChar,30),
					new SqlParameter("@m_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@m_ZheK", SqlDbType.Decimal,9),
					new SqlParameter("@m_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@m_ShenPstatus", SqlDbType.Int,4),
					new SqlParameter("@pc_ID", SqlDbType.Int,4),
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@pc_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@pc_Type", SqlDbType.VarChar,30),
					new SqlParameter("@pc_Content", SqlDbType.NVarChar,500),
					new SqlParameter("@pc_CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@pc_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@pc_IsDel", SqlDbType.Bit,1)};
			parameters[0].Value = model.m_UserName;
			parameters[1].Value = model.m_NickName;
			parameters[2].Value = model.m_RealName;
			parameters[3].Value = model.sku_ModifyBy;
			parameters[4].Value = model.p_ID;
			parameters[5].Value = model.sku_Price;
			parameters[6].Value = model.sku_CostPrice;
			parameters[7].Value = model.sku_Stock;
			parameters[8].Value = model.sku_SalesCount;
			parameters[9].Value = model.sku_Code;
			parameters[10].Value = model.sku_CreatedOn;
			parameters[11].Value = model.sku_CreatedBy;
			parameters[12].Value = model.sku_ModifyOn;
			parameters[13].Value = model.sku_StatusCode;
			parameters[14].Value = model.sku_IsDel;
			parameters[15].Value = model.p_Name;
			parameters[16].Value = model.p_Sort;
			parameters[17].Value = model.p_MeasurementUnit;
			parameters[18].Value = model.p_Province;
			parameters[19].Value = model.p_City;
			parameters[20].Value = model.p_County;
			parameters[21].Value = model.p_CreatedOn;
			parameters[22].Value = model.p_ModifyOn;
			parameters[23].Value = model.p_CreatedBy;
			parameters[24].Value = model.p_ModifyBy;
			parameters[25].Value = model.p_StatusCode;
			parameters[26].Value = model.p_IsDel;
			parameters[27].Value = model.p_SellStatus;
			parameters[28].Value = model.ct_ID;
			parameters[29].Value = model.pt_ID;
			parameters[30].Value = model.m_Password;
			parameters[31].Value = model.m_UserType;
			parameters[32].Value = model.m_YingYZZ;
			parameters[33].Value = model.m_Score;
			parameters[34].Value = model.m_Rank;
			parameters[35].Value = model.m_Sex;
			parameters[36].Value = model.m_Birthday;
			parameters[37].Value = model.m_Phone;
			parameters[38].Value = model.m_Email;
			parameters[39].Value = model.m_QQ;
			parameters[40].Value = model.m_CreatedOn;
			parameters[41].Value = model.m_ZheK;
			parameters[42].Value = model.m_StatusCode;
			parameters[43].Value = model.m_ShenPstatus;
			parameters[44].Value = model.pc_ID;
			parameters[45].Value = model.sku_ID;
			parameters[46].Value = model.pc_CreatedOn;
			parameters[47].Value = model.pc_Type;
			parameters[48].Value = model.pc_Content;
			parameters[49].Value = model.pc_CreatedBy;
			parameters[50].Value = model.pc_StatusCode;
			parameters[51].Value = model.pc_IsDel;

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
			strSql.Append("delete from vm_PCdetails ");
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
		public webs_YueyxShop.Model.vm_PCdetails GetModel(int id)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 m_UserName,m_NickName,m_RealName,sku_ModifyBy,p_ID,sku_Price,sku_CostPrice,sku_Stock,sku_SalesCount,sku_Code,sku_CreatedOn,sku_CreatedBy,sku_ModifyOn,sku_StatusCode,sku_IsDel,p_Name,p_Sort,p_MeasurementUnit,p_Province,p_City,p_County,p_CreatedOn,p_ModifyOn,p_CreatedBy,p_ModifyBy,p_StatusCode,p_IsDel,p_SellStatus,ct_ID,pt_ID,m_Password,m_UserType,m_YingYZZ,m_Score,m_Rank,m_Sex,m_Birthday,m_Phone,m_Email,m_QQ,m_CreatedOn,m_ZheK,m_StatusCode,m_ShenPstatus,pc_ID,sku_ID,pc_CreatedOn,pc_Type,pc_Content,pc_CreatedBy,pc_StatusCode,pc_huifu,pc_IsDel from vm_PCdetails ");
			strSql.Append(" where pc_id="+id);
			SqlParameter[] parameters = {
			};

			webs_YueyxShop.Model.vm_PCdetails model=new webs_YueyxShop.Model.vm_PCdetails();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
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
		public webs_YueyxShop.Model.vm_PCdetails DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.vm_PCdetails model=new webs_YueyxShop.Model.vm_PCdetails();
			if (row != null)
			{
				if(row["m_UserName"]!=null)
				{
					model.m_UserName=row["m_UserName"].ToString();
				}
				if(row["m_NickName"]!=null)
				{
					model.m_NickName=row["m_NickName"].ToString();
				}
				if(row["m_RealName"]!=null)
				{
					model.m_RealName=row["m_RealName"].ToString();
				}
				if(row["sku_ModifyBy"]!=null && row["sku_ModifyBy"].ToString()!="")
				{
					model.sku_ModifyBy= new Guid(row["sku_ModifyBy"].ToString());
				}
				if(row["p_ID"]!=null && row["p_ID"].ToString()!="")
				{
					model.p_ID=int.Parse(row["p_ID"].ToString());
				}
				if(row["sku_Price"]!=null && row["sku_Price"].ToString()!="")
				{
					model.sku_Price=decimal.Parse(row["sku_Price"].ToString());
				}
				if(row["sku_CostPrice"]!=null && row["sku_CostPrice"].ToString()!="")
				{
					model.sku_CostPrice=decimal.Parse(row["sku_CostPrice"].ToString());
				}
				if(row["sku_Stock"]!=null && row["sku_Stock"].ToString()!="")
				{
					model.sku_Stock=int.Parse(row["sku_Stock"].ToString());
				}
				if(row["sku_SalesCount"]!=null && row["sku_SalesCount"].ToString()!="")
				{
					model.sku_SalesCount=int.Parse(row["sku_SalesCount"].ToString());
				}
				if(row["sku_Code"]!=null)
				{
					model.sku_Code=row["sku_Code"].ToString();
				}
				if(row["sku_CreatedOn"]!=null && row["sku_CreatedOn"].ToString()!="")
				{
					model.sku_CreatedOn=DateTime.Parse(row["sku_CreatedOn"].ToString());
				}
				if(row["sku_CreatedBy"]!=null && row["sku_CreatedBy"].ToString()!="")
				{
					model.sku_CreatedBy= new Guid(row["sku_CreatedBy"].ToString());
				}
				if(row["sku_ModifyOn"]!=null && row["sku_ModifyOn"].ToString()!="")
				{
					model.sku_ModifyOn=DateTime.Parse(row["sku_ModifyOn"].ToString());
				}
				if(row["sku_StatusCode"]!=null && row["sku_StatusCode"].ToString()!="")
				{
					model.sku_StatusCode=int.Parse(row["sku_StatusCode"].ToString());
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
				if(row["p_ModifyOn"]!=null && row["p_ModifyOn"].ToString()!="")
				{
					model.p_ModifyOn=DateTime.Parse(row["p_ModifyOn"].ToString());
				}
				if(row["p_CreatedBy"]!=null && row["p_CreatedBy"].ToString()!="")
				{
					model.p_CreatedBy= new Guid(row["p_CreatedBy"].ToString());
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
				if(row["pt_ID"]!=null && row["pt_ID"].ToString()!="")
				{
					model.pt_ID=int.Parse(row["pt_ID"].ToString());
				}
				if(row["m_Password"]!=null)
				{
					model.m_Password=row["m_Password"].ToString();
				}
				if(row["m_UserType"]!=null && row["m_UserType"].ToString()!="")
				{
					model.m_UserType=int.Parse(row["m_UserType"].ToString());
				}
				if(row["m_YingYZZ"]!=null)
				{
					model.m_YingYZZ=row["m_YingYZZ"].ToString();
				}
				if(row["m_Score"]!=null && row["m_Score"].ToString()!="")
				{
					model.m_Score=int.Parse(row["m_Score"].ToString());
				}
				if(row["m_Rank"]!=null && row["m_Rank"].ToString()!="")
				{
					model.m_Rank=int.Parse(row["m_Rank"].ToString());
				}
				if(row["m_Sex"]!=null && row["m_Sex"].ToString()!="")
				{
					model.m_Sex=int.Parse(row["m_Sex"].ToString());
				}
				if(row["m_Birthday"]!=null && row["m_Birthday"].ToString()!="")
				{
					model.m_Birthday=DateTime.Parse(row["m_Birthday"].ToString());
				}
				if(row["m_Phone"]!=null)
				{
					model.m_Phone=row["m_Phone"].ToString();
				}
				if(row["m_Email"]!=null)
				{
					model.m_Email=row["m_Email"].ToString();
				}
				if(row["m_QQ"]!=null)
				{
					model.m_QQ=row["m_QQ"].ToString();
				}
				if(row["m_CreatedOn"]!=null && row["m_CreatedOn"].ToString()!="")
				{
					model.m_CreatedOn=DateTime.Parse(row["m_CreatedOn"].ToString());
				}
				if(row["m_ZheK"]!=null && row["m_ZheK"].ToString()!="")
				{
					model.m_ZheK=decimal.Parse(row["m_ZheK"].ToString());
				}
				if(row["m_StatusCode"]!=null && row["m_StatusCode"].ToString()!="")
				{
					model.m_StatusCode=int.Parse(row["m_StatusCode"].ToString());
				}
				if(row["m_ShenPstatus"]!=null && row["m_ShenPstatus"].ToString()!="")
				{
					model.m_ShenPstatus=int.Parse(row["m_ShenPstatus"].ToString());
				}
				if(row["pc_ID"]!=null && row["pc_ID"].ToString()!="")
				{
					model.pc_ID=int.Parse(row["pc_ID"].ToString());
				}
				if(row["sku_ID"]!=null && row["sku_ID"].ToString()!="")
				{
					model.sku_ID=int.Parse(row["sku_ID"].ToString());
				}
				if(row["pc_CreatedOn"]!=null && row["pc_CreatedOn"].ToString()!="")
				{
					model.pc_CreatedOn=DateTime.Parse(row["pc_CreatedOn"].ToString());
				}
				if(row["pc_Type"]!=null)
				{
					model.pc_Type=row["pc_Type"].ToString();
				}
				if(row["pc_Content"]!=null)
				{
					model.pc_Content=row["pc_Content"].ToString();
				}
				if(row["pc_CreatedBy"]!=null && row["pc_CreatedBy"].ToString()!="")
				{
					model.pc_CreatedBy=int.Parse(row["pc_CreatedBy"].ToString());
				}
				if(row["pc_StatusCode"]!=null && row["pc_StatusCode"].ToString()!="")
				{
					model.pc_StatusCode=int.Parse(row["pc_StatusCode"].ToString());
				}
                if (row["pc_huifu"] != null && row["pc_huifu"].ToString() != "")
				{
                    model.pc_huifu = int.Parse(row["pc_huifu"].ToString());
				}
				if(row["pc_IsDel"]!=null && row["pc_IsDel"].ToString()!="")
				{
					if((row["pc_IsDel"].ToString()=="1")||(row["pc_IsDel"].ToString().ToLower()=="true"))
					{
						model.pc_IsDel=true;
					}
					else
					{
						model.pc_IsDel=false;
					}
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
            strSql.Append("select m_UserName,m_NickName,m_RealName,sku_ModifyBy,p_ID,sku_Price,sku_CostPrice,sku_Stock,sku_SalesCount,sku_Code,sku_CreatedOn,sku_CreatedBy,sku_ModifyOn,sku_StatusCode,sku_IsDel,p_Name,p_Sort,p_MeasurementUnit,p_Province,p_City,p_County,p_CreatedOn,p_ModifyOn,p_CreatedBy,p_ModifyBy,p_StatusCode,p_IsDel,p_SellStatus,ct_ID,pt_ID,m_Password,m_UserType,m_YingYZZ,m_Score,m_Rank,m_Sex,m_Birthday,m_Phone,m_Email,m_QQ,m_CreatedOn,m_ZheK,m_StatusCode,m_ShenPstatus,pc_ID,sku_ID,pc_CreatedOn,pc_Type,pc_Content,pc_CreatedBy,pc_StatusCode,pc_huifu,pc_IsDel ");
			strSql.Append(" FROM vm_PCdetails ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
            strSql.Append(" m_UserName,m_NickName,m_RealName,sku_ModifyBy,p_ID,sku_Price,sku_CostPrice,sku_Stock,sku_SalesCount,sku_Code,sku_CreatedOn,sku_CreatedBy,sku_ModifyOn,sku_StatusCode,sku_IsDel,p_Name,p_Sort,p_MeasurementUnit,p_Province,p_City,p_County,p_CreatedOn,p_ModifyOn,p_CreatedBy,p_ModifyBy,p_StatusCode,p_IsDel,p_SellStatus,ct_ID,pt_ID,m_Password,m_UserType,m_YingYZZ,m_Score,m_Rank,m_Sex,m_Birthday,m_Phone,m_Email,m_QQ,m_CreatedOn,m_ZheK,m_StatusCode,m_ShenPstatus,pc_ID,sku_ID,pc_CreatedOn,pc_Type,pc_Content,pc_CreatedBy,pc_StatusCode,pc_huifu,pc_IsDel ");
			strSql.Append(" FROM vm_PCdetails ");
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
			strSql.Append("select count(1) FROM vm_PCdetails ");
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
			strSql.Append(")AS Row, T.*  from vm_PCdetails T ");
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
			parameters[0].Value = "vm_PCdetails";
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

