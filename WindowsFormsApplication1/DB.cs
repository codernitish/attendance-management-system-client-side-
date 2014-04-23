using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Configuration;
namespace WindowsFormsApplication2
{
    class DB
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DB()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            string server;
            string database;
            string uid;
            string password;
            server = ConfigurationManager.AppSettings["server"];
            database = ConfigurationManager.AppSettings["db_name"];
            uid = ConfigurationManager.AppSettings["db_id"];
            password = (ConfigurationManager.AppSettings["db_pass"]=="")?"" : Secure.Decrypt(ConfigurationManager.AppSettings["db_pass"]);
            string connectionString;
            connectionString = "Server=" + server + ";" + "Database=" + database + ";" + "Uid=" + uid + ";" + "Pwd=" + password + ";";


            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                throw;
                
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

    }
}