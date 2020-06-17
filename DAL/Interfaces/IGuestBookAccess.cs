using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL.Interfaces
{
    public interface IGuestBookAccess : ICRUDAccess<GuestBookDTO>
    {

        public List<GuestBookDTO> GetAllEntries();
        public List<GuestBookDTO> GetAmountOfEntries(int amount);
    }
}
