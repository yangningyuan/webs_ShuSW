using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace webs_YueyxShop.Model
{
    /// <summary>
    /// Adert:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Adert
    {
        public Adert()
        { }
        #region Model
        private int _a_id;
        private int _a_pid;
        private string _a_title;
        private string _a_link;
        private string _a_image;
        private int? _a_sorting=0;
        private int? _a_istop=0;
        private DateTime? _a_createdate = DateTime.Now;
        private Guid _a_createuser;
        private int? _a_status=0;
        private int? _a_delete=0;
        private string _a_spare1;
        private int? _a_spare2;
        /// <summary>
        /// 
        /// </summary>
        public int a_ID
        {
            set { _a_id = value; }
            get { return _a_id; }
        }
        /// <summary>
        /// 广告位置ID
        /// </summary>
        public int a_PID
        {
            set { _a_pid = value; }
            get { return _a_pid; }
        }
        /// <summary>
        /// 广告标题
        /// </summary>
        public string a_Title
        {
            set { _a_title = value; }
            get { return _a_title; }
        }
        /// <summary>
        /// 广告链接
        /// </summary>
        public string a_Link
        {
            set { _a_link = value; }
            get { return _a_link; }
        }
        /// <summary>
        /// 广告显示图片
        /// </summary>
        public string a_Image
        {
            set { _a_image = value; }
            get { return _a_image; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int? a_Sorting
        {
            set { _a_sorting = value; }
            get { return _a_sorting; }
        }
        /// <summary>
        /// 是否置顶0.否1.是
        /// </summary>
        public int? a_IsTop
        {
            set { _a_istop = value; }
            get { return _a_istop; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? a_CreateDate
        {
            set { _a_createdate = value; }
            get { return _a_createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid a_CreateUser
        {
            set { _a_createuser = value; }
            get { return _a_createuser; }
        }
        /// <summary>
        /// 0.正常1.冻结
        /// </summary>
        public int? a_Status
        {
            set { _a_status = value; }
            get { return _a_status; }
        }
        /// <summary>
        /// 0.未删除1.删除
        /// </summary>
        public int? a_Delete
        {
            set { _a_delete = value; }
            get { return _a_delete; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string a_spare1
        {
            set { _a_spare1 = value; }
            get { return _a_spare1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? a_spare2
        {
            set { _a_spare2 = value; }
            get { return _a_spare2; }
        }
        #endregion Model
    }
}
