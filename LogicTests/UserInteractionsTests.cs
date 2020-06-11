using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace Logic.Tests
{
    [TestClass()]
    public class UserInteractionsTests
    {
        UserInteractions Interactions = new UserInteractions();
        [TestMethod()]
        #region Successfull
        public void PostCommentTest()
        {
            Interactions.PostComment();
            Assert.Fail();
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