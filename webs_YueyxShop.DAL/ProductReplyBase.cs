/**  版本信息模板在安装目录下，可自行修改。
* ProductReplyBase.cs
*
* 功 能： N/A
* 类 名： ProductReplyBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/14 11:31:52   N/A    初版
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
	/// 数据访问类:ProductReplyBase
	/// </summary>
	public partial class ProductReplyBase:IProductReplyBase
	{
		public ProductReplyBase()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("pr_ID", "ProductReplyBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int pr_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductReplyBase");
			strSql.Append(" where pr_ID=@pr_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@pr_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = pr_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(webs_YueyxShop.Model.ProductReplyBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductReplyBase(");
			strSql.Append("pc_ID,pr_Content,pr_CreatedBy,pr_CreatedOn,pr_StatusCode,pr_IsDel)");
			strSql.Append(" values (");
			strSql.Append("@pc_ID,@pr_Content,@pr_CreatedBy,@pr_CreatedOn,@pr_StatusCode,@pr_IsDel)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@pc_ID", SqlDbType.Int,4),
					new SqlParameter("@pr_Content", SqlDbType.NVarChar,500),
					new SqlParameter("@pr_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@pr_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@pr_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@pr_IsDel", SqlDbType.Bit,1)};
            parameters[0].Value = model.pc_ID;
			parameters[1].Value = model.pr_Content;
			parameters[2].Value = Guid.NewGuid();
			parameters[3].Value = model.pr_CreatedOn;
			parameters[4].Value = model.pr_StatusCode;
			parameters[5].Value = model.pr_IsDel;

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
		public bool Update(webs_YueyxShop.Model.ProductReplyBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductReplyBase set ");
			strSql.Append("pc_ID=@pc_ID,");
			strSql.Append("pr_Content=@pr_Content,");
			strSql.Append("pr_CreatedBy=@pr_CreatedBy,");
			strSql.Append("pr_CreatedOn=@pr_CreatedOn,");
			strSql.Append("pr_StatusCode=@pr_StatusCode,");
			strSql.Append("pr_IsDel=@pr_IsDel");
			strSql.Append(" where pr_ID=@pr_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@pc_ID", SqlDbType.Int,4),
					new SqlParameter("@pr_Content", SqlDbType.NVarChar,500),
					new SqlParameter("@pr_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@pr_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@pr_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@pr_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@pr_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.pc_ID;
			parameters[1].Value = model.pr_Content;
			parameters[2].Value = model.pr_CreatedBy;
			parameters[3].Value = model.pr_CreatedOn;
			parameters[4].Value = model.pr_StatusCode;
			parameters[5].Value = model.pr_IsDel;
			parameters[6].Value = model.pr_ID;

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
		public bool Delete(int pr_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductReplyBase ");
			strSql.Append(" where pr_ID=@pr_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@pr_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = pr_ID;

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
		public bool DeleteList(string pr_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductReplyBase ");
			strSql.Append(" where pr_ID in ("+pr_IDlist + ")  ");
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
		public webs_YueyxShop.Model.ProductReplyBase GetModel(int pr_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 pr_ID,pc_ID,pr_Content,pr_CreatedBy,pr_CreatedOn,pr_StatusCode,pr_IsDel from ProductReplyBase ");
			strSql.Append(" where pr_ID=@pr_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@pr_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = pr_ID;

			webs_YueyxShop.Model.ProductReplyBase model=new webs_YueyxShop.Model.ProductReplyBase();
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
		public webs_YueyxShop.Model.ProductReplyBase DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.ProductReplyBase model=new webs_YueyxShop.Model.ProductReplyBase();
			if (row != null)
			{
				if(row["pr_ID"]!=null && row["pr_ID"].ToString()!="")
				{
					model.pr_ID=int.Parse(row["pr_ID"].ToString());
				}
				if(row["pc_ID"]!=null && row["pc_ID"].ToString()!="")
				{
					model.pc_ID=int.Parse(row["pc_ID"].ToString());
				}
				if(row["pr_Content"]!=null)
				{
					model.pr_Content=row["pr_Content"].ToString();
				}
				if(row["pr_CreatedBy"]!=null && row["pr_CreatedBy"].ToString()!="")
				{
					model.pr_CreatedBy= new Guid(row["pr_CreatedBy"].ToString());
				}
				if(row["pr_CreatedOn"]!=null && row["pr_CreatedOn"].ToString()!="")
				{
					model.pr_CreatedOn=DateTime.Parse(row["pr_CreatedOn"].ToString());
				}
				if(row["pr_StatusCode"]!=null && row["pr_StatusCode"].ToString()!="")
				{
					model.pr_StatusCode=int.Parse(row["pr_StatusCode"].ToString());
				}
				if(row["pr_IsDel"]!=null && row["pr_IsDel"].ToString()!="")
				{
					if((row["pr_IsDel"].ToString()=="1")||(row["pr_IsDel"].ToString().ToLower()=="true"))
					{
						model.pr_IsDel=true;
					}
					else
					{
						model.pr_IsDel=false;
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
			strSql.Append("select pr_ID,pc_ID,pr_Content,pr_CreatedBy,pr_CreatedOn,pr_StatusCode,pr_IsDel ");
			strSql.Append(" FROM ProductReplyBase ");
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
			strSql.Append(" pr_ID,pc_ID,pr_Content,pr_CreatedBy,pr_CreatedOn,pr_StatusCode,pr_IsDel ");
			strSql.Append(" FROM ProductReplyBase ");
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
			strSql.Append("select count(1) FROM ProductReplyBase ");
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
				strSql.Append("order by T.pr_ID desc");
			}
			strSql.Append(")AS Row, T.*  from ProductReplyBase T ");
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
			parameters[0].Value = "ProductReplyBase";
			parameters[1].Value = "pr_ID";
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

