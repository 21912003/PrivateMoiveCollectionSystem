using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Office.Interop.Excel;
using System.Reflection;

using   System.Runtime.InteropServices;   

namespace MediaTest
{
    class ExcelOutput
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out   int ID);

        public const string EXCEL_FILE_NAME = @"./system.xlsm";

        private Microsoft.Office.Interop.Excel.Application xApp = null;
        private Workbook xBook = null;
        private IntPtr t = IntPtr.Zero;
        private string excelFileName = null;

        public ExcelOutput() 
        {
            try
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(EXCEL_FILE_NAME);
                excelFileName = fi.FullName;

                if (xApp == null)
                    xApp = new ApplicationClass();
                t = new IntPtr(xApp.Hwnd);
                xApp.Visible = false;
                xApp.DisplayAlerts = false;
                xBook =
                    xApp.Workbooks._Open(excelFileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void outputData(string sheetName, DataGridView dgvMediaInfos)
        {
            try
            {
                Worksheet ws = null;

                //判断sheet是否存在
                for (int i = 0; i < xBook.Sheets.Count; i++)
                {
                    Worksheet xSheet = (Worksheet)xBook.Sheets[i+1];
                    if (sheetName.Equals(xSheet.Name))
                    {
                        ws = xSheet;
                        ws.Delete();
                        ws.Cells.Clear();
                        //ws = null;
                        break;
                    }
                }

                if (ws == null)
                {
                    //建立一个sheet
                    ws = (Worksheet)xBook.Worksheets.Add();
                    ws.Name = sheetName;
                }
             
                //建立表头
                ws.Cells[1, 1] = "NO";
                ws.Cells[1, 2] = "Movie Name";
                ws.Cells[1, 3] = "File Size";
                ws.Cells[1, 4] = "Video Size";
                ws.Cells[1, 5] = "Video Length";
                ws.Cells[1, 6] = "Video Rate";
                ws.Cells[1, 7] = "Subtitle";
                ws.Cells[1, 8] = "File Path";
                ws.Cells[1, 9] = "File Root";
                ws.Cells[1, 10] = "File Name";
                
                
                //冻结首行
                xApp.ActiveWindow.SplitRow = 1;
                //xApp.ActiveWindow.SplitColumn = 9;
                xApp.ActiveWindow.FreezePanes = true;

                int row = 2;
                for (int i = 0; i < dgvMediaInfos.Rows.Count; i++)
                {
                    ws.Cells[row, 1] = i + 1;
                    ws.Cells[row, 2] = dgvMediaInfos.Rows[i].Cells["filenameOfChn"].Value;
                    ws.Cells[row, 3] = dgvMediaInfos.Rows[i].Cells["fileSize"].Value;
                    ws.Cells[row, 4] = dgvMediaInfos.Rows[i].Cells["videoSize"].Value;
                    ws.Cells[row, 5] = dgvMediaInfos.Rows[i].Cells["videoTime"].Value;
                    ws.Cells[row, 6] = dgvMediaInfos.Rows[i].Cells["videoBitrate"].Value;
                    ws.Cells[row, 7] = dgvMediaInfos.Rows[i].Cells["subTitle"].Value;
                    ws.Cells[row, 8] = dgvMediaInfos.Rows[i].Cells["fileParentPath"].Value;
                    ws.Cells[row, 9] = dgvMediaInfos.Rows[i].Cells["fileRoot"].Value;
                    ws.Cells[row, 10] = dgvMediaInfos.Rows[i].Cells["fileName"].Value;
                   

                    row++;
                }

                //设置列宽自动适应
                ws.get_Range(ws.Cells[1, 1], ws.Cells[row, 10]).EntireColumn.AutoFit();

                xBook.Close(Microsoft.Office.Interop.Excel.XlSaveAction.xlDoNotSaveChanges, excelFileName, Missing.Value);
                xApp.Quit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void disponse()
        {
            try
            {
                if (t != IntPtr.Zero)
                {
                    int k = 0;
                    GetWindowThreadProcessId(t, out   k);
                    System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
                    p.Kill();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
