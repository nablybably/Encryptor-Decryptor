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
using System.Windows.Forms;

namespace EncryptorDecryptor
{
    internal class LoadDB : Form
    {
        private Main m;

        public void LoadDBClass(Main m)
        {
            this.m = m;

            int i = 2;
            m.DB.Clear();
            //StreamReader sr = new StreamReader("C:\\Encryptor/EncryptorDB.txt");
            if (m.FileNam == null)
            {
                m.textBox1.Text = "Please select the DB file location with the select file buton.";
            }
            else
            if (File.Exists(m.FileNam) == false)
            {
                m.textBox1.Text = "No DB found at: \r\n" + m.FileNam + "\r\nPlease make one with the GenerateDB button.";
                m.wait(2000);
                m.textBox1.Clear();
            }
            else
            {
                try
                {


                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbooks xlWorkbooks = xlApp.Workbooks;
                    Excel.Workbook xlWorkbook = xlWorkbooks.Open(m.FileNam, Missing.Value, Missing.Value, Missing.Value, m.WW);
                    Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                    Excel.Range xlRange = xlWorksheet.UsedRange;


                    if (xlRange.Cells[1, i] != null && xlRange.Cells[1, i].Value2 != null)
                    {
                        m.DbLngthDb = xlRange.Cells[1, 1].Value2.ToString();

                        string Line = xlRange.Cells[1, i].Value2.ToString();
                        try
                        {

                            while (Line != null)
                            {
                                m.DB.Add(Line);
                                //  richTextBox4.Text += Line + " ";
                                i++;
                                Line = xlRange.Cells[1, i].Value2.ToString();
                            }
                        }
                        catch (Exception err) { m.textBox1.Text = "ERROR: " + err.Message + " Or the read is complete"; m.wait(1000); m.textBox1.Clear(); }
                        //sr.Close();
                        m.DBLdd = true;
                        m.DBLngthI.Value = Convert.ToInt32(m.DbLngthDb);
                    }



                    //release com objects to fully kill excel process from running in the background
                    Marshal.ReleaseComObject(xlRange);
                    Marshal.ReleaseComObject(xlWorksheet);

                    //close and release
                    xlWorkbook.Close();
                    Marshal.ReleaseComObject(xlWorkbook);

                    xlWorkbooks.Close();
                    Marshal.ReleaseComObject(xlWorkbooks);

                    //quit and release
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);

                    //cleanup
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                catch (Exception Ex)
                {
                    //m.textBox1.Text = "Wrong password or file is corrupt!";
                    m.textBox1.Text = "Wrong password, check if password is correct/CAPS LOCK is Off. Or the file is corrupt and unable to open.";
                    m.wait(4000);
                    m.textBox1.Text = "";
                }
            }
        }
    }
}
