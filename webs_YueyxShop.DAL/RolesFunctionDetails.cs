/**  版本信息模板在安装目录下，可自行修改。
* RolesFunctionDetails.cs
*
* 功 能： N/A
* 类 名： RolesFunctionDetails
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/28 14:36:06   N/A    初版
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
    /// 数据访问类:RolesFunctionDetails
    /// </summary>
    public partial class RolesFunctionDetails : IRolesFunctionDetails
    {
        public RolesFunctionDetails()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid r_ID, Guid f_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RolesFunctionDetails");
            strSql.Append(" where r_ID=@r_ID and f_ID=@f_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@f_ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = r_ID;
            parameters[1].Value = f_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(webs_YueyxShop.Model.RolesFunctionDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RolesFunctionDetails(");
            strSql.Append("r_ID,f_ID)");
            strSql.Append(" values (");
            strSql.Append("@r_ID,@f_ID)");
            SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@f_ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.r_ID;
            parameters[1].Value = model.f_ID;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(webs_YueyxShop.Model.RolesFunctionDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RolesFunctionDetails set ");
            strSql.Append("r_ID=@r_ID,");
            strSql.Append("f_ID=@f_ID");
            strSql.Append(" where r_ID=@r_ID and f_ID=@f_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@f_ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.r_ID;
            parameters[1].Value = model.f_ID;

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
        public bool Delete(Guid r_ID, Guid f_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RolesFunctionDetails ");
            strSql.Append(" where r_ID=@r_ID and f_ID=@f_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@f_ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = r_ID;
            parameters[1].Value = f_ID;

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
        /// 得到一个对象实体
        /// </summary>
        public webs_YueyxShop.Model.RolesFunctionDetails GetModel(Guid r_ID, Guid f_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 r_ID,f_ID from RolesFunctionDetails ");
            strSql.Append(" where r_ID=@r_ID and f_ID=@f_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@f_ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = r_ID;
            parameters[1].Value = f_ID;

            webs_YueyxShop.Model.RolesFunctionDetails model = new webs_YueyxShop.Model.RolesFunctionDetails();
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
        public webs_YueyxShop.Model.RolesFunctionDetails DataRowToModel(DataRow row)
        {
            webs_YueyxShop.Model.RolesFunctionDetails model = new webs_YueyxShop.Model.RolesFunctionDetails();
            if (row != null)
            {
                if (row["r_ID"] != null && row["r_ID"].ToString() != "")
                {
                    model.r_ID = new Guid(row["r_ID"].ToString());
                }
                if (row["f_ID"] != null && row["f_ID"].ToString() != "")
                {
                    model.f_ID = new Guid(row["f_ID"].ToString());
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
            strSql.Append("select r_ID,f_ID ");
            strSql.Append(" FROM RolesFunctionDetails ");
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
            strSql.Append(" r_ID,f_ID ");
            strSql.Append(" FROM RolesFunctionDetails ");
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
            strSql.Append("select count(1) FROM RolesFunctionDetails ");
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
                strSql.Append("order by T.f_ID desc");
            }
            strSql.Append(")AS Row, T.*  from RolesFunctionDetails T ");
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
            parameters[0].Value = "RolesFunctionDetails";
            parameters[1].Value = "f_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(string r_ID, string f_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RolesFunctionDetails(");
            strSql.Append("r_ID,f_ID)");
            strSql.Append(" values (");
            strSql.Append("@r_ID,@f_ID)");
            SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@f_ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = new Guid(r_ID);
            parameters[1].Value = new Guid(f_ID);

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
        /// 删除对应子集
        /// </summary>
        /// <param name="r_ID"></param>
        /// <param name="f_ID">父级功能</param>
        public bool DelAll(string r_ID, string f_ID)
        {
            string sqlDel = "delete from  RolesFunctionDetails where r_ID='" + r_ID + "' and f_ID in(select f_ID from FunctionBase where f_ParentId='" + f_ID + "' and f_DeleteStateCode=0 )";
            int rows = DbHelperSQL.ExecuteSql(sqlDel);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  ExtensionMethod
    }
}

