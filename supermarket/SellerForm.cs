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


namespace supermarket
{
    public partial class SellerForm : Form
    {
        public SellerForm()
        {
            InitializeComponent();
        }

        private void dataGridView_product_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TextBoxSeller_id.Text = dataGridView_Seller.SelectedRows[0].Cells[0].Value.ToString();
            TextBoxSeller_name.Text = dataGridView_Seller.SelectedRows[0].Cells[0].Value.ToString();
            TextBoxSeller_age.Text = dataGridView_Seller.SelectedRows[0].Cells[0].Value.ToString();
            TextBoxSeller_phone.Text = dataGridView_Seller.SelectedRows[0].Cells[0].Value.ToString();
            textBoxSeller_password.Text = dataGridView_Seller.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\best\Documents\supermarketdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void getTable()
        {

            string query = "select * from seller ";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            dataGridView_Seller.DataSource = dt;
        }
        private void clear()
        {
            TextBoxSeller_id.Clear();
            TextBoxSeller_name.Clear();
            TextBoxSeller_age.Clear();
            TextBoxSeller_phone.Clear();
            textBoxSeller_password.Clear();
        } 
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into Seller values ('" + TextBoxSeller_id.Text + "','" + TextBoxSeller_name.Text + "','" + TextBoxSeller_age.Text + "','" + TextBoxSeller_phone.Text + "','" + textBoxSeller_password.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Seller added successfully", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                getTable();
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SellerForm_Load(object sender, EventArgs e)
        {
            getTable();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBoxSeller_id.Text == "" || TextBoxSeller_name.Text == "" || TextBoxSeller_age.Text == "" || TextBoxSeller_phone.Text == ""||textBoxSeller_password.Text=="")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Open();
                    string query = "Update seller set SellerName='" + TextBoxSeller_name.Text + "',SellerAge='" + TextBoxSeller_age.Text + "',SellerPhone='" + TextBoxSeller_phone.Text + "',SellerPass='" + textBoxSeller_password.Text + "'where SellerId=" + TextBoxSeller_id.Text + "";
                    SqlCommand command = new SqlCommand(query, con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Seller Updated Succesfully ", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dataGridView_Seller_Click(object sender, EventArgs e)
        {

            TextBoxSeller_id.Text = dataGridView_Seller.SelectedRows[0].Cells[0].Value.ToString();
            TextBoxSeller_name.Text = dataGridView_Seller.SelectedRows[0].Cells[1].Value.ToString();
            TextBoxSeller_age.Text = dataGridView_Seller.SelectedRows[0].Cells[2].Value.ToString();
            TextBoxSeller_phone.Text = dataGridView_Seller.SelectedRows[0].Cells[3].Value.ToString();
            textBoxSeller_password.Text = dataGridView_Seller.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBoxSeller_id.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if ((MessageBox.Show("Are you sure to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                   { con.Open();
                        string query = "Delete from Seller where SellerId=" + TextBoxSeller_id.Text + "";
                        SqlCommand command = new SqlCommand(query, con);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Seller Deleted Succesfully ", "Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        getTable();
                        clear();
                   }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            login login= new login();
            login.Show();
            this.Hide();
        }

        private void button_logout_MouseEnter(object sender, EventArgs e)
        {
            button_logout.ForeColor = Color.Red;
        }

        private void button_logout_MouseLeave(object sender, EventArgs e)
        {
            button_logout.ForeColor = Color.Goldenrod;
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

        private void button_seller_Click(object sender, EventArgs e)
        {
            productForm productForm = new productForm();
            productForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            categoryForm categoryForm  = new categoryForm();
            categoryForm.Show();
            this.Hide();
        }
    }
}
