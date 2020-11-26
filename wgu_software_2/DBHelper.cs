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
        public static MySqlConnection connection;
        static public void OpenConnection()
        {
            MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder();
            connectionString.Server = "wgudb.ucertify.com";
            connectionString.UserID = "U059ub";
            connectionString.Port = 3306;
            connectionString.Database = "U059ub";
            connectionString.Password = "53688442061";

            connection = new MySqlConnection(connectionString.ToString());
            

            if (connection.State.ToString() == "Open")
            {
                //MessageBox.Show("Connection is open");   
                return;
            }
            else
            {
                try
                {

                    connection.Open();
                    
                }
                catch (MySqlException e)
                {
                    MessageBox.Show(e.Message);
                }

            }
        }

        static public void VerifyLogin()
        {

        }
    }
}
