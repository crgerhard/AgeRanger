using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Runtime.Serialization;
using System.Configuration;

namespace DebitSuccess
{
    [DataContract]
    public class BasePerson
    {
        [DataMember(Name = "i")]
        public long id { get; set; }
        [DataMember(Name="f")]
        public string firstName { get; set; }
        [DataMember(Name = "l")]
        public string lastName { get; set; }
        [DataMember(Name = "a")]
        public string age { get; set; }
        [DataMember(Name = "ag")]
        public string ageGroup { get; set; }
    }

    public class PersonDB
    {
        public long Add(BasePerson user)
        {
            var result = 0;
            var con = new SQLiteConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["csDebitSuccess"].ConnectionString;
            var sql = "INSERT INTO [PERSON] (FirstName, LastName, Age) " +
            "VALUES (@FirstName, @LastName, @Age)";
            var command = new SQLiteCommand(con);
            command.Parameters.Add("@FirstName", System.Data.DbType.String).Value = user.firstName;
            command.Parameters.Add("@LastName", System.Data.DbType.String).Value = user.lastName;
            command.Parameters.Add("@Age", System.Data.DbType.String).Value = user.age;
            command.CommandText = sql;
            try
            {
                con.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex) {
                System.Diagnostics.Trace.TraceError(ex.ToString());
            }
            finally
            {
                con.Close();
                con.Dispose();
                command.Dispose();
            }
            return result;
        }

        public Boolean Update(BasePerson user)
        {
            var result = false;
            var con = new SQLiteConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["csDebitSuccess"].ConnectionString;
            var sql = "UPDATE [PERSON] set FirstName = @FirstName,  LastName = @LastName, Age = @Age " +
                      "WHERE [Id] = @Id";
            var command = new SQLiteCommand(con);
            command.Parameters.Add("@Id", System.Data.DbType.String).Value = user.id;
            command.Parameters.Add("@FirstName", System.Data.DbType.String).Value = user.firstName;
            command.Parameters.Add("@LastName", System.Data.DbType.String).Value = user.lastName;
            command.Parameters.Add("@Age", System.Data.DbType.String).Value = user.age;
            command.CommandText = sql;
            try
            {
                con.Open();
                var updated = command.ExecuteNonQuery();
                result = updated > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError(ex.ToString());
            }
            finally
            {
                con.Close();
                con.Dispose();
                command.Dispose();
            }
            return result;
        }

        public Boolean Delete(long userId)
        {
            var result = false;
            var con = new SQLiteConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["csDebitSuccess"].ConnectionString;
            var sql = "DELETE FROM [PERSON] WHERE [Id] = @Id";
            var command = new SQLiteCommand(con);
            command.Parameters.Add("@Id", System.Data.DbType.String).Value = userId;
            command.CommandText = sql;
            try
            {
                con.Open();
                var deleted = command.ExecuteNonQuery();
                result = deleted > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError(ex.ToString());
            }
            finally
            {
                con.Close();
                con.Dispose();
                command.Dispose();
            }
            return result;
        }

        public List<BasePerson> List()
        {
            var result = new List<BasePerson>();
            //var con = new System.Data.SQLite.SQLiteConnection("csDebitSuccess");
            var con = new SQLiteConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["csDebitSuccess"].ConnectionString;
            var sql = "SELECT [Id], [FirstName], [LastName], [Age] from [Person]";
            var command = new SQLiteCommand(sql, con);
            try
            {
                con.Open();
                var rdr = command.ExecuteReader();
                while (rdr.Read()) {
                    result.Add(new BasePerson()
                    {
                        id = rdr["Id"] != DBNull.Value ? Convert.ToInt64(rdr["Id"]) : 0,
                        firstName = rdr["FirstName"] != DBNull.Value ? Convert.ToString(rdr["FirstName"]) : "",
                        lastName = rdr["LastName"] != DBNull.Value ? Convert.ToString(rdr["LastName"]) : "",
                        age = rdr["Age"] != DBNull.Value ?
                            rdr["Age"].ToString() != "0" ? Convert.ToString(rdr["Age"]) : ""
                            : "",
                    });
                }
            }
            catch (Exception ex) { }
            return result;
        }
    }
}
