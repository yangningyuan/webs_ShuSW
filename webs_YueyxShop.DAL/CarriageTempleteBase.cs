using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using webs_YueyxShop.IDAL;
using DBUtility;//Please add references
namespace webs_YueyxShop.DAL
{
	/// <summary>
	/// 数据访问类:CarriageTempleteBase
	/// </summary>
	public partial class CarriageTempleteBase:ICarriageTempleteBase
	{
		public CarriageTempleteBase()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ct_ID", "CarriageTempleteBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ct_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CarriageTempleteBase");
			strSql.Append(" where ct_ID=@ct_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ct_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ct_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(webs_YueyxShop.Model.CarriageTempleteBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CarriageTempleteBase(");
            strSql.Append("ct_Name,ct_ValuationType,ct_CreateOn,ct_CreateBy,ct_ModifyOn,ct_ModifyBy,ct_StatusCode,ct_IsDel)");
			strSql.Append(" values (");
            strSql.Append("@ct_Name,@ct_ValuationType,@ct_CreateOn,@ct_CreateBy,@ct_ModifyOn,@ct_ModifyBy,@ct_StatusCode,@ct_IsDel)");
            strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ct_Name", SqlDbType.VarChar,100),
					new SqlParameter("@ct_ValuationType", SqlDbType.Int,4),
					new SqlParameter("@ct_CreateOn", SqlDbType.DateTime),
					new SqlParameter("@ct_CreateBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ct_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@ct_ModifyBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ct_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@ct_IsDel", SqlDbType.Bit,1)};
			parameters[0].Value = model.ct_Name;
            parameters[1].Value = model.ct_ValuationType;
            parameters[2].Value = model.ct_CreateOn;
            parameters[3].Value = model.ct_CreateBy;
            parameters[4].Value = model.ct_ModifyOn;
            parameters[5].Value = model.ct_ModifyBy;
			parameters[6].Value = model.ct_StatusCode;
			parameters[7].Value = model.ct_IsDel;

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
		public bool Update(webs_YueyxShop.Model.CarriageTempleteBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CarriageTempleteBase set ");
			strSql.Append("ct_Name=@ct_Name,");
			strSql.Append("ct_ValuationType=@ct_ValuationType,");
			strSql.Append("ct_StatusCode=@ct_StatusCode,");
			strSql.Append("ct_IsDel=@ct_IsDel");
			strSql.Append(" where ct_ID=@ct_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ct_Name", SqlDbType.VarChar,100),
					new SqlParameter("@ct_ValuationType", SqlDbType.Int,4),
					new SqlParameter("@ct_CreateOn", SqlDbType.DateTime),
					new SqlParameter("@ct_CreateBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ct_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@ct_ModifyBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ct_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@ct_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@ct_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.ct_Name;
            parameters[1].Value = model.ct_ValuationType;
            parameters[2].Value = model.ct_CreateOn;
            parameters[3].Value = Guid.NewGuid();
            parameters[4].Value = model.ct_ModifyOn;
            parameters[5].Value = Guid.NewGuid();
            parameters[6].Value = model.ct_StatusCode;
            parameters[7].Value = model.ct_IsDel;
            parameters[8].Value = model.ct_ID;

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
		public bool Delete(int ct_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CarriageTempleteBase ");
			strSql.Append(" where ct_ID=@ct_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ct_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ct_ID;

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
		public bool DeleteList(string ct_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CarriageTempleteBase ");
			strSql.Append(" where ct_ID in ("+ct_IDlist + ")  ");
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
		public webs_YueyxShop.Model.CarriageTempleteBase GetModel(int ct_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 ct_ID,ct_Name,ct_ValuationType,ct_CreateOn,ct_CreateBy,ct_ModifyOn,ct_ModifyBy,ct_StatusCode,ct_IsDel from CarriageTempleteBase ");
			strSql.Append(" where ct_ID=@ct_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ct_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ct_ID;

			webs_YueyxShop.Model.CarriageTempleteBase model=new webs_YueyxShop.Model.CarriageTempleteBase();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ct_ID"]!=null && ds.Tables[0].Rows[0]["ct_ID"].ToString()!="")
				{
					model.ct_ID=int.Parse(ds.Tables[0].Rows[0]["ct_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ct_Name"]!=null && ds.Tables[0].Rows[0]["ct_Name"].ToString()!="")
				{
					model.ct_Name=ds.Tables[0].Rows[0]["ct_Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ct_ValuationType"]!=null && ds.Tables[0].Rows[0]["ct_ValuationType"].ToString()!="")
				{
					model.ct_ValuationType=int.Parse(ds.Tables[0].Rows[0]["ct_ValuationType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ct_CreateOn"] != null && ds.Tables[0].Rows[0]["ct_CreateOn"].ToString() != "")
                {
                    model.ct_CreateOn = DateTime.Parse(ds.Tables[0].Rows[0]["ct_CreateOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ct_CreateBy"] != null && ds.Tables[0].Rows[0]["ct_CreateBy"].ToString() != "")
                {
                    model.ct_CreateBy = new Guid(ds.Tables[0].Rows[0]["ct_CreateBy"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ct_ModifyOn"] != null && ds.Tables[0].Rows[0]["ct_ModifyOn"].ToString() != "")
                {
                    model.ct_ModifyOn = DateTime.Parse(ds.Tables[0].Rows[0]["ct_ModifyOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ct_ModifyBy"] != null && ds.Tables[0].Rows[0]["ct_ModifyBy"].ToString() != "")
                {
                    model.ct_ModifyBy = new Guid(ds.Tables[0].Rows[0]["ct_ModifyBy"].ToString());
                }
				if(ds.Tables[0].Rows[0]["ct_StatusCode"]!=null && ds.Tables[0].Rows[0]["ct_StatusCode"].ToString()!="")
				{
					model.ct_StatusCode=int.Parse(ds.Tables[0].Rows[0]["ct_StatusCode"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ct_IsDel"]!=null && ds.Tables[0].Rows[0]["ct_IsDel"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["ct_IsDel"].ToString()=="1")||(ds.Tables[0].Rows[0]["ct_IsDel"].ToString().ToLower()=="true"))
					{
						model.ct_IsDel=true;
					}
					else
					{
						model.ct_IsDel=false;
					}
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
            strSql.Append("select ct_ID,ct_Name,ct_ValuationType,ct_CreateOn,ct_CreateBy,ct_ModifyOn,ct_ModifyBy,ct_StatusCode,ct_IsDel ");
			strSql.Append(" FROM CarriageTempleteBase ");
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
            strSql.Append(" ct_ID,ct_Name,ct_ValuationType,ct_CreateOn,ct_CreateBy,ct_ModifyOn,ct_ModifyBy,ct_StatusCode,ct_IsDel ");
			strSql.Append(" FROM CarriageTempleteBase ");
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
			strSql.Append("select count(1) FROM CarriageTempleteBase ");
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
				strSql.Append("order by T.ct_ID desc");
			}
			strSql.Append(")AS Row, T.*  from CarriageTempleteBase T ");
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
			parameters[0].Value = "CarriageTempleteBase";
			parameters[1].Value = "ct_ID";
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

