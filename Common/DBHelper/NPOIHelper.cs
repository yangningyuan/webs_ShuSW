using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Common.SysConext;
using NPOI.HSSF.UserModel;

namespace Common.DBHelper
{
    /// <summary>
    /// Excel生成操作类
    /// </summary>
    public class NPOIHelper
    {
        /// <summary>
        /// 导出列名
        /// </summary>
        public static int MaxLevel_;
        public static List<string> ColumnsList;//用于导出表格字段对应
        public static int ExportWay = 0;//0 不带模板  1带模板
        public static string SheetName;



        #region 导出datatable
        /// <summary>
        /// 服务器端导出Excel
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="filePath"></param>
        public static void ExportExcel(DataTable dtSource, string filePath)
        {
            HSSFWorkbook excelWorkbook = CreateExcelFile();
            InsertRow(dtSource, excelWorkbook);
            SaveExcelFile(excelWorkbook, filePath);
        }
        /// <summary>
        /// 客户端导出Excel
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="filePath"></param>
        public static void ExportExcel(DataTable dtSource, Stream excelStream)
        {
            HSSFWorkbook excelWorkbook = CreateExcelFile();
            InsertRow(dtSource, excelWorkbook);
            SaveExcelFile(excelWorkbook, excelStream);
        }

        /// <summary>
        /// winform 无模版导出
        /// </summary>
        /// <param name="dtSource"></param>        
        /// <param name="row"></param>
        /// <returns></returns>
        public static HSSFWorkbook WinFormExportExcel(DataTable dtSource, SysColumnsList row)
        {
            HSSFWorkbook excelWorkbook = CreateExcelFile();
            MaxLevel_ = row.MaxLevel;
            SheetName = row.SheetName;
            ExportWay = 0;
            if (row.ColumnsLists != string.Empty)
            {
                string[] strArry = row.ColumnsLists.Split('|');
                ColumnsList = new List<string>();
                foreach (string item in strArry)
                    ColumnsList.Add(item);
            }
            else
            {
                ColumnsList = new List<string>();
            }
            InsertRow(dtSource, excelWorkbook, ColumnsList);
            return excelWorkbook;
        }

        /// <summary>
        /// 客户端导出excel 带模板
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="excelStream"></param>
        /// <param name="row"></param>
        public static void ExportExcel(DataTable dtSource, Stream excelStream, Common.SysConext.SysColumnsList row)
        {
            string templatePath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + row.TemplatePath;
            MaxLevel_ = row.MaxLevel;
            SheetName = row.SheetName;
            ExportWay = 1;
            if (row.ColumnsLists != string.Empty)
            {
                string[] strArry = row.ColumnsLists.Split('|');
                ColumnsList = new List<string>();
                foreach (string item in strArry)
                    ColumnsList.Add(item);
            }
            else
            {
                ColumnsList = new List<string>();
            }

            FileStream myFile = new FileStream(templatePath, FileMode.Open, FileAccess.Read);
            HSSFWorkbook excelWorkbook = new HSSFWorkbook(myFile);
            InsertRow(dtSource, excelWorkbook);
            SaveExcelFile(excelWorkbook, excelStream);
        }

        public static void ExportExcel(DataTable dtSource, Stream excelStream, Common.SysConext.SysColumnsList row, Common.SysConext.SysTitleList sysTitleList)
        {
            string templatePath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + row.TemplatePath;
            MaxLevel_ = row.MaxLevel;
            SheetName = row.SheetName;
            ExportWay = 1;
            if (row.ColumnsLists != string.Empty)
            {
                string[] strArry = row.ColumnsLists.Split('|');
                ColumnsList = new List<string>();
                foreach (string item in strArry)
                    ColumnsList.Add(item);
            }
            else
            {
                ColumnsList = new List<string>();
            }

            FileStream myFile = new FileStream(templatePath, FileMode.Open, FileAccess.Read);
            HSSFWorkbook excelWorkbook = new HSSFWorkbook(myFile);
            InsertRow(dtSource, excelWorkbook);
            SaveExcelFile(excelWorkbook, excelStream);
        }

        #endregion
        public static void ExportExcel(DataSet dsSource, string filePath)
        {
            HSSFWorkbook excelWorkbook = CreateExcelFile();
            foreach (DataTable dtSource in dsSource.Tables)
            {
                SheetName = dtSource.TableName;
                InsertRow(dtSource, excelWorkbook);
            }
            SaveExcelFile(excelWorkbook, filePath);
        }

        public static void ExportExcel(DataSet dsSource, string templatePath, string filePath)
        {
            FileStream myFile = new FileStream(templatePath, FileMode.Open, FileAccess.Read);
            HSSFWorkbook excelWorkbook = new HSSFWorkbook(myFile);
            if (ColumnsList == null)
                ColumnsList = new List<string>();
            foreach (DataTable dtSource in dsSource.Tables)
            {
                SheetName = dtSource.TableName;
                InsertRow(dtSource, excelWorkbook);
            }
            SaveExcelFile(excelWorkbook, filePath);
        }
        public static void ExportExcel(DataSet dsSource, Stream excelStream)
        {
            HSSFWorkbook excelWorkbook = CreateExcelFile();
            foreach (DataTable dtSource in dsSource.Tables)
            {
                SheetName = dtSource.TableName;
                InsertRow(dtSource, excelWorkbook);
            }
            SaveExcelFile(excelWorkbook, excelStream);
        }
        #region  导出 dataSet

