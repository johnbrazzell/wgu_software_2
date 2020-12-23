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

            
            UpdateCustomerForm();
           // MySqlDataReader reader = DBHelper.ExecuteQuery("test");
        }

        public void UpdateCustomerForm()
        {
            customerGridView.Refresh();
            customerGridView.Update();
            PopulateDataGridViews();
        }

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

        }

        private void appointmentFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //use this function to change the filter method
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
    }
}
