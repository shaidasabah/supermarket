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
    public partial class productForm : Form
    {
        public productForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void fillcombo()
        {
           
            string query = "select * from Category ";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataAdapter sqlDataAdapter=new SqlDataAdapter(command);
           DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            comboBox_category.DataSource = dt;
            comboBox_category.ValueMember = "catName";
            comboBox_category.DataSource = dt;
            comboBox_category.ValueMember = "catName";
        
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\best\Documents\supermarketdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void productForm_Load(object sender, EventArgs e)
        {
            fillcombo();
        
        }

        private void comboBox_category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            categoryForm categoryForm = new categoryForm();
            categoryForm.Show();
            this.Hide();
        }
        private void getTable()
        {
           
            string query = "select * from product ";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            dataGridView_product.DataSource = dt;
        }
        private void clear()
        {
            TextBox_id.Clear();
            TextBox_name.Clear();
            TextBox_price.Clear();
            TextBox_qty.Clear();
            comboBox_category.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                string query = "insert into product values ('" + TextBox_id.Text + "','" + TextBox_name.Text + "','" +TextBox_price.Text +"','" + TextBox_qty.Text +"','"+comboBox_category.Text+"')";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product added successfully", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                con.Close();
                getTable();
                clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_product_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView_product_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_id.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Open();
                    string query = "Delete from Product where productId=" + TextBox_id.Text + "";
                    SqlCommand command = new SqlCommand(query, con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted Succesfully ", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    getTable();
                    clear();
                  

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_id.Text == "" || TextBox_name.Text == "" || TextBox_qty.Text == ""||TextBox_price.Text=="")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Open();
                    string query = "Update Product set prodname='" + TextBox_name.Text + "',prodPrice=" + TextBox_price.Text + ",prodQty=" + TextBox_qty.Text + ",prodCat='" + comboBox_category.Text + "'where productId=" + TextBox_id.Text + "";
                    SqlCommand command = new SqlCommand(query, con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Product Updated Succesfully ", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    getTable();
                    clear();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_product_Click_1(object sender, EventArgs e)
        {
            TextBox_id.Text = dataGridView_product.SelectedRows[0].Cells[0].Value.ToString();
            TextBox_name.Text = dataGridView_product.SelectedRows[0].Cells[1].Value.ToString();
            TextBox_price.Text = dataGridView_product.SelectedRows[0].Cells[2].Value.ToString();
            TextBox_qty.Text = dataGridView_product.SelectedRows[0].Cells[3].Value.ToString();
            comboBox_category.Text = dataGridView_product.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getTable();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

            string que = "select * from product where prodCat='"+comboBox1.Text+"'";
            SqlCommand command = new SqlCommand(que, con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            dataGridView_product.DataSource = dt;
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
            button_logout.ForeColor = Color.Goldenrod;
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void button_seller_Click(object sender, EventArgs e)
        {
            SellerForm sellerForm = new SellerForm();
            sellerForm.Show();
            this.Hide();
        }
    }
}
