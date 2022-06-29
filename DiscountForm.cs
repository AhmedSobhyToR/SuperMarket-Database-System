using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DatabaseProject
{
    public partial class DiscountForm : Form
    {
        DBConnect dBCon = new DBConnect();

        public DiscountForm()
        {
            InitializeComponent();
        }

        private void label_product_Click(object sender, EventArgs e)
        {
            ProductForm product = new ProductForm();
            product.Show();
            this.Hide();
        }

        private void label_category_Click(object sender, EventArgs e)
        {
            CategoryForm category = new CategoryForm();
            category.Show();
            this.Hide();
        }

        private void label_settings_Click(object sender, EventArgs e)
        {
            CustomerForm cus = new CustomerForm();
            cus.Show();
            this.Hide();
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }
        private void getTable()
        {
            string selectQuerry = "SELECT * FROM Customer";
            SqlCommand command = new SqlCommand(selectQuerry, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridView_discount.DataSource = table;
        }

        private void DiscountForm_Load(object sender, EventArgs e)
        {
            getCustomer();
            getTable();
        }

        private void getCustomer()
        {
            string selectQuerry = "SELECT * FROM Customer";
            SqlCommand command = new SqlCommand(selectQuerry, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

        }



        private void label1_Click(object sender, EventArgs e)
        {
            DiscountForm D = new DiscountForm();
            D.Show();
            this.Hide();

        }


        private void DataGridView_discount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void DataGridView_discount_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DiscountForm_Load_1(object sender, EventArgs e)
        {
            getCustomer();
            getTable();
        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Red;
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Black;

        }

        private void label2_Click(object sender, EventArgs e)
        {
            StockForm st = new StockForm();
            st.Show();
            this.Hide();
        }
    }
}
