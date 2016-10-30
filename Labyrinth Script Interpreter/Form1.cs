using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string currentPath = null;
        private main m ;

        public Form1()
        {
            InitializeComponent();
            m = new main(this);
        }

        public void toOutput(string s)
        {
            output.AppendText(s);
        }

        public void toOutput(char s)
        {
            output.AppendText(s.ToString());
        }

        public void toOutput(long s)
        {
            output.AppendText(s.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void getInput()
        {
            output.ReadOnly = false;
            output.SelectionStart = output.TextLength;
            output.SelectionColor = Color.Yellow;
            output.Focus();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            if(file.ShowDialog() == DialogResult.OK)
            {
                currentPath = file.FileName;
                System.IO.File.WriteAllText(file.FileName, input.Text);
            }
        }

        private void Run_Click(object sender, EventArgs e)
        {
            output.Text = string.Empty;
            output.ReadOnly = true;
            m.reset();
            m.getCommands().setCommand(m.turnIntoArray(input.Text));
            m.run();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                currentPath = file.FileName;
                input.Text = "";
                string[] text = System.IO.File.ReadAllLines(file.FileName);
                foreach(string s in text)
                {
                    input.AppendText(s + "\r\n");
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(currentPath == null)
            {
                System.IO.File.WriteAllText(currentPath, input.Text);
            } else
            {
                saveAsToolStripMenuItem_Click( sender, e);
            }
        }

        private void removeCommentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            char[] availableChars = { '+', '-', '~', '@', '#', '%', '^', '*', '<', '>', '\\', ',', '.', ':', '[', ']', 'v', 'r', 'l', '?', ' ' };
            string temp = string.Empty;
            System.IO.StringReader reader = new System.IO.StringReader(input.Text);
            string line = string.Empty;

            while (line != null)
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    foreach(char c in line)
                    {
                        if (availableChars.Contains(c))
                        {
                            temp += c;
                        } else
                        {
                            temp += " ";
                        }
                    }
                }
                temp += "\r\n";
            }

            input.Text = temp;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void output_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.Enter)
            {
                output.ReadOnly = true;
                output.SelectionStart = output.TextLength;
                output.SelectionColor = Color.White;
                m.getLogic().setInput(output.Lines[output.Lines.Length - 1]);
                toOutput("\r\n");
                m.setPause(false);
                m.run();
            }
        }

        private void output_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
