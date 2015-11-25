/**  版本信息模板在安装目录下，可自行修改。
* ConsigneeInfoBase.cs
*
* 功 能： N/A
* 类 名： ConsigneeInfoBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/22 14:03:34   N/A    初版
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
	/// 数据访问类:ConsigneeInfoBase
	/// </summary>
	public partial class ConsigneeInfoBase:IConsigneeInfoBase
	{
		public ConsigneeInfoBase()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("c_ID", "ConsigneeInfoBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int c_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ConsigneeInfoBase");
			strSql.Append(" where c_ID=@c_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@c_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = c_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(webs_YueyxShop.Model.ConsigneeInfoBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ConsigneeInfoBase(");
			strSql.Append("m_ID,c_Name,c_Telephone,c_Mobilephone,c_Provice,c_City,c_Count,c_Zipcode,c_Moren,c_StatusCode,c_IsDel,c_FullAddress)");
			strSql.Append(" values (");
			strSql.Append("@m_ID,@c_Name,@c_Telephone,@c_Mobilephone,@c_Provice,@c_City,@c_Count,@c_Zipcode,@c_Moren,@c_StatusCode,@c_IsDel,@c_FullAddress)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ID", SqlDbType.Int,4),
					new SqlParameter("@c_Name", SqlDbType.VarChar,10),
					new SqlParameter("@c_Telephone", SqlDbType.VarChar,11),
					new SqlParameter("@c_Mobilephone", SqlDbType.VarChar,12),
					new SqlParameter("@c_Provice", SqlDbType.Int,4),
					new SqlParameter("@c_City", SqlDbType.Int,4),
					new SqlParameter("@c_Count", SqlDbType.Int,4),
					new SqlParameter("@c_Zipcode", SqlDbType.VarChar,7),
					new SqlParameter("@c_Moren", SqlDbType.Int,4),
					new SqlParameter("@c_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@c_IsDel", SqlDbType.Int,4),
					new SqlParameter("@c_FullAddress", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.m_ID;
			parameters[1].Value = model.c_Name;
			parameters[2].Value = model.c_Telephone;
			parameters[3].Value = model.c_Mobilephone;
			parameters[4].Value = model.c_Provice;
			parameters[5].Value = model.c_City;
			parameters[6].Value = model.c_Count;
			parameters[7].Value = model.c_Zipcode;
			parameters[8].Value = model.c_Moren;
			parameters[9].Value = model.c_StatusCode;
			parameters[10].Value = model.c_IsDel;
			parameters[11].Value = model.c_FullAddress;

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
		public bool Update(webs_YueyxShop.Model.ConsigneeInfoBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ConsigneeInfoBase set ");
			strSql.Append("m_ID=@m_ID,");
			strSql.Append("c_Name=@c_Name,");
			strSql.Append("c_Telephone=@c_Telephone,");
			strSql.Append("c_Mobilephone=@c_Mobilephone,");
			strSql.Append("c_Provice=@c_Provice,");
			strSql.Append("c_City=@c_City,");
			strSql.Append("c_Count=@c_Count,");
			strSql.Append("c_Zipcode=@c_Zipcode,");
			strSql.Append("c_Moren=@c_Moren,");
			strSql.Append("c_StatusCode=@c_StatusCode,");
			strSql.Append("c_IsDel=@c_IsDel,");
			strSql.Append("c_FullAddress=@c_FullAddress");
			strSql.Append(" where c_ID=@c_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ID", SqlDbType.Int,4),
					new SqlParameter("@c_Name", SqlDbType.VarChar,10),
					new SqlParameter("@c_Telephone", SqlDbType.VarChar,11),
					new SqlParameter("@c_Mobilephone", SqlDbType.VarChar,12),
					new SqlParameter("@c_Provice", SqlDbType.Int,4),
					new SqlParameter("@c_City", SqlDbType.Int,4),
					new SqlParameter("@c_Count", SqlDbType.Int,4),
					new SqlParameter("@c_Zipcode", SqlDbType.VarChar,7),
					new SqlParameter("@c_Moren", SqlDbType.Int,4),
					new SqlParameter("@c_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@c_IsDel", SqlDbType.Int,4),
					new SqlParameter("@c_FullAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@c_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.m_ID;
			parameters[1].Value = model.c_Name;
			parameters[2].Value = model.c_Telephone;
			parameters[3].Value = model.c_Mobilephone;
			parameters[4].Value = model.c_Provice;
			parameters[5].Value = model.c_City;
			parameters[6].Value = model.c_Count;
			parameters[7].Value = model.c_Zipcode;
			parameters[8].Value = model.c_Moren;
			parameters[9].Value = model.c_StatusCode;
			parameters[10].Value = model.c_IsDel;
			parameters[11].Value = model.c_FullAddress;
			parameters[12].Value = model.c_ID;

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
		public bool Delete(int c_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ConsigneeInfoBase ");
			strSql.Append(" where c_ID=@c_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@c_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = c_ID;

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
		public bool DeleteList(string c_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ConsigneeInfoBase ");
			strSql.Append(" where c_ID in ("+c_IDlist + ")  ");
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
		public webs_YueyxShop.Model.ConsigneeInfoBase GetModel(int c_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 c_ID,m_ID,c_Name,c_Telephone,c_Mobilephone,c_Provice,c_City,c_Count,c_Zipcode,c_Moren,c_StatusCode,c_IsDel,c_FullAddress from ConsigneeInfoBase ");
			strSql.Append(" where c_ID=@c_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@c_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = c_ID;

			webs_YueyxShop.Model.ConsigneeInfoBase model=new webs_YueyxShop.Model.ConsigneeInfoBase();
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
		public webs_YueyxShop.Model.ConsigneeInfoBase DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.ConsigneeInfoBase model=new webs_YueyxShop.Model.ConsigneeInfoBase();
			if (row != null)
			{
				if(row["c_ID"]!=null && row["c_ID"].ToString()!="")
				{
					model.c_ID=int.Parse(row["c_ID"].ToString());
				}
				if(row["m_ID"]!=null && row["m_ID"].ToString()!="")
				{
					model.m_ID=int.Parse(row["m_ID"].ToString());
				}
				if(row["c_Name"]!=null)
				{
					model.c_Name=row["c_Name"].ToString();
				}
				if(row["c_Telephone"]!=null)
				{
					model.c_Telephone=row["c_Telephone"].ToString();
				}
				if(row["c_Mobilephone"]!=null)
				{
					model.c_Mobilephone=row["c_Mobilephone"].ToString();
				}
                IDAL.IRegionBase rb = new DAL.RegionBase();
				if(row["c_Provice"]!=null && row["c_Provice"].ToString()!="")
				{
					model.c_Provice=int.Parse(row["c_Provice"].ToString());
                    if (rb.Exists(model.c_Provice.Value))
                    {
                        model.c_CProvice = rb.GetModel(model.c_Provice.Value).reg_Name;
                    }
				}
				if(row["c_City"]!=null && row["c_City"].ToString()!="")
				{
                    model.c_City = int.Parse(row["c_City"].ToString());
                    if (rb.Exists(model.c_City.Value))
                    {
                        model.c_CCity = rb.GetModel(model.c_City.Value).reg_Name;
                    }
				}
				if(row["c_Count"]!=null && row["c_Count"].ToString()!="")
				{
                    model.c_Count = int.Parse(row["c_Count"].ToString());
                    if (rb.Exists(model.c_Count.Value))
                    {
                        model.c_CCount = rb.GetModel(model.c_Count.Value).reg_Name;
                    }
				}
				if(row["c_Zipcode"]!=null)
				{
					model.c_Zipcode=row["c_Zipcode"].ToString();
				}
				if(row["c_Moren"]!=null && row["c_Moren"].ToString()!="")
				{
					model.c_Moren=int.Parse(row["c_Moren"].ToString());
				}
				if(row["c_StatusCode"]!=null && row["c_StatusCode"].ToString()!="")
				{
					model.c_StatusCode=int.Parse(row["c_StatusCode"].ToString());
				}
				if(row["c_IsDel"]!=null && row["c_IsDel"].ToString()!="")
				{
					model.c_IsDel=int.Parse(row["c_IsDel"].ToString());
				}
				if(row["c_FullAddress"]!=null)
				{
					model.c_FullAddress=row["c_FullAddress"].ToString();
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
			strSql.Append("select c_ID,m_ID,c_Name,c_Telephone,c_Mobilephone,c_Provice,c_City,c_Count,c_Zipcode,c_Moren,c_StatusCode,c_IsDel,c_FullAddress ");
			strSql.Append(" FROM ConsigneeInfoBase ");
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
			strSql.Append(" c_ID,m_ID,c_Name,c_Telephone,c_Mobilephone,c_Provice,c_City,c_Count,c_Zipcode,c_Moren,c_StatusCode,c_IsDel,c_FullAddress ");
			strSql.Append(" FROM ConsigneeInfoBase ");
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
			strSql.Append("select count(1) FROM ConsigneeInfoBase ");
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
				strSql.Append("order by T.c_ID desc");
			}
			strSql.Append(")AS Row, T.*  from ConsigneeInfoBase T ");
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
			parameters[0].Value = "ConsigneeInfoBase";
			parameters[1].Value = "c_ID";
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

