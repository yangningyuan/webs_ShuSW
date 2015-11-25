/**  版本信息模板在安装目录下，可自行修改。
* ProductInfoBase.cs
*
* 功 能： N/A
* 类 名： ProductInfoBase
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
	/// 数据访问类:ProductInfoBase
	/// </summary>
	public partial class ProductInfoBase:IProductInfoBase
	{
		public ProductInfoBase()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("pin_ID", "ProductInfoBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int pin_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductInfoBase");
			strSql.Append(" where pin_ID=@pin_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pin_ID", SqlDbType.Int,4)			};
			parameters[0].Value = pin_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(webs_YueyxShop.Model.ProductInfoBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductInfoBase(");
			strSql.Append("p_ID,pin_Type,pin_Title,pin_Content,pin_CreatedOn,pin_CreatedBy,pin_ModifyOn,pin_MoidfyBy,pin_StatusCode,pin_IsDel)");
			strSql.Append(" values (");
			strSql.Append("@p_ID,@pin_Type,@pin_Title,@pin_Content,@pin_CreatedOn,@pin_CreatedBy,@pin_ModifyOn,@pin_MoidfyBy,@pin_StatusCode,@pin_IsDel)");
			SqlParameter[] parameters = {
					new SqlParameter("@p_ID", SqlDbType.Int,4),
					new SqlParameter("@pin_Type", SqlDbType.NVarChar,30),
					new SqlParameter("@pin_Title", SqlDbType.NVarChar,30),
					new SqlParameter("@pin_Content", SqlDbType.Text),
					new SqlParameter("@pin_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@pin_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@pin_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@pin_MoidfyBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@pin_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@pin_IsDel", SqlDbType.Bit,1)};
			parameters[0].Value = model.p_ID;
			parameters[1].Value = model.pin_Type;
			parameters[2].Value = model.pin_Title;
			parameters[3].Value = model.pin_Content;
			parameters[4].Value = model.pin_CreatedOn;
			parameters[5].Value =  Guid.NewGuid();
            parameters[6].Value = model.pin_ModifyOn;
            parameters[7].Value = Guid.NewGuid();
            parameters[8].Value = model.pin_StatusCode;
			parameters[9].Value = model.pin_IsDel;

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
		public bool Update(webs_YueyxShop.Model.ProductInfoBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductInfoBase set ");
			strSql.Append("p_ID=@p_ID,");
			strSql.Append("pin_Type=@pin_Type,");
			strSql.Append("pin_Title=@pin_Title,");
			strSql.Append("pin_Content=@pin_Content,");
			strSql.Append("pin_CreatedOn=@pin_CreatedOn,");
			strSql.Append("pin_CreatedBy=@pin_CreatedBy,");
			strSql.Append("pin_ModifyOn=@pin_ModifyOn,");
			strSql.Append("pin_MoidfyBy=@pin_MoidfyBy,");
			strSql.Append("pin_StatusCode=@pin_StatusCode,");
			strSql.Append("pin_IsDel=@pin_IsDel");
			strSql.Append(" where pin_ID=@pin_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@p_ID", SqlDbType.Int,4),
					new SqlParameter("@pin_Type", SqlDbType.NVarChar,30),
					new SqlParameter("@pin_Title", SqlDbType.NVarChar,30),
					new SqlParameter("@pin_Content", SqlDbType.Text),
					new SqlParameter("@pin_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@pin_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@pin_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@pin_MoidfyBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@pin_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@pin_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@pin_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.p_ID;
			parameters[1].Value = model.pin_Type;
			parameters[2].Value = model.pin_Title;
			parameters[3].Value = model.pin_Content;
			parameters[4].Value = model.pin_CreatedOn;
			parameters[5].Value = model.pin_CreatedBy;
			parameters[6].Value = model.pin_ModifyOn;
			parameters[7].Value = model.pin_MoidfyBy;
			parameters[8].Value = model.pin_StatusCode;
			parameters[9].Value = model.pin_IsDel;
			parameters[10].Value = model.pin_ID;

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
		public bool Delete(int pin_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductInfoBase ");
			strSql.Append(" where pin_ID=@pin_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pin_ID", SqlDbType.Int,4)			};
			parameters[0].Value = pin_ID;

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
		public bool DeleteList(string pin_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductInfoBase ");
			strSql.Append(" where pin_ID in ("+pin_IDlist + ")  ");
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
		public webs_YueyxShop.Model.ProductInfoBase GetModel(int pin_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 pin_ID,p_ID,pin_Type,pin_Title,pin_Content,pin_CreatedOn,pin_CreatedBy,pin_ModifyOn,pin_MoidfyBy,pin_StatusCode,pin_IsDel from ProductInfoBase ");
			strSql.Append(" where pin_ID=@pin_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pin_ID", SqlDbType.Int,4)			};
			parameters[0].Value = pin_ID;

			webs_YueyxShop.Model.ProductInfoBase model=new webs_YueyxShop.Model.ProductInfoBase();
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
		public webs_YueyxShop.Model.ProductInfoBase DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.ProductInfoBase model=new webs_YueyxShop.Model.ProductInfoBase();
			if (row != null)
			{
				if(row["pin_ID"]!=null && row["pin_ID"].ToString()!="")
				{
					model.pin_ID=int.Parse(row["pin_ID"].ToString());
				}
				if(row["p_ID"]!=null && row["p_ID"].ToString()!="")
				{
					model.p_ID=int.Parse(row["p_ID"].ToString());
				}
				if(row["pin_Type"]!=null)
				{
					model.pin_Type=row["pin_Type"].ToString();
				}
				if(row["pin_Title"]!=null)
				{
					model.pin_Title=row["pin_Title"].ToString();
				}
				if(row["pin_Content"]!=null)
				{
					model.pin_Content=row["pin_Content"].ToString();
				}
				if(row["pin_CreatedOn"]!=null && row["pin_CreatedOn"].ToString()!="")
				{
					model.pin_CreatedOn=DateTime.Parse(row["pin_CreatedOn"].ToString());
				}
				if(row["pin_CreatedBy"]!=null && row["pin_CreatedBy"].ToString()!="")
				{
					model.pin_CreatedBy= new Guid(row["pin_CreatedBy"].ToString());
				}
				if(row["pin_ModifyOn"]!=null && row["pin_ModifyOn"].ToString()!="")
				{
					model.pin_ModifyOn=DateTime.Parse(row["pin_ModifyOn"].ToString());
				}
				if(row["pin_MoidfyBy"]!=null && row["pin_MoidfyBy"].ToString()!="")
				{
					model.pin_MoidfyBy= new Guid(row["pin_MoidfyBy"].ToString());
				}
				if(row["pin_StatusCode"]!=null && row["pin_StatusCode"].ToString()!="")
				{
					model.pin_StatusCode=int.Parse(row["pin_StatusCode"].ToString());
				}
				if(row["pin_IsDel"]!=null && row["pin_IsDel"].ToString()!="")
				{
					if((row["pin_IsDel"].ToString()=="1")||(row["pin_IsDel"].ToString().ToLower()=="true"))
					{
						model.pin_IsDel=true;
					}
					else
					{
						model.pin_IsDel=false;
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
			strSql.Append("select pin_ID,p_ID,pin_Type,pin_Title,pin_Content,pin_CreatedOn,pin_CreatedBy,pin_ModifyOn,pin_MoidfyBy,pin_StatusCode,pin_IsDel ");
			strSql.Append(" FROM ProductInfoBase ");
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
			strSql.Append(" pin_ID,p_ID,pin_Type,pin_Title,pin_Content,pin_CreatedOn,pin_CreatedBy,pin_ModifyOn,pin_MoidfyBy,pin_StatusCode,pin_IsDel ");
			strSql.Append(" FROM ProductInfoBase ");
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
			strSql.Append("select count(1) FROM ProductInfoBase ");
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
				strSql.Append("order by T.pin_ID desc");
			}
			strSql.Append(")AS Row, T.*  from ProductInfoBase T ");
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
			parameters[0].Value = "ProductInfoBase";
			parameters[1].Value = "pin_ID";
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

