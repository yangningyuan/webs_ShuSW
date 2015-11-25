/**  版本信息模板在安装目录下，可自行修改。
* ProductSEOBase.cs
*
* 功 能： N/A
* 类 名： ProductSEOBase
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
	/// 数据访问类:ProductSEOBase
	/// </summary>
	public partial class ProductSEOBase:IProductSEOBase
	{
		public ProductSEOBase()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("pseo_ID", "ProductSEOBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int pseo_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductSEOBase");
			strSql.Append(" where pseo_ID=@pseo_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pseo_ID", SqlDbType.Int,4)			};
			parameters[0].Value = pseo_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(webs_YueyxShop.Model.ProductSEOBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductSEOBase(");
			strSql.Append("p_ID,pseo_Title,pseo_Content,pseo_Keys,pseo_PicAlt,pseo_PicTitle)");
			strSql.Append(" values (");
			strSql.Append("@p_ID,@pseo_Title,@pseo_Content,@pseo_Keys,@pseo_PicAlt,@pseo_PicTitle)");
			SqlParameter[] parameters = {
					new SqlParameter("@p_ID", SqlDbType.Int,4),
					new SqlParameter("@pseo_Title", SqlDbType.NVarChar,20),
					new SqlParameter("@pseo_Content", SqlDbType.NVarChar,300),
					new SqlParameter("@pseo_Keys", SqlDbType.NVarChar,100),
					new SqlParameter("@pseo_PicAlt", SqlDbType.NVarChar,50),
					new SqlParameter("@pseo_PicTitle", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.p_ID;
			parameters[1].Value = model.pseo_Title;
			parameters[2].Value = model.pseo_Content;
			parameters[3].Value = model.pseo_Keys;
			parameters[4].Value = model.pseo_PicAlt;
			parameters[5].Value = model.pseo_PicTitle;

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
		public bool Update(webs_YueyxShop.Model.ProductSEOBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductSEOBase set ");
			strSql.Append("p_ID=@p_ID,");
			strSql.Append("pseo_Title=@pseo_Title,");
			strSql.Append("pseo_Content=@pseo_Content,");
			strSql.Append("pseo_Keys=@pseo_Keys,");
			strSql.Append("pseo_PicAlt=@pseo_PicAlt,");
			strSql.Append("pseo_PicTitle=@pseo_PicTitle");
			strSql.Append(" where pseo_ID=@pseo_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@p_ID", SqlDbType.Int,4),
					new SqlParameter("@pseo_Title", SqlDbType.NVarChar,20),
					new SqlParameter("@pseo_Content", SqlDbType.NVarChar,300),
					new SqlParameter("@pseo_Keys", SqlDbType.NVarChar,100),
					new SqlParameter("@pseo_PicAlt", SqlDbType.NVarChar,50),
					new SqlParameter("@pseo_PicTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@pseo_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.p_ID;
			parameters[1].Value = model.pseo_Title;
			parameters[2].Value = model.pseo_Content;
			parameters[3].Value = model.pseo_Keys;
			parameters[4].Value = model.pseo_PicAlt;
			parameters[5].Value = model.pseo_PicTitle;
			parameters[6].Value = model.pseo_ID;

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
		public bool Delete(int pseo_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductSEOBase ");
			strSql.Append(" where pseo_ID=@pseo_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pseo_ID", SqlDbType.Int,4)			};
			parameters[0].Value = pseo_ID;

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
		public bool DeleteList(string pseo_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductSEOBase ");
			strSql.Append(" where pseo_ID in ("+pseo_IDlist + ")  ");
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
		public webs_YueyxShop.Model.ProductSEOBase GetModel(int pseo_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 pseo_ID,p_ID,pseo_Title,pseo_Content,pseo_Keys,pseo_PicAlt,pseo_PicTitle from ProductSEOBase ");
			strSql.Append(" where pseo_ID=@pseo_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pseo_ID", SqlDbType.Int,4)			};
			parameters[0].Value = pseo_ID;

			webs_YueyxShop.Model.ProductSEOBase model=new webs_YueyxShop.Model.ProductSEOBase();
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
		public webs_YueyxShop.Model.ProductSEOBase DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.ProductSEOBase model=new webs_YueyxShop.Model.ProductSEOBase();
			if (row != null)
			{
				if(row["pseo_ID"]!=null && row["pseo_ID"].ToString()!="")
				{
					model.pseo_ID=int.Parse(row["pseo_ID"].ToString());
				}
				if(row["p_ID"]!=null && row["p_ID"].ToString()!="")
				{
					model.p_ID=int.Parse(row["p_ID"].ToString());
				}
				if(row["pseo_Title"]!=null)
				{
					model.pseo_Title=row["pseo_Title"].ToString();
				}
				if(row["pseo_Content"]!=null)
				{
					model.pseo_Content=row["pseo_Content"].ToString();
				}
				if(row["pseo_Keys"]!=null)
				{
					model.pseo_Keys=row["pseo_Keys"].ToString();
				}
				if(row["pseo_PicAlt"]!=null)
				{
					model.pseo_PicAlt=row["pseo_PicAlt"].ToString();
				}
				if(row["pseo_PicTitle"]!=null)
				{
					model.pseo_PicTitle=row["pseo_PicTitle"].ToString();
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
			strSql.Append("select pseo_ID,p_ID,pseo_Title,pseo_Content,pseo_Keys,pseo_PicAlt,pseo_PicTitle ");
			strSql.Append(" FROM ProductSEOBase ");
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
			strSql.Append(" pseo_ID,p_ID,pseo_Title,pseo_Content,pseo_Keys,pseo_PicAlt,pseo_PicTitle ");
			strSql.Append(" FROM ProductSEOBase ");
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
			strSql.Append("select count(1) FROM ProductSEOBase ");
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
				strSql.Append("order by T.pseo_ID desc");
			}
			strSql.Append(")AS Row, T.*  from ProductSEOBase T ");
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
			parameters[0].Value = "ProductSEOBase";
			parameters[1].Value = "pseo_ID";
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

