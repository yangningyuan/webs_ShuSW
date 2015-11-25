/**  版本信息模板在安装目录下，可自行修改。
* ProductRecommendTypeBase.cs
*
* 功 能： N/A
* 类 名： ProductRecommendTypeBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/14 10:16:49   N/A    初版
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
	/// 数据访问类:ProductRecommendTypeBase
	/// </summary>
	public partial class ProductRecommendTypeBase:IProductRecommendTypeBase
	{
		public ProductRecommendTypeBase()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("prt_ID", "ProductRecommendTypeBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int prt_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductRecommendTypeBase");
			strSql.Append(" where prt_ID=@prt_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@prt_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = prt_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(webs_YueyxShop.Model.ProductRecommendTypeBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductRecommendTypeBase(");
			strSql.Append("prt_Name,prt_Title,prt_Status,prt_IsDelete,prt_Directions)");
			strSql.Append(" values (");
			strSql.Append("@prt_Name,@prt_Title,@prt_Status,@prt_IsDelete,@prt_Directions)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@prt_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@prt_Title", SqlDbType.NVarChar,200),
					new SqlParameter("@prt_Status", SqlDbType.Bit,1),
					new SqlParameter("@prt_IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@prt_Directions", SqlDbType.VarChar,200)};
			parameters[0].Value = model.prt_Name;
			parameters[1].Value = model.prt_Title;
			parameters[2].Value = model.prt_Status;
			parameters[3].Value = model.prt_IsDelete;
			parameters[4].Value = model.prt_Directions;

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
		public bool Update(webs_YueyxShop.Model.ProductRecommendTypeBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductRecommendTypeBase set ");
			strSql.Append("prt_Name=@prt_Name,");
			strSql.Append("prt_Title=@prt_Title,");
			strSql.Append("prt_Status=@prt_Status,");
			strSql.Append("prt_IsDelete=@prt_IsDelete,");
			strSql.Append("prt_Directions=@prt_Directions");
			strSql.Append(" where prt_ID=@prt_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@prt_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@prt_Title", SqlDbType.NVarChar,200),
					new SqlParameter("@prt_Status", SqlDbType.Bit,1),
					new SqlParameter("@prt_IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@prt_Directions", SqlDbType.VarChar,200),
					new SqlParameter("@prt_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.prt_Name;
			parameters[1].Value = model.prt_Title;
			parameters[2].Value = model.prt_Status;
			parameters[3].Value = model.prt_IsDelete;
			parameters[4].Value = model.prt_Directions;
			parameters[5].Value = model.prt_ID;

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
		public bool Delete(int prt_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductRecommendTypeBase ");
			strSql.Append(" where prt_ID=@prt_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@prt_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = prt_ID;

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
		public bool DeleteList(string prt_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductRecommendTypeBase ");
			strSql.Append(" where prt_ID in ("+prt_IDlist + ")  ");
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
		public webs_YueyxShop.Model.ProductRecommendTypeBase GetModel(int prt_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 prt_ID,prt_Name,prt_Title,prt_Status,prt_IsDelete,prt_Directions from ProductRecommendTypeBase ");
			strSql.Append(" where prt_ID=@prt_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@prt_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = prt_ID;

			webs_YueyxShop.Model.ProductRecommendTypeBase model=new webs_YueyxShop.Model.ProductRecommendTypeBase();
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
		public webs_YueyxShop.Model.ProductRecommendTypeBase DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.ProductRecommendTypeBase model=new webs_YueyxShop.Model.ProductRecommendTypeBase();
			if (row != null)
			{
				if(row["prt_ID"]!=null && row["prt_ID"].ToString()!="")
				{
					model.prt_ID=int.Parse(row["prt_ID"].ToString());
				}
				if(row["prt_Name"]!=null)
				{
					model.prt_Name=row["prt_Name"].ToString();
				}
				if(row["prt_Title"]!=null)
				{
					model.prt_Title=row["prt_Title"].ToString();
				}
				if(row["prt_Status"]!=null && row["prt_Status"].ToString()!="")
				{
					if((row["prt_Status"].ToString()=="1")||(row["prt_Status"].ToString().ToLower()=="true"))
					{
						model.prt_Status=true;
					}
					else
					{
						model.prt_Status=false;
					}
				}
				if(row["prt_IsDelete"]!=null && row["prt_IsDelete"].ToString()!="")
				{
					if((row["prt_IsDelete"].ToString()=="1")||(row["prt_IsDelete"].ToString().ToLower()=="true"))
					{
						model.prt_IsDelete=true;
					}
					else
					{
						model.prt_IsDelete=false;
					}
				}
				if(row["prt_Directions"]!=null)
				{
					model.prt_Directions=row["prt_Directions"].ToString();
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
			strSql.Append("select prt_ID,prt_Name,prt_Title,prt_Status,prt_IsDelete,prt_Directions ");
			strSql.Append(" FROM ProductRecommendTypeBase ");
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
			strSql.Append(" prt_ID,prt_Name,prt_Title,prt_Status,prt_IsDelete,prt_Directions ");
			strSql.Append(" FROM ProductRecommendTypeBase ");
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
			strSql.Append("select count(1) FROM ProductRecommendTypeBase ");
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
				strSql.Append("order by T.prt_ID desc");
			}
			strSql.Append(")AS Row, T.*  from ProductRecommendTypeBase T ");
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
			parameters[0].Value = "ProductRecommendTypeBase";
			parameters[1].Value = "prt_ID";
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

