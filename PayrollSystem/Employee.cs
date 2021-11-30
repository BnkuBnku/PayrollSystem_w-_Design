using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class Employee
    {
        private int emp_id;
        private string emp_first, emp_last;
        private int emp_age;
        private string emp_position, emp_deducType, emp_deduc_Descrip;

        public Employee(int emp_id, string emp_first, string emp_last, int emp_age, string emp_position, string emp_deducType, string emp_deduc_Descrip)
        {
            this.Emp_id = emp_id;
            this.Emp_first = emp_first;
            this.Emp_last = emp_last;
            this.Emp_age = emp_age;
            this.Emp_position = emp_position;
            this.Emp_deducType = emp_deducType;
            this.Emp_deduc_Descrip = emp_deduc_Descrip;
        }

        public int Emp_id { get => emp_id; set => emp_id = value; }
        public string Emp_first { get => emp_first; set => emp_first = value; }
        public string Emp_last { get => emp_last; set => emp_last = value; }
        public int Emp_age { get => emp_age; set => emp_age = value; }
        public string Emp_position { get => emp_position; set => emp_position = value; }
        public string Emp_deducType { get => emp_deducType; set => emp_deducType = value; }
        public string Emp_deduc_Descrip { get => emp_deduc_Descrip; set => emp_deduc_Descrip = value; }
    }
}
