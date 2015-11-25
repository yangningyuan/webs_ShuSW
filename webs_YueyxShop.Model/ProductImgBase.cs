/**  版本信息模板在安装目录下，可自行修改。
* ProductImgBase.cs
*
* 功 能： N/A
* 类 名： ProductImgBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/10/31 11:00:33   N/A    初版
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
    /// 商品图集:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductImgBase
	{
		public ProductImgBase()
		{}
		#region Model
		private int _pi_id;
		private int _sku_id;
		private string _pi_url;
        private bool _pl_type;
        private int _pi_statusCode;
        private bool _pl_isdel;
		/// <summary>
		/// 商品图集主键
		/// </summary>
		public int pi_ID 
		{
			set{ _pi_id=value;}
			get{return _pi_id;}
		}
		/// <summary>
		/// sku主键
		/// </summary>
		public int sku_ID
		{
			set{ _sku_id=value;}
			get{return _sku_id;}
		}
		/// <summary>
		/// 图片路径
		/// </summary>
		public string pi_Url
		{
			set{ _pi_url=value;}
			get{return _pi_url;}
		}
		/// <summary>
		/// 图片显示类型
		/// </summary>
        public bool pi_Type
		{
			set{ _pl_type=value;}
			get{return _pl_type;}
		}
        /// <summary>
        /// 状态
        /// </summary>
        public int pi_StatusCode 
        {
            set { _pi_statusCode = value; }
            get { return _pi_statusCode; }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public bool pi_IsDel
        {
            set { _pl_isdel = value; }
            get { return _pl_isdel; }
        }
		#endregion Model

	}
}

