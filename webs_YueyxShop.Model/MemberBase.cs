using System;
namespace webs_YueyxShop.Model
{
    /// <summary>
    /// MemberBase:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class MemberBase
    {
        public MemberBase()
        { }
        #region Model
        private int _m_id;
        private string _m_username;
        private string _m_password;
        private int? _m_usertype = 0;
        private string _m_yingyzz;
        private int? _m_score;
        private int? _m_rank;
        private string _m_nickname;
        private string _m_realname;
        private int _m_sex = 0;
        private DateTime? _m_birthday;
        private string _m_phone;
        private string _m_email;
        private string _m_qq;
        private DateTime _m_createdon = DateTime.Now;
        private decimal? _m_zhek;
        private int _m_statuscode = 0;
        public int m_ShenPstatus { get; set; }
        public string m_GDPhone { get; set; }
        public string m_GongSiName { get; set; }
        public string m_GongSiDiQu { get; set; }
        public string m_GongSiAddress { get; set; }
        private DateTime? _m_closedate = DateTime.Now;
        public string m_HeadImg { get; set; }
        private int? _m_provice;
        private int? _m_city;
        private int? _m_count;
        private bool _m_mailyanzheng;
        private string _m_zhiye;
        private string _m_introduction;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? m_CloseDate
        {
            set { _m_closedate = value; }
            get { return _m_closedate; }
        }
        /// <summary>
        /// 会员id
        /// </summary>
        public int m_ID
        {
            set { _m_id = value; }
            get { return _m_id; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string m_UserName
        {
            set { _m_username = value; }
            get { return _m_username; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string m_Password
        {
            set { _m_password = value; }
            get { return _m_password; }
        }
        /// <summary>
        /// 会员类型0.零售用户1.散批商2.加盟商
        /// </summary>
        public int? m_UserType
        {
            set { _m_usertype = value; }
            get { return _m_usertype; }
        }
        /// <summary>
        /// 营业执照号
        /// </summary>
        public string m_YingYZZ
        {
            set { _m_yingyzz = value; }
            get { return _m_yingyzz; }
        }
        /// <summary>
        /// 积分
        /// </summary>
        public int? m_Score
        {
            set { _m_score = value; }
            get { return _m_score; }
        }
        /// <summary>
        /// 等级
        /// </summary>
        public int? m_Rank
        {
            set { _m_rank = value; }
            get { return _m_rank; }
        }
        /// <summary>
        /// 昵称
        /// </summary>
        public string m_NickName
        {
            set { _m_nickname = value; }
            get { return _m_nickname; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string m_RealName
        {
            set { _m_realname = value; }
            get { return _m_realname; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public int m_Sex
        {
            set { _m_sex = value; }
            get { return _m_sex; }
        }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? m_Birthday
        {
            set { _m_birthday = value; }
            get { return _m_birthday; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string m_Phone
        {
            set { _m_phone = value; }
            get { return _m_phone; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string m_Email
        {
            set { _m_email = value; }
            get { return _m_email; }
        }
        /// <summary>
        /// QQ
        /// </summary>
        public string m_QQ
        {
            set { _m_qq = value; }
            get { return _m_qq; }
        }
        /// <summary>
        /// 注册日期
        /// </summary>
        public DateTime m_CreatedOn
        {
            set { _m_createdon = value; }
            get { return _m_createdon; }
        }
        /// <summary>
        /// 折扣
        /// </summary>
        public decimal? m_ZheK
        {
            set { _m_zhek = value; }
            get { return _m_zhek; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int m_StatusCode
        {
            set { _m_statuscode = value; }
            get { return _m_statuscode; }
        }
        /// <summary>
        /// 省ID
        /// </summary>
        public int? m_Provice
        {
            set { _m_provice = value; }
            get { return _m_provice; }
        }
        /// <summary>
        /// 市ID
        /// </summary>
        public int? m_City
        {
            set { _m_city = value; }
            get { return _m_city; }
        }
        /// <summary>
        /// 区县ID
        /// </summary>
        public int? m_Count
        {
            set { _m_count = value; }
            get { return _m_count; }
        }
        /// <summary>
        /// 邮箱验证
        /// </summary>
        public bool m_mailyanzheng
        {
            set { _m_mailyanzheng = value; }
            get { return _m_mailyanzheng; }
        }
        /// <summary>
        /// 所属职业
        /// </summary>
        public string m_ZhiYe
        {
            set { _m_zhiye = value; }
            get { return _m_zhiye; }
        }
        public int midcount
        { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string m_Introduction
        {
            set { _m_introduction = value; }
            get { return _m_introduction; }
        }
        #endregion Model

    }
}

