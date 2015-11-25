/**  版本信息模板在安装目录下，可自行修改。
* SKUBase.cs
*
* 功 能： N/A
* 类 名： SKUBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/20 9:05:30   N/A    初版
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
	/// SKUBase:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SKUBase
	{
		public SKUBase()
		{}
		#region Model
		private int _sku_id;
		private int? _p_id;
		private decimal _sku_price;
		private decimal? _sku_costprice;
		private int? _sku_stock;
		private int _sku_salescount;
		private string _sku_code;
		private DateTime _sku_createdon;
		private Guid _sku_createdby;
		private DateTime _sku_modifyon;
		private Guid _sku_modifyby;
		private int _sku_statuscode;
		private bool _sku_isdel;
        private decimal? _sku_scpric;
        private bool _sku_ismoren;
		private string _sku_tdcode;
		/// <summary>
		/// sku主键
		/// </summary>
		public int sku_ID
		{
			set{ _sku_id=value;}
			get{return _sku_id;}
		}
		/// <summary>
		/// 商品信息主键
		/// </summary>
		public int? p_ID
		{
			set{ _p_id=value;}
			get{return _p_id;}
		}
		/// <summary>
		/// 销售价
		/// </summary>
		public decimal sku_Price
		{
			set{ _sku_price=value;}
			get{return _sku_price;}
		}
		/// <summary>
		/// 成本价
		/// </summary>
		public decimal? sku_CostPrice
		{
			set{ _sku_costprice=value;}
			get{return _sku_costprice;}
		}
		/// <summary>
		/// 现有库存
		/// </summary>
		public int? sku_Stock
		{
			set{ _sku_stock=value;}
			get{return _sku_stock;}
		}
		/// <summary>
		/// 已售数量
		/// </summary>
		public int sku_SalesCount
		{
			set{ _sku_salescount=value;}
			get{return _sku_salescount;}
		}
		/// <summary>
		/// 产品编码
		/// </summary>
		public string sku_Code
		{
			set{ _sku_code=value;}
			get{return _sku_code;}
		}
		/// <summary>
		/// 二维码
		/// </summary>
		public string sku_tdcode
		{
            set { _sku_tdcode = value; }
            get { return _sku_tdcode; }
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime sku_CreatedOn
		{
			set{ _sku_createdon=value;}
			get{return _sku_createdon;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid sku_CreatedBy
		{
			set{ _sku_createdby=value;}
			get{return _sku_createdby;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime sku_ModifyOn
		{
			set{ _sku_modifyon=value;}
			get{return _sku_modifyon;}
		}
		/// <summary>
		/// 修改人
		/// </summary>
		public Guid sku_ModifyBy
		{
			set{ _sku_modifyby=value;}
			get{return _sku_modifyby;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int sku_StatusCode
		{
			set{ _sku_statuscode=value;}
			get{return _sku_statuscode;}
		}
		/// <summary>
		/// 删除
		/// </summary>
		public bool sku_IsDel
		{
			set{ _sku_isdel=value;}
			get{return _sku_isdel;}
		}
		/// <summary>
		/// 市场价
		/// </summary>
		public decimal? sku_scPric
		{
			set{ _sku_scpric=value;}
			get{return _sku_scpric;}
		}
        /// <summary>
        /// 是否默认
        /// </summary>
        public bool sku_IsMoren
        {
            set { _sku_ismoren = value; }
            get { return _sku_ismoren; }
        }
		#endregion Model

	}
}

