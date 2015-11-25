/**  版本信息模板在安装目录下，可自行修改。
* RolesInfo.cs
*
* 功 能： N/A
* 类 名： RolesInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/28 14:36:07   N/A    初版
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
	/// 角色信息表
	/// </summary>
	[Serializable]
	public partial class RolesInfo
	{
		public RolesInfo()
		{}
		#region Model
		private Guid _r_id;
		private string _r_mingch;
		private string _r_miaos;
		private int _r_paix=0;
		private DateTime _r_createdon= DateTime.Now;
		private Guid _r_createdby;
		private int _r_statecode=0;
		private int _r_deletestatecode=0;
		/// <summary>
		/// 角色ID
		/// </summary>
		public Guid r_ID
		{
			set{ _r_id=value;}
			get{return _r_id;}
		}
		/// <summary>
		/// 角色名称
		/// </summary>
		public string r_MingCh
		{
			set{ _r_mingch=value;}
			get{return _r_mingch;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string r_MiaoS
		{
			set{ _r_miaos=value;}
			get{return _r_miaos;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int r_PaiX
		{
			set{ _r_paix=value;}
			get{return _r_paix;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime r_CreatedOn
		{
			set{ _r_createdon=value;}
			get{return _r_createdon;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid r_CreatedBy
		{
			set{ _r_createdby=value;}
			get{return _r_createdby;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int r_StateCode
		{
			set{ _r_statecode=value;}
			get{return _r_statecode;}
		}
		/// <summary>
		/// 删除
		/// </summary>
		public int r_DeleteStateCode
		{
			set{ _r_deletestatecode=value;}
			get{return _r_deletestatecode;}
		}
		#endregion Model

	}
}

