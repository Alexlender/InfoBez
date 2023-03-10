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

            if (!File.Exists("Polybius.key"))
            {
                File.WriteAllText("Polybius.key", Resources.Polybius);
            }
            key.Text = Path.Combine(Application.StartupPath, "Polybius.key");

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
        private void Polybius()
        {
            try
            {
                List<List<string>> matrix = File.ReadAllLines(key.Text).Select(x => x.Split(' ').ToList()).ToList();
                foreach(var c in textInput.Text)
                {

                    if (matrix.Where(x => x.Contains(c.ToString().ToUpper())).Count() == 0)
                    {
                        MessageBox.Show("Во входной строке есть символы, которые не были определены в ключе", "ОШИБКА ВСЁ НЕПРАВИЛЬНО!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                Polybius(textInput, matrix, (Mode)selectedMode.SelectedIndex);
            }
            catch
            {
                MessageBox.Show("По непонятной причине всё сломалось. Скорее всего, неправильно записан ключ", "ОШИБКА ВСЁ НЕПРАВИЛЬНО!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Polybius(TextBox input, List<List<string>> key, Mode mode = Mode.Encode)
        {
           backgroundWorker1.RunWorkerAsync(new List<object>{input.Text, key, mode});

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Polybius();

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
            Polybius();
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
            Mode mode = (Mode)list[2];
            outputText = "";

            List<List<int>> cords = new List<List<int>>();
            foreach (var c in inputText)
            {
                cords.Add(new List<int>() { key.IndexOf(key.Where(x => x.Contains(c.ToString().ToUpper())).First()),
                    key.Where(x => x.Contains(c.ToString().ToUpper())).First().IndexOf(c.ToString().ToUpper())});
            }
            List<List<int>> cords2 = new List<List<int>>();
            if (mode == Mode.Encode)
            {
                int j = 0;
                foreach (int i in new List<int>() { 0, 1 })
                {
                    for (; j < cords.Count - 1; j += 2)
                    {
                        cords2.Add(new List<int>() { cords[j][i], cords[j + 1][i] });
                    }
                    if (cords2.Count * 2 < cords.Count)
                    {
                        cords2.Add(new List<int>() { cords.Last()[0], cords.First()[1] });
                        j = 1;
                    }
                    else
                        j = 0;
                }
            }
            else
            {
                List<int> buffer = new List<int>();
                foreach (var j in cords)
                {
                    buffer.Add(j[0]);
                    buffer.Add(j[1]);
                }
                for(int i = 0, j = (buffer.Count / 2); i< (buffer.Count / 2); i++, j++)
                {
                    cords2.Add(new List<int>() { buffer[i], buffer[j] });
                }
            }


            foreach(var c in cords2)
            {
                outputText += key[c[0]][c[1]].ToString();
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
