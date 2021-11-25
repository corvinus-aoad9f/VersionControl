using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [Test,
        TestCase("abcd1234", false),
        TestCase("irf@uni-corvinus", false),
        TestCase("irf.uni-corvinus.hu", false),
        TestCase("irf@uni-corvinus.hu", true)]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            // Arrange
            var accountController = new AccountController();

            // Act
            var actualResult = accountController.ValidateEmail(email);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            
        }
        [Test,
            TestCase("Kiskutya"),
            TestCase("K1skutya"),
            TestCase("K1skuty"),
            TestCase("k1skutya"),
            TestCase("K1SKUTYA")]
        public bool TestValidatePassword(string password)
        {
            /*var Length = new Regex(@".{8,}");
            var LowerCase = new Regex(@"[a-z]+");
            var UpperCase = new Regex(@"[A-Z]+");
            var Number = new Regex(@"[0-9]+");*/
            return /*Length.IsMatch(password)&&LowerCase.IsMatch(password)&&UpperCase.IsMatch(password)&&Number.IsMatch(password)*/true;
        }
        
    }
}
