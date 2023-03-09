namespace EncryptorDecryptor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Encrypt = new System.Windows.Forms.Button();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.Decrypt = new System.Windows.Forms.Button();
            this.loaddb = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.newdb = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SelectFile = new System.Windows.Forms.Button();
            this.GeenWWCB = new System.Windows.Forms.CheckBox();
            this.RndmWW = new System.Windows.Forms.CheckBox();
            this.EigWW = new System.Windows.Forms.CheckBox();
            this.WwlengthLabel = new System.Windows.Forms.Label();
            this.EigWWww = new System.Windows.Forms.RichTextBox();
            this.EigWWlabel = new System.Windows.Forms.Label();
            this.FileWW = new System.Windows.Forms.RichTextBox();
            this.WWherelbl = new System.Windows.Forms.Label();
            this.NoSmbls = new System.Windows.Forms.CheckBox();
            this.WWLngthI = new System.Windows.Forms.NumericUpDown();
            this.DBLngthI = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.WWLngthI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBLngthI)).BeginInit();
            this.SuspendLayout();
            // 
            // Encrypt
            // 
            this.Encrypt.Location = new System.Drawing.Point(502, 12);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(94, 29);
            this.Encrypt.TabIndex = 0;
            this.Encrypt.Text = "Encrypt";
            this.Encrypt.UseVisualStyleBackColor = true;
            this.Encrypt.Click += new System.EventHandler(this.Encrypt_Click);
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(12, 12);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(484, 140);
            this.richTextBox3.TabIndex = 1;
            this.richTextBox3.Text = "";
            this.richTextBox3.TextChanged += new System.EventHandler(this.richTextBox3_TextChanged);
            // 
            // richTextBox4
            // 
            this.richTextBox4.Location = new System.Drawing.Point(12, 158);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(484, 140);
            this.richTextBox4.TabIndex = 2;
            this.richTextBox4.Text = "";
            this.richTextBox4.TextChanged += new System.EventHandler(this.richTextBox4_TextChanged);
            // 
            // Decrypt
            // 
            this.Decrypt.Location = new System.Drawing.Point(502, 47);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(94, 29);
            this.Decrypt.TabIndex = 3;
            this.Decrypt.Text = "Decrypt";
            this.Decrypt.UseVisualStyleBackColor = true;
            this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // loaddb
            // 
            this.loaddb.Location = new System.Drawing.Point(737, 11);
            this.loaddb.Name = "loaddb";
            this.loaddb.Size = new System.Drawing.Size(94, 29);
            this.loaddb.TabIndex = 4;
            this.loaddb.Text = "Load DB";
            this.loaddb.UseVisualStyleBackColor = true;
            this.loaddb.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(837, 11);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(240, 104);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // newdb
            // 
            this.newdb.Location = new System.Drawing.Point(732, 49);
            this.newdb.Name = "newdb";
            this.newdb.Size = new System.Drawing.Size(99, 27);
            this.newdb.TabIndex = 6;
            this.newdb.Text = "GenerateDB";
            this.newdb.UseVisualStyleBackColor = true;
            this.newdb.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(736, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 40);
            this.label1.TabIndex = 8;
            this.label1.Text = "DB Length\r\nMin 2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(442, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 29);
            this.button1.TabIndex = 9;
            this.button1.Text = "Copy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "*.xlsx|";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // SelectFile
            // 
            this.SelectFile.Location = new System.Drawing.Point(669, 11);
            this.SelectFile.Name = "SelectFile";
            this.SelectFile.Size = new System.Drawing.Size(62, 55);
            this.SelectFile.TabIndex = 10;
            this.SelectFile.Text = "Select file";
            this.SelectFile.UseVisualStyleBackColor = true;
            this.SelectFile.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // GeenWWCB
            // 
            this.GeenWWCB.AutoSize = true;
            this.GeenWWCB.Checked = true;
            this.GeenWWCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GeenWWCB.Location = new System.Drawing.Point(516, 160);
            this.GeenWWCB.Name = "GeenWWCB";
            this.GeenWWCB.Size = new System.Drawing.Size(97, 24);
            this.GeenWWCB.TabIndex = 11;
            this.GeenWWCB.Text = "Geen WW";
            this.GeenWWCB.UseVisualStyleBackColor = true;
            this.GeenWWCB.CheckedChanged += new System.EventHandler(this.GeenWWCB_CheckedChanged);
            // 
            // RndmWW
            // 
            this.RndmWW.AutoSize = true;
            this.RndmWW.Location = new System.Drawing.Point(516, 190);
            this.RndmWW.Name = "RndmWW";
            this.RndmWW.Size = new System.Drawing.Size(119, 24);
            this.RndmWW.TabIndex = 12;
            this.RndmWW.Text = "Random WW";
            this.RndmWW.UseVisualStyleBackColor = true;
            this.RndmWW.CheckedChanged += new System.EventHandler(this.RndmWW_CheckedChanged);
            // 
            // EigWW
            // 
            this.EigWW.AutoSize = true;
            this.EigWW.Location = new System.Drawing.Point(516, 220);
            this.EigWW.Name = "EigWW";
            this.EigWW.Size = new System.Drawing.Size(113, 24);
            this.EigWW.TabIndex = 13;
            this.EigWW.Text = "Custom WW";
            this.EigWW.UseVisualStyleBackColor = true;
            this.EigWW.CheckedChanged += new System.EventHandler(this.EigWW_CheckedChanged);
            // 
            // WwlengthLabel
            // 
            this.WwlengthLabel.AutoSize = true;
            this.WwlengthLabel.Location = new System.Drawing.Point(648, 168);
            this.WwlengthLabel.Name = "WwlengthLabel";
            this.WwlengthLabel.Size = new System.Drawing.Size(83, 20);
            this.WwlengthLabel.TabIndex = 15;
            this.WwlengthLabel.Text = "WW length";
            this.WwlengthLabel.Visible = false;
            // 
            // EigWWww
            // 
            this.EigWWww.Location = new System.Drawing.Point(648, 220);
            this.EigWWww.Name = "EigWWww";
            this.EigWWww.Size = new System.Drawing.Size(166, 38);
            this.EigWWww.TabIndex = 16;
            this.EigWWww.Text = "";
            this.EigWWww.Visible = false;
            this.EigWWww.TextChanged += new System.EventHandler(this.EigWWww_TextChanged);
            // 
            // EigWWlabel
            // 
            this.EigWWlabel.AutoSize = true;
            this.EigWWlabel.Location = new System.Drawing.Point(648, 194);
            this.EigWWlabel.Name = "EigWWlabel";
            this.EigWWlabel.Size = new System.Drawing.Size(91, 20);
            this.EigWWlabel.TabIndex = 17;
            this.EigWWlabel.Text = "Custom WW";
            this.EigWWlabel.Visible = false;
            // 
            // FileWW
            // 
            this.FileWW.Location = new System.Drawing.Point(866, 157);
            this.FileWW.Name = "FileWW";
            this.FileWW.Size = new System.Drawing.Size(211, 27);
            this.FileWW.TabIndex = 18;
            this.FileWW.Text = "";
            this.FileWW.TextChanged += new System.EventHandler(this.FileWW_TextChanged);
            // 
            // WWherelbl
            // 
            this.WWherelbl.AutoSize = true;
            this.WWherelbl.Location = new System.Drawing.Point(849, 134);
            this.WWherelbl.Name = "WWherelbl";
            this.WWherelbl.Size = new System.Drawing.Size(228, 20);
            this.WWherelbl.TabIndex = 19;
            this.WWherelbl.Text = "WW hier, laat leeg voor geen ww";
            // 
            // NoSmbls
            // 
            this.NoSmbls.AutoSize = true;
            this.NoSmbls.Location = new System.Drawing.Point(720, 189);
            this.NoSmbls.Name = "NoSmbls";
            this.NoSmbls.Size = new System.Drawing.Size(111, 24);
            this.NoSmbls.TabIndex = 20;
            this.NoSmbls.Text = "No Symbols";
            this.NoSmbls.UseVisualStyleBackColor = true;
            this.NoSmbls.Visible = false;
            this.NoSmbls.CheckedChanged += new System.EventHandler(this.NoSmbls_CheckedChanged);
            // 
            // WWLngthI
            // 
            this.WWLngthI.Location = new System.Drawing.Point(648, 190);
            this.WWLngthI.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.WWLngthI.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WWLngthI.Name = "WWLngthI";
            this.WWLngthI.Size = new System.Drawing.Size(58, 27);
            this.WWLngthI.TabIndex = 21;
            this.WWLngthI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WWLngthI.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WWLngthI.Visible = false;
            this.WWLngthI.ValueChanged += new System.EventHandler(this.WWLngthI_ValueChanged);
            // 
            // DBLngthI
            // 
            this.DBLngthI.Location = new System.Drawing.Point(737, 121);
            this.DBLngthI.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.DBLngthI.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.DBLngthI.Name = "DBLngthI";
            this.DBLngthI.Size = new System.Drawing.Size(66, 27);
            this.DBLngthI.TabIndex = 22;
            this.DBLngthI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DBLngthI.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1089, 472);
            this.Controls.Add(this.DBLngthI);
            this.Controls.Add(this.WWLngthI);
            this.Controls.Add(this.NoSmbls);
            this.Controls.Add(this.WWherelbl);
            this.Controls.Add(this.FileWW);
            this.Controls.Add(this.EigWWlabel);
            this.Controls.Add(this.EigWWww);
            this.Controls.Add(this.WwlengthLabel);
            this.Controls.Add(this.EigWW);
            this.Controls.Add(this.RndmWW);
            this.Controls.Add(this.GeenWWCB);
            this.Controls.Add(this.SelectFile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newdb);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.loaddb);
            this.Controls.Add(this.Decrypt);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.Encrypt);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.WWLngthI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBLngthI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       
        
        private Button Encrypt;
        private RichTextBox richTextBox3;
        private RichTextBox richTextBox4;
        private Button Decrypt;
        private Button loaddb;
        private TextBox textBox1;
        private Button newdb;
        private Label label1;
        private Button button1;
        private OpenFileDialog openFileDialog;
        private Button SelectFile;
        private CheckBox GeenWWCB;
        private CheckBox RndmWW;
        private CheckBox EigWW;
        private Label WwlengthLabel;
        private RichTextBox EigWWww;
        private Label EigWWlabel;
        private RichTextBox FileWW;
        private Label WWherelbl;
        private CheckBox NoSmbls;
        private NumericUpDown WWLngthI;
        private NumericUpDown DBLngthI;
    }
}