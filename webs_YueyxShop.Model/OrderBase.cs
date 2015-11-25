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
namespace webs_YueyxShop.Model
{
	/// <summary>
	/// OrderBase:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrderBase
	{
		public OrderBase()
		{}
		#region Model
		private int _o_id;
		private int? _c_id;
		private int? _m_id;
		private string _o_code;
		private DateTime? _o_createon;
		private decimal? _o_pric;
		private int? _o_statuscode;
		private string _o_mark;
		private bool _o_isdel;
		private int? _pay_id;
		private int? _st_id;
		private string _o_alipayno;
		private string _o_logisticsno;
		private int? _o_score;
		private decimal? _o_zhek;
		/// <summary>
		/// 
		/// </summary>
		public int o_ID
		{
			set{ _o_id=value;}
			get{return _o_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? c_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? m_ID
		{
			set{ _m_id=value;}
			get{return _m_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string o_Code
		{
			set{ _o_code=value;}
			get{return _o_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? o_CreateOn
		{
			set{ _o_createon=value;}
			get{return _o_createon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? o_Pric
		{
			set{ _o_pric=value;}
			get{return _o_pric;}
		}
        public decimal? o_Zhek
		{
            set { _o_zhek = value; }
            get { return _o_zhek; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? o_StatusCode
		{
			set{ _o_statuscode=value;}
			get{return _o_statuscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string o_Mark
		{
			set{ _o_mark=value;}
			get{return _o_mark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool o_IsDel
		{
			set{ _o_isdel=value;}
			get{return _o_isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pay_ID
		{
			set{ _pay_id=value;}
			get{return _pay_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? st_ID
		{
			set{ _st_id=value;}
			get{return _st_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string o_AlipayNo
		{
			set{ _o_alipayno=value;}
			get{return _o_alipayno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string o_LogisticsNo
		{
			set{ _o_logisticsno=value;}
			get{return _o_logisticsno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? o_Score
		{
			set{ _o_score=value;}
			get{return _o_score;}
		}
        public Model.RejectionBase rejorder
        { get; set; }
		#endregion Model

	}
}

