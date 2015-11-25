using System;
using System.Data;
using System.Collections.Generic;
namespace webs_YueyxShop.IDAL
{
	/// <summary>
	/// 接口层商品信息表
	/// </summary>
	public interface IProductBase
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int p_ID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
        int Add(webs_YueyxShop.Model.ProductBase model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(webs_YueyxShop.Model.ProductBase model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int p_ID);
		bool DeleteList(string p_IDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		webs_YueyxShop.Model.ProductBase GetModel(int p_ID);
		webs_YueyxShop.Model.ProductBase DataRowToModel(DataRow row);
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
		#region  MethodEx

		#endregion  MethodEx

        DataSet GetModelListById(string p);

        int GetSort();

        bool UpdateList(string pid);

        bool UpdateListx(string pid);
        List<Model.ProductBase> GetpInfoByTypeId(int cid);

        DataTable GetProductDetail(string strWhere);

        DataTable GetProductPropertyDetail(string strWhere);


        List<Model.ProductBase> GetpInfoByRecommendTypeId(int id);
    } 
}
