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
        public UpdateAppointmentForm(int appointmentID)
        {
            InitializeComponent();
            //load data from db into form
            LoadFormData(appointmentID);
        }

        private void LoadFormData(int id)
        {
            DBHelper.OpenConnection();
            MySqlConnection connection = DBHelper.GetConnection();

            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT type, start, end FROM appointment WHERE appointmentId=@appointmentID";
            command.Parameters.AddWithValue("@appointmentID", id);

            MySqlDataReader reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                if (reader.Read())
                {
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
        }
    }
}
