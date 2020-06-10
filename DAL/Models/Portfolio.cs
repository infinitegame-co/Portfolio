using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public List<string> PageCategory { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
        public List<string> Comments { get; set; }
    }
}
