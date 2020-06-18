using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL.Interfaces;
using DAL.Access.Test;
using System.IO;

namespace Logic.Tests
{
    [TestClass()]
    public class AdminInteractionsTests
    {
        IPortfolioAccess portfolioAccess = new TPortfolioAccess();
        IGuestBookAccess guestBookAccess = new TGuestBookAccess();
        AdminInteractions Admin;
        [TestMethod()]
        #region successful
        public void CreatePortFolioSuccessTest()
        {
            Admin = new AdminInteractions(portfolioAccess, guestBookAccess);
            PortfolioDTO portfolio = new PortfolioDTO(1, "TestTitle", new List<string>(), "Lorem Ipsum", DateTime.MinValue, new List<string>());

            Admin.CreatePortFolio(portfolio);
            PortfolioDTO latest = portfolioAccess.GetLatestEntry();

            Assert.AreEqual(portfolio.Id, latest.Id);
            Assert.AreEqual(portfolio.Title, latest.Title);
            Assert.AreEqual(portfolio.PageCategory, latest.PageCategory);
            Assert.AreEqual(portfolio.Content, latest.Content);
            Assert.AreEqual(portfolio.CreationDate, latest.CreationDate);
            Assert.AreEqual(portfolio.Comments, latest.Comments);
            Assert.AreEqual(portfolio.CreationDate, latest.EditDate);
        }

        [TestMethod()]
        public void EditPortfolioSuccessTest()
        {
            Admin = new AdminInteractions(portfolioAccess, guestBookAccess);
            PortfolioDTO Changes = new PortfolioDTO(0, "TestTitle", null, "Lorem Ipsum", DateTime.MinValue, null);
            PortfolioDTO Expected = new PortfolioDTO(0, "TestTitle", new List<string>(), "Lorem Ipsum", new DateTime(2020, 01, 01), new List<string>(), DateTime.Today);
            Expected.Comments.Add("Jimmy John Jr");
            Expected.PageCategory.Add("Test");
            Admin.EditPortfolio(Changes.Id, Changes);
            PortfolioDTO Result = portfolioAccess.Read(0);

            Assert.AreEqual(Expected.Id, Result.Id);
            Assert.AreEqual(Expected.Title, Result.Title);
            Assert.AreEqual(Expected.PageCategory.Count, Result.PageCategory.Count); //idk
            Assert.AreEqual(Expected.Content, Result.Content);
            Assert.AreEqual(Expected.CreationDate, Result.CreationDate); //wrong variable
            Assert.AreEqual(Expected.Comments.Count, Result.Comments.Count); //idk
            Assert.AreEqual(Expected.EditDate, Result.EditDate);
        }

        [TestMethod(),ExpectedException(typeof(FileNotFoundException))]
        public void DeletePortFolioSuccessTest()
        {
            Admin = new AdminInteractions(portfolioAccess, guestBookAccess);
            int index = 0;

            Admin.DeletePortFolio(index);

            PortfolioDTO result = Admin.GetPortfolio(index);//should return filenotfoundexception
            Assert.Fail();
        }
        #endregion
        #region Failure
        #endregion
    }
}