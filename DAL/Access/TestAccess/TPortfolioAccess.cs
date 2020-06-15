using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;
using DAL.Models;
using DTO;

namespace DAL.Access.Test
{
    public class TPortfolioAccess : IPortfolioAccess
    {
        TestData test = new TestData();
        public void Create(PortfolioDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public PortfolioDTO Get(PortfolioDTO obj)
        {
            foreach (PortfolioDTO port in test.Portfolios)
            {
                if (port.Title == obj.Title && port.CreationDate == obj.CreationDate && port.Content == obj.Content)
                {
                    return port;
                }
            }
            return null;
        }

        public List<PortfolioDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<string> GetCategories(int index)
        {
            throw new NotImplementedException();
        }

        public PortfolioDTO GetLatestEntry()
        {
            throw new NotImplementedException();
        }

        public PortfolioDTO Read(int index)
        {
            foreach (PortfolioDTO port in test.Portfolios)
            {
                if (port.Id == index)
                {
                    return port;
                }
            }
            return null;
        }

        public void Update(PortfolioDTO Original, PortfolioDTO Replacement)
        {
            Replacement.Id = Original.Id;
            test.Portfolios[Original.Id] = Replacement;
        }
    }
}
