
namespace wgu_software_2
{
    partial class AppointmentBaseForm
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
            this.appointmentTimeStartPicker = new System.Windows.Forms.DateTimePicker();
            this.appointmentDayPicker = new System.Windows.Forms.DateTimePicker();
            this.appointimeTimeEndPicker = new System.Windows.Forms.DateTimePicker();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.appointmentEndLabel = new System.Windows.Forms.Label();
            this.customerDataGridView = new System.Windows.Forms.DataGridView();
            this.appointmentDayLabel = new System.Windows.Forms.Label();
            this.appointmentTypeLabel = new System.Windows.Forms.Label();
            this.appointmentTypeTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.selectCustomerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // appointmentTimeStartPicker
            // 
            this.appointmentTimeStartPicker.Location = new System.Drawing.Point(26, 93);
            this.appointmentTimeStartPicker.Name = "appointmentTimeStartPicker";
            this.appointmentTimeStartPicker.Size = new System.Drawing.Size(200, 20);
            this.appointmentTimeStartPicker.TabIndex = 0;
            // 
            // appointmentDayPicker
            // 
            this.appointmentDayPicker.Location = new System.Drawing.Point(26, 227);
            this.appointmentDayPicker.Name = "appointmentDayPicker";
            this.appointmentDayPicker.Size = new System.Drawing.Size(200, 20);
            this.appointmentDayPicker.TabIndex = 1;
            // 
            // appointimeTimeEndPicker
            // 
            this.appointimeTimeEndPicker.Location = new System.Drawing.Point(26, 161);
            this.appointimeTimeEndPicker.Name = "appointimeTimeEndPicker";
            this.appointimeTimeEndPicker.Size = new System.Drawing.Size(200, 20);
            this.appointimeTimeEndPicker.TabIndex = 2;
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTimeLabel.Location = new System.Drawing.Point(22, 56);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(139, 20);
            this.startTimeLabel.TabIndex = 3;
            this.startTimeLabel.Text = "Appointment Start";
            // 
            // appointmentEndLabel
            // 
            this.appointmentEndLabel.AutoSize = true;
            this.appointmentEndLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentEndLabel.Location = new System.Drawing.Point(22, 127);
            this.appointmentEndLabel.Name = "appointmentEndLabel";
            this.appointmentEndLabel.Size = new System.Drawing.Size(133, 20);
            this.appointmentEndLabel.TabIndex = 4;
            this.appointmentEndLabel.Text = "Appointment End";
            // 
            // customerDataGridView
            // 
            this.customerDataGridView.AllowUserToAddRows = false;
            this.customerDataGridView.AllowUserToDeleteRows = false;
            this.customerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerDataGridView.Location = new System.Drawing.Point(294, 93);
            this.customerDataGridView.Name = "customerDataGridView";
            this.customerDataGridView.ReadOnly = true;
            this.customerDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerDataGridView.Size = new System.Drawing.Size(337, 227);
            this.customerDataGridView.TabIndex = 5;
            // 
            // appointmentDayLabel
            // 
            this.appointmentDayLabel.AutoSize = true;
            this.appointmentDayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentDayLabel.Location = new System.Drawing.Point(22, 193);
            this.appointmentDayLabel.Name = "appointmentDayLabel";
            this.appointmentDayLabel.Size = new System.Drawing.Size(132, 20);
            this.appointmentDayLabel.TabIndex = 6;
            this.appointmentDayLabel.Text = "Appointment Day";
            // 
            // appointmentTypeLabel
            // 
            this.appointmentTypeLabel.AutoSize = true;
            this.appointmentTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentTypeLabel.Location = new System.Drawing.Point(22, 262);
            this.appointmentTypeLabel.Name = "appointmentTypeLabel";
            this.appointmentTypeLabel.Size = new System.Drawing.Size(138, 20);
            this.appointmentTypeLabel.TabIndex = 7;
            this.appointmentTypeLabel.Text = "Appointment Type";
            this.appointmentTypeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // appointmentTypeTextBox
            // 
            this.appointmentTypeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentTypeTextBox.Location = new System.Drawing.Point(26, 294);
            this.appointmentTypeTextBox.Name = "appointmentTypeTextBox";
            this.appointmentTypeTextBox.Size = new System.Drawing.Size(218, 26);
            this.appointmentTypeTextBox.TabIndex = 8;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(312, 361);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(120, 30);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(494, 361);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(120, 30);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // selectCustomerLabel
            // 
            this.selectCustomerLabel.AutoSize = true;
            this.selectCustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectCustomerLabel.Location = new System.Drawing.Point(293, 56);
            this.selectCustomerLabel.Name = "selectCustomerLabel";
            this.selectCustomerLabel.Size = new System.Drawing.Size(127, 20);
            this.selectCustomerLabel.TabIndex = 11;
            this.selectCustomerLabel.Text = "Select Customer";
            // 
            // AppointmentBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 468);
            this.Controls.Add(this.selectCustomerLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.appointmentTypeTextBox);
            this.Controls.Add(this.appointmentTypeLabel);
            this.Controls.Add(this.appointmentDayLabel);
            this.Controls.Add(this.customerDataGridView);
            this.Controls.Add(this.appointmentEndLabel);
            this.Controls.Add(this.startTimeLabel);
            this.Controls.Add(this.appointimeTimeEndPicker);
            this.Controls.Add(this.appointmentDayPicker);
            this.Controls.Add(this.appointmentTimeStartPicker);
            this.Name = "AppointmentBaseForm";
            this.Text = "AppointmentBaseForm";
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.Label appointmentEndLabel;
        private System.Windows.Forms.Label appointmentDayLabel;
        private System.Windows.Forms.Label appointmentTypeLabel;
        private System.Windows.Forms.Label selectCustomerLabel;
        protected System.Windows.Forms.Button saveButton;
        protected System.Windows.Forms.Button cancelButton;
        protected System.Windows.Forms.DateTimePicker appointmentTimeStartPicker;
        protected System.Windows.Forms.DateTimePicker appointmentDayPicker;
        protected System.Windows.Forms.DateTimePicker appointimeTimeEndPicker;
        protected System.Windows.Forms.DataGridView customerDataGridView;
        protected System.Windows.Forms.TextBox appointmentTypeTextBox;
    }
}