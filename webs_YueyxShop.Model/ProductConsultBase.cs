/**  版本信息模板在安装目录下，可自行修改。
* ProductConsultBase.cs
*
* 功 能： N/A
* 类 名： ProductConsultBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/14 11:31:51   N/A    初版
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
	/// 商品咨询信息表
	/// </summary>
	[Serializable]
	public partial class ProductConsultBase
	{
		public ProductConsultBase()
		{}
		#region Model
		private int _pc_id;
        private int? _sku_id;
        private int? _m_id;
		private DateTime _pc_createdon= DateTime.Now;
		private string _pc_type;
		private string _pc_content;
		private int? _pc_createdby;
		private int _pc_statuscode=0;
        private int _pc_huifu = 0;
		private bool _pc_isdel= false;
		/// <summary>
		/// 商品咨询主键
		/// </summary>
		public int pc_ID
		{
			set{ _pc_id=value;}
			get{return _pc_id;}
		}
		/// <summary>
		/// sku主键
		/// </summary>
		public int? sku_ID
		{
			set{ _sku_id=value;}
			get{return _sku_id;}
		}
		/// <summary>
		/// 咨询时间
		/// </summary>
		public DateTime pc_CreatedOn
		{
			set{ _pc_createdon=value;}
			get{return _pc_createdon;}
		}
		/// <summary>
		/// 咨询分类
		/// </summary>
		public string pc_Type
		{
			set{ _pc_type=value;}
			get{return _pc_type;}
		}
		/// <summary>
		/// 咨询内容
		/// </summary>
		public string pc_Content
		{
			set{ _pc_content=value;}
			get{return _pc_content;}
		}
		/// <summary>
        /// 会员主键
		/// </summary>
		public int? pc_CreatedBy
		{
			set{ _pc_createdby=value;}
			get{return _pc_createdby;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int pc_StatusCode
		{
			set{ _pc_statuscode=value;}
			get{return _pc_statuscode;}
		}
        public int pc_huifu
		{
            set { _pc_huifu = value; }
            get { return _pc_huifu; }
		}
		/// <summary>
		/// 删除
		/// </summary>
		public bool pc_IsDel
		{
			set{ _pc_isdel=value;}
			get{return _pc_isdel;}
		}
        public ProductReplyBase preply
        { get; set; }
        public MemberBase member
        { get; set; }
		#endregion Model

	}
}

