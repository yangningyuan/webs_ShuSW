using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Text;
namespace Common.JOSN
{
    public class JSONHelper
    {
        /// <summary>
        /// 类对像转换成json格式
        /// </summary> 
        /// <returns></returns>
        public static string ToJson(object t)
        {
            return new JavaScriptSerializer().Serialize(t);
        }

        /// <summary>
        /// json格式转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static T FromJson<T>(string strJson) where T : class
        {
            return new JavaScriptSerializer().Deserialize<T>(strJson);
        }



        /// <summary>
        /// 获取树格式对象的JSON
        /// </summary>
        /// <param name="commandText">commandText</param>
        /// <param name="id">ID的字段名</param>
        /// <param name="pid">PID的字段名</param>
        /// <returns></returns>
        public static string GetArrayJSON(string commandText, string id, string pid)
        {
            var o = ArrayToTreeData(commandText, id, pid);
            return ToJson(o);
        }
        /// <summary>
        /// 获取树格式对象的JSON
        /// </summary>
        /// <param name="list">线性数据</param>
        /// <param name="id">ID的字段名</param>
        /// <param name="pid">PID的字段名</param>
        /// <returns></returns>
        public static string GetArrayJSON(IList<Hashtable> list, string id, string pid)
        {
            var o = ArrayToTreeData(list, id, pid);
            return ToJson(o);
        }

        /// <summary>
        /// 获取树格式对象
        /// </summary>
        /// <param name="commandText">sql</param>
        /// <param name="id">ID的字段名</param>
        /// <param name="pid">PID的字段名</param> 
        /// <returns></returns>
        public static object ArrayToTreeData(string commandText, string id, string pid)
        {
            var reader = DBHelper.SQLHelper.GetReader(commandText);
            var list = DbReaderToHash(reader);
            return ArrayToTreeData(list, id, pid);
        }

        /// <summary>
        /// 获取树格式对象
        /// </summary>
        /// <param name="list">线性数据</param>
        /// <param name="id">ID的字段名</param>
        /// <param name="pid">PID的字段名</param>
        /// <returns></returns>
        public static object ArrayToTreeData(IList<Hashtable> list, string id, string pid)
        {
            var h = new Hashtable(); //数据索引 
            var r = new List<Hashtable>(); //数据池,要返回的 
            foreach (var item in list)
            {
                if (!item.ContainsKey(id)) continue;
                h[item[id].ToString()] = item;
            }
            foreach (var item in list)
            {
                if (!item.ContainsKey(id)) continue;
                if (!item.ContainsKey(pid) || item[pid] == null || !h.ContainsKey(item[pid].ToString()))
                {
                    r.Add(item);
                }
                else
                {
                    var pitem = h[item[pid].ToString()] as Hashtable;
                    if (!pitem.ContainsKey("children"))
                        pitem["children"] = new List<Hashtable>();
                    var children = pitem["children"] as List<Hashtable>;
                    children.Add(item);
                }
            }
            return r;
        }



        public static object TableToTreeData(DataTable dt,string id,string pid)        
        {
            TBToList<Hashtable> t = new TBToList<Hashtable>();
            IList<Hashtable> ldt = t.ToList(dt);
            return ArrayToTreeData(ldt,id,pid);
        }
        

        /// <summary>
        /// 将db reader转换为Hashtable列表
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static List<Hashtable> DbReaderToHash(IDataReader reader)
        {
            var list = new List<Hashtable>();
            while (reader.Read())
            {
                var item = new Hashtable();

                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var name = reader.GetName(i);
                    var value = reader[i];
                    item[name] = value;
                }
                list.Add(item);
            }
            return list;
        }
        #region  JSON To ArrayList
        /// <summary>
        /// JSON To ArrayList
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static ArrayList GetArrayListFromJSON(string json)
        {
            object o = JsonConvert.DeserializeObject(json);
            object v = FormatObject(o);
            ArrayList taskList = (ArrayList)FormatObject(o);
            return taskList;
        }

        /// <summary>
        /// 格式化对象
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static object FormatObject(object o)
        {
            if (o == null) return null;

            if (o is JObject)
            {
                JObject jo = o as JObject;

                Hashtable h = new Hashtable();

                foreach (KeyValuePair<string, JToken> entry in jo)
                {
                    h[entry.Key] = FormatObject(entry.Value);
                }

                o = h;
            }
            else if (o is IList)
            {

                ArrayList list = new ArrayList();
                list.AddRange((o as IList));
                int i = 0, l = list.Count;
                for (; i < l; i++)
                {
                    list[i] = FormatObject(list[i]);
                }
                o = list;

            }
            else if (typeof(JValue) == o.GetType())
            {
                JValue v = (JValue)o;
                o = FormatObject(v.Value);
            }
            else
            {
            }
            return o;
        }
        #endregion

