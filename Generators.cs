using InfoBez.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;

namespace InfoBez
{
    public partial class Generators : Form
    {

        public bool genAll = false;

        public Generators()
        {
            InitializeComponent();

            //key.Text = Path.Combine(Application.StartupPath, "Playfair.key");
        }


        //генерирует простые числа p и q
        private async void gen_Click(object sender, EventArgs e)
        {
            uint num = (uint)((System.Windows.Forms.Button)sender).Parent.Controls.OfType<NumericUpDown>().First().Value;
            var texBox = ((System.Windows.Forms.Button)sender).Parent.Controls.OfType<TextBox>().First();

            await Task.Run(() =>
            {
                texBox.Text = KeyGen(Rand(num), texBox).ToString();
            });

            if (textBoxP.ForeColor != Color.Red && textBoxQ.ForeColor != Color.Red && genAll)
                genNN.PerformClick();



        }



        private BigInteger Rand(uint len)
        {
            var rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[len];
            rng.GetBytes(bytes);

            return BigInteger.Abs(new BigInteger(bytes));
        }


        private BigInteger KeyGen(BigInteger row, TextBox textBox)
        {
            var color = textBox.ForeColor;
            textBox.ForeColor = Color.Red;
            if (row.IsEven)
                row += 1;
            for (int i = 0; !Miller.isPrime(row); i += 2)
            {
                textBox.Text = row.ToString();
                row += i;
            }
            textBox.ForeColor = color;
            return row;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
            }
            catch
            {
                MessageBox.Show("Котика не будет(", "Эээх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            genAll = true;

            foreach (var b in new List<Button>() { genP, genQ })
                b.PerformClick();

        }



        private void Save(object sender, EventArgs e)
        {
            using (var stream = File.Open("key", FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    foreach (var tb in new List<TextBox>() { textBoxD, textBoxNN })
                    {
                        writer.Write(tb.Text);
                    }
                }
            }

            using (var stream = File.Open("key.pub", FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    foreach (var tb in new List<TextBox>() { textBoxE, textBoxNN })
                    {
                        writer.Write(tb.Text);
                    }
                }
            }

        }

        private void Load(object sender, EventArgs e)
        {
            try
            {
                using (var stream = File.Open("key.pub", FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        foreach (var tb in new List<TextBox>() { textBoxE, textBoxNN })
                        {
                            tb.Text = reader.ReadString();
                        }
                    }
                }

                using (var stream = File.Open("key", FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        textBoxD.Text = reader.ReadString();

                        string newS = reader.ReadString();

                        if (textBoxNN.Text != newS)
                            throw new ArgumentException("Число n в файлах ключей key и key.pub явно не совпадает");

                        textBoxNN.Text = newS;

                    }
                }


            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message, @"¯\_(ツ)_/¯", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Нет", @"¯\_(ツ)_/¯", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox_SizeChanged(object sender, EventArgs e)
        {
            var texBox = ((GroupBox)sender).Controls.OfType<TextBox>().First();
            texBox.Size = new Size(texBox.Width, ((GroupBox)sender).Size.Height-60);
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void genN_Click(object sender, EventArgs e)
        {
            try
            {
                BigInteger p = BigInteger.Parse(textBoxP.Text);
                BigInteger q = BigInteger.Parse(textBoxQ.Text);

                textBoxN.Text = ((p - 1) * (q - 1)).ToString();

            }
            catch (FormatException)
            {
                MessageBox.Show("Кажется, в полях p и q записано что-то не то", @"Что-то не так...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(genAll)
                genE.PerformClick();

        }

        private void genE_Click(object sender, EventArgs e)
        {
            try
            {
                BigInteger n = BigInteger.Parse(textBoxN.Text);

                if(n < 65537)
                    textBoxE.Text = 3.ToString();
                else
                    textBoxE.Text = 65537.ToString();

            }
            catch (FormatException)
            {
                MessageBox.Show("Кажется, в полe n.. армяне в нарды играют", @"Что-то не так...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (genAll)
                genD.PerformClick();
            

        }

        private void textBoxE_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Да, она задаётся статически. Если хочется, можно вручную переписать. Вопросы?", @"ಠ_ಠ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void genD_Click(object sender, EventArgs ea)
        {
            try
            {
                BigInteger n = BigInteger.Parse(textBoxN.Text);
                BigInteger e = BigInteger.Parse(textBoxE.Text);

                BigInteger k = Rand((uint)lenD.Value);

                BigInteger d;
                BigInteger c;
                do
                {
                    k += 1;
                    d = (k * n + 1) / e;
                    c = (k * n + 1) % e;

                }
                while (c != 0);
                textBoxD.Text = d.ToString();


            }
            catch (FormatException)
            {
                MessageBox.Show("Не надо нажимать на эту кнопку раньше времени", @"Что-то не так...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(genAll)
                genAll = false;

        }

        private void genNN_Click(object sender, EventArgs e)
        {
            try
            {
                BigInteger p = BigInteger.Parse(textBoxP.Text);
                BigInteger q = BigInteger.Parse(textBoxQ.Text);

                textBoxNN.Text = (p * q).ToString();

            }
            catch (FormatException)
            {
                MessageBox.Show("Кажется, в полях p и q записано что-то не то", @"Что-то не так...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (genAll)
                genN.PerformClick();
        }

    }
}
