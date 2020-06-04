using System;
using Poolside.Models;
using DAL.TestAccess;
using Logic;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace Logic
{
    public class Account
    {
        private readonly TestAccess DBAccess;

        private UserLogic userlogic = new UserLogic();
        public Account(TestAccess access)
        {
            DBAccess = access;
        }
        public void LogIn(LoginViewModel loginViewModel)
        {
            if (userlogic.CheckPasswords(loginViewModel.Password, loginViewModel.Email))
            {
                //return positive login back
            }
            //else return negative login back
        }

        public void CreateAccount(LoginViewModel loginViewModel)
        {
            CreateHashedPassword(loginViewModel.Password);//not secure, not important right now.
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
    }
}
