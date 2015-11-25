/**  版本信息模板在安装目录下，可自行修改。
* ProductSEOBase.cs
*
* 功 能： N/A
* 类 名： ProductSEOBase
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
    ///商品SEO信息:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductSEOBase
	{
		public ProductSEOBase()
		{}
		#region Model
		private int _pseo_id;
		private int _p_id;
		private string _pseo_title;
		private string _pseo_content;
		private string _pseo_keys;
		private string _pseo_picalt;
		private string _pseo_pictitle;
		/// <summary>
		/// 商品SEO主键
		/// </summary>
		public int pseo_ID
		{
			set{ _pseo_id=value;}
			get{return _pseo_id;}
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
		/// 页面标题
		/// </summary>
		public string pseo_Title
		{
			set{ _pseo_title=value;}
			get{return _pseo_title;}
		}
		/// <summary>
		/// 页面描述
		/// </summary>
		public string pseo_Content
		{
			set{ _pseo_content=value;}
			get{return _pseo_content;}
		}
		/// <summary>
		/// 页面关键词
		/// </summary>
		public string pseo_Keys
		{
			set{ _pseo_keys=value;}
			get{return _pseo_keys;}
		}
		/// <summary>
		/// 图片Alt信息
		/// </summary>
		public string pseo_PicAlt
		{
			set{ _pseo_picalt=value;}
			get{return _pseo_picalt;}
		}
		/// <summary>
		/// 图片Title
		/// </summary>
		public string pseo_PicTitle
		{
			set{ _pseo_pictitle=value;}
			get{return _pseo_pictitle;}
		}
		#endregion Model

	}
}

