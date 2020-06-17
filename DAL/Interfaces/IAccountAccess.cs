using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL.Interfaces
{
    public interface IAccountAccess : ICRUDAccess<AccountDTO>
    {
        public int GetLength();
        public List<string> GetAllNicknames();
        public List<string> GetAllEmails();
    }
}
