using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            lengh.Text = $"(длина входного текста: {textInput.Text.Length})";
        }

        private void Permutation()
        {
            if (key.Text.Length == 0)
            {
                MessageBox.Show("Нужно хотя бы попробовать ввести ключ", "-_-", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var nums = key.Text.Split(',').
            Select(x => int.Parse(x)).ToList();
            if (CheckKey(nums))
                Permutation(textInput, nums, (Mode)selectedMode.SelectedIndex);
        }
        private void Permutation(TextBox input, List<int> key, Mode mode = Mode.Encode)
        {
           backgroundWorker1.RunWorkerAsync(new List<object>{input.Text, key, mode});

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Permutation();

        }

        private bool CheckKey(List<int> nums)
        {

            if (!nums.GroupBy(x => x).Any(x => x.Count() > 1))
            {
                if (!nums.Any(x => x > textInput.Text.Length && x <= 0))
                {
                    var h1 = nums.OrderBy(x => x).ToList();
                    var h2 = Enumerable.Range(1, h1.Max()).ToList();
                    if (Enumerable.SequenceEqual(h1, h2))
                        return true;
                }

            }
            MessageBox.Show("Неверно введён ключ", "ОШИБКА ВСЁ НЕПРАВИЛЬНО!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            selectedMode.SelectedIndex = (int)Mode.Encode;

            textInput.DoubleClick += TexBox_Click;
            textOutput.DoubleClick += TexBox_Click;
        }

        private void TexBox_Click(object sender, EventArgs e)
        {

            (textInput.Text, textOutput.Text) = (textOutput.Text, textInput.Text);
            Permutation();
        }

        private void textInput_TextChanged(object sender, EventArgs e)
        {
            lengh.Text = $"(длина входного текста: {textInput.Text.Length})";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            List<object> list = e.Argument as List<object>;
            string inputText = (string)list[0];
            List<int> key = list[1] as List<int>;
            Mode mode = (Mode)list[2];
            outputText = "";

            int len = inputText.Length % key.Count() == 0 ? inputText.Length : (inputText.Length / key.Count() + 1) * key.Count();            
            inputText += new string(' ', len - inputText.Length);



            for (int i = 0; i <= len-key.Count; i += key.Count)
            {
                for(int j = 0; j < key.Count; j++)
                {
                    if(mode == Mode.Encode)
                        outputText += inputText[key[j] - 1 + i];
                    else
                        outputText += inputText[key.IndexOf(j + 1) + i]; 
                }

                worker.ReportProgress((int)((double)i/ (len - key.Count) * 100));

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

            char number = e.KeyChar;

            
            if (!(number == '' || (number == ',' && key.Text.Length > 0 && key.Text.LastOrDefault() != ',') || (Char.IsDigit(number))))
            {
                e.Handled = true;
            }

        }

        private void key_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(key, "Нужно указать номера через запятую");

        }
    }
}
