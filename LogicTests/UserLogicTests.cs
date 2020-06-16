using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL.Access.Test;
using System.IO;

namespace Logic.Tests
{
    [TestClass()]
    public class UserLogicTests
    {
        TAccountAccess AccountAccess = new TAccountAccess();
        UserLogic Logic;

        #region Successful
        [TestMethod()]
        public void CheckPasswordsSuccessTest()
        {
            Logic = new UserLogic(AccountAccess);
            AccountDTO Login = new AccountDTO(0, "Jim@Jim.com", "Jim", "Test123");
            bool result = Logic.CheckPasswords(Login);
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void CreateAccountSuccessTest()
        {
            Logic = new UserLogic(AccountAccess);
            AccountDTO Account = new AccountDTO(1, "John@Jim.com", "John", "Test234");
            Logic.CreateAccount(Account);
            Assert.IsTrue(AccountAccess.GetLatestEntry() == Account);
        }
        [TestMethod()]
        public void LogInSuccessTest()
        {
            Logic = new UserLogic(AccountAccess);
            AccountDTO Account = new AccountDTO(0, "Jim@Jim.com", "Jim", "Test123");
            AccountDTO Hashed = new AccountDTO(0, "47357D5BF135BAFB5E2CEF5C1EB0C050DF24BD3DF98EBC1C904D63C0CFF11C49", "Jim", "D9B5F58F0B38198293971865A14074F59EBA3E82595BECBE86AE51F1D9F1F65E");
            AccountDTO Result = Logic.LogIn(Account);
            Assert.AreEqual(Hashed.Id, Result.Id);
            Assert.AreEqual(Hashed.Email, Result.Email);
            Assert.AreEqual(Hashed.NickName, Result.NickName);
            Assert.AreEqual(Hashed.Password, Result.Password);
            //Assert.AreEqual(Hashed, Result); want dit werkt blijkbaar niet
        }
        #endregion

        #region Failure
        [TestMethod()]//, ExpectedException(typeof(Exception))]//would work as well but is not what is desired 
        public void CreateAccountTakenEmailTest()
        {
            Logic = new UserLogic(AccountAccess);
            AccountDTO Account = new AccountDTO(1, "Jim@Jim.com", "John", "Test345");
            Logic.CreateAccount(Account);
            Assert.IsFalse(AccountAccess.GetLatestEntry() == Account);
        }
        //[TestMethod()]
        //public void CreateAccountNonMatchingPasswordTest() //add this if decided to implement this functionality 
        //{
        //    Logic = new UserLogic(AccountAccess);
        //    AccountDTO Account = new AccountDTO(1, "","", "");
        //    Logic.CreateAccount(Account);
        //    Assert.Fail();
        //}
        [TestMethod()]
        public void CreateAccountNicknameTakenTest()
        {
            Logic = new UserLogic(AccountAccess);
            AccountDTO Account = new AccountDTO(1, "John@Jim.com", "Jim", "Test345");
            Logic.CreateAccount(Account);
            Assert.IsFalse(AccountAccess.GetLatestEntry() == Account);
        }
        [TestMethod()]
        public void CheckPasswordFailTest()
        {
            Logic = new UserLogic(AccountAccess);
            AccountDTO Login = new AccountDTO(0, "Jim@Jim.com", "Jim", "Test345");
            bool result = Logic.CheckPasswords(Login);
            Assert.IsFalse(result);
        }
        [TestMethod(), ExpectedException(typeof(FileNotFoundException))]
        public void CheckPasswordNonExistingUserTest()
        {
            Logic = new UserLogic(AccountAccess);
            AccountDTO Login = new AccountDTO(1, "John@jim.com", "John", "Test345");
            bool result = Logic.CheckPasswords(Login);
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void LoginNoAccountTest()
        {
            Logic = new UserLogic(AccountAccess);
            AccountDTO Account = new AccountDTO(1, "John@Jim.com", "John", "Test345");
            AccountDTO Hashed = new AccountDTO(1, "A16AC45023443BD3A321A7A9B30BF7C02110D3670159934F242516E19546F66B", "John", "405B43154D5170F5F7C2D6DDCB7492937D382609D96556C5C3BFC065380A29D6");
            AccountDTO Result = Logic.LogIn(Account);
            Assert.IsTrue(Result == null);
        }
        [TestMethod()]
        public void LoginWrongPasswordTest()
        {
            Logic = new UserLogic(AccountAccess);
            AccountDTO Account = new AccountDTO(0, "Jim@Jim.com", "Jim", "Test345");
            AccountDTO Hashed = new AccountDTO(0, "47357D5BF135BAFB5E2CEF5C1EB0C050DF24BD3DF98EBC1C904D63C0CFF11C49", "Jim", "D9B5F58F0B38198293971865A14074F59EBA3E82595BECBE86AE51F1D9F1F65E");
            AccountDTO Result = Logic.LogIn(Account);
            Assert.IsTrue(Result == null);
            //Assert.AreNotEqual(Hashed.Password, Result.Password);//this is what it should be checking
        }

        #endregion
    }
}