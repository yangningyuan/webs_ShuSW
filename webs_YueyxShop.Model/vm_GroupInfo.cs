/**  版本信息模板在安装目录下，可自行修改。
* vm_GroupInfo.cs
*
* 功 能： N/A
* 类 名： vm_GroupInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/18 11:46:09   N/A    初版
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
	/// vm_GroupInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class vm_GroupInfo
	{
		public vm_GroupInfo()
		{}
		#region Model
		private int _gp_id;
		private DateTime? _gp_starttime;
		private DateTime? _gp_endtime;
		private int? _gp_pcount;
		private decimal? _gp_ppric;
		private DateTime _gp_createon;
		private Guid _gp_createby;
		private int _gp_statuscode;
		private bool _gp_isdel;
		private string _gp_slogan;
		private string _gp_logo;
		private int? _gp_salecount;
		private int _sku_id;
		private decimal _sku_price;
		private decimal? _sku_costprice;
		private string _sku_code;
		private int _p_id;
		private string _p_name;
		private bool _sku_isdel;
		private int _sku_statuscode;
		private bool _p_isdel;
		private int _p_sellstatus;
        private int _p_statusCode;
		/// <summary>
		/// 
		/// </summary>
		public int gp_ID
		{
			set{ _gp_id=value;}
			get{return _gp_id;}
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
		public DateTime gp_CreateOn
		{
			set{ _gp_createon=value;}
			get{return _gp_createon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid gp_CreateBy
		{
			set{ _gp_createby=value;}
			get{return _gp_createby;}
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
		public bool gp_IsDel
		{
			set{ _gp_isdel=value;}
			get{return _gp_isdel;}
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
		public string gp_Logo
		{
			set{ _gp_logo=value;}
			get{return _gp_logo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? gp_SaleCount
		{
			set{ _gp_salecount=value;}
			get{return _gp_salecount;}
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
		public string sku_Code
		{
			set{ _sku_code=value;}
			get{return _sku_code;}
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
		public string p_Name
		{
			set{ _p_name=value;}
			get{return _p_name;}
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
		public int sku_StatusCode
		{
			set{ _sku_statuscode=value;}
			get{return _sku_statuscode;}
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
        public int p_StatusCode
		{
            set { _p_statusCode = value; }
            get { return _p_statusCode; }
		}
		#endregion Model

	}
}

