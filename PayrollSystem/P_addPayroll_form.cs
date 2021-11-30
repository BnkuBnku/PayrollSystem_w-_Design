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
    public partial class P_addPayroll_form : Form
    {
        Connection connect = new Connection();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        double Basic = 50;
        double Other = 0;
        double SSS = 0;
        string datetime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff"); 
        public string bankacc;

        public P_addPayroll_form()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            timer1.Start();

            string Taxes = tb_sss.Text;


            if (Taxes == "SSS")
            {
                SSS = 15;
            }
            else
            {
                Other = 20;
            }

            tb_basic.Text = Basic.ToString();
            tb_sss.Text = SSS.ToString();
            tb_other.Text = Other.ToString();

            conn = connect.getConnect();
            conn.Open();


            Roll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d_label.Text = DateTime.Now.ToString("yyyy-MM-dd");
            time_label.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void tb_workhours_TextChanged(object sender, EventArgs e)
        {
            sum();   
        }

        private void tb_allow_TextChanged(object sender, EventArgs e)
        {
            sum();
        }
        private void tb_adjustments_TextChanged(object sender, EventArgs e)
        {
            sum();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked)
            {
                Save();
            }
            else
            {
                MessageBox.Show("Please Select One of the Payroll Option");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (bankacc.Equals(String.Empty))
            {
                tb_bankAcc.Visible = false;
                radioButton1.Checked = false;
                MessageBox.Show("This Employee has no Bank Account!");
            }
            else
            {
                tb_bankAcc.Visible = true;
                YesBank();
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            tb_bankAcc.Visible = false;
            tb_bankAcc.Clear();
        }

        private void Save()
        {
            conn = connect.getConnect();
            conn.Open();

            string YesBankorNo;
            if (radioButton1.Checked)
            {
                YesBankorNo = "Yes";

                if (String.IsNullOrEmpty(tb_bankAcc.Text))
                {
                    YesBankorNo = "No";
                }
            }
            else
            {
                YesBankorNo = "No";
            }

            cmd = new SqlCommand("use PayrollSystemWInsert execute AddPayrollReport '" + tb_empID.Text + "','" 
                                                                                        + tb_roll.Text + "','"
                                                                                        + tb_First.Text + "','"
                                                                                        + tb_last.Text + "','"
                                                                                        + tb_workhours.Text + "','"
                                                                                        + tb_basic.Text + "','"
                                                                                        + tb_salary.Text + "','"
                                                                                        + tb_allow.Text + "','"
                                                                                        + tb_adjustments.Text + "','"
                                                                                        + tb_sss.Text + "','"
                                                                                        + tb_other.Text + "','"
                                                                                        + tb_total.Text + "','"
                                                                                        + tb_netpay.Text + "','"
                                                                                        + YesBankorNo + "','"
                                                                                        + datetime + "'", conn);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Payroll Added!");

            cmd.Dispose();
            conn.Close();

            this.Close();
        }

        private void YesBank()
        {
            conn = connect.getConnect();
            conn.Open();

            cmd = new SqlCommand("use PayrollSystemWInsert execute DisplayBankAcc '" + tb_First.Text + "', '" + tb_last.Text + "' ",conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                tb_bankAcc.Text = dr[0].ToString();
            }

            cmd.Dispose();
            conn.Close();
        }

        private void sum()
        {
            double a1, b1, c1, d1, i1; // upper section auto calculation
            double.TryParse(tb_workhours.Text, out a1);
            double.TryParse(tb_basic.Text, out b1);
            double.TryParse(tb_allow.Text, out c1);
            double.TryParse(tb_adjustments.Text, out d1);
            i1 = ((b1 * a1) + c1) - d1;
            tb_salary.Text = i1.ToString();

            double total, netpay, SSS, OTaxes; // Below section auto calculation
            double.TryParse(tb_sss.Text, out SSS);
            double.TryParse(tb_other.Text, out OTaxes);

            total = SSS + OTaxes;
            netpay = i1 - total;

            tb_total.Text = total.ToString();
            tb_netpay.Text = netpay.ToString();
        }

        private void Roll()
        {
            conn = connect.getConnect();
            conn.Open();

            cmd = new SqlCommand("use PayrollSystemWInsert select RollNum from payrollsystem.Payroll where Employee_id = '" + tb_empID.Text + "'", conn);
            try
            {
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tb_roll.Text = dr[0].ToString();
                }

                
            }
            catch (Exception x)
            {
                MessageBox.Show("Cannot be Search on Payroll Table \n" + x.Message);
            }
            finally
            {
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }

        }

    }
}
