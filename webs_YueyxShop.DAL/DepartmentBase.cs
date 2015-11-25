/**  版本信息模板在安装目录下，可自行修改。
* DepartmentBase.cs
*
* 功 能： N/A
* 类 名： DepartmentBase
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
    /// 数据访问类:DepartmentBase
    /// </summary>
    public partial class DepartmentBase : IDepartmentBase
    {
        public DepartmentBase()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid d_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DepartmentBase");
            strSql.Append(" where d_ID=@d_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@d_ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = d_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(webs_YueyxShop.Model.DepartmentBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DepartmentBase(");
            strSql.Append("d_ID,cs_ID,d_BianM,d_MingCh,d_ParentId,d_CengJ,d_ZhuYDH,d_ChuanZ,d_YouX,d_CreatedBy,d_CreatedOn,d_StateCode,d_DeleteStateCode)");
            strSql.Append(" values (");
            strSql.Append("@d_ID,@cs_ID,@d_BianM,@d_MingCh,@d_ParentId,@d_CengJ,@d_ZhuYDH,@d_ChuanZ,@d_YouX,@d_CreatedBy,@d_CreatedOn,@d_StateCode,@d_DeleteStateCode)");
            SqlParameter[] parameters = {
					new SqlParameter("@d_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@cs_ID", SqlDbType.Int,4),
					new SqlParameter("@d_BianM", SqlDbType.VarChar,30),
					new SqlParameter("@d_MingCh", SqlDbType.NVarChar,30),
					new SqlParameter("@d_ParentId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@d_CengJ", SqlDbType.Int,4),
					new SqlParameter("@d_ZhuYDH", SqlDbType.VarChar,50),
					new SqlParameter("@d_ChuanZ", SqlDbType.VarChar,50),
					new SqlParameter("@d_YouX", SqlDbType.VarChar,100),
					new SqlParameter("@d_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@d_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@d_StateCode", SqlDbType.Int,4),
					new SqlParameter("@d_DeleteStateCode", SqlDbType.Int,4)};
            parameters[0].Value = model.d_ID;
            parameters[1].Value = model.cs_ID;
            parameters[2].Value = model.d_BianM;
            parameters[3].Value = model.d_MingCh;
            parameters[4].Value = model.d_ParentId;
            parameters[5].Value = model.d_CengJ;
            parameters[6].Value = model.d_ZhuYDH;
            parameters[7].Value = model.d_ChuanZ;
            parameters[8].Value = model.d_YouX;
            parameters[9].Value = model.d_CreatedBy;
            parameters[10].Value = model.d_CreatedOn;
            parameters[11].Value = model.d_StateCode;
            parameters[12].Value = model.d_DeleteStateCode;

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
        public bool Update(webs_YueyxShop.Model.DepartmentBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DepartmentBase set ");
            strSql.Append("cs_ID=@cs_ID,");
            strSql.Append("d_BianM=@d_BianM,");
            strSql.Append("d_MingCh=@d_MingCh,");
            strSql.Append("d_ParentId=@d_ParentId,");
            strSql.Append("d_CengJ=@d_CengJ,");
            strSql.Append("d_ZhuYDH=@d_ZhuYDH,");
            strSql.Append("d_ChuanZ=@d_ChuanZ,");
            strSql.Append("d_YouX=@d_YouX,");
            strSql.Append("d_CreatedBy=@d_CreatedBy,");
            strSql.Append("d_CreatedOn=@d_CreatedOn,");
            strSql.Append("d_StateCode=@d_StateCode,");
            strSql.Append("d_DeleteStateCode=@d_DeleteStateCode");
            strSql.Append(" where d_ID=@d_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@cs_ID", SqlDbType.Int,4),
					new SqlParameter("@d_BianM", SqlDbType.VarChar,30),
					new SqlParameter("@d_MingCh", SqlDbType.NVarChar,30),
					new SqlParameter("@d_ParentId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@d_CengJ", SqlDbType.Int,4),
					new SqlParameter("@d_ZhuYDH", SqlDbType.VarChar,50),
					new SqlParameter("@d_ChuanZ", SqlDbType.VarChar,50),
					new SqlParameter("@d_YouX", SqlDbType.VarChar,100),
					new SqlParameter("@d_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@d_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@d_StateCode", SqlDbType.Int,4),
					new SqlParameter("@d_DeleteStateCode", SqlDbType.Int,4),
					new SqlParameter("@d_ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.cs_ID;
            parameters[1].Value = model.d_BianM;
            parameters[2].Value = model.d_MingCh;
            parameters[3].Value = model.d_ParentId;
            parameters[4].Value = model.d_CengJ;
            parameters[5].Value = model.d_ZhuYDH;
            parameters[6].Value = model.d_ChuanZ;
            parameters[7].Value = model.d_YouX;
            parameters[8].Value = model.d_CreatedBy;
            parameters[9].Value = model.d_CreatedOn;
            parameters[10].Value = model.d_StateCode;
            parameters[11].Value = model.d_DeleteStateCode;
            parameters[12].Value = model.d_ID;

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
        public bool Delete(Guid d_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DepartmentBase set d_DeleteStateCode=1");
            strSql.Append(" where d_ID=@d_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@d_ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = d_ID;

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
        public bool DeleteList(string d_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DepartmentBase ");
            strSql.Append(" where d_ID in (" + d_IDlist + ")  ");
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
        public webs_YueyxShop.Model.DepartmentBase GetModel(Guid d_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 d_ID,cs_ID,d_BianM,d_MingCh,d_ParentId,d_CengJ,d_ZhuYDH,d_ChuanZ,d_YouX,d_CreatedBy,d_CreatedOn,d_StateCode,d_DeleteStateCode from DepartmentBase ");
            strSql.Append(" where d_ID=@d_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@d_ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = d_ID;

            webs_YueyxShop.Model.DepartmentBase model = new webs_YueyxShop.Model.DepartmentBase();
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
        public webs_YueyxShop.Model.DepartmentBase DataRowToModel(DataRow row)
        {
            webs_YueyxShop.Model.DepartmentBase model = new webs_YueyxShop.Model.DepartmentBase();
            if (row != null)
            {
                if (row["d_ID"] != null && row["d_ID"].ToString() != "")
                {
                    model.d_ID = new Guid(row["d_ID"].ToString());
                }
                if (row["cs_ID"] != null && row["cs_ID"].ToString() != "")
                {
                    model.cs_ID = int.Parse(row["cs_ID"].ToString());
                }
                if (row["d_BianM"] != null)
                {
                    model.d_BianM = row["d_BianM"].ToString();
                }
                if (row["d_MingCh"] != null)
                {
                    model.d_MingCh = row["d_MingCh"].ToString();
                }
                if (row["d_ParentId"] != null && row["d_ParentId"].ToString() != "")
                {
                    model.d_ParentId = new Guid(row["d_ParentId"].ToString());
                }
                if (row["d_CengJ"] != null && row["d_CengJ"].ToString() != "")
                {
                    model.d_CengJ = int.Parse(row["d_CengJ"].ToString());
                }
                if (row["d_ZhuYDH"] != null)
                {
                    model.d_ZhuYDH = row["d_ZhuYDH"].ToString();
                }
                if (row["d_ChuanZ"] != null)
                {
                    model.d_ChuanZ = row["d_ChuanZ"].ToString();
                }
                if (row["d_YouX"] != null)
                {
                    model.d_YouX = row["d_YouX"].ToString();
                }
                if (row["d_CreatedBy"] != null && row["d_CreatedBy"].ToString() != "")
                {
                    model.d_CreatedBy = new Guid(row["d_CreatedBy"].ToString());
                }
                if (row["d_CreatedOn"] != null && row["d_CreatedOn"].ToString() != "")
                {
                    model.d_CreatedOn = DateTime.Parse(row["d_CreatedOn"].ToString());
                }
                if (row["d_StateCode"] != null && row["d_StateCode"].ToString() != "")
                {
                    model.d_StateCode = int.Parse(row["d_StateCode"].ToString());
                }
                if (row["d_DeleteStateCode"] != null && row["d_DeleteStateCode"].ToString() != "")
                {
                    model.d_DeleteStateCode = int.Parse(row["d_DeleteStateCode"].ToString());
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
            strSql.Append("select d_ID,cs_ID,d_BianM,d_MingCh,d_ParentId,d_CengJ,d_ZhuYDH,d_ChuanZ,d_YouX,d_CreatedBy,d_CreatedOn,d_StateCode,d_DeleteStateCode ");
            strSql.Append(" FROM DepartmentBase ");
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
            strSql.Append(" d_ID,cs_ID,d_BianM,d_MingCh,d_ParentId,d_CengJ,d_ZhuYDH,d_ChuanZ,d_YouX,d_CreatedBy,d_CreatedOn,d_StateCode,d_DeleteStateCode ");
            strSql.Append(" FROM DepartmentBase ");
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
            strSql.Append("select count(1) FROM DepartmentBase ");
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
                strSql.Append("order by T.d_ID desc");
            }
            strSql.Append(")AS Row, T.*  from DepartmentBase T ");
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
            parameters[0].Value = "DepartmentBase";
            parameters[1].Value = "d_ID";
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
        /// 是否同名
        /// </summary>
        public bool IsExists(string d_ID, string d_MingCh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from DepartmentBase");
            strSql.AppendFormat(" where d_DeleteStateCode=0 and d_MingCh='{0}' ", d_MingCh);
            if (!string.IsNullOrEmpty(d_ID))
            {
                strSql.AppendFormat(" and d_ID<>'{0}'", d_ID);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            bool result = false;
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 是否含有下级
        /// </summary>
        public bool IsSub(Guid did)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from DepartmentBase");
            strSql.AppendFormat(" where d_DeleteStateCode=0 and d_ParentId='{0}' ", did.ToString());
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            bool result = false;
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 更改状态
        /// </summary>
        /// <param name="d_StateCode">要修改成的状态</param>
        public bool UpdateState(int d_StateCode, Guid d_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update DepartmentBase set d_StateCode={0} ", d_StateCode);
            strSql.Append(" where d_ID=@d_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@d_ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = d_ID;

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
        /// 获取编码
        /// </summary>
        /// <param name="CengJ">当前层级</param>
        /// <param name="BianM">父级编码</param>
        public string GetCode(int CengJ, string BianM)
        {
            StringBuilder str = new StringBuilder();
            string ReturnCode = "", Number0 = "";
            if (CengJ == 1)
            {//第一级
                str.AppendFormat("select top 1 * from DepartmentBase where d_CengJ=1 and d_DeleteStateCode=0 and d_ParentId='00000000-0000-0000-0000-000000000000' order by d_CreatedOn desc");
                DataTable dt = DbHelperSQL.Query(str.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["d_BianM"].ToString()))
                    {
                        int Number = Convert.ToInt32(dt.Rows[0]["d_BianM"].ToString()) + 1;
                        for (int i = 0; i < 4 - Number.ToString().Length; i++)
                        {
                            Number0 += "0";
                        }
                        ReturnCode = Number0 + Number.ToString();
                    }
                }
                else
                    ReturnCode = "0001";
            }
            else
            { //子级
                str.AppendFormat("select top 1 *  from DepartmentBase where d_BianM like'{0}%' and d_CengJ={1} and d_DeleteStateCode=0 order by d_CreatedOn desc", BianM, CengJ);
                DataTable dt = DbHelperSQL.Query(str.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["d_BianM"].ToString()))
                    {
                        int Number = Convert.ToInt32(dt.Rows[0]["d_BianM"].ToString().Substring(BianM.Length, 4)) + 1;
                        for (int i = 0; i < 4 - Number.ToString().Length; i++)
                        {
                            Number0 += "0";
                        }
                        ReturnCode = BianM + Number0 + Number.ToString();
                    }
                }
                else
                    ReturnCode = BianM + "0001";
            }
            return ReturnCode;
        }
        #endregion  ExtensionMethod
    }
}

