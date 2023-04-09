using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoBez
{
    public partial class Generators : Form
    {
        public Generators()
        {
            InitializeComponent();
        }

        private async void gen_Click(object sender, EventArgs e)
        {
            uint num = (uint)((Button)sender).Parent.Controls.OfType<NumericUpDown>().First().Value;
            var texBox = ((Button)sender).Parent.Controls.OfType<TextBox>().First();

            await Task.Run(() => {
                texBox.Text = KeyGen(Rand(num)).ToString();
            });
        }


        private BigInteger Rand(uint len)
        {
            var rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[len];
            rng.GetBytes(bytes);

            return BigInteger.Abs(new BigInteger(bytes));
        }
        private BigInteger KeyGen(BigInteger row)
        {
            if (row.IsEven)
                row += 1;
            for (int i = 0; !Miller.isPrime(row); i += 2)
                row += i;
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
                MessageBox.Show("Котика не будет(", "Эээх", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
        }
    }
}
