/**  版本信息模板在安装目录下，可自行修改。
* ProductBase.cs
*
* 功 能： N/A
* 类 名： ProductBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/10/31 17:19:33   N/A    初版
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
	/// 商品信息表
	/// </summary>
	[Serializable]
	public partial class ProductBase
	{
		public ProductBase()
		{}
        #region Model
		private int _p_id;
        private int? _b_id;
        private int? _pt_id;
        private int? _ct_id;
		private string _p_name;
		private int _p_sort=0;
		private string _p_measurementunit;
		private int _p_province;
        private int _p_city;
        private int _p_county;
		private DateTime _p_createdon= DateTime.Now;
		private Guid _p_createdby;
		private DateTime _p_modifyon= DateTime.Now;
		private Guid _p_modifyby;
		private int _p_statuscode=0;
        private bool _p_isdel = false;
        private int _p_sellstatus = 0;
		/// <summary>
		/// 商品信息主键
		/// </summary>
		public int p_ID
		{
			set{ _p_id=value;}
			get{return _p_id;}
		}
        /// <summary>
        /// 品牌主键
        /// </summary>
        public int? b_ID
        {
            set { _b_id = value; }
            get { return _b_id; }
        }
		/// <summary>
		/// 分类ID
		/// </summary>
		public int? pt_ID
		{
			set{ _pt_id=value;}
			get{return _pt_id;}
		}
        /// <summary>
        /// 运费模板ID
        /// </summary>
        public int? ct_ID
        {
            set { _ct_id = value; }
            get { return _ct_id; }
        }
		/// <summary>
		/// 商品名称
		/// </summary>
		public string p_Name
		{
			set{ _p_name=value;}
			get{return _p_name;}
		}
		/// <summary>
		/// 显示顺序
		/// </summary>
		public int p_Sort
		{
			set{ _p_sort=value;}
			get{return _p_sort;}
		}
		/// <summary>
		/// 计量单位
		/// </summary>
		public string p_MeasurementUnit
		{
			set{ _p_measurementunit=value;}
			get{return _p_measurementunit;}
		}
		/// <summary>
		/// 所在地
		/// </summary>
        public int p_Province
		{
			set{ _p_province=value;}
			get{return _p_province;}
		}
		/// <summary>
		/// 所在市
		/// </summary>
		public int p_City
		{
			set{ _p_city=value;}
			get{return _p_city;}
		}
		/// <summary>
		/// 县区
		/// </summary>
        public int p_County
		{
			set{ _p_county=value;}
			get{return _p_county;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime p_CreatedOn
		{
			set{ _p_createdon=value;}
			get{return _p_createdon;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid p_CreatedBy
		{
			set{ _p_createdby=value;}
			get{return _p_createdby;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime p_ModifyOn
		{
			set{ _p_modifyon=value;}
			get{return _p_modifyon;}
		}
		/// <summary>
		/// 修改人
		/// </summary>
		public Guid p_ModifyBy
		{
			set{ _p_modifyby=value;}
			get{return _p_modifyby;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int p_StatusCode
		{
			set{ _p_statuscode=value;}
			get{return _p_statuscode;}
		}
		/// <summary>
		/// 删除
		/// </summary>
		public bool p_IsDel
		{
			set{ _p_isdel=value;}
			get{return _p_isdel;}
		}
        /// <summary>
        /// 销售状态 默认为0，上架为1，下架为2
        /// </summary>
        public int p_SellStatus
        {
            set { _p_sellstatus = value; }
            get { return _p_sellstatus; }
        }
		#endregion Model
        public SKUBase productSkuInfo
        {
            get;
            set;
        }
        public ProductImgBase productImgInfo
        {
            get;
            set;
        }
        public ProductAttributesBase productAttrInfo
        { get; set; }
        public ProductAppraiseBase productAppInfo
        { get; set; }

        public VipCollectionBase collection
        { get; set; }

	}
}

