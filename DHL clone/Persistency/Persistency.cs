using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DHL_clone.Model;

namespace DHL_clone.Persistency
{
    class Persistency
    {
        private const string ConnectionString =
            //Local DB - doesn't work: file not found.
            "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\VSPC1\\Documents\\DHLDB.mdf;Integrated Security=True;Connect Timeout=30";
                //Online DB
                //"Server = tcp:jholmdbserver.database.windows.net,1433;Initial Catalog=OnlyDatabase; Persist Security Info=False;User ID=ServerName;Password=Ab12345678;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

        private const string SelectAllUsers = "select * from User";
        private const string SelectAllUserLogins = "select User.Email, User.Password from User";

        //Login
        public static User Login(User user)
        {
            string connString = ConnectionString;
            using (SqlConnection databaseConnection = new SqlConnection(connString))
            {
                databaseConnection.Open();
                IList<User> allLogins = GetAllUserLogins(databaseConnection);

                foreach (User _user in allLogins)
                {
                    if (user.Email == _user.Email)
                    {
                        if (user.Password == _user.Password)
                        {
                            return user;
                        }
                    }
                }
            }
            return user;
        }


        //Get All User Details
        private static IList<User> GetAllUsers(SqlConnection databaseConnection)
        {
            using (SqlCommand selectCommand = new SqlCommand(SelectAllUsers, databaseConnection))
            {
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    IList<User> users = new List<User>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string email = reader.GetString(1);
                            string password = reader.GetString(2);
                            string name = reader.GetString(3);
                            int phone = reader.GetInt32(4);
                            int type = reader.GetInt32(5);
                            string address = reader.GetString(6);

                            User user = new User()
                            {
                                Email = email,
                                Password = password,
                                Name = name,
                                Phone = phone,
                                Type = type,
                                Address = address
                            };
                            users.Add(user);
                        }
                    }
                    else
                    {
                        throw new Exception("Database is either empty or can't read database data");
                    }
                    return users;
                }
            }
        }

        //Get all User Logins
        private static IList<User> GetAllUserLogins(SqlConnection databaseConnection)
        {
            using (SqlCommand selectCommand = new SqlCommand(SelectAllUserLogins, databaseConnection))
            {
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    IList<User> users = new List<User>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string email = reader.GetString(1);
                            string password = reader.GetString(2);
                            int type = reader.GetInt32(5);

                            User user = new User()
                            {
                                Email = email,
                                Password = password,
                                Type = type,
                            };
                            users.Add(user);
                        }
                    }
                    else
                    {
                        throw new Exception("Database is either empty or can't read database data");
                    }
                    return users;
                }
            }
        }
    }
}
