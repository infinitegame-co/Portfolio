using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace Logic.Tests
{
    [TestClass()]
    public class UserLogicTests
    {
        UserLogic Logic = new UserLogic();
        [TestMethod()]
        #region Successful
        public void CheckPasswordsTest()
        {
            Logic.CheckPasswords("", "");
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateAccountTest()
        {
            AccountDTO Account = new AccountDTO(1, "", "");
            Logic.CreateAccount(Account);
            Assert.Fail();
        }

        [TestMethod()]
        public void LogInTest()
        {
            AccountDTO Account = new AccountDTO(1, "", "");
            Logic.LogIn(Account);
            Assert.Fail();
        }
        #endregion
        #region Failure
        #endregion
    }
}