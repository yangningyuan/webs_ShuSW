using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace webs_YueyxShop.Model
{
    /// <summary>
    /// VipRank:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class VipRank
    {
        public VipRank()
        { }
        #region Model
        private int _r_id;
        private string _r_name;
        private decimal? _r_zhek;
        private int? _r_score;
        private int? _r_status = 0;
        public int r_Rank { get; set; }
        public int r_UpperScore { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int r_ID
        {
            set { _r_id = value; }
            get { return _r_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string r_Name
        {
            set { _r_name = value; }
            get { return _r_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? r_ZheK
        {
            set { _r_zhek = value; }
            get { return _r_zhek; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? r_Score
        {
            set { _r_score = value; }
            get { return _r_score; }
        }
        /// <summary>
        /// 0.启用1.禁用2.删除
        /// </summary>
        public int? r_Status
        {
            set { _r_status = value; }
            get { return _r_status; }
        }
        #endregion Model

    }
}
