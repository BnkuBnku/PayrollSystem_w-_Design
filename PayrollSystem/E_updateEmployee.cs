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
    public partial class E_updateEmployee : Form
    {
        private Employee employee;

        Connection connect = new Connection();
        SqlConnection conn;
        SqlCommand cmd;

        public E_updateEmployee()
        {
            InitializeComponent();
        }

        public E_updateEmployee(Employee employee) : this()
        {
            this.employee = employee;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_First.Text) || String.IsNullOrEmpty(tB_Last.Text) || String.IsNullOrEmpty(tB_age.Text) ||
                String.IsNullOrEmpty(tB_Bank.Text) || String.IsNullOrEmpty(tB_pos.Text) || String.IsNullOrEmpty(up_rTBDescrip.Text) ||
                String.IsNullOrEmpty(up_TBDeductType.Text))
            {
                MessageBox.Show("Please Fill Out The Form Completely");
            }
            else
            {
                if (tB_Bank.Text.Any(char.IsDigit) && tB_Bank.Text.ToString().Length > 11)
                {
                    conn = connect.getConnect();
                    conn.Open();
                    cmd = new SqlCommand("use PayrollSystemWInsert execute UpdateEmployee '" + IDNO.Text +
                                                            "','" + tb_First.Text +
                                                            "','" + tB_Last.Text +
                                                            "', '" + tB_age.Text +
                                                            "', '" + tB_pos.Text +
                                                            "', '" + tB_Bank.Text +
                                                            "', '" + up_TBDeductType.Text +
                                                            "', '" + up_rTBDescrip.Text + "' ", conn);
                    try
                    {
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Updated");
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show("Failed to Update \n" + x.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Close();

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("PH Account number should be 12 digit.");
                }
            }
        }

        private void tB_age_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            tB_age.MaxLength = 3;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void tB_Bank_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            tB_Bank.MaxLength = 12;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

    }
}
