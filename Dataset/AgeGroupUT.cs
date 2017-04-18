using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Runtime.Serialization;
using System.Configuration;

namespace DebitSuccess
{

    public class AgeGroupUT : AgeGroupDB
    {

        public List<BaseAgeGroup> ListByAge(long age)
        {
            var result = new List<BaseAgeGroup>();
            var con = new SQLiteConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["csDebitSuccess"].ConnectionString;
            var sql = "SELECT [Id], [MinAge], [MaxAge], [Description] FROM AgeGroup WHERE ABS(MinAge) <= @Age AND IFNULL(MaxAge, @Age) >= @Age";
            var command = new SQLiteCommand(con);
            command.Parameters.Add("@Age", System.Data.DbType.Int64).Value = age;
            command.CommandText = sql;
            try
            {
                con.Open();
                var rdr = command.ExecuteReader();
                while (rdr.Read())
                {

                    result.Add(new BaseAgeGroup()
                    {
                        id = rdr["Id"] != DBNull.Value ? Convert.ToInt64(rdr["Id"]) : 0,
                        minAge = rdr["MinAge"] != DBNull.Value ? Convert.ToString(rdr["MinAge"]) : "",
                        maxAge = rdr["MaxAge"] != DBNull.Value ? Convert.ToString(rdr["MaxAge"]) : "",
                        description = rdr["Description"] != DBNull.Value ? Convert.ToString(rdr["Description"]) : "",
                    });
                }
            }
            catch (Exception ex) { }
            return result;
        }
    }
}
