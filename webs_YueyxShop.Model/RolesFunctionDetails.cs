/**  版本信息模板在安装目录下，可自行修改。
* RolesFunctionDetails.cs
*
* 功 能： N/A
* 类 名： RolesFunctionDetails
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/28 14:36:06   N/A    初版
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
	/// 角色功能明细表
	/// </summary>
	[Serializable]
	public partial class RolesFunctionDetails
	{
		public RolesFunctionDetails()
		{}
		#region Model
		private Guid _r_id;
		private Guid _f_id;
		/// <summary>
		/// 角色ID
		/// </summary>
		public Guid r_ID
		{
			set{ _r_id=value;}
			get{return _r_id;}
		}
		/// <summary>
		/// 功能信息表ID
		/// </summary>
		public Guid f_ID
		{
			set{ _f_id=value;}
			get{return _f_id;}
		}
		#endregion Model

	}
}

