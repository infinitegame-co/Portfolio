using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;
using DTO;

namespace DAL.Access.Test
{
    public class TGuestBookAccess : IGuestBookAccess
    {
        private readonly TestData test = new TestData();
        public void Create(GuestBookDTO obj)
        {
            obj.Id = test.GuestBookEntries.Count;
            test.GuestBookEntries.Add(obj);
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public GuestBookDTO Get(GuestBookDTO obj)
        {
            throw new NotImplementedException();
        }

        public List<GuestBookDTO> GetAllEntries()
        {
            throw new NotImplementedException();
        }

        public List<GuestBookDTO> GetAmountOfEntries(int amount)
        {
            throw new NotImplementedException();
        }

        public GuestBookDTO GetLatestEntry()
        {
            if (test.GuestBookEntries.Count > 0)
            {
                return test.GuestBookEntries[test.GuestBookEntries.Count - 1];
            }
            return null;
        }

        public GuestBookDTO Read(int index)
        {
            throw new NotImplementedException();
        }

        public void Update(GuestBookDTO Original, GuestBookDTO Replacement)
        {
            throw new NotImplementedException();
        }
    }
}
