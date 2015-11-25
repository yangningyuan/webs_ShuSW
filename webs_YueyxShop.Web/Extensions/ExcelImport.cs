using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Data;
using Common;

namespace webs_YueyxShop.Web
{
    /// <summary>
    /// excel文件导入辅助
    /// </summary>
    public class ExcelImport
    {
        public DataTable table { get; private set; }
        public string _fullPath;

        public ExcelImport()
        {
            _fullPath = "";
            table = new DataTable();
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="file">文件路径</param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public bool ReadExcel(string file, string sheetName)
        {
            _fullPath = System.Web.HttpContext.Current.Server.MapPath("~/" + file);
            try
            {
                string connectString =
                    string.Format(
                        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES;IMEX=1';",
                        _fullPath);
                using (OleDbConnection connection = new OleDbConnection(connectString))
                {
                    connection.Open();

                    #region 检查工作簿的名称是否正确

                    //获取Excel文件中所有的工作簿名称
                    DataTable dt = connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                    bool tableName = false;
                    if (sheetName == null || string.IsNullOrWhiteSpace(sheetName))
                    {
                        sheetName = "Sheet1";
                    }

                    if (dt != null)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row.ItemArray.Any(name => name.ToString().Replace("'", "") == sheetName + "$"))
                            {
                                tableName = true;
                            }
                        }
                    }

                    if (tableName == false)
                    {
                        throw new Exception(string.Format("需导入文件的工作簿名称应为“{0}”,请检查文件！", sheetName));
                    }

                    #endregion

                    string sql = string.Format("SELECT * FROM [{0}$]", sheetName);
                    OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection);
                    adapter.Fill(table);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        /// <summary>
        /// 读取的数据中是否有数据
        /// </summary>
        /// <returns></returns>
        private bool IsHaveData()
        {
            return table.Rows.Count != 0;
        }

        /// <summary>
        /// 是否含有指定列
        /// </summary>
        /// <param name="disc">列名和最大长度的键值对</param>
        /// <returns></returns>
        public bool ExistColumns(Dictionary<string, string> disc)
        {
            if (!IsHaveData())
            {
                throw new Exception("文件中没有数据！");
            }
            string message = string.Empty;
            foreach (string key in disc.Keys)
            {
                if (!table.Columns.Contains(disc[key]))
                {
                    message += disc[key] + " ";
                }
            }
            if (!string.IsNullOrWhiteSpace(message))
                throw new Exception("导入文件中缺少列：" + message);
            return true;
            //return RightColumnsLength(disc);
        }

        /// <summary>
        /// 列长度是否在指定长度范围内
        /// </summary>
        /// <param name="disc">列名和最大长度的键值对</param>
        /// <returns></returns>
        private bool RightColumnsLength(Dictionary<string, int> disc)
        {
            int count = table.Rows.Count;
            for (int i = 1; i < count; i++)
            {
                DataRow row = table.Rows[i];
                foreach (string key in disc.Keys)
                {
                    if (row[key].ToString().Length > disc[key])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool DeleteFile()
        {
            try
            {
                if (File.Exists(_fullPath))
                {
                    File.Delete(_fullPath);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}