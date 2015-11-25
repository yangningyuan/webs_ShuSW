using System;
namespace webs_YueyxShop.Model
{
	/// <summary>
	/// vw_PInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class vw_PInfo
	{
		public vw_PInfo()
		{}
		#region Model
        private int _skucount;
		private int _expr1;
		private string _b_name;
		private int _expr2;
		private string _p_name;
		private DateTime _p_modifyon;
		private Guid _p_modifyby;
		private int _p_statuscode;
		private bool _p_isdel;
		private int _p_sellstatus;
		private int _expr3;
		private string _pi_url;
        private bool _expr4;
		private bool _expr5;
		private int? _expr6;
		private string _p_measurementunit;
		private int _expr17;
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
        private string _sku_tdcode;
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
        private int _vc_ID;
        private DateTime _vc_CreateOn;
        private bool _vc_IsDel;
        private int _pa_Satisfied;
        private string _pa_Content;
        private int _pa_id;
        private DateTime _pa_CreatedOn;
        private bool _pa_IsDel;
        private int _gz;

        public int skucount
        {
            set { _skucount = value; }
            get { return _skucount; }
        }

        public int pa_Satisfied
        {
            set { _pa_Satisfied = value; }
            get { return _pa_Satisfied; }
        }
        public string pa_Content
        {
            set { _pa_Content = value; }
            get { return _pa_Content; }
        }
        public int pa_id
        {
            set { _pa_id = value; }
            get { return _pa_id; }
        }
        public DateTime pa_CreatedOn
        {
            set { _pa_CreatedOn = value; }
            get { return _pa_CreatedOn; }
        }
        public bool pa_IsDel
        {
            set { _pa_IsDel = value; }
            get { return _pa_IsDel; }
        }
		/// <summary>
		/// 
		/// </summary>
        public int b_ID
		{
			set{ _expr1=value;}
			get{return _expr1;}
        }
        public int gz
        {
            set { _gz = value; }
            get { return _gz; }
        }
        /// <summary>
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
			set{ _expr2=value;}
			get{return _expr2;}
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
			set{ _expr3=value;}
			get{return _expr3;}
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
			set{ _expr4=value;}
			get{return _expr4;}
		}
		/// <summary>
		/// 
		/// </summary>
        public bool pi_isDel
		{
			set{ _expr5=value;}
			get{return _expr5;}
		}
		/// <summary>
		/// 
		/// </summary>
        public int? pi_StatusCode
		{
			set{ _expr6=value;}
			get{return _expr6;}
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
			set{ _expr17=value;}
			get{return _expr17;}
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
        public string sku_tdcode
        {
            set { _sku_tdcode = value; }
            get { return _sku_tdcode; }
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
		public string shuxing
		{
			set{ _shuxing=value;}
			get{return _shuxing;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pinglun
		{
			set{ _pinglun=value;}
			get{return _pinglun;}
        }
        public int vc_id
        {
            set { _vc_ID = value; }
            get { return _vc_ID; }
        }
        public DateTime vc_CreateOn
        {
            set { _vc_CreateOn = value; }
            get { return _vc_CreateOn; }
        }
        public bool vc_IsDel
        {
            set { _vc_IsDel = value; }
            get { return _vc_IsDel; }
        }
		#endregion Model


        
    }
}

