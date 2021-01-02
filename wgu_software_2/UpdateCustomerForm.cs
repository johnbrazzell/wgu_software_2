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
    public partial class UpdateCustomerForm : Form
    {

        bool _activeCustomer;
        MySqlConnection _connection;
        AppointmentForm appointmentForm;

        List<string> _countryList = new List<string>() { "US", "Canada", "Norway" };
        List<string> _cityList = new List<string>() { "New York", "Los Angeles", "Toronto", "Vancouver", "Oslo" };

        int _addressID = 0;
        int _customerID = 0;
        public UpdateCustomerForm(int id)
        {
            InitializeComponent();
            DBHelper.OpenConnection();
            _connection = DBHelper.GetConnection();
            appointmentForm = Application.OpenForms["AppointmentForm"] as AppointmentForm;


            //load data using the id provided
            _customerID = id;
            //Update the comboBoxes with list values
            countryComboBox.Items.Clear();
            //countryComboBox.Items.Add(_countryList);

            //Used lambda expression here with list just to lessen the typing
            //rather than using a standard loop this does the loop and adds
            //all of the countries to the list in one line rather than multiple
            _countryList.ForEach(country => countryComboBox.Items.Add(country));

            cityComboBox.Items.Clear();

            MySqlCommand command = _connection.CreateCommand();
            
            command.CommandText = "SELECT * FROM customer WHERE customerId = @id";
            command.Parameters.AddWithValue("@id", id);

            MySqlDataReader customerReader = command.ExecuteReader();
            bool activeCustomer;
            //int addressID = 0;
            int cityID = 0;
            int countryID = 0;
            string city = "";
            
            //read information from customer and populate form with information
            if(customerReader.HasRows)
            {
                if (customerReader.Read())
                {
                    nameTextBox.Text = customerReader["customerName"].ToString();
                    bool p = Boolean.TryParse(customerReader["active"].ToString(), out activeCustomer);

                    if (p)
                    {
                        if (activeCustomer)
                        {
                            yesRadioButton.Checked = true;
                        }
                        else
                        {
                            noRadioButton.Checked = false;
                        }
                    }

                    //bool n = Int32.TryParse(reader["addressId"].ToString(), out addressID);
                    _addressID = (int)customerReader["addressId"];

                    MessageBox.Show("Address ID for Update: " + _addressID);
                    customerReader.Close();

               
                }
            }

            
           // MessageBox.Show("Address ID: " + addressID.ToString());
            //read information from address and populate form
            command.CommandText = "SELECT * FROM address WHERE addressId = @addressID";
            command.Parameters.AddWithValue("@addressID", _addressID);
            //MessageBox.Show("AddressID as parameter" + addressID);
            MySqlDataReader addressReader = command.ExecuteReader();

            if(addressReader.HasRows)
            {
                if(addressReader.Read())
                {
                    addressTextBox.Text = addressReader["address"].ToString();
                    address2TextBox.Text = addressReader["address2"].ToString();
                    postalCodeTextBox.Text = addressReader["postalCode"].ToString();
                    phoneTextBox.Text = addressReader["phone"].ToString();
                    cityID = (int)addressReader["cityId"];
                }

                
            }
            addressReader.Close();


            command.CommandText = "SELECT * FROM city WHERE cityId = @cityID";
            command.Parameters.AddWithValue("@cityID", cityID);
            MySqlDataReader cityReader = command.ExecuteReader();

            if(cityReader.HasRows)
            {
                if(cityReader.Read())
                {
                    countryID = (int)cityReader["countryId"];
                    city = cityReader["city"].ToString();
                    
                }

            }
            cityReader.Close();

            command.CommandText = "SELECT * FROM country WHERE countryId = @countryID";
            command.Parameters.AddWithValue("@countryID", countryID);
            MySqlDataReader countryReader = command.ExecuteReader();

            if (countryReader.HasRows)
            {
                if (countryReader.Read())
                {
                    string country = countryReader["country"].ToString();
                    countryComboBox.SelectedItem = country;
                    cityComboBox.SelectedItem = city;
                }
            }




        }


        

        private void saveButton_Click(object sender, EventArgs e)
        {

            if (!ValidateCustomerForm())
            {
                return;
            }

            DateTime dt = DateTime.UtcNow;
            string dateString = dt.ToShortDateString();

            try
            {

                dt = DateTime.Parse(dateString);
            }
            catch(FormatException)
            {
                MessageBox.Show("Unable to format parse date string");
            }
       
            UpdateAddress(dt);
            UpdateCustomer(dt);

            appointmentForm.UpdateCustomerForm();
    
            this.Close();
           
        }

        private void UpdateAddress(DateTime date)
        {

            DBHelper.OpenConnection();
            _connection = DBHelper.GetConnection();
 
            MySqlCommand command = _connection.CreateCommand();

          

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
            
            command.CommandText = "UPDATE address SET address=@address, address2=@address2, cityId=@cityID, postalCode=@postalCode," +
                "phone=@phone, lastUpdate=@lastUpdate, lastUpdateBy=@lastUpdateBy WHERE addressId=@addressID";
            command.Parameters.AddWithValue("@addressID", _addressID);
            command.Parameters.AddWithValue("@address", addressTextBox.Text.Trim());
            command.Parameters.AddWithValue("@address2", address2TextBox.Text.Trim());
            command.Parameters.AddWithValue("@cityID", _cityID);
            command.Parameters.AddWithValue("@postalCode", postalCodeTextBox.Text.Trim());
            command.Parameters.AddWithValue("@phone", phoneTextBox.Text.Trim());
            command.Parameters.AddWithValue("@lastUpdateBy", "test");
            command.Parameters.AddWithValue("@lastUpdate", date);
    
            command.ExecuteNonQuery();
         
        }

        private void UpdateCustomer(DateTime date)
        {
           

            MySqlCommand command = _connection.CreateCommand();



            command.CommandText = "UPDATE customer SET customerName=@customerName, active=@active, lastUpdate=@lastUpdate, lastUpdateBy=@lastUpdateBy " +
                "WHERE customerId=@customerID";
            command.Parameters.AddWithValue("@customerID", _customerID);
            command.Parameters.AddWithValue("@customerName", nameTextBox.Text);
      
            if(yesRadioButton.Checked)
            {
                command.Parameters.AddWithValue("@active", yesRadioButton.Checked);

            }
            else
            {
                command.Parameters.AddWithValue("@active", noRadioButton.Checked);
            }

        

            command.Parameters.AddWithValue("@lastUpdateBy", "test");
            command.Parameters.AddWithValue("@lastUpdate", date);

            

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
            switch (countryComboBox.SelectedIndex)
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


        private bool ValidateCustomerForm()
        {
            //check if forms are empty or if
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Name field cannot be empty.");
                return false;
            }

            bool nameTextHasNumbers = nameTextBox.Text.Any(x => char.IsNumber(x));

            if (nameTextHasNumbers)
            {
                MessageBox.Show("Name field cannot have numbers.");
                return false;
            }

            if (String.IsNullOrEmpty(addressTextBox.Text))
            {
                MessageBox.Show("Address field cannot be empty.");
                return false;
            }


            if (String.IsNullOrEmpty(postalCodeTextBox.Text))
            {
                MessageBox.Show("Postal code field cannot be empty.");
                return false;
            }

            bool phoneTextHasLetters = phoneTextBox.Text.Any(x => char.IsLetter(x));

            if (phoneTextHasLetters)
            {
                MessageBox.Show("Phone field cannot have letters.");
                return false;
            }

            if (String.IsNullOrEmpty(phoneTextBox.Text))
            {
                MessageBox.Show("Phone field cannot be empty.");
                return false;
            }

            if (!yesRadioButton.Checked && !noRadioButton.Checked)
            {
                MessageBox.Show("Active customer selected cannot be blank.");
                return false;
            }

            if (countryComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Country must be selected.");
                return false;
            }

            if (cityComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("City must be selected.");
                return false;
            }


            return true;
        }
    }
}
