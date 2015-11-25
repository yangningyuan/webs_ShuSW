using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using webs_YueyxShop.IDAL;
using DBUtility;//Please add references
namespace webs_YueyxShop.DAL
{
    /// <summary>
    /// 数据访问类:ProductTypeBrandBase
    /// </summary>
    public partial class ProductTypeBrandBase : IProductTypeBrandBase
    {
        public ProductTypeBrandBase()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ptb_ID", "ProductTypeBrandBase");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ptb_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ProductTypeBrandBase");
            strSql.Append(" where ptb_ID=@ptb_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ptb_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ptb_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(webs_YueyxShop.Model.ProductTypeBrandBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProductTypeBrandBase(");
            strSql.Append("pt_ID,b_ID)");
            strSql.Append(" values (");
            strSql.Append("@pt_ID,@b_ID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@pt_ID", SqlDbType.Int,4),
					new SqlParameter("@b_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.pt_ID;
            parameters[1].Value = model.b_ID;

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
        public bool Update(webs_YueyxShop.Model.ProductTypeBrandBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductTypeBrandBase set ");
            strSql.Append("pt_ID=@pt_ID,");
            strSql.Append("b_ID=@b_ID");
            strSql.Append(" where ptb_ID=@ptb_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@pt_ID", SqlDbType.Int,4),
					new SqlParameter("@b_ID", SqlDbType.Int,4),
					new SqlParameter("@ptb_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.pt_ID;
            parameters[1].Value = model.b_ID;
            parameters[2].Value = model.ptb_ID;

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
        public bool Delete(int ptb_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductTypeBrandBase ");
            strSql.Append(" where ptb_ID=@ptb_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ptb_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ptb_ID;

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
        public bool DeleteList(string ptb_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductTypeBrandBase ");
            strSql.Append(" where ptb_ID in (" + ptb_IDlist + ")  ");
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
        /// 批量删除数据
        /// </summary>
        public bool Deletebybid(int b_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductTypeBrandBase ");
            strSql.Append(" where b_ID =" + b_ID);
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
        public webs_YueyxShop.Model.ProductTypeBrandBase GetModel(int ptb_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ptb_ID,pt_ID,b_ID from ProductTypeBrandBase ");
            strSql.Append(" where ptb_ID=@ptb_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ptb_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ptb_ID;

            webs_YueyxShop.Model.ProductTypeBrandBase model = new webs_YueyxShop.Model.ProductTypeBrandBase();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ptb_ID"] != null && ds.Tables[0].Rows[0]["ptb_ID"].ToString() != "")
                {
                    model.ptb_ID = int.Parse(ds.Tables[0].Rows[0]["ptb_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pt_ID"] != null && ds.Tables[0].Rows[0]["pt_ID"].ToString() != "")
                {
                    model.pt_ID = int.Parse(ds.Tables[0].Rows[0]["pt_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["b_ID"] != null && ds.Tables[0].Rows[0]["b_ID"].ToString() != "")
                {
                    model.b_ID = int.Parse(ds.Tables[0].Rows[0]["b_ID"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ptb_ID,pt_ID,b_ID ");
            strSql.Append(" FROM ProductTypeBrandBase ");
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
            strSql.Append(" ptb_ID,pt_ID,b_ID ");
            strSql.Append(" FROM ProductTypeBrandBase ");
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
            strSql.Append("select count(1) FROM ProductTypeBrandBase ");
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
                strSql.Append("order by T.ptb_ID desc");
            }
            strSql.Append(")AS Row, T.*  from ProductTypeBrandBase T ");
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
            parameters[0].Value = "ProductTypeBrandBase";
            parameters[1].Value = "ptb_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(int ptid, int bid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProductTypeBrandBase(");
            strSql.Append("pt_ID,b_ID)");
            strSql.Append(" values (");
            strSql.Append("@pt_ID,@b_ID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@pt_ID", SqlDbType.Int,4),
					new SqlParameter("@b_ID", SqlDbType.Int,4)};
            parameters[0].Value = ptid;
            parameters[1].Value = bid;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ptid, string bid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductTypeBrandBase");
            strSql.AppendFormat(" where pt_ID={0}", ptid);
            strSql.AppendFormat(" and b_ID={0}", bid);

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
        /// 删除品牌的分类
        /// </summary>
        public bool Deletes(string bid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductTypeBrandBase ");
            strSql.AppendFormat(" where b_ID={0}", bid);
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
    }
}

