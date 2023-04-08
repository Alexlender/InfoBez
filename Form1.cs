using InfoBez.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;

namespace InfoBez
{

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

            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 0);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipPoint);
            
            status.Text = $"Текущий порт: {((IPEndPoint)socket.LocalEndPoint).Port}";
            Task.Run(() => ConnectionHandlerAsync(socket));
        }

        private async Task ConnectionHandlerAsync(Socket socket)
        {
            while (true)
            {
                socket.Listen(1);
                Socket client = await socket.AcceptAsync();
                // получаем адрес клиента
                var result = MessageBox.Show($"Принято входящее подключение\nIP {((IPEndPoint)client.RemoteEndPoint).Address}",
                    "ОБНАРУЖЕНА ПОПЫТКА ПРОНИКНОВЕНИЯ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.Cancel)
                    client.Close();
                else
                {
                    AddLog($"Выполнено подключение к {((IPEndPoint)client.RemoteEndPoint).Address}");
                    Logic(client);
                }
            }

        }

        private async Task Logic(Socket socket)
        {
            try
            {
                long key1 = long.Parse(openKey.Text);
                long key2 = long.Parse(closeKey.Text);
                await Logic(socket, key1, key2);
            }
            catch
            {
                MessageBox.Show("Вместо ключей написан мусор, всё сломалось!", "Что-то пошло не так!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Logic(Socket socket, long openKey, long closeKey)
        {
            var SendBytes = BitConverter.GetBytes(openKey);
            await socket.SendAsync(new ArraySegment<byte>(SendBytes, 0, SendBytes.Length), SocketFlags.None);
            var response = new byte[512];

            socket.Receive(response);
            int anotherKey = BitConverter.ToInt32(response, 0);
            AddLog($"Открытый ключ соседа: {anotherKey}\n");
            if(anotherKey == openKey)
            {
                AddLog($"Ключи совпадают, всё хорошо\n");
            }
            else
            {
                AddLog($"Ключи разные, щас их перемножим и найдём ближайшее большее просто число\n");
                openKey = KeyGen(anotherKey * openKey).Result;
                AddLog($"Найденный ключ: {openKey}\n");
            }

        }


        private async Task<long> KeyGen(long row)
        {

            for (int i = 0; !(await CheckPrime(row)); i++)
                row += i;
            return row;
        }



        /// <returns>True if x is prime</returns>
        private async Task<bool> CheckPrime(long x)
        {
            return await Task.Run(() =>
            {
                long sqrt = (int)Math.Sqrt(x);
                if (sqrt * sqrt == x)
                    return false;
                for (long i = 2; i < sqrt; i++)
                    if (x % i == 0)
                        return false;
                return true;
            });

            
        }

        private void AddLog(string text)
        {
            textOutput.Text += text + Environment.NewLine;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            genP();
            genK();

        }
        private Socket Connect(IPEndPoint iPEndPoint)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // пытаемся подключиться используя URL-адрес и порт
            var result = socket.ConnectAsync(iPEndPoint);

            result.Wait(5000);

            if (socket.Connected)
            {
                return socket;
            }
            else
            {
                socket.Close();
                throw new SocketException();
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                var data = CheckFields(ip.Text, port.Text);
                AddLog($"Подключение к {data.Address}:{data.Port}...\n");
                Socket s = Connect(data);
                AddLog("Подключение выполнено\n");
                Logic(s);
            }
            catch (SocketException)
            {
                MessageBox.Show("Не удалось подключиться :(", "Что-то пошло не так!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AddLog("Подключение отклонено\n");
            }
            catch
            {
                MessageBox.Show("Айпи или порт указаны неверно!", "ОШИБКА ВСЁ НЕПРАВИЛЬНО!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AddLog("Подключение отклонено\n");
            }



        }

        

        private IPEndPoint CheckFields(string ip, string port)
        {

            IPAddress address = IPAddress.Parse(ip);
            int portint = int.Parse(port);
            return new IPEndPoint(address, portint);

        }

    

        private int CustomHash(int x)
        {
            return 13 ^ (x ^ 7) % 99999;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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


        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void genPublic_Click(object sender, EventArgs e)
        {
            genP();
        }

        private void genP()
        {
            var rand = new Random();
            openKey.Text = KeyGen(rand.Next()).Result.ToString();
        }

        private void genKey_Click(object sender, EventArgs e)
        {
            genK();
        }

        private void genK()
        {
            var rand = new Random();
            closeKey.Text = rand.Next(0,10000).ToString();
        }

    }
}
