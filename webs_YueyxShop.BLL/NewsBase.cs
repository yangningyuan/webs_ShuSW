using System;
using System.Data;
using System.Collections.Generic;
using Common;
using webs_YueyxShop.Model;
using webs_YueyxShop.DALFactory;
using webs_YueyxShop.IDAL;
using webs_YueyxShop.DAL;
namespace webs_YueyxShop.BLL
{
    public partial class NewsBase
    {
        private readonly INewsBase dal = DataAccess.CreateNewsBase();
        public NewsBase()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int n_ID)
        {
            return dal.Exists(n_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.NewsBase model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.NewsBase model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int n_ID)
        {

            return dal.Delete(n_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string n_IDlist)
        {
            return dal.DeleteList(n_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.NewsBase GetModel(int n_ID)
        {

            return dal.GetModel(n_ID);
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
        public List<webs_YueyxShop.Model.NewsBase> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<webs_YueyxShop.Model.NewsBase> DataTableToList(DataTable dt)
        {
            List<webs_YueyxShop.Model.NewsBase> modelList = new List<webs_YueyxShop.Model.NewsBase>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                webs_YueyxShop.Model.NewsBase model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new webs_YueyxShop.Model.NewsBase();
                    if (dt.Rows[n]["n_ID"] != null && dt.Rows[n]["n_ID"].ToString() != "")
                    {
                        model.n_ID = int.Parse(dt.Rows[n]["n_ID"].ToString());
                    }
                    if (dt.Rows[n]["m_ID"] != null && dt.Rows[n]["m_ID"].ToString() != "")
                    {
                        model.m_ID = new Guid(dt.Rows[n]["m_ID"].ToString());
                    }
                    if (dt.Rows[n]["n_Title"] != null && dt.Rows[n]["n_Title"].ToString() != "")
                    {
                        model.n_Title = dt.Rows[n]["n_Title"].ToString();
                    }
                    if (dt.Rows[n]["n_Synopsis"] != null && dt.Rows[n]["n_Synopsis"].ToString() != "")
                    {
                        model.n_Synopsis = dt.Rows[n]["n_Synopsis"].ToString();
                    }
                    if (dt.Rows[n]["n_Content"] != null && dt.Rows[n]["n_Content"].ToString() != "")
                    {
                        model.n_Content = dt.Rows[n]["n_Content"].ToString();
                    }
                    if (dt.Rows[n]["n_PicUrl"] != null && dt.Rows[n]["n_PicUrl"].ToString() != "")
                    {
                        model.n_PicUrl = dt.Rows[n]["n_PicUrl"].ToString();
                    }
                    if (dt.Rows[n]["n_RedirectUrl"] != null && dt.Rows[n]["n_RedirectUrl"].ToString() != "")
                    {
                        model.n_RedirectUrl = dt.Rows[n]["n_RedirectUrl"].ToString();
                    }
                    if (dt.Rows[n]["n_QRCode"] != null && dt.Rows[n]["n_QRCode"].ToString() != "")
                    {
                        model.n_QRCode = dt.Rows[n]["n_QRCode"].ToString();
                    }
                    if (dt.Rows[n]["n_IsTop"] != null && dt.Rows[n]["n_IsTop"].ToString() != "")
                    {
                        model.n_IsTop =Convert.ToBoolean(dt.Rows[n]["n_IsTop"].ToString());
                    }
                    if (dt.Rows[n]["n_Sort"] != null && dt.Rows[n]["n_Sort"].ToString() != "")
                    {
                        model.n_Sort = int.Parse(dt.Rows[n]["n_Sort"].ToString());
                    }
                    if (dt.Rows[n]["n_Source"] != null && dt.Rows[n]["n_Source"].ToString() != "")
                    {
                        model.n_Source =dt.Rows[n]["n_Source"].ToString();
                    }
                    if (dt.Rows[n]["n_Writer"] != null && dt.Rows[n]["n_Writer"].ToString() != "")
                    {
                        model.n_Writer = dt.Rows[n]["n_Writer"].ToString();
                    }
                    if (dt.Rows[n]["n_CreatedOn"] != null && dt.Rows[n]["n_CreatedOn"].ToString() != "")
                    {
                        model.n_CreatedOn = Convert.ToDateTime( dt.Rows[n]["n_CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["n_CreatedBy"] != null && dt.Rows[n]["n_CreatedBy"].ToString() != "")
                    {
                        model.n_CreatedBy = new Guid( dt.Rows[n]["n_CreatedBy"].ToString());
                    }
                    if (dt.Rows[n]["n_ModifyOn"] != null && dt.Rows[n]["n_ModifyOn"].ToString() != "")
                    {
                        model.n_ModifyOn =Convert.ToDateTime( dt.Rows[n]["n_ModifyOn"].ToString());
                    }
                    if (dt.Rows[n]["n_StatusCode"] != null && dt.Rows[n]["n_StatusCode"].ToString() != "")
                    {
                        model.n_StatusCode =int.Parse( dt.Rows[n]["n_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["n_IsDel"] != null && dt.Rows[n]["n_IsDel"].ToString() != "")
                    {
                        model.n_IsDel = Convert.ToBoolean(dt.Rows[n]["n_IsDel"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
    }
}
        #endregion