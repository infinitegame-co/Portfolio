using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace Logic.Tests
{
    [TestClass()]
    public class AdminInteractionsTests
    {
        AdminInteractions Admin = new AdminInteractions();
        [TestMethod()]
        #region successful
        public void CreatePortFolioTest()
        {
            Admin.CreatePortFolio();
            Assert.Fail();
        }

        [TestMethod()]
        public void UploadFileTest()
        {
            Admin.UploadFile();
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteFileTest()
        {
            Admin.DeleteFile();
            Assert.Fail();
        }

        [TestMethod()]
        public void EditPortfolioTest()
        {
            PortfolioDTO portfolio = new PortfolioDTO(1, new List<string>(), "", DateTime.MinValue, new List<string>());
            int index = 0;
            Admin.EditPortfolio(index, portfolio);
            Assert.Fail();
        }

        [TestMethod()]
        public void DeletePortFolioTest()
        {
            Admin.DeletePortFolio();
            Assert.Fail();
        }
        #endregion
        #region Failure
        #endregion
    }
}