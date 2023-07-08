using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;

namespace EncryptorDecryptor
{
    internal class DBGen
    {
        private Main m;

        public void DBGenClass(Main m)
        {
            this.m = m;

            File.Delete(m.FileNam);
            if (File.Exists(m.FileNam) == false)
            {
                m.textBox1.Text = "No DB file found, Creating one at: " + m.FileNam;
                CreateExcell(m.FilePath, m.FileName);
            }
            int c = 2;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbooks xlWorkbooks = xlApp.Workbooks;
            Excel.Workbook xlWorkbook = xlWorkbooks.Open(m.FileNam, Missing.Value, Missing.Value, Missing.Value, m.WW);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            if (/*xlRange.Cells[1, 1] != null && xlRange.Cells[1, 1].Value2 != null*/ true)
            {
                m.DbLngth = Convert.ToInt32(m.DBLngthI.Value);
                if (m.DbLngth >= 2)
                {
                    int SlctdLngth = m.DbLngth;
                    int length = m.AlphbtDbGn.Length - 1;
                    xlWorksheet.Cells.ClearContents();
                    //File.WriteAllText("C:\\Encryptor/EncryptorDB.txt", String.Empty);

                    //StreamWriter sw = new StreamWriter("C:\\Encryptor/EncryptorDB.txt");
                    xlWorksheet.Cells[1, 1].Value2 = m.DbLngth;
                    //xlApp.Visible = false;
                    //xlApp.UserControl = false;
                    //xlWorkbook.Save();
                    //sw.WriteLine(textBox2.Text);
                    for (int i = 0; i < m.Alphabet.Length; i++)
                    {
                        for (int b = 0; b < SlctdLngth; b++)
                        {
                            //sw.Write(AlphbtDbGn[rnd.Next(length)]);
                            //xlWorksheet.Cells[1, c] += AlphbtDbGn[rnd.Next(length)];
                            m.temp += m.AlphbtDbGn[m.rnd.Next(length)];

                        }
                        //sw.WriteLine(AlphbtDbGn[rnd.Next(length)]);
                        xlWorksheet.Cells[1, c].Value2 = m.temp;
                        c++;
                        m.temp = "";

                    }
                    xlWorkbook.Save();
                    //sw.Close();



                }
                else if (m.DbLngth < 2)
                {
                    m.textBox1.Text = "Db Length must be more then 2";
                    m.wait(1000);
                    m.textBox1.Clear();

                }
            }

            xlWorkbook.Close(true);
            xlWorkbooks.Close();
            xlApp.Quit();




            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            //xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //close and release
            //xlWorkbooks.Close();
            Marshal.ReleaseComObject(xlWorkbooks);

            //quit and release
            //xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void CreateExcell(string Path, string Name)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = null;
            Excel.Worksheet xlWorksheet = null;

            xlWorkbook = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            xlWorkbook.Worksheets.Add();

            xlWorksheet = xlWorkbook.Worksheets[1];
            xlWorksheet.Name = "1";


            if (m.WW != "")
            {
                xlWorkbook.SaveAs(m.FileNam, Excel.XlFileFormat.xlOpenXMLWorkbook, m.WW, Missing.Value, false, false, Excel.XlSaveAsAccessMode.xlNoChange, Excel.XlSaveConflictResolution.xlUserResolution, true, Missing.Value, Missing.Value, Missing.Value);
            }
            else if (m.WW == "")
            {
                xlWorkbook.SaveAs(m.FileNam, Excel.XlFileFormat.xlOpenXMLWorkbook, Missing.Value, Missing.Value, false, false, Excel.XlSaveAsAccessMode.xlNoChange, Excel.XlSaveConflictResolution.xlUserResolution, true, Missing.Value, Missing.Value, Missing.Value);
            }


            xlWorkbook.Close(true);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(xlApp);

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
