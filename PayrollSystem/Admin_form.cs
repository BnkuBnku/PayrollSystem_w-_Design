using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystem
{
    public partial class Admin_form : Form
    {
        public Admin_form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            P_employeeList_form pp = new P_employeeList_form();
            pp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DTR_search_form dtr = new DTR_search_form();
            dtr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Login_form login = new Login_form();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            E_employeeList_form emp = new E_employeeList_form();
            emp.Show();
        }

        private void P_reportButton_Click(object sender, EventArgs e)
        {
            Payroll_report_form report = new Payroll_report_form();
            report.Show();
        }

        private void Admin_form_Load(object sender, EventArgs e)
        {

        }
    }
}

