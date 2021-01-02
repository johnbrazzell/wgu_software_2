using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace wgu_software_2
{
    public partial class LoginForm : Form
    {
        AppointmentForm appointmentForm = new AppointmentForm();

        //support spanish-US (es-US) and english-US (en-US)

        private string _currentCulture;
        private string _usernameAndPasswordWarning;
        private TimeZone _userTimeZone;
        private string _docPath = Environment.CurrentDirectory;
        
        public LoginForm()
        {
            InitializeComponent();
            _currentCulture = CultureInfo.CurrentCulture.Name;
            _userTimeZone = TimeZone.CurrentTimeZone;
            //MessageBox.Show(_userTimeZone.StandardName.ToString());
            
            if(_currentCulture == "en-US")
            {
                usernameLabel.Text = "Username:";
                passwordLabel.Text = "Password:";
                loginButton.Text = "Login";
                _usernameAndPasswordWarning = "Invalid username and password.";
            }
            else if(_currentCulture == "es-US")
            {
                usernameLabel.Text = "Nombre de usuario:";
                passwordLabel.Text = "Contraseña";
                loginButton.Text = "Iniciar sesión";
                _usernameAndPasswordWarning = "Nombre de usuario y contraseña inválidos";
            }

            
        }

        

        private void loginButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Login button pressed!");
            DBHelper.OpenConnection();
            bool loginSuccess = DBHelper.VerifyLogin(usernameTextBox.Text, passwordTextBox.Text);
            if(loginSuccess)
            {
                //Set the _currentUser in DBhelper
                DBHelper.SetCurrentUser(usernameTextBox.Text.Trim());
                if(_currentCulture == "en-US")
                    MessageBox.Show("Login Successful!");
                if (_currentCulture == "es-US")
                    MessageBox.Show("Inicio de sesión exitoso");
                //if login is successful then stamp time with user information
                LoginStamp(_docPath, usernameTextBox.Text);
                appointmentForm.Show();
                //check for appointments
                //check if currenttime/date - first appointment <= 15 minutes
                //display alert
                AppointmentAlert();
                this.Hide();
                //this.Close();
            }
            else
            {
                MessageBox.Show(_usernameAndPasswordWarning);
                return;
            }
            DBHelper.CloseConnection();
           

        }

        private void LoginStamp(string documentPath, string userInfo)
        {
            //Check if file has already been created by a previous login and if so open that file
            //and append new timestamp to it
            //else create the file and append timestamp

           // DateTime offset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);
            DateTime convertedLocalTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Local);
            if (File.Exists(Environment.CurrentDirectory + "/LoginFile.txt"))
            {
                using(StreamWriter appendText = File.AppendText(Environment.CurrentDirectory + "/LoginFile.txt"))
                {
                    appendText.WriteLine("[User:]" + userInfo + "\t" + " [Login Timestamp:]" + convertedLocalTime.ToString());//DateTime.Now.ToString());
                }
                //MessageBox.Show("file already exists");
            }
            else
            {
                using (StreamWriter textOutputFile = new StreamWriter(Path.Combine(documentPath, "LoginFile.txt")))
                {
                    textOutputFile.WriteLine("[User:]" + userInfo + "\t" + " [Login Timestamp Local:]" + convertedLocalTime.ToString());//DateTime.Now.ToString()) ;

                }
            }
        }

        private void AppointmentAlert()
        {
            DateTime dt = DateTime.Now;
            DBHelper.OpenConnection();
            MySqlConnection connection = DBHelper.GetConnection();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM appointment WHERE MONTH(start)=@month AND YEAR(start)=@year AND DAY(start)=@day";
            command.Parameters.AddWithValue("@month", dt.Month);
            command.Parameters.AddWithValue("@year", dt.Year);
            command.Parameters.AddWithValue("@day", dt.Day);
            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                DateTime d = (DateTime)reader["start"];
                d = d.ToLocalTime();
                TimeSpan diff = d.Subtract(dt);
                //MessageBox.Show(d.ToString());
                //MessageBox.Show(diff.ToString());

                if(diff.Minutes <= 15 && diff.Minutes >= 0)
                {
                    if (_currentCulture == "en-US")
                    {
                        MessageBox.Show("You have an appointment soon! \n" +
                            "AppointmentID: " + reader["appointmentId"].ToString() + 
                            "\nCustomerID: " + reader["customerId"].ToString() +
                            "\nAppointment Time: " + d.ToString() +
                            "\nAppointment Type: " + reader["type"].ToString());

                    }
                    else if(_currentCulture == "es-US")
                    {
                        MessageBox.Show("¡Tienes una cita pronto! \n" +
                            "Cita ID: " + reader["appointmentId"].ToString() +
                            "\nCliente ID: " + reader["customerId"].ToString() +
                            "\nHora de la cita: " + d.ToString() +
                            "\nTipo de cita: " + reader["type"].ToString());
                    }
                }

            }

            reader.Close();
            DBHelper.CloseConnection();
        }
    }
}
