using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBUtility;
using webs_YueyxShop.IDAL;
namespace webs_YueyxShop.DAL
{
    public class NewsBase:INewsBase
    {
        public NewsBase()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int n_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from NewsBase");
            strSql.Append(" where n_ID=@n_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@n_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = n_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.NewsBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into NewsBase(");
            strSql.Append("m_ID,n_Title,n_Synopsis,n_Content,n_PicUrl,n_RedirectUrl,n_QRCode,n_IsTop,n_Sort,n_Source,n_Writer,n_CreatedOn,n_CreatedBy,n_ModifyOn,n_StatusCode,n_IsDel)");
            strSql.Append(" values (");
            strSql.Append("@m_ID,@n_Title,@n_Synopsis,@n_Content,@n_PicUrl,@n_RedirectUrl,@n_QRCode,@n_IsTop,@n_Sort,@n_Source,@n_Writer,@n_CreatedOn,@n_CreatedBy,@n_ModifyOn,@n_StatusCode,@n_IsDel)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@n_Title", SqlDbType.NVarChar,100),
					new SqlParameter("@n_Synopsis", SqlDbType.NVarChar,500),
					new SqlParameter("@n_Content", SqlDbType.Text),
					new SqlParameter("@n_PicUrl", SqlDbType.VarChar,100),
					new SqlParameter("@n_RedirectUrl", SqlDbType.VarChar,100),
					new SqlParameter("@n_QRCode", SqlDbType.VarChar,100),
					new SqlParameter("@n_IsTop", SqlDbType.Bit,1),
					new SqlParameter("@n_Sort", SqlDbType.Int,4),
					new SqlParameter("@n_Source", SqlDbType.NVarChar,30),
					new SqlParameter("@n_Writer", SqlDbType.NVarChar,30),
					new SqlParameter("@n_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@n_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@n_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@n_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@n_IsDel", SqlDbType.Bit,1)};
            parameters[0].Value = model.m_ID;
            parameters[1].Value = model.n_Title;
            parameters[2].Value = model.n_Synopsis;
            parameters[3].Value = model.n_Content;
            parameters[4].Value = model.n_PicUrl;
            parameters[5].Value = model.n_RedirectUrl;
            parameters[6].Value = model.n_QRCode;
            parameters[7].Value = model.n_IsTop;
            parameters[8].Value = model.n_Sort;
            parameters[9].Value = model.n_Source;
            parameters[10].Value = model.n_Writer;
            parameters[11].Value = model.n_CreatedOn;
            parameters[12].Value = model.n_CreatedBy;
            parameters[13].Value = model.n_ModifyOn;
            parameters[14].Value = model.n_StatusCode;
            parameters[15].Value = model.n_IsDel;

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
        public bool Update(Model.NewsBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update NewsBase set ");
            strSql.Append("m_ID=@m_ID,");
            strSql.Append("n_Title=@n_Title,");
            strSql.Append("n_Synopsis=@n_Synopsis,");
            strSql.Append("n_Content=@n_Content,");
            strSql.Append("n_PicUrl=@n_PicUrl,");
            strSql.Append("n_RedirectUrl=@n_RedirectUrl,");
            strSql.Append("n_QRCode=@n_QRCode,");
            strSql.Append("n_IsTop=@n_IsTop,");
            strSql.Append("n_Sort=@n_Sort,");
            strSql.Append("n_Source=@n_Source,");
            strSql.Append("n_Writer=@n_Writer,");
            strSql.Append("n_CreatedOn=@n_CreatedOn,");
            strSql.Append("n_CreatedBy=@n_CreatedBy,");
            strSql.Append("n_ModifyOn=@n_ModifyOn,");
            strSql.Append("n_StatusCode=@n_StatusCode,");
            strSql.Append("n_IsDel=@n_IsDel");
            strSql.Append(" where n_ID=@n_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@n_Title", SqlDbType.NVarChar,100),
					new SqlParameter("@n_Synopsis", SqlDbType.NVarChar,500),
					new SqlParameter("@n_Content", SqlDbType.Text),
					new SqlParameter("@n_PicUrl", SqlDbType.VarChar,100),
					new SqlParameter("@n_RedirectUrl", SqlDbType.VarChar,100),
					new SqlParameter("@n_QRCode", SqlDbType.VarChar,100),
					new SqlParameter("@n_IsTop", SqlDbType.Bit,1),
					new SqlParameter("@n_Sort", SqlDbType.Int,4),
					new SqlParameter("@n_Source", SqlDbType.NVarChar,30),
					new SqlParameter("@n_Writer", SqlDbType.NVarChar,30),
					new SqlParameter("@n_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@n_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@n_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@n_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@n_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@n_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.m_ID;
            parameters[1].Value = model.n_Title;
            parameters[2].Value = model.n_Synopsis;
            parameters[3].Value = model.n_Content;
            parameters[4].Value = model.n_PicUrl;
            parameters[5].Value = model.n_RedirectUrl;
            parameters[6].Value = model.n_QRCode;
            parameters[7].Value = model.n_IsTop;
            parameters[8].Value = model.n_Sort;
            parameters[9].Value = model.n_Source;
            parameters[10].Value = model.n_Writer;
            parameters[11].Value = model.n_CreatedOn;
            parameters[12].Value = model.n_CreatedBy;
            parameters[13].Value = model.n_ModifyOn;
            parameters[14].Value = model.n_StatusCode;
            parameters[15].Value = model.n_IsDel;
            parameters[16].Value = model.n_ID;

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
        public bool Delete(int n_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from NewsBase ");
            strSql.Append(" where n_ID=@n_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@n_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = n_ID;

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
        public bool DeleteList(string n_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from NewsBase ");
            strSql.Append(" where n_ID in (" + n_IDlist + ")  ");
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
        public Model.NewsBase GetModel(int n_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 n_ID,m_ID,n_Title,n_Synopsis,n_Content,n_PicUrl,n_RedirectUrl,n_QRCode,n_IsTop,n_Sort,n_Source,n_Writer,n_CreatedOn,n_CreatedBy,n_ModifyOn,n_StatusCode,n_IsDel from NewsBase ");
            strSql.Append(" where n_ID=@n_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@n_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = n_ID;

            Model.NewsBase model = new Model.NewsBase();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["n_ID"] != null && ds.Tables[0].Rows[0]["n_ID"].ToString() != "")
                {
                    model.n_ID = int.Parse(ds.Tables[0].Rows[0]["n_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["m_ID"] != null && ds.Tables[0].Rows[0]["m_ID"].ToString() != "")
                {
                    model.m_ID = new Guid(ds.Tables[0].Rows[0]["m_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["n_Title"] != null && ds.Tables[0].Rows[0]["n_Title"].ToString() != "")
                {
                    model.n_Title = ds.Tables[0].Rows[0]["n_Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["n_Synopsis"] != null && ds.Tables[0].Rows[0]["n_Synopsis"].ToString() != "")
                {
                    model.n_Synopsis = ds.Tables[0].Rows[0]["n_Synopsis"].ToString();
                }
                if (ds.Tables[0].Rows[0]["n_Content"] != null && ds.Tables[0].Rows[0]["n_Content"].ToString() != "")
                {
                    model.n_Content = ds.Tables[0].Rows[0]["n_Content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["n_PicUrl"] != null && ds.Tables[0].Rows[0]["n_PicUrl"].ToString() != "")
                {
                    model.n_PicUrl = ds.Tables[0].Rows[0]["n_PicUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["n_RedirectUrl"] != null && ds.Tables[0].Rows[0]["n_RedirectUrl"].ToString() != "")
                {
                    model.n_RedirectUrl = ds.Tables[0].Rows[0]["n_RedirectUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["n_QRCode"] != null && ds.Tables[0].Rows[0]["n_QRCode"].ToString() != "")
                {
                    model.n_QRCode = ds.Tables[0].Rows[0]["n_QRCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["n_IsTop"] != null && ds.Tables[0].Rows[0]["n_IsTop"].ToString() != "")
                {
                    model.n_IsTop = Convert.ToBoolean(ds.Tables[0].Rows[0]["n_IsTop"].ToString());
                }
                if (ds.Tables[0].Rows[0]["n_Sort"] != null && ds.Tables[0].Rows[0]["n_Sort"].ToString() != "")
                {
                    model.n_Sort = int.Parse(ds.Tables[0].Rows[0]["n_Sort"].ToString());
                }
                if (ds.Tables[0].Rows[0]["n_Source"] != null && ds.Tables[0].Rows[0]["n_Source"].ToString() != "")
                {
                    model.n_Source = ds.Tables[0].Rows[0]["n_Source"].ToString();
                }
                if (ds.Tables[0].Rows[0]["n_Writer"] != null && ds.Tables[0].Rows[0]["n_Writer"].ToString() != "")
                {
                    model.n_Writer = ds.Tables[0].Rows[0]["n_Writer"].ToString();
                }
                if (ds.Tables[0].Rows[0]["n_CreatedOn"] != null && ds.Tables[0].Rows[0]["n_CreatedOn"].ToString() != "")
                {
                    model.n_CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["n_CreatedOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["n_StatusCode"] != null && ds.Tables[0].Rows[0]["n_StatusCode"].ToString() != "")
                {
                    model.n_StatusCode = int.Parse(ds.Tables[0].Rows[0]["n_StatusCode"].ToString());
                }
                if (ds.Tables[0].Rows[0]["n_IsDel"] != null && ds.Tables[0].Rows[0]["n_IsDel"].ToString() != "")
                {
                    model.n_IsDel = Convert.ToBoolean(ds.Tables[0].Rows[0]["n_IsDel"].ToString());
                }
                return model;
            }
            else
            {
                return new Model.NewsBase();
            }
        }




        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select n_ID,m_ID,n_Title,n_Synopsis,n_Content,n_PicUrl,n_RedirectUrl,n_QRCode,n_IsTop,n_Sort,n_Source,n_Writer,n_CreatedOn,n_CreatedBy,n_ModifyOn,n_StatusCode,n_IsDel ");
            strSql.Append(" FROM NewsBase ");
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
            strSql.Append(" n_ID,m_ID,n_Title,n_Synopsis,n_Content,n_PicUrl,n_RedirectUrl,n_QRCode,n_IsTop,n_Sort,n_Source,n_Writer,n_CreatedOn,n_CreatedBy,n_ModifyOn,n_StatusCode,n_IsDel ");
            strSql.Append(" FROM NewsBase ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
        #endregion