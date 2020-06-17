using System;
using System.Collections.Generic;
using System.IO;
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
            obj.Id = test.Portfolios.Count;
            test.Portfolios.Add(obj);
        }

        public void Delete(int index)
        {
            if (!(index > (test.Portfolios.Count - 1)) && !(index < 0))
            {
                test.Portfolios.RemoveAt(index);
                return;
            }
            throw new IndexOutOfRangeException();
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
            if (test.Portfolios.Count > 0)
            {
                return test.Portfolios[test.Portfolios.Count - 1];
            }
            return null;
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
            throw new FileNotFoundException();
        }

        public void Update(PortfolioDTO Original, PortfolioDTO Replacement)
        {
            Replacement.Id = Original.Id;
            test.Portfolios[Original.Id] = Replacement;
        }
    }
}
