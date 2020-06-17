using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DAL.Interfaces;
using DTO;

namespace Logic
{
    public class AdminInteractions
    {
        private readonly IPortfolioAccess portfolioAccess;
        public AdminInteractions(IPortfolioAccess portfolioAccess)
        {
            this.portfolioAccess = portfolioAccess;
        }
        public void CreatePortFolio(PortfolioDTO portfolio)
        {
            if (!String.IsNullOrEmpty(portfolio.Title) && portfolio.PageCategory != null &&
                !String.IsNullOrEmpty(portfolio.Content) && portfolio.CreationDate != null && portfolio.Comments != null)
            {
                portfolioAccess.Create(portfolio);
                return;
            }
            throw new Exception("One or more portfolio items are empty or null");
        }

        public PortfolioDTO GetPortfolio(int index)
        {
            return portfolioAccess.Read(index);
        }

        public void UploadFile()
        {

        }

        public void DeleteFile()
        {

        }

        public void EditPortfolio(int index, PortfolioDTO Changes)
        {
            PortfolioDTO original = portfolioAccess.Read(index);
            PortfolioDTO Update = new PortfolioDTO
                (
                original.Id, //portfolio Id
                String.IsNullOrEmpty(Changes.Title) ? original.Title : Changes.Title, //portfolio Title
                Changes.PageCategory == null ? original.PageCategory : Changes.PageCategory, //portfolio PageCategory list
                String.IsNullOrEmpty(Changes.Content) ? original.Content : Changes.Content, //portfolio Content
                original.CreationDate,
                Changes.Comments == null ? original.Comments : Changes.Comments,
                Changes.EditDate == original.EditDate ? original.EditDate : DateTime.Today
                );
            //add current date to Changes in the edit section
            portfolioAccess.Update(portfolioAccess.Get(original), Update);
        }

        public void DeletePortFolio(int index)
        {
            if (portfolioAccess.Read(index) != null)
            {
                portfolioAccess.Delete(index);
                return;
            }
            throw new FileNotFoundException();
        }
    }
}
