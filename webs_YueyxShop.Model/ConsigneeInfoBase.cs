/**  版本信息模板在安装目录下，可自行修改。
* ConsigneeInfoBase.cs
*
* 功 能： N/A
* 类 名： ConsigneeInfoBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/22 14:03:34   N/A    初版
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
	/// ConsigneeInfoBase:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ConsigneeInfoBase
	{
		public ConsigneeInfoBase()
		{}
		#region Model
		private int _c_id;
		private int? _m_id;
		private string _c_name;
		private string _c_telephone;
		private string _c_mobilephone;
		private int? _c_provice;
		private int? _c_city;
		private int? _c_count;
		private string _c_zipcode;
		private int? _c_moren;
		private int _c_statuscode;
		private int _c_isdel;
		private string _c_fulladdress;
		/// <summary>
		/// 
		/// </summary>
		public int c_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
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
		public string c_Name
		{
			set{ _c_name=value;}
			get{return _c_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string c_Telephone
		{
			set{ _c_telephone=value;}
			get{return _c_telephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string c_Mobilephone
		{
			set{ _c_mobilephone=value;}
			get{return _c_mobilephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? c_Provice
		{
			set{ _c_provice=value;}
			get{return _c_provice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? c_City
		{
			set{ _c_city=value;}
			get{return _c_city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? c_Count
		{
			set{ _c_count=value;}
			get{return _c_count;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string c_Zipcode
		{
			set{ _c_zipcode=value;}
			get{return _c_zipcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? c_Moren
		{
			set{ _c_moren=value;}
			get{return _c_moren;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int c_StatusCode
		{
			set{ _c_statuscode=value;}
			get{return _c_statuscode;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int c_IsDel
		{
			set{ _c_isdel=value;}
			get{return _c_isdel;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string c_FullAddress
		{
			set{ _c_fulladdress=value;}
			get{return _c_fulladdress;}
		}

        /// <summary>
        /// 省中文
        /// </summary>
        public string c_CProvice { get; set; }

        /// <summary>
        /// 市中文
        /// </summary>
        public string c_CCity { get; set; }

        /// <summary>
        /// 县中文
        /// </summary>
        public string c_CCount { get; set; }

		#endregion Model

	}
}

