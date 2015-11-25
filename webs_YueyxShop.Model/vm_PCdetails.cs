/**  版本信息模板在安装目录下，可自行修改。
* vm_PCdetails.cs
*
* 功 能： N/A
* 类 名： vm_PCdetails
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/19 13:53:58   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace webs_YueyxShop.Model
{
	/// <summary>
	/// vm_PCdetails:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class vm_PCdetails
	{
		public vm_PCdetails()
		{}
		#region Model
		private string _m_username;
		private string _m_nickname;
		private string _m_realname;
		private Guid _sku_modifyby;
		private int? _p_id;
		private decimal _sku_price;
		private decimal? _sku_costprice;
		private int? _sku_stock;
		private int _sku_salescount;
		private string _sku_code;
		private DateTime _sku_createdon;
		private Guid _sku_createdby;
		private DateTime _sku_modifyon;
		private int _sku_statuscode;
		private bool _sku_isdel;
		private string _p_name;
		private int _p_sort;
		private string _p_measurementunit;
		private int? _p_province;
		private int? _p_city;
		private int? _p_county;
		private DateTime _p_createdon;
		private DateTime _p_modifyon;
		private Guid _p_createdby;
		private Guid _p_modifyby;
		private int _p_statuscode;
		private bool _p_isdel;
		private int _p_sellstatus;
		private int? _ct_id;
		private int? _pt_id;
		private string _m_password;
		private int? _m_usertype;
		private string _m_yingyzz;
		private int? _m_score;
		private int? _m_rank;
		private int _m_sex;
		private DateTime? _m_birthday;
		private string _m_phone;
		private string _m_email;
		private string _m_qq;
		private DateTime _m_createdon;
		private decimal? _m_zhek;
		private int _m_statuscode;
		private int _m_shenpstatus;
		private int _pc_id;
		private int? _sku_id;
		private DateTime _pc_createdon;
		private string _pc_type;
		private string _pc_content;
		private int? _pc_createdby;
		private int _pc_statuscode;
        private int _pc_huifu;
		private bool _pc_isdel;
		/// <summary>
		/// 
		/// </summary>
		public string m_UserName
		{
			set{ _m_username=value;}
			get{return _m_username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string m_NickName
		{
			set{ _m_nickname=value;}
			get{return _m_nickname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string m_RealName
		{
			set{ _m_realname=value;}
			get{return _m_realname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid sku_ModifyBy
		{
			set{ _sku_modifyby=value;}
			get{return _sku_modifyby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? p_ID
		{
			set{ _p_id=value;}
			get{return _p_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal sku_Price
		{
			set{ _sku_price=value;}
			get{return _sku_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? sku_CostPrice
		{
			set{ _sku_costprice=value;}
			get{return _sku_costprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sku_Stock
		{
			set{ _sku_stock=value;}
			get{return _sku_stock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int sku_SalesCount
		{
			set{ _sku_salescount=value;}
			get{return _sku_salescount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sku_Code
		{
			set{ _sku_code=value;}
			get{return _sku_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime sku_CreatedOn
		{
			set{ _sku_createdon=value;}
			get{return _sku_createdon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid sku_CreatedBy
		{
			set{ _sku_createdby=value;}
			get{return _sku_createdby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime sku_ModifyOn
		{
			set{ _sku_modifyon=value;}
			get{return _sku_modifyon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int sku_StatusCode
		{
			set{ _sku_statuscode=value;}
			get{return _sku_statuscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool sku_IsDel
		{
			set{ _sku_isdel=value;}
			get{return _sku_isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string p_Name
		{
			set{ _p_name=value;}
			get{return _p_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int p_Sort
		{
			set{ _p_sort=value;}
			get{return _p_sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string p_MeasurementUnit
		{
			set{ _p_measurementunit=value;}
			get{return _p_measurementunit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? p_Province
		{
			set{ _p_province=value;}
			get{return _p_province;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? p_City
		{
			set{ _p_city=value;}
			get{return _p_city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? p_County
		{
			set{ _p_county=value;}
			get{return _p_county;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime p_CreatedOn
		{
			set{ _p_createdon=value;}
			get{return _p_createdon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime p_ModifyOn
		{
			set{ _p_modifyon=value;}
			get{return _p_modifyon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid p_CreatedBy
		{
			set{ _p_createdby=value;}
			get{return _p_createdby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid p_ModifyBy
		{
			set{ _p_modifyby=value;}
			get{return _p_modifyby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int p_StatusCode
		{
			set{ _p_statuscode=value;}
			get{return _p_statuscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool p_IsDel
		{
			set{ _p_isdel=value;}
			get{return _p_isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int p_SellStatus
		{
			set{ _p_sellstatus=value;}
			get{return _p_sellstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ct_ID
		{
			set{ _ct_id=value;}
			get{return _ct_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pt_ID
		{
			set{ _pt_id=value;}
			get{return _pt_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string m_Password
		{
			set{ _m_password=value;}
			get{return _m_password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? m_UserType
		{
			set{ _m_usertype=value;}
			get{return _m_usertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string m_YingYZZ
		{
			set{ _m_yingyzz=value;}
			get{return _m_yingyzz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? m_Score
		{
			set{ _m_score=value;}
			get{return _m_score;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? m_Rank
		{
			set{ _m_rank=value;}
			get{return _m_rank;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int m_Sex
		{
			set{ _m_sex=value;}
			get{return _m_sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? m_Birthday
		{
			set{ _m_birthday=value;}
			get{return _m_birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string m_Phone
		{
			set{ _m_phone=value;}
			get{return _m_phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string m_Email
		{
			set{ _m_email=value;}
			get{return _m_email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string m_QQ
		{
			set{ _m_qq=value;}
			get{return _m_qq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime m_CreatedOn
		{
			set{ _m_createdon=value;}
			get{return _m_createdon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? m_ZheK
		{
			set{ _m_zhek=value;}
			get{return _m_zhek;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int m_StatusCode
		{
			set{ _m_statuscode=value;}
			get{return _m_statuscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int m_ShenPstatus
		{
			set{ _m_shenpstatus=value;}
			get{return _m_shenpstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int pc_ID
		{
			set{ _pc_id=value;}
			get{return _pc_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sku_ID
		{
			set{ _sku_id=value;}
			get{return _sku_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime pc_CreatedOn
		{
			set{ _pc_createdon=value;}
			get{return _pc_createdon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pc_Type
		{
			set{ _pc_type=value;}
			get{return _pc_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pc_Content
		{
			set{ _pc_content=value;}
			get{return _pc_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pc_CreatedBy
		{
			set{ _pc_createdby=value;}
			get{return _pc_createdby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int pc_StatusCode
		{
			set{ _pc_statuscode=value;}
			get{return _pc_statuscode;}
		}
        public int pc_huifu
		{
            set
            {
                _pc_huifu= value;
            }
            get { return _pc_huifu; }
		}
		/// <summary>
		/// 
		/// </summary>
		public bool pc_IsDel
		{
			set{ _pc_isdel=value;}
			get{return _pc_isdel;}
		}
		#endregion Model

	}
}

