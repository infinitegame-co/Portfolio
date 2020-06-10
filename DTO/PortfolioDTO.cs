using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PortfolioDTO
    {
        //private readonly PortfolioAccess

        public int Id { get; set; }
        public List<string> PageCategory { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
        public List<string> Comments { get; set; }

        public PortfolioDTO(int Id, List<string> PageCategory, string Content, DateTime CreationDate, List<string> Comments, DateTime EditDate = default)
        {
            this.Id = Id;
            this.PageCategory = PageCategory;
            this.Content = Content;
            this.CreationDate = CreationDate;
            this.Comments = Comments;
            this.EditDate = EditDate == default ? CreationDate : EditDate;
        }
    }
}
