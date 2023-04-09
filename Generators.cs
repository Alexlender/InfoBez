using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void gen_Click(object sender, EventArgs e)
        {
            ((Button)sender).Parent. = "Лох";
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
