using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL.Access.Test;

namespace Logic.Tests
{
    [TestClass()]
    public class UserInteractionsTests
    {
        UserInteractions Interactions;
        TPortfolioAccess PortfolioAccess = new TPortfolioAccess();
        TGuestBookAccess GuestBookAccess = new TGuestBookAccess();
        [TestMethod()]
        #region Successfull
        public void PostCommentTest()
        {
            Interactions = new UserInteractions(PortfolioAccess);
            AccountDTO account = new AccountDTO(0, "Jim@Jim.com", "Jim", "Test123");
            PortfolioDTO portfolio = new PortfolioDTO(0, "Test", new List<string>(), "This is pretty short for a portfolio.", DateTime.MinValue, new List<string>());
            string comment = "This is a test comment.";
            Interactions.PostComment(account, portfolio, comment);
            Assert.AreEqual(PortfolioAccess.Read(0).Comments[0], ("Jim posted: " + comment));
        }

        [TestMethod()]
        public void WriteInGuestBookTest()
        {
            GuestBookDTO GuestBook = new GuestBookDTO(1, DateTime.MinValue, "", "");
            Interactions.WriteInGuestBook(GuestBook);
            Assert.Fail();
        }
        #endregion
        #region Failure
        #endregion
    }
}