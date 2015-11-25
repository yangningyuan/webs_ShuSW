/**  版本信息模板在安装目录下，可自行修改。
* vw_EmployeeBase.cs
*
* 功 能： N/A
* 类 名： vw_EmployeeBase
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
	public partial class vw_EmployeeBase
	{
		public vw_EmployeeBase()
		{}
		#region Model
		private Guid _e_id;
		private Guid _d_id;
		private string _d_mingch;
		private string _e_yonghm;
		private string _e_mim;
		private string _e_mingc;
		private string _e_gongh;
		private int _e_xingb;
		private DateTime _e_shengr;
		private string _e_qq;
		private string _e_email;
		private string _e_shouj;
		private Guid _e_createdby;
		private DateTime _e_createdon;
		private int _e_statecode;
		private int _e_deletestatecode;
		private int _e_leib;
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
		public Guid d_ID
		{
			set{ _d_id=value;}
			get{return _d_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string d_MingCh
		{
			set{ _d_mingch=value;}
			get{return _d_mingch;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string e_YongHM
		{
			set{ _e_yonghm=value;}
			get{return _e_yonghm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string e_MiM
		{
			set{ _e_mim=value;}
			get{return _e_mim;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string e_MingC
		{
			set{ _e_mingc=value;}
			get{return _e_mingc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string e_GongH
		{
			set{ _e_gongh=value;}
			get{return _e_gongh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int e_XingB
		{
			set{ _e_xingb=value;}
			get{return _e_xingb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime e_ShengR
		{
			set{ _e_shengr=value;}
			get{return _e_shengr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string e_QQ
		{
			set{ _e_qq=value;}
			get{return _e_qq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string e_EMail
		{
			set{ _e_email=value;}
			get{return _e_email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string e_ShouJ
		{
			set{ _e_shouj=value;}
			get{return _e_shouj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid e_CreatedBy
		{
			set{ _e_createdby=value;}
			get{return _e_createdby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime e_CreatedOn
		{
			set{ _e_createdon=value;}
			get{return _e_createdon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int e_StateCode
		{
			set{ _e_statecode=value;}
			get{return _e_statecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int e_DeleteStateCode
		{
			set{ _e_deletestatecode=value;}
			get{return _e_deletestatecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int e_LeiB
		{
			set{ _e_leib=value;}
			get{return _e_leib;}
		}
		#endregion Model

	}
}

