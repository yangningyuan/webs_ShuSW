/**  版本信息模板在安装目录下，可自行修改。
* DepartmentBase.cs
*
* 功 能： N/A
* 类 名： DepartmentBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/28 14:36:01   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Common;
using webs_YueyxShop.Model;
using webs_YueyxShop.DALFactory;
using webs_YueyxShop.IDAL;
namespace webs_YueyxShop.BLL
{
    /// <summary>
    /// 部门信息表
    /// </summary>
    public partial class DepartmentBase
    {
        private readonly IDepartmentBase dal = DataAccess.CreateDepartmentBase();
        public DepartmentBase()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid d_ID)
        {
            return dal.Exists(d_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(webs_YueyxShop.Model.DepartmentBase model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(webs_YueyxShop.Model.DepartmentBase model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid d_ID)
        {

            return dal.Delete(d_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string d_IDlist)
        {
            return dal.DeleteList(Common.PageValidate.SafeLongFilter(d_IDlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public webs_YueyxShop.Model.DepartmentBase GetModel(Guid d_ID)
        {

            return dal.GetModel(d_ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public webs_YueyxShop.Model.DepartmentBase GetModelByCache(Guid d_ID)
        {

            string CacheKey = "DepartmentBaseModel-" + d_ID;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(d_ID);
                    if (objModel != null)
                    {
                        int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (webs_YueyxShop.Model.DepartmentBase)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<webs_YueyxShop.Model.DepartmentBase> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<webs_YueyxShop.Model.DepartmentBase> DataTableToList(DataTable dt)
        {
            List<webs_YueyxShop.Model.DepartmentBase> modelList = new List<webs_YueyxShop.Model.DepartmentBase>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                webs_YueyxShop.Model.DepartmentBase model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 是否同名
        /// </summary>
        public bool IsExists(string d_ID, string d_MingCh)
        {
            return dal.IsExists(d_ID, d_MingCh);
        }
        /// <summary>
        /// 是否含有下级
        /// </summary>
        public bool IsSub(Guid did)
        {
            return dal.IsSub(did);
        }
        /// <summary>
        /// 更改状态
        /// </summary>
        /// <param name="d_StateCode">要修改成的状态</param>
        public bool UpdateState(int d_StateCode, Guid d_ID)
        {
            return dal.UpdateState(d_StateCode, d_ID);
        }
         /// <summary>
        /// 获取编码
        /// </summary>
        /// <param name="CengJ">当前层级</param>
        /// <param name="BianM">父级编码</param>
        public string GetCode(int CengJ, string BianM)
        {
            return dal.GetCode(CengJ, BianM);
        }
        #endregion  ExtensionMethod
    }
}

