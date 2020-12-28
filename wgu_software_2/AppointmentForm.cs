using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace wgu_software_2
{
    public partial class AppointmentForm : Form
    {

        MySqlDataAdapter _adapter;
        MySqlConnection _connection;
        DataSet _appointmentDataSet;
        DataSet _customerDataSet;
        public AppointmentForm()
        {
            InitializeComponent();
            appointmentFilterComboBox.SelectedIndex = 0;
            DBHelper.OpenConnection();
            
            _connection = DBHelper.GetConnection();

            //set the appointment filter to month
            appointmentFilterComboBox.SelectedIndex = 0;

            UpdateAppointmentsByMonth();

            //CultureInfo cultureInfo = new CultureInfo("en-US");
            //calendar = cultureInfo.Calendar;
            UpdateCustomerForm();
            
           // MySqlDataReader reader = DBHelper.ExecuteQuery("test");
        }

        public void UpdateCustomerForm()
        {
            _customerDataSet = null;
            _customerDataSet = new DataSet();

            _adapter = new MySqlDataAdapter("SELECT * FROM customer", _connection);
            _adapter.Fill(_customerDataSet);
            this.customerGridView.DataSource = _customerDataSet.Tables[0];

            customerGridView.Refresh();
            customerGridView.Update();
            PopulateCustomerGridView();
        }

        public void UpdateAppointmentForm()
        {
            //_appointmentDataSet = null;
            //_appointmentDataSet = new DataSet();
           

            //_adapter = new MySqlDataAdapter("SELECT appointmentId, customerId, type, start, end FROM appointment", _connection);
            //_adapter.Fill(_appointmentDataSet);
            //this.appointmentDataGridView.DataSource = _appointmentDataSet.Tables[0];
        }


        private void PopulateCustomerGridView()
        {
           // _appointmentDataSet = null;
           // _appointmentDataSet = new DataSet();
            _customerDataSet = null;
            _customerDataSet = new DataSet();

            //_adapter = new MySqlDataAdapter("SELECT appointmentId, customerId, type, start, end FROM appointment", _connection);
            //_adapter.Fill(_appointmentDataSet);
            //this.appointmentDataGridView.DataSource = _appointmentDataSet.Tables[0];
           
            _adapter = new MySqlDataAdapter("SELECT * FROM customer", _connection);
            _adapter.Fill(_customerDataSet);
            this.customerGridView.DataSource = _customerDataSet.Tables[0];
            

        }

        private void calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            calendar.BoldedDates = null;
            //if the selection date has changed, check the filter combobox 
            //and change the list of the appointment grid view 
           // DateTime dt = new DateTime();
            if(appointmentFilterComboBox.Text == "Month")
            {
                UpdateAppointmentsByMonth();
            }

            if(appointmentFilterComboBox.Text == "Week")
            {

                UpdateAppointmentsByWeek();


            }


        }

        private void appointmentFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            calendar.BoldedDates = null;
      
            if(appointmentFilterComboBox.Text == "Month")
            {
                UpdateAppointmentsByMonth();
            }

            if(appointmentFilterComboBox.Text == "Week")
            {
                UpdateAppointmentsByWeek();
            }
        }

        private void customerGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            //open Add Customer Form
            AddCustomerForm addCustomerForm = new AddCustomerForm();
            addCustomerForm.Show();
        }

        private void addAppointmentButton_Click(object sender, EventArgs e)
        {
            AddAppointmentForm form = new AddAppointmentForm();

            form.Show();
        }

        private void updateCustomerButton_Click(object sender, EventArgs e)
        {

            int customerID;
            foreach (DataGridViewRow row in customerGridView.SelectedRows)
            {

                bool p = Int32.TryParse(row.Cells[0].Value.ToString(), out customerID);
        
                if(p)
                {
                    UpdateCustomerForm updateCustomer = new UpdateCustomerForm(customerID);
                    updateCustomer.Show();
                }
                else
                {
                    MessageBox.Show("Error retrieving customerID. Please contact your administrator.");
                }
                
               
            }

        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {

            int customerID;
            int addressID;

            foreach (DataGridViewRow row in customerGridView.SelectedRows)
            {
                bool p = Int32.TryParse(row.Cells[0].Value.ToString(), out customerID);
                bool q = Int32.TryParse(row.Cells[2].Value.ToString(), out addressID);

                if(p && q)
                {

                    DBHelper.OpenConnection();
                    MySqlCommand command = _connection.CreateCommand();
                    command.CommandText = "DELETE customer, address FROM customer, address WHERE customer.customerId=@customerID AND " +
                "address.addressId=@addressID";
                    command.Parameters.AddWithValue("@customerID", customerID);
                    command.Parameters.AddWithValue("@addressID", addressID);
                    command.ExecuteNonQuery();

                    UpdateCustomerForm();
                }
            }

        }

        private void appointmentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void updateAppointmentButton_Click(object sender, EventArgs e)
        {
            int appointmentID;
            int customerID;
            foreach (DataGridViewRow row in appointmentDataGridView.SelectedRows)
            {

                bool p = Int32.TryParse(row.Cells[0].Value.ToString(), out appointmentID);
                bool q = Int32.TryParse(row.Cells[1].Value.ToString(), out customerID);
                 
                if (p && q)
                {
                    UpdateAppointmentForm updateAppointmentForm = new UpdateAppointmentForm(appointmentID, customerID);
                    updateAppointmentForm.Show();
                }
                else
                {
                    MessageBox.Show("Error retrieving appointmentID. Please contact your administrator.");
                }
            }
        }

        private void deleteAppointmentButton_Click(object sender, EventArgs e)
        {

            int appointmentID;

            foreach (DataGridViewRow row in appointmentDataGridView.SelectedRows)
            {
                bool p = Int32.TryParse(row.Cells[0].Value.ToString(), out appointmentID);
                

                if (p)
                {

                    DBHelper.OpenConnection();
                    MySqlCommand command = _connection.CreateCommand();
                    command.CommandText = "DELETE appointment FROM appointment WHERE appointmentId=@appointmentID";
                    command.Parameters.AddWithValue("@appointmentID", appointmentID);
                  
                    command.ExecuteNonQuery();

                    UpdateCustomerForm();
                    UpdateAppointmentsByMonth();
                }
            }
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            DBHelper.CloseConnection();

            Application.Exit();
        

        }

        public void UpdateAppointmentsByMonth()
        {

            DBHelper.OpenConnection();
            _connection = DBHelper.GetConnection();

            DateTime d = calendar.SelectionRange.Start;

            List<DateTime> dtList = new List<DateTime>();

            MySqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT start FROM appointment";

            MySqlDataReader reader = command.ExecuteReader();

                

            while (reader.Read())
            {
                dtList.Add((DateTime)reader["start"]);
            }

            reader.Close();

            List<DateTime> allAppointments = dtList.FindAll(x => x.Month.Equals(d.Month) && x.Year.Equals(d.Year));

            //_appointmentDataSet.Clear();

            if (allAppointments.Count == 0)
            {
                this.appointmentDataGridView.DataSource = null;
                return;
            }
            else
            {
             
                this.appointmentDataGridView.DataSource = null;
                this.appointmentDataGridView.Rows.Clear();

           

                _appointmentDataSet = null;
                _appointmentDataSet = new DataSet();
              
                foreach (DateTime dateTime in allAppointments)
                {
                  

                    _adapter = null;
                    _adapter = new MySqlDataAdapter("SELECT appointmentId, customerId, type, start, end FROM appointment" +
                        " WHERE MONTH(start)=@month AND YEAR(start)=@year", _connection);
                    _adapter.SelectCommand.Parameters.AddWithValue("@month", d.Month);
                    _adapter.SelectCommand.Parameters.AddWithValue("@year", d.Year);

                }
                _adapter.Fill(_appointmentDataSet);
            }
            if (_appointmentDataSet == null)
            {
                this.appointmentDataGridView.Rows.Clear();
            }
            else
            {
                this.appointmentDataGridView.Refresh();
                this.appointmentDataGridView.Update();

                this.appointmentDataGridView.DataSource = _appointmentDataSet.Tables[0];

            }
        }

        public void UpdateAppointmentsByWeek()
        {
            //UpdateAppointmentsByWeek()
            //add week filter here
            //DateTime now = DateTime.Now;
            MySqlCommand command = _connection.CreateCommand();

            List<DateTime> weeklyAppointments = new List<DateTime>();
            DateTime d = calendar.SelectionRange.Start;
            //int day = d.Day;
            //if selection is not sunday
            //set day selection to sunday
            //iterate through the days until saturday
            //use these dates to select data

            // calendar.MaxSelectionCount = 7;

            //Get the users selected date, and iterate backwards to Sunday
            while (d.DayOfWeek.ToString() != "Sunday")
            {
                d = d.AddDays(-1);
                //MessageBox.Show(d.DayOfWeek.ToString());
            }

            //Now that we are at Sunday, iterate forward 
            //Select Monday-Friday
            //Add these dates to a list
            while (d.DayOfWeek.ToString() != "Friday")
            {
                // calendar.select

                //Add 1 and get to Monday
                d = d.AddDays(1);
                weeklyAppointments.Add(d.Date);
            }

            calendar.BoldedDates = weeklyAppointments.ToArray();

            //MessageBox.Show(weeklyAppointments.Count.ToString());
            if (weeklyAppointments.Count == 0)
            {
                this.appointmentDataGridView.DataSource = null;
                return;

            }
            else
            {
                this.appointmentDataGridView.DataSource = null;
                this.appointmentDataGridView.Rows.Clear();
            }

            _appointmentDataSet = null;
            _appointmentDataSet = new DataSet();
            _adapter = null;


            for(int i = 0; i < weeklyAppointments.Count; i++)
            {
                //if(weeklyAppointments[i] == )
                _adapter = new MySqlDataAdapter("SELECT appointmentId, customerId, type, start, end FROM appointment " +
                    "WHERE DATE(start)=@date", _connection);
                _adapter.SelectCommand.Parameters.AddWithValue("@date", weeklyAppointments[i]);
                _adapter.Fill(_appointmentDataSet);
            }
            

            if (_appointmentDataSet == null)
            {
                this.appointmentDataGridView.Rows.Clear();
            }
            else
            {
                this.appointmentDataGridView.Refresh();
                this.appointmentDataGridView.Update();

                this.appointmentDataGridView.DataSource = _appointmentDataSet.Tables[0];
            }


        }
    }
}
