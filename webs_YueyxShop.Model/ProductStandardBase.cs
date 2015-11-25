/**  版本信息模板在安装目录下，可自行修改。
* ProductStandardBase.cs
*
* 功 能： N/A
* 类 名： ProductStandardBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/10/31 17:19:34   N/A    初版
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
	/// 商品规格明细
	/// </summary>
	[Serializable]
	public partial class ProductStandardBase
	{
		public ProductStandardBase()
		{}
		#region Model
		private int _ps_id;
		private int? _sku_id;
		private int? _pa_id;
		/// <summary>
		/// 商品规格明细主键
		/// </summary>
		public int ps_ID
		{
			set{ _ps_id=value;}
			get{return _ps_id;}
		}
		/// <summary>
		/// SKU主键
		/// </summary>
		public int? sku_ID
		{
			set{ _sku_id=value;}
			get{return _sku_id;}
		}
		/// <summary>
		/// 属性主键
		/// </summary>
		public int? pa_ID
		{
			set{ _pa_id=value;}
			get{return _pa_id;}
		}
		#endregion Model

	}
}

