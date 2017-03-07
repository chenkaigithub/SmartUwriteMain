using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Runtime.InteropServices;
using BIMT.Util.Properties;
using System.Data.OleDb;
using System.Data;

namespace BIMT.Util
{
    public static class ExcelHelper
    {

        public static void DataTabletoExcel(System.Data.DataTable tmpDataTable, string strFileName)
        {
            if (tmpDataTable == null)
                return;
            int rowNum = tmpDataTable.Rows.Count;
            int columnNum = tmpDataTable.Columns.Count;
            int rowIndex = 1;
            int columnIndex = 0;

            Application xlApp = new Application();
            xlApp.DefaultFilePath = "";
            xlApp.DisplayAlerts = true;
            xlApp.SheetsInNewWorkbook = 1;
            Workbook xlBook = xlApp.Workbooks.Add(true);

            //将DataTable的列名导入Excel表第一行
            foreach (DataColumn dc in tmpDataTable.Columns)
            {
                columnIndex++;
                xlApp.Cells[rowIndex, columnIndex] = dc.ColumnName;
            }

            //将DataTable中的数据导入Excel中
            for (int i = 0; i < rowNum; i++)
            {
                rowIndex++;
                columnIndex = 0;
                for (int j = 0; j < columnNum; j++)
                {
                    columnIndex++;
                    xlApp.Cells[rowIndex, columnIndex] = tmpDataTable.Rows[i][j].ToString();
                }
            }
            //xlBook.SaveCopyAs(HttpUtility.UrlDecode(strFileName, System.Text.Encoding.UTF8));
            xlBook.SaveCopyAs(strFileName); xlApp.Quit();
        }

        [method: Obsolete("该方法炸了")]  
        public static bool ExportExcel(System.Data.DataTable dt, string path)
        {
            bool succeed = false;
            if (dt != null)
            {
                Microsoft.Office.Interop.Excel.Application xlApp = null;
                try
                {
                    xlApp = new Microsoft.Office.Interop.Excel.Application();//.ApplicationClass();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (xlApp != null)
                {
                    try
                    {
                        Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                        object oMissing = System.Reflection.Missing.Value;
                        Microsoft.Office.Interop.Excel.Worksheet xlSheet = null;

                        xlSheet = (Worksheet)xlBook.Worksheets[1];
                        xlSheet.Name = "11";

                        int rowIndex = 1;
                        int colIndex = 1;
                        int colCount = dt.Columns.Count;
                        int rowCount = dt.Rows.Count;

                        //列名的处理
                        for (int i = 0; i < colCount; i++)
                        {
                            xlSheet.Cells[rowIndex, colIndex] = dt.Columns[i].ColumnName;
                            colIndex++;
                        }
                        //列名加粗显示
                        //xlSheet.get_Range(xlSheet.Cells[rowIndex, 1], xlSheet.Cells[rowIndex, colCount]).Font.Bold = true;
                        //xlSheet.get_Range(xlSheet.Cells[rowIndex, 1], xlSheet.Cells[rowCount + 1, colCount]).Font.Name = "Arial";
                        //xlSheet.get_Range(xlSheet.Cells[rowIndex, 1], xlSheet.Cells[rowCount + 1, colCount]).Font.Size = "10";
                        rowIndex++;

                        for (int i = 0; i < rowCount; i++)
                        {
                            colIndex = 1;
                            for (int j = 0; j < colCount; j++)
                            {
                                xlSheet.Cells[rowIndex, colIndex] = dt.Rows[i][j].ToString();
                                colIndex++;
                            }
                            rowIndex++;
                        }
                        xlSheet.Cells.EntireColumn.AutoFit();

                        xlApp.DisplayAlerts = false;
                        path = Path.GetFullPath(path);
                        xlBook.SaveCopyAs(path);
                        xlBook.Close(false, null, null);
                        xlApp.Workbooks.Close();
                        Marshal.ReleaseComObject(xlSheet);
                        Marshal.ReleaseComObject(xlBook);
                        xlBook = null;
                        succeed = true;
                    }
                    catch (Exception ex)
                    {
                        succeed = false;
                    }
                    finally
                    {
                        xlApp.Quit();
                        Marshal.ReleaseComObject(xlApp);
                        int generation = System.GC.GetGeneration(xlApp);
                        xlApp = null;
                        System.GC.Collect(generation);
                    }
                }
            }
            return succeed;
        }

        public static System.Data.DataTable ImportExcel(string strFileName)         //strFileName指定的路径+文件名.xls
        {
            if (strFileName != "")
            {
                string conn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFileName + ";Extended Properties=Excel 12.0";
                string sql = "select * from [Sheet2$]";
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds, "datatable");
                }
                catch
                {

                }
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        } 

