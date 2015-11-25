/**  版本信息模板在安装目录下，可自行修改。
* ProductAppraiseBase.cs
*
* 功 能： N/A
* 类 名： ProductAppraiseBase
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
	/// 商品评价信息
	/// </summary>
	[Serializable]
	public partial class ProductAppraiseBase
	{
		public ProductAppraiseBase()
		{}
		#region Model
		private int _pa_id;
		private int? _m_id;
		private int? _sku_id;
		private int _pa_satisfied=0;
		private string _pa_content;
		private int _pa_praisecount=0;
		private DateTime _pa_createdon= DateTime.Now;
		private int _pa_createdby;
		private int _pa_statuscode=0;
		private bool _pa_isdel= false;
		/// <summary>
		/// 评价主键
		/// </summary>
		public int pa_ID
		{
			set{ _pa_id=value;}
			get{return _pa_id;}
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
		/// sku主键
		/// </summary>
		public int? sku_ID
		{
			set{ _sku_id=value;}
			get{return _sku_id;}
		}
		/// <summary>
		/// 满意度
		/// </summary>
		public int pa_Satisfied
		{
			set{ _pa_satisfied=value;}
			get{return _pa_satisfied;}
		}
		/// <summary>
		/// 评论
		/// </summary>
		public string pa_Content
		{
			set{ _pa_content=value;}
			get{return _pa_content;}
		}
		/// <summary>
		/// 被赞次数
		/// </summary>
		public int pa_PraiseCount
		{
			set{ _pa_praisecount=value;}
			get{return _pa_praisecount;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime pa_CreatedOn
		{
			set{ _pa_createdon=value;}
			get{return _pa_createdon;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public int pa_CreatedBy
		{
			set{ _pa_createdby=value;}
			get{return _pa_createdby;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int pa_StatusCode
		{
			set{ _pa_statuscode=value;}
			get{return _pa_statuscode;}
		}
		/// <summary>
		/// 删除
		/// </summary>
		public bool pa_IsDel
		{
			set{ _pa_isdel=value;}
			get{return _pa_isdel;}
		}
        /// <summary>
        /// 平均满意度
        /// </summary>
        public int pavg
        {
            get;
            set;
        }
        public MemberBase member
        { get; set; }
		#endregion Model

	}
}

