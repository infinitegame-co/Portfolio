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
        /// <summary>
        /// Creates new instance of UserLogic
        /// </summary>
        /// <param name="Account">Class that inherits from IAccountAcces which in turn inherits from ICrudAccess</param>
        public UserLogic(IAccountAccess Account)
        {
            this.Account = Account;
        }
        public AccountDTO LogIn(AccountDTO Login)
        {
            if (MatchingEmails(Login.Email))
            {
                if (CheckPasswords(Login))
                {
                    //return positive login back
                    Login.Password = CreateHashedString(Login.Password);
                    Login.NickName = Account.Get(Login).NickName;
                    Login.Email = CreateHashedString(Login.Email);
                    return Login;
                }
            }
            //else return negative login back
            return null;
        }
        public void CreateAccount(AccountDTO Login)
        {
            if (!MatchingEmails(Login.Email))
            {
                if (!MatchingNickName(Login.NickName))
                {
                    Login.Password = CreateHashedString(Login.Password);//not secure, not important right now.
                    Account.Create(Login);
                    return;
                }
                else
                {
                    //throw new Exception("Nickname already taken");
                }
            }
            else
            {
                //throw new Exception("Email is already taken");
            }
        }


        private string CreateHashedString(string Value)
        {//TODO: add salting before publishing
            using (HashAlgorithm hash = SHA256.Create())
            {
                StringBuilder sb = new StringBuilder();
                string hashed = "";
                byte[] temp = hash.ComputeHash(Encoding.UTF8.GetBytes(Value));
                foreach (byte bt in temp)
                {
                    sb.Append(bt.ToString("X2"));
                }
                hashed = sb.ToString();
                return hashed;
            }
        }
        public bool CheckPasswords(AccountDTO Login)
        {
            string tempPassword = CreateHashedString(Login.Password);
            return tempPassword == GetHashedPassword(Login);
        }
        private string GetHashedPassword(AccountDTO Login)
        {
            return Account.Read(Login.Id).Password;
        }
        private bool MatchingEmails(string email)
        {
            for (int i = 0; i < Account.GetLength(); i++)
            {
                if (Account.Read(i).Email == email)
                {
                    return true;
                }
            }
            return false;
        }
        private bool MatchingNickName(string nickName)
        {
            for (int i = 0; i < Account.GetLength(); i++)
            {
                if (Account.Read(i).NickName == nickName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
