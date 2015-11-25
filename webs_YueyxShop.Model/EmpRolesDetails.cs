/**  版本信息模板在安装目录下，可自行修改。
* EmpRolesDetails.cs
*
* 功 能： N/A
* 类 名： EmpRolesDetails
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/28 14:36:01   N/A    初版
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
	/// 用户角色明细
	/// </summary>
	[Serializable]
	public partial class EmpRolesDetails
	{
		public EmpRolesDetails()
		{}
		#region Model
		private Guid _e_id;
		private Guid _r_id;
		/// <summary>
		/// 员工主键
		/// </summary>
		public Guid e_ID
		{
			set{ _e_id=value;}
			get{return _e_id;}
		}
		/// <summary>
		/// 角色ID
		/// </summary>
		public Guid r_ID
		{
			set{ _r_id=value;}
			get{return _r_id;}
		}
		#endregion Model

	}
}

