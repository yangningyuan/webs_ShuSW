/**  版本信息模板在安装目录下，可自行修改。
* GroupPurchaseBase.cs
*
* 功 能： N/A
* 类 名： GroupPurchaseBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/14 9:22:01   N/A    初版
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
	/// 数据访问类:GroupPurchaseBase
	/// </summary>
	public partial class GroupPurchaseBase:IGroupPurchaseBase
	{
		public GroupPurchaseBase()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("gp_ID", "GroupPurchaseBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int gp_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from GroupPurchaseBase");
			strSql.Append(" where gp_ID=@gp_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@gp_ID", SqlDbType.Int,4)			};
			parameters[0].Value = gp_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(webs_YueyxShop.Model.GroupPurchaseBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into GroupPurchaseBase(");
            strSql.Append("sku_ID,gp_StartTime,gp_EndTime,gp_pCount,gp_pPric,gp_CreateOn,gp_CreateBy,gp_StatusCode,gp_IsDel,gp_Logo,gp_Slogan,gp_SaleCount)");
			strSql.Append(" values (");
            strSql.Append("@sku_ID,@gp_StartTime,@gp_EndTime,@gp_pCount,@gp_pPric,@gp_CreateOn,@gp_CreateBy,@gp_StatusCode,@gp_IsDel,@gp_Logo,@gp_Slogan,@gp_SaleCount)");
			SqlParameter[] parameters = {
					
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@gp_StartTime", SqlDbType.DateTime),
					new SqlParameter("@gp_EndTime", SqlDbType.DateTime),
					new SqlParameter("@gp_pCount", SqlDbType.Int,4),
					new SqlParameter("@gp_pPric", SqlDbType.Decimal,5),
					new SqlParameter("@gp_CreateOn", SqlDbType.DateTime),
					new SqlParameter("@gp_CreateBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@gp_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@gp_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@gp_Logo", SqlDbType.NVarChar,20),
					new SqlParameter("@gp_Slogan", SqlDbType.NVarChar,200),
					new SqlParameter("@gp_SaleCount", SqlDbType.Int,4)};

            parameters[0].Value = model.sku_ID;
			parameters[1].Value = model.gp_StartTime;
			parameters[2].Value = model.gp_EndTime;
			parameters[3].Value = model.gp_pCount;
			parameters[4].Value = model.gp_pPric;
			parameters[5].Value = model.gp_CreateOn;
            parameters[6].Value = model.gp_CreateBy;
            parameters[7].Value = model.gp_StatusCode;
            parameters[8].Value = model.gp_IsDel;
            parameters[9].Value = model.gp_Logo;
            parameters[10].Value = model.gp_Slogan;
            parameters[11].Value = model.gp_SaleCount;

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
		public bool Update(webs_YueyxShop.Model.GroupPurchaseBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update GroupPurchaseBase set ");
            strSql.Append("sku_ID=@sku_ID,");
			strSql.Append("gp_StartTime=@gp_StartTime,");
			strSql.Append("gp_EndTime=@gp_EndTime,");
			strSql.Append("gp_pCount=@gp_pCount,");
			strSql.Append("gp_pPric=@gp_pPric,");
			strSql.Append("gp_CreateOn=@gp_CreateOn,");
            strSql.Append("gp_CreateBy=@gp_CreateBy,");
            strSql.Append("gp_StatusCode=@gp_StatusCode,");
            strSql.Append("gp_Logo=@gp_Logo,");
            strSql.Append("gp_Slogan=@gp_Slogan,");
            strSql.Append("gp_SaleCount=@gp_SaleCount,");
			strSql.Append("gp_IsDel=@gp_IsDel");
			strSql.Append(" where gp_ID=@gp_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@gp_StartTime", SqlDbType.DateTime),
					new SqlParameter("@gp_EndTime", SqlDbType.DateTime),
					new SqlParameter("@gp_pCount", SqlDbType.Int,4),
					new SqlParameter("@gp_pPric", SqlDbType.Decimal,5),
					new SqlParameter("@gp_CreateOn", SqlDbType.DateTime),
					new SqlParameter("@gp_CreateBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@gp_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@gp_Logo", SqlDbType.NVarChar,20),
					new SqlParameter("@gp_Slogan", SqlDbType.NVarChar,200),
					new SqlParameter("@gp_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@gp_SaleCount", SqlDbType.Int,4),
					new SqlParameter("@gp_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.sku_ID;
			parameters[1].Value = model.gp_StartTime;
			parameters[2].Value = model.gp_EndTime;
			parameters[3].Value = model.gp_pCount;
			parameters[4].Value = model.gp_pPric;
			parameters[5].Value = model.gp_CreateOn;
            parameters[6].Value = model.gp_CreateBy;
            parameters[7].Value = model.gp_StatusCode;
            parameters[8].Value = model.gp_Logo;
            parameters[9].Value = model.gp_Slogan;
			parameters[10].Value = model.gp_IsDel;
            parameters[11].Value = model.gp_SaleCount;
			parameters[12].Value = model.gp_ID;

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
		public bool Delete(int gp_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from GroupPurchaseBase ");
			strSql.Append(" where gp_ID=@gp_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@gp_ID", SqlDbType.Int,4)			};
			parameters[0].Value = gp_ID;

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
		public bool DeleteList(string gp_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from GroupPurchaseBase ");
			strSql.Append(" where gp_ID in ("+gp_IDlist + ")  ");
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
		public webs_YueyxShop.Model.GroupPurchaseBase GetModel(int gp_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 gp_ID,sku_ID,gp_StartTime,gp_EndTime,gp_pCount,gp_pPric,gp_CreateOn,gp_CreateBy,gp_StatusCode,gp_IsDel,gp_Logo,gp_Slogan,gp_SaleCount from GroupPurchaseBase ");
			strSql.Append(" where gp_ID=@gp_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@gp_ID", SqlDbType.Int,4)			};
			parameters[0].Value = gp_ID;

			webs_YueyxShop.Model.GroupPurchaseBase model=new webs_YueyxShop.Model.GroupPurchaseBase();
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
		public webs_YueyxShop.Model.GroupPurchaseBase DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.GroupPurchaseBase model=new webs_YueyxShop.Model.GroupPurchaseBase();
			if (row != null)
			{
				if(row["gp_ID"]!=null && row["gp_ID"].ToString()!="")
				{
					model.gp_ID=int.Parse(row["gp_ID"].ToString());
				}
                if (row["sku_ID"] != null && row["sku_ID"].ToString() != "")
				{
                    model.sku_ID = int.Parse(row["sku_ID"].ToString());
				}
				if(row["gp_StartTime"]!=null && row["gp_StartTime"].ToString()!="")
				{
					model.gp_StartTime=DateTime.Parse(row["gp_StartTime"].ToString());
				}
				if(row["gp_EndTime"]!=null && row["gp_EndTime"].ToString()!="")
				{
					model.gp_EndTime=DateTime.Parse(row["gp_EndTime"].ToString());
				}
				if(row["gp_pCount"]!=null && row["gp_pCount"].ToString()!="")
				{
					model.gp_pCount=int.Parse(row["gp_pCount"].ToString());
				}
				if(row["gp_pPric"]!=null && row["gp_pPric"].ToString()!="")
				{
					model.gp_pPric=decimal.Parse(row["gp_pPric"].ToString());
				}
				if(row["gp_CreateOn"]!=null && row["gp_CreateOn"].ToString()!="")
				{
					model.gp_CreateOn=DateTime.Parse(row["gp_CreateOn"].ToString());
				}
				if(row["gp_CreateBy"]!=null && row["gp_CreateBy"].ToString()!="")
				{
					model.gp_CreateBy= new Guid(row["gp_CreateBy"].ToString());
                }
                if (row["gp_StatusCode"] != null && row["gp_StatusCode"].ToString() != "")
                {
                    model.gp_StatusCode = int.Parse(row["gp_StatusCode"].ToString());
                }
                if (row["gp_SaleCount"] != null && row["gp_SaleCount"].ToString() != "")
                {
                    model.gp_SaleCount = int.Parse(row["gp_SaleCount"].ToString());
                }
                if (row["gp_Logo"] != null)
                {
                    model.gp_Logo = row["gp_Logo"].ToString();
                }
                if (row["gp_Slogan"] != null)
                {
                    model.gp_Slogan = row["gp_Slogan"].ToString();
                }
				if(row["gp_IsDel"]!=null && row["gp_IsDel"].ToString()!="")
				{
					if((row["gp_IsDel"].ToString()=="1")||(row["gp_IsDel"].ToString().ToLower()=="true"))
					{
						model.gp_IsDel=true;
					}
					else
					{
						model.gp_IsDel=false;
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
            strSql.Append("select gp_ID,sku_ID,gp_StartTime,gp_EndTime,gp_pCount,gp_pPric,gp_CreateOn,gp_CreateBy,gp_StatusCode,gp_IsDel,gp_Logo,gp_Slogan,gp_SaleCount ");
			strSql.Append(" FROM GroupPurchaseBase ");
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
            strSql.Append(" gp_ID,sku_ID,gp_StartTime,gp_EndTime,gp_pCount,gp_pPric,gp_CreateOn,gp_CreateBy,gp_StatusCode,gp_IsDel,gp_Logo,gp_Slogan,gp_SaleCount ");
			strSql.Append(" FROM GroupPurchaseBase ");
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
			strSql.Append("select count(1) FROM GroupPurchaseBase ");
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
				strSql.Append("order by T.gp_ID desc");
			}
			strSql.Append(")AS Row, T.*  from GroupPurchaseBase T ");
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
			parameters[0].Value = "GroupPurchaseBase";
			parameters[1].Value = "gp_ID";
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

