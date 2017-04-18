using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Runtime.Serialization;
using System.Configuration;
using System.Linq;

namespace DebitSuccess
{
    public class PersonUT : PersonDB
    {

        public List<BasePerson> ListWithAgeGroup(string whereClause = "")
        {
            var result = new List<BasePerson>();
            var con = new SQLiteConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["csDebitSuccess"].ConnectionString;
            var sql = "SELECT [Id], [FirstName], [LastName], [Age] from [Person] " + whereClause;
            var command = new SQLiteCommand(sql, con);
            try
            {
                con.Open();
                var rdr = command.ExecuteReader();
                while (rdr.Read())
                {

                    long age = rdr["Age"] != DBNull.Value ?
                                rdr["Age"].ToString() != "0" ? Convert.ToInt64(rdr["Age"]) : 0
                                : 0;

                    var ageGroupList = new AgeGroupUT().ListByAge(age);
                    var ageGroupDescription = "";
                    if (ageGroupList != null)
                        ageGroupDescription = ageGroupList.First().description;

                    result.Add(new BasePerson()
                    {
                        id = rdr["Id"] != DBNull.Value ? Convert.ToInt64(rdr["Id"]) : 0,
                        firstName = rdr["FirstName"] != DBNull.Value ? Convert.ToString(rdr["FirstName"]) : "",
                        lastName = rdr["LastName"] != DBNull.Value ? Convert.ToString(rdr["LastName"]) : "",
                        age = rdr["Age"] != DBNull.Value ?
                            rdr["Age"].ToString() != "0" ? Convert.ToString(rdr["Age"]) : ""
                            : "",
                        ageGroup = ageGroupDescription
                    });
                }
            }
            catch (Exception ex) { }
            return result;
        }

    }
}
