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

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public AccountDTO(int Id, string Email, string Password)
        {
            this.Id = Id;
            this.Email = Email;
            this.Password = Password;
        }
    }
}
