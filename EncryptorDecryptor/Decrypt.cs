using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EncryptorDecryptor
{
    public class Decrypt : Form
    {
        private Main m;
        
        public void DecryptClass(Main m)
        {
            this.m = m;

            if (m.DBLdd == true)
            {

                m.DbLngth = Convert.ToInt32(m.DBLngthI.Value);
                if (m.DbLngth >= 2)
                {
                    m.richTextBox4.Text = "";
                    m.i = 0;
                    List<string> input = new List<string>();
                    input = m.richTextBox3.Text.SplitInParts(m.DbLngth).ToList();
                    try
                    {


                        foreach (var tst in input)
                        {
                            while (m.found != true)
                            {
                                if (tst == m.DB[m.i])
                                {
                                    m.richTextBox4.Text += m.Alphabet[m.i];
                                    m.found = true;
                                    m.i++;
                                    continue;
                                }
                                else { m.i++; m.found = false; continue; }

                            }
                            m.found = false;
                            m.i = 0;
                        }
                    }
                    catch (Exception Ex)
                    {
                        m.textBox1.Text = "String not in DB!";
                        m.wait(4000);
                        m.textBox1.Text = "";
                    }
                }
                else if (m.DbLngth < 2)
                {

                    m.textBox1.Text = "Db Length must be more then 2";
                    m.wait(1000);
                    m.textBox1.Clear();

                }
            }
            else if (m.DBLdd == false)
            {
                m.textBox1.Text = "No DB loaded!";
                m.wait(1000);
                m.textBox1.Clear();
            }
        }
    

    }
}
