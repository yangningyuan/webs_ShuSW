using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text;
namespace webs_YueyxShop.IDAL
{
    /// <summary>
    /// 接口层MemberBase
    /// </summary>
    public interface IMemberBase
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int m_ID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Model.MemberBase model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Model.MemberBase model);
        /// <summary>
        /// 获得会员信息详情
        /// </summary>
        /// <param name="m_id"></param>
        /// <returns></returns>
        Model.MemberInfo getMemberInfo(int m_id);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int m_ID);
        bool DeleteList(string m_IDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Model.MemberBase GetModel(int m_ID);
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
