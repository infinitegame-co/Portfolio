using System;
using System.Text;
using DTO;
using DAL.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace Logic
{
    public class UserLogic
    {
        private readonly IAccountAccess Account;
        private readonly ConversionLogic Convert;
        /// <summary>
        /// Creates new instance of UserLogic
        /// </summary>
        /// <param name="Account">Class that inherits from IAccountAcces which in turn inherits from ICrudAccess</param>
        public UserLogic(IAccountAccess Account)
        {
            Convert = new ConversionLogic(Account);
            this.Account = Account;
        }
        public AccountDTO LogIn(AccountDTO Login)
        {
            if (MatchingEmails(Login.Id, Login.Email))
            {
                if (CheckPasswords(Login))
                {
                    //return positive login back
                    Login.Password = Convert.CreateHashedString(Login.Password);
                    Login.NickName = Account.Get(Login).NickName;
                    Login.Email = Convert.CreateHashedString(Login.Email);
                    return Login;
                }
            }
            //else return negative login back
            return null;
        }
        public void CreateAccount(AccountDTO Login)
        {
            if (!MatchingEmails(Login.Id, Login.Email))
            {
                if (!MatchingNickName(Login.Id, Login.NickName))
                {
                    Login.Password = Convert.CreateHashedString(Login.Password);//not secure, not important right now.
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



        public bool CheckPasswords(AccountDTO Login)
        {
            string tempPassword = Convert.CreateHashedString(Login.Password);
            return tempPassword == GetHashedPassword(Login);
        }
        private string GetHashedPassword(AccountDTO Login)
        {
            AccountDTO res = Account.Read(Login.Id);
            if (res != null)
            {
                return res.Password;
            }
            return "";
        }
        private bool MatchingEmails(int index, string email)
        {
            List<string> res = Account.GetAllEmails();
            foreach (string ac in res)
            {
                if (ac == email)
                {
                    return true;
                }
            }
            return false;
        }
        private bool MatchingNickName(int index, string nickName)
        {
            List<string> res = Account.GetAllNicknames();
            foreach (string ac in res)
            {
                if (ac == nickName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
