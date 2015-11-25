/**  版本信息模板在安装目录下，可自行修改。
* ProductAppraiseBase.cs
*
* 功 能： N/A
* 类 名： ProductAppraiseBase
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
	/// 数据访问类:ProductAppraiseBase
	/// </summary>
	public partial class ProductAppraiseBase:IProductAppraiseBase
	{
		public ProductAppraiseBase()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("pa_ID", "ProductAppraiseBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int pa_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductAppraiseBase");
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
		public int Add(webs_YueyxShop.Model.ProductAppraiseBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductAppraiseBase(");
			strSql.Append("m_ID,sku_ID,pa_Satisfied,pa_Content,pa_PraiseCount,pa_CreatedOn,pa_CreatedBy,pa_StatusCode,pa_IsDel)");
			strSql.Append(" values (");
			strSql.Append("@m_ID,@sku_ID,@pa_Satisfied,@pa_Content,@pa_PraiseCount,@pa_CreatedOn,@pa_CreatedBy,@pa_StatusCode,@pa_IsDel)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ID", SqlDbType.Int,4),
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@pa_Satisfied", SqlDbType.Int,4),
					new SqlParameter("@pa_Content", SqlDbType.NVarChar,500),
					new SqlParameter("@pa_PraiseCount", SqlDbType.Int,4),
					new SqlParameter("@pa_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@pa_CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@pa_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@pa_IsDel", SqlDbType.Bit,1)};
			parameters[0].Value = model.m_ID;
			parameters[1].Value = model.sku_ID;
			parameters[2].Value = model.pa_Satisfied;
			parameters[3].Value = model.pa_Content;
			parameters[4].Value = model.pa_PraiseCount;
			parameters[5].Value = model.pa_CreatedOn;
            parameters[6].Value = model.pa_CreatedBy;
			parameters[7].Value = model.pa_StatusCode;
			parameters[8].Value = model.pa_IsDel;

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
		public bool Update(webs_YueyxShop.Model.ProductAppraiseBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductAppraiseBase set ");
			strSql.Append("m_ID=@m_ID,");
			strSql.Append("sku_ID=@sku_ID,");
			strSql.Append("pa_Satisfied=@pa_Satisfied,");
			strSql.Append("pa_Content=@pa_Content,");
			strSql.Append("pa_PraiseCount=@pa_PraiseCount,");
			strSql.Append("pa_CreatedOn=@pa_CreatedOn,");
			strSql.Append("pa_CreatedBy=@pa_CreatedBy,");
			strSql.Append("pa_StatusCode=@pa_StatusCode,");
			strSql.Append("pa_IsDel=@pa_IsDel");
			strSql.Append(" where pa_ID=@pa_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@m_ID", SqlDbType.Int,4),
					new SqlParameter("@sku_ID", SqlDbType.Int,4),
					new SqlParameter("@pa_Satisfied", SqlDbType.Int,4),
					new SqlParameter("@pa_Content", SqlDbType.NVarChar,500),
					new SqlParameter("@pa_PraiseCount", SqlDbType.Int,4),
					new SqlParameter("@pa_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@pa_CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@pa_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@pa_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@pa_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.m_ID;
			parameters[1].Value = model.sku_ID;
			parameters[2].Value = model.pa_Satisfied;
			parameters[3].Value = model.pa_Content;
			parameters[4].Value = model.pa_PraiseCount;
			parameters[5].Value = model.pa_CreatedOn;
			parameters[6].Value = model.pa_CreatedBy;
			parameters[7].Value = model.pa_StatusCode;
			parameters[8].Value = model.pa_IsDel;
			parameters[9].Value = model.pa_ID;

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
		public bool Delete(int pa_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductAppraiseBase ");
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
			strSql.Append("delete from ProductAppraiseBase ");
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
		public webs_YueyxShop.Model.ProductAppraiseBase GetModel(int pa_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 pa_ID,m_ID,sku_ID,pa_Satisfied,pa_Content,pa_PraiseCount,pa_CreatedOn,pa_CreatedBy,pa_StatusCode,pa_IsDel from ProductAppraiseBase ");
			strSql.Append(" where pa_ID=@pa_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@pa_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = pa_ID;

			webs_YueyxShop.Model.ProductAppraiseBase model=new webs_YueyxShop.Model.ProductAppraiseBase();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public webs_YueyxShop.Model.ProductAppraiseBase DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.ProductAppraiseBase model=new webs_YueyxShop.Model.ProductAppraiseBase();
			if (row != null)
			{
				if(row["pa_ID"]!=null && row["pa_ID"].ToString()!="")
				{
					model.pa_ID=int.Parse(row["pa_ID"].ToString());
				}
				if(row["m_ID"]!=null && row["m_ID"].ToString()!="")
				{
					model.m_ID=int.Parse(row["m_ID"].ToString());
				}
				if(row["sku_ID"]!=null && row["sku_ID"].ToString()!="")
				{
					model.sku_ID=int.Parse(row["sku_ID"].ToString());
				}
				if(row["pa_Satisfied"]!=null && row["pa_Satisfied"].ToString()!="")
				{
					model.pa_Satisfied=int.Parse(row["pa_Satisfied"].ToString());
				}
				if(row["pa_Content"]!=null)
				{
					model.pa_Content=row["pa_Content"].ToString();
				}
				if(row["pa_PraiseCount"]!=null && row["pa_PraiseCount"].ToString()!="")
				{
					model.pa_PraiseCount=int.Parse(row["pa_PraiseCount"].ToString());
				}
				if(row["pa_CreatedOn"]!=null && row["pa_CreatedOn"].ToString()!="")
				{
					model.pa_CreatedOn=DateTime.Parse(row["pa_CreatedOn"].ToString());
				}
				if(row["pa_CreatedBy"]!=null && row["pa_CreatedBy"].ToString()!="")
				{
                    model.pa_CreatedBy = int.Parse(row["pa_CreatedBy"].ToString());
				}
				if(row["pa_StatusCode"]!=null && row["pa_StatusCode"].ToString()!="")
				{
					model.pa_StatusCode=int.Parse(row["pa_StatusCode"].ToString());
				}
				if(row["pa_IsDel"]!=null && row["pa_IsDel"].ToString()!="")
				{
					if((row["pa_IsDel"].ToString()=="1")||(row["pa_IsDel"].ToString().ToLower()=="true"))
					{
						model.pa_IsDel=true;
					}
					else
					{
						model.pa_IsDel=false;
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select pa_ID,m_ID,sku_ID,pa_Satisfied,pa_Content,pa_PraiseCount,pa_CreatedOn,pa_CreatedBy,pa_StatusCode,pa_IsDel ");
			strSql.Append(" FROM ProductAppraiseBase ");
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
			strSql.Append(" pa_ID,m_ID,sku_ID,pa_Satisfied,pa_Content,pa_PraiseCount,pa_CreatedOn,pa_CreatedBy,pa_StatusCode,pa_IsDel ");
			strSql.Append(" FROM ProductAppraiseBase ");
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
			strSql.Append("select count(1) FROM ProductAppraiseBase ");
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
			strSql.Append(")AS Row, T.*  from ProductAppraiseBase T ");
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
			parameters[0].Value = "ProductAppraiseBase";
			parameters[1].Value = "pa_ID";
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
        /// 获得商品评论(通过SKUID)
        /// </summary>
        public List<Model.ProductAppraiseBase> GetModelListByskuId(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select pa.pa_ID,m.m_UserName,m.m_HeadImg,pa.pa_PraiseCount,pa.pa_CreatedOn,pa.pa_Content,pa_Satisfied,(select COUNT(m_Id) from MemberBase where m_ID  in(select m_id from ProductAppraiseBase)) midcount,(select AVG(pa_Satisfied) from ProductAppraiseBase) as pavg   from ProductAppraiseBase pa,MemberBase m where pa.m_ID=m.m_ID  and pa.pa_StatusCode=0 and pa.pa_IsDel=0  and ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<Model.ProductAppraiseBase> pinglun = new List<Model.ProductAppraiseBase>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                Model.ProductAppraiseBase p = new Model.ProductAppraiseBase();
                p.pa_ID =int.Parse( r["pa_ID"].ToString());
                p.pa_PraiseCount = int.Parse(r["pa_PraiseCount"].ToString());
                p.pa_Content = r["pa_Content"].ToString();
                p.pa_CreatedOn = DateTime.Parse(r["pa_CreatedOn"].ToString());
                p.pa_Satisfied = int.Parse(r["pa_Satisfied"].ToString());
                p.pavg = int.Parse(r["pavg"].ToString());
                p.member = new Model.MemberBase
                {
                    midcount=int.Parse(r["midcount"].ToString()),
                    m_UserName = r["m_UserName"].ToString(),
                    m_HeadImg = r["m_HeadImg"].ToString()
                };
                pinglun.Add(p);
            }
            return pinglun;
        }





		#endregion  ExtensionMethod
	}
}

