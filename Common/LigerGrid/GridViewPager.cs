using System;
using System.Data;


namespace Common.LigerGrid
{
    public class GridViewPager : DataBasePager
    {

        static GridViewPager()
        {
            try
            {
                var context = System.Web.HttpContext.Current;
                if (context == null) return;

            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// 查询 单个表或者视图
        /// </summary>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetDataTable(ref int recordCount)
        {
            var context = System.Web.HttpContext.Current;
            string keyFied = context.Request.Params["keyfiled"];
            int pageNo = Convert.ToInt32(context.Request.Params["page"]);
            int pageSize = Convert.ToInt32(context.Request.Params["pagesize"]);
            string gridViewName = context.Request.Params["gridViewName"];
            string whereStr = context.Request.Params["whereStr"];
            string orderStr = "order by   " + context.Request.Params["sortorder"]; ;
            DataTable dt = GetGridView_Sql(gridViewName, "*", keyFied, pageNo, pageSize, orderStr, whereStr, ref recordCount);
            return dt;
        }
        /// <summary>
        /// 传入sql语句查询
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="fieldName"></param>
        /// <param name="sortorder"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string strSql, string fieldName, string sortorder, ref int recordCount)
        {
            var context = System.Web.HttpContext.Current;
            int pageNo = Convert.ToInt32(context.Request.Params["page"]);
            int pageSize = Convert.ToInt32(context.Request.Params["pagesize"]);
            string orderStr = "order by   " + sortorder;
            DataTable dt = GetGridView_Sql(strSql, fieldName, pageNo, pageSize, orderStr, ref recordCount);
            return dt;
        }
        /// <summary>
        /// 查询sql带汇总
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="sumSql"></param>
        /// <param name="fieldName"></param>
        /// <param name="sortorder"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string strSql, string sumSql, string fieldName, string sortorder, ref int recordCount)
        {
            var context = System.Web.HttpContext.Current;
            int pageNo = Convert.ToInt32(context.Request.Params["page"]);
            int pageSize = Convert.ToInt32(context.Request.Params["pagesize"]);
            string orderStr = "order by   " + sortorder;
            DataTable dt = GetGridView_Sql(strSql, sumSql, fieldName, pageNo, pageSize, orderStr, ref recordCount);
            return dt;
        }
    }
}
