using System;
using System.Collections.Generic;
using DebitSuccess;
using System.Web.Script.Serialization;

namespace WcfDebitSuccess
{
    public class Person : IPerson
    {
        public String GetPersons()
        {
            var result = new List<BasePerson>();
            try
            {
                result = new PersonUT().ListWithAgeGroup();
            }
            catch (Exception ex)
            {

            }
            return new JavaScriptSerializer().Serialize(result);
        }
    }
}
