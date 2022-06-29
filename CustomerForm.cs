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
    public partial class CustomerForm : Form
    {
        DBConnect dBCon = new DBConnect();

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void Button_updatedata_Click(object sender, EventArgs e)
        {
            try
            {
                string updateQuery = "UPDATE Customer SET UserName='" + TextBox_uid.Text + "', Password='" + TextBox_uusername.Text + "'WHERE CustomerID=" + TextBox_uid.Text + "";
                SqlCommand command = new SqlCommand(updateQuery, dBCon.GetCon());
                dBCon.OpenCon();
                command.ExecuteNonQuery();
                MessageBox.Show("Customer Info Updated Successfully", "Updated Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dBCon.CloseCon();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Red;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Black;

        }

        private void Button_udelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_uid.Text == "")
                {
                    MessageBox.Show("Missing ID Information");
                }
                else
                {

                    string deleteQuery = "DELETE FROM Customer WHERE CustomerID=" + TextBox_uid.Text + "";
                    SqlCommand command = new SqlCommand(deleteQuery, dBCon.GetCon());
                    dBCon.OpenCon();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Customer Deleted Successfully", "delete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dBCon.CloseCon();



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
