using MySqlConnector;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace Environmental_monitoring
{
    /// <summary>
    /// Класс взаимодействия программы с БД
    /// Позволяет создавать обращения к БД удаление, редактирование и добавление различной информации
    /// </summary>
    internal class Database
    {
        public Collection<user> users = new Collection<user>();
        public Collection<report> reports = new Collection<report>();
        static string server = "localhost";
        static string port = "3306";
        static string dataBase = "environmental-monitoring";
        static string uid = "root";
        static string pwd = "root";
        static string connect = ($"Server={server};Port={port};Database={dataBase};Uid={uid};Pwd={pwd};");
        static MySqlConnection connection;
        static MySqlCommand command;
        static MySqlDataReader reader;
        public Database()
        {
            connection = new MySqlConnection(connect);
            try
            {
                connection.Open();
                command = connection.CreateCommand();
                authenticationUser();
                readAllReports();
            }
            catch (MySqlException ex) { /*Обработка исключений*/ }
        }

        public string statusConnectToDatabase()
        {
            if (connection.State == ConnectionState.Open) return "Подключение к БД успешно!";
            else if(connection.State == ConnectionState.Closed) return "Подключение к БД закрыто!";
            else return "Ошибка!"; 
        }
        public void authenticationUser()
        {
            int userIterator = 0;
            command.CommandText = "SELECT * FROM `employee`";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                long id = reader.GetInt64("id_employee");
                string login = reader.GetString("login");
                string password = reader.GetString("password");
                string lastName = reader.GetString("lastname");
                string firstName = reader.GetString("firstname");
                string surName = reader.GetString("surname");
                decimal phonenumber = reader.GetInt64("phonenumber");
                users.Add(new user(id, login, password, lastName, firstName, surName, phonenumber));
                userIterator++;
            }
        }

        public string addUser(string login, string password, string firstname, string lastname, string surname, string phonenumber)
        {
            
            try
            {
                reader.Close();
                command.CommandText = ($"INSERT INTO `employee` (`id_employee`, `Login`, `Password`, `Firstname`, `Lastname`, `Surname`, `Phonenumber`) VALUES ('0', '{login}', '{password}', '{firstname}', '{lastname}', '{surname}', '{phonenumber}')");
                command.ExecuteNonQuery();
                authenticationUser();
                return "Пользователь успешно создан!";
            }
            catch 
            {
                return "Извините произошла ошибка!";
            }
        }
        public string delUser(string id)
        {

            reader.Close();
            command.CommandText = ($"DELETE FROM `employee` WHERE `employee`.`Id_employee` = {id}");
            command.ExecuteNonQuery();
            authenticationUser();
            return "Пользователь удалён!";

        }

        public bool identification(string login, string password)
        {
            foreach(user user in users) if(user.login == login && user.password == password) return true;
            return false;
        }

        public void readAllReports()
        {
            int iterator = 0;
            reader.Close();
            command.CommandText = "SELECT * FROM `reports`";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                long id = reader.GetInt64("id_report");
                int airData = reader.GetInt32("id_AirData");
                int radioactiveData = reader.GetInt32("id_RadioactiveData");
                int soilData = reader.GetInt32("id_SoilData");
                int waterData = reader.GetInt32("id_WaterData");
                string description = reader.GetString("Description");
                DateTime date = reader.GetDateTime("Date");
                reports.Add(new report(id,date,description,airData,radioactiveData,soilData,waterData));
                iterator++;
            }
        }
        /// <summary>
        /// Позволяет считать данные из БД, в параметры передаётся комманда 
        /// </summary>
        /// <param name="commandText">Текст команды для считывания данных</param>
        /// <returns></returns>
        public string readData(string commandText)
        {
            reader.Close();
            command.CommandText = commandText;
            reader = command.ExecuteReader();
            string thisrow = "";
            while (reader.Read())
                for (int i = 0; i < reader.FieldCount; i++)
                    thisrow += reader.GetValue(i).ToString() + ";";
            return thisrow;
        }

    }
    class report
    {
        public long id { private set; get; }
        public DateTime date { private set; get; }
        public string description { private set; get; }
        public int airData { private set; get; }
        public int radioactiveData { private set; get; }
        public int soilData { private set; get; }
        public int waterData { private set; get; }

        public report(long id, DateTime date, string description, int airData, int radioactiveData, int soilData, int waterData)
        {
            this.id = id;
            this.date = date;
            this.description = description;
            this.airData = airData;
            this.radioactiveData = radioactiveData;
            this.soilData = soilData;
            this.waterData = waterData;
        }
    }
    /// <summary>
    /// Класс описывающий пользователя ИС
    /// </summary>
    class user
    {
        public long id { private set; get; }
        public string login { private set; get; }
        public string password { private set; get; }
        public string lastName { private set; get; }
        public string firstName { private set; get; }
        public string surName { private set; get; }
        public decimal phonenumber { private set; get; }

        public user(long id, string login, string password, string lastName, string firstName, string surName, decimal phonenumber)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.lastName = lastName;
            this.firstName = firstName;
            this.surName = surName;
            this.phonenumber = phonenumber;
        }
        public override string ToString() => ($"Номер: {id} | Имя: {lastName} | Фамилия: {firstName} | Отчество: {surName} | Номер телефона: {phonenumber} |");
    }
}
