using System;
namespace webs_YueyxShop.Model
{
	/// <summary>
	/// 商品品牌分类明细
	/// </summary>
	[Serializable]
	public partial class ProductTypeBrandBase
	{
		public ProductTypeBrandBase()
		{}
		#region Model
		private int _ptb_id;
		private int? _pt_id;
		private int? _b_id;
		/// <summary>
		/// 商品品牌分类主键
		/// </summary>
		public int ptb_ID
		{
			set{ _ptb_id=value;}
			get{return _ptb_id;}
		}
		/// <summary>
		/// 分类主键
		/// </summary>
		public int? pt_ID
		{
			set{ _pt_id=value;}
			get{return _pt_id;}
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

