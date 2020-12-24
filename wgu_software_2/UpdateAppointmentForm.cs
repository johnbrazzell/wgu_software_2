using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace wgu_software_2
{
    public partial class UpdateAppointmentForm : wgu_software_2.AppointmentBaseForm
    {
        private int _appointmentID = 0;
        private int _customerID = 0;
        private int _updatedCustomerID = 0;
        AppointmentForm _appointmentForm;
        public UpdateAppointmentForm(int appointmentID, int customerID)
        {
            InitializeComponent();
            _appointmentID = appointmentID;
            _customerID = customerID;

            _appointmentForm = Application.OpenForms["AppointmentForm"] as AppointmentForm;

            //load data from db into form
            LoadFormData(_appointmentID, _customerID);
        }

        private void LoadFormData(int appointmentID, int customerID)
        {
            DBHelper.OpenConnection();
            MySqlConnection connection = DBHelper.GetConnection();

            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT customeriD, type, start, end FROM appointment WHERE appointmentId=@appointmentID";
            command.Parameters.AddWithValue("@appointmentID", appointmentID);

            MySqlDataReader reader = command.ExecuteReader();
            //need to loop through and select the row of the original customer
            if(reader.HasRows)
            {
                if (reader.Read())
                {
                   
                    int selectedCustomerRow = (int)reader["customerId"];
                    foreach(DataGridViewRow row in customerDataGridView.Rows)
                    {
                        if((int)row.Cells[0].Value == selectedCustomerRow)
                        {
                            row.Selected = true;
                        }
                    }
                    //customerDataGridView.Rows.IndexOf()

                   // customerDataGridView.Rows.IndexOf()
                   //     OfType<DataGridViewRow>().ToList().ForEach(row => { if (!row.IsNewRow) row.Visible = false; });

                    appointmentTypeTextBox.Text = reader["type"].ToString();

                    TimeZoneInfo tzInfo = TimeZoneInfo.Local;
                    DateTime startTime = (DateTime)reader["start"];
                    DateTime endTime = (DateTime)reader["end"];

                    //Convert UTC times from database to the correct local times
                    startTime = TimeZoneInfo.ConvertTimeFromUtc(startTime, tzInfo);
                    endTime = TimeZoneInfo.ConvertTimeFromUtc(endTime, tzInfo);
                    appointmentTimeStartPicker.Value = startTime;
                    appointimeTimeEndPicker.Value = endTime;
                    appointmentDayPicker.Value = startTime.Date;
                }
            }
            reader.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //need to post the data back into the database.
            MySqlConnection connection = DBHelper.GetConnection();
            MySqlCommand command = connection.CreateCommand();

            GetCustomerID();

            DateTime startDateAndTime = appointmentDayPicker.Value.Date + appointmentTimeStartPicker.Value.TimeOfDay;
            DateTime startConverted = startDateAndTime.ToUniversalTime();

            DateTime endDateAndTime = appointmentDayPicker.Value.Date + appointimeTimeEndPicker.Value.TimeOfDay;
            DateTime endDateConverted = endDateAndTime.ToUniversalTime();

            DateTime dt = DateTime.UtcNow;

            command.CommandText = "UPDATE appointment SET customerId=@customerID, type=@type, start=@start, end=@end, " +
                "lastUpdate=@lastUpdate, lastUpdateBy=@lastUpdateBy WHERE appointmentId=@appointmentID";

            command.Parameters.AddWithValue("@customerID", _updatedCustomerID);
            command.Parameters.AddWithValue("@appointmentId", _appointmentID);
            command.Parameters.AddWithValue("@type", appointmentTypeTextBox.Text.Trim());
            command.Parameters.AddWithValue("@start", startConverted);
            command.Parameters.AddWithValue("@end", endDateConverted);
            command.Parameters.AddWithValue("@lastUpdate", dt);
            command.Parameters.AddWithValue("@lastUpdateBy", DBHelper.GetCurrentUser());



            command.ExecuteNonQuery();

            _appointmentForm.UpdateCustomerForm();
            
            this.Close();
        }

        private void GetCustomerID()
        {


            foreach (DataGridViewRow row in customerDataGridView.Rows)
            {

                if (row.Selected)
                {
                    _updatedCustomerID = Int32.Parse(row.Cells[0].Value.ToString());
                }



            }
        }

    }
}
