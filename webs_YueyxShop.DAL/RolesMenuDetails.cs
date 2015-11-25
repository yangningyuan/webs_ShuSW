/**  版本信息模板在安装目录下，可自行修改。
* RolesMenuDetails.cs
*
* 功 能： N/A
* 类 名： RolesMenuDetails
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/28 14:36:07   N/A    初版
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
using System.Transactions;
namespace webs_YueyxShop.DAL
{
    /// <summary>
    /// 数据访问类:RolesMenuDetails
    /// </summary>
    public partial class RolesMenuDetails : IRolesMenuDetails
    {
        public RolesMenuDetails()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid r_ID, Guid m_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RolesMenuDetails");
            strSql.Append(" where r_ID=@r_ID and m_ID=@m_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@m_ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = r_ID;
            parameters[1].Value = m_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(webs_YueyxShop.Model.RolesMenuDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RolesMenuDetails(");
            strSql.Append("r_ID,m_ID)");
            strSql.Append(" values (");
            strSql.Append("@r_ID,@m_ID)");
            SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@m_ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = Guid.NewGuid();

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
        public bool Update(webs_YueyxShop.Model.RolesMenuDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RolesMenuDetails set ");
            strSql.Append("r_ID=@r_ID,");
            strSql.Append("m_ID=@m_ID");
            strSql.Append(" where r_ID=@r_ID and m_ID=@m_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@m_ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.r_ID;
            parameters[1].Value = model.m_ID;

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
        public bool Delete(Guid r_ID, Guid m_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RolesMenuDetails ");
            strSql.Append(" where r_ID=@r_ID and m_ID=@m_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@m_ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = r_ID;
            parameters[1].Value = m_ID;

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
        public webs_YueyxShop.Model.RolesMenuDetails GetModel(Guid r_ID, Guid m_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 r_ID,m_ID from RolesMenuDetails ");
            strSql.Append(" where r_ID=@r_ID and m_ID=@m_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@m_ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = r_ID;
            parameters[1].Value = m_ID;

            webs_YueyxShop.Model.RolesMenuDetails model = new webs_YueyxShop.Model.RolesMenuDetails();
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
        public webs_YueyxShop.Model.RolesMenuDetails DataRowToModel(DataRow row)
        {
            webs_YueyxShop.Model.RolesMenuDetails model = new webs_YueyxShop.Model.RolesMenuDetails();
            if (row != null)
            {
                if (row["r_ID"] != null && row["r_ID"].ToString() != "")
                {
                    model.r_ID = new Guid(row["r_ID"].ToString());
                }
                if (row["m_ID"] != null && row["m_ID"].ToString() != "")
                {
                    model.m_ID = new Guid(row["m_ID"].ToString());
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
            strSql.Append("select r_ID,m_ID ");
            strSql.Append(" FROM RolesMenuDetails ");
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
            strSql.Append(" r_ID,m_ID ");
            strSql.Append(" FROM RolesMenuDetails ");
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
            strSql.Append("select count(1) FROM RolesMenuDetails ");
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
                strSql.Append("order by T.m_ID desc");
            }
            strSql.Append(")AS Row, T.*  from RolesMenuDetails T ");
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
            parameters[0].Value = "RolesMenuDetails";
            parameters[1].Value = "m_ID";
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
        /// 添加角色菜单权限
        /// </summary>
        /// <param name="mids">选中菜单</param>
        public bool AddRoleMenu(string mids, string rid)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    string sqlDel = "delete from  RolesMenuDetails where r_ID='" + rid + "'";
                    DbHelperSQL.ExecuteSql(sqlDel);
                    int count = 0;
                    string[] MenuIds = mids.Trim(',').Split(',');
                    if (!string.IsNullOrEmpty(mids))
                    {
                        count = MenuIds.Length;
                    }
                    for (int i = 0; i < count; i++)
                    {
                        string sqlInto = "insert into RolesMenuDetails (m_ID,r_ID) values('" + MenuIds[i] + "','" + rid + "')";
                        DbHelperSQL.ExecuteSql(sqlInto);
                    }
                    scope.Complete();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        #endregion  ExtensionMethod
    }
}

