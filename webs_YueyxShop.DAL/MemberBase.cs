using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using webs_YueyxShop.IDAL;
using System.Data;
using System.Data.SqlClient;
using DBUtility;
namespace webs_YueyxShop.DAL
{
    /// <summary>
    /// 数据访问类:MemberBase
    /// </summary>
    public partial class MemberBase : IMemberBase
    {
        public MemberBase()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int m_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from MemberBase");
            strSql.Append(" where m_ID=@m_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = m_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public Model.MemberInfo getMemberInfo(int m_id)
        {
            string sql = "SELECT (SELECT COUNT(*) AS Expr1 FROM  dbo.ConsigneeInfoBase AS A	WHERE  (m_ID = dbo.MemberBase.m_ID) AND (c_IsDel = 0)) AS addcount,	VipRank.r_Name, "
                + "(SELECT     COUNT(*) AS Expr1 "
                + "    FROM          dbo.ProductAppraiseBase AS B "
                + "WHERE      (pa_IsDel = 0) AND (m_ID = dbo.MemberBase.m_ID)) AS pacount, (SELECT     COUNT(*) AS Expr2 "
                + "    FROM          dbo.VipCollectionBase AS C "
                + "WHERE      (vc_IsDel = 0) AND (m_ID = dbo.MemberBase.m_ID)) AS VCcount, (SELECT     COUNT(*) AS Expr3 "
                + "    FROM          dbo.OrderBase AS D "
                + "WHERE      (o_IsDel = 0) AND (o_StatusCode=0) AND (m_ID = dbo.MemberBase.m_ID)) AS Ocount, "

                + "dbo.MemberBase.* "
                + "FROM  dbo.MemberBase ,VipRank "
                + "WHERE memberbase.m_StatusCode=0 and VipRank.r_Rank=MemberBase.m_Rank and MemberBase.m_ID=" + m_id;
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModelInfo(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public Model.MemberInfo DataRowToModelInfo(DataRow row)
        {
            Model.MemberInfo model = new Model.MemberInfo();
            if (row != null)
            {
                if (row["m_ID"] != null && row["m_ID"].ToString() != "")
                {
                    model.m_ID = int.Parse(row["m_ID"].ToString());
                }
                if (row["pacount"] != null && row["pacount"].ToString() != "")
                {
                    model.pacount = int.Parse(row["pacount"].ToString());
                }
                if (row["addcount"] != null && row["addcount"].ToString() != "")
                {
                    model.addcount = int.Parse(row["addcount"].ToString());
                }
                if (row["r_Name"] != null)
                {
                    model.r_Name = row["r_Name"].ToString();
                }
                if (row["m_UserName"] != null)
                {
                    model.m_UserName = row["m_UserName"].ToString();
                }
                if (row["m_Password"] != null)
                {
                    model.m_Password = row["m_Password"].ToString();
                }
                if (row["m_UserType"] != null && row["m_UserType"].ToString() != "")
                {
                    model.m_UserType = int.Parse(row["m_UserType"].ToString());
                }
                if (row["m_YingYZZ"] != null)
                {
                    model.m_YingYZZ = row["m_YingYZZ"].ToString();
                }
                if (row["m_Score"] != null && row["m_Score"].ToString() != "")
                {
                    model.m_Score = int.Parse(row["m_Score"].ToString());
                }
                if (row["m_Rank"] != null && row["m_Rank"].ToString() != "")
                {
                    model.m_Rank = int.Parse(row["m_Rank"].ToString());
                }
                if (row["m_NickName"] != null)
                {
                    model.m_NickName = row["m_NickName"].ToString();
                }
                if (row["m_RealName"] != null)
                {
                    model.m_RealName = row["m_RealName"].ToString();
                }
                if (row["m_Sex"] != null && row["m_Sex"].ToString() != "")
                {
                    model.m_Sex = int.Parse(row["m_Sex"].ToString());
                }
                if (row["m_Birthday"] != null && row["m_Birthday"].ToString() != "")
                {
                    model.m_Birthday = DateTime.Parse(row["m_Birthday"].ToString());
                }
                if (row["m_Phone"] != null)
                {
                    model.m_Phone = row["m_Phone"].ToString();
                }
                if (row["m_Email"] != null)
                {
                    model.m_Email = row["m_Email"].ToString();
                }
                if (row["m_QQ"] != null)
                {
                    model.m_QQ = row["m_QQ"].ToString();
                }
                if (row["m_CreatedOn"] != null && row["m_CreatedOn"].ToString() != "")
                {
                    model.m_CreatedOn = DateTime.Parse(row["m_CreatedOn"].ToString());
                }
                if (row["m_ZheK"] != null && row["m_ZheK"].ToString() != "")
                {
                    model.m_ZheK = decimal.Parse(row["m_ZheK"].ToString());
                }
                if (row["m_StatusCode"] != null && row["m_StatusCode"].ToString() != "")
                {
                    model.m_StatusCode = int.Parse(row["m_StatusCode"].ToString());
                }
                if (row["m_ShenPstatus"] != null && row["m_ShenPstatus"].ToString() != "")
                {
                    model.m_ShenPstatus = int.Parse(row["m_ShenPstatus"].ToString());
                }
                if (row["m_GDPhone"] != null && row["m_GDPhone"].ToString() != "")
                {
                    model.m_GDPhone = row["m_GDPhone"].ToString();
                }
                if (row["m_Introduction"] != null && row["m_Introduction"].ToString() != "")
                {
                    model.m_Introduction = row["m_Introduction"].ToString();
                }
                if (row["m_GongSiName"] != null && row["m_GongSiName"].ToString() != "")
                {
                    model.m_GongSiName = row["m_GongSiName"].ToString();
                }
                if (row["m_GongSiDiQu"] != null && row["m_GongSiDiQu"].ToString() != "")
                {
                    model.m_GongSiDiQu = row["m_GongSiDiQu"].ToString();
                }
                if (row["m_GongSiAddress"] != null && row["m_GongSiAddress"].ToString() != "")
                {
                    model.m_GongSiAddress = row["m_GongSiAddress"].ToString();
                }
                if (row["m_CloseDate"] != null && row["m_CloseDate"].ToString() != "")
                {
                    model.m_CloseDate = DateTime.Parse(row["m_CloseDate"].ToString());
                }
                if (row["m_HeadImg"] != null && row["m_HeadImg"].ToString() != "")
                {
                    model.m_HeadImg = row["m_HeadImg"].ToString();
                }
                if (row["m_Provice"] != null && row["m_Provice"].ToString() != "")
                {
                    model.m_Provice = int.Parse(row["m_Provice"].ToString());
                }
                if (row["m_City"] != null && row["m_City"].ToString() != "")
                {
                    model.m_City = int.Parse(row["m_City"].ToString());
                }
                if (row["m_Count"] != null && row["m_Count"].ToString() != "")
                {
                    model.m_Count = int.Parse(row["m_Count"].ToString());
                }
                if (row["m_mailyanzheng"] != null)
                {
                    model.m_mailyanzheng = bool.Parse(row["m_mailyanzheng"].ToString());
                }
                if (row["m_ZhiYe"] != null)
                {
                    model.m_ZhiYe = row["m_ZhiYe"].ToString();
                }
                if (row["VCcount"] != null && row["VCcount"].ToString() != "")
                {
                    model.VCcount = int.Parse(row["VCcount"].ToString());
                }
                if (row["Ocount"] != null && row["Ocount"].ToString() != "")
                {
                    model.Ocount = int.Parse(row["Ocount"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.MemberBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MemberBase(");
            strSql.Append("m_UserName,m_Password,m_UserType,m_YingYZZ,m_Score,m_Rank,m_NickName,m_RealName,m_Sex,m_Birthday,m_Phone,m_Email,m_QQ,m_CreatedOn,m_ZheK,m_StatusCode,m_ShenPstatus,m_GDPhone,m_GongSiName,m_GongSiDiQu,m_GongSiAddress,m_CloseDate,m_HeadImg,m_Provice,m_City,m_Count,m_mailyanzheng,m_ZhiYe,m_Introduction)");
            strSql.Append(" values (");
            strSql.Append("@m_UserName,@m_Password,@m_UserType,@m_YingYZZ,@m_Score,@m_Rank,@m_NickName,@m_RealName,@m_Sex,@m_Birthday,@m_Phone,@m_Email,@m_QQ,@m_CreatedOn,@m_ZheK,@m_StatusCode,@m_ShenPstatus,@m_GDPhone,@m_GongSiName,@m_GongSiDiQu,@m_GongSiAddress,@m_CloseDate,@m_HeadImg,@m_Provice,@m_City,@m_Count,@m_mailyanzheng,@m_ZhiYe,@m_Introduction)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@m_UserName", SqlDbType.VarChar,50),
					new SqlParameter("@m_Password", SqlDbType.VarChar,100),
					new SqlParameter("@m_UserType", SqlDbType.Int,4),
					new SqlParameter("@m_YingYZZ", SqlDbType.NVarChar,30),
					new SqlParameter("@m_Score", SqlDbType.Int,4),
					new SqlParameter("@m_Rank", SqlDbType.Int,4),
					new SqlParameter("@m_NickName", SqlDbType.NVarChar,30),
					new SqlParameter("@m_RealName", SqlDbType.NVarChar,20),
					new SqlParameter("@m_Sex", SqlDbType.Int,4),
					new SqlParameter("@m_Birthday", SqlDbType.DateTime),
					new SqlParameter("@m_Phone", SqlDbType.VarChar,50),
					new SqlParameter("@m_Email", SqlDbType.VarChar,100),
					new SqlParameter("@m_QQ", SqlDbType.VarChar,30),
					new SqlParameter("@m_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@m_ZheK", SqlDbType.Decimal,9),
					new SqlParameter("@m_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@m_ShenPstatus", SqlDbType.Int,4),
					new SqlParameter("@m_GDPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@m_GongSiName", SqlDbType.NVarChar,100),
					new SqlParameter("@m_GongSiDiQu", SqlDbType.NVarChar,50),
					new SqlParameter("@m_GongSiAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@m_CloseDate", SqlDbType.DateTime),
					new SqlParameter("@m_HeadImg", SqlDbType.NVarChar,100),
					new SqlParameter("@m_Provice", SqlDbType.Int,4),
					new SqlParameter("@m_City", SqlDbType.Int,4),
					new SqlParameter("@m_Count", SqlDbType.Int,4),
					new SqlParameter("@m_mailyanzheng", SqlDbType.Bit),
					new SqlParameter("@m_ZhiYe", SqlDbType.NVarChar,100),
					new SqlParameter("@m_Introduction", SqlDbType.Text)};
            parameters[0].Value = model.m_UserName;
            parameters[1].Value = model.m_Password;
            parameters[2].Value = model.m_UserType;
            parameters[3].Value = model.m_YingYZZ;
            parameters[4].Value = model.m_Score;
            parameters[5].Value = model.m_Rank;
            parameters[6].Value = model.m_NickName;
            parameters[7].Value = model.m_RealName;
            parameters[8].Value = model.m_Sex;
            parameters[9].Value = model.m_Birthday;
            parameters[10].Value = model.m_Phone;
            parameters[11].Value = model.m_Email;
            parameters[12].Value = model.m_QQ;
            parameters[13].Value = model.m_CreatedOn;
            parameters[14].Value = model.m_ZheK;
            parameters[15].Value = model.m_StatusCode;
            parameters[16].Value = model.m_ShenPstatus;
            parameters[17].Value = model.m_GDPhone;
            parameters[18].Value = model.m_GongSiName;
            parameters[19].Value = model.m_GongSiDiQu;
            parameters[20].Value = model.m_GongSiAddress;
            parameters[21].Value = model.m_CloseDate;
            parameters[22].Value = model.m_HeadImg;
            parameters[23].Value = model.m_Provice;
            parameters[24].Value = model.m_City;
            parameters[25].Value = model.m_Count;
            parameters[26].Value = model.m_mailyanzheng;
            parameters[27].Value = model.m_ZhiYe;
            parameters[27].Value = model.m_Introduction;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Model.MemberBase model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MemberBase set ");
            strSql.Append("m_UserName=@m_UserName,");
            strSql.Append("m_Password=@m_Password,");
            strSql.Append("m_UserType=@m_UserType,");
            strSql.Append("m_YingYZZ=@m_YingYZZ,");
            strSql.Append("m_Score=@m_Score,");
            strSql.Append("m_Rank=@m_Rank,");
            strSql.Append("m_NickName=@m_NickName,");
            strSql.Append("m_RealName=@m_RealName,");
            strSql.Append("m_Sex=@m_Sex,");
            strSql.Append("m_Birthday=@m_Birthday,");
            strSql.Append("m_Phone=@m_Phone,");
            strSql.Append("m_Email=@m_Email,");
            strSql.Append("m_QQ=@m_QQ,");
            strSql.Append("m_CreatedOn=@m_CreatedOn,");
            strSql.Append("m_ZheK=@m_ZheK,");
            strSql.Append("m_StatusCode=@m_StatusCode,");
            strSql.Append("m_ShenPstatus=@m_ShenPstatus,");
            strSql.Append("m_GDPhone=@m_GDPhone,");
            strSql.Append("m_GongSiName=@m_GongSiName,");
            strSql.Append("m_GongSiDiQu=@m_GongSiDiQu,");
            strSql.Append("m_GongSiAddress=@m_GongSiAddress,");
            strSql.Append("m_CloseDate=@m_CloseDate,");
            strSql.Append("m_HeadImg=@m_HeadImg,");
            strSql.Append("m_Provice=@m_Provice,");
            strSql.Append("m_City=@m_City,");
            strSql.Append("m_Count=@m_Count,");
            strSql.Append("m_mailyanzheng=@m_mailyanzheng,");
            strSql.Append("m_ZhiYe=@m_ZhiYe,");
            strSql.Append("m_Introduction=@m_Introduction");
            strSql.Append(" where m_ID=@m_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@m_UserName", SqlDbType.VarChar,50),
					new SqlParameter("@m_Password", SqlDbType.VarChar,100),
					new SqlParameter("@m_UserType", SqlDbType.Int,4),
					new SqlParameter("@m_YingYZZ", SqlDbType.NVarChar,30),
					new SqlParameter("@m_Score", SqlDbType.Int,4),
					new SqlParameter("@m_Rank", SqlDbType.Int,4),
					new SqlParameter("@m_NickName", SqlDbType.NVarChar,30),
					new SqlParameter("@m_RealName", SqlDbType.NVarChar,20),
					new SqlParameter("@m_Sex", SqlDbType.Int,4),
					new SqlParameter("@m_Birthday", SqlDbType.DateTime),
					new SqlParameter("@m_Phone", SqlDbType.VarChar,50),
					new SqlParameter("@m_Email", SqlDbType.VarChar,100),
					new SqlParameter("@m_QQ", SqlDbType.VarChar,30),
					new SqlParameter("@m_CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@m_ZheK", SqlDbType.Decimal,9),
					new SqlParameter("@m_StatusCode", SqlDbType.Int,4),
					new SqlParameter("@m_ShenPstatus", SqlDbType.Int,4),
					new SqlParameter("@m_GDPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@m_GongSiName", SqlDbType.NVarChar,100),
					new SqlParameter("@m_GongSiDiQu", SqlDbType.NVarChar,50),
					new SqlParameter("@m_GongSiAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@m_CloseDate", SqlDbType.DateTime),
					new SqlParameter("@m_HeadImg", SqlDbType.NVarChar,100),
					new SqlParameter("@m_Provice", SqlDbType.Int,4),
					new SqlParameter("@m_City", SqlDbType.Int,4),
					new SqlParameter("@m_Count", SqlDbType.Int,4),
					new SqlParameter("@m_mailyanzheng", SqlDbType.Bit),
					new SqlParameter("@m_ZhiYe", SqlDbType.NVarChar,100),
					new SqlParameter("@m_Introduction", SqlDbType.Text),
					new SqlParameter("@m_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.m_UserName;
            parameters[1].Value = model.m_Password;
            parameters[2].Value = model.m_UserType;
            parameters[3].Value = model.m_YingYZZ;
            parameters[4].Value = model.m_Score;
            parameters[5].Value = model.m_Rank;
            parameters[6].Value = model.m_NickName;
            parameters[7].Value = model.m_RealName;
            parameters[8].Value = model.m_Sex;
            parameters[9].Value = model.m_Birthday;
            parameters[10].Value = model.m_Phone;
            parameters[11].Value = model.m_Email;
            parameters[12].Value = model.m_QQ;
            parameters[13].Value = model.m_CreatedOn;
            parameters[14].Value = model.m_ZheK;
            parameters[15].Value = model.m_StatusCode;
            parameters[16].Value = model.m_ShenPstatus;
            parameters[17].Value = model.m_GDPhone;
            parameters[18].Value = model.m_GongSiName;
            parameters[19].Value = model.m_GongSiDiQu;
            parameters[20].Value = model.m_GongSiAddress;
            parameters[21].Value = model.m_CloseDate;
            parameters[22].Value = model.m_HeadImg;
            parameters[23].Value = model.m_Provice;
            parameters[24].Value = model.m_City;
            parameters[25].Value = model.m_Count;
            parameters[26].Value = model.m_mailyanzheng;
            parameters[27].Value = model.m_ZhiYe;
            parameters[28].Value = model.m_Introduction;
            parameters[29].Value = model.m_ID;

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
        public bool Delete(int m_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MemberBase ");
            strSql.Append(" where m_ID=@m_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = m_ID;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string m_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MemberBase ");
            strSql.Append(" where m_ID in (" + m_IDlist + ")  ");
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.MemberBase GetModel(int m_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from MemberBase ");
            strSql.Append(" where m_ID=@m_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@m_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = m_ID;

            Model.MemberBase model = new Model.MemberBase();
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
        public Model.MemberBase DataRowToModel(DataRow row)
        {
            Model.MemberBase model = new Model.MemberBase();
            if (row != null)
            {
                if (row["m_ID"] != null && row["m_ID"].ToString() != "")
                {
                    model.m_ID = int.Parse(row["m_ID"].ToString());
                }
                if (row["m_UserName"] != null)
                {
                    model.m_UserName = row["m_UserName"].ToString();
                }
                if (row["m_Password"] != null)
                {
                    model.m_Password = row["m_Password"].ToString();
                }
                if (row["m_UserType"] != null && row["m_UserType"].ToString() != "")
                {
                    model.m_UserType = int.Parse(row["m_UserType"].ToString());
                }
                if (row["m_YingYZZ"] != null)
                {
                    model.m_YingYZZ = row["m_YingYZZ"].ToString();
                }
                if (row["m_Score"] != null && row["m_Score"].ToString() != "")
                {
                    model.m_Score = int.Parse(row["m_Score"].ToString());
                }
                if (row["m_Rank"] != null && row["m_Rank"].ToString() != "")
                {
                    model.m_Rank = int.Parse(row["m_Rank"].ToString());
                }
                if (row["m_NickName"] != null)
                {
                    model.m_NickName = row["m_NickName"].ToString();
                }
                if (row["m_RealName"] != null)
                {
                    model.m_RealName = row["m_RealName"].ToString();
                }
                if (row["m_Sex"] != null && row["m_Sex"].ToString() != "")
                {
                    model.m_Sex = int.Parse(row["m_Sex"].ToString());
                }
                if (row["m_Birthday"] != null && row["m_Birthday"].ToString() != "")
                {
                    model.m_Birthday = DateTime.Parse(row["m_Birthday"].ToString());
                }
                if (row["m_Phone"] != null)
                {
                    model.m_Phone = row["m_Phone"].ToString();
                }
                if (row["m_Email"] != null)
                {
                    model.m_Email = row["m_Email"].ToString();
                }
                if (row["m_QQ"] != null)
                {
                    model.m_QQ = row["m_QQ"].ToString();
                }
                if (row["m_CreatedOn"] != null && row["m_CreatedOn"].ToString() != "")
                {
                    model.m_CreatedOn = DateTime.Parse(row["m_CreatedOn"].ToString());
                }
                if (row["m_ZheK"] != null && row["m_ZheK"].ToString() != "")
                {
                    model.m_ZheK = decimal.Parse(row["m_ZheK"].ToString());
                }
                if (row["m_StatusCode"] != null && row["m_StatusCode"].ToString() != "")
                {
                    model.m_StatusCode = int.Parse(row["m_StatusCode"].ToString());
                }
                if (row["m_ShenPstatus"] != null && row["m_ShenPstatus"].ToString() != "")
                {
                    model.m_ShenPstatus = int.Parse(row["m_ShenPstatus"].ToString());
                }
                if (row["m_GDPhone"] != null && row["m_GDPhone"].ToString() != "")
                {
                    model.m_GDPhone = row["m_GDPhone"].ToString();
                }
                if (row["m_GongSiName"] != null && row["m_GongSiName"].ToString() != "")
                {
                    model.m_GongSiName =row["m_GongSiName"].ToString();
                }
                if (row["m_GongSiDiQu"] != null && row["m_GongSiDiQu"].ToString() != "")
                {
                    model.m_GongSiDiQu =row["m_GongSiDiQu"].ToString();
                }
                if (row["m_Introduction"] != null && row["m_Introduction"].ToString() != "")
                {
                    model.m_Introduction = row["m_Introduction"].ToString();
                }
                if (row["m_GongSiAddress"] != null && row["m_GongSiAddress"].ToString() != "")
                {
                    model.m_GongSiAddress = row["m_GongSiAddress"].ToString();
                }
                if (row["m_CloseDate"] != null && row["m_CloseDate"].ToString() != "")
                {
                    model.m_CloseDate = DateTime.Parse(row["m_CloseDate"].ToString());
                }
                if (row["m_HeadImg"] != null && row["m_HeadImg"].ToString() != "")
                {
                    model.m_HeadImg = row["m_HeadImg"].ToString();
                }
                if (row["m_Provice"] != null && row["m_Provice"].ToString() != "")
                {
                    model.m_Provice = int.Parse(row["m_Provice"].ToString());
                }
                if (row["m_City"] != null && row["m_City"].ToString() != "")
                {
                    model.m_City = int.Parse(row["m_City"].ToString());
                }
                if (row["m_Count"] != null && row["m_Count"].ToString() != "")
                {
                    model.m_Count = int.Parse(row["m_Count"].ToString());
                }
                if (row["m_mailyanzheng"] != null)
                {
                    model.m_mailyanzheng = bool.Parse(row["m_mailyanzheng"].ToString());
                }
                if (row["m_ZhiYe"] != null)
                {
                    model.m_ZhiYe = row["m_ZhiYe"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM MemberBase ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM MemberBase ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM MemberBase ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.m_ID desc");
            }
            strSql.Append(")AS Row, T.*  from MemberBase T ");
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
            parameters[0].Value = "MemberBase";
            parameters[1].Value = "m_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
