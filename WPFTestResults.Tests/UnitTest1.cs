using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStorage;

namespace WPFTestResults.Tests
{
    [TestClass]
    public class UnitTest1
    {

        private static List<DataStorage.Login.Medewerker> gegevens = new List<DataStorage.Login.Medewerker>();
        [TestMethod]
        public void TestMethod1()
        {
            GeneralFunctionality.Functions.InitializeDatabaseConnection();
            gegevens = LoginUsers.GetSelectedUser("GS");
        }
    }
}
