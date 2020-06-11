using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace Logic.Tests
{
    [TestClass()]
    public class HomePageInteractionsTests
    {
        HomePageInteractions Home = new HomePageInteractions();
        [TestMethod()]
        #region Successful
        public void GetAllPortfoliosTest()
        {
            Home.GetAllPortfolios();
            Assert.Fail();
        }

        [TestMethod()]
        public void GetVideoUrlTest()
        {
            Home.GetVideoUrl();
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAudioUrlTest()
        {
            Home.GetAudioUrl();
            Assert.Fail();
        }
        #endregion
        #region Failure
        #endregion
    }
}