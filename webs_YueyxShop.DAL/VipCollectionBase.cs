/**  版本信息模板在安装目录下，可自行修改。
* VipCollectionBase.cs
*
* 功 能： N/A
* 类 名： VipCollectionBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/26 18:53:37   N/A    初版
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
	/// 数据访问类:VipCollectionBase
	/// </summary>
	public partial class VipCollectionBase:IVipCollectionBase
	{
		public VipCollectionBase()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("vc_ID", "VipCollectionBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int vc_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from VipCollectionBase");
			strSql.Append(" where vc_ID=@vc_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@vc_ID", SqlDbType.Int,4)			};
			parameters[0].Value = vc_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(webs_YueyxShop.Model.VipCollectionBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VipCollectionBase(");
			strSql.Append("sku_ID,m_ID,vc_CreateOn,vc_IsDel)");
			strSql.Append(" values (");
			strSql.Append("@sku_ID,@m_ID,@vc_CreateOn,@vc_IsDel)");
			SqlParameter[] parameters = {
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@m_ID", SqlDbType.Int,4),
					new SqlParameter("@vc_CreateOn", SqlDbType.DateTime),
					new SqlParameter("@vc_IsDel", SqlDbType.Bit,1)};
			parameters[0].Value = model.sku_ID;
			parameters[1].Value = model.m_ID;
			parameters[2].Value = model.vc_CreateOn;
			parameters[3].Value = model.vc_IsDel;

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
		public bool Update(webs_YueyxShop.Model.VipCollectionBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VipCollectionBase set ");
			strSql.Append("sku_ID=@sku_ID,");
			strSql.Append("m_ID=@m_ID,");
			strSql.Append("vc_CreateOn=@vc_CreateOn,");
			strSql.Append("vc_IsDel=@vc_IsDel");
			strSql.Append(" where vc_ID=@vc_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@m_ID", SqlDbType.Int,4),
					new SqlParameter("@vc_CreateOn", SqlDbType.DateTime),
					new SqlParameter("@vc_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@vc_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.sku_ID;
			parameters[1].Value = model.m_ID;
			parameters[2].Value = model.vc_CreateOn;
			parameters[3].Value = model.vc_IsDel;
			parameters[4].Value = model.vc_ID;

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
		public bool Delete(int vc_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update  VipCollectionBase set vc_IsDel=1");
			strSql.Append(" where vc_ID=@vc_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@vc_ID", SqlDbType.Int,4)			};
			parameters[0].Value = vc_ID;

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
        public bool Deletebyskuid(int m_id,int skuid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  VipCollectionBase set vc_IsDel=1");
            strSql.Append(" where m_ID=@m_Id and sku_ID=@sku_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@m_Id", SqlDbType.Int,4)	,
					new SqlParameter("@sku_ID", SqlDbType.Int,4)			};
            parameters[0].Value = m_id;
            parameters[1].Value = skuid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
		public bool DeleteList(string vc_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update  VipCollectionBase set vc_IsDel=1 ");
			strSql.Append(" where "+vc_IDlist );
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
		public webs_YueyxShop.Model.VipCollectionBase GetModel(int vc_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 vc_ID,sku_ID,m_ID,vc_CreateOn,vc_IsDel from VipCollectionBase ");
			strSql.Append(" where vc_ID=@vc_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@vc_ID", SqlDbType.Int,4)			};
			parameters[0].Value = vc_ID;

			webs_YueyxShop.Model.VipCollectionBase model=new webs_YueyxShop.Model.VipCollectionBase();
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
		public webs_YueyxShop.Model.VipCollectionBase DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.VipCollectionBase model=new webs_YueyxShop.Model.VipCollectionBase();
			if (row != null)
			{
				if(row["vc_ID"]!=null && row["vc_ID"].ToString()!="")
				{
					model.vc_ID=int.Parse(row["vc_ID"].ToString());
				}
				if(row["sku_ID"]!=null && row["sku_ID"].ToString()!="")
				{
					model.sku_ID=int.Parse(row["sku_ID"].ToString());
				}
				if(row["m_ID"]!=null && row["m_ID"].ToString()!="")
				{
					model.m_ID=int.Parse(row["m_ID"].ToString());
				}
				if(row["vc_CreateOn"]!=null && row["vc_CreateOn"].ToString()!="")
				{
					model.vc_CreateOn=DateTime.Parse(row["vc_CreateOn"].ToString());
				}
				if(row["vc_IsDel"]!=null && row["vc_IsDel"].ToString()!="")
				{
					if((row["vc_IsDel"].ToString()=="1")||(row["vc_IsDel"].ToString().ToLower()=="true"))
					{
						model.vc_IsDel=true;
					}
					else
					{
						model.vc_IsDel=false;
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
			strSql.Append("select vc_ID,sku_ID,m_ID,vc_CreateOn,vc_IsDel ");
			strSql.Append(" FROM VipCollectionBase ");
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
			strSql.Append(" vc_ID,sku_ID,m_ID,vc_CreateOn,vc_IsDel ");
			strSql.Append(" FROM VipCollectionBase ");
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
			strSql.Append("select count(1) FROM VipCollectionBase ");
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
				strSql.Append("order by T.vc_ID desc");
			}
			strSql.Append(")AS Row, T.*  from VipCollectionBase T ");
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
			parameters[0].Value = "VipCollectionBase";
			parameters[1].Value = "vc_ID";
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

