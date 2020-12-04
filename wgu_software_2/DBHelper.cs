using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace wgu_software_2
{
    /// <summary>
    /// Connection string Info: 
    /// Server: wgudb.ucertify.com
    /// User: U059ub
    /// Database: U059ub
    /// Port: 3306
    /// Password: 53688442061
    /// </summary>
    static class DBHelper
    {
        private static MySqlConnection _connection;

        
        public static MySqlConnection GetConnection()
        {
            return _connection;
        }
        static public void OpenConnection()
        {
            MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder();
            connectionString.Server = "wgudb.ucertify.com";
            connectionString.UserID = "U059ub";
            connectionString.Port = 3306;
            connectionString.Database = "U059ub";
            connectionString.Password = "53688442061";

            _connection = new MySqlConnection(connectionString.ToString());
            

            if (_connection.State.ToString() == "Open")
            {
                //MessageBox.Show("Connection is open");   
                return;
               
            }
            else
            {
                try
                {

                    _connection.Open();
                    
                }
                catch (MySqlException e)
                {
                    MessageBox.Show(e.Message, "Error occured when trying to open DB connection.");
                }

            }
        }

        
        static public void CloseConnection()
        {
            if(_connection.State.ToString() == "Closed")
            {
                return;
            }
            else
            {
                try
                {

                    if(_connection.State.ToString() == "Open")
                    {
                        _connection.Close();
                    }
                }
                catch(MySqlException e)
                {
                    MessageBox.Show(e.Message, "Error occured when trying to close DB connection.");

                }
            }
        }

        static public MySqlDataReader ExecuteQuery(string query)
        {
            MySqlCommand command = _connection.CreateCommand();
            command.CommandText = query;
            MySqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        static public bool VerifyLogin(string userName, string password)
        {
            
            MySqlCommand loginCheckCommand = _connection.CreateCommand();
            loginCheckCommand.CommandText = "SELECT * FROM user WHERE userName=@username AND password=@password";
            loginCheckCommand.Parameters.AddWithValue("@username", userName);
            loginCheckCommand.Parameters.AddWithValue("@password", password);

            MySqlDataReader loginReader = loginCheckCommand.ExecuteReader();

            if (loginReader.HasRows)
            {
                
                return true;
            }
            else
            {
           
                return false;
            }
            //while (loginReader.Read()) //need to check username and password
            //{
            //    if(loginReader["userName"].ToString() == userName)
            //    {
            //        if(loginReader["password"].ToString() ==  password)
            //        {
            //            MessageBox.Show("Login successful");
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Username or password is incorrect.");
            //    }
               
            //}

        }
    }
}
