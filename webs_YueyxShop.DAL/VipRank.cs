using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using webs_YueyxShop.IDAL;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DBUtility;
namespace webs_YueyxShop.DAL
{
    /// <summary>
    /// 数据访问类:VipRank
    /// </summary>
    public partial class VipRank : IVipRank
    {
        public VipRank()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int r_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from VipRank");
            strSql.Append(" where r_ID=@r_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = r_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.VipRank model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into VipRank(");
            strSql.Append("r_Name,r_ZheK,r_Score,r_Status,r_Rank,r_UpperScore)");
            strSql.Append(" values (");
            strSql.Append("@r_Name,@r_ZheK,@r_Score,@r_Status,@r_Rank,@r_UpperScore)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@r_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@r_ZheK", SqlDbType.Decimal,9),
					new SqlParameter("@r_Score", SqlDbType.Int,4),
					new SqlParameter("@r_Status", SqlDbType.Int,4),
                    new SqlParameter("@r_Rank", SqlDbType.Int,4),
                    new SqlParameter("@r_UpperScore", SqlDbType.Int,4)};
            parameters[0].Value = model.r_Name;
            parameters[1].Value = model.r_ZheK;
            parameters[2].Value = model.r_Score;
            parameters[3].Value = model.r_Status;
            parameters[4].Value = model.r_Rank;
            parameters[5].Value = model.r_UpperScore;
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
        public bool Update(Model.VipRank model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update VipRank set ");
            strSql.Append("r_Name=@r_Name,");
            strSql.Append("r_ZheK=@r_ZheK,");
            strSql.Append("r_Score=@r_Score,");
            strSql.Append("r_Status=@r_Status,");
            strSql.Append("r_Rank=@r_Rank,");
            strSql.Append("r_UpperScore=@r_UpperScore");
            strSql.Append(" where r_ID=@r_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@r_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@r_ZheK", SqlDbType.Decimal,9),
					new SqlParameter("@r_Score", SqlDbType.Int,4),
					new SqlParameter("@r_Status", SqlDbType.Int,4),
                    new SqlParameter("@r_Rank",SqlDbType.Int,4),
                    new SqlParameter("@r_UpperScore",SqlDbType.Int,4),
					new SqlParameter("@r_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.r_Name;
            parameters[1].Value = model.r_ZheK;
            parameters[2].Value = model.r_Score;
            parameters[3].Value = model.r_Status;
            parameters[4].Value = model.r_Rank;
            parameters[5].Value = model.r_UpperScore;
            parameters[6].Value = model.r_ID;

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
        public bool Delete(int r_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from VipRank ");
            strSql.Append(" where r_ID=@r_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = r_ID;

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
        public bool DeleteList(string r_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from VipRank ");
            strSql.Append(" where r_ID in (" + r_IDlist + ")  ");
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
        public Model.VipRank GetModel(int r_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 r_ID,r_Name,r_ZheK,r_Score,r_Status,r_Rank,r_UpperScore from VipRank ");
            strSql.Append(" where r_ID=@r_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = r_ID;

            Model.VipRank model = new Model.VipRank();
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
        public Model.VipRank DataRowToModel(DataRow row)
        {
            Model.VipRank model = new Model.VipRank();
            if (row != null)
            {
                if (row["r_ID"] != null && row["r_ID"].ToString() != "")
                {
                    model.r_ID = int.Parse(row["r_ID"].ToString());
                }
                if (row["r_Name"] != null)
                {
                    model.r_Name = row["r_Name"].ToString();
                }
                if (row["r_ZheK"] != null && row["r_ZheK"].ToString() != "")
                {
                    model.r_ZheK = decimal.Parse(row["r_ZheK"].ToString());
                }
                if (row["r_Score"] != null && row["r_Score"].ToString() != "")
                {
                    model.r_Score = int.Parse(row["r_Score"].ToString());
                }
                if (row["r_Status"] != null && row["r_Status"].ToString() != "")
                {
                    model.r_Status = int.Parse(row["r_Status"].ToString());
                }
                if (row["r_Rank"] != null && row["r_Rank"].ToString() != "")
                {
                    model.r_Rank = int.Parse(row["r_Rank"].ToString());
                }
                if (row["r_UpperScore"] != null && row["r_UpperScore"].ToString() != "")
                {
                    model.r_UpperScore = int.Parse(row["r_UpperScore"].ToString());
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
            strSql.Append("select r_ID,r_Name,r_ZheK,r_Score,r_Status,r_Rank,r_UpperScore ");
            strSql.Append(" FROM VipRank ");
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
            strSql.Append(" r_ID,r_Name,r_ZheK,r_Score,r_Status,r_Rank,r_UpperScore ");
            strSql.Append(" FROM VipRank ");
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
            strSql.Append("select count(1) FROM VipRank ");
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
                strSql.Append("order by T.r_ID desc");
            }
            strSql.Append(")AS Row, T.*  from VipRank T ");
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
            parameters[0].Value = "VipRank";
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

        #endregion  ExtensionMethod
    }
}
