using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace webs_YueyxShop.Model
{
    [Serializable]
    public class NewsBase
    {
        public NewsBase()
        { }
        #region Model
        private int _n_id;
        private Guid _m_id;
        private string _n_title;
        private string _n_synopsis;
        private string _n_content;
        private string _n_picurl;
        private string _n_redirecturl;
        private string _n_qrcode;
        private bool _n_istop = false;
        private int _n_sort = 0;
        private string _n_source;
        private string _n_writer;
        private DateTime _n_createdon = DateTime.Now;
        private Guid _n_createdby;
        private DateTime _n_modifyon = DateTime.Now;
        private int _n_statuscode = 0;
        private bool _n_isdel = false;
        /// <summary>
        /// 新闻ID
        /// </summary>
        public int n_ID
        {
            set { _n_id = value; }
            get { return _n_id; }
        }
        /// <summary>
        /// 菜单信息ID
        /// </summary>
        public Guid m_ID
        {
            set { _m_id = value; }
            get { return _m_id; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string n_Title
        {
            set { _n_title = value; }
            get { return _n_title; }
        }
        /// <summary>
        /// 简介
        /// </summary>
        public string n_Synopsis
        {
            set { _n_synopsis = value; }
            get { return _n_synopsis; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string n_Content
        {
            set { _n_content = value; }
            get { return _n_content; }
        }
        /// <summary>
        /// 标题图片
        /// </summary>
        public string n_PicUrl
        {
            set { _n_picurl = value; }
            get { return _n_picurl; }
        }
        /// <summary>
        /// 外链地址
        /// </summary>
        public string n_RedirectUrl
        {
            set { _n_redirecturl = value; }
            get { return _n_redirecturl; }
        }
        /// <summary>
        /// 二维码地址
        /// </summary>
        public string n_QRCode
        {
            set { _n_qrcode = value; }
            get { return _n_qrcode; }
        }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool n_IsTop
        {
            set { _n_istop = value; }
            get { return _n_istop; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int n_Sort
        {
            set { _n_sort = value; }
            get { return _n_sort; }
        }
        /// <summary>
        /// 来源
        /// </summary>
        public string n_Source
        {
            set { _n_source = value; }
            get { return _n_source; }
        }
        /// <summary>
        /// 作者
        /// </summary>
        public string n_Writer
        {
            set { _n_writer = value; }
            get { return _n_writer; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime n_CreatedOn
        {
            set { _n_createdon = value; }
            get { return _n_createdon; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid n_CreatedBy
        {
            set { _n_createdby = value; }
            get { return _n_createdby; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime n_ModifyOn
        {
            set { _n_modifyon = value; }
            get { return _n_modifyon; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int n_StatusCode
        {
            set { _n_statuscode = value; }
            get { return _n_statuscode; }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public bool n_IsDel
        {
            set { _n_isdel = value; }
            get { return _n_isdel; }
        }
        #endregion Model
    }
}
