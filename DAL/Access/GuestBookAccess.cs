using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;
using DTO;

namespace DAL.Access
{
    public class GuestBookAccess : IGuestBookAccess
    {
        public void Create(GuestBookDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public GuestBookDTO Get(GuestBookDTO obj)
        {
            throw new NotImplementedException();
        }

        public GuestBookDTO GetLatestEntry()
        {
            throw new NotImplementedException();
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
