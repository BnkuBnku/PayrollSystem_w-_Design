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
            var ppform = (P_employeeList_form)Application.OpenForms["P_employeeList_form"];
            if(ppform == null)
            {
                P_employeeList_form pp = new P_employeeList_form();
                pp.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var dtrform = (DTR_search_form)Application.OpenForms["DTR_search_form"];

            if(dtrform == null)
            {
                DTR_search_form dtr = new DTR_search_form();
                dtr.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Login_form login = new Login_form();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var empform = (E_employeeList_form)Application.OpenForms["E_employeeList_form"];
            
            if (empform == null)
            {
                E_employeeList_form emp = new E_employeeList_form();
                emp.Show();
            }
        }

        private void P_reportButton_Click(object sender, EventArgs e)
        {
            var payform = (Payroll_report_form)Application.OpenForms["Payroll_report_form"];

            if (payform == null)
            {
                Payroll_report_form report = new Payroll_report_form();
                report.Show();
            }
        }
    }
}

