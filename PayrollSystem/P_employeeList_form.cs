using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PayrollSystem
{
    public partial class P_employeeList_form : Form
    {
        Connection connect = new Connection();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        public P_employeeList_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectedList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void P_employeeList_form_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            conn = connect.getConnect();
            conn.Open();

            dataGridView1.Rows.Clear();
            cmd = new SqlCommand("use PayrollSystemWInsert execute DisplayEmployees", conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);
            }


            dr.Close();
            cmd.Dispose();
            conn.Close();
        }

        private void SelectedList()
        {
            P_addPayroll_form add = new P_addPayroll_form();
            add.tb_empID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            add.tb_First.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            add.tb_last.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            add.bankacc = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            add.tb_sss.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            add.Show();
        }
    }
}
