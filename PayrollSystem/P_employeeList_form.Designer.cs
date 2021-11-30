namespace PayrollSystem
{
    partial class P_employeeList_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.P_empid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_firstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_lastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_bankacc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.P_empid,
            this.P_firstname,
            this.P_lastname,
            this.P_age,
            this.P_position,
            this.Column2,
            this.P_bankacc,
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(12, 9);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(853, 370);
            this.dataGridView1.TabIndex = 0;
            // 
            // P_empid
            // 
            this.P_empid.HeaderText = "Emp ID";
            this.P_empid.Name = "P_empid";
            this.P_empid.ReadOnly = true;
            this.P_empid.Width = 70;
            // 
            // P_firstname
            // 
            this.P_firstname.HeaderText = "First Name";
            this.P_firstname.Name = "P_firstname";
            this.P_firstname.ReadOnly = true;
            // 
            // P_lastname
            // 
            this.P_lastname.HeaderText = "Last Name";
            this.P_lastname.Name = "P_lastname";
            this.P_lastname.ReadOnly = true;
            // 
            // P_age
            // 
            this.P_age.HeaderText = "Age";
            this.P_age.Name = "P_age";
            this.P_age.ReadOnly = true;
            this.P_age.Width = 50;
            // 
            // P_position
            // 
            this.P_position.HeaderText = "Position";
            this.P_position.Name = "P_position";
            this.P_position.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "BankAcc";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // P_bankacc
            // 
            this.P_bankacc.HeaderText = "Deduct Type";
            this.P_bankacc.Name = "P_bankacc";
            this.P_bankacc.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Deduct Description";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 385);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add Payroll ➕";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(122, 385);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 33);
            this.button2.TabIndex = 1;
            this.button2.Text = "Refresh 🔄";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(761, 385);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 33);
            this.button3.TabIndex = 4;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // P_employeeList_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 431);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "P_employeeList_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee List";
            this.Load += new System.EventHandler(this.P_employeeList_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_empid;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_firstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_lastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_age;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_position;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_bankacc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}