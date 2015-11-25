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
	/// 数据访问类:ProductAttributesBase
	/// </summary>
	public partial class ProductAttributesBase:IProductAttributesBase
	{
		public ProductAttributesBase()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("pa_ID", "ProductAttributesBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int pa_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductAttributesBase");
			strSql.Append(" where pa_ID=@pa_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@pa_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = pa_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(webs_YueyxShop.Model.ProductAttributesBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductAttributesBase(");
			strSql.Append("pa_Name,pa_Alias,pa_Type,pa_Layer,pa_Code,pa_Sort,pa_SelectType,pa_StatusCode,pa_CreatedOn,pa_CreatedBy,pa_IsDel,pa_ParentID,pt_Id)");
			strSql.Append(" values (");
            strSql.Append("@pa_Name,@pa_Alias,@pa_Type,@pa_Layer,@pa_Code,@pa_Sort,@pa_SelectType,@pa_StatusCode,@pa_CreatedOn,@pa_CreatedBy,@pa_IsDel,@pa_ParentId,@pt_Id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@pa_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@pa_Alias", SqlDbType.NVarChar,20),
					new SqlParameter("@pa_Type", SqlDbType.SmallInt,2),
					new SqlParameter("@pa_Layer", SqlDbType.Int,4),
					new SqlParameter("@pa_Code", SqlDbType.VarChar,30),
					new SqlParameter("@pa_Sort", SqlDbType.Int,4),
					new SqlParameter("@pa_SelectType", SqlDbType.Int,4),
					new SqlParameter("@pa_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@pa_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@pa_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@pa_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@pa_ParentId", SqlDbType.Int,4),
					new SqlParameter("@pt_Id", SqlDbType.Int,4)};
			parameters[0].Value = model.pa_Name;
			parameters[1].Value = model.pa_Alias;
			parameters[2].Value = model.pa_Type;
			parameters[3].Value = model.pa_Layer;
			parameters[4].Value = model.pa_Code;
			parameters[5].Value = model.pa_Sort;
			parameters[6].Value = model.pa_SelectType;
			parameters[7].Value = model.pa_StatusCode;
			parameters[8].Value = model.pa_CreatedOn;
			parameters[9].Value = Guid.NewGuid();
            parameters[10].Value = model.pa_IsDel;
            parameters[11].Value = model.pa_ParentId;
            parameters[12].Value = model.pt_Id;

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
		public bool Update(webs_YueyxShop.Model.ProductAttributesBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductAttributesBase set ");
			strSql.Append("pa_Name=@pa_Name,");
			strSql.Append("pa_Alias=@pa_Alias,");
			strSql.Append("pa_Type=@pa_Type,");
			strSql.Append("pa_Layer=@pa_Layer,");
			strSql.Append("pa_Code=@pa_Code,");
			strSql.Append("pa_Sort=@pa_Sort,");
			strSql.Append("pa_SelectType=@pa_SelectType,");
			strSql.Append("pa_StatusCode=@pa_StatusCode,");
			strSql.Append("pa_CreatedOn=@pa_CreatedOn,");
			strSql.Append("pa_CreatedBy=@pa_CreatedBy,");
            strSql.Append("pa_IsDel=@pa_IsDel,");
            strSql.Append("pa_ParentId=@pa_ParentId,");
            strSql.Append("pt_Id=@pt_Id");
			strSql.Append(" where pa_ID=@pa_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@pa_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@pa_Alias", SqlDbType.NVarChar,20),
					new SqlParameter("@pa_Type", SqlDbType.SmallInt,2),
					new SqlParameter("@pa_Layer", SqlDbType.Int,4),
					new SqlParameter("@pa_Code", SqlDbType.VarChar,30),
					new SqlParameter("@pa_Sort", SqlDbType.Int,4),
					new SqlParameter("@pa_SelectType", SqlDbType.Int,4),
					new SqlParameter("@pa_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@pa_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@pa_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@pa_IsDel", SqlDbType.Bit,1),
                     new SqlParameter("@pa_ParentId", SqlDbType.Int,4) ,
                     new SqlParameter("@pt_Id", SqlDbType.Int,4) ,
					new SqlParameter("@pa_ID", SqlDbType.Int,4) };
			parameters[0].Value = model.pa_Name;
			parameters[1].Value = model.pa_Alias;
			parameters[2].Value = model.pa_Type;
			parameters[3].Value = model.pa_Layer;
			parameters[4].Value = model.pa_Code;
			parameters[5].Value = model.pa_Sort;
			parameters[6].Value = model.pa_SelectType;
			parameters[7].Value = model.pa_StatusCode;
			parameters[8].Value = model.pa_CreatedOn;
			parameters[9].Value = model.pa_CreatedBy;
			parameters[10].Value = model.pa_IsDel;
            parameters[11].Value = model.pa_ParentId;
            parameters[12].Value = model.pt_Id;
            parameters[13].Value = model.pa_ID; 

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
        /// 更新一组数据
        /// </summary>
        public bool UpdateList(webs_YueyxShop.Model.ProductAttributesBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductAttributesBase set ");
            strSql.Append("pa_Name=@pa_Name,");
            strSql.Append("pa_Alias=@pa_Alias,");
            strSql.Append("pa_Type=@pa_Type,");
            strSql.Append("pa_Layer=@pa_Layer,");
            strSql.Append("pa_Code=@pa_Code,");
            strSql.Append("pa_Sort=@pa_Sort,");
            strSql.Append("pa_SelectType=@pa_SelectType,");
            strSql.Append("pa_StatusCode=@pa_StatusCode,");
            strSql.Append("pa_CreatedOn=@pa_CreatedOn,");
            strSql.Append("pa_CreatedBy=@pa_CreatedBy,");
            strSql.Append("pa_IsDel=@pa_IsDel,");
            strSql.Append("pa_ParentId=@pa_ParentId,");
            strSql.Append("pt_Id=@pt_Id");
            strSql.Append(" where pa_ID=@pa_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@pa_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@pa_Alias", SqlDbType.NVarChar,20),
					new SqlParameter("@pa_Type", SqlDbType.SmallInt,2),
					new SqlParameter("@pa_Layer", SqlDbType.Int,4),
					new SqlParameter("@pa_Code", SqlDbType.VarChar,30),
					new SqlParameter("@pa_Sort", SqlDbType.Int,4),
					new SqlParameter("@pa_SelectType", SqlDbType.Int,4),
					new SqlParameter("@pa_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@pa_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@pa_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@pa_IsDel", SqlDbType.Bit,1),
                     new SqlParameter("@pa_ParentId", SqlDbType.Int,4) ,
                     new SqlParameter("@pt_Id", SqlDbType.Int,4) ,
					new SqlParameter("@pa_ID", SqlDbType.Int,4) };
            parameters[0].Value = model.pa_Name;
            parameters[1].Value = model.pa_Alias;
            parameters[2].Value = model.pa_Type;
            parameters[3].Value = model.pa_Layer;
            parameters[4].Value = model.pa_Code;
            parameters[5].Value = model.pa_Sort;
            parameters[6].Value = model.pa_SelectType;
            parameters[7].Value = model.pa_StatusCode;
            parameters[8].Value = model.pa_CreatedOn;
            parameters[9].Value = model.pa_CreatedBy;
            parameters[10].Value = model.pa_IsDel;
            parameters[11].Value = model.pa_ParentId;
            parameters[12].Value = model.pt_Id;
            parameters[13].Value = model.pa_ID;

            StringBuilder strcSql = new StringBuilder();
            strcSql.Append("select count(1) from ProductAttributesBase");
            strcSql.Append(" where pa_parentId=@pa_ID ");
            SqlParameter[] cparameters = {
					new SqlParameter("@pa_ID", SqlDbType.Int,4)
			};
            cparameters[0].Value = model.pa_ID;
            bool cExists = DbHelperSQL.Exists(strcSql.ToString(), cparameters);

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append(" update ProductAttributesBase set ");
            strSql2.Append("pa_type=@pa_type where pa_parentId=@pa_parentId");
            SqlParameter[] parameters1 = { 
				new SqlParameter("@pa_Type", SqlDbType.SmallInt,2),
				new SqlParameter("@pa_parentId", SqlDbType.Int,4) };
            parameters1[0].Value = model.pa_Type;
            parameters1[1].Value = model.pa_ID;
            
            int rows = 0;
            int rows1 = 0;
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    cmd.Transaction = trans;
                    try
                    {

                        rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                        if (cExists)
                        {
                            rows1 = DbHelperSQL.ExecuteSql(strSql2.ToString(), parameters1);
                        }
                        else
                        {
                            rows1 = 1;
                        }
                    }
                    catch (SqlException ex)
                    {
                        trans.Rollback();
                        ///throw new Exception("failed", ex);
                    }
                    finally
                    {
                        if (conn.State != ConnectionState.Closed)
                        {
                            conn.Close();
                        }
                    }
                }
            }
            if (rows > 0 && rows1 > 0)
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
		public bool Delete(int pa_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductAttributesBase ");
			strSql.Append(" where pa_ID=@pa_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@pa_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = pa_ID;

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
		public bool DeleteList(string pa_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductAttributesBase ");
			strSql.Append(" where pa_ID in ("+pa_IDlist + ")  ");
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
		public webs_YueyxShop.Model.ProductAttributesBase GetModel(int pa_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 pa_ID,pa_Name,pa_Alias,pa_Type,pa_Layer,pa_Code,pa_Sort,pa_SelectType,pa_StatusCode,pa_CreatedOn,pa_CreatedBy,pa_IsDel,pa_parentId,pt_Id from ProductAttributesBase ");
			strSql.Append(" where pa_ID=@pa_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@pa_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = pa_ID;

			webs_YueyxShop.Model.ProductAttributesBase model=new webs_YueyxShop.Model.ProductAttributesBase();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["pa_ID"]!=null && ds.Tables[0].Rows[0]["pa_ID"].ToString()!="")
				{
					model.pa_ID=int.Parse(ds.Tables[0].Rows[0]["pa_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pa_Name"]!=null && ds.Tables[0].Rows[0]["pa_Name"].ToString()!="")
				{
					model.pa_Name=ds.Tables[0].Rows[0]["pa_Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pa_Alias"]!=null && ds.Tables[0].Rows[0]["pa_Alias"].ToString()!="")
				{
					model.pa_Alias=ds.Tables[0].Rows[0]["pa_Alias"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pa_Type"]!=null && ds.Tables[0].Rows[0]["pa_Type"].ToString()!="")
				{
					model.pa_Type=int.Parse(ds.Tables[0].Rows[0]["pa_Type"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pa_Layer"]!=null && ds.Tables[0].Rows[0]["pa_Layer"].ToString()!="")
				{
					model.pa_Layer=int.Parse(ds.Tables[0].Rows[0]["pa_Layer"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pa_Code"]!=null && ds.Tables[0].Rows[0]["pa_Code"].ToString()!="")
				{
					model.pa_Code=ds.Tables[0].Rows[0]["pa_Code"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pa_Sort"]!=null && ds.Tables[0].Rows[0]["pa_Sort"].ToString()!="")
				{
					model.pa_Sort=int.Parse(ds.Tables[0].Rows[0]["pa_Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pa_SelectType"]!=null && ds.Tables[0].Rows[0]["pa_SelectType"].ToString()!="")
				{
					model.pa_SelectType=int.Parse(ds.Tables[0].Rows[0]["pa_SelectType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pa_StatusCode"]!=null && ds.Tables[0].Rows[0]["pa_StatusCode"].ToString()!="")
				{
					model.pa_StatusCode=int.Parse(ds.Tables[0].Rows[0]["pa_StatusCode"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pa_CreatedOn"]!=null && ds.Tables[0].Rows[0]["pa_CreatedOn"].ToString()!="")
				{
					model.pa_CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["pa_CreatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pa_CreatedBy"]!=null && ds.Tables[0].Rows[0]["pa_CreatedBy"].ToString()!="")
				{
					model.pa_CreatedBy= new Guid(ds.Tables[0].Rows[0]["pa_CreatedBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pa_IsDel"]!=null && ds.Tables[0].Rows[0]["pa_IsDel"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["pa_IsDel"].ToString()=="1")||(ds.Tables[0].Rows[0]["pa_IsDel"].ToString().ToLower()=="true"))
					{
						model.pa_IsDel=true;
					}
					else
					{
						model.pa_IsDel=false;
					}
				}
                if (ds.Tables[0].Rows[0]["pa_ParentId"] != null && ds.Tables[0].Rows[0]["pa_ParentId"].ToString() != "")
                {
                    model.pa_ParentId = int.Parse(ds.Tables[0].Rows[0]["pa_ParentId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pt_Id"] != null && ds.Tables[0].Rows[0]["pt_Id"].ToString() != "")
                {
                    model.pt_Id = int.Parse(ds.Tables[0].Rows[0]["pt_Id"].ToString());
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
			strSql.Append("select pa_ID,pa_Name,pa_Alias,pa_Type,pa_Layer,pa_Code,pa_Sort,pa_SelectType,pa_StatusCode,pa_CreatedOn,pa_CreatedBy,pa_IsDel,pa_parentId,pt_Id ");
			strSql.Append(" FROM ProductAttributesBase ");
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
            strSql.Append(" pa_ID,pa_Name,pa_Alias,pa_Type,pa_Layer,pa_Code,pa_Sort,pa_SelectType,pa_StatusCode,pa_CreatedOn,pa_CreatedBy,pa_IsDel,pa_parentId,pt_Id ");
			strSql.Append(" FROM ProductAttributesBase ");
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
			strSql.Append("select count(1) FROM ProductAttributesBase ");
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
				strSql.Append("order by T.pa_ID desc");
			}
			strSql.Append(")AS Row, T.*  from ProductAttributesBase T ");
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
			parameters[0].Value = "ProductAttributesBase";
			parameters[1].Value = "pa_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method

        #region
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
                str.AppendFormat("select  Max(pa_Sort) pa_sort from ProductAttributesBase where pa_Layer=1 and pa_IsDel=0 and pa_ParentId=0 ");
                DataTable dt = DbHelperSQL.Query(str.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["pa_sort"].ToString()))
                    {
                        int Number = Convert.ToInt32(dt.Rows[0]["pa_sort"].ToString()) + 1; 
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
                    pt_parentid = int.Parse(dt1.Rows[0]["pt_ID"].ToString());
                }
                str.AppendFormat("select Max(pa_Code) pa_Code  from ProductAttributesBase where pa_Code like'{0}%' and pa_Layer={1} and pa_IsDel=0 ", m_BianM, m_CengJ + 1, pt_parentid);
                DataTable dt = DbHelperSQL.Query(str.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["pa_Code"].ToString()))
                    {
                        int Number = Convert.ToInt32(dt.Rows[0]["pa_Code"].ToString().Substring(m_BianM.Length, 3)) + 1;
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
                str.Append("select Max(pa_Sort) pa_Sort from ProductAttributesBase where pa_parentid=0 and pa_layer=1 and pa_IsDel=0 ");
                DataTable dt = DbHelperSQL.Query(str.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["pa_Sort"].ToString()))
                    {
                        Number = Convert.ToInt32(dt.Rows[0]["pa_Sort"].ToString()) + 1;
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

                str.AppendFormat("select Max(pa_Sort) pa_Sort from ProductAttributesBase where pa_parentid={0} and pa_layer={1} and pa_IsDel=0 ", pid, layer + 1);
                DataTable dt = DbHelperSQL.Query(str.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["pa_Sort"].ToString()))
                    {
                        Number = Convert.ToInt32(dt.Rows[0]["pa_Sort"].ToString()) + 1;
                    }
                    else
                    {
                        Number = 1;
                    }
                }
                return Number;
            }
        }



        /// <summary>
        /// 获得数据列表(包含类名)
        /// </summary>
        public DataSet GetListwithtype(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pa.pa_ID,pa.pa_Name,pa.pa_Alias,pa.pa_Type,pa.pa_Layer,pa.pa_Code,pa.pa_Sort,pa.pa_SelectType,pa.pa_StatusCode,pa.pa_CreatedOn,pa.pa_CreatedBy,pa.pa_IsDel,pa.pa_parentId,pa.pt_Id,pt.pt_Name ");
            strSql.Append(" FROM ProductAttributesBase pa,ProductTypeBase pt");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表(通过SKUID和PID)
        /// </summary>
        public DataSet GetModelListById(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pad.pad_Id,s.p_ID,s.sku_ID,s.sku_Code,pa.pa_ID,pa2.pa_Name as n,pa.pa_Name as nv,pa.pa_Type,pa.pa_StatusCode ");
            strSql.Append(" from ProductAttributesBase pa,ProductAttributesBase pa2,ProductAttributeDetails pad,SKUBase s,ProductBase p  where s.p_ID = p.p_ID  and pad.pa_ID=pa.pa_ID and pad.sku_ID=s.sku_ID and pad.pa_ID=pa.pa_ID   and  pa.pa_parentId=pa2.pa_ID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表(通过SKUID和PID)
        /// </summary>
        public List<Model.ProductAttributesBase> GetModelListByskuId(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pa1.pa_Name n,pa2.pa_Name from ProductAttributesBase pa1,ProductAttributesBase pa2,ProductAttributeDetails pad where pa1.pa_ID=pa2.pa_parentId and pa2.pa_ID = pad.pa_ID and pa1.pa_StatusCode=0 and pa1.pa_IsDel=0 and ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
           DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<Model.ProductAttributesBase> proattr = new List<Model.ProductAttributesBase>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                Model.ProductAttributesBase attrmodel = new Model.ProductAttributesBase();
                attrmodel.pa_Name = r["pa_Name"].ToString();
                attrmodel.pa_Alias = r["n"].ToString();
                proattr.Add(attrmodel);
            }
            return proattr;
        }
        /// <summary>
        /// 获得数据列表(通过SKUID)
        /// </summary>
        public List<Model.ProductAttributesBase> GetModelListByPid(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ProductAttributesBase pa,SKUBase sku,ProductAttributeDetails pad where  pa.pa_ID=pad.pa_ID and sku.sku_ID=pad.sku_ID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<Model.ProductAttributesBase> proattr = new List<Model.ProductAttributesBase>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                Model.ProductAttributesBase attrmodel = new Model.ProductAttributesBase();
                attrmodel.pa_Name = r["pa_Name"].ToString();
                attrmodel.pa_ID = int.Parse(r["pa_ID"].ToString());
                attrmodel.sku = new Model.SKUBase
                {
                    sku_ID = int.Parse(r["sku_ID"].ToString()),
                };
                proattr.Add(attrmodel);
            }
            return proattr;
        }


        public bool UpdateList2(int status, int paid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductAttributesBase set ");
            strSql.Append("pa_StatusCode=@pa_StatusCode");
            strSql.Append(" where pa_ID=@pa_ID");
            strSql.Append(" or pa_parentId=@pa_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@pa_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@pa_ID", SqlDbType.Int,4)};
            parameters[0].Value = status;
            parameters[1].Value = paid;

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
        #endregion
    }
}

