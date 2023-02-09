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
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\best\Documents\supermarketdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            con.Open();
            string query = "select * from Category ";
            SqlDataAdapter adapter = new SqlDataAdapter(query,con);
            SqlCommandBuilder builder=new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            dataGridView_category.DataSource = ds.Tables[0];
            con.Close();

        } 
       
        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into category values ('" + TextBox_id.Text + "','" + TextBox_name.Text + "','" + TextBox_description.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category added successfully", "Add Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                populate();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void categoryForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void dataGridView_category_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TextBox_id.Text = dataGridView_category.SelectedRows[0].Cells[0].Value.ToString();
            TextBox_name.Text = dataGridView_category.SelectedRows[0].Cells[1].Value.ToString();
            TextBox_description.Text = dataGridView_category.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
               if(TextBox_id.Text == "")
                {
                    MessageBox.Show("Select the Category to Delete","Delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               else
                {
                    con.Open();
                    string query="Delete from Category where catId="+TextBox_id.Text+"";
                    SqlCommand command=new SqlCommand(query, con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Category Deleted Succesfully ","Delete Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    con.Close();
                   
                    populate();
                   
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
                if (TextBox_id.Text == "" || TextBox_name.Text == "" || TextBox_description.Text == "")
                {
                    MessageBox.Show("Missing Information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Open();
                    string query = "Update Category set catName='" + TextBox_name.Text +"',catDes='"+ TextBox_description.Text + "'where catId= " + TextBox_id.Text +" ";
                    SqlCommand command = new SqlCommand(query, con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Category Updated Succesfully ", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    populate();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void TextBox_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            productForm productForm = new productForm();
            productForm.Show();
            this.Hide();
        }
    }
}
