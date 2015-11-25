/**  版本信息模板在安装目录下，可自行修改。
* RejectionBase.cs
*
* 功 能： N/A
* 类 名： RejectionBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/13 11:35:11   N/A    初版
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
	/// 数据访问类:RejectionBase
	/// </summary>
	public partial class RejectionBase:IRejectionBase
	{
		public RejectionBase()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("r_ID", "RejectionBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int r_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from RejectionBase");
			strSql.Append(" where r_ID=@r_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = r_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(webs_YueyxShop.Model.RejectionBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RejectionBase(");
            strSql.Append("o_ID,m_ID,r_Date,r_Status,r_IsDelete,r_Remarks,r_Price,r_Code)");
			strSql.Append(" values (");
            strSql.Append("@o_ID,@m_ID,@r_Date,@r_Status,@r_IsDelete,@r_Remarks,@r_Price,@r_Code)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@o_ID", SqlDbType.Int,4),
					new SqlParameter("@m_ID", SqlDbType.Int,4),
					new SqlParameter("@r_Date", SqlDbType.DateTime),
					new SqlParameter("@r_Status", SqlDbType.Int,4),
					new SqlParameter("@r_IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@r_Remarks", SqlDbType.VarChar,200),
					new SqlParameter("@r_Price", SqlDbType.Decimal,5),
					new SqlParameter("@r_Code", SqlDbType.VarChar,30)};
			parameters[0].Value = model.o_ID;
			parameters[1].Value = model.m_ID;
			parameters[2].Value = model.r_Date;
			parameters[3].Value = model.r_Status;
            parameters[4].Value = model.r_IsDelete;
            parameters[5].Value = model.r_Remarks;
            parameters[6].Value = model.r_Price;
            parameters[7].Value = model.r_Code;

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
		public bool Update(webs_YueyxShop.Model.RejectionBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RejectionBase set ");
			strSql.Append("o_ID=@o_ID,");
			strSql.Append("m_ID=@m_ID,");
			strSql.Append("r_Date=@r_Date,");
			strSql.Append("r_Status=@r_Status,");
            strSql.Append("r_IsDelete=@r_IsDelete,");
            strSql.Append("r_Remarks=@r_Remarks,");
            strSql.Append("r_Price=@r_Price,");
            strSql.Append("r_Code=@r_Code");
			strSql.Append(" where r_ID=@r_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@o_ID", SqlDbType.Int,4),
					new SqlParameter("@m_ID", SqlDbType.Int,4),
					new SqlParameter("@r_Date", SqlDbType.DateTime),
					new SqlParameter("@r_Status", SqlDbType.Int,4),
					new SqlParameter("@r_IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@r_Remarks", SqlDbType.VarChar,200),
					new SqlParameter("@r_Price", SqlDbType.Decimal,5),
					new SqlParameter("@r_Code", SqlDbType.VarChar,30),
					new SqlParameter("@r_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.o_ID;
			parameters[1].Value = model.m_ID;
			parameters[2].Value = model.r_Date;
			parameters[3].Value = model.r_Status;
            parameters[4].Value = model.r_IsDelete;
            parameters[5].Value = model.r_Remarks;
            parameters[6].Value = model.r_Price;
            parameters[7].Value = model.r_Code;
			parameters[8].Value = model.r_ID;

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
		public bool Delete(int r_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RejectionBase ");
			strSql.Append(" where r_ID=@r_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = r_ID;

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
		public bool DeleteList(string r_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RejectionBase ");
			strSql.Append(" where r_ID in ("+r_IDlist + ")  ");
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
		public webs_YueyxShop.Model.RejectionBase GetModel(int r_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 r_ID,o_ID,m_ID,r_Date,r_Status,r_IsDelete,r_Remarks,r_Price,r_Code from RejectionBase ");
			strSql.Append(" where r_ID=@r_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@r_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = r_ID;

			webs_YueyxShop.Model.RejectionBase model=new webs_YueyxShop.Model.RejectionBase();
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
		public webs_YueyxShop.Model.RejectionBase DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.RejectionBase model=new webs_YueyxShop.Model.RejectionBase();
			if (row != null)
			{
				if(row["r_ID"]!=null && row["r_ID"].ToString()!="")
				{
					model.r_ID=int.Parse(row["r_ID"].ToString());
				}
				if(row["o_ID"]!=null && row["o_ID"].ToString()!="")
				{
					model.o_ID=int.Parse(row["o_ID"].ToString());
				}
				if(row["m_ID"]!=null && row["m_ID"].ToString()!="")
				{
					model.m_ID=int.Parse(row["m_ID"].ToString());
				}
                if (row["r_Price"] != null && row["r_Price"].ToString() != "")
                {
                    model.r_Price = decimal.Parse(row["r_Price"].ToString());
                }
				if(row["r_Date"]!=null && row["r_Date"].ToString()!="")
				{
					model.r_Date=DateTime.Parse(row["r_Date"].ToString());
				}
				if(row["r_Status"]!=null && row["r_Status"].ToString()!="")
				{
					model.r_Status=int.Parse(row["r_Status"].ToString());
                }
                if (row["r_Code"] != null)
                {
                    model.r_Code = row["r_Code"].ToString();
                }
				if(row["r_IsDelete"]!=null && row["r_IsDelete"].ToString()!="")
				{
					if((row["r_IsDelete"].ToString()=="1")||(row["r_IsDelete"].ToString().ToLower()=="true"))
					{
						model.r_IsDelete=true;
					}
					else
					{
						model.r_IsDelete=false;
					}
				}
				if(row["r_Remarks"]!=null)
				{
					model.r_Remarks=row["r_Remarks"].ToString();
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
			strSql.Append("select r_ID,o_ID,m_ID,r_Date,r_Status,r_IsDelete,r_Remarks,r_Price,r_Code ");
			strSql.Append(" FROM RejectionBase ");
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
            strSql.Append(" r_ID,o_ID,m_ID,r_Date,r_Status,r_IsDelete,r_Remarks ,r_Price,r_Code");
			strSql.Append(" FROM RejectionBase ");
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
			strSql.Append("select count(1) FROM RejectionBase ");
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
				strSql.Append("order by T.r_ID desc");
			}
			strSql.Append(")AS Row, T.*  from RejectionBase T ");
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
			parameters[0].Value = "RejectionBase";
			parameters[1].Value = "r_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
        #region  ExtensionMethod

        public DataTable GetRejectionBaseListDetail(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select * from(
	                            select
		                            --退货单信息
		                            RejectionBase.r_ID,RejectionBase.r_Code,RejectionBase.r_Price,RejectionBase.r_Date,RejectionBase.r_Status,RejectionBase.r_Remarks,RejectionBase.r_IsDelete,
		                            --订单信息
		                            OrderBase.o_ID,OrderBase.o_Code,OrderBase.o_IsDel,OrderBase.o_StatusCode,
		                            --会员信息
		                            MemberBase.m_ID,MemberBase.m_UserName,MemberBase.m_NickName,MemberBase.m_RealName,MemberBase.m_Phone,MemberBase.m_Email,MemberBase.m_QQ,MemberBase.m_StatusCode,MemberBase.m_CreatedOn
	                            from RejectionBase
	                            left join OrderBase on OrderBase.o_ID = RejectionBase.o_ID
	                            left join MemberBase on MemberBase.m_ID = RejectionBase.m_ID
                            ) a where 1=1 ");
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

        public DataTable GetRejectionProductList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select * from(
	                            select
		                            --退货单信息
		                            RejectionBase.r_ID,RejectionBase.r_Code,RejectionBase.r_Price,RejectionBase.r_Date,RejectionBase.r_Status,RejectionBase.r_Remarks,RejectionBase.r_IsDelete,
		                            --SKU信息
		                            SKUBase.sku_ID,SKUBase.sku_Code,SKUBase.sku_Price,SKUBase.sku_CostPrice,SKUBase.sku_StatusCode,
		                            --商品信息
		                            ProductBase.p_ID,ProductBase.p_Name
	                            from RejectionBase
	                            left join RejectionSKUDetail on RejectionSKUDetail.r_ID = RejectionBase.r_ID
	                            left join SKUBase on SKUBase.sku_ID = RejectionSKUDetail.sku_ID
	                            left join ProductBase on ProductBase.p_ID = SKUBase.p_ID
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

