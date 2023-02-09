using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarket
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor= Color.Red;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.RosyBrown;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor= Color.Red;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.RosyBrown;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
