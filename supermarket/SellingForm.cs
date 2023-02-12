using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace supermarket
{
    public partial class SellingForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\best\Documents\supermarketdb.mdf;Integrated Security=True;Connect Timeout=30");
        //DGVPrinterHelper dGVPrinter = new DGVPrinterHelper();
        public SellingForm()
        {
            InitializeComponent();
        }
      
        private void getCategory()
        {

            string query = "select * from Category ";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            comboBox_category.DataSource = dt;
            comboBox_category.ValueMember = "catName";
           

        }
        private void getTable()
        {

            string query = "select prodname,prodPrice from product ";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            dataGridView_product.DataSource = dt;
        }
        private void getsetTable()
        {

            string query = "select * from bill";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            dataGridView_selling.DataSource = dt;
        }
        private void SellingForm_Load(object sender, EventArgs e)
        {
            label_Date.Text = DateTime.Today.ToShortDateString  ();
            getCategory();
            getTable();
            getsetTable();
          
            label_sellerName.Text = login.sellerName;
        }

       
            int grandTotal=0,n=0;

        private void dataGridView_product_Click(object sender, EventArgs e)
        {
            TextBox_name.Text = dataGridView_product.SelectedRows[0].Cells[0].Value.ToString();
            TextBox_price.Text = dataGridView_product.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                

                string query = "insert into bill values ('" + TextBox_id.Text + "','" + label_sellerName.Text + "','" + label_Date.Text + "','" + grandTotal.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Order added successfully", "Order Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();
                getsetTable();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog()==DialogResult.OK)
            { 
                printDocument1.Print();
            }
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Red;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Goldenrod;
        }

        private void button_logout_MouseEnter(object sender, EventArgs e)
        {
            button_logout.ForeColor = Color.Red;
        }

        private void button_logout_MouseLeave(object sender, EventArgs e)
        {
            button_logout.ForeColor= Color.Goldenrod;
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            getTable();
        }

        private void comboBox_category_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string que = "select prodname,prodQty from product where prodCat='" + comboBox_category.SelectedValue.ToString()+"'";
            SqlCommand command = new SqlCommand(que, con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            dataGridView_product.DataSource = dt;
        }
      

        private void TextBox_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Supermarket", new Font("Constantia", 30, FontStyle.Bold), Brushes.Red, new Point(230));
            e.Graphics.DrawString("Bill ID:"+dataGridView_selling.SelectedRows[0].Cells[0].Value.ToString(),new Font("Constantia", 25, FontStyle.Bold) ,Brushes.Blue, new Point(100,70));
            e.Graphics.DrawString("Seller Name:" + dataGridView_selling.SelectedRows[0].Cells[1].Value.ToString(), new Font("Constantia", 25, FontStyle.Bold), Brushes.Blue, new Point(100, 100));
            e.Graphics.DrawString("Date:" + dataGridView_selling.SelectedRows[0].Cells[2].Value.ToString(), new Font("Constantia", 25, FontStyle.Bold), Brushes.Blue, new Point(100, 130));
            e.Graphics.DrawString("Total Amount:" + dataGridView_selling.SelectedRows[0].Cells[3].Value.ToString(), new Font("Constantia", 25, FontStyle.Bold), Brushes.Blue, new Point(100, 160));
            



        }

        private void button_order_Click(object sender, EventArgs e)
        {
            if(TextBox_name.Text==""||TextBox_qty.Text=="")
            {
                MessageBox.Show("Missing Information","Information Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }
            else
            {
                int total = Convert.ToInt32(TextBox_price.Text) * Convert.ToInt32(TextBox_qty.Text);
                DataGridViewRow addrow = new DataGridViewRow();
                addrow.CreateCells(DataGridView_orde);
                addrow.Cells[0].Value = n+1;
                addrow.Cells[1].Value = TextBox_name.Text;
                addrow.Cells[2].Value = TextBox_price.Text;
                addrow.Cells[3].Value = TextBox_qty.Text;
                addrow.Cells[4].Value = total;
                DataGridView_orde.Rows.Add(addrow);
                grandTotal += total;
                label_amount.Text =" " +grandTotal;
            }
            


        }
    }
}
