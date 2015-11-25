/**  版本信息模板在安装目录下，可自行修改。
* SKUBase.cs
*
* 功 能： N/A
* 类 名： SKUBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/20 9:05:30   N/A    初版
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
	/// 数据访问类:SKUBase
	/// </summary>
	public partial class SKUBase:ISKUBase
	{
		public SKUBase()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("sku_ID", "SKUBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int sku_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SKUBase");
			strSql.Append(" where sku_ID=@sku_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@sku_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = sku_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(webs_YueyxShop.Model.SKUBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SKUBase(");
            strSql.Append("p_ID,sku_Price,sku_CostPrice,sku_Stock,sku_SalesCount,sku_Code,sku_CreatedOn,sku_CreatedBy,sku_ModifyOn,sku_ModifyBy,sku_StatusCode,sku_IsDel,sku_scPric,sku_IsMoren,sku_tdcode)");
			strSql.Append(" values (");
            strSql.Append("@p_ID,@sku_Price,@sku_CostPrice,@sku_Stock,@sku_SalesCount,@sku_Code,@sku_CreatedOn,@sku_CreatedBy,@sku_ModifyOn,@sku_ModifyBy,@sku_StatusCode,@sku_IsDel,@sku_scPric,@sku_IsMoren,@sku_tdcode)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@p_ID", SqlDbType.Int,4),
					new SqlParameter("@sku_Price", SqlDbType.Decimal,5),
					new SqlParameter("@sku_CostPrice", SqlDbType.Decimal,5),
					new SqlParameter("@sku_Stock", SqlDbType.Int,4),
					new SqlParameter("@sku_SalesCount", SqlDbType.Int,4),
					new SqlParameter("@sku_Code", SqlDbType.VarChar,30),
					new SqlParameter("@sku_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@sku_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@sku_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@sku_ModifyBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@sku_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@sku_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@sku_scPric", SqlDbType.Decimal,5),
					new SqlParameter("@sku_IsMoren", SqlDbType.Bit,1),
					new SqlParameter("@sku_tdcode", SqlDbType.VarChar,100)};
			parameters[0].Value = model.p_ID;
			parameters[1].Value = model.sku_Price;
			parameters[2].Value = model.sku_CostPrice;
			parameters[3].Value = model.sku_Stock;
			parameters[4].Value = model.sku_SalesCount;
			parameters[5].Value = model.sku_Code;
			parameters[6].Value = model.sku_CreatedOn;
			parameters[7].Value = Guid.NewGuid();
			parameters[8].Value = model.sku_ModifyOn;
			parameters[9].Value = Guid.NewGuid();
			parameters[10].Value = model.sku_StatusCode;
			parameters[11].Value = model.sku_IsDel;
            parameters[12].Value = model.sku_scPric;
            parameters[13].Value = model.sku_IsMoren;
			parameters[14].Value = model.sku_tdcode;

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
		public bool Update(webs_YueyxShop.Model.SKUBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SKUBase set ");
			strSql.Append("p_ID=@p_ID,");
			strSql.Append("sku_Price=@sku_Price,");
			strSql.Append("sku_CostPrice=@sku_CostPrice,");
			strSql.Append("sku_Stock=@sku_Stock,");
			strSql.Append("sku_SalesCount=@sku_SalesCount,");
			strSql.Append("sku_Code=@sku_Code,");
			strSql.Append("sku_CreatedOn=@sku_CreatedOn,");
			strSql.Append("sku_CreatedBy=@sku_CreatedBy,");
			strSql.Append("sku_ModifyOn=@sku_ModifyOn,");
			strSql.Append("sku_ModifyBy=@sku_ModifyBy,");
			strSql.Append("sku_StatusCode=@sku_StatusCode,");
			strSql.Append("sku_IsDel=@sku_IsDel,");
            strSql.Append("sku_scPric=@sku_scPric,");
            strSql.Append("sku_IsMoren=@sku_IsMoren,");
            strSql.Append("sku_tdcode=@sku_tdcode");
			strSql.Append(" where sku_ID=@sku_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@p_ID", SqlDbType.Int,4),
					new SqlParameter("@sku_Price", SqlDbType.Decimal,5),
					new SqlParameter("@sku_CostPrice", SqlDbType.Decimal,5),
					new SqlParameter("@sku_Stock", SqlDbType.Int,4),
					new SqlParameter("@sku_SalesCount", SqlDbType.Int,4),
					new SqlParameter("@sku_Code", SqlDbType.VarChar,30),
					new SqlParameter("@sku_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@sku_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@sku_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@sku_ModifyBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@sku_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@sku_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@sku_scPric", SqlDbType.Decimal,5),
					new SqlParameter("@sku_IsMoren", SqlDbType.Bit,1),
					new SqlParameter("@sku_tdcode", SqlDbType.VarChar,100),
					new SqlParameter("@sku_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.p_ID;
			parameters[1].Value = model.sku_Price;
			parameters[2].Value = model.sku_CostPrice;
			parameters[3].Value = model.sku_Stock;
			parameters[4].Value = model.sku_SalesCount;
			parameters[5].Value = model.sku_Code;
			parameters[6].Value = model.sku_CreatedOn;
			parameters[7].Value = model.sku_CreatedBy;
			parameters[8].Value = model.sku_ModifyOn;
			parameters[9].Value = model.sku_ModifyBy;
			parameters[10].Value = model.sku_StatusCode;
			parameters[11].Value = model.sku_IsDel;
            parameters[12].Value = model.sku_scPric;
            parameters[13].Value = model.sku_IsMoren;
            parameters[14].Value = model.sku_tdcode;
			parameters[15].Value = model.sku_ID;

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
		public bool Delete(int sku_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SKUBase ");
			strSql.Append(" where sku_ID=@sku_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@sku_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = sku_ID;

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
		public bool DeleteList(string sku_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SKUBase ");
			strSql.Append(" where sku_ID in ("+sku_IDlist + ")  ");
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
		public webs_YueyxShop.Model.SKUBase GetModel(int sku_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 sku_ID,p_ID,sku_Price,sku_CostPrice,sku_Stock,sku_SalesCount,sku_Code,sku_CreatedOn,sku_CreatedBy,sku_ModifyOn,sku_ModifyBy,sku_StatusCode,sku_IsDel,sku_scPric,sku_IsMoren,sku_tdcode from SKUBase ");
			strSql.Append(" where sku_ID=@sku_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@sku_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = sku_ID;

			webs_YueyxShop.Model.SKUBase model=new webs_YueyxShop.Model.SKUBase();
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
		public webs_YueyxShop.Model.SKUBase DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.SKUBase model=new webs_YueyxShop.Model.SKUBase();
			if (row != null)
			{
				if(row["sku_ID"]!=null && row["sku_ID"].ToString()!="")
				{
					model.sku_ID=int.Parse(row["sku_ID"].ToString());
				}
				if(row["p_ID"]!=null && row["p_ID"].ToString()!="")
				{
					model.p_ID=int.Parse(row["p_ID"].ToString());
				}
				if(row["sku_Price"]!=null && row["sku_Price"].ToString()!="")
				{
					model.sku_Price=decimal.Parse(row["sku_Price"].ToString());
				}
				if(row["sku_CostPrice"]!=null && row["sku_CostPrice"].ToString()!="")
				{
					model.sku_CostPrice=decimal.Parse(row["sku_CostPrice"].ToString());
				}
				if(row["sku_Stock"]!=null && row["sku_Stock"].ToString()!="")
				{
					model.sku_Stock=int.Parse(row["sku_Stock"].ToString());
				}
				if(row["sku_SalesCount"]!=null && row["sku_SalesCount"].ToString()!="")
				{
					model.sku_SalesCount=int.Parse(row["sku_SalesCount"].ToString());
				}
				if(row["sku_Code"]!=null)
				{
					model.sku_Code=row["sku_Code"].ToString();
				}
				if(row["sku_CreatedOn"]!=null && row["sku_CreatedOn"].ToString()!="")
				{
					model.sku_CreatedOn=DateTime.Parse(row["sku_CreatedOn"].ToString());
				}
				if(row["sku_CreatedBy"]!=null && row["sku_CreatedBy"].ToString()!="")
				{
					model.sku_CreatedBy= new Guid(row["sku_CreatedBy"].ToString());
				}
				if(row["sku_ModifyOn"]!=null && row["sku_ModifyOn"].ToString()!="")
				{
					model.sku_ModifyOn=DateTime.Parse(row["sku_ModifyOn"].ToString());
				}
				if(row["sku_ModifyBy"]!=null && row["sku_ModifyBy"].ToString()!="")
				{
					model.sku_ModifyBy= new Guid(row["sku_ModifyBy"].ToString());
				}
				if(row["sku_StatusCode"]!=null && row["sku_StatusCode"].ToString()!="")
				{
					model.sku_StatusCode=int.Parse(row["sku_StatusCode"].ToString());
				}
				if(row["sku_IsDel"]!=null && row["sku_IsDel"].ToString()!="")
				{
					if((row["sku_IsDel"].ToString()=="1")||(row["sku_IsDel"].ToString().ToLower()=="true"))
					{
						model.sku_IsDel=true;
					}
					else
					{
						model.sku_IsDel=false;
					}
				}
				if(row["sku_scPric"]!=null && row["sku_scPric"].ToString()!="")
				{
					model.sku_scPric=decimal.Parse(row["sku_scPric"].ToString());
                }
                if (row["sku_IsMoren"] != null && row["sku_IsMoren"].ToString() != "")
                {
                    if ((row["sku_IsMoren"].ToString() == "1") || (row["sku_IsMoren"].ToString().ToLower() == "true"))
                    {
                        model.sku_IsMoren = true;
                    }
                    else
                    {
                        model.sku_IsMoren = false;
                    }
                }
                if (row["sku_tdcode"] != null)
                {
                    model.sku_tdcode = row["sku_tdcode"].ToString();
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
            strSql.Append("select * ");
			strSql.Append(" FROM SKUBase ");
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
            strSql.Append(" sku_ID,p_ID,sku_Price,sku_CostPrice,sku_Stock,sku_SalesCount,sku_Code,sku_CreatedOn,sku_CreatedBy,sku_ModifyOn,sku_ModifyBy,sku_StatusCode,sku_IsDel,sku_scPric,sku_IsMoren,sku_tdcode ");
			strSql.Append(" FROM SKUBase ");
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
			strSql.Append("select count(1) FROM SKUBase ");
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
				strSql.Append("order by T.sku_ID desc");
			}
			strSql.Append(")AS Row, T.*  from SKUBase T ");
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
			parameters[0].Value = "SKUBase";
			parameters[1].Value = "sku_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        public DataSet GetModelListById(string p)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select s.sku_ID,s.p_ID,s.sku_Price,s.sku_CostPrice,s.sku_Stock,s.sku_SalesCount,s.sku_Code,s.sku_CreatedOn,s.sku_CreatedBy,s.sku_ModifyOn,s.sku_ModifyBy,s.sku_StatusCode,s.sku_IsDel,s.sku_scPric,s.sku_IsMoren,p.p_Name ");
            strSql.Append("from SKUBase s,ProductBase p");
            if (p.Trim() != "")
            {
                strSql.Append("  where p.p_ID=s.p_ID and " + p);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

//        public DataTable GetSKUDetial(string strWhere)
//        {
//            StringBuilder strSql = new StringBuilder();
//            strSql.Append(@"select * from 
//                                (
//                                select
//	                                --SKU信息
//		                                SKUBase.sku_ID,SKUBase.sku_Code,SKUBase.sku_Price,SKUBase.sku_CostPrice,SKUBase.sku_StatusCode,sku_scPric,sku_IsMoren,
//	                                --产品信息
//		                                ProductBase.p_ID,ProductBase.p_Name,ProductBase.pt_ID
//                                from SKUBase 
//                                left join ProductBase on SKUBase.p_ID = ProductBase.p_ID
//                                where SKUBase.sku_IsDel = 0
//                                ) a where 1=1 ");

//            if (!string.IsNullOrWhiteSpace(strWhere))
//            {
//                strSql.Append(strWhere);
//            }

//            var list = DbHelperSQL.Query(strSql.ToString());
//            if(list != null && list.Tables.Count > 0)
//            {
//                return list.Tables[0];
//            }

//            return null;
//        }

        /// <summary>
        /// 商品详细信息(包括品牌、分类、默认SKU和SKU属性等信息)
        /// </summary>
        public DataTable GetDefaultSKUDetial(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
                           --1 创建临时表
                            /*
                            create table #temptab
                            (
                                sku_ID int,
                                pa_Name nvarchar(200)
                            )
                            */
                            --2 向临时表中添加数据
                            select * into #temptab from (
                                    select sku_ID,pa_name
                                    FROM ProductAttributeDetails
                                    left join ProductAttributesBase on ProductAttributesBase.pa_ID = ProductAttributeDetails.pa_ID
                            ) a
                            --3 创建临时表
                            /*
                            create table #shuxing
                            (
                                sku_ID int,
                                pa_NameCom nvarchar(200)
                            )
                            */
                            --4 向临时表中添加数据
                            select * into #shuxing from (
                                SELECT sku_ID, data=STUFF((SELECT ' '+pa_Name FROM #temptab WHERE sku_ID=t1.sku_ID FOR XML PATH('')), 1, 1, '')
                                FROM  #temptab t1
                                GROUP BY sku_ID
                            ) a2
                            --5 联合查询
                            select * from (
                            select 
                                --分类信息
                                ProductTypeBase.pt_ID,ProductTypeBase.pt_Code,ProductTypeBase.pt_ImgUrl,ProductTypeBase.pt_Name,ProductTypeBase.pt_ParentId,ProductTypeBase.pt_IsDel,ProductTypeBase.pt_StatusCode,
                                --品牌信息
                                BrandBase.b_ID,BrandBase.b_Key,BrandBase.b_LogoUrl,BrandBase.b_IsTui,BrandBase.b_Name,BrandBase.b_SiteUrl,BrandBase.b_TuiImg,BrandBase.b_IsDel,
                                --SKU信息
                                SKUBase.sku_ID,SKUBase.sku_Code,SKUBase.sku_CostPrice,SKUBase.sku_IsDel,SKUBase.sku_ismoren,SKUBase.sku_Price,SKUBase.sku_SalesCount,SKUBase.sku_scPric,SKUBase.sku_StatusCode,SKUBase.sku_Stock,
                                --图片信息
                                ProductImgBase.pi_ID,ProductImgBase.pi_Type,ProductImgBase.pi_Url,ProductImgBase.pi_StatusCode,ProductImgBase.pi_isDel,
                                --属性表
                                #shuxing.data as property,
                                --商品信息
                                ProductBase.p_ID,ProductBase.p_Name,ProductBase.p_IsDel,ProductBase.p_StatusCode,ProductBase.p_SellStatus,ProductBase.p_CreatedOn
                                from ProductBase
                                left join SKUBase on SKUBase.p_ID = ProductBase.p_ID
                                left join ProductImgBase on ProductImgBase.sku_ID = SKUBase.sku_ID
                                left join ProductTypeBase on ProductTypeBase.pt_ID = ProductBase.pt_ID
                                left join BrandBase on BrandBase.b_ID = ProductBase.b_ID
                                left join #shuxing on #shuxing.sku_ID = SKUBase.sku_ID
                            where SKUBase.sku_ismoren = 1 or SKUBase.sku_ID is null
                            )a3 where 1=1 ");

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
        
        /// <summary>
        /// 商品详细信息(包括品牌、分类、SKU和SKU属性等信息)
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="type">true仅查询封面</param>
        /// <returns></returns>
        public DataTable GetSKUDetial(string strWhere, bool type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
                           --1 创建临时表
                            /*
                            create table #temptab
                            (
                                sku_ID int,
                                pa_Name nvarchar(200)
                            )
                            */
                            --2 向临时表中添加数据
                            select * into #temptab from (
                                    select sku_ID,pa_name
                                    FROM ProductAttributeDetails
                                    left join ProductAttributesBase on ProductAttributesBase.pa_ID = ProductAttributeDetails.pa_ID
                            ) a
                            --3 创建临时表
                            /*
                            create table #shuxing
                            (
                                sku_ID int,
                                pa_NameCom nvarchar(200)
                            )
                            */
                            --4 向临时表中添加数据
                            select * into #shuxing from (
                                SELECT sku_ID, data=STUFF((SELECT ' '+pa_Name FROM #temptab WHERE sku_ID=t1.sku_ID FOR XML PATH('')), 1, 1, '')
                                FROM  #temptab t1
                                GROUP BY sku_ID
                            ) a2
                            --5 联合查询
                            select * from (
                                    select 
                                        --分类信息
                                        ProductTypeBase.pt_ID,ProductTypeBase.pt_Code,ProductTypeBase.pt_ImgUrl,ProductTypeBase.pt_Name,ProductTypeBase.pt_ParentId,ProductTypeBase.pt_IsDel,ProductTypeBase.pt_StatusCode,
                                        --品牌信息
                                        BrandBase.b_ID,BrandBase.b_Key,BrandBase.b_LogoUrl,BrandBase.b_IsTui,BrandBase.b_Name,BrandBase.b_SiteUrl,BrandBase.b_TuiImg,BrandBase.b_IsDel,
                                        --SKU信息
                                        SKUBase.sku_ID,SKUBase.sku_Code,SKUBase.sku_CostPrice,SKUBase.sku_IsDel,SKUBase.sku_ismoren,SKUBase.sku_Price,SKUBase.sku_SalesCount,SKUBase.sku_scPric,SKUBase.sku_StatusCode,SKUBase.sku_Stock,
                                        --图片信息
                                        ProductImgBase.pi_ID,ProductImgBase.pi_Type,ProductImgBase.pi_Url,ProductImgBase.pi_StatusCode,ProductImgBase.pi_isDel,
                                        --属性表
                                        #shuxing.data as property,
                                        --商品信息
                                        ProductBase.p_ID,ProductBase.p_Name,ProductBase.p_IsDel,ProductBase.p_StatusCode,ProductBase.p_SellStatus,ProductBase.p_CreatedOn
                                        from ProductBase
                                        left join SKUBase on SKUBase.p_ID = ProductBase.p_ID
                                        left join ProductImgBase on ProductImgBase.sku_ID = SKUBase.sku_ID
                                        left join ProductTypeBase on ProductTypeBase.pt_ID = ProductBase.pt_ID
                                        left join BrandBase on BrandBase.b_ID = ProductBase.b_ID
                                        left join #shuxing on #shuxing.sku_ID = SKUBase.sku_ID");
            if(type)
            {
                strSql.Append(" where (ProductImgBase.pi_isDel = 0 or ProductImgBase.pi_isDel is null) and (ProductImgBase.pi_Type = 1 or ProductImgBase.pi_Type is null)");
            }
                                    
            strSql.Append(")a3 where 1=1 ");

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

