using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptorDecryptor
{
    internal class Encrypt : Form
    {
        private Main m;

        public void EncryptClass(Main m)
        {
            this.m = m;


            if (m.DBLdd == true)
            {
                m.i = 0;
                char[] input = m.richTextBox3.Text.ToCharArray();
                m.richTextBox4.Clear();


                foreach (char letter in input)
                {
                    while (m.found != true)
                    {
                        if (letter == m.Alphabet[m.i])
                        {
                            m.richTextBox4.Text += m.DB[m.i];
                            m.found = true;
                            m.i++;
                            continue;
                        }
                        else
                        {
                            m.i++;
                            m.found = false;
                            if (m.i == 118)
                            {
                                m.textBox1.Text = "Symbol not in Symbol list: " + letter + ", Please report this to the creator.";
                                break;
                            }
                            continue;
                        }

                    }
                    m.found = false;
                    m.i = 0;
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
