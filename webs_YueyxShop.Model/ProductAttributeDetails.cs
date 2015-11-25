/**  版本信息模板在安装目录下，可自行修改。
* ProductAttributeDetails.cs
*
* 功 能： N/A
* 类 名： ProductAttributeDetails
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/10/31 11:00:32   N/A    初版
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
    /// 商品属性明细:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductAttributeDetails
	{
		public ProductAttributeDetails()
		{}
		#region Model
		private int _pad_id;
		private int? _pa_id;
		private int? _sku_id;
		/// <summary>
		/// 商品属性主键
		/// </summary>
		public int pad_ID
		{
			set{ _pad_id=value;}
			get{return _pad_id;}
		}
		/// <summary>
		/// 属性主键
		/// </summary>
		public int? pa_ID
		{
			set{ _pa_id=value;}
			get{return _pa_id;}
		}
		/// <summary>
		/// sku主键
		/// </summary>
		public int? sku_ID
		{
			set{ _sku_id=value;}
			get{return _sku_id;}
		}
		#endregion Model

	}
}

