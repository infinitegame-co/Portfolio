using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL.Access.Test;

namespace Logic.Tests
{
    //ExpectedException(typeof(Exception)) for testing with exceptions
    [TestClass()]
    public class UserLogicTests
    {
        TAccountAccess AccountAccess = new TAccountAccess();
        UserLogic Logic;
        [TestMethod()]
        #region Successful
        public void CheckPasswordsSuccessTest()
        {
            Logic = new UserLogic(AccountAccess);
            Logic.CheckPasswords("", "");
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateAccountSuccessTest()
        {
            Logic = new UserLogic(AccountAccess);
            AccountDTO Account = new AccountDTO(1, "", "");
            Logic.CreateAccount(Account);
            Assert.Fail();
        }

        [TestMethod()]
        public void LogInSuccessTest()
        {
            Logic = new UserLogic(AccountAccess);
            AccountDTO Account = new AccountDTO(1, "", "");
            Logic.LogIn(Account);
            Assert.Fail();
        }
        #endregion
        #region Failure
        [TestMethod()]
        public void CreateAccountTakenEmailTest()
        {
            Logic = new UserLogic(AccountAccess);
            AccountDTO Account = new AccountDTO(1, "", "");
            Logic.CreateAccount(Account);
            Assert.Fail();
        }
        [TestMethod()]
        public void CreateAccountNonMatchingPasswordTest()
        {
            Logic = new UserLogic(AccountAccess);
            AccountDTO Account = new AccountDTO(1, "", "");
            Logic.CreateAccount(Account);
            Assert.Fail();
        }
        [TestMethod()]
        public void CreateAccountNicknameTakenTest()
        {
            Logic = new UserLogic(AccountAccess);
            AccountDTO Account = new AccountDTO(1, "", "");
            Logic.CreateAccount(Account);
            Assert.Fail();
        }
        [TestMethod()]
        public void CheckPasswordFailTest()
        {
            Logic = new UserLogic(AccountAccess);
            Logic.CheckPasswords("", "");
            Assert.Fail();
        }
        [TestMethod()]
        public void CheckPasswordNonExistingUserTest()
        {
            Logic = new UserLogic(AccountAccess);
            Logic.CheckPasswords("", "");
            Assert.Fail();
        }
        [TestMethod()]
        public void LoginNoAccountTest()
        {
            Logic = new UserLogic(AccountAccess);
            AccountDTO Account = new AccountDTO(1, "", "");
            Logic.LogIn(Account);
            Assert.Fail();
        }
        [TestMethod()]
        public void LoginWrongPasswordTest()
        {
            Logic = new UserLogic(AccountAccess);
            AccountDTO Account = new AccountDTO(1, "", "");
            Logic.LogIn(Account);
            Assert.Fail();
        }

        #endregion
    }
}