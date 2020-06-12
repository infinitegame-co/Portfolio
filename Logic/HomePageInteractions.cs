using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace Logic
{
    public class HomePageInteractions
    {
        public HomePageInteractions(/*DBAccess Database*/)
        {

        }
        public List<PortfolioDTO> GetAllPortfolios()
        {
            return new List<PortfolioDTO>();
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
