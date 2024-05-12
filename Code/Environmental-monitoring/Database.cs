using MySqlConnector;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace Environmental_monitoring
{
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
        static MySqlDataReader Reader;

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
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                long id = Reader.GetInt64("id_employee");
                string login = Reader.GetString("login");
                string password = Reader.GetString("password");
                string lastName = Reader.GetString("lastname");
                string firstName = Reader.GetString("firstname");
                string surName = Reader.GetString("surname");
                decimal phonenumber = Reader.GetInt64("phonenumber");
                users.Add(new user(id, login, password, lastName, firstName, surName, phonenumber));
                userIterator++;
            }
        }

        public string addUser(string login, string password, string firstname, string lastname, string surname, string phonenumber)
        {
            //INSERT INTO `employee` (`Id`, `Login`, `Password`, `Firstname`, `Lastname`, `Surname`, `Phonenumber`) VALUES ('0', 'Morik', '301005', 'Katya', 'Krasina', 'Viktorovna', '7920643100')
            try
            {
                Reader.Close();
                command.CommandText = ($"INSERT INTO `employee` (`Id`, `Login`, `Password`, `Firstname`, `Lastname`, `Surname`, `Phonenumber`) VALUES ('0', '{login}', '{password}', '{firstname}', '{lastname}', '{surname}', '{phonenumber}')");
                command.ExecuteNonQuery();
                authenticationUser();
                return "Пользователь успешно создан!";
            }
            catch {return "Извините произошла ошибка!";}
        }
        public string delUser(string id)
        {
            try
            {
                Reader.Close();
                command.CommandText = ($"DELETE FROM `employee` WHERE `employee`.`Id` = {id}");
                command.ExecuteNonQuery();
                authenticationUser();
                return "Пользователь удалён!";
            }
            catch { return "Извините произошла ошибка!"; }
        }

        public bool identification(string login, string password)
        {
            foreach(user user in users) if(user.login == login && user.password == password) return true;
            return false;
        }

        public void readAllReports()
        {
            int Iterator = 0;
            Reader.Close();
            command.CommandText = "SELECT * FROM `reports`";
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                Int64 id = Reader.GetInt64("id_report");
                int airData = Reader.GetInt32("id_AirData");
                int radioactiveData = Reader.GetInt32("id_RadioactiveData");
                int soilData = Reader.GetInt32("id_SoilData");
                int waterData = Reader.GetInt32("id_WaterData");
                string description = Reader.GetString("Description");
                DateTime date = Reader.GetDateTime("Date");
                reports.Add(new report(id,date,description,airData,radioactiveData,soilData,waterData));
                Iterator++;
            }
        }

        public string readData(string commandText)
        {
            Reader.Close();
            command.CommandText = commandText;
            Reader = command.ExecuteReader();
            string thisrow = "";
            while (Reader.Read())
                for (int i = 0; i < Reader.FieldCount; i++)
                    thisrow += Reader.GetValue(i).ToString() + ";";
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
