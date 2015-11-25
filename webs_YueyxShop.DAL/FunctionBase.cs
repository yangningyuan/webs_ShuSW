/**  版本信息模板在安装目录下，可自行修改。
* FunctionBase.cs
*
* 功 能： N/A
* 类 名： FunctionBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/28 14:36:02   N/A    初版
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
    /// 数据访问类:FunctionBase
    /// </summary>
    public partial class FunctionBase : IFunctionBase
    {
        public FunctionBase()
        {
        }

        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid f_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from FunctionBase");
            strSql.Append(" where f_ID=@f_ID ");
            SqlParameter[] parameters =
                {
                    new SqlParameter("@f_ID", SqlDbType.UniqueIdentifier, 16)
                };
            parameters[0].Value = f_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(webs_YueyxShop.Model.FunctionBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FunctionBase(");
            strSql.Append(
                "f_ID,f_BianM,f_MingCh,f_CengJ,f_ParentId,f_MiaoSh,f_ZhuJM,f_PaiX,f_CreatedOn,f_CreatedBy,f_StatusCode,f_DeleteStateCode)");
            strSql.Append(" values (");
            strSql.Append(
                "@f_ID,@f_BianM,@f_MingCh,@f_CengJ,@f_ParentId,@f_MiaoSh,@f_ZhuJM,@f_PaiX,@f_CreatedOn,@f_CreatedBy,@f_StatusCode,@f_DeleteStateCode)");
            SqlParameter[] parameters =
                {
                    new SqlParameter("@f_ID", SqlDbType.UniqueIdentifier, 16),
                    new SqlParameter("@f_BianM", SqlDbType.VarChar, 30),
                    new SqlParameter("@f_MingCh", SqlDbType.NVarChar, 20),
                    new SqlParameter("@f_CengJ", SqlDbType.Int, 4),
                    new SqlParameter("@f_ParentId", SqlDbType.UniqueIdentifier, 16),
                    new SqlParameter("@f_MiaoSh", SqlDbType.NVarChar, 200),
                    new SqlParameter("@f_ZhuJM", SqlDbType.VarChar, 30),
                    new SqlParameter("@f_PaiX", SqlDbType.Int, 4),
                    new SqlParameter("@f_CreatedOn", SqlDbType.DateTime),
                    new SqlParameter("@f_CreatedBy", SqlDbType.UniqueIdentifier, 16),
                    new SqlParameter("@f_StatusCode", SqlDbType.Int, 4),
                    new SqlParameter("@f_DeleteStateCode", SqlDbType.Int, 4)
                };
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.f_BianM;
            parameters[2].Value = model.f_MingCh;
            parameters[3].Value = model.f_CengJ;
            parameters[4].Value = model.f_ParentId; // Guid.NewGuid();
            parameters[5].Value = model.f_MiaoSh;
            parameters[6].Value = model.f_ZhuJM;
            parameters[7].Value = model.f_PaiX;
            parameters[8].Value = model.f_CreatedOn;
            parameters[9].Value = model.f_CreatedBy; // Guid.NewGuid();
            parameters[10].Value = model.f_StatusCode;
            parameters[11].Value = model.f_DeleteStateCode;

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
        public bool Update(webs_YueyxShop.Model.FunctionBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FunctionBase set ");
            strSql.Append("f_BianM=@f_BianM,");
            strSql.Append("f_MingCh=@f_MingCh,");
            strSql.Append("f_CengJ=@f_CengJ,");
            strSql.Append("f_ParentId=@f_ParentId,");
            strSql.Append("f_MiaoSh=@f_MiaoSh,");
            strSql.Append("f_ZhuJM=@f_ZhuJM,");
            strSql.Append("f_PaiX=@f_PaiX,");
            strSql.Append("f_CreatedOn=@f_CreatedOn,");
            strSql.Append("f_CreatedBy=@f_CreatedBy,");
            strSql.Append("f_StatusCode=@f_StatusCode,");
            strSql.Append("f_DeleteStateCode=@f_DeleteStateCode");
            strSql.Append(" where f_ID=@f_ID ");
            SqlParameter[] parameters =
                {
                    new SqlParameter("@f_BianM", SqlDbType.VarChar, 30),
                    new SqlParameter("@f_MingCh", SqlDbType.NVarChar, 20),
                    new SqlParameter("@f_CengJ", SqlDbType.Int, 4),
                    new SqlParameter("@f_ParentId", SqlDbType.UniqueIdentifier, 16),
                    new SqlParameter("@f_MiaoSh", SqlDbType.NVarChar, 200),
                    new SqlParameter("@f_ZhuJM", SqlDbType.VarChar, 30),
                    new SqlParameter("@f_PaiX", SqlDbType.Int, 4),
                    new SqlParameter("@f_CreatedOn", SqlDbType.DateTime),
                    new SqlParameter("@f_CreatedBy", SqlDbType.UniqueIdentifier, 16),
                    new SqlParameter("@f_StatusCode", SqlDbType.Int, 4),
                    new SqlParameter("@f_DeleteStateCode", SqlDbType.Int, 4),
                    new SqlParameter("@f_ID", SqlDbType.UniqueIdentifier, 16)
                };
            parameters[0].Value = model.f_BianM;
            parameters[1].Value = model.f_MingCh;
            parameters[2].Value = model.f_CengJ;
            parameters[3].Value = model.f_ParentId;
            parameters[4].Value = model.f_MiaoSh;
            parameters[5].Value = model.f_ZhuJM;
            parameters[6].Value = model.f_PaiX;
            parameters[7].Value = model.f_CreatedOn;
            parameters[8].Value = model.f_CreatedBy;
            parameters[9].Value = model.f_StatusCode;
            parameters[10].Value = model.f_DeleteStateCode;
            parameters[11].Value = model.f_ID;

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
        public bool Delete(Guid f_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FunctionBase ");
            strSql.Append(" where f_ID=@f_ID ");
            SqlParameter[] parameters =
                {
                    new SqlParameter("@f_ID", SqlDbType.UniqueIdentifier, 16)
                };
            parameters[0].Value = f_ID;

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
        public bool DeleteList(string f_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FunctionBase ");
            strSql.Append(" where f_ID in (" + f_IDlist + ")  ");
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
        public webs_YueyxShop.Model.FunctionBase GetModel(Guid f_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(
                "select  top 1 f_ID,f_BianM,f_MingCh,f_CengJ,f_ParentId,f_MiaoSh,f_ZhuJM,f_PaiX,f_CreatedOn,f_CreatedBy,f_StatusCode,f_DeleteStateCode from FunctionBase ");
            strSql.Append(" where f_ID=@f_ID ");
            SqlParameter[] parameters =
                {
                    new SqlParameter("@f_ID", SqlDbType.UniqueIdentifier, 16)
                };
            parameters[0].Value = f_ID;

            webs_YueyxShop.Model.FunctionBase model = new webs_YueyxShop.Model.FunctionBase();
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
        public webs_YueyxShop.Model.FunctionBase DataRowToModel(DataRow row)
        {
            webs_YueyxShop.Model.FunctionBase model = new webs_YueyxShop.Model.FunctionBase();
            if (row != null)
            {
                if (row["f_ID"] != null && row["f_ID"].ToString() != "")
                {
                    model.f_ID = new Guid(row["f_ID"].ToString());
                }
                if (row["f_BianM"] != null)
                {
                    model.f_BianM = row["f_BianM"].ToString();
                }
                if (row["f_MingCh"] != null)
                {
                    model.f_MingCh = row["f_MingCh"].ToString();
                }
                if (row["f_CengJ"] != null && row["f_CengJ"].ToString() != "")
                {
                    model.f_CengJ = int.Parse(row["f_CengJ"].ToString());
                }
                if (row["f_ParentId"] != null && row["f_ParentId"].ToString() != "")
                {
                    model.f_ParentId = new Guid(row["f_ParentId"].ToString());
                }
                if (row["f_MiaoSh"] != null)
                {
                    model.f_MiaoSh = row["f_MiaoSh"].ToString();
                }
                if (row["f_ZhuJM"] != null)
                {
                    model.f_ZhuJM = row["f_ZhuJM"].ToString();
                }
                if (row["f_PaiX"] != null && row["f_PaiX"].ToString() != "")
                {
                    model.f_PaiX = int.Parse(row["f_PaiX"].ToString());
                }
                if (row["f_CreatedOn"] != null && row["f_CreatedOn"].ToString() != "")
                {
                    model.f_CreatedOn = DateTime.Parse(row["f_CreatedOn"].ToString());
                }
                if (row["f_CreatedBy"] != null && row["f_CreatedBy"].ToString() != "")
                {
                    model.f_CreatedBy = new Guid(row["f_CreatedBy"].ToString());
                }
                if (row["f_StatusCode"] != null && row["f_StatusCode"].ToString() != "")
                {
                    model.f_StatusCode = int.Parse(row["f_StatusCode"].ToString());
                }
                if (row["f_DeleteStateCode"] != null && row["f_DeleteStateCode"].ToString() != "")
                {
                    model.f_DeleteStateCode = int.Parse(row["f_DeleteStateCode"].ToString());
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
                "select f_ID,f_BianM,f_MingCh,f_CengJ,f_ParentId,f_MiaoSh,f_ZhuJM,f_PaiX,f_CreatedOn,f_CreatedBy,f_StatusCode,f_DeleteStateCode ");
            strSql.Append(" FROM FunctionBase ");
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
                " f_ID,f_BianM,f_MingCh,f_CengJ,f_ParentId,f_MiaoSh,f_ZhuJM,f_PaiX,f_CreatedOn,f_CreatedBy,f_StatusCode,f_DeleteStateCode ");
            strSql.Append(" FROM FunctionBase ");
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
            strSql.Append("select count(1) FROM FunctionBase ");
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
            strSql.Append(")AS Row, T.*  from FunctionBase T ");
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
            parameters[0].Value = "FunctionBase";
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

        #endregion  ExtensionMethod
    }
}

