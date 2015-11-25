/**  版本信息模板在安装目录下，可自行修改。
* RegionBase.cs
*
* 功 能： N/A
* 类 名： RegionBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/13 11:35:11   N/A    初版
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
	/// 数据访问类:RegionBase
	/// </summary>
	public partial class RegionBase:IRegionBase
	{
		public RegionBase()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("reg_ID", "RegionBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int reg_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from RegionBase");
			strSql.Append(" where reg_ID=@reg_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@reg_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = reg_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(webs_YueyxShop.Model.RegionBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RegionBase(");
			strSql.Append("reg_Code,reg_PId,reg_Name)");
			strSql.Append(" values (");
			strSql.Append("@reg_Code,@reg_PId,@reg_Name)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@reg_Code", SqlDbType.Int,4),
					new SqlParameter("@reg_PId", SqlDbType.Int,4),
					new SqlParameter("@reg_Name", SqlDbType.VarChar,15)};
			parameters[0].Value = model.reg_Code;
			parameters[1].Value = model.reg_PId;
			parameters[2].Value = model.reg_Name;

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
		public bool Update(webs_YueyxShop.Model.RegionBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RegionBase set ");
			strSql.Append("reg_Code=@reg_Code,");
			strSql.Append("reg_PId=@reg_PId,");
			strSql.Append("reg_Name=@reg_Name");
			strSql.Append(" where reg_ID=@reg_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@reg_Code", SqlDbType.Int,4),
					new SqlParameter("@reg_PId", SqlDbType.Int,4),
					new SqlParameter("@reg_Name", SqlDbType.VarChar,15),
					new SqlParameter("@reg_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.reg_Code;
			parameters[1].Value = model.reg_PId;
			parameters[2].Value = model.reg_Name;
			parameters[3].Value = model.reg_ID;

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
		public bool Delete(int reg_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RegionBase ");
			strSql.Append(" where reg_ID=@reg_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@reg_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = reg_ID;

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
		public bool DeleteList(string reg_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RegionBase ");
			strSql.Append(" where reg_ID in ("+reg_IDlist + ")  ");
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
		public webs_YueyxShop.Model.RegionBase GetModel(int reg_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 reg_ID,reg_Code,reg_PId,reg_Name from RegionBase ");
			strSql.Append(" where reg_ID=@reg_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@reg_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = reg_ID;

			webs_YueyxShop.Model.RegionBase model=new webs_YueyxShop.Model.RegionBase();
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
        /// 通过编码得到一个对象实体
        /// </summary>
        public webs_YueyxShop.Model.RegionBase GetModelByCode(int reg_Code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 reg_ID,reg_Code,reg_PId,reg_Name from RegionBase ");
            strSql.Append(" where reg_Code=@reg_Code");
            SqlParameter[] parameters = {
					new SqlParameter("@reg_Code", SqlDbType.Int,4)
			};
            parameters[0].Value = reg_Code;

            webs_YueyxShop.Model.RegionBase model = new webs_YueyxShop.Model.RegionBase();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
		public webs_YueyxShop.Model.RegionBase DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.RegionBase model=new webs_YueyxShop.Model.RegionBase();
			if (row != null)
			{
				if(row["reg_ID"]!=null && row["reg_ID"].ToString()!="")
				{
					model.reg_ID=int.Parse(row["reg_ID"].ToString());
				}
				if(row["reg_Code"]!=null && row["reg_Code"].ToString()!="")
				{
					model.reg_Code=int.Parse(row["reg_Code"].ToString());
				}
				if(row["reg_PId"]!=null && row["reg_PId"].ToString()!="")
				{
					model.reg_PId=int.Parse(row["reg_PId"].ToString());
				}
				if(row["reg_Name"]!=null)
				{
					model.reg_Name=row["reg_Name"].ToString();
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
			strSql.Append("select reg_ID,reg_Code,reg_PId,reg_Name ");
			strSql.Append(" FROM RegionBase ");
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
			strSql.Append(" reg_ID,reg_Code,reg_PId,reg_Name ");
			strSql.Append(" FROM RegionBase ");
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
			strSql.Append("select count(1) FROM RegionBase ");
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
				strSql.Append("order by T.reg_ID desc");
			}
			strSql.Append(")AS Row, T.*  from RegionBase T ");
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
			parameters[0].Value = "RegionBase";
			parameters[1].Value = "reg_ID";
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