        #endregion
        #region  创建，插入，导出 excel
        /// <summary>
        /// 保存Excel文件
        /// </summary>
        /// <param name="excelWorkBook"></param>
        /// <param name="filePath"></param>
        protected static void SaveExcelFile(HSSFWorkbook excelWorkBook, string filePath)
        {
            FileStream file = null;
            try
            {
                file = new FileStream(filePath, FileMode.Create);
                excelWorkBook.Write(file);
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
        }
        /// <summary>
        /// 保存Excel文件
        /// </summary>
        /// <param name="excelWorkBook"></param>
        /// <param name="filePath"></param>
        protected static void SaveExcelFile(HSSFWorkbook excelWorkBook, Stream excelStream)
        {
            try
            {
                excelWorkBook.Write(excelStream);
            }
            finally
            {

            }
        }
        /// <summary>
        /// 创建Excel文件
        /// </summary>
        /// <param name="filePath"></param>
        protected static HSSFWorkbook CreateExcelFile()
        {
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            return hssfworkbook;
        }
        /// <summary>
        /// 创建excel表头
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="excelSheet"></param>
        ///     <param name="TitleType">创建表头类型 1 不添加  2 添加部门  上报人</param>
        protected static void CreateHeader(NPOI.SS.UserModel.ISheet excelSheet)
        {

            //int level = 0;
            //NPOI.SS.UserModel.IRow newRow = excelSheet.CreateRow(level);
            //foreach (MutileTitle item in ListColumnsName)
            //{
            //    if (item.level != level)
            //    {
            //        newRow = excelSheet.CreateRow(item.level);
            //        level = item.level;
            //    }
            //    NPOI.SS.UserModel.ICell newCell = newRow.CreateCell(item.col1);
            //    newCell.SetCellValue(item.titleName);
            //    if (item.IsMer)
            //    {
            //        excelSheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(item.row1, item.row2, item.col1, item.col2));
            //    }
            //}           
        }
        protected static void CreateHeader(NPOI.SS.UserModel.ISheet excelSheet, List<string> columList)
        {
            int rownum = MaxLevel_ - 1 > 0 ? MaxLevel_ - 2 : 0;
            NPOI.SS.UserModel.IRow newRow = excelSheet.CreateRow(rownum);
            for (int k = 0; k < columList.Count; k++)
            {
                NPOI.SS.UserModel.ICell newCell = newRow.CreateCell(k);
                newCell.SetCellValue(columList[k]);
            }
        }

        /// <summary>
        /// 插入数据行
        /// </summary>
        protected static void InsertRow(DataTable dtSource, HSSFWorkbook excelWorkbook)
        {
            int rowCount = MaxLevel_ - 1; ;
            int sheetCount = 11;
            int columnsCount = 0;
            NPOI.SS.UserModel.ISheet newsheet;

            if (ExportWay == 0)//创建表头
            {
                newsheet = excelWorkbook.CreateSheet("Sheet" + sheetCount);
                CreateHeader(newsheet);
            }
            else
                newsheet = excelWorkbook.GetSheet(SheetName);
            if (dtSource.Rows.Count > 0)
            {
                if (ColumnsList.Count == 0)
                    columnsCount = dtSource.Columns.Count;
                foreach (DataRow dr in dtSource.Rows)
                {

                    //超出10000条数据 创建新的工作簿
                    if (rowCount == 65530)
                    {
                        rowCount = MaxLevel_ - 1;
                        sheetCount++;
                        newsheet = excelWorkbook.CreateSheet("Sheet" + sheetCount);
                        if (ExportWay == 0)
                            CreateHeader(newsheet);
                    }
                    rowCount++;
                    NPOI.SS.UserModel.IRow newRow = newsheet.CreateRow(rowCount);
                    if (ColumnsList.Count == 0)
                        InsertCell(columnsCount, dr, newRow, newsheet, excelWorkbook);
                    else
                        InsertCell(dr, newRow, newsheet, excelWorkbook);
                }

            }
        }

        protected static void InsertRow(DataTable dtSource, HSSFWorkbook excelWorkbook, List<string> columList)
        {
            int rowCount = MaxLevel_ - 1; ;
            int sheetCount = 11;            
            NPOI.SS.UserModel.ISheet newsheet;

            if (ExportWay == 0)//创建表头
            {
                newsheet = excelWorkbook.CreateSheet("Sheet" + sheetCount);
                CreateHeader(newsheet);
            }
            else
                newsheet = excelWorkbook.GetSheet(SheetName);
            if (dtSource.Rows.Count > 0)
            {
                CreateHeader(newsheet, ColumnsList);
                foreach (DataRow dr in dtSource.Rows)
                {

                    //超出10000条数据 创建新的工作簿
                    if (rowCount == 65530)
                    {
                        rowCount = MaxLevel_ - 1;
                        sheetCount++;
                        newsheet = excelWorkbook.CreateSheet("Sheet" + sheetCount);
                        if (ExportWay == 0)
                            CreateHeader(newsheet);
                    }
                    rowCount++;
                    NPOI.SS.UserModel.IRow newRow = newsheet.CreateRow(rowCount);
                    InsertCell(ColumnsList.Count, dr, newRow, newsheet, excelWorkbook);
                }
            }
        }

        /// <summary>
        /// 导出数据行 用于报表  
        /// </summary>
        /// <param name="drSource"></param>
        /// <param name="currentExcelRow"></param>
        /// <param name="excelSheet"></param>
        /// <param name="excelWorkBook"></param>
        protected static void InsertCell(DataRow drSource, NPOI.SS.UserModel.IRow currentExcelRow, NPOI.SS.UserModel.ISheet excelSheet, HSSFWorkbook excelWorkBook)
        {
            for (int cellIndex = 0; cellIndex < ColumnsList.Count; cellIndex++)
            {
                //列名称
                string columnsName = ColumnsList[cellIndex];
                NPOI.SS.UserModel.ICell newCell = null;
                System.Type rowType = drSource[columnsName].GetType();
                string drValue = drSource[columnsName].ToString().Trim();
                switch (rowType.ToString())
                {
                    case "System.String"://字符串类型
                        drValue = drValue.Replace("&", "&");
                        drValue = drValue.Replace(">", ">");
                        drValue = drValue.Replace("<", "<");
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(drValue);
                        break;
                    case "System.DateTime"://日期类型                        
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(DateTime.Parse(drValue).ToString("yyyy-MM-dd HH:mm:ss"));
                        break;
                    case "System.Boolean"://布尔型
                        bool boolV = false;
                        bool.TryParse(drValue, out boolV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(boolV);
                        break;
                    case "System.Int16"://整型
                    case "System.Int32":
                    case "System.Int64":
                    case "System.Byte":
                        int intV = 0;
                        int.TryParse(drValue, out intV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(intV.ToString());
                        break;
                    case "System.Decimal"://浮点型
                    case "System.Double":
                        double doubV = 0;
                        double.TryParse(drValue, out doubV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(doubV);
                        break;
                    case "System.DBNull"://空值处理
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue("");
                        break;
                    default:
                        throw (new Exception(rowType.ToString() + "：类型数据无法处理!"));
                }
            }
        }


        /// <summary>
        /// 导出数据行  用于普通导出 不指明列的
        /// </summary>
        /// <param name="columnsCount"></param>
        /// <param name="drSource"></param>
        /// <param name="currentExcelRow"></param>
        /// <param name="excelSheet"></param>
        /// <param name="excelWorkBook"></param>
        protected static void InsertCell(int columnsCount, DataRow drSource, NPOI.SS.UserModel.IRow currentExcelRow, NPOI.SS.UserModel.ISheet excelSheet, HSSFWorkbook excelWorkBook)
        {
            for (int cellIndex = 0; cellIndex < columnsCount; cellIndex++)
            {
                //列名称
                NPOI.SS.UserModel.ICell newCell = null;
                System.Type rowType = drSource[cellIndex].GetType();
                string drValue = drSource[cellIndex].ToString().Trim();
                switch (rowType.ToString())
                {
                    case "System.String"://字符串类型
                        drValue = drValue.Replace("&", "&");
                        drValue = drValue.Replace(">", ">");
                        drValue = drValue.Replace("<", "<");
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(drValue);
                        break;
                    case "System.DateTime"://日期类型                        
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(DateTime.Parse(drValue).ToString("yyyy-MM-dd HH:mm:ss"));
                        break;
                    case "System.Boolean"://布尔型
                        bool boolV = false;
                        bool.TryParse(drValue, out boolV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(boolV);
                        break;
                    case "System.Int16"://整型
                    case "System.Int32":
                    case "System.Int64":
                    case "System.Byte":
                        int intV = 0;
                        int.TryParse(drValue, out intV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        //newCell.SetCellValue(intV.ToString());
                        newCell.SetCellValue(intV);
                        break;
                    case "System.Decimal"://浮点型
                    case "System.Double":
                        double doubV = 0;
                        double.TryParse(drValue, out doubV);
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(doubV);
                        break;
                    case "System.DBNull"://空值处理
                        newCell = currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue("");
                        break;
                    default:
                        throw (new Exception(rowType.ToString() + "：类型数据无法处理!"));
                }
            }
        }
        #endregion      
    }

    //排序实现接口 不进行排序 根据添加顺序导出
    public class NoSort : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            return -1;
        }
    }
}
