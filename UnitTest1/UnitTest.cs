using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DHL_clone.Persistency;
using DHL_clone.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Newtonsoft.Json;

namespace UnitTest1
{
    [TestClass]
    public class UnitTesting
    {
        [TestMethod]
        public void RegistrationTestMethod()
        {
            var u = new User
            {
                Email = "a@a.com",
                Password = "1234",
                Name = "Bob",
                Address = "Here",
                Phone = 12345678,
                Type = 1
            };

            var e = PersistencyWebApi.GetUsers().Result.Count;
            PersistencyWebApi.Register(u);
            var a = PersistencyWebApi.GetUsers().Result.Count;
            Assert.AreEqual(a, e + 1);
        }

        [TestMethod]
        public void LoginTestMethod()
        {
            var u = new User
            {
                Email = "a@a.com",
                Password = "1234"
            };
            var user = PersistencyWebApi.Login(u).Result;
            int loggedUserType = user.Type;
            Assert.AreEqual(1, loggedUserType);
        }
    }
}
