﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace webs_YueyxShop.IDAL
{
    /// <summary>
    /// 接口层AdertPositionBase
    /// </summary>
    public interface IAdertPositionBase
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int p_ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Model.AdertPositionBase model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Model.AdertPositionBase model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int p_ID);
        bool DeleteList(string p_IDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Model.AdertPositionBase GetModel(int p_ID);
        Model.AdertPositionBase DataRowToModel(DataRow row);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        int GetRecordCount(string strWhere);
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    } 
}
