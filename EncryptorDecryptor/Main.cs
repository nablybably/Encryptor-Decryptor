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
using EncryptorDecryptor;

namespace EncryptorDecryptor
{
    public partial class Main : Form
    {
        
        public string temp;
        public string DbLngthDb;
        public int DbLngth;
        public string line;
        public string[] Temp = new string[10];
        public char[] Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz=~+ßÁ|-_ó^$*®[]˘µ%£¥`!?./,;:…»À ÈËÎÍ¡¿¬ƒ‚‰·‡Ÿ˘µ&@()1234567890\n\\\"\' ".ToCharArray();
        public char[] AlphbtDbGn = "ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz~+ßÁ|-_ó^$*®[]˘µ%£¥`!?./,;:…»À ÈËÎÍ¡¿¬ƒ‚‰·‡Ÿ˘µ&@()1234567890".ToCharArray();
        public char[] AlphbtNoSmblGn = "ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz1234567890".ToCharArray();
        public Random rnd = new Random();
        
        
        public string Output;
        
        //string[] DB = File.ReadAllLines("C:\\Encryptor/EncryptorDB.txt");   
        
        public List<string> DB = new List<string>();
        public int o;
        public int i;
        public bool found;
        public bool DBLdd;
        public string FilePath = "C://Encryptor/";
        public string FileName = "EncryptorDB.xlsx";
        public string FileNam = @"C:\Encryptor/EncryptorDB.xlsx";
        public string WW = "";


        public Main()
        {
            InitializeComponent();
            

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WWLngthI.Maximum = 250;
            WWLngthI.Minimum = 1;
            DBLdd = false;
        }

        //Load DB
        private void button4_Click(object sender, EventArgs e)
        {
            var LdDB = new LoadDB();
            LdDB.LoadDBClass(this);
        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            var en = new Encrypt();
            en.EncryptClass(this);
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            var d = new Decrypt();
            d.DecryptClass(this);
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
            var Db = new DBGen();
            Db.DBGenClass(this);
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
