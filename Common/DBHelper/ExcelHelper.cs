using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Common.DBHelper
{
    public class ExcelHelper
    {
        private string excelpath;
        private NPOI.SS.UserModel.ISheet newsheet;
        private NPOI.HSSF.UserModel.HSSFWorkbook excelWorkbook;


        public ExcelHelper(string _excelpath)
        {
            excelpath = _excelpath;
        }
        #region excel 打开 保存
        public bool OpenExcel()
        {
            bool isSuccess = false;
            try
            {
                FileStream fileStream = new FileStream(excelpath, FileMode.Open, FileAccess.ReadWrite);
                excelWorkbook = new NPOI.HSSF.UserModel.HSSFWorkbook(fileStream);
                isSuccess = true;
            }
            catch (Exception)
            {
                
            }
            return isSuccess;
        }
        public void SaveExcel(string _excelpath)
        {
            if (excelWorkbook != null)
            {
                FileStream fileStream = new FileStream(_excelpath, FileMode.OpenOrCreate);
                excelWorkbook.Write(fileStream);
                fileStream.Close();
            }
        }
        public void SaveExcel()
        {
            if (excelWorkbook != null)
            {
                FileStream fileStream = new FileStream(excelpath, FileMode.OpenOrCreate);
                excelWorkbook.Write(fileStream);
                fileStream.Close();
            }
        }
        #endregion
        #region sheet 操作
        public bool isExistSheet(string sheetName)
        {
            newsheet = excelWorkbook.GetSheet(sheetName);
            if (newsheet != null)
            {
                newsheet.ForceFormulaRecalculation = true;
                return true;
            }
            else
                return false;
        }
        public bool isExistSheet(int sheetIndex)
        {
            newsheet = excelWorkbook.GetSheetAt(sheetIndex);
            if (newsheet != null)
            {
                newsheet.ForceFormulaRecalculation = true;
                return true;
            }
            else
                return false;
        }
        public void CreateSheet(string sheetName)
        {
            bool isexistSheet = isExistSheet(sheetName);
            if (!isexistSheet)
            {
                newsheet = excelWorkbook.CreateSheet(sheetName);
                newsheet.ForceFormulaRecalculation = true;
            }
        }
        public void CreateSheet(string sheetName, List<SysConext.Rectangle> rectangleListOrderBylevel)
        {
            bool isexistSheet = isExistSheet(sheetName);
            if (!isexistSheet)
            {
                newsheet = excelWorkbook.CreateSheet(sheetName);
                newsheet.ForceFormulaRecalculation = true;
                CreateHeader(rectangleListOrderBylevel);
            }

        }
        public int CloneSheet(int sheetIndex)
        {
            int index = -1;
            bool isexistSheet = isExistSheet(sheetIndex);
            if (isexistSheet)
            {
                newsheet = excelWorkbook.CloneSheet(sheetIndex);
                newsheet.ForceFormulaRecalculation = true;
                index = excelWorkbook.GetSheetIndex(newsheet);
            }
            return index;
        }
        public void SetSheetName(int sheetIndex, string sheetName)
        {
            bool isexistSheet = isExistSheet(sheetIndex);
            if (isexistSheet)
                excelWorkbook.SetSheetName(sheetIndex, sheetName);
        }
        public void SetSheetHidden(int sheetIndex, bool isHidden)
        {
            bool isexistSheet = isExistSheet(sheetIndex);
            if (isexistSheet)
                excelWorkbook.SetSheetHidden(sheetIndex, isHidden);
        }
        public void DeleteSheet(string sheetName)
        {
            bool isexistSheet = isExistSheet(sheetName);
            if (isexistSheet)
            {
                int sheetIndex = excelWorkbook.GetSheetIndex(newsheet);
                excelWorkbook.RemoveSheetAt(sheetIndex);
            }
        }

        #endregion
        #region 单元格操作
        private NPOI.SS.UserModel.ICell CreateCell(NPOI.SS.UserModel.IRow newRow, SysConext.Rectangle rectangle)
        {
            NPOI.SS.UserModel.ICell newCell = newRow.GetCell(rectangle.col1);
            if (newCell == null)
                newCell = newRow.CreateCell(rectangle.col1);
            newCell.SetCellValue(rectangle.titleName);
            if (rectangle.isMegerCell)
                newsheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(rectangle.row1, rectangle.row2, rectangle.col1, rectangle.col2));
            return newCell;
        }
        public void CreateHeader(List<SysConext.Rectangle> rectangleListOrderBylevel)
        {
            int level = 0;
            NPOI.SS.UserModel.IRow newRow = newsheet.CreateRow(level);
            foreach (SysConext.Rectangle item in rectangleListOrderBylevel)
            {
                if (item.level != level)
                {
                    newRow = newsheet.CreateRow(item.level);
                    level = item.level;
                }
                CreateCell(newRow, item);
            }
        }
        public void WriteCell(SysConext.Rectangle rectangle)
        {
            NPOI.SS.UserModel.IRow row = newsheet.GetRow(rectangle.row1);
            NPOI.SS.UserModel.ICell cell = row.GetCell(rectangle.col1);
            switch (rectangle.Celltype.ToLower())
            {
                case "string":
                    cell.SetCellType(NPOI.SS.UserModel.CellType.STRING); cell.SetCellValue(rectangle.titleName); break;
                case "int":
                case "float":
                case "double":
                    cell.SetCellType(NPOI.SS.UserModel.CellType.NUMERIC); cell.SetCellValue(Convert.ToDouble(rectangle.titleName)); break;
                case "bool":
                    cell.SetCellType(NPOI.SS.UserModel.CellType.BOOLEAN); cell.SetCellValue(Convert.ToBoolean(rectangle.titleName)); break;
                case "datetime":
                    cell.SetCellValue(Convert.ToDateTime(rectangle.titleName)); break;
                default:
                    cell.SetCellValue(rectangle.titleName); break;
            }


        }
        public object ReadCell(int rowIndex, int colIndex, string cellType)
        {
            Object itemobject;
            NPOI.SS.UserModel.ICell cell = newsheet.GetRow(rowIndex).GetCell(colIndex);
            NPOI.HSSF.UserModel.HSSFFormulaEvaluator e = new NPOI.HSSF.UserModel.HSSFFormulaEvaluator(excelWorkbook);
            cell = e.EvaluateInCell(cell);
            switch (cellType.ToLower())
            {
                case "string":
                    itemobject = cell.StringCellValue; break;
                case "int":
                case "float":
                case "double":
                    itemobject = cell.NumericCellValue; break;
                case "bool":
                    itemobject = cell.BooleanCellValue; break;
                case "datetime":
                    itemobject = cell.DateCellValue; break;
                default:
                    itemobject = cell.ToString(); break;
            }
            return itemobject;
        }
        #endregion
        #region 插入超链接
        public void CreateLink(SysConext.Rectangle rectangle, string sheetName)
        {
            NPOI.SS.UserModel.ISheet MenuSheet = excelWorkbook.GetSheet(sheetName);
            NPOI.SS.UserModel.ICellStyle hlink_style = excelWorkbook.CreateCellStyle();
            NPOI.SS.UserModel.IFont hlink_font = excelWorkbook.CreateFont();
            hlink_font.Underline = (byte)NPOI.SS.UserModel.FontUnderlineType.SINGLE;
            hlink_font.Color = NPOI.HSSF.Util.HSSFColor.BLUE.index;
            hlink_style.SetFont(hlink_font);
            NPOI.SS.UserModel.IRow newRow;
            newRow = MenuSheet.GetRow(rectangle.level);
            if (newRow == null)
                newRow = MenuSheet.CreateRow(rectangle.level);
            NPOI.SS.UserModel.ICell newcell = CreateCell(newRow, rectangle);
            NPOI.HSSF.UserModel.HSSFHyperlink link = new NPOI.HSSF.UserModel.HSSFHyperlink(NPOI.SS.UserModel.HyperlinkType.DOCUMENT);
            link.Address = ("'" + rectangle.titleName + "'!A1");
            newcell.Hyperlink = (link);
            newcell.CellStyle = (hlink_style);
        }
        #endregion
        #region 插入数据行
        private void InsertRow(DataTable dtSource, int maxLevel, int beginIndex)
        {
            string ywq = "";
            NPOI.SS.UserModel.IRow newRow;
            int rowCount = maxLevel;
            int columnsCount = dtSource.Columns.Count;

            foreach (DataRow row in dtSource.Rows)
            {
                string ywqTemp = row[0].ToString();
                if (!string.IsNullOrEmpty(ywq) && ywqTemp != ywq)
                    rowCount++;
                newRow = newsheet.GetRow(rowCount);
                if (newRow == null)
                    newRow = newsheet.CreateRow(rowCount);

                InsertCellByRow(beginIndex, columnsCount, row, newRow);
                rowCount++;
                ywq = ywqTemp;
            }
        }
        private void InsertCellByRow(int beginIndex, int endIndex, DataRow drSource, NPOI.SS.UserModel.IRow currentExcelRow)
        {
            for (int cellIndex = beginIndex; cellIndex < endIndex; cellIndex++)
            {
                //列名称
                NPOI.SS.UserModel.ICell newCell = currentExcelRow.GetCell(cellIndex);
                newCell.SetCellType(NPOI.SS.UserModel.CellType.NUMERIC);
                newCell.SetCellValue(Convert.ToDouble(drSource[cellIndex]));
            }
        }
        #endregion
        #region
        public void ExportExcel(DataTable dtSource, int maxLevel, int beginIndex)
        {
            InsertRow(dtSource, maxLevel, beginIndex);
        }
        #endregion
    }
}
