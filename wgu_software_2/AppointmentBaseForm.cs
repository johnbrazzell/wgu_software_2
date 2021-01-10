using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Windows.Forms;

namespace wgu_software_2
{
    public partial class AppointmentBaseForm : Form
    {
        private DataSet _customerDataSet;
        private MySqlDataAdapter _adapter;
        private MySqlConnection _connection;

        protected DateTime _startTime;
        protected DateTime _endTime;
        protected DateTime _selectedDay;

        public AppointmentBaseForm()
        {
            InitializeComponent();

            //Set start and end time picker to only show times
            appointmentTimeStartPicker.Format = DateTimePickerFormat.Custom;
            appointmentTimeStartPicker.CustomFormat = "hh:mm tt";
            appointmentTimeStartPicker.ShowUpDown = true;
            appointimeTimeEndPicker.Format = DateTimePickerFormat.Custom;
            appointimeTimeEndPicker.ShowUpDown = true;
            appointimeTimeEndPicker.CustomFormat = "hh:mm tt";

            _startTime = appointmentTimeStartPicker.Value;
            _endTime = appointimeTimeEndPicker.Value;
            _selectedDay = appointmentDayPicker.Value;

            //need to load customer data into datagridview
            PopulateCustomerGrid();


        }

        protected void PopulateCustomerGrid()
        {
            //Open connection and get reference to connection
            DBHelper.OpenConnection();
            _connection = DBHelper.GetConnection();

            _customerDataSet = null;
            _customerDataSet = new DataSet();
            _adapter = new MySqlDataAdapter("SELECT customerId, customerName, active FROM customer", _connection);
            _adapter.Fill(_customerDataSet);
            this.customerDataGridView.DataSource = _customerDataSet.Tables[0];
            //_customerDataSet.AsEnumerable.where
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }


        protected bool CheckAppointmentScheduleTimes(DateTime start, DateTime end)
        {
            if(start.TimeOfDay < TimeSpan.FromHours(9))
            {
                MessageBox.Show("Start time cannot be before\n" +
                    "opening business hours (9am)");
                return false;
            }
            else if(start.TimeOfDay > TimeSpan.FromHours(17))
            {
                MessageBox.Show("Start time cannot be after\n" +
                    "closing business hours (5pm)");
                return false;
            }
            else if(end.TimeOfDay < TimeSpan.FromHours(9))
            {
                MessageBox.Show("End time cannot be before\n" +
                    "opening business hours (9am)");
                return false;
            }
            else if(end.TimeOfDay > TimeSpan.FromHours(17))
            {
                MessageBox.Show("End time cannot be after\n" +
                    "closing business hours (5pm)");
                return false;
            }
            else if(end.TimeOfDay < start.TimeOfDay)
            {
                MessageBox.Show("End time cannot be less than Start time");
                return false;
            }
            else if(start.TimeOfDay > end.TimeOfDay)
            {
                MessageBox.Show("Start time of day cannot be greater than End Time");
                return false;
            }
            else if(String.IsNullOrEmpty(appointmentTypeTextBox.Text))
            {
                MessageBox.Show("Appointment Type cannot be blank");
                return false;
            }
            else
            {
                return true;
            }

         
        }

        protected bool CheckAppointmentOverlapTimes(DateTime start, DateTime end, DateTime day)
        {

            
            //DBHelper.OpenConnection();
            //_connection = DBHelper.GetConnection();
            MySqlCommand command = _connection.CreateCommand();

          
          
        
            //if start is less than compared start
            //|| start.TimeOfDay <= xStart.TimeOfDay
            // Func<DateTime, DateTime, bool> isOverlap = (xStart, yEnd) => start.TimeOfDay <= yEnd.TimeOfDay && end.TimeOfDay >= xStart.TimeOfDay;
            //get all the values based on the new selected appointment date
            //command.CommandText = "SELECT start, end FROM appointment WHERE MONTH(start)=@month AND DAY(start)=@day AND YEAR(start)=@year";
            command.CommandText = "SELECT * FROM appointment WHERE MONTH(start)=@month AND DAY(start)=@day AND YEAR(start)=@year";
            command.Parameters.AddWithValue("@month", _selectedDay.Month);
            command.Parameters.AddWithValue("@day", _selectedDay.Day);
            command.Parameters.AddWithValue("@year", _selectedDay.Year);

            //MessageBox.Show("SelectedDate: " + day.Date.ToString());
            //MessageBox.Show(day.ToString());
            // command.Parameters.AddWithValue("@year", day.Year);
            //MessageBox.Show(day.Month.ToString());
            start = start.ToUniversalTime();
            end = end.ToUniversalTime();

            MySqlDataReader reader = command.ExecuteReader();


            //Created lambda function to cut down on code - initially was storing dates in a list
            //and then looping through them. 
            Func<DateTime, DateTime, bool> isOverlap = (xStart, yEnd) => start.TimeOfDay < yEnd.TimeOfDay && xStart.TimeOfDay < end.TimeOfDay;

                while (reader.Read())
                {
                    //MessageBox.Show(reader["start"].ToString());
                    DateTime dbStart = (DateTime)reader["start"];
                    DateTime dbEnd = (DateTime)reader["end"];
                    
                
                    if (isOverlap(dbStart, dbEnd))
                    {
                        
                        //MessageBox.Show("Start " + convertStart.TimeOfDay.ToString(), "End " + convertEnd.ToString());
                        MessageBox.Show("This appointment overlaps with another time.");
                        reader.Close();
                        return true;
                    }


                }
                reader.Close();

           
            return false;
            
        }

        private void appointmentTimeStartPicker_ValueChanged(object sender, EventArgs e)
        {
            _startTime = appointmentTimeStartPicker.Value.ToUniversalTime();
         
        }

        private void appointimeTimeEndPicker_ValueChanged(object sender, EventArgs e)
        {
           
            _endTime = appointimeTimeEndPicker.Value.ToUniversalTime();
          
        }

        private void appointmentDayPicker_ValueChanged(object sender, EventArgs e)
        {

            _selectedDay = appointmentDayPicker.Value;
        }
    }
}
