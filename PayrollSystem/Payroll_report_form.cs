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
    public partial class Payroll_report_form : Form
    {
        Connection connect = new Connection();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        public Payroll_report_form()
        {
            InitializeComponent();
        }

        private void Payroll_report_form_Load(object sender, EventArgs e)
        {
            LoadList();
            LoadListSum();
        }
        
        private void LoadList()
        {
            conn = connect.getConnect();
            conn.Open();

            dataGridView1.Rows.Clear();
            cmd = new SqlCommand("use PayrollSystemWInsert execute DisplayFullReport", conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10], dr[11], dr[12], dr[13], dr[14], dr[15]);
            }


            dr.Close();
            cmd.Dispose();
            conn.Close();
        }

        private void LoadListSum()
        {
            conn = connect.getConnect();
            conn.Open();

            dataGridView2.Rows.Clear();
            cmd = new SqlCommand("use PayrollSystemWInsert execute DisplaySummary", conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dataGridView2.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
            }


            dr.Close();
            cmd.Dispose();
            conn.Close();
        }

        private void RefreshButtonSum_Click(object sender, EventArgs e)
        {
            LoadListSum();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn = connect.getConnect();
            conn.Open();

            
            if (dataGridView1.SelectedRows.Count > 0)
            {
                cmd = new SqlCommand("use PayrollSystemWInsert delete from payrollsystem.PayReport where PayReportID = '" + dataGridView1.CurrentRow.Cells[0].Value + "'",conn);
                cmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Select 1 row before you hit Delete");
            }

            cmd.Dispose();
            conn.Close();

            LoadList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = connect.getConnect();
            conn.Open();


            if (dataGridView2.SelectedRows.Count > 0)
            {
                cmd = new SqlCommand("use PayrollSystemWInsert delete from payrollsystem.SummaryPort where SummaryID = '" + dataGridView2.CurrentRow.Cells[0].Value + "'", conn);
                cmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Select 1 row before you hit Delete");
            }

            cmd.Dispose();
            conn.Close();

            LoadListSum();
        }
    }
}