        private static string excelstring = "Provider=Microsoft.Ace.OleDb.12.0;data source='{0}';Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'";
        [method: Obsolete("该方法炸了")]  
        public static void SaveAsExcel(string name, System.Data.DataTable dt)
        {
            OleDbConnection cnnxls = new OleDbConnection(string.Format(excelstring, name+""));
            string insertcolumnstring = "";
            string insertvaluestring = "";
            string fileName = name + ".xls";
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
            int colIndex = 0;
            foreach (DataColumn col in dt.Columns)
            {
                colIndex++;
                excel.Cells[1, colIndex] = col.ColumnName;
                insertcolumnstring += string.Format("{0},", col.ColumnName);
            }
            excel.ActiveWorkbook.SaveAs(fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel7, null, null, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);
            insertcolumnstring = insertcolumnstring.Trim(',');
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    row[dc].ToString();
                    insertvaluestring += string.Format("'{0}',", row[dc].ToString().Replace("'", "''"));
                }
                string sql = string.Format("insert into [Sheet1$]({0}) values({1})", insertcolumnstring, insertvaluestring);
                OleDbDataAdapter myDa = new OleDbDataAdapter(sql, cnnxls);
                myDa.InsertCommand.ExecuteNonQuery();
            }
            excel.Visible = false;
            excel.Quit();
            excel = null;
            GC.Collect();//垃圾回收 
        }
        [method: Obsolete("该方法炸了")]  
        public static bool ExportExcelWithAspose(System.Data.DataTable dt, string path)
        {
            bool succeed = false;
            if (dt != null)
            {
                try
                {
                    Aspose.Cells.License li = new Aspose.Cells.License();
                    string lic = Resources.License;
                    Stream s = new MemoryStream(ASCIIEncoding.Default.GetBytes(lic));
                    li.SetLicense(s);

                    Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
                    Aspose.Cells.Worksheet cellSheet = workbook.Worksheets[0];

                    cellSheet.Name = dt.TableName;

                    int rowIndex = 0;
                    int colIndex = 0;
                    int colCount = dt.Columns.Count;
                    int rowCount = dt.Rows.Count;

                    //列名的处理
                    for (int i = 0; i < colCount; i++)
                    {
                        cellSheet.Cells[rowIndex, colIndex].PutValue(dt.Columns[i].ColumnName);
                        cellSheet.Cells[rowIndex, colIndex].Style.Font.IsBold = true;
                        cellSheet.Cells[rowIndex, colIndex].Style.Font.Name = "宋体";
                        colIndex++;
                    }

                    Aspose.Cells.Style style = workbook.Styles[workbook.Styles.Add()];
                    style.Font.Name = "Arial";
                    style.Font.Size = 10;
                    Aspose.Cells.StyleFlag styleFlag = new Aspose.Cells.StyleFlag();
                    cellSheet.Cells.ApplyStyle(style, styleFlag);

                    rowIndex++;

                    for (int i = 0; i < rowCount; i++)
                    {
                        colIndex = 0;
                        for (int j = 0; j < colCount; j++)
                        {
                            cellSheet.Cells[rowIndex, colIndex].PutValue(dt.Rows[i][j].ToString());
                            colIndex++;
                        }
                        rowIndex++;
                    }
                    cellSheet.AutoFitColumns();

                    path = Path.GetFullPath(path);
                    workbook.Save(path);
                    succeed = true;
                }
                catch (Exception ex)
                {
                    succeed = false;
                }
            }

            return succeed;
        }

        //public static void DataGridView(DataGridView) { }
    }
}
