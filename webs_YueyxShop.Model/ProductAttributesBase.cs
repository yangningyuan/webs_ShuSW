using System;
namespace webs_YueyxShop.Model
{
	/// <summary>
	/// 商品属性
	/// </summary>
	[Serializable]
	public partial class ProductAttributesBase
	{
		public ProductAttributesBase()
		{}
		#region Model
		private int _pa_id;
		private string _pa_name;
		private string _pa_alias;
		private int _pa_type=0;
		private int _pa_layer=0;
		private string _pa_code;
		private int _pa_sort=0;
		private int _pa_selecttype=0;
		private int _pa_statuscode=0;
		private DateTime _pa_createdon= DateTime.Now;
		private Guid _pa_createdby;
		private bool _pa_isdel= false;
        private int _pa_parentId;
        private int _pt_Id;
		/// <summary>
		/// 属性主键
		/// </summary>
		public int pa_ID
		{
			set{ _pa_id=value;}
			get{return _pa_id;}
		}
		/// <summary>
		/// 属性名称/值
		/// </summary>
		public string pa_Name
		{
			set{ _pa_name=value;}
			get{return _pa_name;}
		}
		/// <summary>
		/// 别名
		/// </summary>
		public string pa_Alias
		{
			set{ _pa_alias=value;}
			get{return _pa_alias;}
		}
		/// <summary>
		/// 属性分类(1 属性 2 规格)
		/// </summary>
		public int pa_Type
		{
			set{ _pa_type=value;}
			get{return _pa_type;}
		}
		/// <summary>
		/// 层级
		/// </summary>
		public int pa_Layer
		{
			set{ _pa_layer=value;}
			get{return _pa_layer;}
		}
		/// <summary>
		/// 编码
		/// </summary>
		public string pa_Code
		{
			set{ _pa_code=value;}
			get{return _pa_code;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int pa_Sort
		{
			set{ _pa_sort=value;}
			get{return _pa_sort;}
		}
		/// <summary>
		/// 选择方式(0 单选,1 多选)主要由一级分类使用
		/// </summary>
		public int pa_SelectType
		{
			set{ _pa_selecttype=value;}
			get{return _pa_selecttype;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int pa_StatusCode
		{
			set{ _pa_statuscode=value;}
			get{return _pa_statuscode;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime pa_CreatedOn
		{
			set{ _pa_createdon=value;}
			get{return _pa_createdon;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid pa_CreatedBy
		{
			set{ _pa_createdby=value;}
			get{return _pa_createdby;}
		}
		/// <summary>
		/// 删除
		/// </summary>
		public bool pa_IsDel
		{
			set{ _pa_isdel=value;}
			get{return _pa_isdel;}
		}


        public int pa_ParentId
        {
            set { _pa_parentId = value; }
            get { return _pa_parentId; }
        }
        public int pt_Id
        {
            set { _pt_Id = value; }
            get { return _pt_Id; }
        }
        public SKUBase sku
        {
            get;
            set;
        }
		#endregion Model

	}
}

