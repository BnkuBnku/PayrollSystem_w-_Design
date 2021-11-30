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
    public partial class DTR_search_form : Form
    {
        Connection connect = new Connection();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        public DTR_search_form()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            d_label.Text = DateTime.Now.ToString("yyyy / MM / dd");
            time_label.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            SearchLoadList();
        }

        private void DTR_search_form_Load(object sender, EventArgs e)
        {
            timer1.Start();
            LoadList();
            ToDatePicker.Value = DateTime.Now;
        }

        private void LoadList()
        {
            conn = connect.getConnect();
            conn.Open();

            dataGridView1.Rows.Clear();
            cmd = new SqlCommand("use PayrollSystemWInsert execute DTRReport", conn);
            try
            {
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
                }

                
            }
            catch (Exception x)
            {
                MessageBox.Show("There is a problem in Loading the List \n\n" + x.Message);
            }
            finally
            {
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
        }

        private void SearchLoadList()
        {
            if (String.IsNullOrEmpty(tb_EmpID.Text))
            {
                MessageBox.Show("Please Input ID First");
            }
            else
            {
                string FromDate = FromDatePick.Value.ToString("yyyy-MM-dd");
                string ToDate = ToDatePicker.Value.ToString("yyyy-MM-dd");
                conn = connect.getConnect();
                conn.Open();

                dataGridView1.Rows.Clear();
                cmd = new SqlCommand("use PayrollSystemWInsert execute SearchDTR '" + tb_EmpID.Text + "', '" 
                                                                                    + FromDate + "', '" 
                                                                                    + ToDate + "'", conn);
                try
                {
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
                        
                    }

                    MessageBox.Show("Search Completed");

                    int tot = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        tot += Convert.ToInt32(row.Cells[5].Value);
                    }

                    lb_total.Text = tot.ToString();

                    
                    
                }
                catch (Exception x)
                {
                    MessageBox.Show("Failed to Search \n\n" + x.Message);
                }
                finally
                {
                    dr.Close();
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            conn = connect.getConnect();
            conn.Open();

           

            cmd = new SqlCommand("use PayrollSystemWInsert execute DeleteDTR '" + dataGridView1.CurrentRow.Cells[0].Value + "'",conn );
            try
            {
                cmd.ExecuteNonQuery();

                MessageBox.Show("Deleted Successfully");
            }
            catch (Exception x)
            {
                MessageBox.Show("Failed to Delete \n\n" + x.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                LoadList();
            }
        }

        private void refreshbutton_Click(object sender, EventArgs e)
        {
            tb_EmpID.Clear();
            LoadList();
            lb_total.Text = "-";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_EmpID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}
