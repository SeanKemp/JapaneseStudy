using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JapaneseStudy.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace JapaneseStudy.Classes
{
    public class KanjiReviewOld
    {
        private IConfiguration Config;
        public Person Person { get; set; }
        public Kanji KanjiChar { get; set; }
        public string ReviewType { get; set; }
        public int ReviewNo { get; set; }
        public bool IsLeech { get; set; }

        public KanjiReviewOld()
        {

        }

        

    }
    public class KanjiReviews
    {

        public Person Person { get; set; }
        public IList<KanjiReview> Reviews { get; set; }

        //Get all reviews for Person p
        public KanjiReviews(Person p, IConfiguration config)
        {
            Reviews = new List<KanjiReview>();
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

                    String sql = $"SELECT person_id, kanji_id, review_type, review_no, is_leech FROM tbl_KanjiReview WHERE person_id = {p.ID}";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                KanjiReview kr = new KanjiReview();
                                //kr.Person = p;
                                //kr.KanjiChar = new Kanji(reader.GetInt32(1), config);
                                kr.ReviewType = reader.GetString(2).Trim();
                                kr.ReviewNo = reader.GetInt32(3);
                                kr.IsLeech = reader.GetBoolean(4);
                                Reviews.Add(kr);
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

    }
}
