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
    
    public partial class AddAppointmentForm : wgu_software_2.AppointmentBaseForm
    {
        int _customerID;
        int _userID;
        AppointmentForm _appointmentForm;
        public AddAppointmentForm()
        {
            InitializeComponent();
            _appointmentForm = Application.OpenForms["AppointmentForm"] as AppointmentForm;
        }

    
        private void saveButton_Click_1(object sender, EventArgs e)
        {

            if(CheckAppointmentOverlapTimes(appointmentTimeStartPicker.Value, appointimeTimeEndPicker.Value, appointmentDayPicker.Value))
            {
                return;
            }
            if(!CheckAppointmentScheduleTimes(appointmentTimeStartPicker.Value, appointimeTimeEndPicker.Value))
            {
                return;
            }
            //generate new appointmentID
            int newAppointmentID = GenerateAppointmentID();
            //retrieve customer ID from dgv
            GetCustomerID();
            //retrieve userId from user database
            GetUserID();
            
            DBHelper.OpenConnection();
            MySqlConnection _connection = DBHelper.GetConnection();
            MySqlCommand command = _connection.CreateCommand();

            DateTime startDateAndTime = appointmentDayPicker.Value.Date + appointmentTimeStartPicker.Value.TimeOfDay;
            DateTime startConverted = startDateAndTime.ToUniversalTime();

            DateTime endDateAndTime = appointmentDayPicker.Value.Date + appointimeTimeEndPicker.Value.TimeOfDay;
            DateTime endDateConverted = endDateAndTime.ToUniversalTime();

            DateTime dt = DateTime.UtcNow;

            command.CommandText = "INSERT INTO appointment (appointmentId, customerId, userId, title," +
                "description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (@appointmentID, @customerID, @userID, @title, @description, @location, @contact, @type, @url, @start," +
                "@end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

            command.Parameters.AddWithValue("@appointmentID", newAppointmentID);
            command.Parameters.AddWithValue("@customerID", _customerID); //Need to add value from DGV. 
            command.Parameters.AddWithValue("@userID", _userID);
            command.Parameters.AddWithValue("@title", "not needed");
            command.Parameters.AddWithValue("@description", "not needed");
            command.Parameters.AddWithValue("@location", "not needed");
            command.Parameters.AddWithValue("@contact", "not needed");
            command.Parameters.AddWithValue("@type", appointmentTypeTextBox.Text.Trim());
            command.Parameters.AddWithValue("@url", "not needed");
            command.Parameters.AddWithValue("@start", startConverted);
            command.Parameters.AddWithValue("@end", endDateConverted);
            command.Parameters.AddWithValue("@createDate", dt);
            command.Parameters.AddWithValue("@createdBy", DBHelper.GetCurrentUser());
            command.Parameters.AddWithValue("@lastUpdate", dt);
            command.Parameters.AddWithValue("@lastUpdateBy", DBHelper.GetCurrentUser());

            command.ExecuteNonQuery();

            base.PopulateCustomerGrid();
            _appointmentForm.UpdateCustomerForm();
            _appointmentForm.UpdateAppointmentsByMonth();
            this.Close();
            // MessageBox.Show("This is from the child Add Appointment form");
        }

        private void GetUserID()
        {
            //Access userID from user database
            MySqlConnection _connection = DBHelper.GetConnection();
            MySqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT userId FROM user WHERE userName=@userName";
            command.Parameters.AddWithValue("@userName", DBHelper.GetCurrentUser());

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    _userID = (int)reader["userId"];
                }
            }

            reader.Close();


        }
        
        private void GetCustomerID()
        {

    
            foreach (DataGridViewRow row in customerDataGridView.Rows)
            {

                if(row.Selected)
                {
                    _customerID = Int32.Parse(row.Cells[0].Value.ToString()); 
                }

                
           
            }
        }

        private int GenerateAppointmentID()
        {
            
            int id = 0;
            MySqlConnection _connection = DBHelper.GetConnection();
            //connection.Open();
            MySqlCommand command = _connection.CreateCommand();
            //Get the last ID added in customer DB 
            command.CommandText = "SELECT appointmentId FROM appointment ORDER BY appointmentId DESC LIMIT 1";

            MySqlDataReader reader = command.ExecuteReader();



            while (reader.Read())
            {
                id = (int)reader["appointmentId"];

            }

            reader.Close();

            // MessageBox.Show(_newCustomerID.ToString(), "Before the increment");

            return id + 1;

           
        }
    }
}
