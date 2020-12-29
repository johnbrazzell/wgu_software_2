
namespace wgu_software_2
{
    partial class AppointmentForm
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
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.appointmentDataGridView = new System.Windows.Forms.DataGridView();
            this.appointmentFilterComboBox = new System.Windows.Forms.ComboBox();
            this.appointmentScheduleTabs = new System.Windows.Forms.TabControl();
            this.appointmentTabView = new System.Windows.Forms.TabPage();
            this.deleteAppointmentButton = new System.Windows.Forms.Button();
            this.updateAppointmentButton = new System.Windows.Forms.Button();
            this.filterLabel = new System.Windows.Forms.Label();
            this.addAppointmentButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.updateCustomerButton = new System.Windows.Forms.Button();
            this.deleteCustomerButton = new System.Windows.Forms.Button();
            this.addCustomerButton = new System.Windows.Forms.Button();
            this.customerGridView = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numOfReportsByMonthButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.schedulesForConsultantButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).BeginInit();
            this.appointmentScheduleTabs.SuspendLayout();
            this.appointmentTabView.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerGridView)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // calendar
            // 
            this.calendar.FirstDayOfWeek = System.Windows.Forms.Day.Sunday;
            this.calendar.Location = new System.Drawing.Point(50, 106);
            this.calendar.MaxSelectionCount = 1;
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 0;
            this.calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendar_DateChanged);
            // 
            // appointmentDataGridView
            // 
            this.appointmentDataGridView.AllowUserToAddRows = false;
            this.appointmentDataGridView.AllowUserToDeleteRows = false;
            this.appointmentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.appointmentDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.appointmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentDataGridView.Location = new System.Drawing.Point(309, 32);
            this.appointmentDataGridView.MultiSelect = false;
            this.appointmentDataGridView.Name = "appointmentDataGridView";
            this.appointmentDataGridView.ReadOnly = true;
            this.appointmentDataGridView.RowTemplate.ReadOnly = true;
            this.appointmentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentDataGridView.Size = new System.Drawing.Size(594, 262);
            this.appointmentDataGridView.TabIndex = 1;
            this.appointmentDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.appointmentDataGridView_CellContentClick);
            // 
            // appointmentFilterComboBox
            // 
            this.appointmentFilterComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentFilterComboBox.FormattingEnabled = true;
            this.appointmentFilterComboBox.Items.AddRange(new object[] {
            "Month",
            "Week"});
            this.appointmentFilterComboBox.Location = new System.Drawing.Point(157, 32);
            this.appointmentFilterComboBox.MaxDropDownItems = 2;
            this.appointmentFilterComboBox.Name = "appointmentFilterComboBox";
            this.appointmentFilterComboBox.Size = new System.Drawing.Size(121, 28);
            this.appointmentFilterComboBox.TabIndex = 2;
            this.appointmentFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.appointmentFilterComboBox_SelectedIndexChanged);
            // 
            // appointmentScheduleTabs
            // 
            this.appointmentScheduleTabs.Controls.Add(this.appointmentTabView);
            this.appointmentScheduleTabs.Controls.Add(this.tabPage2);
            this.appointmentScheduleTabs.Controls.Add(this.tabPage1);
            this.appointmentScheduleTabs.Location = new System.Drawing.Point(12, 12);
            this.appointmentScheduleTabs.Multiline = true;
            this.appointmentScheduleTabs.Name = "appointmentScheduleTabs";
            this.appointmentScheduleTabs.SelectedIndex = 0;
            this.appointmentScheduleTabs.Size = new System.Drawing.Size(930, 426);
            this.appointmentScheduleTabs.TabIndex = 3;
            // 
            // appointmentTabView
            // 
            this.appointmentTabView.Controls.Add(this.deleteAppointmentButton);
            this.appointmentTabView.Controls.Add(this.updateAppointmentButton);
            this.appointmentTabView.Controls.Add(this.filterLabel);
            this.appointmentTabView.Controls.Add(this.calendar);
            this.appointmentTabView.Controls.Add(this.addAppointmentButton);
            this.appointmentTabView.Controls.Add(this.appointmentFilterComboBox);
            this.appointmentTabView.Controls.Add(this.appointmentDataGridView);
            this.appointmentTabView.Location = new System.Drawing.Point(4, 22);
            this.appointmentTabView.Name = "appointmentTabView";
            this.appointmentTabView.Padding = new System.Windows.Forms.Padding(3);
            this.appointmentTabView.Size = new System.Drawing.Size(922, 400);
            this.appointmentTabView.TabIndex = 0;
            this.appointmentTabView.Text = "Appointments";
            this.appointmentTabView.UseVisualStyleBackColor = true;
            // 
            // deleteAppointmentButton
            // 
            this.deleteAppointmentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAppointmentButton.Location = new System.Drawing.Point(696, 316);
            this.deleteAppointmentButton.Name = "deleteAppointmentButton";
            this.deleteAppointmentButton.Size = new System.Drawing.Size(140, 35);
            this.deleteAppointmentButton.TabIndex = 6;
            this.deleteAppointmentButton.Text = "Delete Appointment";
            this.deleteAppointmentButton.UseVisualStyleBackColor = true;
            this.deleteAppointmentButton.Click += new System.EventHandler(this.deleteAppointmentButton_Click);
            // 
            // updateAppointmentButton
            // 
            this.updateAppointmentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateAppointmentButton.Location = new System.Drawing.Point(527, 316);
            this.updateAppointmentButton.Name = "updateAppointmentButton";
            this.updateAppointmentButton.Size = new System.Drawing.Size(140, 35);
            this.updateAppointmentButton.TabIndex = 5;
            this.updateAppointmentButton.Text = "Update Appointment";
            this.updateAppointmentButton.UseVisualStyleBackColor = true;
            this.updateAppointmentButton.Click += new System.EventHandler(this.updateAppointmentButton_Click);
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterLabel.Location = new System.Drawing.Point(60, 32);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(74, 24);
            this.filterLabel.TabIndex = 3;
            this.filterLabel.Text = "Sort By:";
            // 
            // addAppointmentButton
            // 
            this.addAppointmentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAppointmentButton.Location = new System.Drawing.Point(369, 316);
            this.addAppointmentButton.Name = "addAppointmentButton";
            this.addAppointmentButton.Size = new System.Drawing.Size(130, 35);
            this.addAppointmentButton.TabIndex = 4;
            this.addAppointmentButton.Text = "Add Appointment";
            this.addAppointmentButton.UseVisualStyleBackColor = true;
            this.addAppointmentButton.Click += new System.EventHandler(this.addAppointmentButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.updateCustomerButton);
            this.tabPage2.Controls.Add(this.deleteCustomerButton);
            this.tabPage2.Controls.Add(this.addCustomerButton);
            this.tabPage2.Controls.Add(this.customerGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(922, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Customers";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // updateCustomerButton
            // 
            this.updateCustomerButton.Location = new System.Drawing.Point(361, 333);
            this.updateCustomerButton.Name = "updateCustomerButton";
            this.updateCustomerButton.Size = new System.Drawing.Size(132, 35);
            this.updateCustomerButton.TabIndex = 3;
            this.updateCustomerButton.Text = "Update Customer";
            this.updateCustomerButton.UseVisualStyleBackColor = true;
            this.updateCustomerButton.Click += new System.EventHandler(this.updateCustomerButton_Click);
            // 
            // deleteCustomerButton
            // 
            this.deleteCustomerButton.Location = new System.Drawing.Point(499, 333);
            this.deleteCustomerButton.Name = "deleteCustomerButton";
            this.deleteCustomerButton.Size = new System.Drawing.Size(135, 35);
            this.deleteCustomerButton.TabIndex = 2;
            this.deleteCustomerButton.Text = "Delete Customer";
            this.deleteCustomerButton.UseVisualStyleBackColor = true;
            this.deleteCustomerButton.Click += new System.EventHandler(this.deleteCustomerButton_Click);
            // 
            // addCustomerButton
            // 
            this.addCustomerButton.Location = new System.Drawing.Point(223, 333);
            this.addCustomerButton.Name = "addCustomerButton";
            this.addCustomerButton.Size = new System.Drawing.Size(132, 35);
            this.addCustomerButton.TabIndex = 1;
            this.addCustomerButton.Text = "Add Customer";
            this.addCustomerButton.UseVisualStyleBackColor = true;
            this.addCustomerButton.Click += new System.EventHandler(this.addCustomerButton_Click);
            // 
            // customerGridView
            // 
            this.customerGridView.AllowUserToAddRows = false;
            this.customerGridView.AllowUserToDeleteRows = false;
            this.customerGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customerGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.customerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerGridView.Location = new System.Drawing.Point(51, 32);
            this.customerGridView.MultiSelect = false;
            this.customerGridView.Name = "customerGridView";
            this.customerGridView.ReadOnly = true;
            this.customerGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerGridView.Size = new System.Drawing.Size(829, 295);
            this.customerGridView.TabIndex = 0;
            this.customerGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customerGridView_CellContentClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(922, 400);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Reports";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Appointment \r\nTypes By Month";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "Schedules For Each \r\nConsultant";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "List of Inactive Customers";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numOfReportsByMonthButton
            // 
            this.numOfReportsByMonthButton.BackColor = System.Drawing.Color.GhostWhite;
            this.numOfReportsByMonthButton.Location = new System.Drawing.Point(53, 211);
            this.numOfReportsByMonthButton.Name = "numOfReportsByMonthButton";
            this.numOfReportsByMonthButton.Size = new System.Drawing.Size(135, 39);
            this.numOfReportsByMonthButton.TabIndex = 3;
            this.numOfReportsByMonthButton.Text = "Generate Report";
            this.numOfReportsByMonthButton.UseVisualStyleBackColor = false;
            this.numOfReportsByMonthButton.Click += new System.EventHandler(this.numOfReportsByMonthButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numOfReportsByMonthButton);
            this.panel1.Location = new System.Drawing.Point(44, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 276);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.schedulesForConsultantButton);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(334, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 276);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(621, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 276);
            this.panel3.TabIndex = 6;
            // 
            // schedulesForConsultantButton
            // 
            this.schedulesForConsultantButton.BackColor = System.Drawing.Color.GhostWhite;
            this.schedulesForConsultantButton.Location = new System.Drawing.Point(53, 211);
            this.schedulesForConsultantButton.Name = "schedulesForConsultantButton";
            this.schedulesForConsultantButton.Size = new System.Drawing.Size(135, 39);
            this.schedulesForConsultantButton.TabIndex = 4;
            this.schedulesForConsultantButton.Text = "Generate Report";
            this.schedulesForConsultantButton.UseVisualStyleBackColor = false;
            this.schedulesForConsultantButton.Click += new System.EventHandler(this.schedulesForConsultantButton_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.GhostWhite;
            this.button3.Location = new System.Drawing.Point(57, 211);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(135, 39);
            this.button3.TabIndex = 5;
            this.button3.Text = "Generate Report";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 456);
            this.Controls.Add(this.appointmentScheduleTabs);
            this.Name = "AppointmentForm";
            this.Text = "Appointment Scheduler - Main Screen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).EndInit();
            this.appointmentScheduleTabs.ResumeLayout(false);
            this.appointmentTabView.ResumeLayout(false);
            this.appointmentTabView.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customerGridView)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.DataGridView appointmentDataGridView;
        private System.Windows.Forms.ComboBox appointmentFilterComboBox;
        private System.Windows.Forms.TabControl appointmentScheduleTabs;
        private System.Windows.Forms.TabPage appointmentTabView;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.Button addAppointmentButton;
        private System.Windows.Forms.Button deleteCustomerButton;
        private System.Windows.Forms.Button addCustomerButton;
        private System.Windows.Forms.DataGridView customerGridView;
        private System.Windows.Forms.Button updateCustomerButton;
        private System.Windows.Forms.Button deleteAppointmentButton;
        private System.Windows.Forms.Button updateAppointmentButton;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button schedulesForConsultantButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button numOfReportsByMonthButton;
    }
}