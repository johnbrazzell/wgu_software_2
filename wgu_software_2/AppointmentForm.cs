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
            PopulateDataGridViews();
        }

        public void UpdateAppointmentForm()
        {
            _appointmentDataSet = null;
            _appointmentDataSet = new DataSet();
           

            _adapter = new MySqlDataAdapter("SELECT appointmentId, customerId, type, start, end FROM appointment", _connection);
            _adapter.Fill(_appointmentDataSet);
            this.appointmentDataGridView.DataSource = _appointmentDataSet.Tables[0];
        }

        //Need to separate from gridviews so I can filter the 
        private void PopulateDataGridViews()
        {
            _appointmentDataSet = null;
            _appointmentDataSet = new DataSet();
            _customerDataSet = null;
            _customerDataSet = new DataSet();

            _adapter = new MySqlDataAdapter("SELECT appointmentId, customerId, type, start, end FROM appointment", _connection);
            _adapter.Fill(_appointmentDataSet);
            this.appointmentDataGridView.DataSource = _appointmentDataSet.Tables[0];
           
            _adapter = new MySqlDataAdapter("SELECT * FROM customer", _connection);
            _adapter.Fill(_customerDataSet);
            this.customerGridView.DataSource = _customerDataSet.Tables[0];
            

        }

        private void calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            //if the selection date has changed, check the filter combobox 
            //and change the list of the appointment grid view 
            DateTime dt = new DateTime();

            if (appointmentFilterComboBox.Text == "Month")
            {
                //get the month, and populate all the appointments in the month.
                DateTime d = calendar.SelectionRange.Start;
                //Console.WriteLine(d.Month.ToString());
                MessageBox.Show(d.Month.ToString());
                List<DateTime> dtList = new List<DateTime>();

                MySqlCommand command = _connection.CreateCommand();

                command.CommandText = "SELECT start FROM appointment";

                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    dtList.Add((DateTime)reader["start"]);
                }

                reader.Close();

                List<DateTime> allAppointments = dtList.FindAll(x => x.Month.Equals(d.Month) && x.Year.Equals(d.Year));
                command.CommandText = "SELECT "

                foreach(DateTime dateTime in allAppointments)
                {
                    if(dateTime.Month == d.Month && dateTime.Year == d.Year)
                        MessageBox.Show(dateTime.ToString());

                }
                //_appointmentDataSet = null;
                //_appointmentDataSet = new DataSet();


               // _adapter = new MySqlDataAdapter("SELECT appointmentId, customerId, type, start, end FROM appointment WHERE start=@startMonth", _connection);
                
               // _adapter.Fill(_appointmentDataSet);
               // this.appointmentDataGridView.DataSource = _appointmentDataSet.Tables[0];
                //if ()

                //calendar.getwee
               // dt = calendar.
            }

            if(appointmentFilterComboBox.Text == "Week")
            {
                //add week filter here
            }

            //int week = (int)calendar.SelectionStart.DayOfWeek;
            //MessageBox.Show("Selected week: " + week.ToString());
        }

        private void appointmentFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
      
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
                }
            }
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            DBHelper.CloseConnection();

            Application.Exit();
        

        }
    }
}
