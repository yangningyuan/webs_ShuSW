using System;
using System.Data;
using System.Collections.Generic;
namespace webs_YueyxShop.IDAL
{
	/// <summary>
	/// 接口层商品属性
	/// </summary>
	public interface IProductAttributesBase
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int pa_ID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(webs_YueyxShop.Model.ProductAttributesBase model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(webs_YueyxShop.Model.ProductAttributesBase model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int pa_ID);
		bool DeleteList(string pa_IDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		webs_YueyxShop.Model.ProductAttributesBase GetModel(int pa_ID);
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

        string GetCode(string m_BianM, int m_CengJ);

        int GetSort(string pid, int layer);

        bool UpdateList(Model.ProductAttributesBase pa);
        bool UpdateList2(int code, int id);

        DataSet GetListwithtype(string p);

        DataSet GetModelListById(string p);

        List<Model.ProductAttributesBase> GetModelListByskuId(string p);

        List<Model.ProductAttributesBase> GetModelListByPid(string p);
    } 
}
