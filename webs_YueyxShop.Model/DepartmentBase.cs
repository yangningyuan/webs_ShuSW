/**  版本信息模板在安装目录下，可自行修改。
* DepartmentBase.cs
*
* 功 能： N/A
* 类 名： DepartmentBase
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
	/// 部门信息表
	/// </summary>
	[Serializable]
	public partial class DepartmentBase
	{
		public DepartmentBase()
		{}
		#region Model
		private Guid _d_id;
		private int? _cs_id;
		private string _d_bianm;
		private string _d_mingch;
		private Guid _d_parentid;
		private int _d_cengj=0;
		private string _d_zhuydh;
		private string _d_chuanz;
		private string _d_youx;
		private Guid _d_createdby;
		private DateTime _d_createdon= DateTime.Now;
		private int _d_statecode=0;
		private int _d_deletestatecode=0;
		/// <summary>
		/// 部门ID
		/// </summary>
		public Guid d_ID
		{
			set{ _d_id=value;}
			get{return _d_id;}
		}
		/// <summary>
		/// 院系主键
		/// </summary>
		public int? cs_ID
		{
			set{ _cs_id=value;}
			get{return _cs_id;}
		}
		/// <summary>
		/// 部门编码
		/// </summary>
		public string d_BianM
		{
			set{ _d_bianm=value;}
			get{return _d_bianm;}
		}
		/// <summary>
		/// 部门名称
		/// </summary>
		public string d_MingCh
		{
			set{ _d_mingch=value;}
			get{return _d_mingch;}
		}
		/// <summary>
		/// 直属上级
		/// </summary>
		public Guid d_ParentId
		{
			set{ _d_parentid=value;}
			get{return _d_parentid;}
		}
		/// <summary>
		/// 层级
		/// </summary>
		public int d_CengJ
		{
			set{ _d_cengj=value;}
			get{return _d_cengj;}
		}
		/// <summary>
		/// 主要电话
		/// </summary>
		public string d_ZhuYDH
		{
			set{ _d_zhuydh=value;}
			get{return _d_zhuydh;}
		}
		/// <summary>
		/// 传真
		/// </summary>
		public string d_ChuanZ
		{
			set{ _d_chuanz=value;}
			get{return _d_chuanz;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string d_YouX
		{
			set{ _d_youx=value;}
			get{return _d_youx;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid d_CreatedBy
		{
			set{ _d_createdby=value;}
			get{return _d_createdby;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime d_CreatedOn
		{
			set{ _d_createdon=value;}
			get{return _d_createdon;}
		}
		/// <summary>
		/// 状态
        /// 0 存在,1 停用
		/// </summary>
		public int d_StateCode
		{
			set{ _d_statecode=value;}
			get{return _d_statecode;}
		}
		/// <summary>
		/// 删除
		/// </summary>
		public int d_DeleteStateCode
		{
			set{ _d_deletestatecode=value;}
			get{return _d_deletestatecode;}
		}
		#endregion Model

	}
}

