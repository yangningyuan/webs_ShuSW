/**  版本信息模板在安装目录下，可自行修改。
* EmployeeBase.cs
*
* 功 能： N/A
* 类 名： EmployeeBase
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
	/// 员工信息表
	/// </summary>
	[Serializable]
	public partial class EmployeeBase
	{
		public EmployeeBase()
		{}
		#region Model
		private Guid _e_id;
		private Guid _d_id;
		private string _e_yonghm;
		private string _e_mim;
		private string _e_mingc;
		private string _e_gongh;
		private int _e_xingb=0;
		private DateTime _e_shengr= Convert.ToDateTime("1900-01-01");
		private string _e_qq;
		private string _e_email;
		private string _e_shouj;
		private Guid _e_createdby;
		private DateTime _e_createdon= DateTime.Now;
		private int _e_statecode=0;
		private int _e_deletestatecode=0;
        private int _e_leib = 0;
        private string _e_imgUrl;
        private DateTime _e_LastLogintime = DateTime.Now;
		
        /// <summary>
		/// 员工主键
		/// </summary>
		public Guid e_ID
		{
			set{ _e_id=value;}
			get{return _e_id;}
		}
		/// <summary>
		/// 部门ID
		/// </summary>
		public Guid d_ID
		{
			set{ _d_id=value;}
			get{return _d_id;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string e_YongHM
		{
			set{ _e_yonghm=value;}
			get{return _e_yonghm;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string e_MiM
		{
			set{ _e_mim=value;}
			get{return _e_mim;}
		}
		/// <summary>
		/// 员工名称
		/// </summary>
		public string e_MingC
		{
			set{ _e_mingc=value;}
			get{return _e_mingc;}
		}
		/// <summary>
		/// 员工工号
		/// </summary>
		public string e_GongH
		{
			set{ _e_gongh=value;}
			get{return _e_gongh;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public int e_XingB
		{
			set{ _e_xingb=value;}
			get{return _e_xingb;}
		}
		/// <summary>
		/// 生日
		/// </summary>
		public DateTime e_ShengR
		{
			set{ _e_shengr=value;}
			get{return _e_shengr;}
		}
		/// <summary>
		/// QQ
		/// </summary>
		public string e_QQ
		{
			set{ _e_qq=value;}
			get{return _e_qq;}
		}
		/// <summary>
		/// E-Mail
		/// </summary>
		public string e_EMail
		{
			set{ _e_email=value;}
			get{return _e_email;}
		}
		/// <summary>
		/// 手机
		/// </summary>
		public string e_ShouJ
		{
			set{ _e_shouj=value;}
			get{return _e_shouj;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid e_CreatedBy
		{
			set{ _e_createdby=value;}
			get{return _e_createdby;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime e_CreatedOn
		{
			set{ _e_createdon=value;}
			get{return _e_createdon;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int e_StateCode
		{
			set{ _e_statecode=value;}
			get{return _e_statecode;}
		}
		/// <summary>
		/// 删除
		/// </summary>
		public int e_DeleteStateCode
		{
			set{ _e_deletestatecode=value;}
			get{return _e_deletestatecode;}
		}
		/// <summary>
		/// 类别(0 普通员工、1 代课教师)
		/// </summary>
		public int e_LeiB
		{
			set{ _e_leib=value;}
			get{return _e_leib;}
		}
       
		#endregion Model

	}
}

