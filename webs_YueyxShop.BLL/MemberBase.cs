using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using webs_YueyxShop.IDAL;
using webs_YueyxShop.DALFactory;
namespace webs_YueyxShop.BLL
{
    /// <summary>
    /// 会员管理
    /// </summary>
    public partial class MemberBase
    {
        private readonly IMemberBase dal = DataAccess.CreateMemberBase();
        public MemberBase()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int m_ID)
        {
            return dal.Exists(m_ID);
        }
        /// <summary>
        /// 获得会员详情
        /// </summary>
        /// <param name="m_id"></param>
        /// <returns></returns>
        public Model.MemberInfo getMemberInfo(int m_id)
        {
            return dal.getMemberInfo(m_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.MemberBase model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.MemberBase model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int m_ID)
        {

            return dal.Delete(m_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string m_IDlist)
        {
            return dal.DeleteList(m_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.MemberBase GetModel(int m_ID)
        {

            return dal.GetModel(m_ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.MemberBase GetModelByCache(int m_ID)
        {

            string CacheKey = "MemberBaseModel-" + m_ID;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(m_ID);
                    if (objModel != null)
                    {
                        int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Model.MemberBase)objModel;
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
        public List<Model.MemberBase> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.MemberBase> DataTableToList(DataTable dt)
        {
            List<Model.MemberBase> modelList = new List<Model.MemberBase>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.MemberBase model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.MemberBase();
                    if (dt.Rows[n]["m_ID"] != null && dt.Rows[n]["m_ID"].ToString() != "")
                    {
                        model.m_ID = int.Parse(dt.Rows[n]["m_ID"].ToString());
                    }
                    if (dt.Rows[n]["m_UserName"] != null && dt.Rows[n]["m_UserName"].ToString() != "")
                    {
                        model.m_UserName = dt.Rows[n]["m_UserName"].ToString();
                    }
                    if (dt.Rows[n]["m_Password"] != null && dt.Rows[n]["m_Password"].ToString() != "")
                    {
                        model.m_Password = dt.Rows[n]["m_Password"].ToString();
                    }
                    if (dt.Rows[n]["m_UserType"] != null && dt.Rows[n]["m_UserType"].ToString() != "")
                    {
                        model.m_UserType = int.Parse(dt.Rows[n]["m_UserType"].ToString());
                    }
                    if (dt.Rows[n]["m_YingYZZ"] != null && dt.Rows[n]["m_YingYZZ"].ToString() != "")
                    {
                        model.m_YingYZZ =dt.Rows[n]["m_YingYZZ"].ToString();
                    }
                    if (dt.Rows[n]["m_Score"] != null && dt.Rows[n]["m_Score"].ToString() != "")
                    {
                        model.m_Score = int.Parse(dt.Rows[n]["m_Score"].ToString());
                    }
                    if (dt.Rows[n]["m_Rank"] != null && dt.Rows[n]["m_Rank"].ToString() != "")
                    {
                        model.m_Rank = int.Parse(dt.Rows[n]["m_Rank"].ToString());
                    }
                    if (dt.Rows[n]["m_NickName"] != null && dt.Rows[n]["m_NickName"].ToString() != "")
                    {
                        model.m_NickName = dt.Rows[n]["m_NickName"].ToString();
                    }
                    if (dt.Rows[n]["m_RealName"] != null && dt.Rows[n]["m_RealName"].ToString() != "")
                    {
                        model.m_RealName = dt.Rows[n]["m_RealName"].ToString();
                    }
                    if (dt.Rows[n]["m_Sex"] != null && dt.Rows[n]["m_Sex"].ToString() != "")
                    {
                        model.m_Sex = int.Parse(dt.Rows[n]["m_Sex"].ToString());
                    }
                    if (dt.Rows[n]["m_Birthday"] != null && dt.Rows[n]["m_Birthday"].ToString() != "")
                    {
                        model.m_Birthday = DateTime.Parse( dt.Rows[n]["m_Birthday"].ToString());
                    }
                    if (dt.Rows[n]["m_Phone"] != null && dt.Rows[n]["m_Phone"].ToString() != "")
                    {
                        model.m_Phone = dt.Rows[n]["m_Phone"].ToString();
                    }
                    if (dt.Rows[n]["m_Email"] != null && dt.Rows[n]["m_Email"].ToString() != "")
                    {
                        model.m_Email = dt.Rows[n]["m_Email"].ToString();
                    }
                    if (dt.Rows[n]["m_QQ"] != null && dt.Rows[n]["m_QQ"].ToString() != "")
                    {
                        model.m_QQ = dt.Rows[n]["m_QQ"].ToString();
                    }
                    if (dt.Rows[n]["m_CreatedOn"] != null && dt.Rows[n]["m_CreatedOn"].ToString() != "")
                    {
                        model.m_CreatedOn = DateTime.Parse( dt.Rows[n]["m_CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["m_ZheK"] != null && dt.Rows[n]["m_ZheK"].ToString() != "")
                    {
                        model.m_ZheK = decimal.Parse( dt.Rows[n]["m_ZheK"].ToString());
                    }
                    if (dt.Rows[n]["m_StatusCode"] != null && dt.Rows[n]["m_StatusCode"].ToString() != "")
                    {
                        model.m_StatusCode =int.Parse( dt.Rows[n]["m_StatusCode"].ToString());
                    }
                    if (dt.Rows[n]["m_ShenPstatus"] != null && dt.Rows[n]["m_ShenPstatus"].ToString() != "")
                    {
                        model.m_ShenPstatus = int.Parse(dt.Rows[n]["m_ShenPstatus"].ToString());
                    }
                    if (dt.Rows[n]["m_GDPhone"] != null && dt.Rows[n]["m_GDPhone"].ToString() != "")
                    {
                        model.m_GDPhone = dt.Rows[n]["m_GDPhone"].ToString();
                    }
                    if (dt.Rows[n]["m_GongSiName"] != null && dt.Rows[n]["m_GongSiName"].ToString() != "")
                    {
                        model.m_GongSiName = dt.Rows[n]["m_GongSiName"].ToString();
                    }
                    if (dt.Rows[n]["m_GongSiDiQu"] != null && dt.Rows[n]["m_GongSiDiQu"].ToString() != "")
                    {
                        model.m_GongSiDiQu = dt.Rows[n]["m_GongSiDiQu"].ToString();
                    }
                    if (dt.Rows[n]["m_GongSiAddress"] != null && dt.Rows[n]["m_GongSiAddress"].ToString() != "")
                    {
                        model.m_GongSiAddress = dt.Rows[n]["m_GongSiAddress"].ToString();
                    }
                    if (dt.Rows[n]["m_CloseDate"] != null && dt.Rows[n]["m_CloseDate"].ToString() != "")
                    {
                        model.m_CloseDate = DateTime.Parse(dt.Rows[n]["m_CloseDate"].ToString());
                    }
                    if (dt.Rows[n]["m_Introduction"] != null && dt.Rows[n]["m_Introduction"].ToString() != "")
                    {
                        model.m_Introduction = dt.Rows[n]["m_Introduction"].ToString();
                    }
                    if (dt.Rows[n]["m_HeadImg"] != null && dt.Rows[n]["m_HeadImg"].ToString() != "")
                    {
                        model.m_HeadImg = dt.Rows[n]["m_HeadImg"].ToString();
                    }
                    if (dt.Rows[n]["m_Provice"] != null && dt.Rows[n]["m_Provice"].ToString() != "")
                    {
                        model.m_Provice = int.Parse(dt.Rows[n]["m_Provice"].ToString());
                    }
                    if (dt.Rows[n]["m_City"] != null && dt.Rows[n]["m_City"].ToString() != "")
                    {
                        model.m_City = int.Parse(dt.Rows[n]["m_City"].ToString());
                    }
                    if (dt.Rows[n]["m_Count"] != null && dt.Rows[n]["m_Count"].ToString() != "")
                    {
                        model.m_Count = int.Parse(dt.Rows[n]["m_Count"].ToString());
                    }
                    if (dt.Rows[n]["m_mailyanzheng"] != null && dt.Rows[n]["m_mailyanzheng"].ToString() != "")
                    {
                        model.m_mailyanzheng = bool.Parse(dt.Rows[n]["m_mailyanzheng"].ToString());
                    }
                    if (dt.Rows[n]["m_ZhiYe"] != null && dt.Rows[n]["m_ZhiYe"].ToString() != "")
                    {
                        model.m_ZhiYe = dt.Rows[n]["m_ZhiYe"].ToString();
                    }
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

        #endregion  ExtensionMethod
    }
}
