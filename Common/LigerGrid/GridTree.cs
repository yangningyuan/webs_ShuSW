using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Common.DBHelper;
using Common.JOSN;

namespace Common.LigerGrid
{
    public class GridTree
    {
        public GridTree()
        {
        }

        /// <summary>
        /// 获取 ligerTree 所需要的JSON
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetTreeJSON()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string view = context.Request["view"];
            string where = context.Request["where"];
            string idfield = context.Request["idfield"];
            string pidfield = context.Request["pidfield"];
            string textfield = context.Request["textfield"];
            string iconfield = context.Request["iconfield"];
            string iconroot = context.Request["iconroot"] ?? "";
            string root = context.Request["root"];
            string rooticon = context.Request["rooticon"];
            string sql = "select {0} from [{1}] where {2}";

            string sqlselect = "[" + textfield + "] as [text]";
            if (!string.IsNullOrEmpty(iconfield))
            {
                sqlselect += ",'" + iconroot + "'+[" + iconfield + "] as [icon]";
            }
            if (!string.IsNullOrEmpty(idfield))
            {
                sqlselect += ",[" + idfield + "] as [id]";
            }
            if (!string.IsNullOrEmpty(idfield))
            {
                sqlselect += ",[" + idfield + "]";
            }
            if (!string.IsNullOrEmpty(pidfield))
            {
                sqlselect += ",[" + pidfield + "]";
            }


            if (string.IsNullOrEmpty(where))
                where = "1=1";

            sql = string.Format(sql, sqlselect, view, where);

            //获取树格式对象的JSON，并且对结果进行格式化(转化为树格式)
            string json = JSONHelper.GetArrayJSON(sql, idfield, pidfield);

            if (!string.IsNullOrEmpty(root))
            {
                json = @"[{""text"":""" + root + @""",""children"":" + json;
                if (!string.IsNullOrEmpty(rooticon))
                    json += @",""icon"":""" + rooticon + @"""";
                json += "}]";
            }

            return json;
        }

        /// <summary>
        /// 获取 ligerGrid(Tree) 所需要的JSON
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetGridTreeJSON()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string view = context.Request["gridviewname"];
            string where = context.Request["where"];
            string idfield = context.Request["idfield"];
            string pidfield = context.Request["pidfield"];
            string sql = "select * from [{0}] where {1}";
            if (string.IsNullOrEmpty(where))
                where = " 1=1 ";
            sql = string.Format(sql, view, where);

            //获取树格式对象的JSON，并且对结果进行格式化(转化为树格式)
            List<Hashtable> o = JSONHelper.ArrayToTreeData(sql, idfield, pidfield) as List<Hashtable>;

            string json = @"{""Rows"":" + JSONHelper.ToJson(o) + @",""Total"":""" + o.Count + @"""}";
            return json;
        }
        /*
        public string GetJSON()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string view = context.Request["view"];
            string where = context.Request["where"];
            string idfield = context.Request["idfield"];
            string textfield = context.Request["textfield"];
            string distinct = context.Request["distinct"];
            string sql = "select   {0} from [{1}] where {2}";
            string sqlselect = "";
            if (!string.IsNullOrEmpty(idfield))
            {
                sqlselect = (sqlselect + "[" + idfield + "] as [id]") + ",[" + idfield + "] as [value]";
            }
            if (!string.IsNullOrEmpty(textfield))
            {
                sqlselect = sqlselect + ",[" + textfield + "] as [text]";
            }
            if (string.IsNullOrEmpty(where))
            {
                where = " 1=1 ";
            }
            DataSet ds = SQLHelper.GetDataSet(string.Format(sql, sqlselect, view, where));
            return new Liger.Common.JSON.DataSetJSONSerializer().Serialize(ds); //DataSetJSONSerializer().Serialize(ds);

        }

        public string GetSelectJSON()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string view = context.Request["view"];
            string where = context.Request["where"];
            string idfield = context.Request["idfield"];
            string textfield = context.Request["textfield"];
            string distinct = context.Request["distinct"];
            string sql = "select " + ((!string.IsNullOrEmpty(distinct) && (distinct != "false")) ? "distinct" : "") +
                         "  {0} from [{1}] where {2}";
            string sqlselect = "";
            if (!string.IsNullOrEmpty(idfield))
            {
                sqlselect = (sqlselect + "[" + idfield + "] as [id]") + ",[" + idfield + "] as [value]";
            }
            if (!string.IsNullOrEmpty(textfield))
            {
                sqlselect = sqlselect + ",[" + textfield + "] as [text]";
            }
            if (string.IsNullOrEmpty(where))
            {
                where = " 1=1 ";
            }
            string strSql = "     (select  '全部' as [id],   '全部' as [value],'全部'  as [text] )   union all   ";
            DataSet ds = SQLHelper.GetDataSet(string.Format(strSql + sql, sqlselect, view, where));
            return new Liger.Common.JSON.DataSetJSONSerializer().Serialize(ds); //DataSetJSONSerializer().Serialize(ds);

        }
         * */
    }
}
