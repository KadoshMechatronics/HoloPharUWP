using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
namespace DataContainer
{
    public static class DataAccess
    {
        public static void InitializeDatabase()
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=HoloDB.db"))
            {
                db.Open();

                //String tableCommand = "drop TABLE Users";
                //SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                //createTable.ExecuteNonQuery();

                String tableCommand = "CREATE TABLE IF NOT EXISTS Users ( [ID] INTEGER PRIMARY KEY AUTOINCREMENT,[Name] nvarchar(100) ,[Mobile] nvarchar(100) ,[Address] nvarchar(500),[FB] nvarchar(500), [Email] nvarchar(500), Gender Integer, Year Integer)";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteNonQuery();


                tableCommand = "CREATE TABLE IF NOT EXISTS PatientHistory ( [ID] INTEGER PRIMARY KEY AUTOINCREMENT,[UserID] int REFERENCES [Users] ([ID]) On Delete SET NULL,[DOB] smalldatetime,[Disease] nvarchar(500),[Drug1] nvarchar(500),[Drug2] nvarchar(500),[Drug3] nvarchar(500),[Drug4] nvarchar(500),[Drug5] nvarchar(500),[Doctor] nvarchar(500),[PerImage] image)";
                createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteNonQuery();
            }
        }
        public static void PatientHistoryAdd(string name, string mobile, string address, string FB)
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=HoloDB.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO PatientHistory VALUES (@UserID, @DOB, @Disease, @Drug1, @Drug2, @Drug3, @Drug4, @Drug5, @Doctor, @PerImage);";
                insertCommand.Parameters.AddWithValue("@Name", name);
                insertCommand.Parameters.AddWithValue("@Mobile", mobile);
                insertCommand.Parameters.AddWithValue("@Address", address);
                insertCommand.Parameters.AddWithValue("@FB", FB);

                insertCommand.ExecuteReader();

                db.Close();
            }

        }

        public static User UserAdd(string name, string mobile, string address, string FB,string email="", int gender=1, int year=2000)
        {
            int idd = 1;
            using (SqliteConnection db =
                new SqliteConnection("Filename=HoloDB.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO Users(Name, Mobile, Address, FB, Email, Gender, Year) VALUES (@Name, @Mobile, @Address, @FB, @Email, @Gender, @Year);";
                insertCommand.Parameters.AddWithValue("@Name", name);
                insertCommand.Parameters.AddWithValue("@Mobile", mobile);
                insertCommand.Parameters.AddWithValue("@Address", address);
                insertCommand.Parameters.AddWithValue("@FB", FB);
                insertCommand.Parameters.AddWithValue("@Email", email);
                insertCommand.Parameters.AddWithValue("@Gender", gender);
                insertCommand.Parameters.AddWithValue("@Year", year);

                insertCommand.ExecuteNonQuery();


                insertCommand.CommandText = "select id from users order by id desc LIMIT 1;";
                idd = int.Parse(insertCommand.ExecuteScalar().ToString());

                db.Close();
            }



            User a = GetUser(idd);
            return a;
        }
        public static List<User> GetUsers()
        {
            List<User> li = new List<User>();
            using (SqliteConnection db =
                new SqliteConnection("Filename=HoloDB.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "select * from Users;";
                SqliteDataReader dr = insertCommand.ExecuteReader();
                while (dr.Read())
                {
                    li.Add(new User() { Address = dr.GetString(2), FB = dr.GetString(3), Mobile = dr.GetString(1), Name = dr.GetString(0) });
                }
                db.Close();
            }

            return li;

        }
        public static User GetUser(int id)
        {
            User li = new User();
            using (SqliteConnection db =
                new SqliteConnection("Filename=HoloDB.db"))
            {
                db.Open();


                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "select * from Users where id=" + id;
                SqliteDataReader dr = insertCommand.ExecuteReader();
                if (dr.Read())
                {

                    li = new User() { Address = dr.GetString(2), FB = dr.GetString(3), Mobile = dr.GetString(1), Name = dr.GetString(0) };
                }
                db.Close();
            }

            return li;

        }
        public static void UpdateUser(int id, string mobile, string name = "", string address = "", string FB = "", string email = "", int gender = 1, int year = 2000)
        {
            User li = new User();
            using (SqliteConnection db =
                new SqliteConnection("Filename=HoloDB.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "update users set mobile=@mobile, name=@name, address=@address, FB=@FB, email=@email, gender=@gender, year=@year where id=@id";
                insertCommand.Parameters.AddWithValue("@mobile", mobile);
                insertCommand.Parameters.AddWithValue("@id", id);
                insertCommand.Parameters.AddWithValue("@Name", name);
                insertCommand.Parameters.AddWithValue("@Address", address);
                insertCommand.Parameters.AddWithValue("@FB", FB);
                insertCommand.Parameters.AddWithValue("@Email", email);
                insertCommand.Parameters.AddWithValue("@Gender", gender);
                insertCommand.Parameters.AddWithValue("@Year", year);
                insertCommand.ExecuteNonQuery();
                db.Close();
            }

        }
        public static string Connstr { get; set; } = "Filename=HoloDB.db";
        public static List<String> GetPatientHistory()
        {
            List<String> entries = new List<string>();

            using (SqliteConnection db =
                new SqliteConnection(Connstr))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from PatientHistory", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }

                db.Close();
            }

            return entries;
        }

    }

    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FB { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Year { get; set; }
        public bool IsMale { get; set; }

        public string GetGender 
        {
            get
            {
                if (IsMale)
                    return "ذكر";
                else
                    return "أنثى";
            }
        }
        public int Age 
        {
            get
            {
                return DateTime.Now.Year - Year;
            }
        }
          
    }
}
