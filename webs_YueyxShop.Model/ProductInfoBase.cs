/**  版本信息模板在安装目录下，可自行修改。
* ProductInfoBase.cs
*
* 功 能： N/A
* 类 名： ProductInfoBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/10/31 11:00:33   N/A    初版
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
    /// 商品介绍信息:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductInfoBase
	{
		public ProductInfoBase()
		{}
		#region Model
		private int _pin_id;
		private int _p_id;
		private string _pin_type;
		private string _pin_title;
		private string _pin_content;
		private DateTime _pin_createdon;
		private Guid _pin_createdby;
		private DateTime _pin_modifyon;
		private Guid _pin_moidfyby;
		private int _pin_statuscode;
		private bool _pin_isdel;
		/// <summary>
		/// 商品介绍主键
		/// </summary>
		public int pin_ID
		{
			set{ _pin_id=value;}
			get{return _pin_id;}
		}
		/// <summary>
		/// 商品信息主键
		/// </summary>
		public int p_ID
		{
			set{ _p_id=value;}
			get{return _p_id;}
		}
		/// <summary>
		/// 信息分类
		/// </summary>
		public string pin_Type
		{
			set{ _pin_type=value;}
			get{return _pin_type;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string pin_Title
		{
			set{ _pin_title=value;}
			get{return _pin_title;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string pin_Content
		{
			set{ _pin_content=value;}
			get{return _pin_content;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime pin_CreatedOn
		{
			set{ _pin_createdon=value;}
			get{return _pin_createdon;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid pin_CreatedBy
		{
			set{ _pin_createdby=value;}
			get{return _pin_createdby;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime pin_ModifyOn
		{
			set{ _pin_modifyon=value;}
			get{return _pin_modifyon;}
		}
		/// <summary>
		/// 修改人
		/// </summary>
		public Guid pin_MoidfyBy
		{
			set{ _pin_moidfyby=value;}
			get{return _pin_moidfyby;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int pin_StatusCode
		{
			set{ _pin_statuscode=value;}
			get{return _pin_statuscode;}
		}
		/// <summary>
		/// 删除
		/// </summary>
		public bool pin_IsDel
		{
			set{ _pin_isdel=value;}
			get{return _pin_isdel;}
		}
		#endregion Model

	}
}

