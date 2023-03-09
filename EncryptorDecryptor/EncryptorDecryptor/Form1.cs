using System.Text;
using System.IO;
using System.Linq;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;
using Application = System.Windows.Forms.Application;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Globalization;

namespace EncryptorDecryptor
{
    public partial class Form1 : Form
    {
        string temp;
        string DbLngthDb;
        int DbLngth;
        string line;
        string[] Temp = new string[10];
        char[] Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz=~+ßÁ|-_ó^$*®[]˘µ%£¥`!?./,;:…»À ÈËÎÍ¡¿¬ƒ‚‰·‡Ÿ˘µ&@()1234567890\n\\\"\' ".ToCharArray();
        char[] AlphbtDbGn = "ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz~+ßÁ|-_ó^$*®[]˘µ%£¥`!?./,;:…»À ÈËÎÍ¡¿¬ƒ‚‰·‡Ÿ˘µ&@()1234567890".ToCharArray();
        char[] AlphbtNoSmblGn = "ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz1234567890".ToCharArray();
        Random rnd = new Random();
        
        
        string Output;
        
        //string[] DB = File.ReadAllLines("C:\\Encryptor/EncryptorDB.txt");   
        
        List<string> DB = new List<string>();
        int o;
        int i;
        bool found = false;
        bool DBLdd = false;
        string FilePath = "C://Encryptor/";
        string FileName = "EncryptorDB.xlsx";
        string FileNam = @"C:\Encryptor/EncryptorDB.xlsx";
        string WW = "";


        public Form1()
        {
            InitializeComponent();
            

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WWLngthI.Maximum = 250;
            WWLngthI.Minimum = 1;
        }

