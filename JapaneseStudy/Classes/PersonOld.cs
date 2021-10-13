using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace JapaneseStudy.Classes
{
    public class PersonOld
    {

        public int PersonId { get; }
        public string Username { get; set; }
        public string Password { get; set; }

        public PersonOld(string usr, string pwd)
        {
            Username = usr;
            Password = pwd;
        }

        public PersonOld(int personId, IConfiguration config)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = $"{config.GetSection("ConnectionStrings").GetSection("Server").Value}.database.windows.net";
                builder.UserID = $"{config.GetSection("ConnectionStrings").GetSection("Username").Value}";
                builder.Password = $"{config.GetSection("ConnectionStrings").GetSection("Password").Value}";
                builder.InitialCatalog = $"{config.GetSection("ConnectionStrings").GetSection("Database").Value}";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    String sql = $"SELECT person_id, username, password FROM tbl_Person WHERE person_id = {personId}";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PersonId = reader.GetInt32(0);
                                Username = reader.GetString(1);
                                Password = reader.GetString(2);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void SaveToDB()
        {
            //update DB
        }
        
    }
}
