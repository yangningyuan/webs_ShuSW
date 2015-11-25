/**  版本信息模板在安装目录下，可自行修改。
* VipCollectionBase.cs
*
* 功 能： N/A
* 类 名： VipCollectionBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/26 18:53:37   N/A    初版
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
	/// 收藏夹
	/// </summary>
	[Serializable]
	public partial class VipCollectionBase
	{
		public VipCollectionBase()
		{}
		#region Model
		private int _vc_id;
		private int? _sku_id;
		private int? _m_id;
		private DateTime _vc_createon;
		private bool _vc_isdel;
		/// <summary>
		/// 
		/// </summary>
		public int vc_ID
		{
			set{ _vc_id=value;}
			get{return _vc_id;}
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
		/// 会员主键
		/// </summary>
		public int? m_ID
		{
			set{ _m_id=value;}
			get{return _m_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime vc_CreateOn
		{
			set{ _vc_createon=value;}
			get{return _vc_createon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool vc_IsDel
		{
			set{ _vc_isdel=value;}
			get{return _vc_isdel;}
		}
		#endregion Model

	}
}

