using System;
namespace webs_YueyxShop.Model
{
	/// <summary>
	/// vw_Orderpinfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class vw_Orderpinfo
	{
		public vw_Orderpinfo()
		{}
		#region Model
		private int _b_id;
		private string _b_name;
		private int _p_id;
		private string _p_name;
		private DateTime _p_modifyon;
		private Guid _p_modifyby;
		private int _p_statuscode;
		private bool _p_isdel;
		private int _p_sellstatus;
		private int _pi_id;
		private string _pi_url;
		private bool _pi_type;
		private bool _pi_isdel;
		private int? _pi_statuscode;
		private string _p_measurementunit;
		private int _pt_id;
		private string _pt_name;
		private int _pt_parentid;
		private int _pt_statuscode;
		private Guid _pt_createdby;
		private DateTime _pt_createdon;
		private bool _pt_isdel;
		private string _pt_imgurl;
		private int _sku_id;
		private decimal _sku_price;
		private decimal? _sku_costprice;
		private int _sku_salescount;
		private int? _sku_stock;
		private string _sku_code;
		private DateTime _sku_createdon;
		private Guid _sku_createdby;
		private DateTime _sku_modifyon;
		private Guid _sku_modifyby;
		private int _sku_statuscode;
		private bool _sku_isdel;
		private decimal? _sku_scpric;
		private bool _sku_ismoren;
		private int? _p_province;
		private int? _p_city;
		private int? _p_county;
		private Guid _p_createdby;
		private DateTime _p_createdon;
		private string _b_key;
		private string _b_siteurl;
		private string _b_logourl;
		private int _b_sort;
		private DateTime _b_createdon;
		private Guid _b_createdby;
		private int _b_statuscode;
		private bool _b_isdel;
		private bool _b_istui;
		private byte[] _b_tuiimg;
		private string _shuxing;
		private int? _pinglun;
		private int _o_id;
		private int? _c_id;
		private string _o_code;
		private int? _m_id;
		private DateTime? _o_createon;
		private decimal? _o_pric;
		private int? _o_statuscode;
		private string _o_mark;
		private bool _o_isdel;
		private int? _pay_id;
		private int? _st_id;
		private int _os_id;
        private int? _os_pcount;
        private int _os_oid;
        private decimal? _o_zhek;
        private int? _o_score;
        private bool _os_isgp;


        public bool os_IsGP
        {
            set { _os_isgp = value; }
            get { return _os_isgp; }
        }
        public decimal? o_Zhek
        {
            set { _o_zhek = value; }
            get { return _o_zhek; }
        }
        public int? o_Score
        {
            set { _o_score = value; }
            get { return _o_score; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int b_ID
		{
			set{ _b_id=value;}
			get{return _b_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string b_Name
		{
			set{ _b_name=value;}
			get{return _b_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int p_ID
		{
			set{ _p_id=value;}
			get{return _p_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string p_Name
		{
			set{ _p_name=value;}
			get{return _p_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime p_ModifyOn
		{
			set{ _p_modifyon=value;}
			get{return _p_modifyon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid p_ModifyBy
		{
			set{ _p_modifyby=value;}
			get{return _p_modifyby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int p_StatusCode
		{
			set{ _p_statuscode=value;}
			get{return _p_statuscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool p_IsDel
		{
			set{ _p_isdel=value;}
			get{return _p_isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int p_SellStatus
		{
			set{ _p_sellstatus=value;}
			get{return _p_sellstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int pi_ID
		{
			set{ _pi_id=value;}
			get{return _pi_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pi_Url
		{
			set{ _pi_url=value;}
			get{return _pi_url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool pi_Type
		{
			set{ _pi_type=value;}
			get{return _pi_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool pi_isDel
		{
			set{ _pi_isdel=value;}
			get{return _pi_isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pi_StatusCode
		{
			set{ _pi_statuscode=value;}
			get{return _pi_statuscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string p_MeasurementUnit
		{
			set{ _p_measurementunit=value;}
			get{return _p_measurementunit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int pt_ID
		{
			set{ _pt_id=value;}
			get{return _pt_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pt_Name
		{
			set{ _pt_name=value;}
			get{return _pt_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int pt_ParentId
		{
			set{ _pt_parentid=value;}
			get{return _pt_parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int pt_StatusCode
		{
			set{ _pt_statuscode=value;}
			get{return _pt_statuscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid pt_CreatedBy
		{
			set{ _pt_createdby=value;}
			get{return _pt_createdby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime pt_CreatedOn
		{
			set{ _pt_createdon=value;}
			get{return _pt_createdon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool pt_IsDel
		{
			set{ _pt_isdel=value;}
			get{return _pt_isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pt_ImgUrl
		{
			set{ _pt_imgurl=value;}
			get{return _pt_imgurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int sku_ID
		{
			set{ _sku_id=value;}
			get{return _sku_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal sku_Price
		{
			set{ _sku_price=value;}
			get{return _sku_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? sku_CostPrice
		{
			set{ _sku_costprice=value;}
			get{return _sku_costprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int sku_SalesCount
		{
			set{ _sku_salescount=value;}
			get{return _sku_salescount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sku_Stock
		{
			set{ _sku_stock=value;}
			get{return _sku_stock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sku_Code
		{
			set{ _sku_code=value;}
			get{return _sku_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime sku_CreatedOn
		{
			set{ _sku_createdon=value;}
			get{return _sku_createdon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid sku_CreatedBy
		{
			set{ _sku_createdby=value;}
			get{return _sku_createdby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime sku_ModifyOn
		{
			set{ _sku_modifyon=value;}
			get{return _sku_modifyon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid sku_ModifyBy
		{
			set{ _sku_modifyby=value;}
			get{return _sku_modifyby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int sku_StatusCode
		{
			set{ _sku_statuscode=value;}
			get{return _sku_statuscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool sku_IsDel
		{
			set{ _sku_isdel=value;}
			get{return _sku_isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? sku_scPric
		{
			set{ _sku_scpric=value;}
			get{return _sku_scpric;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool sku_ismoren
		{
			set{ _sku_ismoren=value;}
			get{return _sku_ismoren;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? p_Province
		{
			set{ _p_province=value;}
			get{return _p_province;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? p_City
		{
			set{ _p_city=value;}
			get{return _p_city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? p_County
		{
			set{ _p_county=value;}
			get{return _p_county;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid p_CreatedBy
		{
			set{ _p_createdby=value;}
			get{return _p_createdby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime p_CreatedOn
		{
			set{ _p_createdon=value;}
			get{return _p_createdon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string b_Key
		{
			set{ _b_key=value;}
			get{return _b_key;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string b_SiteUrl
		{
			set{ _b_siteurl=value;}
			get{return _b_siteurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string b_LogoUrl
		{
			set{ _b_logourl=value;}
			get{return _b_logourl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int b_Sort
		{
			set{ _b_sort=value;}
			get{return _b_sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime b_CreatedOn
		{
			set{ _b_createdon=value;}
			get{return _b_createdon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid b_CreatedBy
		{
			set{ _b_createdby=value;}
			get{return _b_createdby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int b_StatusCode
		{
			set{ _b_statuscode=value;}
			get{return _b_statuscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool b_IsDel
		{
			set{ _b_isdel=value;}
			get{return _b_isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool b_IsTui
		{
			set{ _b_istui=value;}
			get{return _b_istui;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] b_TuiImg
		{
			set{ _b_tuiimg=value;}
			get{return _b_tuiimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int o_ID
		{
			set{ _o_id=value;}
			get{return _o_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? c_ID
		{
			set{ _c_id=value;}
			get{return _c_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string o_Code
		{
			set{ _o_code=value;}
			get{return _o_code;}
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
		public DateTime? o_CreateOn
		{
			set{ _o_createon=value;}
			get{return _o_createon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? o_Pric
		{
			set{ _o_pric=value;}
			get{return _o_pric;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? o_StatusCode
		{
			set{ _o_statuscode=value;}
			get{return _o_statuscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string o_Mark
		{
			set{ _o_mark=value;}
			get{return _o_mark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool o_IsDel
		{
			set{ _o_isdel=value;}
			get{return _o_isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pay_ID
		{
			set{ _pay_id=value;}
			get{return _pay_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? st_ID
		{
			set{ _st_id=value;}
			get{return _st_id;}
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
		public int? os_pCount
		{
			set{ _os_pcount=value;}
			get{return _os_pcount;}
		}
		public int os_oID
		{
			set{ _os_oid=value;}
            get { return _os_oid; }
		}
		#endregion Model

	}
}

