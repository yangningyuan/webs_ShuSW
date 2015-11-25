/**  版本信息模板在安装目录下，可自行修改。
* ShipTypeBase.cs
*
* 功 能： N/A
* 类 名： ShipTypeBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/13 11:35:11   N/A    初版
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
	/// 数据访问类:ShipTypeBase
	/// </summary>
	public partial class ShipTypeBase:IShipTypeBase
	{
		public ShipTypeBase()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("st_ID", "ShipTypeBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int st_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ShipTypeBase");
			strSql.Append(" where st_ID=@st_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@st_ID", SqlDbType.Int,4)			};
			parameters[0].Value = st_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(webs_YueyxShop.Model.ShipTypeBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ShipTypeBase(");
			strSql.Append("st_Name,st_StatusCode,st_IsDel)");
			strSql.Append(" values (");
			strSql.Append("@st_Name,@st_StatusCode,@st_IsDel)");
			SqlParameter[] parameters = {
					new SqlParameter("@st_Name", SqlDbType.VarChar,30),
					new SqlParameter("@st_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@st_IsDel", SqlDbType.Bit,1)};
			parameters[0].Value = model.st_Name;
			parameters[1].Value = model.st_StatusCode;
			parameters[2].Value = model.st_IsDel;

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
		public bool Update(webs_YueyxShop.Model.ShipTypeBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ShipTypeBase set ");
			strSql.Append("st_Name=@st_Name,");
			strSql.Append("st_StatusCode=@st_StatusCode,");
			strSql.Append("st_IsDel=@st_IsDel");
			strSql.Append(" where st_ID=@st_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@st_Name", SqlDbType.VarChar,30),
					new SqlParameter("@st_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@st_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@st_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.st_Name;
			parameters[1].Value = model.st_StatusCode;
			parameters[2].Value = model.st_IsDel;
			parameters[3].Value = model.st_ID;

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
		public bool Delete(int st_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ShipTypeBase ");
			strSql.Append(" where st_ID=@st_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@st_ID", SqlDbType.Int,4)			};
			parameters[0].Value = st_ID;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string st_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ShipTypeBase ");
			strSql.Append(" where st_ID in ("+st_IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public webs_YueyxShop.Model.ShipTypeBase GetModel(int st_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 st_ID,st_Name,st_StatusCode,st_IsDel from ShipTypeBase ");
			strSql.Append(" where st_ID=@st_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@st_ID", SqlDbType.Int,4)			};
			parameters[0].Value = st_ID;

			webs_YueyxShop.Model.ShipTypeBase model=new webs_YueyxShop.Model.ShipTypeBase();
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
		public webs_YueyxShop.Model.ShipTypeBase DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.ShipTypeBase model=new webs_YueyxShop.Model.ShipTypeBase();
			if (row != null)
			{
				if(row["st_ID"]!=null && row["st_ID"].ToString()!="")
				{
					model.st_ID=int.Parse(row["st_ID"].ToString());
				}
				if(row["st_Name"]!=null)
				{
					model.st_Name=row["st_Name"].ToString();
				}
				if(row["st_StatusCode"]!=null && row["st_StatusCode"].ToString()!="")
				{
					model.st_StatusCode=int.Parse(row["st_StatusCode"].ToString());
				}
				if(row["st_IsDel"]!=null && row["st_IsDel"].ToString()!="")
				{
					if((row["st_IsDel"].ToString()=="1")||(row["st_IsDel"].ToString().ToLower()=="true"))
					{
						model.st_IsDel=true;
					}
					else
					{
						model.st_IsDel=false;
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
			strSql.Append("select st_ID,st_Name,st_StatusCode,st_IsDel ");
			strSql.Append(" FROM ShipTypeBase ");
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
			strSql.Append(" st_ID,st_Name,st_StatusCode,st_IsDel ");
			strSql.Append(" FROM ShipTypeBase ");
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
			strSql.Append("select count(1) FROM ShipTypeBase ");
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
				strSql.Append("order by T.st_ID desc");
			}
			strSql.Append(")AS Row, T.*  from ShipTypeBase T ");
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
			parameters[0].Value = "ShipTypeBase";
			parameters[1].Value = "st_ID";
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

