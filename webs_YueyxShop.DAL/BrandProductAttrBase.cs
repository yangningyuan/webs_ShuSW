﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using webs_YueyxShop.IDAL;
using DBUtility;//Please add references
namespace webs_YueyxShop.DAL
{
	/// <summary>
	/// 数据访问类:BrandProductAttrBase
	/// </summary>
	public partial class BrandProductAttrBase:IBrandProductAttrBase
	{
		public BrandProductAttrBase()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("bpa_ID", "BrandProductAttrBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int bpa_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BrandProductAttrBase");
			strSql.Append(" where bpa_ID=@bpa_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@bpa_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = bpa_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(webs_YueyxShop.Model.BrandProductAttrBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BrandProductAttrBase(");
			strSql.Append("pa_ID,b_ID)");
			strSql.Append(" values (");
			strSql.Append("@pa_ID,@b_ID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@pa_ID", SqlDbType.Int,4),
					new SqlParameter("@b_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.pa_ID;
			parameters[1].Value = model.b_ID;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(webs_YueyxShop.Model.BrandProductAttrBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BrandProductAttrBase set ");
			strSql.Append("pa_ID=@pa_ID,");
			strSql.Append("b_ID=@b_ID");
			strSql.Append(" where bpa_ID=@bpa_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@pa_ID", SqlDbType.Int,4),
					new SqlParameter("@b_ID", SqlDbType.Int,4),
					new SqlParameter("@bpa_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.pa_ID;
			parameters[1].Value = model.b_ID;
			parameters[2].Value = model.bpa_ID;

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
		public bool Delete(int bpa_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BrandProductAttrBase ");
			strSql.Append(" where bpa_ID=@bpa_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@bpa_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = bpa_ID;

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
		public bool DeleteList(string bpa_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BrandProductAttrBase ");
			strSql.Append(" where bpa_ID in ("+bpa_IDlist + ")  ");
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
		public webs_YueyxShop.Model.BrandProductAttrBase GetModel(int bpa_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 bpa_ID,pa_ID,b_ID from BrandProductAttrBase ");
			strSql.Append(" where bpa_ID=@bpa_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@bpa_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = bpa_ID;

			webs_YueyxShop.Model.BrandProductAttrBase model=new webs_YueyxShop.Model.BrandProductAttrBase();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["bpa_ID"]!=null && ds.Tables[0].Rows[0]["bpa_ID"].ToString()!="")
				{
					model.bpa_ID=int.Parse(ds.Tables[0].Rows[0]["bpa_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pa_ID"]!=null && ds.Tables[0].Rows[0]["pa_ID"].ToString()!="")
				{
					model.pa_ID=int.Parse(ds.Tables[0].Rows[0]["pa_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["b_ID"]!=null && ds.Tables[0].Rows[0]["b_ID"].ToString()!="")
				{
					model.b_ID=int.Parse(ds.Tables[0].Rows[0]["b_ID"].ToString());
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
			strSql.Append("select bpa_ID,pa_ID,b_ID ");
			strSql.Append(" FROM BrandProductAttrBase ");
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
			strSql.Append(" bpa_ID,pa_ID,b_ID ");
			strSql.Append(" FROM BrandProductAttrBase ");
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
			strSql.Append("select count(1) FROM BrandProductAttrBase ");
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
				strSql.Append("order by T.bpa_ID desc");
			}
			strSql.Append(")AS Row, T.*  from BrandProductAttrBase T ");
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
			parameters[0].Value = "BrandProductAttrBase";
			parameters[1].Value = "bpa_ID";
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

