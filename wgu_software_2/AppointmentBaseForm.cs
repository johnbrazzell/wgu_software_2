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
    }
}
