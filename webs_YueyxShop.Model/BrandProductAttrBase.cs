using System;
namespace webs_YueyxShop.Model
{
	/// <summary>
	/// 品牌商品属性明细
	/// </summary>
	[Serializable]
	public partial class BrandProductAttrBase
	{
		public BrandProductAttrBase()
		{}
		#region Model
		private int _bpa_id;
		private int? _pa_id;
		private int? _b_id;
		/// <summary>
		/// 品牌商品属性明细主键
		/// </summary>
		public int bpa_ID
		{
			set{ _bpa_id=value;}
			get{return _bpa_id;}
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
		/// 品牌主键
		/// </summary>
		public int? b_ID
		{
			set{ _b_id=value;}
			get{return _b_id;}
		}
		#endregion Model

	}
}

