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
        private readonly IGuestBookAccess guestBookAccess;
        public UserInteractions(IPortfolioAccess portfolioAccess, IGuestBookAccess guestBookAccess)
        {
            this.portfolioAccess = portfolioAccess;
            this.guestBookAccess = guestBookAccess;
        }
        public UserInteractions(IPortfolioAccess portfolioAccess)
        {
            this.portfolioAccess = portfolioAccess;
        }
        public UserInteractions(IGuestBookAccess guestBookAccess)
        {
            this.guestBookAccess = guestBookAccess;
        }

        public void PostComment(AccountDTO User, PortfolioDTO portfolio, string Comment)
        {
            PortfolioDTO original = portfolioAccess.Get(portfolio);
            if (!String.IsNullOrEmpty(User.NickName))
            {
                if (original != null)
                {
                    portfolio.Comments.Add($"{User.NickName} posted: {Comment}");
                    portfolioAccess.Update(original, portfolio);
                    return;
                }
            }
            throw new Exception("No nickname found");
        }

        public void WriteInGuestBook(GuestBookDTO guestBook)
        {
            if (!String.IsNullOrEmpty(guestBook.Message))
            {

                if (!String.IsNullOrEmpty(guestBook.NickName))
                {
                    guestBookAccess.Create(guestBook);
                    return;
                }
                throw new Exception("No nickname found");
            }
            throw new Exception("No message found");
        }
    }
}
