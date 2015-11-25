using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace webs_YueyxShop.IDAL
{
    /// <summary>
    /// 接口层新闻信息表
    /// </summary>
    public interface INewsBase
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int n_ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Model.NewsBase model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Model.NewsBase model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int n_ID);
        bool DeleteList(string n_IDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Model.NewsBase GetModel(int n_ID);
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
       
       
       
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    } 
}
