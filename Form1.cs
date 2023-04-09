﻿using InfoBez.Properties;
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
                Socket client = await socket.AcceptAsync();
                // получаем адрес клиента
                var result = MessageBox.Show($"Принято входящее подключение\nIP {((IPEndPoint)client.RemoteEndPoint).Address}",
                    "ОБНАРУЖЕНА ПОПЫТКА ПРОНИКНОВЕНИЯ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.Cancel)
                    client.Disconnect(true);
                else
                {
                    AddLog($"Выполнено подключение к {((IPEndPoint)client.RemoteEndPoint).Address}");
                    Logic(client, new List<BigInteger>());
                }
            }

        }

        private async Task Logic(Socket socket, List<BigInteger> list)
        {
            try
            {
                await LogicAsync(socket, list[0], list[1], list[2], list[3]);
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

        private async Task LogicAsync(Socket socket, BigInteger q, BigInteger p, BigInteger d, BigInteger e)
        {
            await Task.Run(() =>
            {
                /*socket.SendAsync(new ArraySegment<byte>(openKey.ToByteArray()), SocketFlags.None);

                var response = new byte[512];
                socket.Receive(response);
                BigInteger anotherKey = new BigInteger(response);
                AddLog($"Общий открытый ключ у соседа: {anotherKey}\n");
                if (anotherKey == openKey)
                {
                    AddLog($"Ключи совпадают, всё хорошо\n");
                }
                else
                {
                    AddLog($"Ключи разные, щас их перемножим и найдём ближайшее большее просто число\n");
                    openKey = KeyGen(anotherKey * openKey);
                    AddLog($"Найденный ключ: {openKey}\n");
                }
                var a = new BigInteger(CustomHash(closeKey, openKey));
                AddLog($"Мой открытый ключ: {a}\n");
                socket.SendAsync(new ArraySegment<byte>(a.ToByteArray()), SocketFlags.None);

                var response2 = new byte[512];
                socket.Receive(response2);
                BigInteger b = new BigInteger(response2);
                AddLog($"Открытый ключ соседа: {b}\n");

                var key = new BigInteger(CustomHash(a, b));
                AddLog($"Получился ключ: {key}\n");
                socket.Disconnect(true);
                AddLog($"Подключение закрыто\n\n");*/

            });

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
            if (!File.Exists("Keys.dat"))
                textBoxKey.Text = "Файла ещё нет :(";
            else
                textBoxKey.Text = Path.Combine(Application.StartupPath, "Keys.dat");

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
                Logic(s, new List<BigInteger>());
            }
            catch (SocketException)
            {
                MessageBox.Show("Не удалось подключиться :(", "Что-то пошло не так!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AddLog("Подключение отклонено\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКА ВСЁ НЕПРАВИЛЬНО!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            throw null;
        }
        private long CustomHash(BigInteger x, BigInteger p)
        {
            return (int)((p ^ x) % 2147483647);
        }

        /*private async void Work(Button button)
        {
            isWorking = true;
            await Task.Run(async () =>
            {

                for (int i = 0; isWorking; i = i == 3 ? 0 : i + 1)
                {
                    button.Text = "Думаю" + new string('.', i);
                    await Task.Delay(400);
                }

                button.Text = "Генерировать";


            });
        }*/

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

        }
    }
}
