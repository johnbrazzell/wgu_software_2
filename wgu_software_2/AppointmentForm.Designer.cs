﻿
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.filterLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.customerGridView = new System.Windows.Forms.DataGridView();
            this.addCustomerButton = new System.Windows.Forms.Button();
            this.deleteCustomerButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).BeginInit();
            this.appointmentScheduleTabs.SuspendLayout();
            this.appointmentTabView.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // calendar
            // 
            this.calendar.FirstDayOfWeek = System.Windows.Forms.Day.Sunday;
            this.calendar.Location = new System.Drawing.Point(29, 56);
            this.calendar.MaxSelectionCount = 1;
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 0;
            this.calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendar_DateChanged);
            // 
            // appointmentDataGridView
            // 
            this.appointmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentDataGridView.Location = new System.Drawing.Point(282, 56);
            this.appointmentDataGridView.Name = "appointmentDataGridView";
            this.appointmentDataGridView.Size = new System.Drawing.Size(438, 283);
            this.appointmentDataGridView.TabIndex = 1;
            // 
            // appointmentFilterComboBox
            // 
            this.appointmentFilterComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentFilterComboBox.FormattingEnabled = true;
            this.appointmentFilterComboBox.Items.AddRange(new object[] {
            "Month",
            "Week"});
            this.appointmentFilterComboBox.Location = new System.Drawing.Point(358, 15);
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
            this.appointmentScheduleTabs.Location = new System.Drawing.Point(12, 12);
            this.appointmentScheduleTabs.Multiline = true;
            this.appointmentScheduleTabs.Name = "appointmentScheduleTabs";
            this.appointmentScheduleTabs.SelectedIndex = 0;
            this.appointmentScheduleTabs.Size = new System.Drawing.Size(776, 417);
            this.appointmentScheduleTabs.TabIndex = 3;
            // 
            // appointmentTabView
            // 
            this.appointmentTabView.Controls.Add(this.button1);
            this.appointmentTabView.Controls.Add(this.filterLabel);
            this.appointmentTabView.Controls.Add(this.calendar);
            this.appointmentTabView.Controls.Add(this.appointmentFilterComboBox);
            this.appointmentTabView.Controls.Add(this.appointmentDataGridView);
            this.appointmentTabView.Location = new System.Drawing.Point(4, 22);
            this.appointmentTabView.Name = "appointmentTabView";
            this.appointmentTabView.Padding = new System.Windows.Forms.Padding(3);
            this.appointmentTabView.Size = new System.Drawing.Size(768, 391);
            this.appointmentTabView.TabIndex = 0;
            this.appointmentTabView.Text = "Appointments";
            this.appointmentTabView.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.deleteCustomerButton);
            this.tabPage2.Controls.Add(this.addCustomerButton);
            this.tabPage2.Controls.Add(this.customerGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 391);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Customers";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterLabel.Location = new System.Drawing.Point(278, 18);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(74, 24);
            this.filterLabel.TabIndex = 3;
            this.filterLabel.Text = "Sort By:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(50, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 48);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add Appointment";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // customerGridView
            // 
            this.customerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerGridView.Location = new System.Drawing.Point(51, 32);
            this.customerGridView.Name = "customerGridView";
            this.customerGridView.Size = new System.Drawing.Size(666, 295);
            this.customerGridView.TabIndex = 0;
            // 
            // addCustomerButton
            // 
            this.addCustomerButton.Location = new System.Drawing.Point(51, 333);
            this.addCustomerButton.Name = "addCustomerButton";
            this.addCustomerButton.Size = new System.Drawing.Size(132, 35);
            this.addCustomerButton.TabIndex = 1;
            this.addCustomerButton.Text = "Add Customer";
            this.addCustomerButton.UseVisualStyleBackColor = true;
            // 
            // deleteCustomerButton
            // 
            this.deleteCustomerButton.Location = new System.Drawing.Point(189, 333);
            this.deleteCustomerButton.Name = "deleteCustomerButton";
            this.deleteCustomerButton.Size = new System.Drawing.Size(135, 35);
            this.deleteCustomerButton.TabIndex = 2;
            this.deleteCustomerButton.Text = "Delete Customer";
            this.deleteCustomerButton.UseVisualStyleBackColor = true;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.appointmentScheduleTabs);
            this.Name = "AppointmentForm";
            this.Text = "Appointment Scheduler - Main Screen";
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).EndInit();
            this.appointmentScheduleTabs.ResumeLayout(false);
            this.appointmentTabView.ResumeLayout(false);
            this.appointmentTabView.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customerGridView)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button deleteCustomerButton;
        private System.Windows.Forms.Button addCustomerButton;
        private System.Windows.Forms.DataGridView customerGridView;
    }
}