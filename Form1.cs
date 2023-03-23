using InfoBez.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace InfoBez
{
    enum Mode { Encode, Decode };
    
    public partial class Form1 : Form
    {
        string outputText;
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_WorkDone;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            selectedMode.SelectedIndex = (int)Mode.Encode;

            textInput.DoubleClick += TexBox_Click;
            textOutput.DoubleClick += TexBox_Click;

            if (!File.Exists("Playfair.key"))
            {
                File.WriteAllText("Playfair.key", Resources.Playfair);
            }
            key.Text = Path.Combine(Application.StartupPath, "Playfair.key");

        }
        private void openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog();
            opfd.Multiselect = false;
            opfd.InitialDirectory = Application.StartupPath;
            if (opfd.ShowDialog(this) == DialogResult.OK)
            {
                key.Text = opfd.FileName;
            }
        }
        private void Playfair()
        {

            try
            {
                List<List<string>> matrix = File.ReadAllLines(key.Text).Select(x => x.Split(' ').ToList()).ToList();
                foreach (var c in (textInput.Text + fillingСhar.Text).Replace(" ",""))
                {

                    if (matrix.Where(x => x.Contains(c.ToString().ToUpper())).Count() == 0)
                    {
                        MessageBox.Show("Во входной строке или заполнителе есть символы, которые не были определены в ключе", "ОШИБКА ВСЁ НЕПРАВИЛЬНО!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                Playfair(textInput, matrix, (Mode)selectedMode.SelectedIndex);
            }
            catch
            {
                MessageBox.Show("По непонятной причине всё сломалось. Скорее всего, неправильно записан ключ", "ОШИБКА ВСЁ НЕПРАВИЛЬНО!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Playfair(TextBox input, List<List<string>> key, Mode mode = Mode.Encode)
        {
           backgroundWorker1.RunWorkerAsync(new List<object>{input.Text, key, fillingСhar.Text, mode});

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Playfair();

        }


        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void TexBox_Click(object sender, EventArgs e)
        {

            (textInput.Text, textOutput.Text) = (textOutput.Text, textInput.Text);
            Playfair();
        }

        private void textInput_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            List<object> list = e.Argument as List<object>;
            string inputText = (string)list[0];
            List<List<string>> key = list[1] as List<List<string>>;
            string fillingChar = (string)list[2];
            Mode mode = (Mode)list[3];
            outputText = "";

            List<string> pairs = new List<string>();
            inputText = inputText.Replace(" ", "");

            while (inputText != "")
            {
                if (inputText.Length == 1 || inputText[0] == inputText[1])
                {
                    pairs.Add(inputText[0] + fillingChar);
                    inputText=inputText.Remove(0, 1);
                }
                else
                {
                    pairs.Add(inputText[0] + inputText[1].ToString());
                    inputText=inputText.Remove(0, 2);
                }
                
            }
            int row0, col0, row1, col1;
            foreach (var pair in pairs)
            {
                row0 = key.IndexOf(key.Where(x => x.Contains(pair[0].ToString())).First());
                col0 = key[row0].IndexOf(pair[0].ToString());

                row1 = key.IndexOf(key.Where(x => x.Contains(pair[1].ToString())).First());
                col1 = key[row1].IndexOf(pair[1].ToString());

                if (row0 == row1)
                {
                    outputText += (key[row0][col0 == (mode == Mode.Encode ? key[row0].Count - 1 : 0) ?
                        (mode != Mode.Encode ? key[row0].Count - 1 : 0) :
                        col0 += (mode == Mode.Encode ? 1 : -1)]);

                    outputText += (key[row0][col1 == (mode == Mode.Encode ? key[row0].Count - 1 : 0) ?
                        (mode != Mode.Encode ? key[row0].Count - 1 : 0) :
                        col1 += (mode == Mode.Encode ? 1 : -1)]);
                }
                else if (col0 == col1)
                {
                    outputText += (key[row0 == (mode == Mode.Encode ? key.Count - 1 : 0) ?
                        (mode != Mode.Encode ? key.Count - 1 : 0) :
                        row0 += (mode == Mode.Encode ? 1 : -1)][col0]);

                    outputText += (key[row1 == (mode == Mode.Encode ? key.Count - 1 : 0) ?
                        (mode != Mode.Encode ? key.Count - 1 : 0) :
                        row1 += (mode == Mode.Encode ? 1 : -1)][col0]);

                }
                else
                {
                    outputText += key[row0][col1];
                    outputText += key[row1][col0];
                }
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textOutput.Text = outputText;
            progressBar.Value = (int)e.ProgressPercentage;
        }

        private void backgroundWorker1_WorkDone(object sender, RunWorkerCompletedEventArgs e)
        {
            textOutput.Text = outputText;
            progressBar.Value = 100;
        }

        private void key_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void key_MouseEnter(object sender, EventArgs e)
        {
            

        }

        private void key_TextChanged(object sender, EventArgs e)
        {

        }

        private void edit_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c notepad \"{key.Text}\"",
                WindowStyle = ProcessWindowStyle.Hidden
            });
        }
    }
}
