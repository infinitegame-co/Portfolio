using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL.Access.Test
{
    internal class TestData
    {
        internal List<AccountDTO> Users;
        internal List<GuestBookDTO> GuestBookEntries;
        internal List<PortfolioDTO> Portfolios;

        internal TestData()
        {
            Users = new List<AccountDTO>();
            GuestBookEntries = new List<GuestBookDTO>();
            Portfolios = new List<PortfolioDTO>();

            Users.Add(new AccountDTO(0, "Jim@Jim.com","Jim" ,"D9B5F58F0B38198293971865A14074F59EBA3E82595BECBE86AE51F1D9F1F65E"));
            GuestBookEntries.Add(new GuestBookDTO(0, DateTime.MinValue, "This is good.", "Jim"));
            PortfolioDTO PORTFOLIO1 = new PortfolioDTO(0, new List<string>(), "This is pretty short for a portfolio.", DateTime.MinValue, new List<string>());
            PORTFOLIO1.Comments.Add("Jimmy John Jr");
            PORTFOLIO1.PageCategory.Add("Test");
            Portfolios.Add(PORTFOLIO1);
        }
    }
}
