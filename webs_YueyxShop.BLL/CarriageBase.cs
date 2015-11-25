using System;
using System.Data;
using System.Collections.Generic;
using Common;
using System.Linq;
using webs_YueyxShop.Model;
using webs_YueyxShop.DALFactory;
using webs_YueyxShop.IDAL;
namespace webs_YueyxShop.BLL
{
	/// <summary>
	/// CarriageBase
	/// </summary>
	public partial class CarriageBase
	{
		private readonly ICarriageBase dal=DataAccess.CreateCarriageBase();
		public CarriageBase()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int car_ID)
		{
			return dal.Exists(car_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(webs_YueyxShop.Model.CarriageBase model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(webs_YueyxShop.Model.CarriageBase model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int car_ID)
		{
			
			return dal.Delete(car_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string car_IDlist )
		{
			return dal.DeleteList(car_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public webs_YueyxShop.Model.CarriageBase GetModel(int car_ID)
		{
			
			return dal.GetModel(car_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public webs_YueyxShop.Model.CarriageBase GetModelByCache(int car_ID)
		{
			
			string CacheKey = "CarriageBaseModel-" + car_ID;
			object objModel = Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(car_ID);
					if (objModel != null)
					{
						int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
						Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (webs_YueyxShop.Model.CarriageBase)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<webs_YueyxShop.Model.CarriageBase> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<webs_YueyxShop.Model.CarriageBase> DataTableToList(DataTable dt)
		{
			List<webs_YueyxShop.Model.CarriageBase> modelList = new List<webs_YueyxShop.Model.CarriageBase>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				webs_YueyxShop.Model.CarriageBase model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new webs_YueyxShop.Model.CarriageBase();
					if(dt.Rows[n]["car_ID"]!=null && dt.Rows[n]["car_ID"].ToString()!="")
					{
						model.car_ID=int.Parse(dt.Rows[n]["car_ID"].ToString());
					}
					if(dt.Rows[n]["ct_ID"]!=null && dt.Rows[n]["ct_ID"].ToString()!="")
					{
						model.ct_ID=int.Parse(dt.Rows[n]["ct_ID"].ToString());
					}
                    if (dt.Rows[n]["St_ID"] != null && dt.Rows[n]["St_ID"].ToString() != "")
					{
                        model.St_ID = dt.Rows[n]["St_ID"].ToString();
					}
					if(dt.Rows[n]["car_measurementUnits"]!=null && dt.Rows[n]["car_measurementUnits"].ToString()!="")
					{
					model.car_measurementUnits=int.Parse(dt.Rows[n]["car_measurementUnits"].ToString());
					}
					if(dt.Rows[n]["car_shouCount"]!=null && dt.Rows[n]["car_shouCount"].ToString()!="")
					{
						model.car_shouCount=int.Parse(dt.Rows[n]["car_shouCount"].ToString());
					}
					if(dt.Rows[n]["car_shouCarriage"]!=null && dt.Rows[n]["car_shouCarriage"].ToString()!="")
					{
						model.car_shouCarriage=decimal.Parse(dt.Rows[n]["car_shouCarriage"].ToString());
					}
					if(dt.Rows[n]["car_xuCount"]!=null && dt.Rows[n]["car_xuCount"].ToString()!="")
					{
						model.car_xuCount=int.Parse(dt.Rows[n]["car_xuCount"].ToString());
					}
					if(dt.Rows[n]["car_xuCarriage"]!=null && dt.Rows[n]["car_xuCarriage"].ToString()!="")
					{
						model.car_xuCarriage=decimal.Parse(dt.Rows[n]["car_xuCarriage"].ToString());
					}
					if(dt.Rows[n]["car_area"]!=null && dt.Rows[n]["car_area"].ToString()!="")
					{
					model.car_area=dt.Rows[n]["car_area"].ToString();
					}
					if(dt.Rows[n]["car_Ismoren"]!=null && dt.Rows[n]["car_Ismoren"].ToString()!="")
					{
                        model.car_Ismoren = bool.Parse(dt.Rows[n]["car_Ismoren"].ToString());
					}
					if(dt.Rows[n]["car_StatusCode"]!=null && dt.Rows[n]["car_StatusCode"].ToString()!="")
					{
						model.car_StatusCode=int.Parse(dt.Rows[n]["car_StatusCode"].ToString());
					}
					if(dt.Rows[n]["car_IsDel"]!=null && dt.Rows[n]["car_IsDel"].ToString()!="")
					{
						if((dt.Rows[n]["car_IsDel"].ToString()=="1")||(dt.Rows[n]["car_IsDel"].ToString().ToLower()=="true"))
						{
						model.car_IsDel=true;
						}
						else
						{
							model.car_IsDel=false;
						}
					}
					modelList.Add(model);
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method


        public DataSet GetModelListByid(string p)
        {
            var ds = dal.GetModelListByid(p);
            if (ds != null && ds.Tables.Count > 0)
            {
                var stList = new ShipTypeBase().GetModelList(" st_IsDel = 0 ");
                ds.Tables[0].Columns.Add("st_Name", Type.GetType("System.String"));
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var shipt = new BLL.ShipTypeBase().GetModelList(" st_ID='" +row["st_Id"].ToString()+ "' and st_IsDel=0 ");
                    if (shipt.Count > 0)
                    {
                        var st = stList.Where(m => m.st_ID == shipt[0].st_ID).FirstOrDefault();
                    
                    if (st != null)
                    {
                        row["st_Name"] = st.st_Name;
                    }
                    }
                }
            }
            return ds;
        }
    }
}

