using System;
using System.Collections.Generic;
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
                if (obj.Email == ac.Email && obj.Password == ac.Password)
                {
                    return ac;
                }
            }
            return null;
        }

        public List<string> GetAllEmails()
        {
            List<string> res = new List<string>();
            foreach (AccountDTO ac in Test.Users)
            {
                res.Add(ac.Email);
            }
            return res;
        }

        public List<string> GetAllNicknames()
        {
            List<string> res = new List<string>();
            foreach (AccountDTO ac in Test.Users)
            {
                res.Add(ac.NickName);
            }
            return res;
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
            return null;
        }

        public void Update(AccountDTO Original, AccountDTO Replacement)
        {
            throw new NotImplementedException();
        }
    }
}
