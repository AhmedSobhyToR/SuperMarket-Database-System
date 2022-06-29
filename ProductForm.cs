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

namespace DatabaseProject
{
    public partial class ProductForm : Form
    {
        DBConnect dBCon = new DBConnect();  
        public ProductForm()
        {
            InitializeComponent();
        }


        private void ProductForm_Load(object sender, EventArgs e)
        {
            getCategory();
            getTable();
        }

        private void label_product_Click(object sender, EventArgs e)
        {
            ProductForm product = new ProductForm();
            product.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            CategoryForm category = new CategoryForm();
            category.Show();
            this.Hide();
        }
        private void getCategory()
        {
            string selectQuerry = "SELECT * FROM Category";
            SqlCommand command = new SqlCommand(selectQuerry, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            ComboBox_categoryy.DataSource = table;
            ComboBox_categoryy.ValueMember = "name";
            comboBox_search.DataSource = table;
            comboBox_search.ValueMember = "name";
        }
        private void getTable()
        {
            string selectQuerry = "SELECT * FROM Product";
            SqlCommand command = new SqlCommand(selectQuerry, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView_product.DataSource = table;
        }
        private void clear()
        {
            TextBox_productID.Clear();
            TextBox_prodname.Clear();
            TextBox_price.Clear();
            TextBox_quantity.Clear();
            TextBox_availability.Clear();
            ComboBox_categoryy.SelectedIndex = 0;

        }
        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = "INSERT INTO Product VALUES("+ TextBox_productID.Text + ",'" + TextBox_prodname.Text + "'," + TextBox_price.Text + "," + TextBox_quantity.Text + ",'" + TextBox_availability.Text + "','" + ComboBox_categoryy.Text + "')";
                SqlCommand command = new SqlCommand(insertQuery, dBCon.GetCon());
                dBCon.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("Product Added Successfully","Add Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
                dBCon.CloseCon();
                getTable();
                clear();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
           }


        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                string updateQuery = "UPDATE product SET PID=" + TextBox_productID.Text + ", name='" + TextBox_prodname.Text + "', price=" + TextBox_price.Text + ", quantity=" + TextBox_quantity.Text + ", availability='" + TextBox_availability.Text + "', category='" + ComboBox_categoryy.Text + "'WHERE PID="+TextBox_productID.Text+"";
                SqlCommand command = new SqlCommand(updateQuery, dBCon.GetCon());
                dBCon.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("Product Updated Successfully", "Updated Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dBCon.CloseCon();
                getTable();
                clear();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_productID.Text == "")
                {
                    MessageBox.Show("Missing ID Information");
                }
                else
                {

                    string deleteQuery = "DELETE FROM Product WHERE PID=" + TextBox_productID.Text + "";
                    SqlCommand command = new SqlCommand(deleteQuery, dBCon.GetCon());
                    dBCon.OpenCon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted Successfully", "delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dBCon.CloseCon();
                    getTable();
                    clear();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void DataGridView_product_Click_1(object sender, EventArgs e)
        {
            TextBox_productID.Text = dataGridView_product.SelectedRows[0].Cells[0].Value.ToString();
            TextBox_prodname.Text = dataGridView_product.SelectedRows[0].Cells[1].Value.ToString();
            TextBox_price.Text = dataGridView_product.SelectedRows[0].Cells[2].Value.ToString();
            TextBox_quantity.Text = dataGridView_product.SelectedRows[0].Cells[3].Value.ToString();
            TextBox_availability.Text = dataGridView_product.SelectedRows[0].Cells[4].Value.ToString();
            ComboBox_categoryy.SelectedValue = dataGridView_product.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            getTable();
        }

        private void comboBox_search_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectQuerry = "SELECT * FROM Product WHERE category='" +ComboBox_categoryy.SelectedValue.ToString()+"'";
            SqlCommand command = new SqlCommand(selectQuerry, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView_product.DataSource = table;
        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Red;
        }
        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Black;
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void button_logout_MouseEnter(object sender, EventArgs e)
        {
            button_logout.ForeColor = Color.Red;
        }
        private void button_logout_MouseLeave(object sender, EventArgs e)
        {
            button_logout.ForeColor = Color.Black;
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void label_settings_Click(object sender, EventArgs e)
        {
            CustomerForm cus = new CustomerForm();
            cus.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            DiscountForm D = new DiscountForm();
            D.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            StockForm st = new StockForm();
            st.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
