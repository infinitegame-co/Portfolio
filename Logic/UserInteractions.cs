using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL.Interfaces;

namespace Logic
{
    public class UserInteractions
    {
        private readonly IPortfolioAccess portfolioAccess;
        public UserInteractions(IPortfolioAccess portfolioAccess)
        {
            this.portfolioAccess = portfolioAccess;
        }

        public void PostComment(AccountDTO User, PortfolioDTO portfolio, string Comment)
        {
            PortfolioDTO original = portfolioAccess.Get(portfolio);
            if (original != null)
            {
                portfolio.Comments.Add($"{User.NickName} posted: {Comment}");
                portfolioAccess.Update(original, portfolio);
            }
        }

        public void WriteInGuestBook(DTO.GuestBookDTO guestBook)
        {

        }



    }
}
