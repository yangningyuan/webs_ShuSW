using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using webs_YueyxShop.IDAL;
using DBUtility;//Please add references
namespace webs_YueyxShop.DAL
{
	/// <summary>
	/// 数据访问类:SysLogBase
	/// </summary>
	public partial class SysLogBase:ISysLogBase
	{
		public SysLogBase()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("sl_ID", "SysLogBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int sl_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SysLogBase");
			strSql.Append(" where sl_ID=@sl_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@sl_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = sl_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(webs_YueyxShop.Model.SysLogBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SysLogBase(");
			strSql.Append("sl_LeiX,sl_ShiJ,sl_DiZh,sl_MiaoSh,sl_LeiX_CaoZ)");
			strSql.Append(" values (");
			strSql.Append("@sl_LeiX,@sl_ShiJ,@sl_DiZh,@sl_MiaoSh,@sl_LeiX_CaoZ)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@sl_LeiX", SqlDbType.Int,4),
					new SqlParameter("@sl_ShiJ", SqlDbType.DateTime),
					new SqlParameter("@sl_DiZh", SqlDbType.VarChar,100),
					new SqlParameter("@sl_MiaoSh", SqlDbType.NVarChar,500),
					new SqlParameter("@sl_LeiX_CaoZ", SqlDbType.VarChar,30)};
			parameters[0].Value = model.sl_LeiX;
			parameters[1].Value = model.sl_ShiJ;
			parameters[2].Value = model.sl_DiZh;
			parameters[3].Value = model.sl_MiaoSh;
			parameters[4].Value = model.sl_LeiX_CaoZ;

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
		public bool Update(webs_YueyxShop.Model.SysLogBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SysLogBase set ");
			strSql.Append("sl_LeiX=@sl_LeiX,");
			strSql.Append("sl_ShiJ=@sl_ShiJ,");
			strSql.Append("sl_DiZh=@sl_DiZh,");
			strSql.Append("sl_MiaoSh=@sl_MiaoSh,");
			strSql.Append("sl_LeiX_CaoZ=@sl_LeiX_CaoZ");
			strSql.Append(" where sl_ID=@sl_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@sl_LeiX", SqlDbType.Int,4),
					new SqlParameter("@sl_ShiJ", SqlDbType.DateTime),
					new SqlParameter("@sl_DiZh", SqlDbType.VarChar,100),
					new SqlParameter("@sl_MiaoSh", SqlDbType.NVarChar,500),
					new SqlParameter("@sl_LeiX_CaoZ", SqlDbType.VarChar,30),
					new SqlParameter("@sl_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.sl_LeiX;
			parameters[1].Value = model.sl_ShiJ;
			parameters[2].Value = model.sl_DiZh;
			parameters[3].Value = model.sl_MiaoSh;
			parameters[4].Value = model.sl_LeiX_CaoZ;
			parameters[5].Value = model.sl_ID;

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
		public bool Delete(int sl_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SysLogBase ");
			strSql.Append(" where sl_ID=@sl_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@sl_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = sl_ID;

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
		public bool DeleteList(string sl_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SysLogBase ");
			strSql.Append(" where sl_ID in ("+sl_IDlist + ")  ");
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
		public webs_YueyxShop.Model.SysLogBase GetModel(int sl_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sl_ID,sl_LeiX,sl_ShiJ,sl_DiZh,sl_MiaoSh,sl_LeiX_CaoZ from SysLogBase ");
			strSql.Append(" where sl_ID=@sl_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@sl_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = sl_ID;

			webs_YueyxShop.Model.SysLogBase model=new webs_YueyxShop.Model.SysLogBase();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["sl_ID"]!=null && ds.Tables[0].Rows[0]["sl_ID"].ToString()!="")
				{
					model.sl_ID=int.Parse(ds.Tables[0].Rows[0]["sl_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sl_LeiX"]!=null && ds.Tables[0].Rows[0]["sl_LeiX"].ToString()!="")
				{
					model.sl_LeiX=int.Parse(ds.Tables[0].Rows[0]["sl_LeiX"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sl_ShiJ"]!=null && ds.Tables[0].Rows[0]["sl_ShiJ"].ToString()!="")
				{
					model.sl_ShiJ=DateTime.Parse(ds.Tables[0].Rows[0]["sl_ShiJ"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sl_DiZh"]!=null && ds.Tables[0].Rows[0]["sl_DiZh"].ToString()!="")
				{
					model.sl_DiZh=ds.Tables[0].Rows[0]["sl_DiZh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sl_MiaoSh"]!=null && ds.Tables[0].Rows[0]["sl_MiaoSh"].ToString()!="")
				{
					model.sl_MiaoSh=ds.Tables[0].Rows[0]["sl_MiaoSh"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sl_LeiX_CaoZ"]!=null && ds.Tables[0].Rows[0]["sl_LeiX_CaoZ"].ToString()!="")
				{
					model.sl_LeiX_CaoZ=ds.Tables[0].Rows[0]["sl_LeiX_CaoZ"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select sl_ID,sl_LeiX,sl_ShiJ,sl_DiZh,sl_MiaoSh,sl_LeiX_CaoZ ");
			strSql.Append(" FROM SysLogBase ");
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
			strSql.Append(" sl_ID,sl_LeiX,sl_ShiJ,sl_DiZh,sl_MiaoSh,sl_LeiX_CaoZ ");
			strSql.Append(" FROM SysLogBase ");
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
			strSql.Append("select count(1) FROM SysLogBase ");
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
				strSql.Append("order by T.sl_ID desc");
			}
			strSql.Append(")AS Row, T.*  from SysLogBase T ");
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
			parameters[0].Value = "SysLogBase";
			parameters[1].Value = "sl_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

