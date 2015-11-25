/**  版本信息模板在安装目录下，可自行修改。
* ProductReplyBase.cs
*
* 功 能： N/A
* 类 名： ProductReplyBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/14 11:31:52   N/A    初版
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
	/// 商品资讯回复明细
	/// </summary>
	[Serializable]
	public partial class ProductReplyBase
	{
		public ProductReplyBase()
		{}
		#region Model
		private int _pr_id;
		private int? _pc_id;
		private string _pr_content;
		private Guid _pr_createdby;
		private DateTime _pr_createdon= DateTime.Now;
		private int _pr_statuscode=0;
		private bool _pr_isdel= false;
		/// <summary>
		/// 回复主键
		/// </summary>
		public int pr_ID
		{
			set{ _pr_id=value;}
			get{return _pr_id;}
		}
		/// <summary>
		/// 商品咨询主键
		/// </summary>
		public int? pc_ID
		{
			set{ _pc_id=value;}
			get{return _pc_id;}
		}
		/// <summary>
		/// 回复内容
		/// </summary>
		public string pr_Content
		{
			set{ _pr_content=value;}
			get{return _pr_content;}
		}
		/// <summary>
		/// 回复人
		/// </summary>
		public Guid pr_CreatedBy
		{
			set{ _pr_createdby=value;}
			get{return _pr_createdby;}
		}
		/// <summary>
		/// 回复时间
		/// </summary>
		public DateTime pr_CreatedOn
		{
			set{ _pr_createdon=value;}
			get{return _pr_createdon;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int pr_StatusCode
		{
			set{ _pr_statuscode=value;}
			get{return _pr_statuscode;}
		}
		/// <summary>
		/// 删除
		/// </summary>
		public bool pr_IsDel
		{
			set{ _pr_isdel=value;}
			get{return _pr_isdel;}
		}
		#endregion Model

	}
}

