using System;
namespace webs_YueyxShop.Model
{
	/// <summary>
	/// 系统日志
	/// </summary>
	[Serializable]
	public partial class SysLogBase
	{
		public SysLogBase()
		{}
		#region Model
		private int _sl_id;
		private int? _sl_leix;
		private DateTime _sl_shij= DateTime.Now;
		private string _sl_dizh;
		private string _sl_miaosh;
		private string _sl_leix_caoz;
		/// <summary>
		/// 日志主键
		/// </summary>
		public int sl_ID
		{
			set{ _sl_id=value;}
			get{return _sl_id;}
		}
		/// <summary>
		/// 日志类型(系统日志、操作日志)
		/// </summary>
		public int? sl_LeiX
		{
			set{ _sl_leix=value;}
			get{return _sl_leix;}
		}
		/// <summary>
		/// 日志时间
		/// </summary>
		public DateTime sl_ShiJ
		{
			set{ _sl_shij=value;}
			get{return _sl_shij;}
		}
		/// <summary>
		/// 发生地址
		/// </summary>
		public string sl_DiZh
		{
			set{ _sl_dizh=value;}
			get{return _sl_dizh;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string sl_MiaoSh
		{
			set{ _sl_miaosh=value;}
			get{return _sl_miaosh;}
		}
		/// <summary>
		/// 操作类型(增、删、改、查)
		/// </summary>
		public string sl_LeiX_CaoZ
		{
			set{ _sl_leix_caoz=value;}
			get{return _sl_leix_caoz;}
		}
		#endregion Model

	}
}

