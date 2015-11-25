/**  版本信息模板在安装目录下，可自行修改。
* OrderStatusBase.cs
*
* 功 能： N/A
* 类 名： OrderStatusBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/2 14:08:08   N/A    初版
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
	/// 订单状态表
	/// </summary>
	[Serializable]
	public partial class OrderStatusBase
	{
		public OrderStatusBase()
		{}
		#region Model
		private int _os_id;
		private int? _o_id;
		private int _o_status;
		private DateTime _os_modifyon;
		private bool _os_isdel;
		/// <summary>
		/// 
		/// </summary>
		public int os_ID
		{
			set{ _os_id=value;}
			get{return _os_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? o_ID
		{
			set{ _o_id=value;}
			get{return _o_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int o_Status
		{
			set{ _o_status=value;}
			get{return _o_status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime os_ModifyOn
		{
			set{ _os_modifyon=value;}
			get{return _os_modifyon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool os_IsDel
		{
			set{ _os_isdel=value;}
			get{return _os_isdel;}
		}
		#endregion Model

	}
}

