/**  版本信息模板在安装目录下，可自行修改。
* ProductAttributeDetails.cs
*
* 功 能： N/A
* 类 名： ProductAttributeDetails
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/10/31 11:00:33   N/A    初版
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
	/// 数据访问类:ProductAttributeDetails
	/// </summary>
	public partial class ProductAttributeDetails:IProductAttributeDetails
	{
		public ProductAttributeDetails()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("pad_ID", "ProductAttributeDetails"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int pad_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductAttributeDetails");
			strSql.Append(" where pad_ID=@pad_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pad_ID", SqlDbType.Int,4)			};
			parameters[0].Value = pad_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(webs_YueyxShop.Model.ProductAttributeDetails model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductAttributeDetails(");
			strSql.Append("pa_ID,sku_ID)");
			strSql.Append(" values (");
			strSql.Append("@pa_ID,@sku_ID)");
			SqlParameter[] parameters = {
					new SqlParameter("@pa_ID", SqlDbType.Int,4),
					new SqlParameter("@sku_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.pa_ID;
			parameters[1].Value = model.sku_ID;

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
		public bool Update(webs_YueyxShop.Model.ProductAttributeDetails model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductAttributeDetails set ");
			strSql.Append("pa_ID=@pa_ID,");
			strSql.Append("sku_ID=@sku_ID");
			strSql.Append(" where pad_ID=@pad_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pa_ID", SqlDbType.Int,4),
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@pad_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.pa_ID;
			parameters[1].Value = model.sku_ID;
			parameters[2].Value = model.pad_ID;

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
		public bool Delete(int pad_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductAttributeDetails ");
			strSql.Append(" where pad_ID=@pad_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pad_ID", SqlDbType.Int,4)			};
			parameters[0].Value = pad_ID;

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
		public bool DeleteList(string pad_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductAttributeDetails ");
			strSql.Append(" where pad_ID in ("+pad_IDlist + ")  ");
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
		public webs_YueyxShop.Model.ProductAttributeDetails GetModel(int pad_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 pad_ID,pa_ID,sku_ID from ProductAttributeDetails ");
			strSql.Append(" where pad_ID=@pad_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pad_ID", SqlDbType.Int,4)			};
			parameters[0].Value = pad_ID;

			webs_YueyxShop.Model.ProductAttributeDetails model=new webs_YueyxShop.Model.ProductAttributeDetails();
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
		public webs_YueyxShop.Model.ProductAttributeDetails DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.ProductAttributeDetails model=new webs_YueyxShop.Model.ProductAttributeDetails();
			if (row != null)
			{
				if(row["pad_ID"]!=null && row["pad_ID"].ToString()!="")
				{
					model.pad_ID=int.Parse(row["pad_ID"].ToString());
				}
				if(row["pa_ID"]!=null && row["pa_ID"].ToString()!="")
				{
					model.pa_ID=int.Parse(row["pa_ID"].ToString());
				}
				if(row["sku_ID"]!=null && row["sku_ID"].ToString()!="")
				{
					model.sku_ID=int.Parse(row["sku_ID"].ToString());
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
			strSql.Append("select pad_ID,pa_ID,sku_ID ");
			strSql.Append(" FROM ProductAttributeDetails ");
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
			strSql.Append(" pad_ID,pa_ID,sku_ID ");
			strSql.Append(" FROM ProductAttributeDetails ");
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
			strSql.Append("select count(1) FROM ProductAttributeDetails ");
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
				strSql.Append("order by T.pad_ID desc");
			}
			strSql.Append(")AS Row, T.*  from ProductAttributeDetails T ");
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
			parameters[0].Value = "ProductAttributeDetails";
			parameters[1].Value = "pad_ID";
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

