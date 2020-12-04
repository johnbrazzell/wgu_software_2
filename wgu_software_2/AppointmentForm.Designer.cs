
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
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // calendar
            // 
            this.calendar.FirstDayOfWeek = System.Windows.Forms.Day.Sunday;
            this.calendar.Location = new System.Drawing.Point(87, 104);
            this.calendar.MaxSelectionCount = 1;
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 0;
            this.calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendar_DateChanged);
            // 
            // appointmentDataGridView
            // 
            this.appointmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentDataGridView.Location = new System.Drawing.Point(326, 104);
            this.appointmentDataGridView.Name = "appointmentDataGridView";
            this.appointmentDataGridView.Size = new System.Drawing.Size(438, 283);
            this.appointmentDataGridView.TabIndex = 1;
            // 
            // appointmentFilterComboBox
            // 
            this.appointmentFilterComboBox.FormattingEnabled = true;
            this.appointmentFilterComboBox.Location = new System.Drawing.Point(459, 48);
            this.appointmentFilterComboBox.Name = "appointmentFilterComboBox";
            this.appointmentFilterComboBox.Size = new System.Drawing.Size(121, 21);
            this.appointmentFilterComboBox.TabIndex = 2;
            this.appointmentFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.appointmentFilterComboBox_SelectedIndexChanged);
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.appointmentFilterComboBox);
            this.Controls.Add(this.appointmentDataGridView);
            this.Controls.Add(this.calendar);
            this.Name = "AppointmentForm";
            this.Text = "Appointment Scheduler - Main Screen";
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.DataGridView appointmentDataGridView;
        private System.Windows.Forms.ComboBox appointmentFilterComboBox;
    }
}