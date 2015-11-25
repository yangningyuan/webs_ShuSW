using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using webs_YueyxShop.IDAL;
using DBUtility;//Please add references
namespace webs_YueyxShop.DAL
{
	/// <summary>
	/// 数据访问类:ProductTypeBase
	/// </summary>
	public partial class ProductTypeBase:IProductTypeBase
	{
		public ProductTypeBase()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("pt_ID", "ProductTypeBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int pt_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductTypeBase");
			strSql.Append(" where pt_ID=@pt_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@pt_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = pt_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(webs_YueyxShop.Model.ProductTypeBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductTypeBase(");
			strSql.Append("pt_Name,pt_Code,pt_Layer,pt_Sort,pt_ParentId,pt_Content,pt_ImgUrl,pt_StatusCode,pt_CreatedBy,pt_CreatedOn,pt_IsDel)");
			strSql.Append(" values (");
			strSql.Append("@pt_Name,@pt_Code,@pt_Layer,@pt_Sort,@pt_ParentId,@pt_Content,@pt_ImgUrl,@pt_StatusCode,@pt_CreatedBy,@pt_CreatedOn,@pt_IsDel)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@pt_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@pt_Code", SqlDbType.VarChar,30),
					new SqlParameter("@pt_Layer", SqlDbType.Int,4),
					new SqlParameter("@pt_Sort", SqlDbType.Int,4),
					new SqlParameter("@pt_ParentId", SqlDbType.Int,4),
					new SqlParameter("@pt_Content", SqlDbType.Text),
					new SqlParameter("@pt_ImgUrl", SqlDbType.VarChar,200),
					new SqlParameter("@pt_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@pt_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@pt_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@pt_IsDel", SqlDbType.Bit,1)};
			parameters[0].Value = model.pt_Name;
			parameters[1].Value = model.pt_Code;
			parameters[2].Value = model.pt_Layer;
			parameters[3].Value = model.pt_Sort;
			parameters[4].Value = model.pt_ParentId;
			parameters[5].Value = model.pt_Content;
			parameters[6].Value = model.pt_ImgUrl;
			parameters[7].Value = model.pt_StatusCode;
			parameters[8].Value = Guid.NewGuid();
			parameters[9].Value = model.pt_CreatedOn;
			parameters[10].Value = model.pt_IsDel;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(webs_YueyxShop.Model.ProductTypeBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductTypeBase set ");
			strSql.Append("pt_Name=@pt_Name,");
			strSql.Append("pt_Code=@pt_Code,");
			strSql.Append("pt_Layer=@pt_Layer,");
			strSql.Append("pt_Sort=@pt_Sort,");
			strSql.Append("pt_ParentId=@pt_ParentId,");
			strSql.Append("pt_Content=@pt_Content,");
			strSql.Append("pt_ImgUrl=@pt_ImgUrl,");
			strSql.Append("pt_StatusCode=@pt_StatusCode,");
			strSql.Append("pt_CreatedBy=@pt_CreatedBy,");
			strSql.Append("pt_CreatedOn=@pt_CreatedOn,");
			strSql.Append("pt_IsDel=@pt_IsDel");
			strSql.Append(" where pt_ID=@pt_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@pt_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@pt_Code", SqlDbType.VarChar,30),
					new SqlParameter("@pt_Layer", SqlDbType.Int,4),
					new SqlParameter("@pt_Sort", SqlDbType.Int,4),
					new SqlParameter("@pt_ParentId", SqlDbType.Int,4),
					new SqlParameter("@pt_Content", SqlDbType.Text),
					new SqlParameter("@pt_ImgUrl", SqlDbType.VarChar,200),
					new SqlParameter("@pt_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@pt_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@pt_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@pt_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@pt_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.pt_Name;
			parameters[1].Value = model.pt_Code;
			parameters[2].Value = model.pt_Layer;
			parameters[3].Value = model.pt_Sort;
			parameters[4].Value = model.pt_ParentId;
			parameters[5].Value = model.pt_Content;
			parameters[6].Value = model.pt_ImgUrl;
			parameters[7].Value = model.pt_StatusCode;
			parameters[8].Value = model.pt_CreatedBy;
			parameters[9].Value = model.pt_CreatedOn;
			parameters[10].Value = model.pt_IsDel;
			parameters[11].Value = model.pt_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


        /// 更新一条数据
        /// </summary>
        public bool UpdateList(int code,int ptid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductTypeBase set ");
            strSql.Append("pt_StatusCode=@pt_StatusCode ");
            strSql.Append(" where pt_ID=@pt_ID");
            strSql.Append(" or pt_ParentId=@pt_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@pt_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@pt_ID", SqlDbType.Int,4)};
            parameters[0].Value = code;
            parameters[1].Value = ptid;

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
		public bool Delete(int pt_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductTypeBase set pt_IsDel=1");
			strSql.Append(" where pt_ID=@pt_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@pt_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = pt_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string pt_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductTypeBase ");
			strSql.Append(" where pt_ID in ("+pt_IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public webs_YueyxShop.Model.ProductTypeBase GetModel(int pt_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 pt_ID,pt_Name,pt_Code,pt_Layer,pt_Sort,pt_ParentId,pt_Content,pt_ImgUrl,pt_StatusCode,pt_CreatedBy,pt_CreatedOn,pt_IsDel from ProductTypeBase ");
			strSql.Append(" where pt_ID=@pt_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@pt_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = pt_ID;

			webs_YueyxShop.Model.ProductTypeBase model=new webs_YueyxShop.Model.ProductTypeBase();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["pt_ID"]!=null && ds.Tables[0].Rows[0]["pt_ID"].ToString()!="")
				{
					model.pt_ID=int.Parse(ds.Tables[0].Rows[0]["pt_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pt_Name"]!=null && ds.Tables[0].Rows[0]["pt_Name"].ToString()!="")
				{
					model.pt_Name=ds.Tables[0].Rows[0]["pt_Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pt_Code"]!=null && ds.Tables[0].Rows[0]["pt_Code"].ToString()!="")
				{
					model.pt_Code=ds.Tables[0].Rows[0]["pt_Code"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pt_Layer"]!=null && ds.Tables[0].Rows[0]["pt_Layer"].ToString()!="")
				{
					model.pt_Layer=int.Parse(ds.Tables[0].Rows[0]["pt_Layer"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pt_Sort"]!=null && ds.Tables[0].Rows[0]["pt_Sort"].ToString()!="")
				{
					model.pt_Sort=int.Parse(ds.Tables[0].Rows[0]["pt_Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pt_ParentId"]!=null && ds.Tables[0].Rows[0]["pt_ParentId"].ToString()!="")
				{
					model.pt_ParentId=int.Parse(ds.Tables[0].Rows[0]["pt_ParentId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pt_Content"]!=null && ds.Tables[0].Rows[0]["pt_Content"].ToString()!="")
				{
					model.pt_Content=ds.Tables[0].Rows[0]["pt_Content"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pt_ImgUrl"]!=null && ds.Tables[0].Rows[0]["pt_ImgUrl"].ToString()!="")
				{
					model.pt_ImgUrl=ds.Tables[0].Rows[0]["pt_ImgUrl"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pt_StatusCode"]!=null && ds.Tables[0].Rows[0]["pt_StatusCode"].ToString()!="")
				{
					model.pt_StatusCode=int.Parse(ds.Tables[0].Rows[0]["pt_StatusCode"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pt_CreatedBy"]!=null && ds.Tables[0].Rows[0]["pt_CreatedBy"].ToString()!="")
				{
					model.pt_CreatedBy= new Guid(ds.Tables[0].Rows[0]["pt_CreatedBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pt_CreatedOn"]!=null && ds.Tables[0].Rows[0]["pt_CreatedOn"].ToString()!="")
				{
					model.pt_CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["pt_CreatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pt_IsDel"]!=null && ds.Tables[0].Rows[0]["pt_IsDel"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["pt_IsDel"].ToString()=="1")||(ds.Tables[0].Rows[0]["pt_IsDel"].ToString().ToLower()=="true"))
					{
						model.pt_IsDel=true;
					}
					else
					{
						model.pt_IsDel=false;
					}
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select pt_ID,pt_Name,pt_Code,pt_Layer,pt_Sort,pt_ParentId,pt_Content,pt_ImgUrl,pt_StatusCode,pt_CreatedBy,pt_CreatedOn,pt_IsDel ");
			strSql.Append(" FROM ProductTypeBase ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" pt_ID,pt_Name,pt_Code,pt_Layer,pt_Sort,pt_ParentId,pt_Content,pt_ImgUrl,pt_StatusCode,pt_CreatedBy,pt_CreatedOn,pt_IsDel ");
			strSql.Append(" FROM ProductTypeBase ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ProductTypeBase ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.pt_ID desc");
			}
			strSql.Append(")AS Row, T.*  from ProductTypeBase T ");
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
			parameters[0].Value = "ProductTypeBase";
			parameters[1].Value = "pt_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method

        /// <summary>
        /// 获取菜单编码 2014/10/23 glz
        /// </summary>
        /// <param name="m_BianM">父级编码</param>
        /// <param name="m_CengJ">当前层级</param>
        public string GetCode(string m_BianM, int m_CengJ)
        {
            StringBuilder str = new StringBuilder();
            StringBuilder str1 = new StringBuilder();
            string ReturnCode = "", Number0 = "";
            if (m_BianM == "")
            {//第一级
                str.AppendFormat("select  Max(pt_Sort) pt_sort from ProductTypeBase where pt_Layer=1  and pt_Isdel=0 and pt_statusCode=0 and pt_ParentId=0 ");
                DataTable dt = DbHelperSQL.Query(str.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["pt_sort"].ToString()))
                    {
                        int Number = Convert.ToInt32(dt.Rows[0]["pt_sort"].ToString()) + 1;
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
                            ReturnCode = Number.ToString();
                        }
                    }
                else
                    ReturnCode = "001";
                }
            }
            else
            { //子级
                str1.AppendFormat("select * from ProductTypeBase where pt_code='{0}'", m_BianM);
                DataTable dt1 = DbHelperSQL.Query(str1.ToString()).Tables[0]; 
                int pt_parentid = 0;
                if (dt1.Rows.Count > 0)
                {
                   pt_parentid =int.Parse(dt1.Rows[0]["pt_ID"].ToString());
                }
                str.AppendFormat("select Max(pt_Code) pt_Code  from ProductTypeBase where pt_Code like'{0}%' and pt_Layer={1}  and pt_Isdel=0 and pt_statusCode=0 and pt_ParentId={2} ", m_BianM, m_CengJ + 1, pt_parentid);
                DataTable dt = DbHelperSQL.Query(str.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["pt_Code"].ToString()))
                    {
                        int Number = Convert.ToInt32(dt.Rows[0]["pt_Code"].ToString().Substring(m_BianM.Length, 3)) + 1;
                        for (int i = 0; i < 3 - Number.ToString().Length; i++)
                        {
                            Number0 += "0";
                        }
                        ReturnCode = m_BianM + Number0 + Number.ToString();
                    }
                else
                    ReturnCode = m_BianM + "001";
                }
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
            if (pid == "0")
            {
                str.Append("select Max(pt_Sort) pt_Sort from ProductTypeBase where pt_parentid=0 and pt_layer=1  and pt_Isdel=0 and pt_statusCode=0 ");
                DataTable dt = DbHelperSQL.Query(str.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["pt_Sort"].ToString()))
                    {
                        Number = Convert.ToInt32(dt.Rows[0]["pt_Sort"].ToString()) + 1;
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

                str.AppendFormat("select Max(pt_Sort) pt_Sort from ProductTypeBase where pt_parentid={0} and pt_layer={1}  and pt_Isdel=0 and pt_statusCode=0 ", pid, layer + 1);
                DataTable dt = DbHelperSQL.Query(str.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["pt_Sort"].ToString()))
                    {
                        Number = Convert.ToInt32(dt.Rows[0]["pt_Sort"].ToString()) + 1;
                    }
                    else
                    {
                        Number = 1;
                    }
                }
                return Number;
            }
        }
	}
}

