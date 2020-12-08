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
        DataSet data = new DataSet();
        public AppointmentForm()
        {
            InitializeComponent();
            appointmentFilterComboBox.SelectedIndex = 0;
            DBHelper.OpenConnection();
            
            _connection = DBHelper.GetConnection();

            _adapter = new MySqlDataAdapter("SELECT * FROM appointment ", _connection);
            _adapter.Fill(data);
            this.appointmentDataGridView.DataSource = data.Tables[0];

           // MySqlDataReader reader = DBHelper.ExecuteQuery("test");
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
            //need to load data into this gridview
        }
    }
}
