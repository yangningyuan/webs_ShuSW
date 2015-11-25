/**  版本信息模板在安装目录下，可自行修改。
* OrderBase.cs
*
* 功 能： N/A
* 类 名： OrderBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/6 16:05:07   N/A    初版
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
	/// 数据访问类:OrderBase
	/// </summary>
	public partial class OrderBase:IOrderBase
	{
		public OrderBase()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("o_ID", "OrderBase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int o_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OrderBase");
			strSql.Append(" where o_ID=@o_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@o_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = o_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(webs_YueyxShop.Model.OrderBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OrderBase(");
            strSql.Append("c_ID,m_ID,o_Code,o_CreateOn,o_Pric,o_Zhek,o_StatusCode,o_Mark,o_IsDel,pay_ID,st_ID,o_AlipayNo,o_LogisticsNo,o_Score)");
			strSql.Append(" values (");
            strSql.Append("@c_ID,@m_ID,@o_Code,@o_CreateOn,@o_Pric,@o_Zhek,@o_StatusCode,@o_Mark,@o_IsDel,@pay_ID,@st_ID,@o_AlipayNo,@o_LogisticsNo,@o_Score)");
            strSql.Append(";select SCOPE_IDENTITY()");
			SqlParameter[] parameters = {
					new SqlParameter("@c_ID", SqlDbType.Int,4),
					new SqlParameter("@m_ID", SqlDbType.Int,4),
					new SqlParameter("@o_Code", SqlDbType.VarChar,30),
					new SqlParameter("@o_CreateOn", SqlDbType.DateTime),
					new SqlParameter("@o_Pric", SqlDbType.Decimal,5),
					new SqlParameter("@o_Zhek", SqlDbType.Decimal,5),
					new SqlParameter("@o_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@o_Mark", SqlDbType.VarChar,200),
					new SqlParameter("@o_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@pay_ID", SqlDbType.Int,4),
					new SqlParameter("@st_ID", SqlDbType.Int,4),
					new SqlParameter("@o_AlipayNo", SqlDbType.VarChar,30),
					new SqlParameter("@o_LogisticsNo", SqlDbType.VarChar,30),
					new SqlParameter("@o_Score", SqlDbType.Int,4)};
			parameters[0].Value = model.c_ID;
			parameters[1].Value = model.m_ID;
			parameters[2].Value = model.o_Code;
			parameters[3].Value = model.o_CreateOn;
			parameters[4].Value = model.o_Pric;
            parameters[5].Value = model.o_Zhek;
			parameters[6].Value = model.o_StatusCode;
			parameters[7].Value = model.o_Mark;
			parameters[8].Value = model.o_IsDel;
			parameters[9].Value = model.pay_ID;
			parameters[10].Value = model.st_ID;
			parameters[11].Value = model.o_AlipayNo;
			parameters[12].Value = model.o_LogisticsNo;
			parameters[13].Value = model.o_Score;

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
		public bool Update(webs_YueyxShop.Model.OrderBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OrderBase set ");
			strSql.Append("c_ID=@c_ID,");
			strSql.Append("m_ID=@m_ID,");
			strSql.Append("o_Code=@o_Code,");
			strSql.Append("o_CreateOn=@o_CreateOn,");
			strSql.Append("o_Pric=@o_Pric,");
            strSql.Append("o_Zhek=@o_Zhek,");
			strSql.Append("o_StatusCode=@o_StatusCode,");
			strSql.Append("o_Mark=@o_Mark,");
			strSql.Append("o_IsDel=@o_IsDel,");
			strSql.Append("pay_ID=@pay_ID,");
			strSql.Append("st_ID=@st_ID,");
			strSql.Append("o_AlipayNo=@o_AlipayNo,");
			strSql.Append("o_LogisticsNo=@o_LogisticsNo,");
			strSql.Append("o_Score=@o_Score");
			strSql.Append(" where o_ID=@o_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@c_ID", SqlDbType.Int,4),
					new SqlParameter("@m_ID", SqlDbType.Int,4),
					new SqlParameter("@o_Code", SqlDbType.VarChar,30),
					new SqlParameter("@o_CreateOn", SqlDbType.DateTime),
					new SqlParameter("@o_Pric", SqlDbType.Decimal,5),
					new SqlParameter("@o_Zhek", SqlDbType.Decimal,5),
					new SqlParameter("@o_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@o_Mark", SqlDbType.VarChar,200),
					new SqlParameter("@o_IsDel", SqlDbType.Bit,1),
					new SqlParameter("@pay_ID", SqlDbType.Int,4),
					new SqlParameter("@st_ID", SqlDbType.Int,4),
					new SqlParameter("@o_AlipayNo", SqlDbType.VarChar,30),
					new SqlParameter("@o_LogisticsNo", SqlDbType.VarChar,30),
					new SqlParameter("@o_Score", SqlDbType.Int,4),
					new SqlParameter("@o_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.c_ID;
			parameters[1].Value = model.m_ID;
			parameters[2].Value = model.o_Code;
			parameters[3].Value = model.o_CreateOn;
			parameters[4].Value = model.o_Pric;
            parameters[5].Value = model.o_Zhek;
			parameters[6].Value = model.o_StatusCode;
			parameters[7].Value = model.o_Mark;
			parameters[8].Value = model.o_IsDel;
			parameters[9].Value = model.pay_ID;
			parameters[10].Value = model.st_ID;
			parameters[11].Value = model.o_AlipayNo;
			parameters[12].Value = model.o_LogisticsNo;
			parameters[13].Value = model.o_Score;
			parameters[14].Value = model.o_ID;

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
		public bool Delete(int o_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OrderBase ");
			strSql.Append(" where o_ID=@o_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@o_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = o_ID;

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
		public bool DeleteList(string o_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OrderBase ");
			strSql.Append(" where o_ID in ("+o_IDlist + ")  ");
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
		public webs_YueyxShop.Model.OrderBase GetModel(int o_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 o_ID,c_ID,m_ID,o_Code,o_CreateOn,o_Pric,o_Zhek,o_StatusCode,o_Mark,o_IsDel,pay_ID,st_ID,o_AlipayNo,o_LogisticsNo,o_Score from OrderBase ");
			strSql.Append(" where o_ID='"+o_ID+"'");

			webs_YueyxShop.Model.OrderBase model=new webs_YueyxShop.Model.OrderBase();
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
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
		public webs_YueyxShop.Model.OrderBase DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.OrderBase model=new webs_YueyxShop.Model.OrderBase();
			if (row != null)
			{
				if(row["o_ID"]!=null && row["o_ID"].ToString()!="")
				{
					model.o_ID=int.Parse(row["o_ID"].ToString());
				}
				if(row["c_ID"]!=null && row["c_ID"].ToString()!="")
				{
					model.c_ID=int.Parse(row["c_ID"].ToString());
				}
				if(row["m_ID"]!=null && row["m_ID"].ToString()!="")
				{
					model.m_ID=int.Parse(row["m_ID"].ToString());
				}
				if(row["o_Code"]!=null)
				{
					model.o_Code=row["o_Code"].ToString();
				}
				if(row["o_CreateOn"]!=null && row["o_CreateOn"].ToString()!="")
				{
					model.o_CreateOn=DateTime.Parse(row["o_CreateOn"].ToString());
				}
				if(row["o_Pric"]!=null && row["o_Pric"].ToString()!="")
				{
					model.o_Pric=decimal.Parse(row["o_Pric"].ToString());
				}
                if (row["o_Zhek"] != null && row["o_Zhek"].ToString() != "")
				{
                    model.o_Zhek = decimal.Parse(row["o_Zhek"].ToString());
				}
				if(row["o_StatusCode"]!=null && row["o_StatusCode"].ToString()!="")
				{
					model.o_StatusCode=int.Parse(row["o_StatusCode"].ToString());
				}
				if(row["o_Mark"]!=null)
				{
					model.o_Mark=row["o_Mark"].ToString();
				}
				if(row["o_IsDel"]!=null && row["o_IsDel"].ToString()!="")
				{
					if((row["o_IsDel"].ToString()=="1")||(row["o_IsDel"].ToString().ToLower()=="true"))
					{
						model.o_IsDel=true;
					}
					else
					{
						model.o_IsDel=false;
					}
				}
				if(row["pay_ID"]!=null && row["pay_ID"].ToString()!="")
				{
					model.pay_ID=int.Parse(row["pay_ID"].ToString());
				}
				if(row["st_ID"]!=null && row["st_ID"].ToString()!="")
				{
					model.st_ID=int.Parse(row["st_ID"].ToString());
				}
				if(row["o_AlipayNo"]!=null)
				{
					model.o_AlipayNo=row["o_AlipayNo"].ToString();
				}
				if(row["o_LogisticsNo"]!=null)
				{
					model.o_LogisticsNo=row["o_LogisticsNo"].ToString();
				}
				if(row["o_Score"]!=null && row["o_Score"].ToString()!="")
				{
					model.o_Score=int.Parse(row["o_Score"].ToString());
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
            strSql.Append("select o_ID,c_ID,m_ID,o_Code,o_CreateOn,o_Pric,o_Zhek,o_StatusCode,o_Mark,o_IsDel,pay_ID,st_ID,o_AlipayNo,o_LogisticsNo,o_Score ");
			strSql.Append(" FROM OrderBase ");
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
            strSql.Append(" o_ID,c_ID,m_ID,o_Code,o_CreateOn,o_Pric,o_Zhek,o_StatusCode,o_Mark,o_IsDel,pay_ID,st_ID,o_AlipayNo,o_LogisticsNo,o_Score ");
			strSql.Append(" FROM OrderBase ");
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
			strSql.Append("select count(1) FROM OrderBase ");
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
				strSql.Append("order by T.o_ID desc");
			}
			strSql.Append(")AS Row, T.*  from OrderBase T ");
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
			parameters[0].Value = "OrderBase";
			parameters[1].Value = "o_ID";
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetModelListbypric(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select o_ID,c_ID,m_ID,o_Code,o_CreateOn,cast(o_Pric as decimal(16,0)) as o_Pric,o_Zhek,o_StatusCode,o_Mark,o_IsDel,pay_ID,st_ID,o_AlipayNo,o_LogisticsNo,o_Score ");
            strSql.Append(" FROM OrderBase ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataTable GetOrderDetialList(string strWhere)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"select * from(
	                        --订单信息
	                        select OrderBase.o_ID,OrderBase.o_Code,OrderBase.o_CreateOn,OrderBase.o_Pric,OrderBase.o_Zhek,OrderBase.o_StatusCode,OrderBase.o_Mark,OrderBase.o_IsDel,
		                        --配送方式
		                        ShipTypeBase.st_ID,ShipTypeBase.st_Name,
		                        --支付方式
		                        PaymentBase.pay_ID,PaymentBase.pay_Name,
		                        --收货人信息(地址)
		                        ConsigneeInfoBase.c_ID,ConsigneeInfoBase.c_Name,ConsigneeInfoBase.c_Mobilephone,ConsigneeInfoBase.c_Provice,ConsigneeInfoBase.c_City,ConsigneeInfoBase.c_Count,ConsigneeInfoBase.c_Zipcode,'' as c_Address,
		                        --会员信息
                                MemberBase.m_ID,MemberBase.m_UserName,MemberBase.m_NickName,MemberBase.m_RealName,MemberBase.m_Phone,MemberBase.m_Email,MemberBase.m_QQ,MemberBase.m_StatusCode,MemberBase.m_CreatedOn
	                        from OrderBase
	                        left join MemberBase on MemberBase.m_ID = OrderBase.m_ID
	                        left join ConsigneeInfoBase on ConsigneeInfoBase.c_ID = OrderBase.c_ID
	                        left join ShipTypeBase on ShipTypeBase.st_ID = OrderBase.st_ID
	                        left join PaymentBase on PaymentBase.pay_ID = OrderBase.pay_ID
	                        where OrderBase.o_IsDel = 0
                        ) a where 1=1  ");
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                sql.Append(strWhere);
            }
            sql.Append("  order by o_CreateOn desc");

            var ds = DbHelperSQL.Query(sql.ToString());

            if (ds != null && ds.Tables[0] != null)
            {
                ConsigneeInfoBase cib = new ConsigneeInfoBase();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["c_ID"] != null && !string.IsNullOrWhiteSpace(row["c_ID"].ToString()))
                    {
                        var model = cib.GetModel(Convert.ToInt32(row["c_ID"]));
                        row["c_Address"] = model.c_Name + "," + model.c_Mobilephone + "," + model.c_CProvice + model.c_CCity + model.c_CCount + model.c_FullAddress + "," + model.c_Zipcode;
                    }
                }
                return ds.Tables[0];
            }
            return null;
        }

        public DataTable GetOrderProductList(string strWhere)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(@"select * from(
	                            --订单信息
	                            select OrderBase.o_ID,OrderBase.o_Code,OrderBase.o_CreateOn,OrderBase.o_Pric,OrderBase.o_Zhek,OrderBase.o_StatusCode,OrderBase.o_Mark,OrderBase.o_IsDel,
		                            --SKU信息
		                            SKUBase.sku_ID,SKUBase.sku_Code,SKUBase.sku_Price,SKUBase.sku_CostPrice,SKUBase.sku_StatusCode,
		                            --商品信息
ProductBase.p_ID,ProductBase.p_Name,OrderSKUDetail.os_chima,OrderSKUDetail.os_yanse,OrderSKUDetail.os_pCount
	                            from OrderBase
	                            left join OrderSKUDetail on OrderSKUDetail.o_ID = OrderBase.o_ID
	                            left join SKUBase on SKUBase.sku_ID = OrderSKUDetail.sku_ID
	                            left join ProductBase on ProductBase.p_ID = SKUBase.p_ID
	                            where OrderBase.o_IsDel = 0
                            ) a where 1=1   ");
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                sql.Append(strWhere);
            }

            var ds = DbHelperSQL.Query(sql.ToString());

            if (ds != null && ds.Tables[0] != null)
            {
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetregList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select o.o_ID,o.c_ID,o.m_ID,o.o_Code,o.o_CreateOn,o.o_Pric,o.o_Zhek,o.o_StatusCode,o.o_AlipayNo,o.o_LogisticsNo,o.o_Score,o.o_Mark,o.o_IsDel,o.pay_ID,o.st_ID,r.r_Status,r.r_Date,r.r_Price ");
            strSql.Append(" FROM OrderBase o,RejectionBase r  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where o.o_ID=r.o_ID and  r.r_IsDelete=0 " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public webs_YueyxShop.Model.OrderBase DataRowToModel2(DataRow row)
        {
            webs_YueyxShop.Model.OrderBase model = new webs_YueyxShop.Model.OrderBase();
            if (row != null)
            {
                if (row["o_ID"] != null && row["o_ID"].ToString() != "")
                {
                    model.o_ID = int.Parse(row["o_ID"].ToString());
                }
                if (row["c_ID"] != null && row["c_ID"].ToString() != "")
                {
                    model.c_ID = int.Parse(row["c_ID"].ToString());
                }
                if (row["m_ID"] != null && row["m_ID"].ToString() != "")
                {
                    model.m_ID = int.Parse(row["m_ID"].ToString());
                }
                if (row["o_Code"] != null)
                {
                    model.o_Code = row["o_Code"].ToString();
                }
                if (row["o_CreateOn"] != null && row["o_CreateOn"].ToString() != "")
                {
                    model.o_CreateOn = DateTime.Parse(row["o_CreateOn"].ToString());
                }
                if (row["o_Pric"] != null && row["o_Pric"].ToString() != "")
                {
                    model.o_Pric = decimal.Parse(row["o_Pric"].ToString());
                }
                if (row["o_Zhek"] != null && row["o_Zhek"].ToString() != "")
                {
                    model.o_Zhek = decimal.Parse(row["o_Zhek"].ToString());
                }
                if (row["o_StatusCode"] != null && row["o_StatusCode"].ToString() != "")
                {
                    model.o_StatusCode = int.Parse(row["o_StatusCode"].ToString());
                }
                if (row["o_Mark"] != null)
                {
                    model.o_Mark = row["o_Mark"].ToString();
                }
                if (row["o_IsDel"] != null && row["o_IsDel"].ToString() != "")
                {
                    if ((row["o_IsDel"].ToString() == "1") || (row["o_IsDel"].ToString().ToLower() == "true"))
                    {
                        model.o_IsDel = true;
                    }
                    else
                    {
                        model.o_IsDel = false;
                    }
                }
                if (row["pay_ID"] != null && row["pay_ID"].ToString() != "")
                {
                    model.pay_ID = int.Parse(row["pay_ID"].ToString());
                }
                if (row["st_ID"] != null && row["st_ID"].ToString() != "")
                {
                    model.st_ID = int.Parse(row["st_ID"].ToString());
                }
                if (row["r_Status"] != null && row["r_Status"].ToString() != "" && row["r_Date"] != null && row["st_ID"].ToString() != "")
                {
                    model.rejorder = new Model.RejectionBase
                    {
                        r_Status = int.Parse(row["r_Status"].ToString()),
                        r_Date = DateTime.Parse(row["r_Date"].ToString()),
                        r_Price = decimal.Parse(row["r_Price"].ToString())
                    };
                }
                if (row["o_AlipayNo"] != null)
                {
                    model.o_AlipayNo = row["o_AlipayNo"].ToString();
                }
                if (row["o_LogisticsNo"] != null)
                {
                    model.o_LogisticsNo = row["o_LogisticsNo"].ToString();
                }
                if (row["o_Score"] != null && row["o_Score"].ToString() != "")
                {
                    model.o_Score = int.Parse(row["o_Score"].ToString());
                }
            }
            return model;
        }

		#endregion  ExtensionMethod
	}
}

