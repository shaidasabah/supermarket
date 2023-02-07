using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace supermarket
{ 

    public partial class categoryForm : Form
    {
       
        public categoryForm()
        {
            InitializeComponent();
        }
        sqlconnection con = new sqlconnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\best\Documents\supermarketdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
              con.Open();
                string query = "insert into categoryTB1 values(" + TextBox_id.Text + ", '" + TextBox_name.Text + ", '" + TextBox_description.Text + "')";
                sqlcommand cmd = new sqlcommand(query, con);
                cmd.ExecuteNoQuery();
                MessageBox.Show("category added successfully");
              con.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
