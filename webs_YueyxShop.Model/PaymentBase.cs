/**  版本信息模板在安装目录下，可自行修改。
* PaymentBase.cs
*
* 功 能： N/A
* 类 名： PaymentBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/13 12:01:52   N/A    初版
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
    /// PaymentBase:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PaymentBase
    {
        public PaymentBase()
        { }
        #region Model
        private int _pay_id;
        private string _pay_name;
        private string _pay_url;
        private bool _pay_isdel;
        private bool _pay_isphone;
        /// <summary>
        /// 
        /// </summary>
        public int pay_ID
        {
            set { _pay_id = value; }
            get { return _pay_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pay_Name
        {
            set { _pay_name = value; }
            get { return _pay_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pay_Url
        {
            set { _pay_url = value; }
            get { return _pay_url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool pay_IsDel
        {
            set { _pay_isdel = value; }
            get { return _pay_isdel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool pay_isPhone
        {
            set { _pay_isphone = value; }
            get { return _pay_isphone; }
        }
        #endregion Model

    }
}