        //Load DB
        private void button4_Click(object sender, EventArgs e)
        {
            int i = 2;
            DB.Clear();
            //StreamReader sr = new StreamReader("C:\\Encryptor/EncryptorDB.txt");
            if(FileNam == null)
            {
                textBox1.Text = "Please select the DB file location with the select file buton."; 
            } else
            if(File.Exists(FileNam) == false)
            {
                textBox1.Text = "No DB found at: \r\n"  + FileNam + "\r\nPlease make one with the GenerateDB button.";
                wait(2000);
                textBox1.Clear();
            } else
            {

                Excel.Application xlApp = new Excel.Application();
                Excel.Workbooks xlWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkbook = xlWorkbooks.Open(FileNam, Missing.Value, Missing.Value, Missing.Value, WW);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                if (xlRange.Cells[1, i] != null && xlRange.Cells[1, i].Value2 != null)
                {
                    DbLngthDb = xlRange.Cells[1, 1].Value2.ToString();

                    string Line = xlRange.Cells[1, i].Value2.ToString();
                    try
                    {

                        while (Line != null)
                        {
                            DB.Add(Line);
                            //  richTextBox4.Text += Line + " ";
                            i++;
                            Line = xlRange.Cells[1, i].Value2.ToString();
                        }
                    }
                    catch (Exception err) { textBox1.Text = "ERROR: " + err.Message + " Or the read is complete"; wait(1000); textBox1.Clear(); }
                    //sr.Close();
                    DBLdd = true;
                    DBLngthI.Value = Convert.ToInt32(DbLngthDb);
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

            

        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            
            if (DBLdd == true)
            {
                i = 0;
                char[] input = richTextBox3.Text.ToCharArray();
                richTextBox4.Clear();

                
            foreach (char letter in input)
            {
                while (found != true)
                {
                    if (letter == Alphabet[i])
                    {
                        richTextBox4.Text += DB[i];
                        found = true;
                        i++;
                        continue;
                    }
                    else 
                        {
                            i++;
                            found = false; 
                            if (i == 118) 
                            {
                                textBox1.Text = "Symbol not in Symbol list: " + letter + ", Please report this to the creator.";
                                break;
                            }
                            continue;
                        }

                }
                found = false;
                i = 0;
            }
                
                
                
            } else if (DBLdd == false)
            {
                textBox1.Text = "No DB loaded!";
                wait(1000);
                textBox1.Clear();
            }
            
            
            
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            if (DBLdd == true)
            {

            
                DbLngth = Convert.ToInt32(DBLngthI.Value);
                if(DbLngth >= 2)
                {
                    richTextBox4.Text = "";
                    i = 0;
                    List<string> input = new List<string>();
                    input = richTextBox3.Text.SplitInParts(DbLngth).ToList();
                    foreach (var tst in input)
                    {
                        while (found != true)
                        {
                            if (tst == DB[i])
                            {
                                richTextBox4.Text += Alphabet[i];
                                found = true;
                                i++;
                                continue;
                            }
                            else { i++; found = false; continue; }

                        }
                        found = false;
                        i = 0;
                    }
                } else if (DbLngth < 2)
                {
                
                    textBox1.Text = "Db Length must be more then 2";
                    wait(1000);
                    textBox1.Clear();

                }
            }
            else if (DBLdd == false)
            {
                textBox1.Text = "No DB loaded!";
                wait(1000);
                textBox1.Clear();
            }


        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }
        //DEBUGBOX
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //Gen new db
        private void button1_Click(object sender, EventArgs e)
        {
            File.Delete(FileNam);
            if(File.Exists(FileNam) == false)
            {
                textBox1.Text = "No DB file found, Creating one at: " + FileNam;
                CreateExcell(FilePath, FileName);
            }
            int c = 2;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbooks xlWorkbooks = xlApp.Workbooks;
            Excel.Workbook xlWorkbook = xlWorkbooks.Open(FileNam, Missing.Value, Missing.Value, Missing.Value, WW);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            if (/*xlRange.Cells[1, 1] != null && xlRange.Cells[1, 1].Value2 != null*/ true)
            {
                DbLngth = Convert.ToInt32(DBLngthI.Value);
                if (DbLngth >= 2)
                {
                    int SlctdLngth = DbLngth;
                    int length = AlphbtDbGn.Length - 1;
                    xlWorksheet.Cells.ClearContents();
                    //File.WriteAllText("C:\\Encryptor/EncryptorDB.txt", String.Empty);

                    //StreamWriter sw = new StreamWriter("C:\\Encryptor/EncryptorDB.txt");
                    xlWorksheet.Cells[1, 1].Value2 = DbLngth;
                    //xlApp.Visible = false;
                    //xlApp.UserControl = false;
                    //xlWorkbook.Save();
                    //sw.WriteLine(textBox2.Text);
                    for (int i = 0; i < Alphabet.Length; i++)
                    {
                        for (int b = 0; b < SlctdLngth; b++)
                        {
                            //sw.Write(AlphbtDbGn[rnd.Next(length)]);
                            //xlWorksheet.Cells[1, c] += AlphbtDbGn[rnd.Next(length)];
                            temp += AlphbtDbGn[rnd.Next(length)];

                        }
                        //sw.WriteLine(AlphbtDbGn[rnd.Next(length)]);
                        xlWorksheet.Cells[1, c].Value2 = temp;
                        c++;
                        temp = "";
                        
                    }
                    xlWorkbook.Save();
                    //sw.Close();



                }
                else if (DbLngth < 2)
                {
                    textBox1.Text = "Db Length must be more then 2";
                    wait(1000);
                    textBox1.Clear();

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
        
        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
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
            

            if (WW != "")
            {
                xlWorkbook.SaveAs(FileNam, Excel.XlFileFormat.xlOpenXMLWorkbook, WW, Missing.Value, false, false, Excel.XlSaveAsAccessMode.xlNoChange, Excel.XlSaveConflictResolution.xlUserResolution, true, Missing.Value, Missing.Value, Missing.Value);
            } else if (WW == "")
            {
                xlWorkbook.SaveAs(FileNam, Excel.XlFileFormat.xlOpenXMLWorkbook, Missing.Value, Missing.Value, false, false, Excel.XlSaveAsAccessMode.xlNoChange, Excel.XlSaveConflictResolution.xlUserResolution, true, Missing.Value, Missing.Value, Missing.Value);
            }
            

            xlWorkbook.Close(true);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(xlApp);

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(richTextBox4.Text);
        }

        private void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void SelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse .xlsx files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xlsx",
                Filter = "xlsx files (*.xlsx)|*.xlsx",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
                
            };

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileNam = openFileDialog.FileName;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RndmWW_CheckedChanged(object sender, EventArgs e)
        {
            WWLngthI.Visible = RndmWW.Checked;
            WwlengthLabel.Visible = RndmWW.Checked;
            NoSmbls.Visible = RndmWW.Checked;
            if (RndmWW.Checked == true)
            {
                GeenWWCB.Checked = false;
                EigWW.Checked = false;
            }
        }

        private void GeenWWCB_CheckedChanged(object sender, EventArgs e)
        {
            WW = "";
            if (GeenWWCB.Checked == true)
            {
                RndmWW.Checked = false;
                EigWW.Checked = false;
            }
        }

        private void EigWW_CheckedChanged(object sender, EventArgs e)
        {
            EigWWww.Visible = EigWW.Checked;
            EigWWlabel.Visible = EigWW.Checked;
            if (EigWW.Checked == true)
            {
                GeenWWCB.Checked = false;
                RndmWW.Checked = false;
            }
        }

        private void EigWWww_TextChanged(object sender, EventArgs e)
        {
            WW = EigWWww.Text;
        }

        private void FileWW_TextChanged(object sender, EventArgs e)
        {
                WW = FileWW.Text;
        }

        private void NoSmbls_CheckedChanged(object sender, EventArgs e)
        {
            WWLngthI_ValueChanged(sender, e);
        }

        private void WWLngthI_ValueChanged(object sender, EventArgs e)
        {
            WW = "";
            int NoSmblLgth = AlphbtNoSmblGn.Length - 1;
            int length = AlphbtDbGn.Length - 1;
            int WWlngth = 0;

            WWlngth = Convert.ToInt32(WWLngthI.Value);           
            for (int i = 0; i < WWlngth; i++)
            {
                if (NoSmbls.Checked == true)
                {
                    WW += AlphbtNoSmblGn[rnd.Next(NoSmblLgth)].ToString();
                }
                else if (NoSmbls.Checked == false)
                {
                    WW += AlphbtDbGn[rnd.Next(length)].ToString();
                }

            }
            if (WW != "")
            {
                Clipboard.SetText(WW);
                textBox1.Text = "Random WW copied to clipboard.";
            }
        }
    }
    static class StringExtensions
    {

        public static IEnumerable<String> SplitInParts(this String s, Int32 partLength)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", nameof(partLength));

            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }

    }

}
