/**  版本信息模板在安装目录下，可自行修改。
* SysCodeBase.cs
*
* 功 能： N/A
* 类 名： SysCodeBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/28 14:36:10   N/A    初版
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
	/// 系统代码词典
	/// </summary>
	[Serializable]
	public partial class SysCodeBase
	{
		public SysCodeBase()
		{}
		#region Model
		private Guid _sc_id;
		private string _sc_bianm;
		private string _sc_mingch;
		private int _sc_cengj=0;
		private Guid _sc_parentid;
		private Guid _sc_createdby;
		private DateTime _sc_createdon= DateTime.Now;
		private int _sc_statecode=0;
		private int _sc_deletestatecode=0;
		private int _sc_leib=0;
		private string _sc_suosmk;
		/// <summary>
		/// 代码词典主键
		/// </summary>
		public Guid sc_ID
		{
			set{ _sc_id=value;}
			get{return _sc_id;}
		}
		/// <summary>
		/// 编码
		/// </summary>
		public string sc_BianM
		{
			set{ _sc_bianm=value;}
			get{return _sc_bianm;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string sc_MingCh
		{
			set{ _sc_mingch=value;}
			get{return _sc_mingch;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public int sc_CengJ
		{
			set{ _sc_cengj=value;}
			get{return _sc_cengj;}
		}
		/// <summary>
		/// 上级ID
		/// </summary>
		public Guid sc_ParentId
		{
			set{ _sc_parentid=value;}
			get{return _sc_parentid;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid sc_CreatedBy
		{
			set{ _sc_createdby=value;}
			get{return _sc_createdby;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime sc_CreatedOn
		{
			set{ _sc_createdon=value;}
			get{return _sc_createdon;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int sc_StateCode
		{
			set{ _sc_statecode=value;}
			get{return _sc_statecode;}
		}
		/// <summary>
		/// 删除
		/// </summary>
		public int sc_DeleteStateCode
		{
			set{ _sc_deletestatecode=value;}
			get{return _sc_deletestatecode;}
		}
		/// <summary>
		/// 类别(0 普通、1 系统)
		/// </summary>
		public int sc_LeiB
		{
			set{ _sc_leib=value;}
			get{return _sc_leib;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sc_SuoSMK
		{
			set{ _sc_suosmk=value;}
			get{return _sc_suosmk;}
		}
		#endregion Model

	}
}

