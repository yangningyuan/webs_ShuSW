using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using webs_YueyxShop.IDAL;
using System.Data;
using System.Data.SqlClient;
namespace webs_YueyxShop.DAL
{
    /// <summary>
    /// 数据访问类:Adert
    /// </summary>
    public partial class Adert : IAdert
    {
        public Adert()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int a_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Adert");
            strSql.Append(" where a_ID=@a_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@a_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = a_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Adert model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Adert(");
            strSql.Append("a_PID,a_Title,a_Link,a_Image,a_Sorting,a_IsTop,a_CreateDate,a_CreateUser,a_Status,a_Delete,a_spare1,a_spare2)");
            strSql.Append(" values (");
            strSql.Append("@a_PID,@a_Title,@a_Link,@a_Image,@a_Sorting,@a_IsTop,@a_CreateDate,@a_CreateUser,@a_Status,@a_Delete,@a_spare1,@a_spare2)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@a_PID", SqlDbType.Int,4),
					new SqlParameter("@a_Title", SqlDbType.NVarChar,100),
					new SqlParameter("@a_Link", SqlDbType.NVarChar,200),
					new SqlParameter("@a_Image", SqlDbType.NVarChar,200),
					new SqlParameter("@a_Sorting", SqlDbType.Int,4),
					new SqlParameter("@a_IsTop", SqlDbType.Int,4),
					new SqlParameter("@a_CreateDate", SqlDbType.DateTime),
					new SqlParameter("@a_CreateUser", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@a_Status", SqlDbType.Int,4),
					new SqlParameter("@a_Delete", SqlDbType.Int,4),
					new SqlParameter("@a_spare1", SqlDbType.NVarChar,50),
					new SqlParameter("@a_spare2", SqlDbType.Int,4)};
            parameters[0].Value = model.a_PID;
            parameters[1].Value = model.a_Title;
            parameters[2].Value = model.a_Link;
            parameters[3].Value = model.a_Image;
            parameters[4].Value = model.a_Sorting;
            parameters[5].Value = model.a_IsTop;
            parameters[6].Value = model.a_CreateDate;
            parameters[7].Value = Guid.NewGuid();
            parameters[8].Value = model.a_Status;
            parameters[9].Value = model.a_Delete;
            parameters[10].Value = model.a_spare1;
            parameters[11].Value = model.a_spare2;

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
        public bool Update(Model.Adert model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Adert set ");
            strSql.Append("a_PID=@a_PID,");
            strSql.Append("a_Title=@a_Title,");
            strSql.Append("a_Link=@a_Link,");
            strSql.Append("a_Image=@a_Image,");
            strSql.Append("a_Sorting=@a_Sorting,");
            strSql.Append("a_IsTop=@a_IsTop,");
            strSql.Append("a_CreateDate=@a_CreateDate,");
            strSql.Append("a_CreateUser=@a_CreateUser,");
            strSql.Append("a_Status=@a_Status,");
            strSql.Append("a_Delete=@a_Delete,");
            strSql.Append("a_spare1=@a_spare1,");
            strSql.Append("a_spare2=@a_spare2");
            strSql.Append(" where a_ID=@a_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@a_PID", SqlDbType.Int,4),
					new SqlParameter("@a_Title", SqlDbType.NVarChar,100),
					new SqlParameter("@a_Link", SqlDbType.NVarChar,200),
					new SqlParameter("@a_Image", SqlDbType.NVarChar,200),
					new SqlParameter("@a_Sorting", SqlDbType.Int,4),
					new SqlParameter("@a_IsTop", SqlDbType.Int,4),
					new SqlParameter("@a_CreateDate", SqlDbType.DateTime),
					new SqlParameter("@a_CreateUser", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@a_Status", SqlDbType.Int,4),
					new SqlParameter("@a_Delete", SqlDbType.Int,4),
					new SqlParameter("@a_spare1", SqlDbType.NVarChar,50),
					new SqlParameter("@a_spare2", SqlDbType.Int,4),
					new SqlParameter("@a_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.a_PID;
            parameters[1].Value = model.a_Title;
            parameters[2].Value = model.a_Link;
            parameters[3].Value = model.a_Image;
            parameters[4].Value = model.a_Sorting;
            parameters[5].Value = model.a_IsTop;
            parameters[6].Value = model.a_CreateDate;
            parameters[7].Value = model.a_CreateUser;
            parameters[8].Value = model.a_Status;
            parameters[9].Value = model.a_Delete;
            parameters[10].Value = model.a_spare1;
            parameters[11].Value = model.a_spare2;
            parameters[12].Value = model.a_ID;

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
        public bool Delete(int a_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Adert ");
            strSql.Append(" where a_ID=@a_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@a_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = a_ID;

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
        public bool DeleteList(string a_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Adert ");
            strSql.Append(" where a_ID in (" + a_IDlist + ")  ");
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
        public Model.Adert GetModel(int a_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 a_ID,a_PID,a_Title,a_Link,a_Image,a_Sorting,a_IsTop,a_CreateDate,a_CreateUser,a_Status,a_Delete,a_spare1,a_spare2 from Adert ");
            strSql.Append(" where a_ID=@a_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@a_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = a_ID;

            Model.Adert model = new Model.Adert();
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
        public Model.Adert DataRowToModel(DataRow row)
        {
            Model.Adert model = new Model.Adert();
            if (row != null)
            {
                if (row["a_ID"] != null && row["a_ID"].ToString() != "")
                {
                    model.a_ID = int.Parse(row["a_ID"].ToString());
                }
                if (row["a_PID"] != null && row["a_PID"].ToString() != "")
                {
                    model.a_PID = int.Parse(row["a_PID"].ToString());
                }
                if (row["a_Title"] != null)
                {
                    model.a_Title = row["a_Title"].ToString();
                }
                if (row["a_Link"] != null)
                {
                    model.a_Link = row["a_Link"].ToString();
                }
                if (row["a_Image"] != null)
                {
                    model.a_Image = row["a_Image"].ToString();
                }
                if (row["a_Sorting"] != null && row["a_Sorting"].ToString() != "")
                {
                    model.a_Sorting = int.Parse(row["a_Sorting"].ToString());
                }
                if (row["a_IsTop"] != null && row["a_IsTop"].ToString() != "")
                {
                    model.a_IsTop = int.Parse(row["a_IsTop"].ToString());
                }
                if (row["a_CreateDate"] != null && row["a_CreateDate"].ToString() != "")
                {
                    model.a_CreateDate = DateTime.Parse(row["a_CreateDate"].ToString());
                }
                if (row["a_CreateUser"] != null && row["a_CreateUser"].ToString() != "")
                {
                    model.a_CreateUser = new Guid(row["a_CreateUser"].ToString());
                }
                if (row["a_Status"] != null && row["a_Status"].ToString() != "")
                {
                    model.a_Status = int.Parse(row["a_Status"].ToString());
                }
                if (row["a_Delete"] != null && row["a_Delete"].ToString() != "")
                {
                    model.a_Delete = int.Parse(row["a_Delete"].ToString());
                }
                if (row["a_spare1"] != null)
                {
                    model.a_spare1 = row["a_spare1"].ToString();
                }
                if (row["a_spare2"] != null && row["a_spare2"].ToString() != "")
                {
                    model.a_spare2 = int.Parse(row["a_spare2"].ToString());
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
            strSql.Append("select a_ID,a_PID,a_Title,a_Link,a_Image,a_Sorting,a_IsTop,a_CreateDate,a_CreateUser,a_Status,a_Delete,a_spare1,a_spare2 ");
            strSql.Append(" FROM Adert ");
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
            strSql.Append(" a_ID,a_PID,a_Title,a_Link,a_Image,a_Sorting,a_IsTop,a_CreateDate,a_CreateUser,a_Status,a_Delete,a_spare1,a_spare2 ");
            strSql.Append(" FROM Adert ");
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
            strSql.Append("select count(1) FROM Adert ");
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
                strSql.Append("order by T.a_ID desc");
            }
            strSql.Append(")AS Row, T.*  from Adert T ");
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
            parameters[0].Value = "Adert";
            parameters[1].Value = "a_ID";
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
