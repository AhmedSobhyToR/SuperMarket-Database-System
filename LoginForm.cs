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
    public partial class LoginForm : Form
    {
                DBConnect dBCon = new DBConnect();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Red;
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Black;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button_login_Click(object sender, EventArgs e)
        {
            if (comboBox_role.SelectedItem.ToString() == "Admin")
            {
                if (TextBox_username.Text == "Admin" && TextBox_password.Text == "Admin")
                {
                    ProductForm product = new ProductForm();
                    product.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please Enter Correct UserName and Password");
                }
            }
            else if (comboBox_role.SelectedItem.ToString() == "Customer")
            {
                try
                {
                    dBCon.OpenCon();
                    string checkQuery = " SELECT UserName , Password FROM Customer WHERE UserName IN ('" + TextBox_username + "') AND Password IN ('" + TextBox_password + "')";
                    SqlCommand command = new SqlCommand(checkQuery, dBCon.GetCon());
                    SqlDataReader dataReader;

                    dataReader = command.ExecuteReader();




                    
                    if (dataReader.Read())
                    {
                        
                        MessageBox.Show("Success");
                        BrowsingForm S = new BrowsingForm();
                        S.Show();
                        this.Hide();
                        

                    }
                    else
                    {
                        MessageBox.Show("Failed");
                    }
                    dataReader.Close();
                    command.Dispose();
                    dBCon.CloseCon();







                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

 

            }

        private void Button_SignUp_Click(object sender, EventArgs e)
        {
            SignupForm S = new SignupForm();
            S.Show();
            this.Hide();
        }
    }


    
}
