using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace webs_YueyxShop.Model
{
    /// <summary>
    /// AdertPositionBase:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class AdertPositionBase
    {
        public AdertPositionBase()
        { }
        #region Model
        private int _p_id;
        private string _p_positionname;
        private string _p_positionexplain;
        private DateTime? _p_createdate = DateTime.Now;
        private Guid _p_createuser;
        private int? _p_status=0;
        private int? _p_delete=0;
        private string _p_showposition;
        private int? _p_producttype;
        /// <summary>
        /// 广告位置ID
        /// </summary>
        public int p_ID
        {
            set { _p_id = value; }
            get { return _p_id; }
        }
        /// <summary>
        /// 位置名称
        /// </summary>
        public string p_PositionName
        {
            set { _p_positionname = value; }
            get { return _p_positionname; }
        }
        /// <summary>
        /// 是否固定不可更改  0可更改 1.固定不可更改
        /// </summary>
        public string p_PositionExplain
        {
            set { _p_positionexplain = value; }
            get { return _p_positionexplain; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? p_CreateDate
        {
            set { _p_createdate = value; }
            get { return _p_createdate; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid p_CreateUser
        {
            set { _p_createuser = value; }
            get { return _p_createuser; }
        }
        /// <summary>
        /// 0.正常1.冻结
        /// </summary>
        public int? p_Status
        {
            set { _p_status = value; }
            get { return _p_status; }
        }
        /// <summary>
        /// 0.正常1.删除
        /// </summary>
        public int? p_Delete
        {
            set { _p_delete = value; }
            get { return _p_delete; }
        }
        /// <summary>
        /// 显示位置 左边右边
        /// </summary>
        public string p_showposition
        {
            set { _p_showposition = value; }
            get { return _p_showposition; }
        }
        /// <summary>
        /// 商品分类id
        /// </summary>
        public int? p_producttype
        {
            set { _p_producttype = value; }
            get { return _p_producttype; }
        }
        #endregion Model

    }
}
