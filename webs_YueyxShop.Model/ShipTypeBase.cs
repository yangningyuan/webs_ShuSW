/**  版本信息模板在安装目录下，可自行修改。
* ShipTypeBase.cs
*
* 功 能： N/A
* 类 名： ShipTypeBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/13 11:35:11   N/A    初版
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
	/// ShipTypeBase:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ShipTypeBase
	{
		public ShipTypeBase()
		{}
		#region Model
		private int _st_id;
		private string _st_name;
		private int _st_statuscode;
		private bool _st_isdel;
		/// <summary>
		/// 
		/// </summary>
		public int st_ID
		{
			set{ _st_id=value;}
			get{return _st_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string st_Name
		{
			set{ _st_name=value;}
			get{return _st_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int st_StatusCode
		{
			set{ _st_statuscode=value;}
			get{return _st_statuscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool st_IsDel
		{
			set{ _st_isdel=value;}
			get{return _st_isdel;}
		}
		#endregion Model

	}
}

