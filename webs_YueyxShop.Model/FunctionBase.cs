/**  版本信息模板在安装目录下，可自行修改。
* FunctionBase.cs
*
* 功 能： N/A
* 类 名： FunctionBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/28 14:36:02   N/A    初版
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
    /// 功能信息表
    /// </summary>
    [Serializable]
    public partial class FunctionBase
    {
        public FunctionBase()
        {
        }

        #region Model

        private Guid _f_id;
        private string _f_bianm;
        private string _f_mingch;
        private int _f_cengj = 0;
        private Guid _f_parentid;
        private string _f_miaosh;
        private string _f_zhujm;
        private int _f_paix = 0;
        private DateTime _f_createdon = DateTime.Now;
        private Guid _f_createdby;
        private int _f_statuscode = 0;
        private int _f_deletestatecode = 0;

        /// <summary>
        /// 功能信息表ID
        /// </summary>
        public Guid f_ID
        {
            set { _f_id = value; }
            get { return _f_id; }
        }

        /// <summary>
        /// 功能编码(每级三位)
        /// </summary>
        public string f_BianM
        {
            set { _f_bianm = value; }
            get { return _f_bianm; }
        }

        /// <summary>
        /// 功能名称
        /// </summary>
        public string f_MingCh
        {
            set { _f_mingch = value; }
            get { return _f_mingch; }
        }

        /// <summary>
        /// 层级
        /// </summary>
        public int f_CengJ
        {
            set { _f_cengj = value; }
            get { return _f_cengj; }
        }

        /// <summary>
        /// 上级ID
        /// </summary>
        public Guid f_ParentId
        {
            set { _f_parentid = value; }
            get { return _f_parentid; }
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string f_MiaoSh
        {
            set { _f_miaosh = value; }
            get { return _f_miaosh; }
        }

        /// <summary>
        /// 助记码(便于查找该功能，同一层级不允许重复)
        /// </summary>
        public string f_ZhuJM
        {
            set { _f_zhujm = value; }
            get { return _f_zhujm; }
        }

        /// <summary>
        /// 排序
        /// </summary>
        public int f_PaiX
        {
            set { _f_paix = value; }
            get { return _f_paix; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime f_CreatedOn
        {
            set { _f_createdon = value; }
            get { return _f_createdon; }
        }

        /// <summary>
        /// 创建人
        /// </summary>
        public Guid f_CreatedBy
        {
            set { _f_createdby = value; }
            get { return _f_createdby; }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public int f_StatusCode
        {
            set { _f_statuscode = value; }
            get { return _f_statuscode; }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public int f_DeleteStateCode
        {
            set { _f_deletestatecode = value; }
            get { return _f_deletestatecode; }
        }

        #endregion Model

    }
}

