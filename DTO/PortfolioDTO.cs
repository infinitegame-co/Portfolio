﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PortfolioDTO
    {
        //private readonly PortfolioAccess
        //TODO: make a method when converting from viewmodel to this where the id is got form the database

        public int Id { get; set; }
        public string Title { get; set; }
        public List<string> PageCategory { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
        public List<string> Comments { get; set; }

        public PortfolioDTO(int Id,string Title ,List<string> PageCategory, string Content, DateTime CreationDate, List<string> Comments, DateTime EditDate = default)
        {
            this.Id = Id;
            this.Title = Title;
            this.PageCategory = PageCategory;
            this.Content = Content;
            this.CreationDate = CreationDate;
            this.Comments = Comments;
            this.EditDate = EditDate == default ? CreationDate : EditDate;
        }
    }
}
