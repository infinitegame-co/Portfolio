using System;
using DAL.Interfaces;
using DTO;

namespace DAL.Access
{
    public class AccountAccess : IAccountAccess
    {
        public AccountDTO Get(AccountDTO user)
        {
            return new AccountDTO(1, "", "", "");
        }

        public void Create(AccountDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Update(AccountDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public AccountDTO Read(int index)
        {
            throw new NotImplementedException();
        }

        public int GetLength()
        {
            throw new NotImplementedException();
        }

        public AccountDTO GetLatestEntry()
        {
            throw new NotImplementedException();
        }
    }
}
