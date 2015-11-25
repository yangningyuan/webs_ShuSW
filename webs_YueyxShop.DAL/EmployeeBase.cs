/**  版本信息模板在安装目录下，可自行修改。
* EmployeeBase.cs
*
* 功 能： N/A
* 类 名： EmployeeBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/28 14:36:01   N/A    初版
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
    /// 数据访问类:EmployeeBase
    /// </summary>
    public partial class EmployeeBase : IEmployeeBase
    {
        public EmployeeBase()
        {
        }

        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid e_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from EmployeeBase");
            strSql.Append(" where e_ID=@e_ID ");
            SqlParameter[] parameters =
                {
                    new SqlParameter("@e_ID", SqlDbType.UniqueIdentifier, 16)
                };
            parameters[0].Value = e_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(webs_YueyxShop.Model.EmployeeBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into EmployeeBase(");
            strSql.Append(
                "e_ID,d_ID,e_YongHM,e_MiM,e_MingC,e_GongH,e_XingB,e_ShengR,e_QQ,e_EMail,e_ShouJ,e_CreatedBy,e_CreatedOn,e_StateCode,e_DeleteStateCode,e_LeiB)");
            strSql.Append(" values (");
            strSql.Append(
                "@e_ID,@d_ID,@e_YongHM,@e_MiM,@e_MingC,@e_GongH,@e_XingB,@e_ShengR,@e_QQ,@e_EMail,@e_ShouJ,@e_CreatedBy,@e_CreatedOn,@e_StateCode,@e_DeleteStateCode,@e_LeiB)");
            SqlParameter[] parameters =
                {
                    new SqlParameter("@e_ID", SqlDbType.UniqueIdentifier, 16),
                    new SqlParameter("@d_ID", SqlDbType.UniqueIdentifier, 16),
                    new SqlParameter("@e_YongHM", SqlDbType.VarChar, 50),
                    new SqlParameter("@e_MiM", SqlDbType.VarChar, 200),
                    new SqlParameter("@e_MingC", SqlDbType.NVarChar, 20),
                    new SqlParameter("@e_GongH", SqlDbType.VarChar, 50),
                    new SqlParameter("@e_XingB", SqlDbType.Int, 4),
                    new SqlParameter("@e_ShengR", SqlDbType.DateTime),
                    new SqlParameter("@e_QQ", SqlDbType.VarChar, 30),
                    new SqlParameter("@e_EMail", SqlDbType.VarChar, 200),
                    new SqlParameter("@e_ShouJ", SqlDbType.VarChar, 100),
                    new SqlParameter("@e_CreatedBy", SqlDbType.UniqueIdentifier, 16),
                    new SqlParameter("@e_CreatedOn", SqlDbType.DateTime),
                    new SqlParameter("@e_StateCode", SqlDbType.Int, 4),
                    new SqlParameter("@e_DeleteStateCode", SqlDbType.Int, 4),
                    new SqlParameter("@e_LeiB", SqlDbType.Int, 4)
                };
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.d_ID; //Guid.NewGuid();
            parameters[2].Value = model.e_YongHM;
            parameters[3].Value = model.e_MiM;
            parameters[4].Value = model.e_MingC;
            parameters[5].Value = model.e_GongH;
            parameters[6].Value = model.e_XingB;
            parameters[7].Value = model.e_ShengR;
            parameters[8].Value = model.e_QQ;
            parameters[9].Value = model.e_EMail;
            parameters[10].Value = model.e_ShouJ;
            parameters[11].Value = model.e_CreatedBy;
            parameters[12].Value = model.e_CreatedOn;
            parameters[13].Value = model.e_StateCode;
            parameters[14].Value = model.e_DeleteStateCode;
            parameters[15].Value = model.e_LeiB;

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
        public bool Update(webs_YueyxShop.Model.EmployeeBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update EmployeeBase set ");
            strSql.Append("d_ID=@d_ID,");
            strSql.Append("e_YongHM=@e_YongHM,");
            strSql.Append("e_MiM=@e_MiM,");
            strSql.Append("e_MingC=@e_MingC,");
            strSql.Append("e_GongH=@e_GongH,");
            strSql.Append("e_XingB=@e_XingB,");
            strSql.Append("e_ShengR=@e_ShengR,");
            strSql.Append("e_QQ=@e_QQ,");
            strSql.Append("e_EMail=@e_EMail,");
            strSql.Append("e_ShouJ=@e_ShouJ,");
            strSql.Append("e_CreatedBy=@e_CreatedBy,");
            strSql.Append("e_CreatedOn=@e_CreatedOn,");
            strSql.Append("e_StateCode=@e_StateCode,");
            strSql.Append("e_DeleteStateCode=@e_DeleteStateCode,");
            strSql.Append("e_LeiB=@e_LeiB");
            strSql.Append(" where e_ID=@e_ID ");
            SqlParameter[] parameters =
                {
                    new SqlParameter("@d_ID", SqlDbType.UniqueIdentifier, 16),
                    new SqlParameter("@e_YongHM", SqlDbType.VarChar, 50),
                    new SqlParameter("@e_MiM", SqlDbType.VarChar, 200),
                    new SqlParameter("@e_MingC", SqlDbType.NVarChar, 20),
                    new SqlParameter("@e_GongH", SqlDbType.VarChar, 50),
                    new SqlParameter("@e_XingB", SqlDbType.Int, 4),
                    new SqlParameter("@e_ShengR", SqlDbType.DateTime),
                    new SqlParameter("@e_QQ", SqlDbType.VarChar, 30),
                    new SqlParameter("@e_EMail", SqlDbType.VarChar, 200),
                    new SqlParameter("@e_ShouJ", SqlDbType.VarChar, 100),
                    new SqlParameter("@e_CreatedBy", SqlDbType.UniqueIdentifier, 16),
                    new SqlParameter("@e_CreatedOn", SqlDbType.DateTime),
                    new SqlParameter("@e_StateCode", SqlDbType.Int, 4),
                    new SqlParameter("@e_DeleteStateCode", SqlDbType.Int, 4),
                    new SqlParameter("@e_LeiB", SqlDbType.Int, 4),
                    new SqlParameter("@e_ID", SqlDbType.UniqueIdentifier, 16)
                };
            parameters[0].Value = model.d_ID;
            parameters[1].Value = model.e_YongHM;
            parameters[2].Value = model.e_MiM;
            parameters[3].Value = model.e_MingC;
            parameters[4].Value = model.e_GongH;
            parameters[5].Value = model.e_XingB;
            parameters[6].Value = model.e_ShengR;
            parameters[7].Value = model.e_QQ;
            parameters[8].Value = model.e_EMail;
            parameters[9].Value = model.e_ShouJ;
            parameters[10].Value = model.e_CreatedBy;
            parameters[11].Value = model.e_CreatedOn;
            parameters[12].Value = model.e_StateCode;
            parameters[13].Value = model.e_DeleteStateCode;
            parameters[14].Value = model.e_LeiB;
            parameters[15].Value = model.e_ID;

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
        public bool Delete(Guid e_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from EmployeeBase ");
            strSql.Append(" where e_ID=@e_ID ");
            SqlParameter[] parameters =
                {
                    new SqlParameter("@e_ID", SqlDbType.UniqueIdentifier, 16)
                };
            parameters[0].Value = e_ID;

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
        public bool DeleteList(string e_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from EmployeeBase ");
            strSql.Append(" where e_ID in (" + e_IDlist + ")  ");
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
        public webs_YueyxShop.Model.EmployeeBase GetModel(Guid e_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(
                "select  top 1 e_ID,d_ID,e_YongHM,e_MiM,e_MingC,e_GongH,e_XingB,e_ShengR,e_QQ,e_EMail,e_ShouJ,e_CreatedBy,e_CreatedOn,e_StateCode,e_DeleteStateCode,e_LeiB from EmployeeBase ");
            strSql.Append(" where e_ID=@e_ID ");
            SqlParameter[] parameters =
                {
                    new SqlParameter("@e_ID", SqlDbType.UniqueIdentifier, 16)
                };
            parameters[0].Value = e_ID;

            webs_YueyxShop.Model.EmployeeBase model = new webs_YueyxShop.Model.EmployeeBase();
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
        public webs_YueyxShop.Model.EmployeeBase DataRowToModel(DataRow row)
        {
            webs_YueyxShop.Model.EmployeeBase model = new webs_YueyxShop.Model.EmployeeBase();
            if (row != null)
            {
                if (row["e_ID"] != null && row["e_ID"].ToString() != "")
                {
                    model.e_ID = new Guid(row["e_ID"].ToString());
                }
                if (row["d_ID"] != null && row["d_ID"].ToString() != "")
                {
                    model.d_ID = new Guid(row["d_ID"].ToString());
                }
                if (row["e_YongHM"] != null)
                {
                    model.e_YongHM = row["e_YongHM"].ToString();
                }
                if (row["e_MiM"] != null)
                {
                    model.e_MiM = row["e_MiM"].ToString();
                }
                if (row["e_MingC"] != null)
                {
                    model.e_MingC = row["e_MingC"].ToString();
                }
                if (row["e_GongH"] != null)
                {
                    model.e_GongH = row["e_GongH"].ToString();
                }
                if (row["e_XingB"] != null && row["e_XingB"].ToString() != "")
                {
                    model.e_XingB = int.Parse(row["e_XingB"].ToString());
                }
                if (row["e_ShengR"] != null && row["e_ShengR"].ToString() != "")
                {
                    model.e_ShengR = DateTime.Parse(row["e_ShengR"].ToString());
                }
                if (row["e_QQ"] != null)
                {
                    model.e_QQ = row["e_QQ"].ToString();
                }
                if (row["e_EMail"] != null)
                {
                    model.e_EMail = row["e_EMail"].ToString();
                }
                if (row["e_ShouJ"] != null)
                {
                    model.e_ShouJ = row["e_ShouJ"].ToString();
                }
                if (row["e_CreatedBy"] != null && row["e_CreatedBy"].ToString() != "")
                {
                    model.e_CreatedBy = new Guid(row["e_CreatedBy"].ToString());
                }
                if (row["e_CreatedOn"] != null && row["e_CreatedOn"].ToString() != "")
                {
                    model.e_CreatedOn = DateTime.Parse(row["e_CreatedOn"].ToString());
                }
                if (row["e_StateCode"] != null && row["e_StateCode"].ToString() != "")
                {
                    model.e_StateCode = int.Parse(row["e_StateCode"].ToString());
                }
                if (row["e_DeleteStateCode"] != null && row["e_DeleteStateCode"].ToString() != "")
                {
                    model.e_DeleteStateCode = int.Parse(row["e_DeleteStateCode"].ToString());
                }
                if (row["e_LeiB"] != null && row["e_LeiB"].ToString() != "")
                {
                    model.e_LeiB = int.Parse(row["e_LeiB"].ToString());
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
            strSql.Append(
                "select e_ID,d_ID,e_YongHM,e_MiM,e_MingC,e_GongH,e_XingB,e_ShengR,e_QQ,e_EMail,e_ShouJ,e_CreatedBy,e_CreatedOn,e_StateCode,e_DeleteStateCode,e_LeiB ");
            strSql.Append(" FROM EmployeeBase ");
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
            strSql.Append(
                " e_ID,d_ID,e_YongHM,e_MiM,e_MingC,e_GongH,e_XingB,e_ShengR,e_QQ,e_EMail,e_ShouJ,e_CreatedBy,e_CreatedOn,e_StateCode,e_DeleteStateCode,e_LeiB ");
            strSql.Append(" FROM EmployeeBase ");
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
            strSql.Append("select count(1) FROM EmployeeBase ");
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
                strSql.Append("order by T.e_ID desc");
            }
            strSql.Append(")AS Row, T.*  from EmployeeBase T ");
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
            parameters[0].Value = "EmployeeBase";
            parameters[1].Value = "e_ID";
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

