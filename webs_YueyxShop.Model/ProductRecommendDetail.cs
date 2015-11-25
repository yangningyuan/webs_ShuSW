/**  版本信息模板在安装目录下，可自行修改。
* ProductRecommendDetail.cs
*
* 功 能： N/A
* 类 名： ProductRecommendDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/14 10:16:49   N/A    初版
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
	/// ProductRecommendDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductRecommendDetail
	{
		public ProductRecommendDetail()
		{}
		#region Model
		private int _prd_id;
		private int? _prt_id;
		private int? _p_id;
		private bool _prd_status;
		private bool _prd_isdelete;
		/// <summary>
		/// 
		/// </summary>
		public int prd_ID
		{
			set{ _prd_id=value;}
			get{return _prd_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? prt_ID
		{
			set{ _prt_id=value;}
			get{return _prt_id;}
		}
		/// <summary>
		/// 
		/// </summary>
        public int? p_ID
        {
            set { _p_id = value; }
            get { return _p_id; }
        }
		/// <summary>
		/// 
		/// </summary>
		public bool prd_Status
		{
			set{ _prd_status=value;}
			get{return _prd_status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool prd_IsDelete
		{
			set{ _prd_isdelete=value;}
			get{return _prd_isdelete;}
		}
		#endregion Model

	}
}

