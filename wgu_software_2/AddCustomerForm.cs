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
        AppointmentForm appointmentForm;

        // Country list - 1 US, 2 Canada, 3 Norway
        // City List - 1 New York, 2 Los Angeles, 3 Toronto, 4 Vancouver, 5 Oslo

        List<string> _countryList = new List<string>() {"US", "Canada", "Norway" };
        List<string> _cityList = new List<string>() { "New York", "Los Angeles", "Toronto", "Vancouver", "Oslo" };

        public AddCustomerForm()
        {
            InitializeComponent();
            DBHelper.OpenConnection();
            _connection = DBHelper.GetConnection();

            //Update the comboBoxes with list values
            countryComboBox.Items.Clear();
            //countryComboBox.Items.Add(_countryList);
            _countryList.ForEach(country => countryComboBox.Items.Add(country)); //Used this format instead of looping or adding items individually
            
            cityComboBox.Items.Clear();
            //refresh datagridview
            appointmentForm = Application.OpenForms["AppointmentForm"] as AppointmentForm;
        }

        //Need function to add the address first and return the address ID to add to customer record

        private void saveButton_Click(object sender, EventArgs e)
        {

            AddNewAddress();
            AddNewCustomer();

            appointmentForm.UpdateCustomerForm();
            //Refresh DataGridView
           // MySqlCommand cmd = 
            this.Close();
           
        }

        private void AddNewAddress()
        {

            DBHelper.OpenConnection();
            _newAddressID = GetNewAddressID();
            _newCustomerID = GetNewCustomerID();

            _connection = DBHelper.GetConnection();
            //MySqlConnection connection = DBHelper.GetConnection();
            MySqlCommand command = _connection.CreateCommand();

            DateTime dt = DateTime.UtcNow;

            int _cityID = 0;

            switch (cityComboBox.Text)
            {
                case "New York":
                    _cityID = 1;
                    break;
                case "Los Angeles":
                    _cityID = 2;
                    break;
                case "Toronto":
                    _cityID = 3;
                    break;
                case "Vancouver":
                    _cityID = 4;
                    break;
                case "Oslo":
                    _cityID = 5;
                    break;
                default:
                    Console.WriteLine("default case");
                    break;

            }
            //Address DB Fields
            //addressId
            //address2
            //cityId
            //postalCode
            //phone
            //createDate
            //createdBy
            //lastUpdate
            //lastUpdateBy
            command.CommandText = "INSERT INTO address (addressId, address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy)" +
                "VALUES (@addressID, @address, @address2, @cityID, @postalCode, @phone, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

            command.Parameters.AddWithValue("@addressID", _newAddressID);
            command.Parameters.AddWithValue("@address", addressTextBox.Text.Trim());
            command.Parameters.AddWithValue("@address2", address2TextBox.Text.Trim());
            command.Parameters.AddWithValue("@cityID", _cityID);
            command.Parameters.AddWithValue("@postalCode", postalCodeTextBox.Text.Trim());
            command.Parameters.AddWithValue("@phone", phoneTextBox.Text.Trim());
            command.Parameters.AddWithValue("@createDate", dt);
            command.Parameters.AddWithValue("@createdBy", "test");
            command.Parameters.AddWithValue("@lastUpdate", dt);
            command.Parameters.AddWithValue("@lastUpdateBy", "test");
          
            command.ExecuteNonQuery();
            
            //command.Parameters.AddWithValue("@password", password);
        }

        private void AddNewCustomer()
        {
            int addressID = 0;
            DateTime createDate = new DateTime();
            DateTime lastUpdate = new DateTime();
            string createUser = "";
            string updateUser = "";

            
            MySqlCommand command = _connection.CreateCommand();

      
            command.CommandText = "SELECT addressId, createDate, createdBy, lastUpdate, lastUpdateBy FROM address WHERE addressId = @id";
            command.Parameters.AddWithValue("@id", _newAddressID);

            MySqlDataReader reader = command.ExecuteReader();

          
                if (reader.Read())
                {
                    bool p = Int32.TryParse(reader["addressId"].ToString(), out addressID);
                    createDate = (DateTime)reader["createDate"];
                    createUser = reader["createdBy"].ToString();
                    lastUpdate = (DateTime)reader["lastUpdate"];
                    updateUser = reader["lastUpdateBy"].ToString();
                }
            

            reader.Close();

   

      
            command.CommandText = "INSERT INTO customer (customerId, customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES(@customerID, @customerName, @addressID," +
           "@active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
            command.Parameters.AddWithValue("@customerID", _newCustomerID);
            command.Parameters.AddWithValue("@customerName", nameTextBox.Text);
            command.Parameters.AddWithValue("@addressID", _newAddressID);
            command.Parameters.AddWithValue("@active", _activeCustomer);
            command.Parameters.AddWithValue("@createDate", createDate);
            command.Parameters.AddWithValue("@createdBy", createUser);
            command.Parameters.AddWithValue("@lastUpdate", lastUpdate);
            command.Parameters.AddWithValue("@lastUpdateBy", updateUser);



            command.ExecuteNonQuery();
      

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
                bool parseResult = Int32.TryParse(reader["addressId"].ToString(), out id); 
            }
            reader.Close();

            MessageBox.Show(id.ToString());
            return id + 1;
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

            return id + 1;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void yesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(yesRadioButton.Checked)
            {
                _activeCustomer = true;
            }
        }

        private void noRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(noRadioButton.Checked)
            {
                _activeCustomer = false;
            }
        }

        private void countryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(countryComboBox.SelectedIndex)
            {
                case 0:
                    //Make sure only US cities are available to select
                    cityComboBox.Items.Clear();
                    cityComboBox.Items.Add(_cityList[0]);
                    cityComboBox.Items.Add(_cityList[1]);
                    
                    break;
                case 1:
                    cityComboBox.Items.Clear();
                    cityComboBox.Items.Add(_cityList[2]);
                    cityComboBox.Items.Add(_cityList[3]);
                    break;
                case 2:
                    cityComboBox.Items.Clear();
                    cityComboBox.Items.Add(_cityList[4]);
                    break;
            }
        }

        private void cityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
