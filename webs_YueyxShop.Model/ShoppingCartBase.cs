/**  版本信息模板在安装目录下，可自行修改。
* ShoppingCartBase.cs
*
* 功 能： N/A
* 类 名： ShoppingCartBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/22 16:19:24   N/A    初版
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
	/// ShoppingCartBase:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ShoppingCartBase
	{
		public ShoppingCartBase()
		{}
		#region Model
		private int _sc_id;
		private int? _sku_id;
		private int? _m_id;
		private int? _sc_pcount;
		private decimal? _sc_ppric;
        private DateTime _sc_createon;
        private bool _sc_isdel;
        private bool _sc_Status;
        private bool _sc_isgp = false;
        private string _sc_chima;

        public string sc_chima
        {
            get { return _sc_chima; }
            set { _sc_chima = value; }
        }
        private string _sc_yanse;

        public string sc_yanse
        {
            get { return _sc_yanse; }
            set { _sc_yanse = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int sc_ID
		{
			set{ _sc_id=value;}
			get{return _sc_id;}
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
		public int? m_ID
		{
			set{ _m_id=value;}
			get{return _m_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sc_pCount
		{
			set{ _sc_pcount=value;}
			get{return _sc_pcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? sc_pPric
		{
			set{ _sc_ppric=value;}
			get{return _sc_ppric;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime sc_CreateOn
		{
			set{ _sc_createon=value;}
			get{return _sc_createon;}
		}
		/// <summary>
		/// 
        /// </summary>
        public bool sc_IsDel
        {
            set { _sc_isdel = value; }
            get { return _sc_isdel; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public bool sc_Status
        {
            set { _sc_Status = value; }
            get { return _sc_Status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool sc_IsGP
        {
            set { _sc_isgp = value; }
            get { return _sc_isgp; }
        }

        
		#endregion Model

	}
}

