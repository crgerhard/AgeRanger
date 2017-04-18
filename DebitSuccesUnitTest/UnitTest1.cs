using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DebitSuccesUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var listUsersTest = new DebitSuccess.PersonUT().ListWithAgeGroup();

            var newUser = new DebitSuccess.BasePerson() { firstName = "First1", lastName = "Last1", age = "21" };
            var addUserTest = new DebitSuccess.PersonDB().Add(newUser);

        }
    }
}
