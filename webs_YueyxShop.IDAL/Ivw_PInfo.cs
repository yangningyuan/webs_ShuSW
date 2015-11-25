using System;
using System.Data;
namespace webs_YueyxShop.IDAL
{
	/// <summary>
	/// 接口层vw_PInfo
	/// </summary>
	public interface Ivw_PInfo
	{
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
        bool Add(webs_YueyxShop.Model.vw_PInfo model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
        bool Update(webs_YueyxShop.Model.vw_PInfo model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete();
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        webs_YueyxShop.Model.vw_PInfo GetModel();
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		int GetRecordCount(string strWhere);
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法

        /// <summary>
        /// 数据分页列表
        /// </summary>
        DataSet GetList(string p, int p_2, int pagerows,string sortby);

        DataSet GetListVC(string p, int page, int pagerows, string sortby);

        DataSet getguanzhu(string p, int page, int pagerows);

        DataSet GetListPA(string p, int page, int pagerows, string sortby);

        DataSet getmodelListPH();
    } 
}
