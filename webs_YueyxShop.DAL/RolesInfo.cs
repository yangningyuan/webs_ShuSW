/**  版本信息模板在安装目录下，可自行修改。
* RolesInfo.cs
*
* 功 能： N/A
* 类 名： RolesInfo
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
namespace webs_YueyxShop.DAL
{
    /// <summary>
    /// 数据访问类:RolesInfo
    /// </summary>
    public partial class RolesInfo : IRolesInfo
    {
        public RolesInfo()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid r_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RolesInfo");
            strSql.Append(" where r_ID=@r_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = r_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(webs_YueyxShop.Model.RolesInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RolesInfo(");
            strSql.Append("r_ID,r_MingCh,r_MiaoS,r_PaiX,r_CreatedOn,r_CreatedBy,r_StateCode,r_DeleteStateCode)");
            strSql.Append(" values (");
            strSql.Append("@r_ID,@r_MingCh,@r_MiaoS,@r_PaiX,@r_CreatedOn,@r_CreatedBy,@r_StateCode,@r_DeleteStateCode)");
            SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@r_MingCh", SqlDbType.NVarChar,20),
					new SqlParameter("@r_MiaoS", SqlDbType.NVarChar,200),
					new SqlParameter("@r_PaiX", SqlDbType.Int,4),
					new SqlParameter("@r_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@r_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@r_StateCode", SqlDbType.Int,4),
					new SqlParameter("@r_DeleteStateCode", SqlDbType.Int,4)};
            parameters[0].Value = model.r_ID;
            parameters[1].Value = model.r_MingCh;
            parameters[2].Value = model.r_MiaoS;
            parameters[3].Value = model.r_PaiX;
            parameters[4].Value = model.r_CreatedOn;
            parameters[5].Value = model.r_CreatedBy;
            parameters[6].Value = model.r_StateCode;
            parameters[7].Value = model.r_DeleteStateCode;

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
        public bool Update(webs_YueyxShop.Model.RolesInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RolesInfo set ");
            strSql.Append("r_MingCh=@r_MingCh,");
            strSql.Append("r_MiaoS=@r_MiaoS,");
            strSql.Append("r_PaiX=@r_PaiX,");
            strSql.Append("r_CreatedOn=@r_CreatedOn,");
            strSql.Append("r_CreatedBy=@r_CreatedBy,");
            strSql.Append("r_StateCode=@r_StateCode,");
            strSql.Append("r_DeleteStateCode=@r_DeleteStateCode");
            strSql.Append(" where r_ID=@r_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@r_MingCh", SqlDbType.NVarChar,20),
					new SqlParameter("@r_MiaoS", SqlDbType.NVarChar,200),
					new SqlParameter("@r_PaiX", SqlDbType.Int,4),
					new SqlParameter("@r_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@r_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@r_StateCode", SqlDbType.Int,4),
					new SqlParameter("@r_DeleteStateCode", SqlDbType.Int,4),
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.r_MingCh;
            parameters[1].Value = model.r_MiaoS;
            parameters[2].Value = model.r_PaiX;
            parameters[3].Value = model.r_CreatedOn;
            parameters[4].Value = model.r_CreatedBy;
            parameters[5].Value = model.r_StateCode;
            parameters[6].Value = model.r_DeleteStateCode;
            parameters[7].Value = model.r_ID;

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
        public bool Delete(Guid r_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RolesInfo set r_DeleteStateCode=1 ");
            strSql.Append(" where r_ID=@r_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16)};
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
            strSql.Append("delete from RolesInfo ");
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
        public webs_YueyxShop.Model.RolesInfo GetModel(Guid r_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 r_ID,r_MingCh,r_MiaoS,r_PaiX,r_CreatedOn,r_CreatedBy,r_StateCode,r_DeleteStateCode from RolesInfo ");
            strSql.Append(" where r_ID=@r_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = r_ID;

            webs_YueyxShop.Model.RolesInfo model = new webs_YueyxShop.Model.RolesInfo();
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
        public webs_YueyxShop.Model.RolesInfo DataRowToModel(DataRow row)
        {
            webs_YueyxShop.Model.RolesInfo model = new webs_YueyxShop.Model.RolesInfo();
            if (row != null)
            {
                if (row["r_ID"] != null && row["r_ID"].ToString() != "")
                {
                    model.r_ID = new Guid(row["r_ID"].ToString());
                }
                if (row["r_MingCh"] != null)
                {
                    model.r_MingCh = row["r_MingCh"].ToString();
                }
                if (row["r_MiaoS"] != null)
                {
                    model.r_MiaoS = row["r_MiaoS"].ToString();
                }
                if (row["r_PaiX"] != null && row["r_PaiX"].ToString() != "")
                {
                    model.r_PaiX = int.Parse(row["r_PaiX"].ToString());
                }
                if (row["r_CreatedOn"] != null && row["r_CreatedOn"].ToString() != "")
                {
                    model.r_CreatedOn = DateTime.Parse(row["r_CreatedOn"].ToString());
                }
                if (row["r_CreatedBy"] != null && row["r_CreatedBy"].ToString() != "")
                {
                    model.r_CreatedBy = new Guid(row["r_CreatedBy"].ToString());
                }
                if (row["r_StateCode"] != null && row["r_StateCode"].ToString() != "")
                {
                    model.r_StateCode = int.Parse(row["r_StateCode"].ToString());
                }
                if (row["r_DeleteStateCode"] != null && row["r_DeleteStateCode"].ToString() != "")
                {
                    model.r_DeleteStateCode = int.Parse(row["r_DeleteStateCode"].ToString());
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
            strSql.Append("select r_ID,r_MingCh,r_MiaoS,r_PaiX,r_CreatedOn,r_CreatedBy,r_StateCode,r_DeleteStateCode ");
            strSql.Append(" FROM RolesInfo ");
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
            strSql.Append(" r_ID,r_MingCh,r_MiaoS,r_PaiX,r_CreatedOn,r_CreatedBy,r_StateCode,r_DeleteStateCode ");
            strSql.Append(" FROM RolesInfo ");
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
            strSql.Append("select count(1) FROM RolesInfo ");
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
            strSql.Append(")AS Row, T.*  from RolesInfo T ");
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
            parameters[0].Value = "RolesInfo";
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
        /// <summary>
        /// 更改状态
        /// </summary>
        /// <param name="r_StateCode">要修改成的状态</param>
        public bool UpdateState(int r_StateCode, Guid r_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update RolesInfo set r_StateCode={0} ", r_StateCode);
            strSql.Append(" where r_ID=@r_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.UniqueIdentifier,16)};
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
        /// 判断是否存在同名
        /// </summary>
        public bool IsExists(string r_MingCh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from RolesInfo");
            strSql.AppendFormat(" where r_MingCh='{0}' and r_DeleteStateCode=0 ", r_MingCh);

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            bool result = false;
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }
        #endregion  ExtensionMethod
    }
}

