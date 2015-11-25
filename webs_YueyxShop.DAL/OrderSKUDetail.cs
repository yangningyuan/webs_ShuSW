/**  版本信息模板在安装目录下，可自行修改。
* OrderSKUDetail.cs
*
* 功 能： N/A
* 类 名： OrderSKUDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/17 17:24:35   N/A    初版
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
    /// 数据访问类:OrderSKUDetail
    /// </summary>
    public partial class OrderSKUDetail : IOrderSKUDetail
    {
        public OrderSKUDetail()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("os_ID", "OrderSKUDetail");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int os_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OrderSKUDetail");
            strSql.Append(" where os_ID=@os_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@os_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = os_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(webs_YueyxShop.Model.OrderSKUDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrderSKUDetail(");
            strSql.Append("sku_ID,o_ID,os_pCount,os_Price,os_IsGP,os_chima,os_yanse)");
            strSql.Append(" values (");
            strSql.Append("@sku_ID,@o_ID,@os_pCount,@os_Price,@os_IsGP,@os_chima,@os_yanse)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@o_ID", SqlDbType.Int,4),
					new SqlParameter("@os_pCount", SqlDbType.Int,4),
					new SqlParameter("@os_Price", SqlDbType.Decimal,5),
					new SqlParameter("@os_IsGP", SqlDbType.Bit,1),
					new SqlParameter("@os_chima", SqlDbType.VarChar,50),
					new SqlParameter("@os_yanse", SqlDbType.VarChar,50)};
            parameters[0].Value = model.sku_ID;
            parameters[1].Value = model.o_ID;
            parameters[2].Value = model.os_pCount;
            parameters[3].Value = model.os_Price;
            parameters[4].Value = model.os_IsGP;
			parameters[5].Value=model.os_chima;
			parameters[6].Value=model.os_yanse;
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
        public bool Update(webs_YueyxShop.Model.OrderSKUDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrderSKUDetail set ");
            strSql.Append("sku_ID=@sku_ID,");
            strSql.Append("o_ID=@o_ID,");
            strSql.Append("os_pCount=@os_pCount,");
            strSql.Append("os_Price=@os_Price,");
            strSql.Append("os_IsGP=@os_IsGP,");
			strSql.Append("os_chima=@os_chima,");
			strSql.Append("os_yanse=@os_yanse ");
            strSql.Append(" where os_ID=@os_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@o_ID", SqlDbType.Int,4),
					new SqlParameter("@os_pCount", SqlDbType.Int,4),
					new SqlParameter("@os_Price", SqlDbType.Decimal,5),
					new SqlParameter("@os_IsGP", SqlDbType.Bit,1),
					new SqlParameter("@os_chima", SqlDbType.VarChar,50),
					new SqlParameter("@os_yanse", SqlDbType.VarChar,50),
					new SqlParameter("@os_ID", SqlDbType.Int,4)
					};
            parameters[0].Value = model.sku_ID;
            parameters[1].Value = model.o_ID;
            parameters[2].Value = model.os_pCount;
            parameters[3].Value = model.os_Price;
            parameters[4].Value = model.os_IsGP;
			parameters[5].Value=model.os_chima;
			parameters[6].Value=model.os_yanse;
            parameters[7].Value = model.os_ID;

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
        public bool Delete(int os_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrderSKUDetail ");
            strSql.Append(" where os_ID=@os_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@os_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = os_ID;

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
        public bool DeleteList(string os_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrderSKUDetail ");
            strSql.Append(" where os_ID in (" + os_IDlist + ")  ");
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
        public webs_YueyxShop.Model.OrderSKUDetail GetModel(int os_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 os_ID,sku_ID,o_ID,os_pCount,os_Price,os_IsGP,os_chima,os_yanse from OrderSKUDetail ");
            strSql.Append(" where os_ID=@os_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@os_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = os_ID;

            webs_YueyxShop.Model.OrderSKUDetail model = new webs_YueyxShop.Model.OrderSKUDetail();
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
        public webs_YueyxShop.Model.OrderSKUDetail DataRowToModel(DataRow row)
        {
            webs_YueyxShop.Model.OrderSKUDetail model = new webs_YueyxShop.Model.OrderSKUDetail();
            if (row != null)
            {
                if (row["os_ID"] != null && row["os_ID"].ToString() != "")
                {
                    model.os_ID = int.Parse(row["os_ID"].ToString());
                }
                if (row["sku_ID"] != null && row["sku_ID"].ToString() != "")
                {
                    model.sku_ID = int.Parse(row["sku_ID"].ToString());
                }
                if (row["o_ID"] != null && row["o_ID"].ToString() != "")
                {
                    model.o_ID = int.Parse(row["o_ID"].ToString());
                }
                if (row["os_pCount"] != null && row["os_pCount"].ToString() != "")
                {
                    model.os_pCount = int.Parse(row["os_pCount"].ToString());
                }
                if (row["os_Price"] != null && row["os_Price"].ToString() != "")
                {
                    model.os_Price = decimal.Parse(row["os_Price"].ToString());
                }
                if (row["os_IsGP"] != null && row["os_IsGP"].ToString() != "")
                {
                    if ((row["os_IsGP"].ToString() == "1") || (row["os_IsGP"].ToString().ToLower() == "true"))
                    {
                        model.os_IsGP = true;
                    }
                    else
                    {
                        model.os_IsGP = false;
                    }
                }
				if (row["os_chima"] != null && row["os_chima"].ToString() != "")
				{
					model.os_chima = row["os_chima"].ToString();
				}
				if (row["os_yanse"] != null && row["os_yanse"].ToString() != "")
				{
					model.os_yanse =row["os_yanse"].ToString();
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
            strSql.Append("select os_ID,sku_ID,o_ID,os_pCount,os_Price,os_IsGP,os_chima,os_yanse ");
            strSql.Append(" FROM OrderSKUDetail ");
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
            strSql.Append(" os_ID,sku_ID,o_ID,os_pCount,os_Price,os_IsGP,os_chima,os_yanse ");
            strSql.Append(" FROM OrderSKUDetail ");
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
            strSql.Append("select count(1) FROM OrderSKUDetail ");
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
                strSql.Append("order by T.os_ID desc");
            }
            strSql.Append(")AS Row, T.*  from OrderSKUDetail T ");
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
            parameters[0].Value = "OrderSKUDetail";
            parameters[1].Value = "os_ID";
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

