/**  版本信息模板在安装目录下，可自行修改。
* RushPurchaseBase.cs
*
* 功 能： N/A
* 类 名： RushPurchaseBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/14 9:22:02   N/A    初版
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
	/// RushPurchaseBase:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RushPurchaseBase
	{
		public RushPurchaseBase()
		{}
		#region Model
		private int _rp_id;
		private int? _p_id;
		private DateTime? _rp_starttime;
		private DateTime? _rp_endtiime;
		private int? _rp_pcount;
		private decimal? _rp_ppric;
		private DateTime _rp_createon;
		private Guid _rp_createby;
		private int _rp_statuscode;
		private bool _rp_isdel;
		/// <summary>
		/// 
		/// </summary>
		public int rp_ID
		{
			set{ _rp_id=value;}
			get{return _rp_id;}
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
		public DateTime? rp_StartTime
		{
			set{ _rp_starttime=value;}
			get{return _rp_starttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? rp_EndTiime
		{
			set{ _rp_endtiime=value;}
			get{return _rp_endtiime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? rp_pCount
		{
			set{ _rp_pcount=value;}
			get{return _rp_pcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? rp_pPric
		{
			set{ _rp_ppric=value;}
			get{return _rp_ppric;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime rp_CreateOn
		{
			set{ _rp_createon=value;}
			get{return _rp_createon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid rp_CreateBy
		{
			set{ _rp_createby=value;}
			get{return _rp_createby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int rp_StatusCode
		{
			set{ _rp_statuscode=value;}
			get{return _rp_statuscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool rp_isdel
		{
			set{ _rp_isdel=value;}
			get{return _rp_isdel;}
		}
		#endregion Model

	}
}

