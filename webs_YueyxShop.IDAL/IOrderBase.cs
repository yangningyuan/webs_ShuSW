﻿/**  版本信息模板在安装目录下，可自行修改。
* OrderBase.cs
*
* 功 能： N/A
* 类 名： OrderBase
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/11 14:43:35   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
namespace webs_YueyxShop.IDAL
{
	/// <summary>
	/// 接口层OrderBase
	/// </summary>
	public interface IOrderBase
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int o_ID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(webs_YueyxShop.Model.OrderBase model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(webs_YueyxShop.Model.OrderBase model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int o_ID);
		bool DeleteList(string o_IDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		webs_YueyxShop.Model.OrderBase GetModel(int o_ID);
		webs_YueyxShop.Model.OrderBase DataRowToModel(DataRow row);
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

        DataTable GetOrderDetialList(string strWhere);

        DataTable GetOrderProductList(string strWhere);

		#endregion  MethodEx

        DataSet GetModelListbypric(string p);

        DataSet GetregList(string p);

        Model.OrderBase DataRowToModel2(DataRow dataRow);
    } 
}
