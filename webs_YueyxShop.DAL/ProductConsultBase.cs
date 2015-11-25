/**  版本信息模板在安装目录下，可自行修改。
* ProductConsultBase.cs
*
* 功 能： N/A
* 类 名： ProductConsultBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/14 11:31:52   N/A    初版
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
using DBUtility;
using System.Collections.Generic;//Please add references
namespace webs_YueyxShop.DAL
{
    /// <summary>
    /// 数据访问类:ProductConsultBase
    /// </summary>
    public partial class ProductConsultBase : IProductConsultBase
    {
        public ProductConsultBase()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("pc_ID", "ProductConsultBase");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int pc_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ProductConsultBase");
            strSql.Append(" where pc_ID=@pc_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@pc_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = pc_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(webs_YueyxShop.Model.ProductConsultBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProductConsultBase(");
            strSql.Append("sku_ID,pc_CreatedOn,pc_Type,pc_Content,pc_CreatedBy,pc_StatusCode,pc_huifu,pc_IsDel)");
            strSql.Append(" values (");
            strSql.Append("@sku_ID,@pc_CreatedOn,@pc_Type,@pc_Content,@pc_CreatedBy,@pc_StatusCode,@pc_huifu,@pc_IsDel)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@pc_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@pc_Type", SqlDbType.VarChar,30),
					new SqlParameter("@pc_Content", SqlDbType.NVarChar,500),
					new SqlParameter("@pc_CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@pc_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@pc_huifu", SqlDbType.Int,4),
					new SqlParameter("@pc_IsDel", SqlDbType.Bit,1)};
            parameters[0].Value = model.sku_ID;
            parameters[1].Value = model.pc_CreatedOn;
            parameters[2].Value = model.pc_Type;
            parameters[3].Value = model.pc_Content;
            parameters[4].Value = model.pc_CreatedBy;
            parameters[5].Value = model.pc_StatusCode;
            parameters[6].Value = model.pc_huifu;
            parameters[7].Value = model.pc_IsDel;

            int obj = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

            return obj;

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(webs_YueyxShop.Model.ProductConsultBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductConsultBase set ");
            strSql.Append("sku_ID=@sku_ID,");
            strSql.Append("pc_CreatedOn=@pc_CreatedOn,");
            strSql.Append("pc_Type=@pc_Type,");
            strSql.Append("pc_Content=@pc_Content,");
            strSql.Append("pc_CreatedBy=@pc_CreatedBy,");
            strSql.Append("pc_StatusCode=@pc_StatusCode,");
            strSql.Append("pc_huifu=@pc_huifu,");
            strSql.Append("pc_IsDel=@pc_IsDel");
            strSql.Append(" where pc_ID=@pc_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@pc_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@pc_Type", SqlDbType.VarChar,30),
					new SqlParameter("@pc_Content", SqlDbType.NVarChar,500),
					new SqlParameter("@pc_CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@pc_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@pc_huifu", SqlDbType.Int,4),
					new SqlParameter("@pc_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@pc_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.sku_ID;
            parameters[1].Value = model.pc_CreatedOn;
            parameters[2].Value = model.pc_Type;
            parameters[3].Value = model.pc_Content;
            parameters[4].Value = model.pc_CreatedBy;
            parameters[5].Value = model.pc_StatusCode;
            parameters[6].Value = model.pc_huifu;
            parameters[7].Value = model.pc_IsDel;
            parameters[8].Value = model.pc_ID;

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
        public bool Delete(int pc_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductConsultBase ");
            strSql.Append(" where pc_ID=@pc_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@pc_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = pc_ID;

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
        public bool DeleteList(string pc_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductConsultBase ");
            strSql.Append(" where pc_ID in (" + pc_IDlist + ")  ");
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
        public webs_YueyxShop.Model.ProductConsultBase GetModel(int pc_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 pc_ID,sku_ID,pc_CreatedOn,pc_Type,pc_Content,pc_CreatedBy,pc_StatusCode,pc_huifu,pc_IsDel from ProductConsultBase ");
            strSql.Append(" where pc_ID=@pc_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@pc_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = pc_ID;

            webs_YueyxShop.Model.ProductConsultBase model = new webs_YueyxShop.Model.ProductConsultBase();
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
        public webs_YueyxShop.Model.ProductConsultBase DataRowToModel(DataRow row)
        {
            webs_YueyxShop.Model.ProductConsultBase model = new webs_YueyxShop.Model.ProductConsultBase();
            if (row != null)
            {
                if (row["pc_ID"] != null && row["pc_ID"].ToString() != "")
                {
                    model.pc_ID = int.Parse(row["pc_ID"].ToString());
                }
                if (row["sku_ID"] != null && row["sku_ID"].ToString() != "")
                {
                    model.sku_ID = int.Parse(row["sku_ID"].ToString());
                }
                if (row["pc_CreatedOn"] != null && row["pc_CreatedOn"].ToString() != "")
                {
                    model.pc_CreatedOn = DateTime.Parse(row["pc_CreatedOn"].ToString());
                }
                if (row["pc_Type"] != null)
                {
                    model.pc_Type = row["pc_Type"].ToString();
                }
                if (row["pc_Content"] != null)
                {
                    model.pc_Content = row["pc_Content"].ToString();
                }
                if (row["pc_CreatedBy"] != null && row["pc_CreatedBy"].ToString() != "")
                {
                    model.pc_CreatedBy = int.Parse(row["pc_CreatedBy"].ToString());
                }
                if (row["pc_StatusCode"] != null && row["pc_StatusCode"].ToString() != "")
                {
                    model.pc_StatusCode = int.Parse(row["pc_StatusCode"].ToString());
                }
                if (row["pc_huifu"] != null && row["pc_huifu"].ToString() != "")
                {
                    model.pc_huifu = int.Parse(row["pc_huifu"].ToString());
                }
                if (row["pc_IsDel"] != null && row["pc_IsDel"].ToString() != "")
                {
                    if ((row["pc_IsDel"].ToString() == "1") || (row["pc_IsDel"].ToString().ToLower() == "true"))
                    {
                        model.pc_IsDel = true;
                    }
                    else
                    {
                        model.pc_IsDel = false;
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
            strSql.Append("select pc_ID,sku_ID,pc_CreatedOn,pc_Type,pc_Content,pc_CreatedBy,pc_StatusCode,pc_huifu,pc_IsDel");
            strSql.Append(" FROM ProductConsultBase ");
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
            strSql.Append(" pc_ID,sku_ID,pc_CreatedOn,pc_Type,pc_Content,pc_CreatedBy,pc_StatusCode,pc_huifu,pc_IsDel");
            strSql.Append(" FROM ProductConsultBase ");
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
            strSql.Append("select count(1) FROM ProductConsultBase ");
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
                strSql.Append("order by T.pc_ID desc");
            }
            strSql.Append(")AS Row, T.*  from ProductConsultBase T ");
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
            parameters[0].Value = "ProductConsultBase";
            parameters[1].Value = "pc_ID";
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
        /// 获得商品咨询(通过SKUID)
        /// </summary>
        public List<Model.ProductConsultBase> GetModelListByskuId(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pc.sku_ID, pc.pc_ID,pc.pc_Content,pc.pc_CreatedOn,pr.pr_Content,pr.pr_CreatedOn,m.m_UserName from ProductReplyBase pr,ProductConsultBase pc,MemberBase m where pr.pc_ID = pc.pc_ID and pc.pc_CreatedBy = m.m_ID  and pc.pc_StatusCode=0 and pc.pc_huifu=1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<Model.ProductConsultBase> prozixun = new List<Model.ProductConsultBase>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                Model.ProductConsultBase zixumodel = new Model.ProductConsultBase();
                zixumodel.pc_Content = r["pc_Content"].ToString();
                zixumodel.pc_CreatedOn = DateTime.Parse(r["pc_CreatedOn"].ToString());
                zixumodel.preply=new Model.ProductReplyBase
                {
                    pr_Content = r["pr_Content"].ToString(),
                    pr_CreatedOn = DateTime.Parse(r["pr_CreatedOn"].ToString())
                };
                zixumodel.member = new Model.MemberBase
                {
                    m_UserName = r["m_UserName"].ToString()
                };
                prozixun.Add(zixumodel);
            }
            return prozixun;
        }
        #endregion  ExtensionMethod
    }
}

