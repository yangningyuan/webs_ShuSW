using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using webs_YueyxShop.IDAL;
using DBUtility;
namespace webs_YueyxShop.DAL
{
    /// <summary>
    /// 数据访问类:AdertPositionBase
    /// </summary>
    public partial class AdertPositionBase : IAdertPositionBase
    {
        public AdertPositionBase()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int p_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AdertPositionBase");
            strSql.Append(" where p_ID=@p_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@p_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = p_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.AdertPositionBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AdertPositionBase(");
            strSql.Append("p_PositionName,p_PositionExplain,p_CreateDate,p_CreateUser,p_Status,p_Delete,p_showposition,p_producttype)");
            strSql.Append(" values (");
            strSql.Append("@p_PositionName,@p_PositionExplain,@p_CreateDate,@p_CreateUser,@p_Status,@p_Delete,@p_showposition,@p_producttype)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@p_PositionName", SqlDbType.NVarChar,50),
					new SqlParameter("@p_PositionExplain", SqlDbType.NVarChar,220),
					new SqlParameter("@p_CreateDate", SqlDbType.DateTime),
					new SqlParameter("@p_CreateUser", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@p_Status", SqlDbType.Int,4),
					new SqlParameter("@p_Delete", SqlDbType.Int,4),
					new SqlParameter("@p_showposition", SqlDbType.NVarChar,50),
					new SqlParameter("@p_producttype", SqlDbType.Int,4)};
            parameters[0].Value = model.p_PositionName;
            parameters[1].Value = model.p_PositionExplain;
            parameters[2].Value = model.p_CreateDate;
            parameters[3].Value = Guid.NewGuid();
            parameters[4].Value = model.p_Status;
            parameters[5].Value = model.p_Delete;
            parameters[6].Value = model.p_showposition;
            parameters[7].Value = model.p_producttype;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Model.AdertPositionBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdertPositionBase set ");
            strSql.Append("p_PositionName=@p_PositionName,");
            strSql.Append("p_PositionExplain=@p_PositionExplain,");
            strSql.Append("p_CreateDate=@p_CreateDate,");
            strSql.Append("p_CreateUser=@p_CreateUser,");
            strSql.Append("p_Status=@p_Status,");
            strSql.Append("p_Delete=@p_Delete,");
            strSql.Append("p_showposition=@p_showposition,");
            strSql.Append("p_producttype=@p_producttype");
            strSql.Append(" where p_ID=@p_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@p_PositionName", SqlDbType.NVarChar,50),
					new SqlParameter("@p_PositionExplain", SqlDbType.NVarChar,220),
					new SqlParameter("@p_CreateDate", SqlDbType.DateTime),
					new SqlParameter("@p_CreateUser", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@p_Status", SqlDbType.Int,4),
					new SqlParameter("@p_Delete", SqlDbType.Int,4),
					new SqlParameter("@p_showposition", SqlDbType.NVarChar,50),
					new SqlParameter("@p_producttype", SqlDbType.Int,4),
					new SqlParameter("@p_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.p_PositionName;
            parameters[1].Value = model.p_PositionExplain;
            parameters[2].Value = model.p_CreateDate;
            parameters[3].Value = model.p_CreateUser;
            parameters[4].Value = model.p_Status;
            parameters[5].Value = model.p_Delete;
            parameters[6].Value = model.p_showposition;
            parameters[7].Value = model.p_producttype;
            parameters[8].Value = model.p_ID;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int p_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AdertPositionBase ");
            strSql.Append(" where p_ID=@p_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@p_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = p_ID;

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
        public bool DeleteList(string p_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AdertPositionBase ");
            strSql.Append(" where p_ID in (" + p_IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Model.AdertPositionBase GetModel(int p_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 p_ID,p_PositionName,p_PositionExplain,p_CreateDate,p_CreateUser,p_Status,p_Delete,p_showposition,p_producttype from AdertPositionBase ");
            strSql.Append(" where p_ID=@p_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@p_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = p_ID;

            Model.AdertPositionBase model = new Model.AdertPositionBase();
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
        public Model.AdertPositionBase DataRowToModel(DataRow row)
        {
            Model.AdertPositionBase model = new Model.AdertPositionBase();
            if (row != null)
            {
                if (row["p_ID"] != null && row["p_ID"].ToString() != "")
                {
                    model.p_ID = int.Parse(row["p_ID"].ToString());
                }
                if (row["p_PositionName"] != null)
                {
                    model.p_PositionName = row["p_PositionName"].ToString();
                }
                if (row["p_PositionExplain"] != null)
                {
                    model.p_PositionExplain = row["p_PositionExplain"].ToString();
                }
                if (row["p_CreateDate"] != null && row["p_CreateDate"].ToString() != "")
                {
                    model.p_CreateDate = DateTime.Parse(row["p_CreateDate"].ToString());
                }
                if (row["p_CreateUser"] != null && row["p_CreateUser"].ToString() != "")
                {
                    model.p_CreateUser = new Guid(row["p_CreateUser"].ToString());
                }
                if (row["p_Status"] != null && row["p_Status"].ToString() != "")
                {
                    model.p_Status = int.Parse(row["p_Status"].ToString());
                }
                if (row["p_Delete"] != null && row["p_Delete"].ToString() != "")
                {
                    model.p_Delete = int.Parse(row["p_Delete"].ToString());
                }
                if (row["p_showposition"] != null)
                {
                    model.p_showposition = row["p_showposition"].ToString();
                }
                if (row["p_producttype"] != null && row["p_producttype"].ToString() != "")
                {
                    model.p_producttype = int.Parse(row["p_producttype"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select p_ID,p_PositionName,p_PositionExplain,p_CreateDate,p_CreateUser,p_Status,p_Delete,p_showposition,p_producttype ");
            strSql.Append(" FROM AdertPositionBase ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" p_ID,p_PositionName,p_PositionExplain,p_CreateDate,p_CreateUser,p_Status,p_Delete,p_showposition,p_producttype ");
            strSql.Append(" FROM AdertPositionBase ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM AdertPositionBase ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.p_ID desc");
            }
            strSql.Append(")AS Row, T.*  from AdertPositionBase T ");
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
            parameters[0].Value = "AdertPositionBase";
            parameters[1].Value = "p_ID";
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
