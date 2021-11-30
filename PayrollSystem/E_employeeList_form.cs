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
    public partial class E_employeeList_form : Form
    {
        Connection connect = new Connection();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        public E_employeeList_form()
        {
            InitializeComponent();
        }

        private void E_employeeList_form_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            conn = connect.getConnect();
            conn.Open();

            dataGridView1.Rows.Clear();
            cmd = new SqlCommand("use PayrollSystemWInsert execute DisplayEmployees", conn);
            try
            {
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);
                }

            }
            catch (Exception x)
            {
                MessageBox.Show("There is a problem to the LoadList \n\n " + x.Message);
            }
            finally
            {
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            E_addemployee_form add = new E_addemployee_form();
            add.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Delete_form delete = new Delete_form();
            delete.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            connect.getConnect();
            conn.Open();

            E_updateEmployee upa = new E_updateEmployee();

            upa.IDNO.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            upa.tb_First.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            upa.tB_Last.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            upa.tB_age.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            upa.tB_pos.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            upa.tB_Bank.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            upa.up_TBDeductType.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            upa.up_rTBDescrip.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();

            upa.Show();

            dr.Close();
            cmd.Dispose();
            conn.Close();
        }

    }
}
