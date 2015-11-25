/**  版本信息模板在安装目录下，可自行修改。
* ProductRecommendDetail.cs
*
* 功 能： N/A
* 类 名： ProductRecommendDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/14 10:16:49   N/A    初版
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
	/// 数据访问类:ProductRecommendDetail
	/// </summary>
	public partial class ProductRecommendDetail:IProductRecommendDetail
	{
		public ProductRecommendDetail()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("prd_ID", "ProductRecommendDetail"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int prd_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductRecommendDetail");
			strSql.Append(" where prd_ID=@prd_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@prd_ID", SqlDbType.Int,4)			};
			parameters[0].Value = prd_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(webs_YueyxShop.Model.ProductRecommendDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductRecommendDetail(");
			strSql.Append("prt_ID,p_ID,prd_Status,prd_IsDelete)");
			strSql.Append(" values (");
			strSql.Append("@prt_ID,@p_ID,@prd_Status,@prd_IsDelete)");
			SqlParameter[] parameters = {
					new SqlParameter("@prt_ID", SqlDbType.Int,4),
					new SqlParameter("@p_ID", SqlDbType.Int,4),
					new SqlParameter("@prd_Status", SqlDbType.Bit,1),
					new SqlParameter("@prd_IsDelete", SqlDbType.Bit,1)};
			parameters[0].Value = model.prt_ID;
			parameters[1].Value = model.p_ID;
			parameters[2].Value = model.prd_Status;
			parameters[3].Value = model.prd_IsDelete;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(webs_YueyxShop.Model.ProductRecommendDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductRecommendDetail set ");
			strSql.Append("prt_ID=@prt_ID,");
			strSql.Append("p_ID=@p_ID,");
			strSql.Append("prd_Status=@prd_Status,");
			strSql.Append("prd_IsDelete=@prd_IsDelete");
			strSql.Append(" where prd_ID=@prd_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@prt_ID", SqlDbType.Int,4),
					new SqlParameter("@p_ID", SqlDbType.Int,4),
					new SqlParameter("@prd_Status", SqlDbType.Bit,1),
					new SqlParameter("@prd_IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@prd_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.prt_ID;
			parameters[1].Value = model.p_ID;
			parameters[2].Value = model.prd_Status;
			parameters[3].Value = model.prd_IsDelete;
			parameters[4].Value = model.prd_ID;

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
		public bool Delete(int prd_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductRecommendDetail ");
			strSql.Append(" where prd_ID=@prd_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@prd_ID", SqlDbType.Int,4)			};
			parameters[0].Value = prd_ID;

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
		public bool DeleteList(string prd_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductRecommendDetail ");
			strSql.Append(" where prd_ID in ("+prd_IDlist + ")  ");
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
        public webs_YueyxShop.Model.ProductRecommendDetail GetModel(int prd_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 prd_ID,prt_ID,p_ID,prd_Status,prd_IsDelete from ProductRecommendDetail ");
            strSql.Append(" where prd_ID=@prd_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@prd_ID", SqlDbType.Int,4)			};
            parameters[0].Value = prd_ID;

            webs_YueyxShop.Model.ProductRecommendDetail model = new webs_YueyxShop.Model.ProductRecommendDetail();
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
		public webs_YueyxShop.Model.ProductRecommendDetail DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.ProductRecommendDetail model=new webs_YueyxShop.Model.ProductRecommendDetail();
			if (row != null)
			{
				if(row["prd_ID"]!=null && row["prd_ID"].ToString()!="")
				{
					model.prd_ID=int.Parse(row["prd_ID"].ToString());
				}
				if(row["prt_ID"]!=null && row["prt_ID"].ToString()!="")
				{
					model.prt_ID=int.Parse(row["prt_ID"].ToString());
				}
				if(row["p_ID"]!=null && row["p_ID"].ToString()!="")
				{
					model.p_ID=int.Parse(row["p_ID"].ToString());
				}
				if(row["prd_Status"]!=null && row["prd_Status"].ToString()!="")
				{
					if((row["prd_Status"].ToString()=="1")||(row["prd_Status"].ToString().ToLower()=="true"))
					{
						model.prd_Status=true;
					}
					else
					{
						model.prd_Status=false;
					}
				}
				if(row["prd_IsDelete"]!=null && row["prd_IsDelete"].ToString()!="")
				{
					if((row["prd_IsDelete"].ToString()=="1")||(row["prd_IsDelete"].ToString().ToLower()=="true"))
					{
						model.prd_IsDelete=true;
					}
					else
					{
						model.prd_IsDelete=false;
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
			strSql.Append("select prd_ID,prt_ID,p_ID,prd_Status,prd_IsDelete ");
			strSql.Append(" FROM ProductRecommendDetail ");
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
			strSql.Append(" prd_ID,prt_ID,p_ID,prd_Status,prd_IsDelete ");
			strSql.Append(" FROM ProductRecommendDetail ");
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
			strSql.Append("select count(1) FROM ProductRecommendDetail ");
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
				strSql.Append("order by T.prd_ID desc");
			}
			strSql.Append(")AS Row, T.*  from ProductRecommendDetail T ");
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
			parameters[0].Value = "ProductRecommendDetail";
			parameters[1].Value = "prd_ID";
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
        /// 执行非查询语句
        /// </summary>
        /// <param name="strSql">完整查询语句</param>
        /// <returns></returns>
        public bool ExecuteNonQuery(string strSql)
        {
            if (!string.IsNullOrWhiteSpace(strSql))
            {
                try
                {
                    int rows = DbHelperSQL.ExecuteSql(strSql);
                    if (rows > 0)
                    {
                        return true;
                    }
                }
                catch
                {
                }
            }

            return false;
        }

        public DataTable GetTop4List(string where)
        {
            string sql = @"select * from(
                                    select 
                                        --推荐类型
                                        ProductRecommendTypeBase.prt_ID,ProductRecommendTypeBase.prt_Name,ProductRecommendTypeBase.prt_Title,ProductRecommendTypeBase.prt_Status,ProductRecommendTypeBase.prt_IsDelete,ProductRecommendTypeBase.prt_Directions,
                                        --推荐信息
                                        ProductRecommendDetail.prd_ID,ProductRecommendDetail.prd_Status,ProductRecommendDetail.prd_IsDelete,
                                        --分类信息
                                        ProductTypeBase.pt_ID,ProductTypeBase.pt_Code,ProductTypeBase.pt_ImgUrl,ProductTypeBase.pt_Name,ProductTypeBase.pt_ParentId,ProductTypeBase.pt_IsDel,ProductTypeBase.pt_StatusCode,
                                        --品牌信息
                                        BrandBase.b_ID,BrandBase.b_Key,BrandBase.b_LogoUrl,BrandBase.b_IsTui,BrandBase.b_Name,BrandBase.b_SiteUrl,BrandBase.b_TuiImg,BrandBase.b_IsDel,
                                        --商品信息
                                        ProductBase.p_ID,ProductBase.p_Name,ProductBase.p_IsDel,ProductBase.p_StatusCode,ProductBase.p_SellStatus,
                                        SKUBase.sku_Price,SKUBase.sku_id,
                                        productimgbase.pi_Url,
                                        (select COUNT(*) from ProductAppraiseBase where ProductAppraiseBase.sku_ID = SKUBase.sku_ID and pa_IsDel=0) as plcount
                                        
                                    from ProductRecommendTypeBase
                                    left join ProductRecommendDetail on ProductRecommendDetail.prt_ID = ProductRecommendTypeBase.prt_ID 
                                    left join ProductBase on ProductBase.p_ID = ProductRecommendDetail.p_ID
                                    left join BrandBase on BrandBase.b_ID = ProductBase.b_ID
                                    left join ProductTypeBase on ProductTypeBase.pt_ID = ProductBase.pt_ID
                                    left join SKUBase on SKUBase.p_ID=productrecommenddetail.p_ID
                                    left join ProductImgBase on ProductImgBase.sku_ID = SKUBase.sku_ID
                                    where ProductRecommendDetail.prd_IsDelete = 0 and SKUBase.sku_ismoren=1 and ProductImgBase.pi_Type=1
                                ) a where 1=1 ";
            sql += where;
            var ds = DbHelperSQL.Query(sql);
            if (ds != null && ds.Tables.Count != 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataTable GetRecommendProductList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select * from(
                                    select
                                        --推荐类型
                                        ProductRecommendTypeBase.prt_ID,ProductRecommendTypeBase.prt_Name,ProductRecommendTypeBase.prt_Title,ProductRecommendTypeBase.prt_Status,ProductRecommendTypeBase.prt_IsDelete,ProductRecommendTypeBase.prt_Directions,
                                        --推荐信息
                                        ProductRecommendDetail.prd_ID,ProductRecommendDetail.prd_Status,ProductRecommendDetail.prd_IsDelete,
                                        --分类信息
                                        ProductTypeBase.pt_ID,ProductTypeBase.pt_Code,ProductTypeBase.pt_ImgUrl,ProductTypeBase.pt_Name,ProductTypeBase.pt_ParentId,ProductTypeBase.pt_IsDel,ProductTypeBase.pt_StatusCode,
                                        --品牌信息
                                        BrandBase.b_ID,BrandBase.b_Key,BrandBase.b_LogoUrl,BrandBase.b_IsTui,BrandBase.b_Name,BrandBase.b_SiteUrl,BrandBase.b_TuiImg,BrandBase.b_IsDel,
                                        --商品信息
                                        ProductBase.p_ID,ProductBase.p_Name,ProductBase.p_IsDel,ProductBase.p_StatusCode,ProductBase.p_SellStatus
                                    from ProductRecommendTypeBase
                                    left join ProductRecommendDetail on ProductRecommendDetail.prt_ID = ProductRecommendTypeBase.prt_ID 
                                    left join ProductBase on ProductBase.p_ID = ProductRecommendDetail.p_ID
                                    left join BrandBase on BrandBase.b_ID = ProductBase.b_ID
                                    left join ProductTypeBase on ProductTypeBase.pt_ID = ProductBase.pt_ID
                                    where ProductRecommendDetail.prd_IsDelete = 0 and ProductBase.p_IsDel = 0
                                ) a where 1=1  ");
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                strSql.Append(strWhere);
            }

            var ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count != 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataTable GetRecommendProductDefaultSKUList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select * from(
                                select
                                    --推荐类型
                                    ProductRecommendTypeBase.prt_ID,ProductRecommendTypeBase.prt_Name,ProductRecommendTypeBase.prt_Title,ProductRecommendTypeBase.prt_Status,ProductRecommendTypeBase.prt_IsDelete,ProductRecommendTypeBase.prt_Directions,
                                    --推荐信息
                                    ProductRecommendDetail.prd_ID,ProductRecommendDetail.prd_Status,ProductRecommendDetail.prd_IsDelete,
                                    --分类信息
                                    ProductTypeBase.pt_ID,ProductTypeBase.pt_Code,ProductTypeBase.pt_ImgUrl,ProductTypeBase.pt_Name,ProductTypeBase.pt_ParentId,ProductTypeBase.pt_IsDel,ProductTypeBase.pt_StatusCode,
                                    --品牌信息
                                    BrandBase.b_ID,BrandBase.b_Key,BrandBase.b_LogoUrl,BrandBase.b_IsTui,BrandBase.b_Name,BrandBase.b_SiteUrl,BrandBase.b_TuiImg,BrandBase.b_IsDel,
                                    --SKU图片
                                    ProductImgBase.pi_ID,ProductImgBase.pi_isDel,ProductImgBase.pi_StatusCode,ProductImgBase.pi_Type,ProductImgBase.pi_Url,
                                    --SKU信息
                                    SKUBase.sku_ID,SKUBase.sku_Code,SKUBase.sku_Price,SKUBase.sku_CostPrice,SKUBase.sku_StatusCode,SKUBase.sku_scPric,SKUBase.sku_IsDel,
                                    --商品信息
                                    ProductBase.p_ID,ProductBase.p_Name,ProductBase.p_IsDel,ProductBase.p_StatusCode,ProductBase.p_SellStatus
                                from ProductRecommendTypeBase
                                left join ProductRecommendDetail on ProductRecommendDetail.prt_ID = ProductRecommendTypeBase.prt_ID 
                                left join ProductBase on ProductBase.p_ID = ProductRecommendDetail.p_ID
                                left join BrandBase on BrandBase.b_ID = ProductBase.b_ID
                                left join ProductTypeBase on ProductTypeBase.pt_ID = ProductBase.pt_ID
                                left join SKUBase on SKUBase.p_ID = ProductBase.p_ID
                                left join ProductImgBase on ProductImgBase.sku_ID = SKUBase.sku_ID
                                where ProductRecommendDetail.prd_IsDelete = 0 and SKUBase.sku_ismoren = 1 and ProductImgBase.pi_Type = 1
                            ) a where 1=1  ");
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                strSql.Append(strWhere);
            }

            var ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count != 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

		#endregion  ExtensionMethod
	}
}

