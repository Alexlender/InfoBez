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
        }

        private void Cesar(TextBox input, TextBox output, int key, Mode mode = Mode.Encode)
        {
           backgroundWorker1.RunWorkerAsync(new List<object>{ input.Text, key, mode});

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cesar(textInput, textOutput, (int)keyInput.Value, (Mode)selectedMode.SelectedIndex);
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
        }

        private void textInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            //Cesar(textInput, textOutput, (int)keyInput.Value, (Mode)selectedMode.SelectedIndex);
            List<object> list = e.Argument as List<object>;
            string inputText = (string)list[0];
            int key = (int)list[1];
            Mode mode = (Mode)list[2];
            outputText = "";
            for (int i = 0; i<inputText.Length;i++)
            {
                char c = inputText[i];
                outputText += (char)(c + key * (mode == Mode.Encode ? 1 : -1));
                worker.ReportProgress((int)((double)i/inputText.Length*100));

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
    }
}
