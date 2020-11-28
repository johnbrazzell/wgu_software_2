using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                appointmentForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(_usernameAndPasswordWarning);
            }
            DBHelper.CloseConnection();
           

        }
    }
}
