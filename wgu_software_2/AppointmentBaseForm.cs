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
            appointmentTimeStartPicker.Format = DateTimePickerFormat.Time;
            appointmentTimeStartPicker.ShowUpDown = true;
            appointimeTimeEndPicker.Format = DateTimePickerFormat.Time;
            appointimeTimeEndPicker.ShowUpDown = true;

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

        }
    }
}
