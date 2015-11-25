/**  版本信息模板在安装目录下，可自行修改。
* MenuBase.cs
*
* 功 能： N/A
* 类 名： MenuBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/28 14:36:03   N/A    初版
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
    /// 数据访问类:MenuBase
    /// </summary>
    public partial class MenuBase : IMenuBase
    {
        public MenuBase()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid m_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from MenuBase");
            strSql.Append(" where m_ID=@m_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = m_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(webs_YueyxShop.Model.MenuBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MenuBase(");
            strSql.Append("m_ID,m_BianM,m_MingCh,m_CengJ,m_PaiX,m_ParentId,m_CreatedOn,m_CreatedBy,m_StateCode,m_DeleteStateCode,m_Path,m_Type,m_IsShow,m_PageType)");
            strSql.Append(" values (");
            strSql.Append("@m_ID,@m_BianM,@m_MingCh,@m_CengJ,@m_PaiX,@m_ParentId,@m_CreatedOn,@m_CreatedBy,@m_StateCode,@m_DeleteStateCode,@m_Path,@m_Type,@m_IsShow,@m_PageType)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@m_BianM", SqlDbType.VarChar,30),
					new SqlParameter("@m_MingCh", SqlDbType.NVarChar,20),
					new SqlParameter("@m_CengJ", SqlDbType.Int,4),
					new SqlParameter("@m_PaiX", SqlDbType.Int,4),
					new SqlParameter("@m_ParentId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@m_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@m_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@m_StateCode", SqlDbType.Int,4),
					new SqlParameter("@m_DeleteStateCode", SqlDbType.Int,4),
					new SqlParameter("@m_Path", SqlDbType.NVarChar,100),
                    new SqlParameter("@m_Type", SqlDbType.Int,4),
                    new SqlParameter("@m_IsShow", SqlDbType.Bit,1),
                    new SqlParameter("@m_PageType", SqlDbType.VarChar,30)};
            parameters[0].Value = model.m_ID;
            parameters[1].Value = model.m_BianM;
            parameters[2].Value = model.m_MingCh;
            parameters[3].Value = model.m_CengJ;
            parameters[4].Value = model.m_PaiX;
            parameters[5].Value = model.m_ParentId;
            parameters[6].Value = model.m_CreatedOn;
            parameters[7].Value = model.m_CreatedBy;
            parameters[8].Value = model.m_StateCode;
            parameters[9].Value = model.m_DeleteStateCode;
            parameters[10].Value = model.m_Path;
            parameters[11].Value = model.m_Type;
            parameters[12].Value = model.m_IsShow;
            parameters[13].Value = model.m_PageType;

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
        public bool Update(webs_YueyxShop.Model.MenuBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MenuBase set ");
            strSql.Append("m_BianM=@m_BianM,");
            strSql.Append("m_MingCh=@m_MingCh,");
            strSql.Append("m_CengJ=@m_CengJ,");
            strSql.Append("m_PaiX=@m_PaiX,");
            strSql.Append("m_ParentId=@m_ParentId,");
            strSql.Append("m_CreatedOn=@m_CreatedOn,");
            strSql.Append("m_CreatedBy=@m_CreatedBy,");
            strSql.Append("m_StateCode=@m_StateCode,");
            strSql.Append("m_DeleteStateCode=@m_DeleteStateCode,");
            strSql.Append("m_Path=@m_Path,");
            strSql.Append("m_Type=@m_Type,");
            strSql.Append("m_IsShow=@m_IsShow,");
            strSql.Append("m_PageType=@m_PageType");
            strSql.Append(" where m_ID=@m_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_BianM", SqlDbType.VarChar,30),
					new SqlParameter("@m_MingCh", SqlDbType.NVarChar,20),
					new SqlParameter("@m_CengJ", SqlDbType.Int,4),
					new SqlParameter("@m_PaiX", SqlDbType.Int,4),
					new SqlParameter("@m_ParentId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@m_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@m_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@m_StateCode", SqlDbType.Int,4),
					new SqlParameter("@m_DeleteStateCode", SqlDbType.Int,4),
					new SqlParameter("@m_Path", SqlDbType.NVarChar,100),
                    new SqlParameter("@m_Type", SqlDbType.Int,4),
                    new SqlParameter("@m_IsShow", SqlDbType.Bit,1),
                    new SqlParameter("@m_PageType", SqlDbType.VarChar,30),
					new SqlParameter("@m_ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.m_BianM;
            parameters[1].Value = model.m_MingCh;
            parameters[2].Value = model.m_CengJ;
            parameters[3].Value = model.m_PaiX;
            parameters[4].Value = model.m_ParentId;
            parameters[5].Value = model.m_CreatedOn;
            parameters[6].Value = model.m_CreatedBy;
            parameters[7].Value = model.m_StateCode;
            parameters[8].Value = model.m_DeleteStateCode;
            parameters[9].Value = model.m_Path;
            parameters[10].Value = model.m_Type;
            parameters[11].Value = model.m_IsShow;
            parameters[12].Value = model.m_PageType;
            parameters[13].Value = model.m_ID;

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
        public bool Delete(Guid m_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MenuBase ");
            strSql.Append(" where m_ID=@m_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = m_ID;

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
        public bool DeleteList(string m_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MenuBase ");
            strSql.Append(" where m_ID in (" + m_IDlist + ")  ");
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
        public webs_YueyxShop.Model.MenuBase GetModel(Guid m_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from MenuBase ");
            strSql.Append(" where m_ID=@m_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = m_ID;

            webs_YueyxShop.Model.MenuBase model = new webs_YueyxShop.Model.MenuBase();
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
        public webs_YueyxShop.Model.MenuBase DataRowToModel(DataRow row)
        {
            webs_YueyxShop.Model.MenuBase model = new webs_YueyxShop.Model.MenuBase();
            if (row != null)
            {
                if (row["m_ID"] != null && row["m_ID"].ToString() != "")
                {
                    model.m_ID = new Guid(row["m_ID"].ToString());
                }
                if (row["m_BianM"] != null)
                {
                    model.m_BianM = row["m_BianM"].ToString();
                }
                if (row["m_MingCh"] != null)
                {
                    model.m_MingCh = row["m_MingCh"].ToString();
                }
                if (row["m_CengJ"] != null && row["m_CengJ"].ToString() != "")
                {
                    model.m_CengJ = int.Parse(row["m_CengJ"].ToString());
                }
                if (row["m_PaiX"] != null && row["m_PaiX"].ToString() != "")
                {
                    model.m_PaiX = int.Parse(row["m_PaiX"].ToString());
                }
                if (row["m_ParentId"] != null && row["m_ParentId"].ToString() != "")
                {
                    model.m_ParentId = new Guid(row["m_ParentId"].ToString());
                }
                if (row["m_CreatedOn"] != null && row["m_CreatedOn"].ToString() != "")
                {
                    model.m_CreatedOn = DateTime.Parse(row["m_CreatedOn"].ToString());
                }
                if (row["m_CreatedBy"] != null && row["m_CreatedBy"].ToString() != "")
                {
                    model.m_CreatedBy = new Guid(row["m_CreatedBy"].ToString());
                }
                if (row["m_StateCode"] != null && row["m_StateCode"].ToString() != "")
                {
                    model.m_StateCode = int.Parse(row["m_StateCode"].ToString());
                }
                if (row["m_DeleteStateCode"] != null && row["m_DeleteStateCode"].ToString() != "")
                {
                    model.m_DeleteStateCode = int.Parse(row["m_DeleteStateCode"].ToString());
                }
                if (row["m_Path"] != null)
                {
                    model.m_Path = row["m_Path"].ToString();
                }
                if (row["m_Type"] != null && row["m_Type"].ToString() != "")
                {
                    model.m_Type = int.Parse(row["m_Type"].ToString());
                }
                if (row["m_IsShow"] != null && row["m_IsShow"].ToString() != "")
                {
                    if ((row["m_IsShow"].ToString() == "1") || (row["m_IsShow"].ToString().ToLower() == "true"))
                    {
                        model.m_IsShow = true;
                    }
                    else
                    {
                        model.m_IsShow = false;
                    }
                }
                if (row["m_PageType"] != null)
                {
                    model.m_PageType = row["m_PageType"].ToString();
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
            strSql.Append("select * ");
            strSql.Append(" FROM MenuBase ");
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
            strSql.Append(" * ");
            strSql.Append(" FROM MenuBase ");
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
            strSql.Append("select count(1) FROM MenuBase ");
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
            strSql.Append(")AS Row, T.*  from MenuBase T ");
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
            parameters[0].Value = "MenuBase";
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
        /// 获取菜单编码
        /// </summary>
        /// <param name="m_BianM">父级编码</param>
        /// <param name="m_CengJ">当前层级</param>
        public string GetCode(string m_BianM, int m_CengJ)
        {
            StringBuilder str = new StringBuilder();
            string ReturnCode = "", Number0 = "";
            if (m_BianM == "")
            {//第一级
                str.AppendFormat("select Max(m_BianM) m_BianM from MenuBase where m_CengJ=1 and m_DeleteStateCode=0 and m_ParentId='00000000-0000-0000-0000-000000000000' ");
                DataTable dt = DbHelperSQL.Query(str.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                   if (!string.IsNullOrEmpty(dt.Rows[0]["m_BianM"].ToString()))
                    {
                        int Number = Convert.ToInt32(dt.Rows[0]["m_BianM"].ToString()) + 1;
                        if (Number.ToString().Length == 1)
                        {
                            ReturnCode = "00" + Number.ToString();
                        }
                        if (Number.ToString().Length == 2)
                        {
                            ReturnCode = "0" + Number.ToString();
                        }
                        if (Number.ToString().Length == 3)
                        {
                            ReturnCode =  Number.ToString();
                        }
                    }
                }
                else
                        ReturnCode = "001";
            }
            else
            { //子级
                str.AppendFormat("select Max(m_BianM) m_BianM from MenuBase where m_BianM like'{0}%' and m_CengJ={1} and m_DeleteStateCode=0 ", m_BianM, m_CengJ);
                DataTable dt = DbHelperSQL.Query(str.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                { 
                    if (!string.IsNullOrEmpty(dt.Rows[0]["m_BianM"].ToString()))
                    {
                        int Number = Convert.ToInt32(dt.Rows[0]["m_BianM"].ToString().Substring(m_BianM.Length, 3)) + 1;
                        for (int i = 0; i < 3 - Number.ToString().Length; i++)
                        {
                            Number0 += "0";
                        }
                        ReturnCode = m_BianM + Number0 + Number.ToString();
                    }
                    else
                        ReturnCode = m_BianM + "001";
                    
                }
                else
                    ReturnCode = m_BianM + "001";
            }
            return ReturnCode;
        }
        /// <summary>
        /// 获取排序 2014/10/23 glz
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public int GetSort(string pid, int layer)
        {

            int Number = 0;
            StringBuilder str = new StringBuilder();
            if (pid == "00000000-0000-0000-0000-000000000000")
            {
                str.Append("select Max(m_PaiX) m_PaiX from MenuBase where m_ParentId='00000000-0000-0000-0000-000000000000' and m_CengJ=1 and m_DeleteStateCode=0 ");
                DataTable dt = DbHelperSQL.Query(str.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["m_PaiX"].ToString()))
                    {
                        Number = Convert.ToInt32(dt.Rows[0]["m_PaiX"].ToString()) + 1;
                    }
                    else
                    {
                        Number = 1;
                    }
                }
                return Number;
            }
            else
            {

                str.AppendFormat("select Max(m_PaiX) m_PaiX from MenuBase where m_ParentId='{0}' and m_CengJ={1} and m_DeleteStateCode=0 ", pid, layer);
                DataTable dt = DbHelperSQL.Query(str.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["m_PaiX"].ToString()))
                    {
                        Number = Convert.ToInt32(dt.Rows[0]["m_PaiX"].ToString()) + 1;
                    }
                    else
                    {
                        Number = 1;
                    }
                }
                return Number;
            }
        }
        #endregion  ExtensionMethod
    }
}

