/**  版本信息模板在安装目录下，可自行修改。
* PaymentBase.cs
*
* 功 能： N/A
* 类 名： PaymentBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/12 17:12:44   N/A    初版
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
    /// 数据访问类:PaymentBase
    /// </summary>
    public partial class PaymentBase : IPaymentBase
    {
        public PaymentBase()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("pay_ID", "PaymentBase");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int pay_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PaymentBase");
            strSql.Append(" where pay_ID=@pay_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@pay_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = pay_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(webs_YueyxShop.Model.PaymentBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PaymentBase(");
            strSql.Append("pay_Name,pay_Url,pay_IsDel,pay_isPhone)");
            strSql.Append(" values (");
            strSql.Append("@pay_Name,@pay_Url,@pay_IsDel,@pay_isPhone)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@pay_Name", SqlDbType.VarChar,20),
					new SqlParameter("@pay_Url", SqlDbType.VarChar,30),
					new SqlParameter("@pay_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@pay_isPhone", SqlDbType.Bit,1)};
            parameters[0].Value = model.pay_Name;
            parameters[1].Value = model.pay_Url;
            parameters[2].Value = model.pay_IsDel;
            parameters[3].Value = model.pay_isPhone;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(webs_YueyxShop.Model.PaymentBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PaymentBase set ");
            strSql.Append("pay_Name=@pay_Name,");
            strSql.Append("pay_Url=@pay_Url,");
            strSql.Append("pay_IsDel=@pay_IsDel,");
            strSql.Append("pay_isPhone=@pay_isPhone");
            strSql.Append(" where pay_ID=@pay_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@pay_Name", SqlDbType.VarChar,20),
					new SqlParameter("@pay_Url", SqlDbType.VarChar,30),
					new SqlParameter("@pay_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@pay_isPhone", SqlDbType.Bit,1),
					new SqlParameter("@pay_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.pay_Name;
            parameters[1].Value = model.pay_Url;
            parameters[2].Value = model.pay_IsDel;
            parameters[3].Value = model.pay_isPhone;
            parameters[4].Value = model.pay_ID;

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
        public bool Delete(int pay_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PaymentBase ");
            strSql.Append(" where pay_ID=@pay_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@pay_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = pay_ID;

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
        public bool DeleteList(string pay_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PaymentBase ");
            strSql.Append(" where pay_ID in (" + pay_IDlist + ")  ");
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
        public webs_YueyxShop.Model.PaymentBase GetModel(int pay_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 pay_ID,pay_Name,pay_Url,pay_IsDel,pay_isPhone from PaymentBase ");
            strSql.Append(" where pay_ID=@pay_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@pay_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = pay_ID;

            webs_YueyxShop.Model.PaymentBase model = new webs_YueyxShop.Model.PaymentBase();
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
        public webs_YueyxShop.Model.PaymentBase DataRowToModel(DataRow row)
        {
            webs_YueyxShop.Model.PaymentBase model = new webs_YueyxShop.Model.PaymentBase();
            if (row != null)
            {
                if (row["pay_ID"] != null && row["pay_ID"].ToString() != "")
                {
                    model.pay_ID = int.Parse(row["pay_ID"].ToString());
                }
                if (row["pay_Name"] != null)
                {
                    model.pay_Name = row["pay_Name"].ToString();
                }
                if (row["pay_Url"] != null)
                {
                    model.pay_Url = row["pay_Url"].ToString();
                }
                if (row["pay_IsDel"] != null && row["pay_IsDel"].ToString() != "")
                {
                    if ((row["pay_IsDel"].ToString() == "1") || (row["pay_IsDel"].ToString().ToLower() == "true"))
                    {
                        model.pay_IsDel = true;
                    }
                    else
                    {
                        model.pay_IsDel = false;
                    }
                }
                if (row["pay_isPhone"] != null && row["pay_isPhone"].ToString() != "")
                {
                    if ((row["pay_isPhone"].ToString() == "1") || (row["pay_isPhone"].ToString().ToLower() == "true"))
                    {
                        model.pay_isPhone = true;
                    }
                    else
                    {
                        model.pay_isPhone = false;
                    }
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
            strSql.Append("select pay_ID,pay_Name,pay_Url,pay_IsDel,pay_isPhone ");
            strSql.Append(" FROM PaymentBase ");
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
            strSql.Append(" pay_ID,pay_Name,pay_Url,pay_IsDel,pay_isPhone ");
            strSql.Append(" FROM PaymentBase ");
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
            strSql.Append("select count(1) FROM PaymentBase ");
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
                strSql.Append("order by T.pay_ID desc");
            }
            strSql.Append(")AS Row, T.*  from PaymentBase T ");
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
            parameters[0].Value = "PaymentBase";
            parameters[1].Value = "pay_ID";
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