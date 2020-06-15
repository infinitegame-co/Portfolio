using System;
using System.IO;
using DAL.Access.Test;
using DAL.Interfaces;
using DTO;

namespace DAL.Access.Test
{
    public class TAccountAccess : IAccountAccess
    {
        TestData Test = new TestData();
        public void Create(AccountDTO obj)
        {
            //make obj.Id lowest.
            obj.Id = GetLength();
            Test.Users.Add(obj);
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public AccountDTO Get(AccountDTO obj)
        {
            foreach (AccountDTO ac in Test.Users)
            {
                if (obj == ac)
                {
                    return ac;
                }
            }
            throw new FileNotFoundException();
        }

        public AccountDTO GetLatestEntry()
        {
            if (Test.Users.Count > 0)
            {
                return Test.Users[Test.Users.Count - 1];
            }
            return null;
        }

        public int GetLength()
        {
            return Test.Users.Count;
        }

        public AccountDTO Read(int index)
        {
            foreach (AccountDTO ac in Test.Users)
            {
                if (ac.Id == index)
                {
                    return ac;
                }
            }
            throw new FileNotFoundException();
        }

        public void Update(AccountDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
