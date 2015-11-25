/**  版本信息模板在安装目录下，可自行修改。
* vm_GBDetails.cs
*
* 功 能： N/A
* 类 名： vm_GBDetails
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/21 11:14:06   N/A    初版
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
	/// vm_GBDetails:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class vm_GBDetails
	{
		public vm_GBDetails()
		{}
		#region Model
		private int _p_id;
		private int? _pt_id;
		private string _p_name;
		private int _p_sort;
		private string _p_measurementunit;
		private int? _p_province;
		private int? _p_city;
		private int? _p_county;
		private DateTime _p_createdon;
		private Guid _p_createdby;
		private DateTime _p_modifyon;
		private Guid _p_modifyby;
		private int _p_statuscode;
		private bool _p_isdel;
		private int _p_sellstatus;
		private int? _ct_id;
		private string _pi_url;
		private DateTime? _gp_starttime;
		private DateTime? _gp_endtime;
		private int? _gp_pcount;
		private decimal? _gp_ppric;
        private decimal _sku_price;
        private decimal _sku_scprice;
		private decimal? _sku_costprice;
		private int _sku_salescount;
		private int? _sku_stock;
		private bool _sku_isdel;
		private bool _sku_ismoren;
		private string _sku_code;
		private int _sku_id;
		private string _shuxing;
		private int? _b_id;
		private bool _gp_isdel;
		private int _gp_statuscode;
		private string _gp_logo;
		private string _gp_slogan;
		private int? _gp_salecount;
        private int _gp_ID;
        private int _pinglun;

        public int pinglun
        {
            set { _pinglun = value; }
            get { return _pinglun; }
        }
        public int gp_ID
        {
            set { _gp_ID = value; }
            get { return _gp_ID; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int p_ID
		{
			set{ _p_id=value;}
			get{return _p_id;}
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
		public Guid p_CreatedBy
		{
			set{ _p_createdby=value;}
			get{return _p_createdby;}
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
		public string pi_Url
		{
			set{ _pi_url=value;}
			get{return _pi_url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? gp_StartTime
		{
			set{ _gp_starttime=value;}
			get{return _gp_starttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? gp_EndTime
		{
			set{ _gp_endtime=value;}
			get{return _gp_endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? gp_pCount
		{
			set{ _gp_pcount=value;}
			get{return _gp_pcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? gp_pPric
		{
			set{ _gp_ppric=value;}
			get{return _gp_ppric;}
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
        public decimal sku_scPrice
        {
            set { _sku_scprice = value; }
            get { return _sku_scprice; }
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
		public int sku_SalesCount
		{
			set{ _sku_salescount=value;}
			get{return _sku_salescount;}
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
		public bool sku_IsDel
		{
			set{ _sku_isdel=value;}
			get{return _sku_isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool sku_ismoren
		{
			set{ _sku_ismoren=value;}
			get{return _sku_ismoren;}
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
		public int sku_ID
		{
			set{ _sku_id=value;}
			get{return _sku_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string shuxing
		{
			set{ _shuxing=value;}
			get{return _shuxing;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? b_ID
		{
			set{ _b_id=value;}
			get{return _b_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool gp_IsDel
		{
			set{ _gp_isdel=value;}
			get{return _gp_isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int gp_StatusCode
		{
			set{ _gp_statuscode=value;}
			get{return _gp_statuscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string gp_Logo
		{
			set{ _gp_logo=value;}
			get{return _gp_logo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string gp_Slogan
		{
			set{ _gp_slogan=value;}
			get{return _gp_slogan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? gp_SaleCount
		{
			set{ _gp_salecount=value;}
			get{return _gp_salecount;}
		}
		#endregion Model

	}
}

