﻿/**  版本信息模板在安装目录下，可自行修改。
* EmpRolesDetails.cs
*
* 功 能： N/A
* 类 名： EmpRolesDetails
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/28 14:36:02   N/A    初版
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
	/// 数据访问类:EmpRolesDetails
	/// </summary>
	public partial class EmpRolesDetails:IEmpRolesDetails
	{
		public EmpRolesDetails()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid e_ID,Guid r_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from EmpRolesDetails");
			strSql.Append(" where e_ID=@e_ID and r_ID=@r_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@e_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = e_ID;
			parameters[1].Value = r_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(webs_YueyxShop.Model.EmpRolesDetails model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into EmpRolesDetails(");
			strSql.Append("e_ID,r_ID)");
			strSql.Append(" values (");
			strSql.Append("@e_ID,@r_ID)");
			SqlParameter[] parameters = {
					new SqlParameter("@e_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.e_ID;
			parameters[1].Value = model.r_ID;

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
		public bool Update(webs_YueyxShop.Model.EmpRolesDetails model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update EmpRolesDetails set ");
			strSql.Append("e_ID=@e_ID,");
			strSql.Append("r_ID=@r_ID");
			strSql.Append(" where e_ID=@e_ID and r_ID=@r_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@e_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.e_ID;
			parameters[1].Value = model.r_ID;

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
		public bool Delete(Guid e_ID,Guid r_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from EmpRolesDetails ");
			strSql.Append(" where e_ID=@e_ID and r_ID=@r_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@e_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = e_ID;
			parameters[1].Value = r_ID;

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
        /// 删除员工的所有角色权限
        /// </summary>
        /// <param name="e_ID">角色ID</param>
        /// <returns></returns>
        public bool DeleteByEId(Guid e_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from EmpRolesDetails ");
            strSql.Append(" where e_ID=@e_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@e_ID", SqlDbType.UniqueIdentifier,16)
                    };
            parameters[0].Value = e_ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            
            return true;
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public webs_YueyxShop.Model.EmpRolesDetails GetModel(Guid e_ID,Guid r_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 e_ID,r_ID from EmpRolesDetails ");
			strSql.Append(" where e_ID=@e_ID and r_ID=@r_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@e_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = e_ID;
			parameters[1].Value = r_ID;

			webs_YueyxShop.Model.EmpRolesDetails model=new webs_YueyxShop.Model.EmpRolesDetails();
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
		public webs_YueyxShop.Model.EmpRolesDetails DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.EmpRolesDetails model=new webs_YueyxShop.Model.EmpRolesDetails();
			if (row != null)
			{
				if(row["e_ID"]!=null && row["e_ID"].ToString()!="")
				{
					model.e_ID= new Guid(row["e_ID"].ToString());
				}
				if(row["r_ID"]!=null && row["r_ID"].ToString()!="")
				{
					model.r_ID= new Guid(row["r_ID"].ToString());
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
			strSql.Append("select e_ID,r_ID ");
			strSql.Append(" FROM EmpRolesDetails ");
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
			strSql.Append(" e_ID,r_ID ");
			strSql.Append(" FROM EmpRolesDetails ");
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
			strSql.Append("select count(1) FROM EmpRolesDetails ");
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
				strSql.Append("order by T.r_ID desc");
			}
			strSql.Append(")AS Row, T.*  from EmpRolesDetails T ");
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
			parameters[0].Value = "EmpRolesDetails";
			parameters[1].Value = "r_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

        public bool UpdateRolesDetails(string items, string eId)
        {
            Guid eID =new Guid(eId);
            string[] list = items.Split(',');
            bool result = true;

            if (DeleteByEId(eID))
            {
                foreach (string rId in list)
                {
                    if (!string.IsNullOrWhiteSpace(rId))
                    {
                        if (!Add(new webs_YueyxShop.Model.EmpRolesDetails() { e_ID = eID, r_ID = new Guid(rId) }))
                        {
                            result = false;
                        }
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

		#endregion  ExtensionMethod
	}
}

