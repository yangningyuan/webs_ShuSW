using System;
using System.Collections;
using System.Collections.Generic;
namespace webs_YueyxShop.Model
{
	/// <summary>
	/// 商品分类信息
	/// </summary>
	[Serializable]
	public partial class ProductTypeBase
	{
		public ProductTypeBase()
		{
            this.ProductTypeBase1 = new List<ProductTypeBase>();
        }
		#region Model
		private int _pt_id;
		private string _pt_name;
		private string _pt_code;
		private int _pt_layer=0;
		private int _pt_sort=0;
		private int _pt_parentid=0;
		private string _pt_content;
		private string _pt_imgurl;
		private int _pt_statuscode=0;
		private Guid _pt_createdby;
		private DateTime _pt_createdon= DateTime.Now;
		private bool _pt_isdel= false;
		/// <summary>
		/// 分类主键
		/// </summary>
		public int pt_ID
		{
			set{ _pt_id=value;}
			get{return _pt_id;}
		}
		/// <summary>
		/// 分类名称
		/// </summary>
		public string pt_Name
		{
			set{ _pt_name=value;}
			get{return _pt_name;}
		}
		/// <summary>
		/// 分类编码
		/// </summary>
		public string pt_Code
		{
			set{ _pt_code=value;}
			get{return _pt_code;}
		}
		/// <summary>
		/// 分类层级
		/// </summary>
		public int pt_Layer
		{
			set{ _pt_layer=value;}
			get{return _pt_layer;}
		}
		/// <summary>
		/// 分类排序
		/// </summary>
		public int pt_Sort
		{
			set{ _pt_sort=value;}
			get{return _pt_sort;}
		}
		/// <summary>
		/// 上级ID
		/// </summary>
		public int pt_ParentId
		{
			set{ _pt_parentid=value;}
			get{return _pt_parentid;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string pt_Content
		{
			set{ _pt_content=value;}
			get{return _pt_content;}
		}
		/// <summary>
		/// 类别图片
		/// </summary>
		public string pt_ImgUrl
		{
			set{ _pt_imgurl=value;}
			get{return _pt_imgurl;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int pt_StatusCode
		{
			set{ _pt_statuscode=value;}
			get{return _pt_statuscode;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid pt_CreatedBy
		{
			set{ _pt_createdby=value;}
			get{return _pt_createdby;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime pt_CreatedOn
		{
			set{ _pt_createdon=value;}
			get{return _pt_createdon;}
		}
		/// <summary>
		/// 删除
		/// </summary>
		public bool pt_IsDel
		{
			set{ _pt_isdel=value;}
			get{return _pt_isdel;}
		}
		#endregion Model

        public virtual List<ProductTypeBase> ProductTypeBase1 { get; set; }
	}
}

