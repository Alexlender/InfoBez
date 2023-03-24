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

            textInput.DoubleClick += TexBox_Click;
            textOutput.DoubleClick += TexBox_Click;
            keyLen.Value = key.Text.Length;

        }
        private void XOR(TextBox input, TextBox key)
        {
           backgroundWorker1.RunWorkerAsync(new List<object>{input.Text, key.Text});

        }

        private void button1_Click(object sender, EventArgs e)
        {
            XOR(textInput, key);

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
            XOR(textInput, key);
        }

        private void textInput_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            List<object> list = e.Argument as List<object>;
            string inputText = (string)list[0];
            string key = (string)list[1];

            outputText = "";

            int len;
            if (inputText.Length > key.Length)
                len = key.Length * (inputText.Length / key.Length + (inputText.Length % key.Length > 0 ? 1 : 0));
            else
                len = (int)key.Length;

            inputText += new string(' ', len - inputText.Length);
            key = String.Concat(Enumerable.Repeat(key, len / key.Length));

            for(int i = 0; i< len; i++)
            {
                outputText += (char)(inputText[i] ^ key[i]);
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
            keyLen.Value = key.Text.Length;
        }

        private void edit_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int len = (int)keyLen.Value;
            key.Text = "";
            for (int i = 0; i < len; i++)
                key.Text += (char)rand.Next(0x0410, 0x44F);
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
