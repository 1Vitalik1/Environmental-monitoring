using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Environmental_monitoring
{
    internal class Database
    {
        static string server = "localhost";
        static string port = "3306";
        static string dataBase = "environmental-monitoring";
        static string uid = "root";
        static string pwd = "root";
        static string connect = ($"Server={server};Port={port};Database={dataBase};Uid={uid};Pwd={pwd};");
        static MySqlConnection mysql_connection = new MySqlConnection(connect);
        static MySqlConnection connection = new MySqlConnection(connect);

        public bool ConnectToDatabase()
        {
            try
            {
                connection.Open();
                
                return true;
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        public string readAllAccounts()
        {
            Collection<string> users = new Collection<string>();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;
            command.CommandText = "SELECT * FROM `employee`";
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                string thisrow = "";
                for (int i = 0; i < Reader.FieldCount; i++)
                    thisrow += Reader.GetValue(i).ToString() + ";";
                return thisrow;
            }
            return null;
        }


    }

    class user
    {
        public int id;
        public string login;
        public string password;
        public string lastName;
        public string firstName;
        public string surName;
        public decimal phonenumber;
    }
}