        #region Obj To JSON String
        public static string ToJSON(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        #endregion
        /// <summary>
        /// 将dataTable 转化为json，重载两个参数
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public static string GetJSONFromDataTable(DataTable dt, int recordCount)
        {
            try
            {
                //13253683830
                string rowsjson = JsonConvert.SerializeObject(dt, new DataTableConverter());                
                string json = @"{""total"":"""+recordCount+@""",""rows"":"+rowsjson+@"}";
                return json;
            }
            catch (Exception)
            {
                return @"{""total"":0,""rows"":[]}";
            }
        }
        /// <summary>
        /// 将dataTable 转化为json,重载一个参数
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetJSONFromDataTable(DataTable dt)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("[");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Json.Append("{");
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            Json.Append("\"" + dt.Columns[j].ColumnName.ToString().ToLower() + "\":\"" + JsonFilter(dt.Rows[i][j].ToString()) + "\",");
                        }
                        Json.Remove(Json.Length - 1, 1);
                        Json.Append("},");
                    }
                    Json.Remove(Json.Length - 1, 1);
                }
            }
            Json.Append("]");
            return Json.ToString();
        }

        public static string DataTableToJSON(DataTable dt)
        {
            StringBuilder Json = new StringBuilder();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Json.Append("{");
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            Json.Append("\"" + dt.Columns[j].ColumnName.ToString().ToLower() + "\":\"" + JsonFilter(dt.Rows[i][j].ToString()) + "\",");
                        }
                        Json.Remove(Json.Length - 1, 1);
                        Json.Append("},");
                    }
                    Json.Remove(Json.Length - 1, 1);
                }
            }
            return Json.ToString();
        }

        public static string JsonFilter(string text)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            text = text.Replace("\"", "＂");
            text = text.Replace("'", "＇");
            text = text.Replace("\\", "、");
            text = text.Replace("\r\n", " ");
            text = text.Replace("\n", " ");
            text = text.Replace("\r", " ");
            text = text.Replace("\t", " ");
            text = IsLegalLetter(text);
            return text;
        }
        /// <summary>
        /// 判断字符串中的字符是否合法(过滤乱码字符)
        /// </summary>
        /// <param name="input"></param>
        /// <param name="index"></param>
        public static string IsLegalLetter(string input)
        {
            int code = 0;
            string temp = "";
            char[] ch = input.ToCharArray();
            string ext = "　。《》、“”‘’【】｛｝＋－—……";
            int bjbegin = Convert.ToInt32("0020", 16);     //范围（0x0021～0x007E）半角字符,0020为半角空格
            int bjend = Convert.ToInt32("007E", 16);
            int qjbegin = Convert.ToInt32("FF01", 16);   //范围（0xFF01～0xFF5E）全角字符
            int qjend = Convert.ToInt32("FF5E", 16);
            int chbegin = Convert.ToInt32("4e00", 16);    //范围（0x4e00～0x9fff）汉字
            int chend = Convert.ToInt32("9fff", 16);
            if (input != "")
            {
                for (int i = 0; i < ch.Length; i++)
                {
                    code = Char.ConvertToUtf32(input, i);    //获得字符串中指定索引index处字符unicode编码
                    if (ext.IndexOf(input[i]) != -1 || (code >= bjbegin && code <= bjend) || (code >= qjbegin && code <= qjend) || (code >= chbegin && code <= chend))
                    {
                        temp += ch[i];
                    }
                }
            }
            return temp;
        }

        /// <summary>
        /// 将json转换为DataTable
        /// </summary>
        /// <param name="strJson">得到的json</param>
        /// <returns></returns>
        public static DataTable JsonToDataTable(string strJson)
        {
            //转换json格式
            strJson = strJson.Replace(",\"", "*\"").Replace("\":", "\"#").ToString();
            //取出表名   
            var rg = new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase);
            string strName = rg.Match(strJson).Value;
            DataTable tb = null;
            //去除表名   
            strJson = strJson.Substring(strJson.IndexOf("[") + 1);
            strJson = strJson.Substring(0, strJson.IndexOf("]"));

            //获取数据   
            rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split('*');

                //创建表   
                if (tb == null)
                {
                    tb = new DataTable();
                    tb.TableName = strName;
                    foreach (string str in strRows)
                    {
                        var dc = new DataColumn();
                        string[] strCell = str.Split('#');

                        if (strCell[0].Substring(0, 1) == "\"")
                        {
                            int a = strCell[0].Length;
                            dc.ColumnName = strCell[0].Substring(1, a - 2);
                        }
                        else
                        {
                            dc.ColumnName = strCell[0];
                        }
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }

                //增加内容   
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    dr[r] = strRows[r].Split('#')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("\"", "");
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }

            return tb;
        }
        //{"code":1,"msg":{"percard":"41302219811219801X","name":"胡继文","perbh":"0101821643","cardID":"03361727","status":"6","cardstatus":"1","phonenumber":"","dbname":"艾雅洁,艾亚西,安自超","cjbh":"2068465"}}
        public static DataTable JsonDataTable(string json)
        {
            int start = json.IndexOf("msg") + 6;
            string s = json.Substring(start);
            s = s.Substring(0, s.IndexOf('}'));
            string[] str = s.Split(':');
            DataTable dt=new DataTable("msg");
            for (int i = 0; i < str.Length; i++)
            {
                string name = str[i].Substring(1, str[i].IndexOf(':') - 1);
                dt.Columns.Add(name);
            }
            DataRow r = dt.NewRow();
            for (int i = 0; i < str.Length; i++)
            {
                r[i] = str[i].Substring(str[i].IndexOf(':') + 1, str[i].Length - 1);
            }
            return dt;
        }
    }

    public class TBToList<T> where T : new()
    {
        /// <summary>
        /// 获取列名集合
        /// </summary>
        private IList<string> GetColumnNames(DataColumnCollection dcc)
        {
            IList<string> list = new List<string>();
            foreach (DataColumn dc in dcc)
            {
                list.Add(dc.ColumnName);
            }
            return list;
        }

        /// <summary>
        ///属性名称和类型名的键值对集合
        /// </summary>
        private Hashtable GetColumnType(DataColumnCollection dcc)
        {
            if (dcc == null || dcc.Count == 0)
            {
                return null;
            }
            IList<string> colNameList = GetColumnNames(dcc);

            Type t = typeof(T);
            PropertyInfo[] properties = t.GetProperties();
            Hashtable hashtable = new Hashtable();
            int i = 0;
            foreach (PropertyInfo p in properties)
            {
                foreach (string col in colNameList)
                {
                    if (col.ToLower().Contains(p.Name.ToLower()))
                    {
                        hashtable.Add(col, p.PropertyType.ToString() + i++);
                    }
                }
            }

            return hashtable;
        }

        /// <summary>
        /// DataTable转换成IList
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public IList<T> ToList(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }

            PropertyInfo[] properties = typeof(T).GetProperties();//获取实体类型的属性集合
            Hashtable hh = GetColumnType(dt.Columns);//属性名称和类型名的键值对集合
            IList<string> colNames = GetColumnNames(hh);//按照属性顺序的列名集合
            List<T> list = new List<T>();
            T model = default(T);
            foreach (DataRow dr in dt.Rows)
            {
                model = new T();//创建实体
                int i = 0;
                foreach (PropertyInfo p in properties)
                {
                    if (p.PropertyType == typeof(string))
                    {
                        p.SetValue(model, dr[colNames[i++]], null);
                    }
                    else if (p.PropertyType == typeof(int))
                    {
                        p.SetValue(model, int.Parse(dr[colNames[i++]].ToString()), null);
                    }
                    else if (p.PropertyType == typeof(DateTime))
                    {
                        p.SetValue(model, DateTime.Parse(dr[colNames[i++]].ToString()), null);
                    }
                    else if (p.PropertyType == typeof(float))
                    {
                        p.SetValue(model, float.Parse(dr[colNames[i++]].ToString()), null);
                    }
                    else if (p.PropertyType == typeof(double))
                    {
                        p.SetValue(model, double.Parse(dr[colNames[i++]].ToString()), null);
                    }
                }

                list.Add(model);
            }

            return list;
        }

        /// <summary>
        /// 按照属性顺序的列名集合
        /// </summary>
        private IList<string> GetColumnNames(Hashtable hh)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();//获取实体类型的属性集合
            IList<string> ilist = new List<string>();
            int i = 0;
            foreach (PropertyInfo p in properties)
            {
                ilist.Add(GetKey(p.PropertyType.ToString() + i++, hh));
            }
            return ilist;
        }

        /// <summary>
        /// 根据Value查找Key
        /// </summary>
        private string GetKey(string val, Hashtable tb)
        {
            foreach (DictionaryEntry de in tb)
            {
                if (de.Value.ToString() == val)
                {
                    return de.Key.ToString();
                }
            }
            return null;
        }

    }
}
