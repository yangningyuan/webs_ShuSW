/**  版本信息模板在安装目录下，可自行修改。
* ProductImgBase.cs
*
* 功 能： N/A
* 类 名： ProductImgBase
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
	/// 数据访问类:ProductImgBase
	/// </summary>
	public partial class ProductImgBase:IProductImgBase
	{
		public ProductImgBase()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("pi_ID", "ProductImgBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int pi_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductImgBase");
			strSql.Append(" where pi_ID=@pi_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pi_ID", SqlDbType.Int,4)			};
			parameters[0].Value = pi_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(webs_YueyxShop.Model.ProductImgBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductImgBase(");
            strSql.Append("sku_ID,pi_Url,pi_Type,pi_StatusCode,pi_IsDel)");
			strSql.Append(" values (");
            strSql.Append("@sku_ID,@pi_Url,@pi_Type,@pi_statuscode,@pi_isdel)");
			SqlParameter[] parameters = {
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@pi_Url", SqlDbType.VarChar,100),
					new SqlParameter("@pi_Type", SqlDbType.Bit),
					new SqlParameter("@pi_statuscode", SqlDbType.Int,4),
					new SqlParameter("@pi_isdel", SqlDbType.Bit)};
			parameters[0].Value = model.sku_ID;
			parameters[1].Value = model.pi_Url;
            parameters[2].Value = model.pi_Type;
            parameters[3].Value = model.pi_StatusCode;
            parameters[4].Value = model.pi_IsDel;

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
		public bool Update(webs_YueyxShop.Model.ProductImgBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductImgBase set ");
			strSql.Append("sku_ID=@sku_ID,");
			strSql.Append("pi_Url=@pi_Url,");
			strSql.Append("pi_Type=@pi_Type,");
            strSql.Append("pi_StatusCode=@pi_StatusCode,");
            strSql.Append("pi_IsDel=@pi_IsDel");
			strSql.Append(" where pi_ID=@pi_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@pi_Url", SqlDbType.VarChar,100),
					new SqlParameter("@pi_Type", SqlDbType.Bit),
					new SqlParameter("@pi_statuscode", SqlDbType.Int,4),
					new SqlParameter("@pi_isdel", SqlDbType.Bit),
					new SqlParameter("@pi_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.sku_ID;
			parameters[1].Value = model.pi_Url;
            parameters[2].Value = model.pi_Type;
            parameters[3].Value = model.pi_StatusCode;
            parameters[4].Value = model.pi_IsDel;
			parameters[5].Value = model.pi_ID;

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
		public bool Delete(int pi_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductImgBase ");
			strSql.Append(" where pi_ID=@pi_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pi_ID", SqlDbType.Int,4)			};
			parameters[0].Value = pi_ID;

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
		public bool DeleteList(string pi_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductImgBase ");
			strSql.Append(" where pi_ID in ("+pi_IDlist + ")  ");
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
		public webs_YueyxShop.Model.ProductImgBase GetModel(int pi_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 pi_ID,sku_ID,pi_Url,pi_Type,pi_StatusCode,pi_IsDel from ProductImgBase ");
			strSql.Append(" where pi_ID=@pi_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pi_ID", SqlDbType.Int,4)			};
			parameters[0].Value = pi_ID;

			webs_YueyxShop.Model.ProductImgBase model=new webs_YueyxShop.Model.ProductImgBase();
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
		public webs_YueyxShop.Model.ProductImgBase DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.ProductImgBase model=new webs_YueyxShop.Model.ProductImgBase();
			if (row != null)
			{
				if(row["pi_ID"]!=null && row["pi_ID"].ToString()!="")
				{
					model.pi_ID=int.Parse(row["pi_ID"].ToString());
				}
				if(row["sku_ID"]!=null && row["sku_ID"].ToString()!="")
				{
					model.sku_ID=int.Parse(row["sku_ID"].ToString());
				}
				if(row["pi_Url"]!=null)
				{
					model.pi_Url=row["pi_Url"].ToString();
				}
				if(row["pi_Type"]!=null && row["pi_Type"].ToString()!="")
				{
                    model.pi_Type = bool.Parse(row["pi_Type"].ToString());
				}
                if (row["pi_StatusCode"] != null && row["pi_StatusCode"].ToString() != "")
				{
                    model.pi_StatusCode = int.Parse(row["pi_StatusCode"].ToString());
				}
                if (row["pi_IsDel"] != null && row["pi_IsDel"].ToString() != "")
				{
                    model.pi_IsDel = bool.Parse(row["pi_IsDel"].ToString());
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
            strSql.Append("select pi_ID,sku_ID,pi_Url,pi_Type,pi_StatusCode,pi_IsDel ");
			strSql.Append(" FROM ProductImgBase ");
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
            strSql.Append(" pi_ID,sku_ID,pi_Url,pi_Type,pi_StatusCode,pi_IsDel");
			strSql.Append(" FROM ProductImgBase ");
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
			strSql.Append("select count(1) FROM ProductImgBase ");
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
				strSql.Append("order by T.pi_ID desc");
			}
			strSql.Append(")AS Row, T.*  from ProductImgBase T ");
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
			parameters[0].Value = "ProductImgBase";
			parameters[1].Value = "pi_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        public DataSet GetModelListById(string p)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pimg.pi_ID,pimg.sku_ID,pimg.pi_Url,pimg.pi_Type,pimg.pi_StatusCode,pimg.pi_IsDel,s.sku_Code ");
            strSql.Append("from SKUBase s,ProductImgBase pimg");
            if (p.Trim() != "")
            {
                strSql.Append("  where pimg.sku_ID=s.sku_ID   " + p);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
		#endregion  ExtensionMethod
	}
}

