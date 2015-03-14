using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace IntegrationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string tmp = ConfigurationManager.AppSettings["mySetting"];


        }
    }
}
