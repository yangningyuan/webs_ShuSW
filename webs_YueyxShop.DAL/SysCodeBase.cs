/**  版本信息模板在安装目录下，可自行修改。
* SysCodeBase.cs
*
* 功 能： N/A
* 类 名： SysCodeBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/28 14:36:10   N/A    初版
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
	/// 数据访问类:SysCodeBase
	/// </summary>
	public partial class SysCodeBase:ISysCodeBase
	{
		public SysCodeBase()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid sc_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SysCodeBase");
			strSql.Append(" where sc_ID=@sc_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sc_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = sc_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(webs_YueyxShop.Model.SysCodeBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SysCodeBase(");
			strSql.Append("sc_ID,sc_BianM,sc_MingCh,sc_CengJ,sc_ParentId,sc_CreatedBy,sc_CreatedOn,sc_StateCode,sc_DeleteStateCode,sc_LeiB,sc_SuoSMK)");
			strSql.Append(" values (");
			strSql.Append("@sc_ID,@sc_BianM,@sc_MingCh,@sc_CengJ,@sc_ParentId,@sc_CreatedBy,@sc_CreatedOn,@sc_StateCode,@sc_DeleteStateCode,@sc_LeiB,@sc_SuoSMK)");
			SqlParameter[] parameters = {
					new SqlParameter("@sc_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@sc_BianM", SqlDbType.VarChar,30),
					new SqlParameter("@sc_MingCh", SqlDbType.NVarChar,20),
					new SqlParameter("@sc_CengJ", SqlDbType.Int,4),
					new SqlParameter("@sc_ParentId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@sc_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@sc_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@sc_StateCode", SqlDbType.Int,4),
					new SqlParameter("@sc_DeleteStateCode", SqlDbType.Int,4),
					new SqlParameter("@sc_LeiB", SqlDbType.SmallInt,2),
					new SqlParameter("@sc_SuoSMK", SqlDbType.NVarChar,50)};
			parameters[0].Value = Guid.NewGuid();
			parameters[1].Value = model.sc_BianM;
			parameters[2].Value = model.sc_MingCh;
			parameters[3].Value = model.sc_CengJ;
			parameters[4].Value = model.sc_ParentId;
			parameters[5].Value = model.sc_CreatedBy;
			parameters[6].Value = model.sc_CreatedOn;
			parameters[7].Value = model.sc_StateCode;
			parameters[8].Value = model.sc_DeleteStateCode;
			parameters[9].Value = model.sc_LeiB;
			parameters[10].Value = model.sc_SuoSMK;

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
		public bool Update(webs_YueyxShop.Model.SysCodeBase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SysCodeBase set ");
			strSql.Append("sc_BianM=@sc_BianM,");
			strSql.Append("sc_MingCh=@sc_MingCh,");
			strSql.Append("sc_CengJ=@sc_CengJ,");
			strSql.Append("sc_ParentId=@sc_ParentId,");
			strSql.Append("sc_CreatedBy=@sc_CreatedBy,");
			strSql.Append("sc_CreatedOn=@sc_CreatedOn,");
			strSql.Append("sc_StateCode=@sc_StateCode,");
			strSql.Append("sc_DeleteStateCode=@sc_DeleteStateCode,");
			strSql.Append("sc_LeiB=@sc_LeiB,");
			strSql.Append("sc_SuoSMK=@sc_SuoSMK");
			strSql.Append(" where sc_ID=@sc_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sc_BianM", SqlDbType.VarChar,30),
					new SqlParameter("@sc_MingCh", SqlDbType.NVarChar,20),
					new SqlParameter("@sc_CengJ", SqlDbType.Int,4),
					new SqlParameter("@sc_ParentId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@sc_CreatedBy", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@sc_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@sc_StateCode", SqlDbType.Int,4),
					new SqlParameter("@sc_DeleteStateCode", SqlDbType.Int,4),
					new SqlParameter("@sc_LeiB", SqlDbType.SmallInt,2),
					new SqlParameter("@sc_SuoSMK", SqlDbType.NVarChar,50),
					new SqlParameter("@sc_ID", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.sc_BianM;
			parameters[1].Value = model.sc_MingCh;
			parameters[2].Value = model.sc_CengJ;
			parameters[3].Value = model.sc_ParentId;
			parameters[4].Value = model.sc_CreatedBy;
			parameters[5].Value = model.sc_CreatedOn;
			parameters[6].Value = model.sc_StateCode;
			parameters[7].Value = model.sc_DeleteStateCode;
			parameters[8].Value = model.sc_LeiB;
			parameters[9].Value = model.sc_SuoSMK;
			parameters[10].Value = model.sc_ID;

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
		public bool Delete(Guid sc_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SysCodeBase ");
			strSql.Append(" where sc_ID=@sc_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sc_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = sc_ID;

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
		public bool DeleteList(string sc_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SysCodeBase ");
			strSql.Append(" where sc_ID in ("+sc_IDlist + ")  ");
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
		public webs_YueyxShop.Model.SysCodeBase GetModel(Guid sc_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sc_ID,sc_BianM,sc_MingCh,sc_CengJ,sc_ParentId,sc_CreatedBy,sc_CreatedOn,sc_StateCode,sc_DeleteStateCode,sc_LeiB,sc_SuoSMK from SysCodeBase ");
			strSql.Append(" where sc_ID=@sc_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@sc_ID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = sc_ID;

			webs_YueyxShop.Model.SysCodeBase model=new webs_YueyxShop.Model.SysCodeBase();
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
		public webs_YueyxShop.Model.SysCodeBase DataRowToModel(DataRow row)
		{
			webs_YueyxShop.Model.SysCodeBase model=new webs_YueyxShop.Model.SysCodeBase();
			if (row != null)
			{
				if(row["sc_ID"]!=null && row["sc_ID"].ToString()!="")
				{
					model.sc_ID= new Guid(row["sc_ID"].ToString());
				}
				if(row["sc_BianM"]!=null)
				{
					model.sc_BianM=row["sc_BianM"].ToString();
				}
				if(row["sc_MingCh"]!=null)
				{
					model.sc_MingCh=row["sc_MingCh"].ToString();
				}
				if(row["sc_CengJ"]!=null && row["sc_CengJ"].ToString()!="")
				{
					model.sc_CengJ=int.Parse(row["sc_CengJ"].ToString());
				}
				if(row["sc_ParentId"]!=null && row["sc_ParentId"].ToString()!="")
				{
					model.sc_ParentId= new Guid(row["sc_ParentId"].ToString());
				}
				if(row["sc_CreatedBy"]!=null && row["sc_CreatedBy"].ToString()!="")
				{
					model.sc_CreatedBy= new Guid(row["sc_CreatedBy"].ToString());
				}
				if(row["sc_CreatedOn"]!=null && row["sc_CreatedOn"].ToString()!="")
				{
					model.sc_CreatedOn=DateTime.Parse(row["sc_CreatedOn"].ToString());
				}
				if(row["sc_StateCode"]!=null && row["sc_StateCode"].ToString()!="")
				{
					model.sc_StateCode=int.Parse(row["sc_StateCode"].ToString());
				}
				if(row["sc_DeleteStateCode"]!=null && row["sc_DeleteStateCode"].ToString()!="")
				{
					model.sc_DeleteStateCode=int.Parse(row["sc_DeleteStateCode"].ToString());
				}
				if(row["sc_LeiB"]!=null && row["sc_LeiB"].ToString()!="")
				{
					model.sc_LeiB=int.Parse(row["sc_LeiB"].ToString());
				}
				if(row["sc_SuoSMK"]!=null)
				{
					model.sc_SuoSMK=row["sc_SuoSMK"].ToString();
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
			strSql.Append("select sc_ID,sc_BianM,sc_MingCh,sc_CengJ,sc_ParentId,sc_CreatedBy,sc_CreatedOn,sc_StateCode,sc_DeleteStateCode,sc_LeiB,sc_SuoSMK ");
			strSql.Append(" FROM SysCodeBase ");
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
			strSql.Append(" sc_ID,sc_BianM,sc_MingCh,sc_CengJ,sc_ParentId,sc_CreatedBy,sc_CreatedOn,sc_StateCode,sc_DeleteStateCode,sc_LeiB,sc_SuoSMK ");
			strSql.Append(" FROM SysCodeBase ");
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
			strSql.Append("select count(1) FROM SysCodeBase ");
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
				strSql.Append("order by T.sc_ID desc");
			}
			strSql.Append(")AS Row, T.*  from SysCodeBase T ");
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
			parameters[0].Value = "SysCodeBase";
			parameters[1].Value = "sc_ID";
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
        /// 获取编码
        /// </summary>
        /// <param name="CengJ">当前层级</param>
        /// <param name="BianM">父级编码</param>
        public string GetCode(int CengJ, string BianM)
        {
            StringBuilder str = new StringBuilder();
            string ReturnCode = "", Number0 = "";
            if (CengJ == 1)
            {//第一级
                str.AppendFormat("select top 1 * from SysCodeBase where sc_CengJ=1 and sc_DeleteStateCode=0 and sc_ParentId='00000000-0000-0000-0000-000000000000' order by sc_CreatedOn desc");
                DataTable dt = DbHelperSQL.Query(str.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["sc_BianM"].ToString()))
                    {
                        int Number = Convert.ToInt32(dt.Rows[0]["sc_BianM"].ToString()) + 1;
                        for (int i = 0; i < 4 - Number.ToString().Length; i++)
                        {
                            Number0 += "0";
                        }
                        ReturnCode = Number0 + Number.ToString();
                    }
                }
                else
                    ReturnCode = "0001";
            }
            else
            { //子级
                str.AppendFormat("select top 1 *  from SysCodeBase where sc_BianM like'{0}%' and sc_CengJ={1} and sc_DeleteStateCode=0 order by sc_CreatedOn desc", BianM, CengJ);
                DataTable dt = DbHelperSQL.Query(str.ToString()).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["sc_BianM"].ToString()))
                    {
                        int Number = Convert.ToInt32(dt.Rows[0]["sc_BianM"].ToString().Substring(BianM.Length, 4)) + 1;
                        for (int i = 0; i < 4 - Number.ToString().Length; i++)
                        {
                            Number0 += "0";
                        }
                        ReturnCode = BianM + Number0 + Number.ToString();
                    }
                }
                else
                    ReturnCode = BianM + "0001";
            }
            return ReturnCode;
        }
		#endregion  ExtensionMethod
	}
}

