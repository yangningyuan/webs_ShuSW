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
	/// 数据访问类:BrandBase
	/// </summary>
	public partial class BrandBase:IBrandBase
	{
		public BrandBase()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("b_ID", "BrandBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int b_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BrandBase");
			strSql.Append(" where b_ID=@b_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@b_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = b_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(webs_YueyxShop.Model.BrandBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BrandBase(");
			strSql.Append("b_Name,b_Key,b_LogoUrl,b_SiteUrl,b_Sort,b_CreatedOn,b_CreatedBy,b_StatusCode,b_IsDel)");
			strSql.Append(" values (");
			strSql.Append("@b_Name,@b_Key,@b_LogoUrl,@b_SiteUrl,@b_Sort,@b_CreatedOn,@b_CreatedBy,@b_StatusCode,@b_IsDel)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@b_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@b_Key", SqlDbType.VarChar,20),
					new SqlParameter("@b_LogoUrl", SqlDbType.VarChar,300),
					new SqlParameter("@b_SiteUrl", SqlDbType.VarChar,300),
					new SqlParameter("@b_Sort", SqlDbType.Int,4),
					new SqlParameter("@b_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@b_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@b_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@b_IsDel", SqlDbType.Bit,1)};
			parameters[0].Value = model.b_Name;
			parameters[1].Value = model.b_Key;
			parameters[2].Value = model.b_LogoUrl;
			parameters[3].Value = model.b_SiteUrl;
			parameters[4].Value = model.b_Sort;
			parameters[5].Value = model.b_CreatedOn;
            parameters[6].Value = model.b_CreatedBy;
			parameters[7].Value = model.b_StatusCode;
			parameters[8].Value = model.b_IsDel;

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
		public bool Update(webs_YueyxShop.Model.BrandBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BrandBase set ");
			strSql.Append("b_Name=@b_Name,");
			strSql.Append("b_Key=@b_Key,");
			strSql.Append("b_LogoUrl=@b_LogoUrl,");
			strSql.Append("b_SiteUrl=@b_SiteUrl,");
			strSql.Append("b_Sort=@b_Sort,");
			strSql.Append("b_CreatedOn=@b_CreatedOn,");
			strSql.Append("b_CreatedBy=@b_CreatedBy,");
			strSql.Append("b_StatusCode=@b_StatusCode,");
			strSql.Append("b_IsDel=@b_IsDel");
			strSql.Append(" where b_ID=@b_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@b_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@b_Key", SqlDbType.VarChar,20),
					new SqlParameter("@b_LogoUrl", SqlDbType.VarChar,300),
					new SqlParameter("@b_SiteUrl", SqlDbType.VarChar,300),
					new SqlParameter("@b_Sort", SqlDbType.Int,4),
					new SqlParameter("@b_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@b_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@b_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@b_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@b_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.b_Name;
			parameters[1].Value = model.b_Key;
			parameters[2].Value = model.b_LogoUrl;
			parameters[3].Value = model.b_SiteUrl;
			parameters[4].Value = model.b_Sort;
			parameters[5].Value = model.b_CreatedOn;
			parameters[6].Value = model.b_CreatedBy;
			parameters[7].Value = model.b_StatusCode;
			parameters[8].Value = model.b_IsDel;
			parameters[9].Value = model.b_ID;

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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int b_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BrandBase ");
			strSql.Append(" where b_ID=@b_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@b_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = b_ID;

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
		public bool DeleteList(string b_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BrandBase ");
			strSql.Append(" where b_ID in ("+b_IDlist + ")  ");
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
		public webs_YueyxShop.Model.BrandBase GetModel(int b_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 b_ID,b_Name,b_Key,b_LogoUrl,b_SiteUrl,b_Sort,b_CreatedOn,b_CreatedBy,b_StatusCode,b_IsDel from BrandBase ");
			strSql.Append(" where b_ID=@b_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@b_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = b_ID;

			webs_YueyxShop.Model.BrandBase model=new webs_YueyxShop.Model.BrandBase();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["b_ID"]!=null && ds.Tables[0].Rows[0]["b_ID"].ToString()!="")
				{
					model.b_ID=int.Parse(ds.Tables[0].Rows[0]["b_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["b_Name"]!=null && ds.Tables[0].Rows[0]["b_Name"].ToString()!="")
				{
					model.b_Name=ds.Tables[0].Rows[0]["b_Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["b_Key"]!=null && ds.Tables[0].Rows[0]["b_Key"].ToString()!="")
				{
					model.b_Key=ds.Tables[0].Rows[0]["b_Key"].ToString();
				}
				if(ds.Tables[0].Rows[0]["b_LogoUrl"]!=null && ds.Tables[0].Rows[0]["b_LogoUrl"].ToString()!="")
				{
					model.b_LogoUrl=ds.Tables[0].Rows[0]["b_LogoUrl"].ToString();
				}
				if(ds.Tables[0].Rows[0]["b_SiteUrl"]!=null && ds.Tables[0].Rows[0]["b_SiteUrl"].ToString()!="")
				{
					model.b_SiteUrl=ds.Tables[0].Rows[0]["b_SiteUrl"].ToString();
				}
				if(ds.Tables[0].Rows[0]["b_Sort"]!=null && ds.Tables[0].Rows[0]["b_Sort"].ToString()!="")
				{
					model.b_Sort=int.Parse(ds.Tables[0].Rows[0]["b_Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["b_CreatedOn"]!=null && ds.Tables[0].Rows[0]["b_CreatedOn"].ToString()!="")
				{
					model.b_CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["b_CreatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["b_CreatedBy"]!=null && ds.Tables[0].Rows[0]["b_CreatedBy"].ToString()!="")
				{
					model.b_CreatedBy= new Guid(ds.Tables[0].Rows[0]["b_CreatedBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["b_StatusCode"]!=null && ds.Tables[0].Rows[0]["b_StatusCode"].ToString()!="")
				{
					model.b_StatusCode=int.Parse(ds.Tables[0].Rows[0]["b_StatusCode"].ToString());
				}
				if(ds.Tables[0].Rows[0]["b_IsDel"]!=null && ds.Tables[0].Rows[0]["b_IsDel"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["b_IsDel"].ToString()=="1")||(ds.Tables[0].Rows[0]["b_IsDel"].ToString().ToLower()=="true"))
					{
						model.b_IsDel=true;
					}
					else
					{
						model.b_IsDel=false;
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
			strSql.Append("select b_ID,b_Name,b_Key,b_LogoUrl,b_SiteUrl,b_Sort,b_CreatedOn,b_CreatedBy,b_StatusCode,b_IsDel ");
			strSql.Append(" FROM BrandBase ");
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
			strSql.Append(" b_ID,b_Name,b_Key,b_LogoUrl,b_SiteUrl,b_Sort,b_CreatedOn,b_CreatedBy,b_StatusCode,b_IsDel ");
			strSql.Append(" FROM BrandBase ");
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
			strSql.Append("select count(1) FROM BrandBase ");
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
				strSql.Append("order by T.b_ID desc");
			}
			strSql.Append(")AS Row, T.*  from BrandBase T ");
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
			parameters[0].Value = "BrandBase";
			parameters[1].Value = "b_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
        //按商品类别获取该类别下所有的品牌（存储过程）
        public List<Model.BrandBase> GetbrandByTypeId(int cid)
        {
            List<Model.BrandBase> brandlist = new List<Model.BrandBase>();

            SqlParameter[] ps = new SqlParameter[]
            {
                new SqlParameter("@rptid",cid),
            };
            DataTable table = DbHelperSQL.GetTable("GetbrandByTypeId", ps);

            foreach (DataRow r in table.Rows)
            {
                Model.BrandBase b = new Model.BrandBase();
                b.b_Name = r["b_Name"].ToString();
                b.b_ID = (int)r["b_ID"];
                brandlist.Add(b);
            }
            return brandlist;
        }
	}
}

