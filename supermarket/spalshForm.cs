using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarket
{
    public partial class spalshForm : Form
    {
        public spalshForm()
        {
            InitializeComponent();
        }

        private void spalshForm_Load(object sender, EventArgs e)
        {
            timer1.Start(); 
        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 2;
            CircleProgressBar.Value=startpoint;
            if (CircleProgressBar.Value == 100)
            {
                CircleProgressBar.Value = 100;
                timer1.Stop();
               login form1 = new login();
                this.Hide();
                form1.Show();

            }
        }
    }
}
