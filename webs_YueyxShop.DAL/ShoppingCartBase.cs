/**  版本信息模板在安装目录下，可自行修改。
* ShoppingCartBase.cs
*
* 功 能： N/A
* 类 名： ShoppingCartBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/17 17:24:36   N/A    初版
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
    /// 数据访问类:ShoppingCartBase
    /// </summary>
    public partial class ShoppingCartBase : IShoppingCartBase
    {
        public ShoppingCartBase()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("sc_ID", "ShoppingCartBase");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int sc_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ShoppingCartBase");
            strSql.Append(" where sc_ID=@sc_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@sc_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = sc_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(webs_YueyxShop.Model.ShoppingCartBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ShoppingCartBase(");
            strSql.Append("sku_ID,m_ID,sc_pCount,sc_pPric,sc_CreateOn,sc_IsDel,sc_Status,sc_IsGP,sc_chima,sc_yanse)");
            strSql.Append(" values (");
            strSql.Append("@sku_ID,@m_ID,@sc_pCount,@sc_pPric,@sc_CreateOn,@sc_IsDel,@sc_Status,@sc_IsGP,@sc_chima,@sc_yanse)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@m_ID", SqlDbType.Int,4),
					new SqlParameter("@sc_pCount", SqlDbType.Int,4),
					new SqlParameter("@sc_pPric", SqlDbType.Decimal,5),
					new SqlParameter("@sc_CreateOn", SqlDbType.DateTime),
					new SqlParameter("@sc_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@sc_Status", SqlDbType.Bit,1),
					new SqlParameter("@sc_IsGP", SqlDbType.Bit,1),
                                        new SqlParameter("@sc_chima", SqlDbType.VarChar,50),
                                        new SqlParameter("@sc_yanse", SqlDbType.VarChar,50)};
            parameters[0].Value = model.sku_ID;
            parameters[1].Value = model.m_ID;
            parameters[2].Value = model.sc_pCount;
            parameters[3].Value = model.sc_pPric;
            parameters[4].Value = model.sc_CreateOn;
            parameters[5].Value = model.sc_IsDel;
            parameters[6].Value = model.sc_Status;
            parameters[7].Value = model.sc_IsGP;
            parameters[8].Value = model.sc_chima;
            parameters[9].Value = model.sc_yanse;

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
        public bool Update(webs_YueyxShop.Model.ShoppingCartBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ShoppingCartBase set ");
            strSql.Append("sku_ID=@sku_ID,");
            strSql.Append("m_ID=@m_ID,");
            strSql.Append("sc_pCount=@sc_pCount,");
            strSql.Append("sc_pPric=@sc_pPric,");
            strSql.Append("sc_CreateOn=@sc_CreateOn,");
            strSql.Append("sc_IsDel=@sc_IsDel,");
            strSql.Append("sc_Status=@sc_Status,");
            strSql.Append("sc_IsGP=@sc_IsGP,");
            strSql.Append("sc_chima=@sc_chima,");
            strSql.Append("sc_yanse=@sc_yanse");
            strSql.Append(" where sc_ID=@sc_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@m_ID", SqlDbType.Int,4),
					new SqlParameter("@sc_pCount", SqlDbType.Int,4),
					new SqlParameter("@sc_pPric", SqlDbType.Decimal,5),
					new SqlParameter("@sc_CreateOn", SqlDbType.DateTime),
					new SqlParameter("@sc_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@sc_Status", SqlDbType.Bit,1),
					new SqlParameter("@sc_IsGP", SqlDbType.Bit,1),
                    new SqlParameter("@sc_chima", SqlDbType.VarChar,50),
                    new SqlParameter("@sc_yanse", SqlDbType.VarChar,50),
					new SqlParameter("@sc_ID", SqlDbType.Int,4)
                    
                                        };
            parameters[0].Value = model.sku_ID;
            parameters[1].Value = model.m_ID;
            parameters[2].Value = model.sc_pCount;
            parameters[3].Value = model.sc_pPric;
            parameters[4].Value = model.sc_CreateOn;
            parameters[5].Value = model.sc_IsDel;
            parameters[6].Value = model.sc_Status;
            parameters[7].Value = model.sc_IsGP;
            parameters[8].Value = model.sc_chima;
            parameters[9].Value = model.sc_yanse;
            parameters[10].Value = model.sc_ID;

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
        public bool Delete(int sc_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ShoppingCartBase ");
            strSql.Append(" where sc_ID=@sc_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@sc_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = sc_ID;

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
        public bool DeleteList(string sc_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ShoppingCartBase ");
            strSql.Append(" where sc_ID in (" + sc_IDlist + ")  ");
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
        public webs_YueyxShop.Model.ShoppingCartBase GetModel(int sc_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 sc_ID,sku_ID,m_ID,sc_pCount,sc_pPric,sc_CreateOn,sc_IsDel,sc_Status,sc_IsGP,sc_chima,sc_yanse from ShoppingCartBase ");
            strSql.Append(" where sc_ID=@sc_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@sc_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = sc_ID;

            webs_YueyxShop.Model.ShoppingCartBase model = new webs_YueyxShop.Model.ShoppingCartBase();
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
        public webs_YueyxShop.Model.ShoppingCartBase DataRowToModel(DataRow row)
        {
            webs_YueyxShop.Model.ShoppingCartBase model = new webs_YueyxShop.Model.ShoppingCartBase();
            if (row != null)
            {
                if (row["sc_ID"] != null && row["sc_ID"].ToString() != "")
                {
                    model.sc_ID = int.Parse(row["sc_ID"].ToString());
                }
                if (row["sku_ID"] != null && row["sku_ID"].ToString() != "")
                {
                    model.sku_ID = int.Parse(row["sku_ID"].ToString());
                }
                if (row["m_ID"] != null && row["m_ID"].ToString() != "")
                {
                    model.m_ID = int.Parse(row["m_ID"].ToString());
                }
                if (row["sc_pCount"] != null && row["sc_pCount"].ToString() != "")
                {
                    model.sc_pCount = int.Parse(row["sc_pCount"].ToString());
                }
                if (row["sc_pPric"] != null && row["sc_pPric"].ToString() != "")
                {
                    model.sc_pPric = decimal.Parse(row["sc_pPric"].ToString());
                }
                if (row["sc_CreateOn"] != null && row["sc_CreateOn"].ToString() != "")
                {
                    model.sc_CreateOn = DateTime.Parse(row["sc_CreateOn"].ToString());
                }
                if (row["sc_IsDel"] != null && row["sc_IsDel"].ToString() != "")
                {
                    if ((row["sc_IsDel"].ToString() == "1") || (row["sc_IsDel"].ToString().ToLower() == "true"))
                    {
                        model.sc_IsDel = true;
                    }
                    else
                    {
                        model.sc_IsDel = false;
                    }
                }
                if (row["sc_Status"] != null && row["sc_Status"].ToString() != "")
                {
                    if ((row["sc_Status"].ToString() == "1") || (row["sc_Status"].ToString().ToLower() == "true"))
                    {
                        model.sc_Status = true;
                    }
                    else
                    {
                        model.sc_Status = false;
                    }
                }
                if (row["sc_IsGP"] != null && row["sc_IsGP"].ToString() != "")
                {
                    if ((row["sc_IsGP"].ToString() == "1") || (row["sc_IsGP"].ToString().ToLower() == "true"))
                    {
                        model.sc_IsGP = true;
                    }
                    else
                    {
                        model.sc_IsGP = false;
                    }
                }
                if (row["sc_chima"] != null && row["sc_chima"].ToString() != "") 
                {
                    model.sc_chima = row["sc_chima"].ToString();
                }
                if (row["sc_yanse"] != null && row["sc_yanse"].ToString() != "")
                {
                    model.sc_yanse = row["sc_yanse"].ToString();
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
            strSql.Append("select sc_ID,sku_ID,m_ID,sc_pCount,sc_pPric,sc_CreateOn,sc_IsDel,sc_Status,sc_IsGP,sc_chima,sc_yanse ");
            strSql.Append(" FROM ShoppingCartBase ");
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
            strSql.Append(" sc_ID,sku_ID,m_ID,sc_pCount,sc_pPric,sc_CreateOn,sc_IsDel,sc_Status,sc_IsGP,sc_chima,sc_yanse ");
            strSql.Append(" FROM ShoppingCartBase ");
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
            strSql.Append("select count(1) FROM ShoppingCartBase ");
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
                strSql.Append("order by T.sc_ID desc");
            }
            strSql.Append(")AS Row, T.*  from ShoppingCartBase T ");
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
            parameters[0].Value = "ShoppingCartBase";
            parameters[1].Value = "sc_ID";
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
        /// 修改状态(删除和状态)
        /// </summary>
        /// <param name="isDelete">是否删除</param>
        /// <param name="mID">会员ID</param>
        /// <param name="ids">产品Id集合</param>
        public bool ChangeStatus(bool isDelete, int mID, string ids)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format(@" update ShoppingCartBase set {0} = 1 where m_ID = {1} and sku_ID in ({2})", isDelete ? "sc_IsDel" : "sc_Status", mID, ids));

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            return false;
        }

        #endregion  ExtensionMethod
    }
}

