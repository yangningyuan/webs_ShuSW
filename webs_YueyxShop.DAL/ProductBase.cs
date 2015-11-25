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
	/// 数据访问类:ProductBase
	/// </summary>
	public partial class ProductBase:IProductBase
	{
		public ProductBase()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("p_ID", "ProductBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int p_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductBase");
			strSql.Append(" where p_ID=@p_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@p_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = p_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(webs_YueyxShop.Model.ProductBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductBase(");
            strSql.Append("b_ID,pt_ID,ct_ID,p_Name,p_Sort,p_MeasurementUnit,p_Province,p_City,p_County,p_CreatedOn,p_CreatedBy,p_ModifyOn,p_ModifyBy,p_StatusCode,p_IsDel,p_sellStatus)");
			strSql.Append(" values (");
            strSql.Append("@b_ID,@pt_ID,@ct_ID,@p_Name,@p_Sort,@p_MeasurementUnit,@p_Province,@p_City,@p_County,@p_CreatedOn,@p_CreatedBy,@p_ModifyOn,@p_ModifyBy,@p_StatusCode,@p_IsDel,@p_sellStatus)");
			strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@b_ID", SqlDbType.Int,4),
					new SqlParameter("@pt_ID", SqlDbType.Int,4),
					new SqlParameter("@ct_ID", SqlDbType.Int,4),
					new SqlParameter("@p_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@p_Sort", SqlDbType.Int,4),
					new SqlParameter("@p_MeasurementUnit", SqlDbType.VarChar,20),
					new SqlParameter("@p_Province", SqlDbType.Int,4),
					new SqlParameter("@p_City", SqlDbType.Int,4),
					new SqlParameter("@p_County", SqlDbType.Int,4),
					new SqlParameter("@p_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@p_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@p_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@p_ModifyBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@p_StatusCode", SqlDbType.SmallInt,2),
					new SqlParameter("@p_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@p_sellStatus", SqlDbType.Int,2)};
            parameters[0].Value = model.b_ID;
			parameters[1].Value = model.pt_ID;
            parameters[2].Value = model.ct_ID;
			parameters[3].Value = model.p_Name;
			parameters[4].Value = model.p_Sort;
			parameters[5].Value = model.p_MeasurementUnit;
			parameters[6].Value = model.p_Province;
			parameters[7].Value = model.p_City;
			parameters[8].Value = model.p_County;
			parameters[9].Value = model.p_CreatedOn;
			parameters[10].Value = Guid.NewGuid();
			parameters[11].Value = model.p_ModifyOn;
			parameters[12].Value = Guid.NewGuid();
			parameters[13].Value = model.p_StatusCode;
            parameters[14].Value = model.p_IsDel;
            parameters[15].Value = model.p_SellStatus;

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
		public bool Update(webs_YueyxShop.Model.ProductBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductBase set ");
            strSql.Append("b_ID=@b_ID,");
            strSql.Append("pt_ID=@pt_ID,");
            strSql.Append("ct_ID=@ct_ID,");
			strSql.Append("p_Name=@p_Name,");
			strSql.Append("p_Sort=@p_Sort,");
			strSql.Append("p_MeasurementUnit=@p_MeasurementUnit,");
			strSql.Append("p_Province=@p_Province,");
			strSql.Append("p_City=@p_City,");
			strSql.Append("p_County=@p_County,");
			strSql.Append("p_CreatedOn=@p_CreatedOn,");
			strSql.Append("p_CreatedBy=@p_CreatedBy,");
			strSql.Append("p_ModifyOn=@p_ModifyOn,");
			strSql.Append("p_ModifyBy=@p_ModifyBy,");
            strSql.Append("p_StatusCode=@p_StatusCode,");
            strSql.Append("p_sellStatus=@p_sellStatus,");
			strSql.Append("p_IsDel=@p_IsDel");
			strSql.Append(" where p_ID=@p_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@b_ID", SqlDbType.Int,4),
					new SqlParameter("@pt_ID", SqlDbType.Int,4),
					new SqlParameter("@ct_ID", SqlDbType.Int,4),
					new SqlParameter("@p_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@p_Sort", SqlDbType.Int,4),
					new SqlParameter("@p_MeasurementUnit", SqlDbType.VarChar,20),
					new SqlParameter("@p_Province", SqlDbType.Int,4),
					new SqlParameter("@p_City", SqlDbType.Int,4),
					new SqlParameter("@p_County", SqlDbType.Int,4),
					new SqlParameter("@p_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@p_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@p_ModifyOn", SqlDbType.DateTime),
					new SqlParameter("@p_ModifyBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@p_StatusCode", SqlDbType.SmallInt,2),
					new SqlParameter("@p_sellStatus", SqlDbType.SmallInt,2),
					new SqlParameter("@p_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@p_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.b_ID;
			parameters[1].Value = model.pt_ID;
			parameters[2].Value = model.ct_ID;
			parameters[3].Value = model.p_Name;
			parameters[4].Value = model.p_Sort;
			parameters[5].Value = model.p_MeasurementUnit;
			parameters[6].Value = model.p_Province;
			parameters[7].Value = model.p_City;
			parameters[8].Value = model.p_County;
			parameters[9].Value = model.p_CreatedOn;
			parameters[10].Value = model.p_CreatedBy;
			parameters[11].Value = model.p_ModifyOn;
			parameters[12].Value = model.p_ModifyBy;
            parameters[13].Value = model.p_StatusCode;
            parameters[14].Value = model.p_SellStatus;
			parameters[15].Value = model.p_IsDel;
			parameters[16].Value = model.p_ID;

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
		public bool Delete(int p_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductBase ");
			strSql.Append(" where p_ID=@p_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@p_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = p_ID;

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
		public bool DeleteList(string p_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductBase ");
			strSql.Append(" where p_ID in ("+p_IDlist + ")  ");
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
		public webs_YueyxShop.Model.ProductBase GetModel(int p_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 b_ID ,p_ID,ct_ID,pt_ID,p_Name,p_Sort,p_MeasurementUnit,p_Province,p_City,p_County,p_CreatedOn,p_CreatedBy,p_ModifyOn,p_ModifyBy,p_StatusCode,p_IsDel,p_sellStatus from ProductBase ");
			strSql.Append(" where p_ID=@p_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@p_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = p_ID;

			webs_YueyxShop.Model.ProductBase model=new webs_YueyxShop.Model.ProductBase();
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
		public webs_YueyxShop.Model.ProductBase DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.ProductBase model=new webs_YueyxShop.Model.ProductBase();
			if (row != null)
			{
				if(row["p_ID"]!=null && row["p_ID"].ToString()!="")
				{
					model.p_ID=int.Parse(row["p_ID"].ToString());
				}
                if (row["b_ID"] != null && row["b_ID"].ToString() != "")
				{
                    model.b_ID = int.Parse(row["b_ID"].ToString());
				}
				if(row["pt_ID"]!=null && row["pt_ID"].ToString()!="")
				{
					model.pt_ID=int.Parse(row["pt_ID"].ToString());
				}
                if (row["ct_ID"] != null && row["ct_ID"].ToString() != "")
				{
                    model.ct_ID = int.Parse(row["ct_ID"].ToString());
				}
				if(row["p_Name"]!=null)
				{
					model.p_Name=row["p_Name"].ToString();
				}
				if(row["p_Sort"]!=null && row["p_Sort"].ToString()!="")
				{
					model.p_Sort=int.Parse(row["p_Sort"].ToString());
				}
				if(row["p_MeasurementUnit"]!=null)
				{
					model.p_MeasurementUnit=row["p_MeasurementUnit"].ToString();
				}
				if(row["p_Province"]!=null)
				{
					model.p_Province=int.Parse(row["p_Province"].ToString());
				}
				if(row["p_City"]!=null)
				{
					model.p_City=int.Parse(row["p_City"].ToString());
				}
				if(row["p_County"]!=null)
				{
					model.p_County=int.Parse(row["p_County"].ToString());
				}
				if(row["p_CreatedOn"]!=null && row["p_CreatedOn"].ToString()!="")
				{
					model.p_CreatedOn=DateTime.Parse(row["p_CreatedOn"].ToString());
				}
				if(row["p_CreatedBy"]!=null && row["p_CreatedBy"].ToString()!="")
				{
					model.p_CreatedBy= new Guid(row["p_CreatedBy"].ToString());
				}
				if(row["p_ModifyOn"]!=null && row["p_ModifyOn"].ToString()!="")
				{
					model.p_ModifyOn=DateTime.Parse(row["p_ModifyOn"].ToString());
				}
				if(row["p_ModifyBy"]!=null && row["p_ModifyBy"].ToString()!="")
				{
					model.p_ModifyBy= new Guid(row["p_ModifyBy"].ToString());
				}
				if(row["p_StatusCode"]!=null && row["p_StatusCode"].ToString()!="")
				{
					model.p_StatusCode=int.Parse(row["p_StatusCode"].ToString());
                }
                if (row["p_sellStatus"] != null && row["p_sellStatus"].ToString() != "")
                {
                    model.p_SellStatus = int.Parse(row["p_sellStatus"].ToString());
                }
				if(row["p_IsDel"]!=null && row["p_IsDel"].ToString()!="")
				{
					if((row["p_IsDel"].ToString()=="1")||(row["p_IsDel"].ToString().ToLower()=="true"))
					{
						model.p_IsDel=true;
					}
					else
					{
						model.p_IsDel=false;
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
            strSql.Append("select b_ID, p_ID,pt_ID,ct_ID,p_Name,p_Sort,p_MeasurementUnit,p_Province,p_City,p_County,p_CreatedOn,p_CreatedBy,p_ModifyOn,p_ModifyBy,p_StatusCode,p_IsDel,p_sellStatus ");
			strSql.Append(" FROM ProductBase ");
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
            strSql.Append(" b_ID,p_ID,pt_ID,ct_ID,p_Name,p_Sort,p_MeasurementUnit,p_Province,p_City,p_County,p_CreatedOn,p_CreatedBy,p_ModifyOn,p_ModifyBy,p_StatusCode,p_IsDel,p_sellStatus ");
			strSql.Append(" FROM ProductBase ");
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
			strSql.Append("select count(1) FROM ProductBase ");
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
				strSql.Append("order by T.p_ID desc");
			}
			strSql.Append(")AS Row, T.*  from ProductBase T ");
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
			parameters[0].Value = "ProductBase";
			parameters[1].Value = "p_ID";
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
            strSql.Append("select p.b_Id,p.p_Id,p.pt_ID,p.ct_ID,p.p_Name,p.p_Sort,p.p_MeasurementUnit,p.p_Province,p.p_City,p.p_County,p.p_CreatedOn,p.p_CreatedBy,p.p_ModifyOn,p.p_ModifyBy,p.p_StatusCode,p.p_IsDel,p.p_sellStatus,pt.pt_Name,r.reg_Name Province ,r2.reg_Name city,r3.reg_Name country ,ct.ct_Name ");
            strSql.Append(" from ProductBase p, ProductTypeBase pt,regionbase r,regionbase r2,regionbase r3,CarriageTempleteBase ct");
            if (p.Trim() != "")
            {
                strSql.Append(" where p.pt_ID = pt.pt_ID and r.reg_id = p.p_Province and r2.reg_id = p.p_City and r3.reg_id = p.p_County and p.ct_ID=ct.ct_ID and " + p+" order by p.p_Name");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int GetSort()
        {
            int Number = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Max(p_Sort) p_Sort from ProductBase where p_IsDel=0 and p_StatusCode =0");
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["p_Sort"].ToString()))
                {
                    Number = Convert.ToInt32(dt.Rows[0]["p_Sort"].ToString()) + 1;
                }
                else
                {
                    Number = 1;
                }
            }
            return Number;
        }
        //批量上架
        public bool UpdateList(string plist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductBase set p_SellStatus=1 where p_Id in("+plist+")");

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
        //批量下架
        public bool UpdateListx(string plist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductBase set p_SellStatus=2 where p_Id in(" + plist + ")");

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

        //按商品类别获取该类别下所有的商品信息（存储过程）
        public  List<Model.ProductBase> GetpInfoByTypeId(int cid)
        {
            List<Model.ProductBase> goodsI = new List<Model.ProductBase>();

            SqlParameter[] ps = new SqlParameter[]
            {
                new SqlParameter("@ptid",cid),
            };
            DataTable table = DbHelperSQL.GetTable("GetpInfoByTypeId", ps);

            foreach (DataRow r in table.Rows)
            {
                Model.ProductBase p = new Model.ProductBase();
                p.p_Name = r["p_Name"].ToString();
                p.productSkuInfo = new Model.SKUBase
                {
                    sku_Price = (decimal)r["sku_Price"],
                    sku_scPric = (decimal)r["sku_scPric"],
                    sku_ID = (int)r["sku_ID"],
                };//价格，skuid
                p.productImgInfo = new Model.ProductImgBase { pi_Url = r["pi_Url"].ToString() };//图片地址
                p.productAttrInfo = new Model.ProductAttributesBase
                {
                    pa_Name = r["shuxing"].ToString()
                };//全部属性
                p.productAppInfo = new Model.ProductAppraiseBase
                {
                    pa_ID = (int)r["countpl"]
                };//评价条数
                goodsI.Add(p);
            }
            return goodsI;
        }

        /// <summary>
        /// 商品详细信息(包括品牌和分类信息)
        /// </summary>
        public DataTable GetProductDetail(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select * from(
                                select
                                    --分类信息
                                    ProductTypeBase.pt_ID,ProductTypeBase.pt_Code,ProductTypeBase.pt_ImgUrl,ProductTypeBase.pt_Name,ProductTypeBase.pt_ParentId,ProductTypeBase.pt_IsDel,ProductTypeBase.pt_StatusCode,
                                    --品牌信息
                                    BrandBase.b_ID,BrandBase.b_Key,BrandBase.b_LogoUrl,BrandBase.b_IsTui,BrandBase.b_Name,BrandBase.b_SiteUrl,BrandBase.b_TuiImg,BrandBase.b_IsDel,
                                    --商品信息
                                    ProductBase.p_ID,ProductBase.p_Name,ProductBase.p_IsDel,ProductBase.p_StatusCode,ProductBase.p_SellStatus
                                from ProductBase
                                left join BrandBase on BrandBase.b_ID = ProductBase.b_ID
                                left join ProductTypeBase on ProductTypeBase.pt_ID = ProductBase.pt_ID
                                where ProductBase.p_IsDel = 0
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

        /// <summary>
        /// 商品详细信息(包括品牌、分类、默认SKU和SKU属性等信息)
        /// </summary>
        public DataTable GetProductPropertyDetail(string strWhere)
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
                            ) a1
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


        //获取商品信息（添加各个条件）
        public List<Model.ProductBase> GetpInfoByRecommendTypeId(int id)
        {


            List<Model.ProductBase> goodsI = new List<Model.ProductBase>();

            SqlParameter[] ps = new SqlParameter[]
            {
                new SqlParameter("@ptid",id),
            };
            DataTable table = DbHelperSQL.GetTable("GetpInfoByRecommendTypeId",ps);

            foreach (DataRow r in table.Rows)
            {
                Model.ProductBase p = new Model.ProductBase();

                if (r["sku_Price"] != null && r["sku_Price"].ToString() != "")
                {
                    StringBuilder strSqlgp = new StringBuilder();
                    strSqlgp.Append("select gp_ID,sku_ID,gp_StartTime,gp_EndTime,gp_pCount,gp_pPric,gp_CreateOn,gp_CreateBy,gp_StatusCode,gp_IsDel,gp_Logo,gp_Slogan,gp_SaleCount ");
                    strSqlgp.Append(" FROM GroupPurchaseBase ");
                    strSqlgp.Append(" where sku_ID=" + r["sku_ID"] + " and gp_StatusCode=0 and gp_IsDel=0 and gp_EndTime > '" + DateTime.Now + "'");
                    var gplist = DbHelperSQL.Query(strSqlgp.ToString());
                    if (gplist.Tables[0].Rows.Count > 0)
                    {
                        p.productSkuInfo = new Model.SKUBase
                        {
                            sku_Price = (decimal)gplist.Tables[0].Rows[0]["gp_pPric"],
                            sku_scPric = (decimal)r["sku_scPric"],
                            sku_ID = (int)r["sku_ID"],
                        };
                    }
                    else
                    {
                        p.productSkuInfo = new Model.SKUBase
                        {
                            sku_Price = (decimal)r["sku_Price"],
                            sku_scPric = (decimal)r["sku_scPric"],
                            sku_ID = (int)r["sku_ID"],
                        };
                    }
                }
                p.p_Name = r["p_Name"].ToString();
                //p.productSkuInfo = new Model.SKUBase
                //{
                //    sku_Price = (decimal)r["sku_Price"],
                //    sku_scPric = (decimal)r["sku_scPric"],
                //    sku_ID = (int)r["sku_ID"],
                //};//价格，skuid
                p.productImgInfo = new Model.ProductImgBase { pi_Url = r["pi_Url"].ToString() };//图片地址
                p.productAttrInfo = new Model.ProductAttributesBase
                {
                    pa_Name = r["shuxing"].ToString()
                };//全部属性
                p.productAppInfo = new Model.ProductAppraiseBase
                {
                    pa_ID = (int)r["countpl"]
                };//评价条数
                goodsI.Add(p);
            }
            return goodsI;
        }
		#endregion  ExtensionMethod
	}
}

