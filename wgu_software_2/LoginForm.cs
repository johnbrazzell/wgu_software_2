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
            MessageBox.Show(_userTimeZone.StandardName.ToString());
            
            if(_currentCulture == "en-US")
            {
                usernameLabel.Text = "Username:";
                passwordLabel.Text = "Password:";
                _usernameAndPasswordWarning = "Invalid username and password.";
            }
            else if(_currentCulture == "es-US")
            {
                usernameLabel.Text = "Nombre de usuario:";
                passwordLabel.Text = "Contraseña";
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
                MessageBox.Show("Login Successful!");
                //if login is successful then stamp time with user information
                LoginStamp(_docPath, usernameTextBox.Text);
                appointmentForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(_usernameAndPasswordWarning);
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
                    textOutputFile.WriteLine("[User:]" + userInfo + "\t" + " [Login Timestamp:]" + convertedLocalTime.ToString());//DateTime.Now.ToString()) ;
                }
            }
        }
    }
}
