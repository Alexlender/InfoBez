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
using System.Numerics;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using System.Reflection.Emit;
using System.Reflection;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace InfoBez
{

    public partial class Form1 : Form
    {
        private Socket s;
        public Form1()
        {
            InitializeComponent();

            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 0);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipPoint);
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            status.Text = $"Текущий порт: {((IPEndPoint)socket.LocalEndPoint).Port}";
            Task.Run(() => ConnectionHandlerAsync(socket));
        }

        private async Task ConnectionHandlerAsync(Socket socket)
        {
            while (true)
            {
                socket.Listen(1);
                AddLog($"Жду подключений...");
                Socket client = await socket.AcceptAsync();
                // получаем адрес клиента
                var result = MessageBox.Show($"Принято входящее подключение\nIP {((IPEndPoint)client.RemoteEndPoint).Address}",
                    "ОБНАРУЖЕНА ПОПЫТКА ПРОНИКНОВЕНИЯ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.Cancel)
                    client.Disconnect(true);
                else
                {
                    AddLog($"Выполнено подключение к {((IPEndPoint)client.RemoteEndPoint).Address}");
                    await LogicSecondAsync(client);
                }
            }

        }

        private async Task LogicSecondAsync(Socket client)
        {
            await Task.Run(() =>
            {

                client.SendAsync(new ArraySegment<byte>(new byte[] { 1 }), SocketFlags.None);

                var response = new byte[2048];
                client.Receive(response);
                BigInteger n = new BigInteger(response);

                AddLog($"Получено число n = {n}\n");

                int blockSize =  BytesFromBigInt(n).Length;

                client.SendAsync(new ArraySegment<byte>((n % 8).ToByteArray()), SocketFlags.None);


                var response2 = new byte[2048];
                client.Receive(response2);
                BigInteger e = new BigInteger(response2);

                AddLog($"Получено число e = {e}\n");

                client.SendAsync(new ArraySegment<byte>((e % 8).ToByteArray()), SocketFlags.None);

                var list = ReadFile(textBoxFile.Text, blockSize - 1);
                //var list = new List<byte[]>();
                AddLog($"Подготовлен файл из {list.Count} блоков\n");

                client.SendAsync(new ArraySegment<byte>((new BigInteger(list.Count)).ToByteArray()), SocketFlags.None);
                client.Receive(new byte[16]);


                foreach (var s in list)
                {
                    //var s = new BigInteger(l);
                    //AddLog($"{s} -> {BigInteger.ModPow(s, e, n)} ({BytesFromBigInt(BigInteger.ModPow(s, e, n)).Length} B)\n");
                    client.SendAsync(new ArraySegment<byte>(BytesFromBigInt(BigInteger.ModPow(s, e, n))), SocketFlags.None);
                    //AddLog($"{BigInteger.ModPow(s, e, n)}\n");
                    client.Receive(new byte[16]);
                }
                AddLog($"Много байтов файла отправлено ({list.Count} блоков по {blockSize} байт)\n");
                client.Disconnect(true);
                AddLog($"Подключение закрыто\n\n");
            });
        }

        private async Task Logic(Socket socket)
        {
            try
            {
                List<BigInteger> list = Read(textBoxKey.Text);
                BigInteger d = list[0];
                BigInteger n = list[1];

                list = Read(textBoxOpenKey.Text);
                BigInteger e = list[0];

                BigInteger newN = list[1];
                if (newN != n)
                    throw new Exception("Числа N в фалах не совпадают");


                await LogicAsync(socket, n, d, e);

            }
            catch (FormatException)
            {
                MessageBox.Show("Вместо ключей написан мусор, всё сломалось!", "Что-то пошло не так!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "О Нет!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LogicAsync(Socket socket, BigInteger n, BigInteger d, BigInteger e)
        {
            await Task.Run(() =>
            {

                int blockSize = n.ToByteArray().Where(t => !(t == (byte)0 && t == n.ToByteArray().Last())).ToArray().Length;

                var response = new byte[1];
                socket.Receive(response);

                socket.SendAsync(new ArraySegment<byte>(n.ToByteArray()), SocketFlags.None);
                AddLog($"Отправлено число n = {n}\n");

                response = new byte[16];
                socket.Receive(response);
                BigInteger answer = new BigInteger(response);
                if (answer != n % 8)
                {
                    AddLog($"ОШИБКА\n");
                }



                socket.SendAsync(new ArraySegment<byte>(e.ToByteArray()), SocketFlags.None);
                AddLog($"Отправлено число e = {e}\n");

                response = new byte[16];
                socket.Receive(response);
                answer = new BigInteger(response);
                if (answer != e % 8)
                {
                    AddLog($"ОШИБКА\n");
                }


                var list = new List<BigInteger>();

                response = new byte[4096];
                socket.Receive(response);
                var count = new BigInteger(response);
                socket.SendAsync(new ArraySegment<byte>(new byte[] { 1 }), SocketFlags.None);
                AddLog($"Будет получено {count} блоков текста по {blockSize} байт\n");


                for (int i = 0; i < count; i++)
                {
                    response = new byte[blockSize];
                    socket.Receive(response);
                    var s = new BigInteger(response.ToList().Append((byte)0).ToArray());
                    list.Add(BigInteger.ModPow(s, d, n));
                    //AddLog($"{s} -> {BigInteger.ModPow(s, d, n)}");
                    socket.SendAsync(new ArraySegment<byte>(e.ToByteArray()), SocketFlags.None);
                }



                AddLog($"Файл загружен в {LoadFile(list)}\n");

                socket.Disconnect(true);
                AddLog($"Подключение закрыто\n\n");

            });

        }

        private List<BigInteger> ReadFile(string path, int blockSize)
        {
            var list = new List<BigInteger>();
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream, Encoding.Unicode, false))
                {
                    while (stream.Position < stream.Length)
                        list.Add(new BigInteger((reader.ReadBytes(blockSize)).ToList().Append((byte)0).ToArray()));
                }
            }

            return list;

        }

        private string LoadFile(List<BigInteger> list)
        {

            using (var stream = File.Open(textBoxFile.Text, FileMode.Truncate, FileAccess.Write))
            {
                using (var writer = new BinaryWriter(stream, Encoding.Unicode, false))
                {
                    foreach (var l in list)
                        writer.Write(BytesFromBigInt(l)); 
                }
            }

            return textBoxFile.Text;

        }


        private byte[] BytesFromBigInt(BigInteger bg)
        {

            return bg.ToByteArray().Where(t => !(t == (byte)0 && t == bg.ToByteArray().Last())).ToArray(); //эта страшная штука убирает последний нулевой байт (знаковый (да, тут LE))

        }

        private void AddLog(string text)
        {
            textOutput.Text += text + Environment.NewLine;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KeyFileCheck();

        }

        private void KeyFileCheck()
        {
            if (!File.Exists("key.pub"))
                textBoxOpenKey.Text = "Файла ещё нет :(";
            else
                textBoxOpenKey.Text = Path.Combine(Application.StartupPath, "key.pub");

            if (!File.Exists("key"))
                textBoxKey.Text = "Файла ещё нет :(";
            else
                textBoxKey.Text = Path.Combine(Application.StartupPath, "key");


            if (!File.Exists("File.dat"))
                File.Create("File.dat");
            else
                textBoxFile.Text = Path.Combine(Application.StartupPath, "File.dat");

        }

        private void Connect(IPEndPoint iPEndPoint)
        {
            // пытаемся подключиться используя URL-адрес и порт
            var result = s.ConnectAsync(iPEndPoint);

            result.Wait(5000);

            if (!s.Connected)
            {
                throw new SocketException();
            }

        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                if (s.Connected)
                {
                    MessageBox.Show("Подключение уже выполнено", "ಠ_ಠ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var data = CheckFields(ip.Text, port.Text);
                AddLog($"Подключение к {data.Address}:{data.Port}...\n");
                Connect(data);
                AddLog("Подключение выполнено\n");
                Logic(s);
            }
            catch (SocketException)
            {
                MessageBox.Show("Не удалось подключиться :(", "Что-то пошло не так!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AddLog("Подключение отклонено\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.Data, "ОШИБКА ВСЁ НЕПРАВИЛЬНО!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AddLog("Подключение отклонено\n");
            }
        }


        private IPEndPoint CheckFields(string ip, string port)
        {

            IPAddress address = IPAddress.Parse(ip);
            int portint = int.Parse(port);
            return new IPEndPoint(address, portint);

        }


        private List<BigInteger> Read(string filename)
        {
            var list = new List<BigInteger>();
            using (var stream = File.Open(filename, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                {
                    for (int i = 0; i < 2; i++) //да, тут хардкодом забито 2. Мне очень лень делать считывание до конца файла
                        list.Add(BigInteger.Parse(reader.ReadString()));
                }
            }
            return list;
        }


        private void textOutput_Clear(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Отчистить лог?",
                    "УДАЛИТЬ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
                textOutput.Text = "";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog();
            opfd.Multiselect = false;
            opfd.InitialDirectory = Application.StartupPath;
            if (opfd.ShowDialog(this) == DialogResult.OK)
            {
                ((Control)sender).Text = opfd.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var gen = new Generators();
            gen.Show();
            gen.FormClosed += (s, ec) =>
            {
                KeyFileCheck();
            };
        }

        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void edit_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c notepad \"{textBoxFile.Text}\"",
                WindowStyle = ProcessWindowStyle.Hidden
            });
        }


      
    }
}
