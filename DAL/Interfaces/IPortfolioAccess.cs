using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IPortfolioAccess : ICRUDAccess<GuestBookDTO>
    {
        public List<string> GetCategories(int index);
        public List<Portfolio> GetAll();
    }
}
