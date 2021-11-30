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

namespace PayrollSystem
{
    public partial class Delete_form : Form
    {
        Connection connect = new Connection();
        SqlConnection conn;
        SqlCommand cmd;
        public Delete_form()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            conn = connect.getConnect();
            conn.Open();

            cmd = new SqlCommand("use PayrollSystemWInsert execute DeleteEmployees '" + tB_Id.Text + "'", conn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
                tB_Id.Clear();
                tB_Id.Focus();
            }
            catch (Exception x)
            {
                MessageBox.Show("Failed To Delete \n" + x.Message);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tB_Id_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}
