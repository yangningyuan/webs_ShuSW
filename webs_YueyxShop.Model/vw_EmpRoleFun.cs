/**  版本信息模板在安装目录下，可自行修改。
* vw_EmpRoleFun.cs
*
* 功 能： N/A
* 类 名： vw_EmpRoleFun
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/28 14:36:11   N/A    初版
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
	/// 交通信息
	/// </summary>
	[Serializable]
	public partial class vw_EmpRoleFun
	{
		public vw_EmpRoleFun()
		{}
		#region Model
		private string _f_bianm;
		private Guid _f_id;
		private Guid _e_id;
		private Guid _r_id;
		/// <summary>
		/// 
		/// </summary>
		public string f_BianM
		{
			set{ _f_bianm=value;}
			get{return _f_bianm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid f_ID
		{
			set{ _f_id=value;}
			get{return _f_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid e_ID
		{
			set{ _e_id=value;}
			get{return _e_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid r_ID
		{
			set{ _r_id=value;}
			get{return _r_id;}
		}
		#endregion Model

	}
}

