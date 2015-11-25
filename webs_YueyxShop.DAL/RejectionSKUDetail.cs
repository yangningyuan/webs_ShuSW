/**  版本信息模板在安装目录下，可自行修改。
* RejectionSKUDetail.cs
*
* 功 能： N/A
* 类 名： RejectionSKUDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/13 16:05:47   N/A    初版
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
	/// 数据访问类:RejectionSKUDetail
	/// </summary>
	public partial class RejectionSKUDetail:IRejectionSKUDetail
	{
		public RejectionSKUDetail()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("rs_ID", "RejectionSKUDetail"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int rs_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from RejectionSKUDetail");
			strSql.Append(" where rs_ID=@rs_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@rs_ID", SqlDbType.Int,4)			};
			parameters[0].Value = rs_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(webs_YueyxShop.Model.RejectionSKUDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RejectionSKUDetail(");
			strSql.Append("sku_ID,r_ID,rs_pCount)");
			strSql.Append(" values (");
			strSql.Append("@sku_ID,@r_ID,@rs_pCount)");
			SqlParameter[] parameters = {
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@r_ID", SqlDbType.Int,4),
					new SqlParameter("@rs_pCount", SqlDbType.Int,4)};
			parameters[0].Value = model.sku_ID;
			parameters[1].Value = model.r_ID;
			parameters[2].Value = model.rs_pCount;

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
		public bool Update(webs_YueyxShop.Model.RejectionSKUDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RejectionSKUDetail set ");
			strSql.Append("sku_ID=@sku_ID,");
			strSql.Append("r_ID=@r_ID,");
			strSql.Append("rs_pCount=@rs_pCount");
			strSql.Append(" where rs_ID=@rs_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@r_ID", SqlDbType.Int,4),
					new SqlParameter("@rs_pCount", SqlDbType.Int,4),
					new SqlParameter("@rs_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.sku_ID;
			parameters[1].Value = model.r_ID;
			parameters[2].Value = model.rs_pCount;
			parameters[3].Value = model.rs_ID;

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
		public bool Delete(int rs_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RejectionSKUDetail ");
			strSql.Append(" where rs_ID=@rs_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@rs_ID", SqlDbType.Int,4)			};
			parameters[0].Value = rs_ID;

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
		public bool DeleteList(string rs_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RejectionSKUDetail ");
			strSql.Append(" where rs_ID in ("+rs_IDlist + ")  ");
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
		public webs_YueyxShop.Model.RejectionSKUDetail GetModel(int rs_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 rs_ID,sku_ID,r_ID,rs_pCount from RejectionSKUDetail ");
			strSql.Append(" where rs_ID=@rs_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@rs_ID", SqlDbType.Int,4)			};
			parameters[0].Value = rs_ID;

			webs_YueyxShop.Model.RejectionSKUDetail model=new webs_YueyxShop.Model.RejectionSKUDetail();
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
		public webs_YueyxShop.Model.RejectionSKUDetail DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.RejectionSKUDetail model=new webs_YueyxShop.Model.RejectionSKUDetail();
			if (row != null)
			{
				if(row["rs_ID"]!=null && row["rs_ID"].ToString()!="")
				{
					model.rs_ID=int.Parse(row["rs_ID"].ToString());
				}
				if(row["sku_ID"]!=null && row["sku_ID"].ToString()!="")
				{
					model.sku_ID=int.Parse(row["sku_ID"].ToString());
				}
				if(row["r_ID"]!=null && row["r_ID"].ToString()!="")
				{
					model.r_ID=int.Parse(row["r_ID"].ToString());
				}
				if(row["rs_pCount"]!=null && row["rs_pCount"].ToString()!="")
				{
					model.rs_pCount=int.Parse(row["rs_pCount"].ToString());
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
			strSql.Append("select rs_ID,sku_ID,r_ID,rs_pCount ");
			strSql.Append(" FROM RejectionSKUDetail ");
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
			strSql.Append(" rs_ID,sku_ID,r_ID,rs_pCount ");
			strSql.Append(" FROM RejectionSKUDetail ");
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
			strSql.Append("select count(1) FROM RejectionSKUDetail ");
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
				strSql.Append("order by T.rs_ID desc");
			}
			strSql.Append(")AS Row, T.*  from RejectionSKUDetail T ");
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
			parameters[0].Value = "RejectionSKUDetail";
			parameters[1].Value = "rs_ID";
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

