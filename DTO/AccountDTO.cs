using System;
using DTO;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace DTO
{
    public class AccountDTO
    {
        //private readonly AccountAccess;
        //TODO: make a method when converting from viewmodel to this where the id is got form the database
        public int Id { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }

        public AccountDTO()
        {

        }
        public AccountDTO(int Id, string Email, string NickName ,string Password)
        {
            this.Id = Id;
            this.Email = Email;
            this.NickName = NickName;
            this.Password = Password;
        }
    }
}
