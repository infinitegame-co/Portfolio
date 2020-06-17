using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;
using DTO;

namespace Logic
{
    public class HomePageInteractions
    {
        private readonly IPortfolioAccess portfolioAccess;
        private readonly IGuestBookAccess guestBookAccess;
        public HomePageInteractions(IPortfolioAccess portfolioAccess, IGuestBookAccess guestBookAccess)
        {
            this.portfolioAccess = portfolioAccess;
            this.guestBookAccess = guestBookAccess;
        }
        public List<PortfolioDTO> GetAllPortfolios()
        {
            return new List<PortfolioDTO>();
        }

        public List<GuestBookDTO> GetAllGuestBooks()
        {
            List<GuestBookDTO> entries = guestBookAccess.GetAllEntries();
            return entries;
        }

        public string GetVideoUrl()
        {
            return "";
        }

        public string GetAudioUrl()
        {
            return "";
        }
    }
}
