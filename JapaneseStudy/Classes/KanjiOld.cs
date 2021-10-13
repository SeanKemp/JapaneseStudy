using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace JapaneseStudy.Classes
{
    public class KanjiOld
    {
        public int KanjiId { get; set; }
        public string KanjiChar { get; set; }
        public string Meanings { get; set; }
        public string Story { get; set; }
        public string Primative { get; set; }
        public bool IsOnlyPrimative { get; set; }

        public KanjiOld(int kanjiId, IConfiguration config)
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

                    String sql = $"SELECT kanji_id, kanji, meanings, story, primative, is_only_primative FROM tbl_Kanji WHERE kanji_id = {kanjiId}";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                KanjiId = reader.GetInt32(0);
                                KanjiChar = reader.GetString(1);
                                Meanings = reader.GetString(2);
                                Story = reader.GetString(3);
                                Primative = reader.GetString(4);
                                IsOnlyPrimative = reader.GetBoolean(5);
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

        //public void FillKanjiById(int kanjiId, IConfiguration config)
        //{
        //    try
        //    {
        //        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        //        builder.DataSource = $"{config.GetSection("ConnectionStrings").GetSection("Server").Value}.database.windows.net";
        //        builder.UserID = $"{config.GetSection("ConnectionStrings").GetSection("Username").Value}";
        //        builder.Password = $"{config.GetSection("ConnectionStrings").GetSection("Password").Value}";
        //        builder.InitialCatalog = $"{config.GetSection("ConnectionStrings").GetSection("Database").Value}";

        //        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
        //        {
        //            Console.WriteLine("\nQuery data example:");
        //            Console.WriteLine("=========================================\n");

        //            String sql = $"SELECT kanji_id, kanji, meanings, story, primative, is_only_primative FROM tbl_Kanji WHERE kanji_id = {kanjiId}";

        //            using (SqlCommand command = new SqlCommand(sql, connection))
        //            {
        //                connection.Open();
        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        KanjiId = reader.GetInt32(0);
        //                        KanjiChar = reader.GetString(1);
        //                        Meanings = reader.GetString(2);
        //                        Story = reader.GetString(3);
        //                        Primative = reader.GetString(4);
        //                        IsOnlyPrimative = reader.GetBoolean(5);
        //                    }
        //                }
        //            }
        //            connection.Close();
        //        }
        //    }
        //    catch (SqlException e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }
        //}

        public bool CheckMeaning(string meaning)
        {
            IList<string> meanings = Meanings.Split(',');
            return meanings.Contains(meaning);
        }
    }

    public class Kanjis
    {
        //public IList<Kanji> KanjiList { get; set; }

        public Kanjis ()
        {
            //Get kanjis from database maybe
        }

        //Get kanjis from tbl_Kanji
        public Kanjis GetPrimativeKanjis()
        {

            return new Kanjis();
        }
    }
    
}
