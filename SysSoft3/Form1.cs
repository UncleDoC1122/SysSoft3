using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysSoft3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool flagInputFile;
        private bool flagOutputFile;

        private List<string> divider()
        {
            string input = textBox1.Text;

            List<string> output = new List<string>();
            string tmp = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Equals(' '))
                {
                    output.Add(tmp);
                    tmp = "";
                }
                else if (input[i].Equals('<') || input[i].Equals('>') || input[i].Equals('=') || input[i].Equals('&'))
                {
                    if (!tmp.Equals(""))
                    {
                        output.Add(tmp);
                        tmp = "";
                    }
                    string tmp2 = "";
                    tmp2 += input[i];
                    
                    output.Add(tmp2);
                }
                else if (input[i].Equals('x') && input[i + 1].Equals('o') && input[i + 2].Equals('r'))
                {
                    if (!tmp.Equals(""))
                    {
                        output.Add(tmp);
                        tmp = "";
                    }
                    string tmp2 = "xor";
                   
                    i += 2;
                    output.Add(tmp2);
                }
                else if(input[i].Equals('\"'))
                {
                    if (!tmp.Equals(""))
                    {
                        output.Add(tmp);
                    } 
                    tmp = "\"";
                    i++;
                    while (input[i].Equals('\"') == false)
                    {
                        tmp += input[i];
                        i++;
                    }
                    tmp += "\"";
                    output.Add(tmp);
                    tmp = "";
                }
                else if(input[i].Equals('|') && input[i + 1].Equals('|'))
                {
                    string tmp2 = "||";
                    output.Add(tmp2);
                    i++;
                }
                else if (i == input.Length - 1)
                {
                    tmp += input[i];
                    output.Add(tmp);
                }
                else
                {
                    tmp += input[i];
                }
            }

            return output;
        }

        private void printingIdentifyers(List<string> input)
        {
            for (int i = 0; i < input.Count; i ++)
            {
                if (input[i].Equals("<") || input[i].Equals(">") || input[i].Equals("+") || input[i].Equals("||") || input[i].Equals("&") || input[i].Equals("xor") || input[i].Equals("="))
                {
                    dataGridView1.Rows.Add(input[i], "Знак операции", input[i]);
                }
                else if (input[i][0].Equals('\"') && input[i][input[i].Length - 1].Equals('\"'))
                {
                    dataGridView1.Rows.Add(input[i], "Строковая константа", "const");
                }
                else
                {
                    dataGridView1.Rows.Add(input[i], "Идентификатор", "identifier");
                }
            }
        }        

        private void выбратьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string InputData = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                InputData = openFileDialog1.rea;
                textBox1.Text = InputData;
                sr.Close();
            }
        }

        private void выбратьВыводToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            List<string> inner = divider();
            printingIdentifyers(inner);
        }

        
    }
}
