using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IPortfolioAccess : ICRUDAccess<PortfolioDTO>
    {
        public List<string> GetCategories(int index);
        public List<PortfolioDTO> GetAll();
    }
}
