/**  版本信息模板在安装目录下，可自行修改。
* RegionBase.cs
*
* 功 能： N/A
* 类 名： RegionBase
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
	/// RegionBase:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RegionBase
	{
		public RegionBase()
		{}
		#region Model
		private int _reg_id;
		private int _reg_code;
		private int _reg_pid;
		private string _reg_name;
		/// <summary>
		/// 
		/// </summary>
		public int reg_ID
		{
			set{ _reg_id=value;}
			get{return _reg_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int reg_Code
		{
			set{ _reg_code=value;}
			get{return _reg_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int reg_PId
		{
			set{ _reg_pid=value;}
			get{return _reg_pid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string reg_Name
		{
			set{ _reg_name=value;}
			get{return _reg_name;}
		}
		#endregion Model

	}
}

