using System;
namespace webs_YueyxShop.Model
{
	/// <summary>
	/// CarriageTempleteBase:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CarriageTempleteBase
	{
		public CarriageTempleteBase()
		{}
		#region Model
		private int _ct_id;
		private string _ct_name;
        private int? _ct_valuationtype;
        private DateTime _ct_createdon = DateTime.Now;
        private Guid _ct_createdby;
        private DateTime _ct_modifyon = DateTime.Now;
        private Guid _ct_modifyby;
		private int _ct_statuscode;
		private bool _ct_isdel;
		/// <summary>
		/// 运费模板主键
		/// </summary>
		public int ct_ID
		{
			set{ _ct_id=value;}
			get{return _ct_id;}
		}
		/// <summary>
		/// 模板名称
		/// </summary>
		public string ct_Name
		{
			set{ _ct_name=value;}
			get{return _ct_name;}
		}
		/// <summary>
		/// 计价方式，1 按件数，2 按重量，3 按体积
		/// </summary>
		public int? ct_ValuationType
		{
			set{ _ct_valuationtype=value;}
			get{return _ct_valuationtype;}
		}

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime ct_CreateOn
        {
            set { _ct_createdon = value; }
            get { return _ct_createdon; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid ct_CreateBy
        {
            set { _ct_createdby = value; }
            get { return _ct_createdby; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ct_ModifyOn
        {
            set { _ct_modifyon = value; }
            get { return _ct_modifyon; }
        }
        /// <summary>
        /// 修改人
        /// </summary>
        public Guid ct_ModifyBy
        {
            set { _ct_modifyby = value; }
            get { return _ct_modifyby; }
        }
		/// <summary>
		/// 状态
		/// </summary>
		public int ct_StatusCode
		{
			set{ _ct_statuscode=value;}
			get{return _ct_statuscode;}
		}
		/// <summary>
		/// 删除
		/// </summary>
		public bool ct_IsDel
		{
			set{ _ct_isdel=value;}
			get{return _ct_isdel;}
		}
		#endregion Model

	}
}

