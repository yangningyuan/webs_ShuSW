/**  版本信息模板在安装目录下，可自行修改。
* ProductRecommendTypeBase.cs
*
* 功 能： N/A
* 类 名： ProductRecommendTypeBase
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
	/// ProductRecommendTypeBase:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductRecommendTypeBase
	{
		public ProductRecommendTypeBase()
		{}
		#region Model
		private int _prt_id;
		private string _prt_name;
		private string _prt_title;
		private bool _prt_status;
		private bool _prt_isdelete;
		private string _prt_directions;
		/// <summary>
		/// 
		/// </summary>
		public int prt_ID
		{
			set{ _prt_id=value;}
			get{return _prt_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string prt_Name
		{
			set{ _prt_name=value;}
			get{return _prt_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string prt_Title
		{
			set{ _prt_title=value;}
			get{return _prt_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool prt_Status
		{
			set{ _prt_status=value;}
			get{return _prt_status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool prt_IsDelete
		{
			set{ _prt_isdelete=value;}
			get{return _prt_isdelete;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string prt_Directions
		{
			set{ _prt_directions=value;}
			get{return _prt_directions;}
		}
		#endregion Model

	}
}

