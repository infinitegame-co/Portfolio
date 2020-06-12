using System;
using System.Text;
using System.Security.Cryptography;
using DTO;
using DAL.Interfaces;

namespace Logic
{
    public class UserLogic
    {
        private readonly IAccountAccess Account;
        public UserLogic(IAccountAccess Account)
        {
            this.Account = Account;
        }
        public void LogIn(AccountDTO Account)
        {
            if (CheckPasswords(Account.Password, Account.Email))
            {
                //return positive login back
            }
            //else return negative login back
        }

        public void CreateAccount(AccountDTO Account)
        {
            CreateHashedPassword(Account.Password);//not secure, not important right now.
        }


        private string CreateHashedPassword(string Password)
        {//TODO: add salting before publishing
            StringBuilder sb = new StringBuilder();
            string hashed = "";
            byte[] temp;
            using (HashAlgorithm hash = SHA256.Create())
            {
                temp = hash.ComputeHash(Encoding.UTF8.GetBytes(Password));
            }
            foreach (byte bt in temp)
            {
                sb.Append(bt.ToString("X2"));
            }
            hashed = sb.ToString();
            return hashed;
        }

        public bool CheckPasswords(string password, string email)
        {
            string tempPassword = password; //TODO: pass password through hashing and salting process
            return tempPassword == GetHashedPassword(email);
        }

        private string GetHashedPassword(string email)
        {
            //access database and request password from email
            return "";
        }
    }
}
