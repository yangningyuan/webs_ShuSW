/**  版本信息模板在安装目录下，可自行修改。
* MenuBase.cs
*
* 功 能： N/A
* 类 名： MenuBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/28 14:36:03   N/A    初版
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
	/// 菜单信息表
	/// </summary>
	[Serializable]
	public partial class MenuBase
	{
		public MenuBase()
		{}
		#region Model
		private Guid _m_id;
		private string _m_bianm;
		private string _m_mingch;
		private int _m_cengj=0;
		private int _m_paix=0;
		private Guid _m_parentid;
		private DateTime _m_createdon= DateTime.Now;
		private Guid _m_createdby;
		private int _m_statecode=0;
		private int _m_deletestatecode=0;
		private string _m_path;
        private int _m_type = 0;
        private bool _m_isshow = false;
        private string _m_pagetype;
		/// <summary>
		/// 菜单信息ID
		/// </summary>
		public Guid m_ID
		{
			set{ _m_id=value;}
			get{return _m_id;}
		}
		/// <summary>
		/// 菜单编码
		/// </summary>
		public string m_BianM
		{
			set{ _m_bianm=value;}
			get{return _m_bianm;}
		}
		/// <summary>
		/// 菜单名称
		/// </summary>
		public string m_MingCh
		{
			set{ _m_mingch=value;}
			get{return _m_mingch;}
		}
		/// <summary>
		/// 层级
		/// </summary>
		public int m_CengJ
		{
			set{ _m_cengj=value;}
			get{return _m_cengj;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int m_PaiX
		{
			set{ _m_paix=value;}
			get{return _m_paix;}
		}
		/// <summary>
		/// 上级菜单
		/// </summary>
		public Guid m_ParentId
		{
			set{ _m_parentid=value;}
			get{return _m_parentid;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime m_CreatedOn
		{
			set{ _m_createdon=value;}
			get{return _m_createdon;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid m_CreatedBy
		{
			set{ _m_createdby=value;}
			get{return _m_createdby;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int m_StateCode
		{
			set{ _m_statecode=value;}
			get{return _m_statecode;}
		}
		/// <summary>
		/// 删除
		/// </summary>
		public int m_DeleteStateCode
		{
			set{ _m_deletestatecode=value;}
			get{return _m_deletestatecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string m_Path
		{
			set{ _m_path=value;}
			get{return _m_path;}
		}
        /// <summary>
        /// 菜单分类(0 管理系统，1 CMS)
        /// </summary>
        public int m_Type
        {
            set { _m_type = value; }
            get { return _m_type; }
        }
        /// <summary>
        /// 是否显示(前台导航) ,1显示
        /// </summary>
        public bool m_IsShow
        {
            set { _m_isshow = value; }
            get { return _m_isshow; }
        }
        /// <summary>
        /// 菜单页面类型（非资讯页、文章页、图片列表页、文字列表页）
        /// </summary>
        public string m_PageType
        {
            set { _m_pagetype = value; }
            get { return _m_pagetype; }
        }
		#endregion Model

	}
}

