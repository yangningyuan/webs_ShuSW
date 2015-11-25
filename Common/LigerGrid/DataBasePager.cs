using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Common.LigerGrid
{
    public abstract class DataBasePager
    {
        public virtual IList<LigerGrid.ViewInfo> Views { get; set; }
        public string GetKeyName(string ViewName)
        {
            if (Views == null) return null;
            foreach (var view in Views)
            {
                if (view.ViewName.Equals(ViewName))
                    return view.KeyName;
            }
            return null;
        }

        public DataTable GetGridView_Sql(string gridViewName, string fiedName, string keyName, int pageNo, int pageSize, string orderStr, string whereStr, ref int recordTotal)
        {
            string ProcName = "P_GridViewPager_Query";
            SqlParameter[] pas = new SqlParameter[] { 
                new SqlParameter("@viewName", SqlDbType.VarChar, 800), 
                new SqlParameter("@fieldName",SqlDbType.VarChar,800),
                new SqlParameter("@keyName",SqlDbType.VarChar,200),
                new SqlParameter("@pageNo", SqlDbType.Int, 4), 
                new SqlParameter("@pageSize", SqlDbType.Int, 4), 
                new SqlParameter("@orderString", SqlDbType.VarChar, 255), 
                new SqlParameter("@whereString", SqlDbType.VarChar, 255), 
                new SqlParameter("recordTotal", SqlDbType.VarChar, 255) };
            pas[0].Value = gridViewName;
            pas[1].Value = fiedName;
            pas[2].Value = keyName;
            pas[3].Value = pageNo;
            pas[4].Value = pageSize;
            pas[5].Value = orderStr;
            pas[6].Value = whereStr;
            pas[7].Direction = ParameterDirection.Output;
            DataTable dt = DBHelper.SQLHelper.GetDataSetProc(ProcName, ref pas).Tables[0];
            recordTotal = Convert.ToInt32(pas[7].Value);
            return dt;
        }
        protected DataTable GetGridView_Sql(string strSql, string fieldName, int pageNo, int pageSize, string orderStr, ref int recordTotal)
        {
            string ProcName = "P_GridViewPager";
            SqlParameter[] pas ={new SqlParameter( "@StrSql", SqlDbType.VarChar,3000 ),
            new SqlParameter( "@fieldName", SqlDbType.VarChar,1000),
            new SqlParameter( "@pageNo", SqlDbType.Int, 4),
            new SqlParameter( "@pageSize", SqlDbType.Int,4 ),
            new SqlParameter ("@orderString", SqlDbType.VarChar,255),
            new SqlParameter("recordTotal", SqlDbType.Int, 4) };
            pas[0].Value = strSql;
            pas[1].Value = fieldName;
            pas[2].Value = pageNo;
            pas[3].Value = pageSize;
            pas[4].Value = orderStr;
            pas[5].Direction = ParameterDirection.Output;

            DataTable dt = DBHelper.SQLHelper.GetDataSetProc(ProcName, ref pas).Tables[0];
            recordTotal = Convert.ToInt32(pas[5].Value);
            return dt;
        }

        protected DataTable GetGridView_Sql(string strSql, string sumSql, string fieldName, int pageNo, int pageSize, string orderStr, ref int recordTotal)
        {
            string ProcName = "P_GridViewPager_Summary";
            SqlParameter[] pas ={new SqlParameter( "@StrSql", SqlDbType.VarChar,3000 ),
                                    new SqlParameter( "@sumSql", SqlDbType.VarChar,3000 ),
            new SqlParameter( "@fieldName", SqlDbType.VarChar,1000),
            new SqlParameter( "@pageNo", SqlDbType.Int, 4),
            new SqlParameter( "@pageSize", SqlDbType.Int,4 ),
            new SqlParameter ("@orderString", SqlDbType.VarChar,255),
            new SqlParameter("recordTotal", SqlDbType.Int, 4) };
            pas[0].Value = strSql;
            pas[1].Value = sumSql;
            pas[2].Value = fieldName;
            pas[3].Value = pageNo;
            pas[4].Value = pageSize;
            pas[5].Value = orderStr;
            pas[6].Direction = ParameterDirection.Output;

            DataSet ds = DBHelper.SQLHelper.GetDataSetProc(ProcName, ref pas);
            recordTotal = Convert.ToInt32(pas[6].Value);
            DataTable dt = ds.Tables[1];
            if (ds.Tables[0].Rows.Count > 0)
                dt.Merge(ds.Tables[0]);
            return dt;
        }
    }
}
