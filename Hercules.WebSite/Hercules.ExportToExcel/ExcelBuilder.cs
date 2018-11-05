using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

using Microsoft.Office.Interop.Excel;

namespace Hercules.ExportToExcel
{
    public class ExcelBuilder
    {

        static char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        Application excelApp = new Application();
        Workbook workBook = null;

        ~ExcelBuilder()
        {
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }

        public void Import(System.Data.DataTable table, FileInfo file, bool newSheet, bool hasTitle, string sheetName = null)
        {
            try
            {
                workBook = excelApp.Workbooks.Add();

                var newWorkSheet = (Worksheet) workBook.Worksheets.Add();


                newWorkSheet = (Worksheet)workBook.ActiveSheet;

                
                newWorkSheet.Name = sheetName == null ? "Sheet" + DateTime.Now.ToString("yyyyMMddHHmmss") : sheetName;

                int SheetRowNum = 1;
                //if (hasTitle)
                //{
                //    int columnidx = 0;
                //    foreach (DataColumn column in table.Columns)
                //    {
                //        newWorkSheet.Range[alpha[columnidx++]][SheetRowNum] = column.ColumnName;
                //    }
                //    SheetRowNum = 2;
                //}

                newWorkSheet.Cells[1,1] = table.Columns[0].ColumnName;
                newWorkSheet.Cells[1, 2] = table.Columns[1].ColumnName;

                //newWorkSheet.Range["A1"].Value2 = table.Columns[0].ColumnName;
                //newWorkSheet.Range["B1"].Value2 = table.Columns[1].ColumnName;

                SheetRowNum = 2;

             

                //foreach (DataRow row in table.Rows)
                //{
                //    int columnidx = 0;
                //    foreach (var item in row.ItemArray)
                //        newWorkSheet.Range[alpha[columnidx++] + SheetRowNum].Value2 = item.ToString();

                //    SheetRowNum++;
                //}

                //newWorkSheet.Range["A2"].Value2 = table.Rows[0][0];
                //newWorkSheet.Range["B2"].Value2 = table.Rows[0][1];

                //newWorkSheet.Range["A3"].Value2 = table.Rows[1][0];
                //newWorkSheet.Range["B3"].Value2 = table.Rows[1][1];

                //workBook.Save();
                

                workBook.SaveAs(file.FullName, Type.Missing,
    Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange,
    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                workBook.Close();
            }
        }

      
    }
}
