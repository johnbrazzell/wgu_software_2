using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wgu_software_2
{
    public partial class AddCustomerForm : Form
    {
        int _newCustomerID;
        int _newAddressID;
        bool _activeCustomer;
        MySqlConnection _connection;
        public AddCustomerForm()
        {
            InitializeComponent();
            
        }

        //Need function to add the address first and return the address ID to add to customer record

        private void saveButton_Click(object sender, EventArgs e)
        {
            //AddNewAddress();
            if(yesRadioButton.Checked)
            {
                _activeCustomer = true;
            }
            else if(noRadioButton.Checked)
            {
                _activeCustomer = false;
            }
                
            AddNewCustomer();
        }

        private void AddNewCustomer()
        {
            //Fields to add from form
            //Name 
            //Address 1
            //Address 2
            //Postal Code
            //Phone
            //Active Customer - selectable by radio button
            //Country - selectable in drop down
            //City - selectable in drop down
            //get the data in the text fields
            //create a new record in the customer database
            //add information into customer database
            //create new record in address database
            //INSERT INTO 'table name' (column1, column2, ...)
            //VALUES (value1, value2, ...)
            DBHelper.OpenConnection();

            _newAddressID = GetNewAddressID();
            _newCustomerID = GetNewCustomerID();

            _connection = DBHelper.GetConnection();
            //MySqlConnection connection = DBHelper.GetConnection();
            MySqlCommand command = _connection.CreateCommand();

            DateTime dt = DateTime.UtcNow;

            //MessageBox.Show(_newCustomerID.ToString(), "After The Increment");

            command.CommandText = "INSERT INTO customer (customerId, customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES(@customerID, @customerName, @addressID, " +
                "@active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
            command.Parameters.AddWithValue("@customerID", _newCustomerID);
            command.Parameters.AddWithValue("@customerName", nameTextBox.Text);
            command.Parameters.AddWithValue("@addressID", _newAddressID);
            command.Parameters.AddWithValue("@active", _activeCustomer);
            command.Parameters.AddWithValue("@createDate", dt);
            command.Parameters.AddWithValue("@createdBy", "test");
            command.Parameters.AddWithValue("@lastUpdate", dt);
            command.Parameters.AddWithValue("@lastUpdateBy", "test");

            //command.Parameters.AddWithValue("@addressID", );
            //command.Parameters.AddWithValue("@")
            command.ExecuteNonQuery();
            
            //command.Parameters.AddWithValue("@password", password);
        }

        private void AddNewAddress()
        {
            _connection = DBHelper.GetConnection();
            MySqlCommand command = _connection.CreateCommand();
            command.CommandText = "INSERT INTO address (addressId, address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES" +
                "@addressID, @address, @address2, @cityID, @postalCode, @phone, @lastUpdate, @lastUpdateBy)";

            //need to add the address first, return the ID and store it to link to

        }

        private int GetNewAddressID()
        {
            int id = 0;
            _connection = DBHelper.GetConnection();
            MySqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT addressId FROM address ORDER BY addressId DESC LIMIT 1";
            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                id = (int)reader["addressId"];
            }
            reader.Close();

            MessageBox.Show(id.ToString());
            return id + 2;
        }

        private int GetNewCustomerID()
        {
            //access the customer table
            //parse the ID's
            //return last ID + 1
            //SELECT customerID FROM customer ORDERBY customerID DESC LIMIT 1
            //parse the ID to int
            //return the ID + 1 to assign new customer ID for new record
            int id = 0;
            MySqlConnection connection = DBHelper.GetConnection();
            //connection.Open();
            MySqlCommand command = connection.CreateCommand();
            //Get the last ID added in customer DB 
            command.CommandText = "SELECT customerId FROM customer ORDER BY customerId DESC LIMIT 1";

            MySqlDataReader reader = command.ExecuteReader();

           

            while(reader.Read())
            {
                id = (int)reader["customerId"];
              
            }

            reader.Close();

           // MessageBox.Show(_newCustomerID.ToString(), "Before the increment");

            return id + 2;
        }
    }
}
