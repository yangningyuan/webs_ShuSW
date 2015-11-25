/**  版本信息模板在安装目录下，可自行修改。
* vm_GPDetails.cs
*
* 功 能： N/A
* 类 名： vm_GPDetails
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/14 9:22:03   N/A    初版
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
	/// vm_GPDetails:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class vm_GPDetails
	{
		public vm_GPDetails()
		{}
		#region Model
		private int _gp_id;
		private int? _p_id;
		private DateTime? _gp_starttime;
		private DateTime? _gp_endtime;
		private int? _gp_pcount;
		private decimal? _gp_ppric;
		private DateTime _gp_createon;
		private Guid _gp_createby;
		private int _gp_statuscode;
		private bool _gp_isdel;
        private string _p_name;
        private string _gp_Slogan;
        private string _gp_Logo;
        private int _gp_SaleCount;
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
		public int? p_ID
		{
			set{ _p_id=value;}
			get{return _p_id;}
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
		public string p_Name
		{
			set{ _p_name=value;}
			get{return _p_name;}
		}

        public string gp_Slogan
        {
            set { _gp_Slogan = value; }
            get { return _gp_Slogan; }
        }

        public string gp_Logo
        {
            set { _gp_Logo = value; }
            get { return _gp_Logo; }
        }

        public int gp_SaleCount
        {
            set { _gp_SaleCount = value; }
            get { return _gp_SaleCount; }
        }
		#endregion Model

	}
}

