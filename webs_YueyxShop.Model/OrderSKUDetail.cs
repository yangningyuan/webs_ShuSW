/**  版本信息模板在安装目录下，可自行修改。
* OrderSKUDetail.cs
*
* 功 能： N/A
* 类 名： OrderSKUDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/13 19:07:26   N/A    初版
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
	/// OrderSKUDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrderSKUDetail
	{
		public OrderSKUDetail()
		{}
		#region Model
		private int _os_id;
		private int? _sku_id;
		private int? _o_id;
        private int? _os_pcount;
        private decimal? _os_price;
        private bool _os_isgp = false;
		private string _os_chima;

		public string os_chima
		{
			get { return _os_chima; }
			set { _os_chima = value; }
		}
		private string _os_yanse;

		public string os_yanse
		{
			get { return _os_yanse; }
			set { _os_yanse = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int os_ID
		{
			set{ _os_id=value;}
			get{return _os_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sku_ID
		{
			set{ _sku_id=value;}
			get{return _sku_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? o_ID
		{
			set{ _o_id=value;}
			get{return _o_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? os_pCount
		{
			set{ _os_pcount=value;}
			get{return _os_pcount;}
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? os_Price
        {
            set { _os_price = value; }
            get { return _os_price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool os_IsGP
        {
            set { _os_isgp = value; }
            get { return _os_isgp; }
        }
		#endregion Model

	}
}

