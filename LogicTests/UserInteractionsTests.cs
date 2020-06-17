using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL.Access.Test;
using DAL.Interfaces;

namespace Logic.Tests
{
    [TestClass()]
    public class UserInteractionsTests
    {
        UserInteractions Interactions;
        IPortfolioAccess PortfolioAccess;
        IGuestBookAccess GuestBookAccess;
        [TestMethod()]
        #region Successfull
        public void PostCommentSuccessTest()
        {
            PortfolioAccess = new TPortfolioAccess();
            Interactions = new UserInteractions(PortfolioAccess);
            AccountDTO account = new AccountDTO(0, "Jim@Jim.com", "Jim", "Test123");
            PortfolioDTO portfolio = new PortfolioDTO(0, "Test", new List<string>(), "This is pretty short for a portfolio.", new DateTime(2020,01,01), new List<string>());
            string comment = "This is a test comment.";

            Interactions.PostComment(account, portfolio, comment);

            Assert.AreEqual(PortfolioAccess.Read(0).Comments[0], ("Jim posted: " + comment));
        }

        [TestMethod()]
        public void WriteInGuestBookSuccessTest()
        {
            GuestBookAccess = new TGuestBookAccess();
            Interactions = new UserInteractions(GuestBookAccess);
            GuestBookDTO GuestBook = new GuestBookDTO(1, DateTime.MinValue, "TestMessage", "Jim");

            Interactions.WriteInGuestBook(GuestBook);
            GuestBookDTO latest = GuestBookAccess.GetLatestEntry();

            Assert.AreEqual(GuestBook.PostDate, latest.PostDate);
            Assert.AreEqual(GuestBook.Message, latest.Message);
            Assert.AreEqual(GuestBook.NickName, latest.NickName);
        }
        #endregion
        #region Failure
        [TestMethod(),ExpectedException(typeof(Exception))]
        public void PostCommentNoNicknameTest()
        {
            PortfolioAccess = new TPortfolioAccess();
            Interactions = new UserInteractions(PortfolioAccess);
            AccountDTO account = new AccountDTO(0, "Jim@Jim.com", null, "Test123");
            PortfolioDTO portfolio = new PortfolioDTO(0, "Test", new List<string>(), "This is pretty short for a portfolio.", DateTime.MinValue, new List<string>());
            string comment = "This is a test comment.";

            Interactions.PostComment(account, portfolio, comment);

            Assert.Fail();
        }
        [TestMethod(), ExpectedException(typeof(Exception))]
        public void WriteInGuestBookNoNicknameTest()//if the user leaves the nickname field empty after clearing it
        {
            GuestBookAccess = new TGuestBookAccess();
            Interactions = new UserInteractions(GuestBookAccess);
            GuestBookDTO GuestBook = new GuestBookDTO(1, DateTime.MinValue, "TestMessage", null);

            Interactions.WriteInGuestBook(GuestBook);
            GuestBookDTO latest = GuestBookAccess.GetLatestEntry();

            Assert.Fail();
        }
        #endregion
    }
}