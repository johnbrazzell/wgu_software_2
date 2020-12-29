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
            else
            {
                return true;
            }

            //return false;
        }

        protected bool CheckAppointmentOverlapTimes(DateTime start, DateTime end, DateTime day)
        {
            //we need to get the day of the scheduled appointment
            //we need to check the times against the other appointments for the same day
            //return error message if the appointments are overlapping
            //otherwise schedule the appointment

            //    return start1 < end2 && end1 > start2;

            //Func<DateTime, DateTime, bool> findOverlap

            //get list of dates for 
            DBHelper.OpenConnection();
            MySqlCommand command = _connection.CreateCommand();


            //Created lambda function to cut down on code - initially was storing dates in a list
            //and then looping through them.
            Func<DateTime, DateTime, bool> isOverlap = (xStart, yEnd) => start.TimeOfDay < yEnd.TimeOfDay || end.TimeOfDay > xStart.TimeOfDay ;

            //get all the values based on the new selected appointment date
            command.CommandText = "SELECT start, end FROM appointment WHERE DATE(start)=@date";
            command.Parameters.AddWithValue("@date", day.Date);

            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                DateTime dbStart = (DateTime)reader["start"];
                DateTime dbEnd = (DateTime)reader["end"];

                
                if(isOverlap(dbStart, dbEnd))
                {
                    MessageBox.Show("This appointment overlaps with another time.");
                    reader.Close();
                    return true;
                }
                

            }

            reader.Close();

            return false;
            
        }
    }
}
