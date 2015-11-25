using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using webs_YueyxShop.IDAL;
using DBUtility;//Please add references
namespace webs_YueyxShop.DAL
{
	/// <summary>
	/// 数据访问类:CarriageBase
	/// </summary>
	public partial class CarriageBase:ICarriageBase
	{
		public CarriageBase()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("car_ID", "CarriageBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int car_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CarriageBase");
			strSql.Append(" where car_ID=@car_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@car_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = car_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(webs_YueyxShop.Model.CarriageBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CarriageBase(");
            strSql.Append("ct_ID,st_ID,car_measurementUnits,car_shouCount,car_shouCarriage,car_xuCount,car_xuCarriage,car_area,car_CreateOn,car_CreateBy,car_ModifyOn,car_ModifyBy,car_Ismoren,car_StatusCode,car_IsDel)");
			strSql.Append(" values (");
            strSql.Append("@ct_ID,@st_ID,@car_measurementUnits,@car_shouCount,@car_shouCarriage,@car_xuCount,@car_xuCarriage,@car_area,@car_CreateOn,@car_CreateBy,@car_ModifyOn,@car_ModifyBy,@car_Ismoren,@car_StatusCode,@car_IsDel)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ct_ID", SqlDbType.Int,4),
					new SqlParameter("@st_ID", SqlDbType.Char,20),
					new SqlParameter("@car_measurementUnits", SqlDbType.Int,4),
					new SqlParameter("@car_shouCount", SqlDbType.Int,4),
					new SqlParameter("@car_shouCarriage", SqlDbType.Decimal,5),
					new SqlParameter("@car_xuCount", SqlDbType.Int,4),
					new SqlParameter("@car_xuCarriage", SqlDbType.Decimal,5),
					new SqlParameter("@car_area", SqlDbType.VarChar,500),
					new SqlParameter("@car_CreateOn", SqlDbType.DateTime),
					new SqlParameter("@car_CreateBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@car_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@car_ModifyBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@car_Ismoren", SqlDbType.Bit,1),
					new SqlParameter("@car_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@car_IsDel", SqlDbType.Bit,1)};
			parameters[0].Value = model.ct_ID;
			parameters[1].Value = model.St_ID;
			parameters[2].Value = model.car_measurementUnits;
			parameters[3].Value = model.car_shouCount;
			parameters[4].Value = model.car_shouCarriage;
			parameters[5].Value = model.car_xuCount;
			parameters[6].Value = model.car_xuCarriage;
            parameters[7].Value = model.car_area;
            parameters[8].Value = model.car_CreateOn;
            parameters[9].Value = Guid.NewGuid();
            parameters[10].Value = model.car_ModifyOn;
            parameters[11].Value = Guid.NewGuid();
			parameters[12].Value = model.car_Ismoren;
			parameters[13].Value = model.car_StatusCode;
			parameters[14].Value = model.car_IsDel;

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
		public bool Update(webs_YueyxShop.Model.CarriageBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CarriageBase set ");
			strSql.Append("ct_ID=@ct_ID,");
            strSql.Append("st_ID=@st_ID,");
			strSql.Append("car_measurementUnits=@car_measurementUnits,");
			strSql.Append("car_shouCount=@car_shouCount,");
			strSql.Append("car_shouCarriage=@car_shouCarriage,");
			strSql.Append("car_xuCount=@car_xuCount,");
			strSql.Append("car_xuCarriage=@car_xuCarriage,");
            strSql.Append("car_area=@car_area,");
            strSql.Append("car_CreateOn=@car_CreateOn,");
            strSql.Append("car_CreateBy=@car_CreateBy,");
            strSql.Append("car_ModifyOn=@car_ModifyOn,");
            strSql.Append("car_ModifyBy=@car_ModifyBy,");
			strSql.Append("car_Ismoren=@car_Ismoren,");
			strSql.Append("car_StatusCode=@car_StatusCode,");
			strSql.Append("car_IsDel=@car_IsDel");
			strSql.Append(" where car_ID=@car_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ct_ID", SqlDbType.Int,4),
					new SqlParameter("@st_ID", SqlDbType.Char,20),
					new SqlParameter("@car_measurementUnits", SqlDbType.Int,4),
					new SqlParameter("@car_shouCount", SqlDbType.Int,4),
					new SqlParameter("@car_shouCarriage", SqlDbType.Decimal,5),
					new SqlParameter("@car_xuCount", SqlDbType.Int,4),
					new SqlParameter("@car_xuCarriage", SqlDbType.Decimal,5),
					new SqlParameter("@car_area", SqlDbType.VarChar,500),
					new SqlParameter("@car_CreateOn", SqlDbType.DateTime),
					new SqlParameter("@car_CreateBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@car_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@car_ModifyBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@car_Ismoren", SqlDbType.Bit,1),
					new SqlParameter("@car_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@car_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@car_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.ct_ID;
			parameters[1].Value = model.St_ID;
			parameters[2].Value = model.car_measurementUnits;
			parameters[3].Value = model.car_shouCount;
			parameters[4].Value = model.car_shouCarriage;
			parameters[5].Value = model.car_xuCount;
			parameters[6].Value = model.car_xuCarriage;
            parameters[7].Value = model.car_area;
            parameters[8].Value = model.car_CreateOn;
            parameters[9].Value = model.car_CreateBy;
            parameters[10].Value = model.car_ModifyOn;
            parameters[11].Value = model.car_ModifyBy;
			parameters[12].Value = model.car_Ismoren;
			parameters[13].Value = model.car_StatusCode;
			parameters[14].Value = model.car_IsDel;
			parameters[15].Value = model.car_ID;

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
		public bool Delete(int car_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CarriageBase ");
			strSql.Append(" where car_ID=@car_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@car_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = car_ID;

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
		public bool DeleteList(string car_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CarriageBase ");
			strSql.Append(" where car_ID in ("+car_IDlist + ")  ");
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
		public webs_YueyxShop.Model.CarriageBase GetModel(int car_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 car_ID,ct_ID,st_ID,car_measurementUnits,car_shouCount,car_shouCarriage,car_xuCount,car_xuCarriage,car_area,car_CreateOn,car_CreateBy,car_ModifyOn,car_ModifyBy,car_Ismoren,car_StatusCode,car_IsDel from CarriageBase ");
			strSql.Append(" where car_ID=@car_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@car_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = car_ID;

			webs_YueyxShop.Model.CarriageBase model=new webs_YueyxShop.Model.CarriageBase();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["car_ID"]!=null && ds.Tables[0].Rows[0]["car_ID"].ToString()!="")
				{
					model.car_ID=int.Parse(ds.Tables[0].Rows[0]["car_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ct_ID"]!=null && ds.Tables[0].Rows[0]["ct_ID"].ToString()!="")
				{
					model.ct_ID=int.Parse(ds.Tables[0].Rows[0]["ct_ID"].ToString());
				}
                if (ds.Tables[0].Rows[0]["st_ID"] != null && ds.Tables[0].Rows[0]["st_ID"].ToString() != "")
				{
                    model.St_ID = ds.Tables[0].Rows[0]["st_ID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["car_measurementUnits"]!=null && ds.Tables[0].Rows[0]["car_measurementUnits"].ToString()!="")
				{
					model.car_measurementUnits=int.Parse(ds.Tables[0].Rows[0]["car_measurementUnits"].ToString());
				}
				if(ds.Tables[0].Rows[0]["car_shouCount"]!=null && ds.Tables[0].Rows[0]["car_shouCount"].ToString()!="")
				{
					model.car_shouCount=int.Parse(ds.Tables[0].Rows[0]["car_shouCount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["car_shouCarriage"]!=null && ds.Tables[0].Rows[0]["car_shouCarriage"].ToString()!="")
				{
					model.car_shouCarriage=decimal.Parse(ds.Tables[0].Rows[0]["car_shouCarriage"].ToString());
				}
				if(ds.Tables[0].Rows[0]["car_xuCount"]!=null && ds.Tables[0].Rows[0]["car_xuCount"].ToString()!="")
				{
					model.car_xuCount=int.Parse(ds.Tables[0].Rows[0]["car_xuCount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["car_xuCarriage"]!=null && ds.Tables[0].Rows[0]["car_xuCarriage"].ToString()!="")
				{
					model.car_xuCarriage=decimal.Parse(ds.Tables[0].Rows[0]["car_xuCarriage"].ToString());
				}
				if(ds.Tables[0].Rows[0]["car_area"]!=null && ds.Tables[0].Rows[0]["car_area"].ToString()!="")
				{
					model.car_area=ds.Tables[0].Rows[0]["car_area"].ToString();
                }
                if (ds.Tables[0].Rows[0]["car_CreateOn"] != null && ds.Tables[0].Rows[0]["car_CreateOn"].ToString() != "")
                {
                    model.car_CreateOn= DateTime.Parse(ds.Tables[0].Rows[0]["car_CreateOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["car_CreateBy"] != null && ds.Tables[0].Rows[0]["car_CreateBy"].ToString() != "")
                {
                    model.car_CreateBy =  new Guid(ds.Tables[0].Rows[0]["car_CreateBy"].ToString());
                }
                if (ds.Tables[0].Rows[0]["car_ModifyOn"] != null && ds.Tables[0].Rows[0]["car_ModifyOn"].ToString() != "")
                {
                    model.car_ModifyOn = DateTime.Parse(ds.Tables[0].Rows[0]["car_ModifyOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["car_ModifyBy"] != null && ds.Tables[0].Rows[0]["car_ModifyBy"].ToString() != "")
                {
                    model.car_ModifyBy =  new Guid(ds.Tables[0].Rows[0]["car_ModifyBy"].ToString());
                }
				if(ds.Tables[0].Rows[0]["car_Ismoren"]!=null && ds.Tables[0].Rows[0]["car_Ismoren"].ToString()!="")
				{
                    model.car_Ismoren = bool.Parse(ds.Tables[0].Rows[0]["car_Ismoren"].ToString());
				}
				if(ds.Tables[0].Rows[0]["car_StatusCode"]!=null && ds.Tables[0].Rows[0]["car_StatusCode"].ToString()!="")
				{
					model.car_StatusCode=int.Parse(ds.Tables[0].Rows[0]["car_StatusCode"].ToString());
				}
				if(ds.Tables[0].Rows[0]["car_IsDel"]!=null && ds.Tables[0].Rows[0]["car_IsDel"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["car_IsDel"].ToString()=="1")||(ds.Tables[0].Rows[0]["car_IsDel"].ToString().ToLower()=="true"))
					{
						model.car_IsDel=true;
					}
					else
					{
						model.car_IsDel=false;
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
            strSql.Append("select car_ID,ct_ID,st_ID,car_measurementUnits,car_shouCount,car_shouCarriage,car_xuCount,car_xuCarriage,car_area,car_CreateOn,car_CreateBy,car_ModifyOn,car_ModifyBy,car_Ismoren,car_StatusCode,car_IsDel ");
			strSql.Append(" FROM CarriageBase ");
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
            strSql.Append(" car_ID,ct_ID,st_ID,car_measurementUnits,car_shouCount,car_shouCarriage,car_xuCount,car_xuCarriage,car_area,car_CreateOn,car_CreateBy,car_ModifyOn,car_ModifyBy,car_Ismoren,car_StatusCode,car_IsDel ");
			strSql.Append(" FROM CarriageBase ");
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
			strSql.Append("select count(1) FROM CarriageBase ");
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
				strSql.Append("order by T.car_ID desc");
			}
			strSql.Append(")AS Row, T.*  from CarriageBase T ");
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
			parameters[0].Value = "CarriageBase";
			parameters[1].Value = "car_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method


        /// <summary>
        /// 获得数据列表(通过ctid)
        /// </summary>
        public DataSet GetModelListByid(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select c.car_ID,c.ct_ID,c.st_ID,c.car_measurementUnits,c.car_shouCount,c.car_shouCarriage,c.car_xuCount,c.car_xuCarriage,c.car_area,c.car_Ismoren,c.car_StatusCode,c.car_IsDel,c.car_CreateOn,c.car_CreateBy,c.car_ModifyOn,c.car_ModifyBy,ct.ct_Name ");
            strSql.Append(" from CarriageBase c,CarriageTempleteBase ct where c.ct_ID = ct.ct_ID  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
	}
}

