/**  版本信息模板在安装目录下，可自行修改。
* vm_RPDetails.cs
*
* 功 能： N/A
* 类 名： vm_RPDetails
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/14 9:22:03   N/A    初版
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
	/// 数据访问类:vm_RPDetails
	/// </summary>
	public partial class vm_RPDetails:Ivm_RPDetails
	{
		public vm_RPDetails()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(webs_YueyxShop.Model.vm_RPDetails model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into vm_RPDetails(");
			strSql.Append("rp_ID,p_ID,rp_StartTime,rp_EndTiime,rp_pCount,rp_pPric,rp_CreateOn,rp_CreateBy,rp_StatusCode,rp_isdel,p_Name)");
			strSql.Append(" values (");
			strSql.Append("@rp_ID,@p_ID,@rp_StartTime,@rp_EndTiime,@rp_pCount,@rp_pPric,@rp_CreateOn,@rp_CreateBy,@rp_StatusCode,@rp_isdel,@p_Name)");
			SqlParameter[] parameters = {
					new SqlParameter("@rp_ID", SqlDbType.Int,4),
					new SqlParameter("@p_ID", SqlDbType.Int,4),
					new SqlParameter("@rp_StartTime", SqlDbType.DateTime),
					new SqlParameter("@rp_EndTiime", SqlDbType.DateTime),
					new SqlParameter("@rp_pCount", SqlDbType.Int,4),
					new SqlParameter("@rp_pPric", SqlDbType.Decimal,5),
					new SqlParameter("@rp_CreateOn", SqlDbType.DateTime),
					new SqlParameter("@rp_CreateBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@rp_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@rp_isdel", SqlDbType.Bit,1),
					new SqlParameter("@p_Name", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.rp_ID;
			parameters[1].Value = model.p_ID;
			parameters[2].Value = model.rp_StartTime;
			parameters[3].Value = model.rp_EndTiime;
			parameters[4].Value = model.rp_pCount;
			parameters[5].Value = model.rp_pPric;
			parameters[6].Value = model.rp_CreateOn;
			parameters[7].Value = Guid.NewGuid();
			parameters[8].Value = model.rp_StatusCode;
			parameters[9].Value = model.rp_isdel;
			parameters[10].Value = model.p_Name;

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
		public bool Update(webs_YueyxShop.Model.vm_RPDetails model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update vm_RPDetails set ");
			strSql.Append("rp_ID=@rp_ID,");
			strSql.Append("p_ID=@p_ID,");
			strSql.Append("rp_StartTime=@rp_StartTime,");
			strSql.Append("rp_EndTiime=@rp_EndTiime,");
			strSql.Append("rp_pCount=@rp_pCount,");
			strSql.Append("rp_pPric=@rp_pPric,");
			strSql.Append("rp_CreateOn=@rp_CreateOn,");
			strSql.Append("rp_CreateBy=@rp_CreateBy,");
			strSql.Append("rp_StatusCode=@rp_StatusCode,");
			strSql.Append("rp_isdel=@rp_isdel,");
			strSql.Append("p_Name=@p_Name");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@rp_ID", SqlDbType.Int,4),
					new SqlParameter("@p_ID", SqlDbType.Int,4),
					new SqlParameter("@rp_StartTime", SqlDbType.DateTime),
					new SqlParameter("@rp_EndTiime", SqlDbType.DateTime),
					new SqlParameter("@rp_pCount", SqlDbType.Int,4),
					new SqlParameter("@rp_pPric", SqlDbType.Decimal,5),
					new SqlParameter("@rp_CreateOn", SqlDbType.DateTime),
					new SqlParameter("@rp_CreateBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@rp_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@rp_isdel", SqlDbType.Bit,1),
					new SqlParameter("@p_Name", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.rp_ID;
			parameters[1].Value = model.p_ID;
			parameters[2].Value = model.rp_StartTime;
			parameters[3].Value = model.rp_EndTiime;
			parameters[4].Value = model.rp_pCount;
			parameters[5].Value = model.rp_pPric;
			parameters[6].Value = model.rp_CreateOn;
			parameters[7].Value = model.rp_CreateBy;
			parameters[8].Value = model.rp_StatusCode;
			parameters[9].Value = model.rp_isdel;
			parameters[10].Value = model.p_Name;

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
			strSql.Append("delete from vm_RPDetails ");
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
		public webs_YueyxShop.Model.vm_RPDetails GetModel(int id)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 rp_ID,p_ID,rp_StartTime,rp_EndTiime,rp_pCount,rp_pPric,rp_CreateOn,rp_CreateBy,rp_StatusCode,rp_isdel,p_Name from vm_RPDetails ");
			strSql.Append(" where rp_id="+id);
			SqlParameter[] parameters = {
			};

			webs_YueyxShop.Model.vm_RPDetails model=new webs_YueyxShop.Model.vm_RPDetails();
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
		public webs_YueyxShop.Model.vm_RPDetails DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.vm_RPDetails model=new webs_YueyxShop.Model.vm_RPDetails();
			if (row != null)
			{
				if(row["rp_ID"]!=null && row["rp_ID"].ToString()!="")
				{
					model.rp_ID=int.Parse(row["rp_ID"].ToString());
				}
				if(row["p_ID"]!=null && row["p_ID"].ToString()!="")
				{
					model.p_ID=int.Parse(row["p_ID"].ToString());
				}
				if(row["rp_StartTime"]!=null && row["rp_StartTime"].ToString()!="")
				{
					model.rp_StartTime=DateTime.Parse(row["rp_StartTime"].ToString());
				}
				if(row["rp_EndTiime"]!=null && row["rp_EndTiime"].ToString()!="")
				{
					model.rp_EndTiime=DateTime.Parse(row["rp_EndTiime"].ToString());
				}
				if(row["rp_pCount"]!=null && row["rp_pCount"].ToString()!="")
				{
					model.rp_pCount=int.Parse(row["rp_pCount"].ToString());
				}
				if(row["rp_pPric"]!=null && row["rp_pPric"].ToString()!="")
				{
					model.rp_pPric=decimal.Parse(row["rp_pPric"].ToString());
				}
				if(row["rp_CreateOn"]!=null && row["rp_CreateOn"].ToString()!="")
				{
					model.rp_CreateOn=DateTime.Parse(row["rp_CreateOn"].ToString());
				}
				if(row["rp_CreateBy"]!=null && row["rp_CreateBy"].ToString()!="")
				{
					model.rp_CreateBy= new Guid(row["rp_CreateBy"].ToString());
				}
				if(row["rp_StatusCode"]!=null && row["rp_StatusCode"].ToString()!="")
				{
					model.rp_StatusCode=int.Parse(row["rp_StatusCode"].ToString());
				}
				if(row["rp_isdel"]!=null && row["rp_isdel"].ToString()!="")
				{
					if((row["rp_isdel"].ToString()=="1")||(row["rp_isdel"].ToString().ToLower()=="true"))
					{
						model.rp_isdel=true;
					}
					else
					{
						model.rp_isdel=false;
					}
				}
				if(row["p_Name"]!=null)
				{
					model.p_Name=row["p_Name"].ToString();
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
			strSql.Append("select rp_ID,p_ID,rp_StartTime,rp_EndTiime,rp_pCount,rp_pPric,rp_CreateOn,rp_CreateBy,rp_StatusCode,rp_isdel,p_Name ");
			strSql.Append(" FROM vm_RPDetails ");
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
			strSql.Append(" rp_ID,p_ID,rp_StartTime,rp_EndTiime,rp_pCount,rp_pPric,rp_CreateOn,rp_CreateBy,rp_StatusCode,rp_isdel,p_Name ");
			strSql.Append(" FROM vm_RPDetails ");
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
			strSql.Append("select count(1) FROM vm_RPDetails ");
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
				strSql.Append("order by T.rp_ID desc");
			}
			strSql.Append(")AS Row, T.*  from vm_RPDetails T ");
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
			parameters[0].Value = "vm_RPDetails";
			parameters[1].Value = "rp_ID";
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

