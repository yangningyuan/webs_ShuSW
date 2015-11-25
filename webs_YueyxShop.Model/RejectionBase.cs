/**  版本信息模板在安装目录下，可自行修改。
* RejectionBase.cs
*
* 功 能： N/A
* 类 名： RejectionBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/13 11:35:11   N/A    初版
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
    /// RejectionBase:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class RejectionBase
    {
        public RejectionBase()
        { }
        #region Model
        private int _r_id;
        private int? _o_id;
        private int? _m_id;
        private DateTime? _r_date;
        private int? _r_status;
        private bool _r_isdelete;
        private string _r_remarks;
        private decimal _r_Price;
        private string _r_Code;

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
        public int? o_ID
        {
            set { _o_id = value; }
            get { return _o_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? m_ID
        {
            set { _m_id = value; }
            get { return _m_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? r_Date
        {
            set { _r_date = value; }
            get { return _r_date; }
        }
        /// <summary>
        /// 0,未确认，1拒绝，2完成
        /// </summary>
        public int? r_Status
        {
            set { _r_status = value; }
            get { return _r_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool r_IsDelete
        {
            set { _r_isdelete = value; }
            get { return _r_isdelete; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string r_Remarks
        {
            set { _r_remarks = value; }
            get { return _r_remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal r_Price
        {
            set { _r_Price = value; }
            get { return _r_Price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string r_Code
        {
            set { _r_Code = value; }
            get { return _r_Code; }
        }

        #endregion Model

    }
}