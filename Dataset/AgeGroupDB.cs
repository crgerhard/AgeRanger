using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Runtime.Serialization;
using System.Configuration;

namespace DebitSuccess
{

    public class BaseAgeGroup
    {
        public long id { get; set; }
        public string minAge { get; set; }
        public string maxAge { get; set; }
        public string description { get; set; }
    }

    public class AgeGroupDB
    {
    }
}
