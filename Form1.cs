using System.IO;
using System.Windows.Forms;

namespace TextEditior
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                richTextBox1.Text = "";
                string line;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    richTextBox1.Text += line + "\n";
                }
                sr.Close();
            }
        }

        private void SaveFile()
        {
            StreamWriter sr;
            sr = File.CreateText(openFileDialog1.FileName);

            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {
                sr.WriteLine(richTextBox1.Lines[i]);
            }
            sr.Close();
        }
        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName != null)
                SaveFile();
            else
            {
                openFileDialog1.ShowDialog();
                
            }
        }
        private void Form1_OnKeyBoardShortCut(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.Shift | Keys.A))
            {
                SaveFile();
            }


        }

       
    }
}
