using System;
namespace webs_YueyxShop.Model
{
	/// <summary>
	/// 品牌管理
	/// </summary>
	[Serializable]
	public partial class BrandBase
	{
		public BrandBase()
		{}
		#region Model
		private int _b_id;
		private string _b_name;
		private string _b_key;
		private string _b_logourl;
		private string _b_siteurl;
		private int _b_sort=0;
		private DateTime _b_createdon= DateTime.Now;
		private Guid _b_createdby;
		private int _b_statuscode=0;
		private bool _b_isdel= false;
		/// <summary>
		/// 品牌主键
		/// </summary>
		public int b_ID
		{
			set{ _b_id=value;}
			get{return _b_id;}
		}
		/// <summary>
		/// 品牌名称
		/// </summary>
		public string b_Name
		{
			set{ _b_name=value;}
			get{return _b_name;}
		}
		/// <summary>
		/// 查询关键字(用于快速锁定该品牌，一般为拼音简写)
		/// </summary>
		public string b_Key
		{
			set{ _b_key=value;}
			get{return _b_key;}
		}
		/// <summary>
		/// 品牌Logo
		/// </summary>
		public string b_LogoUrl
		{
			set{ _b_logourl=value;}
			get{return _b_logourl;}
		}
		/// <summary>
		/// 品牌官方地址
		/// </summary>
		public string b_SiteUrl
		{
			set{ _b_siteurl=value;}
			get{return _b_siteurl;}
		}
		/// <summary>
		/// 显示顺序
		/// </summary>
		public int b_Sort
		{
			set{ _b_sort=value;}
			get{return _b_sort;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime b_CreatedOn
		{
			set{ _b_createdon=value;}
			get{return _b_createdon;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid b_CreatedBy
		{
			set{ _b_createdby=value;}
			get{return _b_createdby;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int b_StatusCode
		{
			set{ _b_statuscode=value;}
			get{return _b_statuscode;}
		}
		/// <summary>
		/// 删除
		/// </summary>
		public bool b_IsDel
		{
			set{ _b_isdel=value;}
			get{return _b_isdel;}
		}
		#endregion Model

	}
}

