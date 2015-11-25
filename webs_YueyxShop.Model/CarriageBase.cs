using System;
using System.Collections.Generic;
namespace webs_YueyxShop.Model
{
	/// <summary>
	/// CarriageBase:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CarriageBase
	{
		public CarriageBase()
		{
        }
		#region Model
		private int _car_id;
		private int _ct_id;
        private string _st_ID;
		private int _car_measurementunits;
		private int? _car_shoucount;
		private decimal? _car_shoucarriage;
		private int? _car_xucount;
		private decimal? _car_xucarriage;
		private string _car_area;
        private bool _car_ismoren;
        private DateTime _car_createdon = DateTime.Now;
        private Guid _car_createdby;
        private DateTime _car_modifyon = DateTime.Now;
        private Guid _car_modifyby;
		private int _car_statuscode;
        private bool _car_isdel;
		/// <summary>
		/// 运费主键
		/// </summary>
		public int car_ID
		{
			set{ _car_id=value;}
			get{return _car_id;}
		}
		/// <summary>
		/// 运费模板主键
		/// </summary>
		public int ct_ID
		{
			set{ _ct_id=value;}
			get{return _ct_id;}
		}
		/// <summary>
		/// 运送方式,1 快递,2 EMS,3 平邮
		/// </summary>
        public string St_ID
		{
            set { _st_ID = value; }
            get { return _st_ID; }
		}
		/// <summary>
		/// 计量单位
		/// </summary>
		public int car_measurementUnits
		{
			set{ _car_measurementunits=value;}
			get{return _car_measurementunits;}
		}
		/// <summary>
		/// 首数量
		/// </summary>
		public int? car_shouCount
		{
			set{ _car_shoucount=value;}
			get{return _car_shoucount;}
		}
		/// <summary>
		/// 首运费
		/// </summary>
		public decimal? car_shouCarriage
		{
			set{ _car_shoucarriage=value;}
			get{return _car_shoucarriage;}
		}
		/// <summary>
		/// 续数量
		/// </summary>
		public int? car_xuCount
		{
			set{ _car_xucount=value;}
			get{return _car_xucount;}
		}
		/// <summary>
		/// 续运费
		/// </summary>
		public decimal? car_xuCarriage
		{
			set{ _car_xucarriage=value;}
			get{return _car_xucarriage;}
		}
		/// <summary>
		/// 运送地区，地区ID组合的字符串
		/// </summary>
		public string car_area
		{
			set{ _car_area=value;}
			get{return _car_area;}
		}
		/// <summary>
		/// 是否默认
		/// </summary>
		public bool car_Ismoren
		{
			set{ _car_ismoren=value;}
			get{return _car_ismoren;}
		}

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime car_CreateOn
        {
            set { _car_createdon = value; }
            get { return _car_createdon; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid car_CreateBy
        {
            set { _car_createdby = value; }
            get { return _car_createdby; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime car_ModifyOn
        {
            set { _car_modifyon = value; }
            get { return _car_modifyon; }
        }
        /// <summary>
        /// 修改人
        /// </summary>
        public Guid car_ModifyBy
        {
            set { _car_modifyby = value; }
            get { return _car_modifyby; }
        }
		/// <summary>
		/// 状态
		/// </summary>
		public int car_StatusCode
		{
			set{ _car_statuscode=value;}
			get{return _car_statuscode;}
		}
		/// <summary>
		/// 删除
		/// </summary>
		public bool car_IsDel
		{
			set{ _car_isdel=value;}
			get{return _car_isdel;}
		}
		#endregion Model

	}
}

