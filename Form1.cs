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
                filerichTextBox.Text = "";
                string line;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    filerichTextBox.Text += line + "\n";
                }
                sr.Close();
            }
        }

        private void SaveFile()
        {
            StreamWriter sr;
            sr = File.CreateText(openFileDialog1.FileName);

            for (int i = 0; i < filerichTextBox.Lines.Length; i++)
            {
                sr.WriteLine(filerichTextBox.Lines[i]);
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filerichTextBox.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open";
            openFileDialog1.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                filerichTextBox.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);

            this.Text = openFileDialog1.FileName;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save";
            saveFileDialog.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                filerichTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);

            this.Text = saveFileDialog.FileName;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filerichTextBox.Text = DateTime.Now.ToString();
        }

        private void undoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            filerichTextBox.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filerichTextBox.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filerichTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filerichTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filerichTextBox.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filerichTextBox.SelectAll();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
                filerichTextBox.ForeColor = color.Color;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fnt = new FontDialog();
            if (fnt.ShowDialog() == DialogResult.OK)
                filerichTextBox.Font = fnt.Font;
        }
    }
}
